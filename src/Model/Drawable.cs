using System.IO;

namespace omd2stl.Model
{
    public class Drawable
    {
        public string Name { get; set; }
        public Transform Transform { get; set; }
        public IndexedFaceSet Mesh { get; set; }  

        public Drawable(BinaryReader reader)
        {
            Name = reader.ExtractString();
            Transform = new Transform(reader);
            Mesh = new IndexedFaceSet(reader);
        }

        public override string ToString()
        {
            return "Name: " + Name + "\nTransform: " + Transform.ToString() + "\nMesh: " + Mesh.ToString();
        }
    }
}
