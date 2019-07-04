using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ScoutsEncoder
{
    internal class WaveHeader
    {
        public uint dwFileLength;    // Total file length minus 8, which is taken up by RIFF
        public string sGroupId;      // RIFF
        public string sRiffType;     // Always WAVE

        public WaveHeader()
        {
            sGroupId = "RIFF";
            dwFileLength = 0;
            sRiffType = "WAVE";
        }
    }

    internal class WaveFormatChunk
    {
        public uint dwAvgBytesPerSec;    // For estimating RAM allocation
        public uint dwChunkSize;         // Length of header in bytes
        public uint dwSamplesPerSec;     // Frequency of the audio in Hz... 44100
        public string sChunkId;          // Four bytes: "fmt "
        public ushort wBitsPerSample;    // Bits per sample
        public ushort wBlockAlign;       // Sample frame size, in bytes
        public ushort wChannels;         // Number of channels (1 for Mono or 2 for Stereo)
        public ushort wFormatTag;        // 1 (MS PCM)

        public WaveFormatChunk()
        {
            sChunkId = "fmt ";
            dwChunkSize = 16;
            wFormatTag = 1;
            wChannels = 1;
            dwSamplesPerSec = 44100;
            wBitsPerSample = 16;
            wBlockAlign = (ushort) (wChannels * (wBitsPerSample / 8));
            dwAvgBytesPerSec = dwSamplesPerSec * wBlockAlign;
        }
    }

    internal class WaveDataChunk
    {
        public short[] dotArray;        // 8-bit audio
        public uint dwChunkSize;        // Length of header in bytes
        public string sChunkId;         // "data"
        public short[] silenceArray;    // 8-bit audio

        public WaveDataChunk()
        {
            sChunkId = "data";
            dwChunkSize = 0;
            dotArray = new short[0];
            silenceArray = new short[0];
        }
    }

    public class MorseCodeGenerator
    {

        private readonly WaveHeader _header;
        private readonly WaveFormatChunk _format;
        private readonly WaveDataChunk _data;

        private const char CharsDelimiter = '+';
        private const char WordsDelimiter = ' ';
        private readonly string _encodedText;


        public MorseCodeGenerator(string encodedText, string charsDelimiter, string wordsDelimiter, int speed)
        {
            _encodedText = ModifyEncodedText(ref encodedText, charsDelimiter, wordsDelimiter);

            // Init chunks
            _header = new WaveHeader();
            _format = new WaveFormatChunk();
            _data = new WaveDataChunk
            {
                dotArray = new short[_format.dwSamplesPerSec / 10 * (3 - speed)],
                silenceArray = new short[_format.dwSamplesPerSec / 10 * (3 - speed)]
            };

            // Sine wave Properties
            const int amplitude = 32760; // Max amplitude for 16-bit audio
            const double freq = 750.0f;
            var periodOfWave = Math.PI * 2 * freq / _format.dwSamplesPerSec;

            // Fill dot array with sine waves
            var size = _format.dwSamplesPerSec / 10 * (3 - speed);
            for (uint i = 0; i < size; i++) _data.dotArray[i] = Convert.ToInt16(amplitude * Math.Sin(periodOfWave * i));

            // Calculate data chunk size in bytes
            foreach (var c in _encodedText)
                switch (c)
                {
                    case '-': // 4 frames
                        _data.dwChunkSize += (uint) (_data.dotArray.Length * (_format.wBitsPerSample / 8) * 4);
                        break;

                    case '•': // 2 frames
                        _data.dwChunkSize += (uint) (_data.dotArray.Length * (_format.wBitsPerSample / 8) * 2);
                        break;

                    case CharsDelimiter: // 3 frames
                        _data.dwChunkSize += (uint) (_data.dotArray.Length * (_format.wBitsPerSample / 8) * 3);
                        break;

                    case WordsDelimiter: // 7 frames
                        _data.dwChunkSize += (uint) (_data.dotArray.Length * (_format.wBitsPerSample / 8) * 7);
                        break;

                    default:
                        continue;
                }
        }

        public void Save(string filePath)
        {
            // Create a file (it always overwrites)
            var fileStream = new FileStream(filePath, FileMode.Create);

            // Use BinaryWriter to write the bytes to the file
            var writer = new BinaryWriter(fileStream);

            // Write the header
            writer.Write(_header.sGroupId.ToCharArray());
            writer.Write(_header.dwFileLength);
            writer.Write(_header.sRiffType.ToCharArray());

            // Write the format chunk
            writer.Write(_format.sChunkId.ToCharArray());
            writer.Write(_format.dwChunkSize);
            writer.Write(_format.wFormatTag);
            writer.Write(_format.wChannels);
            writer.Write(_format.dwSamplesPerSec);
            writer.Write(_format.dwAvgBytesPerSec);
            writer.Write(_format.wBlockAlign);
            writer.Write(_format.wBitsPerSample);

            // Write the data chunk
            writer.Write(_data.sChunkId.ToCharArray());
            writer.Write(_data.dwChunkSize);

            // Morse Code:
            // 1. The duration of a Dash is three times the duration of a dot.
            // 2. Each dot or dash within a character is followed by period of signal absence,
            //    called a space, equal to the dot duration.
            // 3. Letters are separated by a space of duration equal to three dots.
            // 4. Words are separated by a space of duration equal to seven dots.

            // Write the cipher
            foreach (var c in _encodedText)
                switch (c)
                {
                    case '-': // Dash = 3 dots + period

                        for (var i = 0; i < 3; i++)
                            foreach (var dataPoint in _data.dotArray)
                                writer.Write(dataPoint);

                        foreach (var dataPoint in _data.silenceArray)
                            writer.Write(dataPoint);

                        break;

                    case '•': // Dot = 1 dot + period

                        foreach (var dataPoint in _data.dotArray)
                            writer.Write(dataPoint);

                        foreach (var dataPoint in _data.silenceArray)
                            writer.Write(dataPoint);

                        break;

                    case CharsDelimiter: // Letter space = 3 dots

                        for (var i = 0; i < 3; i++)
                            foreach (var dataPoint in _data.silenceArray)
                                writer.Write(dataPoint);

                        break;

                    case WordsDelimiter: // Word Space = 7 dots

                        for (var i = 0; i < 7; i++)
                            foreach (var dataPoint in _data.silenceArray)
                                writer.Write(dataPoint);

                        break;

                    default:
                        continue;
                }

            writer.Seek(4, SeekOrigin.Begin);
            var fileSize = (uint) writer.BaseStream.Length;
            writer.Write(fileSize - 8);

            // Clean up
            writer.Close();
            fileStream.Close();
        }

        private static string ModifyEncodedText(ref string encodedText, string charsDelimiter, string wordsDelimiter)
        {
            // Replace sent delimiters with local delimiters
            encodedText = encodedText.Replace(charsDelimiter, CharsDelimiter.ToString())
                .Replace(wordsDelimiter, WordsDelimiter.ToString());

            // Replace multiple new lines with 2 x words delimiter
            encodedText = Regex.Replace(encodedText, @"[\r\n]{2,}", new string(WordsDelimiter, 2));

            var morseRegex = "[^\\-\\•]" + "\\" + CharsDelimiter + "\\" + WordsDelimiter + "]";

            // Remove anything that doesn't belong to the morse syntax
            encodedText = Regex.Replace(encodedText, morseRegex, string.Empty);

            // Surround string with whitespaces to leave about 1 second
            // of silence at the beginning and the end of the audio.
            encodedText = " " + encodedText + " ";

            return encodedText;
        }
    }
}