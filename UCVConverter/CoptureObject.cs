using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCVConverter
{
    internal class CaptureAnnotationValue
    {
        public int label_id { get; set; }
        public string label_name { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float width { get; set; }
        public float height { get; set; }
    }
    internal class CaptureElementAnnotation
    {
        public string id { get; set; }
        public List<CaptureAnnotationValue> values { get; set; }
    }
    internal class CaptureElement { 
        public string filename { get; set; }
        public List<CaptureElementAnnotation> annotations { get; set; }
    }

    internal class CaptureObject
    {
        public List<CaptureElement> captures { get; set; }
    }
}
