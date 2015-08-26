using System.IO;

namespace omd2stl.Model
{
    public class Vector2
    {
        public float x { get; set; }
        public float y { get; set; }
        
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2(BinaryReader reader)
        {
            x = reader.ReadSingle();
            y = reader.ReadSingle();
        }

        public override string ToString()
        {
            return "x: " + x.ToString() + " y: " + y.ToString();
        }
    }
}