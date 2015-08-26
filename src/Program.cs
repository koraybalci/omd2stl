using omd2stl.Model;
using QuantumConcepts.Formats.StereoLithography;
using System;
using System.IO;
using System.Text;

namespace omd2stl
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0 || string.IsNullOrEmpty(args[0]))
            {
                Console.WriteLine("need input filename path as a parameter");
                return;
            }
            try
            {
                using (var reader = new BinaryReader(File.Open(args[0], FileMode.Open), Encoding.GetEncoding(1252)))
                {
                    // read header
                    var header = new OmdHeader(reader);
                    Console.WriteLine(header.ToString());

                    var nDrawables = reader.ReadInt16();
                    Console.WriteLine("drawable count: " + nDrawables);
                    if (nDrawables <= 0) return;

                    // create destination folder
                    var folderName = Path.GetFileNameWithoutExtension(args[0]);
                    var destPath = Path.GetDirectoryName(Path.GetFullPath(args[0])) + "\\" + folderName;
                    Directory.CreateDirectory(destPath);

                    // dump the header to a text file
                    using (var writer = new StreamWriter(destPath + "\\" + folderName + ".txt"))
                    {
                        writer.Write(header.ToString());
                    }

                    // read and dump each drawable as a separate stl
                    for (int i = 0; i < nDrawables; i++)
                    {
                        var drawable = new Drawable(reader);
                        Console.WriteLine(drawable.ToString());

                        var stl = CreateSTLDocument(drawable);
                        using (var writer = new StreamWriter(destPath + "\\" + stl.Name + ".stl"))
                        {
                            stl.Write(writer);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static STLDocument CreateSTLDocument(Drawable drawable)
        {
            var stl = new STLDocument();
            stl.Name = drawable.Name;
            for (int j = 0; j < drawable.Mesh.Indices.Length; j += 3)
            {
                var facet = CreateFacet(drawable.Mesh.Geometry.Vertices[j],
                    drawable.Mesh.Geometry.Vertices[j + 1],
                    drawable.Mesh.Geometry.Vertices[j + 2]);
                stl.Facets.Add(facet);
            }
            return stl;
        }
        private static Facet CreateFacet(Vertex v1, Vertex v2, Vertex v3)
        {
            var facet = new Facet();
            facet.Vertices.Add(v1);
            facet.Vertices.Add(v2);
            facet.Vertices.Add(v3);
            facet.Normal = CalculateNormal(v1, v2, v3);
            return facet;
        }

        private static Normal CalculateNormal(Vertex firstPoint, Vertex secondPoint, Vertex thirdPoint)
        {
            var u = new Vertex(firstPoint.X - secondPoint.X,
                firstPoint.Y - secondPoint.Y,
                firstPoint.Z - secondPoint.Z);

            var v = new Vertex(secondPoint.X - thirdPoint.X,
                secondPoint.Y - thirdPoint.Y,
                secondPoint.Z - thirdPoint.Z);

            return Normal.FromVertex(new Vertex(u.Y * v.Z - u.Z * v.Y, u.Z * v.X - u.X * v.Z, u.X * v.Y - u.Y * v.X));
        }
    }
}
