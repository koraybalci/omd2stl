using System.IO;

namespace omd2stl.Model
{
    public class IndexedFaceSet
    {
        public Geometry Geometry { get; set; }
        public uint[] Indices { get; set; }

        public IndexedFaceSet(BinaryReader reader)
        {
            Geometry = new Geometry(reader);

            var sz = reader.ReadUInt32();
            Indices = new uint[sz];
            for (int i = 0; i < sz; i++)
            {
                Indices[i] = reader.ReadUInt32();
            }
        }

        public override string ToString()
        {
            return Indices.Length + " indices\n" + Geometry.ToString();
        }
    }
}