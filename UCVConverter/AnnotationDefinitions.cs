using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCVConverter
{
    internal class AnnotationSpec
    {
        public string label_id { get; set; }
        public string label_name { get; set; }

    }
    internal class AnnotationDefinitions
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string format { get; set; }
        public List<AnnotationSpec> spec { get; set; }

    }
    internal class AnnotationDefinitionsObject
    {
        public string version { get; set; }
        public List<AnnotationDefinitions> annotation_definitions { get; set; }
    }
}
