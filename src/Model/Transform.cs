using QuantumConcepts.Formats.StereoLithography;
using System.IO;

namespace omd2stl.Model
{
    public class Transform
    {
        public Vertex Rotation { get; set; }
        public Vertex Translation { get; set; }

        public Transform(BinaryReader reader)
        {
            Rotation = Vertex.Read(reader);
            Translation = Vertex.Read(reader);
        }

        public override string ToString()
        {
            return "Rotation: " + Rotation.ToString() + "\tTranslation: " + Translation.ToString();
        }
    }
}
