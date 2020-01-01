using System.IO;

namespace ScoutsEncoder.Morse
{
    public static class WavFormatChunk
    {
        private const string ChunkId     = "fmt ";
        private const int ChunkSize      = 16;
        private const int AvgBytesPerSec = SamplesPerSec * BlockAlign;
        private const short FormatTag    = 1;
        private const short Channels     = 1;
        private const short BlockAlign   = Channels * (BitsPerSample / 8);
        public const int SamplesPerSec   = 44100;
        public const short BitsPerSample = 16;

        public static void Write(BinaryWriter writer)
        {
            writer.Write(ChunkId.ToCharArray());
            writer.Write(ChunkSize);
            writer.Write(FormatTag);
            writer.Write(Channels);
            writer.Write(SamplesPerSec);
            writer.Write(AvgBytesPerSec);
            writer.Write(BlockAlign);
            writer.Write(BitsPerSample);
        }
    }
}