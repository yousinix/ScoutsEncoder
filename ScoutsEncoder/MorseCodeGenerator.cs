using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoutsEncoder
{
    public class WaveHeader
    {
        public string sGroupID;   // RIFF
        public uint dwFileLength; // total file length minus 8, which is taken up by RIFF
        public string sRiffType;  // always WAVE

        /// <summary>
        /// Initializes a WaveHeader object with the default values.
        /// </summary>
        public WaveHeader()
        {
            dwFileLength = 0;
            sGroupID = "RIFF";
            sRiffType = "WAVE";
        }
    }

    public class WaveFormatChunk
    {
        public string sChunkID;         // Four bytes: "fmt "
        public uint dwChunkSize;        // Length of header in bytes
        public ushort wFormatTag;       // 1 (MS PCM)
        public ushort wChannels;        // Number of channels
        public uint dwSamplesPerSec;    // Frequency of the audio in Hz... 44100
        public uint dwAvgBytesPerSec;   // for estimating RAM allocation
        public ushort wBlockAlign;      // sample frame size, in bytes
        public ushort wBitsPerSample;   // bits per sample

        /// <summary>
        /// Initializes a format chunk with the following properties:
        /// Sample rate: 44100 Hz
        /// Channels: Stereo
        /// Bit depth: 16-bit
        /// </summary>
        public WaveFormatChunk()
        {
            sChunkID = "fmt ";
            dwChunkSize = 16;
            wFormatTag = 1;
            wChannels = 1;
            dwSamplesPerSec = 44100;
            wBitsPerSample = 16;
            wBlockAlign = (ushort)(wChannels * (wBitsPerSample / 8));
            dwAvgBytesPerSec = dwSamplesPerSec * wBlockAlign;
        }
    }

    public class WaveDataChunk
    {
        public string sChunkID;     // "data"
        public uint dwChunkSize;    // Length of header in bytes
        public short[] dashArray;   // 8-bit audio
        public short[] dotArray;    // 8-bit audio
        public short[] silenceArray;  // 8-bit audio


        /// <summary>
        /// Initializes a new data chunk with default values.
        /// </summary>
        public WaveDataChunk()
        {
            dotArray = new short[0];
            silenceArray = new short[0];
            dwChunkSize = 0;
            sChunkID = "data";
        }
    }


    public class MorseCodeGenerator
    {
        // Header, Format, Data chunks
        WaveHeader header;
        WaveFormatChunk format;
        WaveDataChunk data;

        public MorseCodeGenerator(string morseCode, string filePath)
        {
            // Init chunks
            header = new WaveHeader();
            format = new WaveFormatChunk();
            data = new WaveDataChunk();

            // Number of samples = sample rate * channels * bytes per sample
            uint numSamples = format.dwSamplesPerSec * format.wChannels;

            // Initialize the 16-bit array
            data.dotArray = new short[numSamples / 10];
            data.silenceArray = new short[numSamples / 10]; //automatically Initialized with zeroes

            //Wave Properties
            int amplitude = 32760;  // Max amplitude for 16-bit audio
            double freq = 750.0f;
            double periodOfWave = (Math.PI * 2 * freq) / (format.dwSamplesPerSec);

            for (uint i = 0; i < numSamples / 10; i++)
            {
                //fill dot array with sine waves
                data.dotArray[i] = Convert.ToInt16(amplitude * Math.Sin(periodOfWave * i));
            }

            // Morse Code:
            // 1. The duration of a Dash is three times the duration of a dot.
            // 2. Each dot or dash within a character is followed by period of signal absence,
            //    called a space, equal to the dot duration.
            // 3. Letters are separated by a space of duration equal to three dots.
            // 4. Words are separated by a space of duration equal to seven dots.


            // Calculate data chunk size in bytes
            for (int index = 0; index < morseCode.Length; index++)
            {
                switch (morseCode[index])
                {
                    case '-': // 4 frames
                        data.dwChunkSize += (uint)((data.dotArray.Length * (format.wBitsPerSample / 8)) * 4);
                        break;

                    case '•': // 2 frames
                        data.dwChunkSize += (uint)((data.dotArray.Length * (format.wBitsPerSample / 8)) * 2);
                        break;

                    case '.': // 3 frames
                        data.dwChunkSize += (uint)((data.dotArray.Length * (format.wBitsPerSample / 8)) * 3);

                        break;

                    case ' ': // 7 frames
                        data.dwChunkSize += (uint)((data.dotArray.Length * (format.wBitsPerSample / 8)) * 7);
                        break;

                    default:
                        continue;
                }
            }

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

            for (int index = 0; index < morseCode.Length; index++)
            {
                switch (morseCode[index])
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

                    case '.': // Letter space = 3 dots

                        for (int i = 0; i < 3; i++)
                        {
                            foreach (short dataPoint in data.silenceArray)
                                writer.Write(dataPoint);
                        }


                        break;

                    case ' ': // Word Space = 7 dots

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

    }
}
