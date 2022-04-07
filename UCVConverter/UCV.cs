using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCVConverter
{
    internal struct Info
    {
        public int ImageCount;
        public int ClassesCount;
        public int RectagleCount;
        public string[] ClassNames;
    }
    public class ProgressInfo
    {
        public int Current;
        public int Count;
    }
    internal class UCV
        
    {
        protected string rootPath;
        protected Folder datasetFolder;
        protected Folder rgbFolder;
        protected Folder segmentationFolder;
        protected Folder resultFolder;
        protected TextBoxBase log;
        protected CaptureObject? data;
        public static event Action OnLoadObjects;
        public static event Action<ProgressInfo> OnSavedElement;
        public static event Action OnExported;
        public UCV(string dir)
        {
            rootPath = dir;
            if(rootPath!="")Init();
        }

        private void Init()
        {
            var  list = Directory.GetDirectories(rootPath);
            foreach (string? dir in list)
            {
                var name = Path.GetFileName(dir);
                if (name.StartsWith("Dataset"))
                    datasetFolder = new Folder(dir);
                if (name.StartsWith("RGB"))
                    rgbFolder = new Folder(dir);
                if (name.StartsWith("SemanticSegmentation"))
                    segmentationFolder = new Folder(dir);
            }
        }
        public int CountRectangle()
        {
            int  count = 0;
            foreach (CaptureElement? element in this.GetElements())
            {
                foreach (var annot in this.GetElementAnnotations("bounding box", element))
                {
                    foreach (var val in this.GetElementAnnotationValues(annot))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        public virtual void Export() => OnExported?.Invoke();
        public Size GetImageSize(CaptureElement obj)
        {
            Bitmap bitmap = new Bitmap(rootPath+"/"+obj.filename);
            return bitmap.Size;
        }
        public async void GetCaptureObject(bool force = false)
        {
            if (data != null && !force)
            {
                OnLoadObjects?.Invoke();
                return;
            }
            var aa = GetCaptureObjects();
            var cnt = 0;
            await foreach (var cobj in aa)
            {
                cnt++;
                if (cnt!=1)
                {
                    data.captures.AddRange(cobj.captures);
                } else
                {
                    data = cobj;    
                }
            }
            OnLoadObjects?.Invoke();
        }

        private async IAsyncEnumerable<CaptureObject>  GetCaptureObjects()
        {
            foreach(var file in Directory.EnumerateFiles(GetDatasetFolder().Path, "captures*.json"))
            {
                var str = File.ReadAllText(file);
                yield return JsonConvert.DeserializeObject<CaptureObject>(str);
            }
        }
        public virtual Info GetInfo()
        {
            var info = new Info();
            info.ImageCount = GetElements().Count();
            info.RectagleCount = CountRectangle();
            var ad = GetAnnotationInfo();
            if (ad is not null)
            {
                var bb = ad.annotation_definitions.Find(a => a.id == "bounding box");
                if (bb is not null)
                {
                    info.ClassesCount = bb.spec.Count();
                    var list = new List<string>();
                    bb.spec.ForEach(a => list.Add(a.label_name));
                    info.ClassNames = list.ToArray();
                }                
            }
            return info;
        }
        private AnnotationDefinitionsObject? GetAnnotationInfo()
        {
            var str = File.ReadAllText(this.GetDatasetFolder().Path + "\\annotation_definitions.json");
            var data = JsonConvert.DeserializeObject<AnnotationDefinitionsObject>(str);
            return data;
        }
        public IEnumerable<CaptureElement> GetElements()
        {
            if (data == null) 
                yield break;
            foreach (CaptureElement? item in data.captures)
            {
                yield return item;
            }
        }
        public IEnumerable<CaptureElementAnnotation> GetElementAnnotations(string id, CaptureElement data)
        {
            
                foreach (CaptureElementAnnotation? annot in data.annotations)
                {
                    if (annot.id == id)
                    {
                        yield return annot;
                    }
                }
            
        }
        public IEnumerable<CaptureAnnotationValue> GetElementAnnotationValues(CaptureElementAnnotation data)
        {
            foreach (CaptureAnnotationValue? item in data.values)
            {
                yield return item;
            }
        }
        public RectangleF GetRectangleFromValue(CaptureAnnotationValue value)
        {
            return new RectangleF(value.x, value.y, value.width, value.height);
        }
        public RectangleF GetRectangleFromValue(CaptureAnnotationValue value, Size normalizeTo)
        {
            return new RectangleF(value.x/normalizeTo.Width, value.y/normalizeTo.Height, value.width/normalizeTo.Width, value.height/normalizeTo.Height);
        }
        public UCV SetResultFolder(string folder)
        {
            resultFolder = new Folder(folder);
            return this;
        }
        public Folder GetDatasetFolder()
        {
            return datasetFolder;
        }
        public Folder GetRGBFolder()
        {
            return rgbFolder;
        }
        public Folder GetSegmentationFolder()
        {
            return segmentationFolder;
        }
        protected bool createDir(string path)
        {
            try
            {
                FileSystem.MkDir(path);
                return true;
            }
            catch (IOException)
            {
                return false;
            }
        }
    }
}
