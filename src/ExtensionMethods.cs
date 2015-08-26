using QuantumConcepts.Formats.StereoLithography;
using System;
using System.IO;
using System.Text;

namespace omd2stl
{
    public static class ExtensionMethods
    {
        public static string ExtractString(this BinaryReader reader, int codepage = 1254)
        {
            var decoder = Encoding.GetEncoding(codepage).GetDecoder();
            var length = Convert.ToInt32(reader.ReadUInt32());
            var bytes = reader.ReadBytes(length);
            char[] dest = new char[length];
            decoder.GetChars(bytes, 0, length, dest, 0, true);
            var value = new string(dest);
            return value;
        }
    }
}
