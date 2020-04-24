using System.IO;

namespace MorseGenerator
{
    public static class MorseAudioGenerator
    {
        public static void Generate(string filePath, string encodedText, string charsDelimiter, string wordsDelimiter, int speed)
        {
            var stream = new FileStream(filePath, FileMode.Create);
            var writer = new BinaryWriter(stream);

            WavHeader.Write(writer);
            WavFormatChunk.Write(writer);
            MorseDataChunk.FillData(encodedText, charsDelimiter, wordsDelimiter, speed);
            MorseDataChunk.Write(writer);
            WavHeader.WriteFileLength(writer);

            writer.Close();
            stream.Close();
        }
    }
}