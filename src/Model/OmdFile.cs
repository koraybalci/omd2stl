using System.Collections.Generic;

namespace omd2stl.Model
{
    public class OmdFile
    {
        public OmdHeader Header { get; set; }
        public List<Drawable> Drawables { get; set; }
    }
}
