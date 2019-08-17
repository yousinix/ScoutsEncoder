using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ScoutsEncoder
{
    public class MorseAudioGenerator
    {
        private static class Header
        {
            public const string GroupId  = "RIFF";
            public const string RiffType = "WAVE";
            public const uint FileLength = 0;
        }

        private static class FormatChunk
        {
            public const string ChunkId       = "fmt ";
            public const uint ChunkSize       = 16;
            public const uint AvgBytesPerSec  = SamplesPerSec * BlockAlign;
            public const uint SamplesPerSec   = 44100;
            public const ushort FormatTag     = 1;
            public const ushort Channels      = 1;
            public const ushort BlockAlign    = Channels * (BitsPerSample / 8);
            public const ushort BitsPerSample = 16;
        }

        private static class DataChunk
        {
            public const string SChunkId = "data";
            public static uint dwChunkSize;
            public static short[] dot;
            public static short[] period;

            public static short[] GenerateSineWave(long size)
            {
                const int amplitude       = 32760;
                const float frequency     = 750.0f;
                const double periodOfWave = Math.PI * 2 * frequency / FormatChunk.SamplesPerSec;

                var temp = new short[size];
                for (uint i = 0; i < size; i++)
                    temp[i] = Convert.ToInt16(amplitude * Math.Sin(periodOfWave * i));
                return temp;
            }
        }

        private readonly string _morseText;

        public MorseAudioGenerator(string encodedText, string charsDelimiter, string wordsDelimiter, int speed)
        {
            _morseText = ConvertToMorseGrammar(encodedText, charsDelimiter, wordsDelimiter);
            var size   = FormatChunk.SamplesPerSec / 10 * (3 - speed);
            var frame  = size * (FormatChunk.BitsPerSample / 8);

            DataChunk.dot         = DataChunk.GenerateSineWave(size);
            DataChunk.period      = new short[size];
            DataChunk.dwChunkSize = (uint)(frame * _morseText.Length);
        }

        public void Save(string filePath)
        {
            var fileStream   = new FileStream(filePath, FileMode.Create);
            var binaryWriter = new BinaryWriter(fileStream);

            binaryWriter.Write(Header.GroupId.ToCharArray());
            binaryWriter.Write(Header.FileLength);
            binaryWriter.Write(Header.RiffType.ToCharArray());

            binaryWriter.Write(FormatChunk.ChunkId.ToCharArray());
            binaryWriter.Write(FormatChunk.ChunkSize);
            binaryWriter.Write(FormatChunk.FormatTag);
            binaryWriter.Write(FormatChunk.Channels);
            binaryWriter.Write(FormatChunk.SamplesPerSec);
            binaryWriter.Write(FormatChunk.AvgBytesPerSec);
            binaryWriter.Write(FormatChunk.BlockAlign);
            binaryWriter.Write(FormatChunk.BitsPerSample);

            binaryWriter.Write(DataChunk.SChunkId.ToCharArray());
            binaryWriter.Write(DataChunk.dwChunkSize);

            foreach (var c in _morseText)
            {
                if (c == '.')
                    WriteArray(binaryWriter, DataChunk.dot);
                else if (c == ' ') 
                    WriteArray(binaryWriter, DataChunk.period);
            }

            var fileSize = (uint)binaryWriter.BaseStream.Length;
            binaryWriter.Seek(4, SeekOrigin.Begin);
            binaryWriter.Write(fileSize - 8);

            binaryWriter.Close();
            fileStream.Close();
        }

        private static void WriteArray(BinaryWriter writer, IEnumerable<short> array)
        {
            foreach (var v in array)
                writer.Write(v);
        }

        private static string ConvertToMorseGrammar(string encodedText, string charsDelimiter, string wordsDelimiter)
        {
            // Map encoded characters to their audio replacements:
            // 1. The duration of a Dash is three times the duration of a dot.
            // 2. Each dot or dash within a character is followed by period of signal absence,
            //    called a space, equal to the dot duration.
            // 3. Letters are separated by a space of duration equal to three dots.
            // 4. Words are separated by a space of duration equal to seven dots.

            const string dot       = ". ";                // Dot  = 1 dot  + 1 period
            const string dash      = "... ";              // Dash = 3 dots + 1 period
            const string delimiter = "   ";               // Letter space  = 3 periods
            const string space     = "       ";           // Word space    = 7 periods
            const string paragraph = delimiter + space;   // New Line      = 10 periods

            encodedText = encodedText
                .Replace(charsDelimiter, delimiter)
                .Replace(wordsDelimiter, space)
                .Replace("•", dot)
                .Replace("-", dash);

            // Replace new lines with 10 periods
            encodedText = Regex.Replace(encodedText, @"[\r\n]{1,}", paragraph);

            // Remove anything that doesn't belong to the morse grammar
            encodedText = Regex.Replace(encodedText, @"[^\.\ ]", string.Empty);

            // Surround string with whitespaces to leave about 1 second
            // of silence at the beginning and the end of the audio.
            return space + encodedText.Trim() + space;
        }
    }
}