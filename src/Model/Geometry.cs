using QuantumConcepts.Formats.StereoLithography;
using System.IO;

namespace omd2stl.Model
{
    public class Geometry
    {
        public Vertex[] Vertices { get; set; }
        public Vertex[] Normals { get; set; }
        public Vector2[] TexCoords { get; set; }

        public Geometry(BinaryReader reader)
        {
            var sz = reader.ReadInt32();
            Vertices = new Vertex[sz];
            for (int i = 0; i < sz; i++)
            {
                Vertices[i] = Vertex.Read(reader);
            }

            sz = reader.ReadInt32();
            Normals = new Vertex[sz];
            for (int i = 0; i < sz; i++)
            {
                Normals[i] = Vertex.Read(reader);
            }

            sz = reader.ReadInt32();
            TexCoords = new Vector2[sz];
            for (int i = 0; i < sz; i++)
            {
                TexCoords[i] = new Vector2(reader);
            }
        }

        public override string ToString()
        {
            return Vertices.Length + " vertices\n" +
                Normals.Length + " normals\n" +
                TexCoords.Length + " texCoords\n";
        }
    }
}