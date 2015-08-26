using System.IO;

namespace omd2stl.Model
{
    public class OmdHeader
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
        public int ScanId { get; set; }
        public int FileVersion { get; set; }
        public string Clinic { get; set; }

        public OmdHeader(BinaryReader reader)
        {
            FileVersion = reader.ReadInt32();
            ScanId = reader.ReadInt32();
            Clinic = reader.ExtractString();
            Name = reader.ExtractString();
            Surname = reader.ExtractString();
            Birthday = reader.ExtractString();
        }

        public override string ToString()
        {
            return "Name: " + Name + "\r\nSurname: " + Surname + "\r\nBirthday: " + Birthday + "\r\nScan Id: " + ScanId + "\r\nClinic: " + Clinic + "\r\nFile Version: " + FileVersion;
        }
    }
}
