using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ScoutsEncoder_WPF
{
    public class WaveHeader
    {
        public string sGroupID;      // RIFF
        public uint   dwFileLength;  // total file length minus 8, which is taken up by RIFF
        public string sRiffType;     // always WAVE

        /// <summary>
        /// Initializes a WaveHeader object with the default values.
        /// </summary>
        public WaveHeader()
        {
            sGroupID     = "RIFF";
            dwFileLength = 0;
            sRiffType    = "WAVE";
        }
    }

    public class WaveFormatChunk
    {
        public string sChunkID;          // Four bytes: "fmt "
        public uint   dwChunkSize;       // Length of header in bytes
        public ushort wFormatTag;        // 1 (MS PCM)
        public ushort wChannels;         // Number of channels (1 for Mono or 2 for Stereo)
        public uint   dwSamplesPerSec;   // Frequency of the audio in Hz... 44100
        public uint   dwAvgBytesPerSec;  // for estimating RAM allocation
        public ushort wBlockAlign;       // sample frame size, in bytes
        public ushort wBitsPerSample;    // bits per sample

        /// <summary>
        /// Initializes a format chunk with the following properties:
        /// Sample rate: 44100 Hz
        /// Channels: Mono
        /// Bit depth: 16-bit
        /// </summary>
        public WaveFormatChunk()
        {
            sChunkID         = "fmt ";
            dwChunkSize      = 16;
            wFormatTag       = 1;
            wChannels        = 1;
            dwSamplesPerSec  = 44100;
            wBitsPerSample   = 16;
            wBlockAlign      = (ushort)(wChannels * (wBitsPerSample / 8));
            dwAvgBytesPerSec = dwSamplesPerSec * wBlockAlign;
        }
    }

    public class WaveDataChunk
    {
        public string sChunkID;       // "data"
        public uint dwChunkSize;      // Length of header in bytes
        public short[] dotArray;      // 8-bit audio
        public short[] silenceArray;  // 8-bit audio

        /// <summary>
        /// Initializes a new data chunk with default values.
        /// </summary>
        public WaveDataChunk()
        {
            sChunkID     = "data";
            dwChunkSize  = 0;
            dotArray     = new short[0];
            silenceArray = new short[0];
        }
    }


    public class MorseCodeGenerator
    {
        // Header, Format, Data chunks
        WaveHeader header;
        WaveFormatChunk format;
        WaveDataChunk data;

        private string _encodedText;
        private const char _charsDelimeter = '+';
        private const char _wordsDelimeter = ' ';


        public MorseCodeGenerator(string encodedText, string charsDelimeter, string wordsDelimeter)
        {

            _encodedText = ModifyEncodedText(ref encodedText, charsDelimeter, wordsDelimeter);

            // Init chunks
            header = new WaveHeader();
            format = new WaveFormatChunk();
            data   = new WaveDataChunk();

            // Initialize the 16-bit array
            data.dotArray     = new short[format.dwSamplesPerSec / 10];
            data.silenceArray = new short[format.dwSamplesPerSec / 10]; //automatically Initialized with zeroes

            // Sine wave Properties
            int amplitude = 32760;  // Max amplitude for 16-bit audio
            double freq   = 750.0f;
            double periodOfWave = (Math.PI * 2 * freq) / (format.dwSamplesPerSec);

            // Fill dot array with sine waves
            for (uint i = 0; i < format.dwSamplesPerSec / 10; i++)
            {
                data.dotArray[i] = Convert.ToInt16(amplitude * Math.Sin(periodOfWave * i));
            }

            // Calculate data chunk size in bytes
            for (int index = 0; index < _encodedText.Length; index++)
            {
                switch (_encodedText[index])
                {
                    case '-': // 4 frames
                        data.dwChunkSize += (uint)((data.dotArray.Length * (format.wBitsPerSample / 8)) * 4);
                        break;

                    case '•': // 2 frames
                        data.dwChunkSize += (uint)((data.dotArray.Length * (format.wBitsPerSample / 8)) * 2);
                        break;

                    case _charsDelimeter: // 3 frames
                        data.dwChunkSize += (uint)((data.dotArray.Length * (format.wBitsPerSample / 8)) * 3);
                        break;

                    case _wordsDelimeter: // 7 frames
                        data.dwChunkSize += (uint)((data.dotArray.Length * (format.wBitsPerSample / 8)) * 7);
                        break;

                    default:
                        continue;
                }
            }
        }

        public void Save(string filePath)
        { 
            // Create a file (it always overwrites)
            FileStream fileStream = new FileStream(filePath, FileMode.Create);

            // Use BinaryWriter to write the bytes to the file
            BinaryWriter writer = new BinaryWriter(fileStream);

            // Write the header
            writer.Write(header.sGroupID.ToCharArray());
            writer.Write(header.dwFileLength);
            writer.Write(header.sRiffType.ToCharArray());

            // Write the format chunk
            writer.Write(format.sChunkID.ToCharArray());
            writer.Write(format.dwChunkSize);
            writer.Write(format.wFormatTag);
            writer.Write(format.wChannels);
            writer.Write(format.dwSamplesPerSec);
            writer.Write(format.dwAvgBytesPerSec);
            writer.Write(format.wBlockAlign);
            writer.Write(format.wBitsPerSample);

            // Write the data chunk
            writer.Write(data.sChunkID.ToCharArray());
            writer.Write(data.dwChunkSize);


            // Morse Code:
            // 1. The duration of a Dash is three times the duration of a dot.
            // 2. Each dot or dash within a character is followed by period of signal absence,
            //    called a space, equal to the dot duration.
            // 3. Letters are separated by a space of duration equal to three dots.
            // 4. Words are separated by a space of duration equal to seven dots.


            // Write the cipher
            for (int index = 0; index < _encodedText.Length; index++)
            {
                switch (_encodedText[index])
                {
                    case '-': // Dash = 3 dots + period

                        for (int i = 0; i < 3; i++)
                        {
                            foreach (short dataPoint in data.dotArray)
                                writer.Write(dataPoint);
                        }

                        foreach (short dataPoint in data.silenceArray)
                            writer.Write(dataPoint);

                        break;

                    case '•': // Dot = 1 dot + period

                        foreach (short dataPoint in data.dotArray)
                            writer.Write(dataPoint);

                        foreach (short dataPoint in data.silenceArray)
                            writer.Write(dataPoint);

                        break;

                    case _charsDelimeter: // Letter space = 3 dots

                        for (int i = 0; i < 3; i++)
                        {
                            foreach (short dataPoint in data.silenceArray)
                                writer.Write(dataPoint);
                        }

                        break;

                    case _wordsDelimeter: // Word Space = 7 dots

                        for (int i = 0; i < 7; i++)
                        {
                            foreach (short dataPoint in data.silenceArray)
                                writer.Write(dataPoint);
                        }

                        break;

                    default:
                        continue;
                }
            }

            writer.Seek(4, SeekOrigin.Begin);
            uint filesize = (uint)writer.BaseStream.Length;
            writer.Write(filesize - 8);

            // Clean up
            writer.Close();
            fileStream.Close();
        }


        private string ModifyEncodedText(ref string encodedText, string charsDelimeter, string wordsDelimeter)
        {
            // Replace sent delimeters with local delimeters
            encodedText = encodedText.Replace(charsDelimeter, _charsDelimeter.ToString())
                                     .Replace(wordsDelimeter, _wordsDelimeter.ToString());

            // Replace multiple new lines with 2 x words delimeter
            encodedText = Regex.Replace(encodedText, @"[\r\n]{2,}", new String(_wordsDelimeter, 2));

            string morseRegex = "[^\\-\\•]" + "\\" + _charsDelimeter + "\\" + _wordsDelimeter + "]";

            // Remove anything that doesn't belong to the morse syntax
            encodedText = Regex.Replace(encodedText, morseRegex, String.Empty);

            // Surround string with whitespaces to leave about 1 second
            // of silence at the begining and the end of the audio.
            encodedText = "  " + encodedText + "  ";

            return encodedText;
        }
    }
}
