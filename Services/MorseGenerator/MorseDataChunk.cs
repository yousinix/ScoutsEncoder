using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Services.MorseGenerator
{
    public static class MorseDataChunk
    {
        private const char Dot        = '•';
        private const char Dash       = '-';
        private const char Space      = ' ';
        private const string SChunkId = "data";

        private static List<short> _dotData;
        private static string _parsedText;
        private static int _dwChunkSize;

        public static void FillData(string encodedText, string charsDelimiter, string wordsDelimiter, int speed)
        {
            const int amplitude = 32760;
            const int frequency = 750;
            const double period = 2 * Math.PI * frequency / WavFormatChunk.SamplesPerSec;

            var size  = (3 - speed) * WavFormatChunk.SamplesPerSec / 10;
            var frame = size * (WavFormatChunk.BitsPerSample / 8);

            _dotData     = GenerateSineWave(size, amplitude, period);
            _parsedText  = Parse(encodedText, charsDelimiter, wordsDelimiter);
            _dwChunkSize = frame * _parsedText.Length;
        }

        public static void Write(BinaryWriter writer)
        {
            writer.Write(SChunkId.ToCharArray());
            writer.Write(_dwChunkSize);

            foreach (var c in _parsedText)
            {
                // Anything that's not Dot or Space is skipped
                if (c == Dot) _dotData.ForEach(writer.Write);
                else if (c == Space) _dotData.ForEach(_ => writer.Write((short) 0));
            }
        }

        private static List<short> GenerateSineWave(int size, int amplitude, double period)
        {
            return Enumerable.Range(0, size)
                .Select(i => (short)(Math.Sin(i * period) * amplitude))
                .ToList();
        }

        private static string Parse(string encodedText, string charsDelimiter, string wordsDelimiter)
        {
            // Map encoded characters to their audio replacements:
            // 1. The duration of a Dash is three times the duration of a dot.
            // 2. Each dot or dash within a character is followed by period of signal absence,
            //    called a space, equal to the dot duration.
            // 3. Letters are separated by a space of duration equal to three dots.
            // 4. Words are separated by a space of duration equal to seven dots.

            var dot       = new string(Dot, 1) + Space;
            var dash      = new string(Dot, 3) + Space;
            var charSpace = new string(Space, 3);
            var wordSpace = new string(Space, 7);
            var newLine   = new string(Space, 10);

            encodedText = encodedText
                .Replace("\r\n", newLine)
                .Replace(charsDelimiter, charSpace)
                .Replace(wordsDelimiter, wordSpace)
                .Replace(Dot.ToString(), dot)
                .Replace(Dash.ToString(), dash);

            // Surround string with whitespaces to leave about 1 second
            // of silence at the beginning and the end of the audio.
            return wordSpace + encodedText.Trim() + wordSpace;
        }
    }
}