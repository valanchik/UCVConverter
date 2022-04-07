using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCVConverter
{
    internal struct Folder
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public Folder(string path)
        {
            Name = System.IO.Path.GetFileName(path);
            Path = path;
        }
    }
}
