using System.IO;

namespace MorseGenerator
{
    public static class WavHeader
    {
        private const string GroupId  = "RIFF";
        private const string RiffType = "WAVE";
        private const int FileLength  = 0;

        public static void Write(BinaryWriter writer)
        {
            writer.Write(GroupId.ToCharArray());
            writer.Write(FileLength);
            writer.Write(RiffType.ToCharArray());
        }

        public static void WriteFileLength(BinaryWriter writer)
        {
            var fileLength = (uint)writer.BaseStream.Length;
            writer.Seek(4, SeekOrigin.Begin);
            writer.Write(fileLength - 8);
        }
    }
}