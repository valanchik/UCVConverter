using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpConfig;

namespace UCVConverter
{

    internal class YOLOUCV : UCV
    {
        
        private string filesFolder;
        public static event Action<ProgressInfo> OnSavedElement;
        public YOLOUCV(string dir) : base(dir)
        {
            filesFolder = Directory.GetCurrentDirectory()+"/files";
        }
        public override void Export()
        {
            var size = GetImageSize(GetElements().First());
            var dirDataName = "data";
            var yolodata = resultFolder.Path + "/"+dirDataName;
            var dirBackupName = "backup";
            var yolobackup = resultFolder.Path + "/"+ dirBackupName;
            var trainFolderName = "traindata";
            var traindata = yolodata + "/"+trainFolderName;
            createDir(yolodata);
            createDir(yolobackup);  
            createDir(traindata);
            CreateObjectData(yolodata, dirDataName, dirBackupName);
            CreateObjectName(yolodata);
            CreateYOLOConfig();
            var traintext = File.CreateText(yolodata+"/train.txt");
            var validtext = File.CreateText(yolodata+"/valid.txt");
            var count = GetElements().Count();
            var current = 0;
            foreach (CaptureElement? element in GetElements())
            {
                current++;
                string filepath = rootPath+"/"+element.filename;
                string filename = Path.GetFileNameWithoutExtension(filepath);
                if (new Random().Next(1,100)>=30)
                {
                    traintext.WriteLine($"{dirDataName}/{trainFolderName}/{filename}.jpg");
                } else
                {
                    validtext.WriteLine($"{dirDataName}/{trainFolderName}/{filename}.jpg");
                }
                SavePngToJPEG(filepath, traindata+"/"+filename+".jpg");
                using (var f = File.CreateText(traindata + "/" + filename + ".txt"))
                {
                    foreach (var annot in GetElementAnnotations("bounding box", element))
                    {
                        foreach (var val in GetElementAnnotationValues(annot))
                        {
                            RectangleF rect = GetRectangleFromValue(val, size);
                            rect.X += rect.Width / 2;
                            rect.Y += rect.Height / 2;
                            f.WriteLine($"{val.label_id} {rect.X.ToString().Replace(",", ".")} {rect.Y.ToString().Replace(",", ".")} {rect.Width.ToString().Replace(",", ".")} {rect.Height.ToString().Replace(",", ".")}");
                        }
                    }
                    f.Close();
                    OnSavedElement?.Invoke(new() { Current = current, Count = count});
                }
            }
            traintext.Close();
            validtext.Close();
            CopyDarknet();
            base.Export();
        }
        private void CreateObjectData(string path, string yolodata, string yolobackupname)
        {
            var info = GetInfo();
            var f = File.CreateText(path + "/obj.data");
            f.WriteLine($"classes = {info.ClassesCount}");
            f.WriteLine($"train = {yolodata}/train.txt");
            f.WriteLine($"valid = {yolodata}/valid.txt");
            f.WriteLine($"backup = {yolobackupname}/");
            f.Close();
        }
        private void CreateObjectName(string path)
        {
            var info = GetInfo();
            var f = File.CreateText(path + "/names.list");
            foreach (var name in info.ClassNames)
            {
                f.WriteLine(name);
            }
            f.Close();
        }
        private void SavePngToJPEG(string from, string to)
        {
            using (Image image1 = Image.FromFile(from))
            {
                image1.Save(to, ImageFormat.Jpeg);
            };
            
        }

        private void CopyDarknet()
        {
            var arr = new List<string>();
            arr.Add("darknet.exe");
            arr.Add("opencv_world430.dll");
            arr.Add("opencv_world3410.dll");
            arr.Add("pthreadVC2.dll");
            arr.Add("yolov4-tiny.conv.29");
            arr.Add("test-tiny.cmd");
            arr.Add("train-tiny_cudnn.cmd");
            arr.Add("train-tiny_cudnn_last.cmd");
            foreach(var item in arr)
            {
                File.Copy(
                    filesFolder + Path.DirectorySeparatorChar + item, 
                    resultFolder.Path + Path.DirectorySeparatorChar + item, 
                    true
                );
            }
        }
        private void CreateYOLOConfig()
        {
           var config = Configuration.LoadFromFile(filesFolder + Path.DirectorySeparatorChar+ "yolov4-tiny.cfg");
            var info = GetInfo();
            Section lastSection = new Section("temp");
            foreach (Section? section in config)
            {

                if (section.Name != "yolo")
                {
                    lastSection = section;
                    continue;
                } else
                {
                    foreach (Setting? setting in lastSection)
                    {
                        if (setting.Name == "filters")
                        {
                            setting.SetValue((info.ClassesCount+5)*3);
                        }
                    }
                }
                foreach (Setting? setting in section)
                {
                    if (setting.Name == "classes")
                    {
                        setting.SetValue(info.ClassesCount);
                    }
                }
            }
            var configFile = resultFolder.Path + Path.DirectorySeparatorChar + "yolov4-tiny.cfg";
            var file = config.StringRepresentation;
            file = file.Replace("\"", "");
            File.WriteAllText(configFile, file);
        }
    }
}
