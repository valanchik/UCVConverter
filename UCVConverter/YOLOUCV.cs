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
    public enum YOLOType
    {
        YOLOV4,
        YOLOV4_TINY
    }
    public class YOLOConfig
    {
        public YOLOType Type;
        public Size Dimension { get; set; }
        public bool Randomize { get; set; }
        public int Batch { get; set; }
        public int Subdivisions { get; set; }
        public bool ExportConfigOnly { get; set; }
        public string configFilePath;
        public string resultConfigFilePath;
        public string convWeightFileName;

    }
    internal class YOLOUCV : UCV
    {
        
        
        private string filesFolder;
        public static event Action<ProgressInfo> OnSavedElement;
        private YOLOConfig config = new();
        
        public YOLOUCV(string dir) : base(dir)
        {
            filesFolder = Directory.GetCurrentDirectory()+"/files";
        }

        public void Configure(YOLOConfig config)
        {
            this.config = config;
            if (config.Type == YOLOType.YOLOV4)
            {
                this.config.configFilePath = filesFolder + Path.DirectorySeparatorChar + "yolov4.cfg";
                this.config.convWeightFileName = "yolov4.conv.137";
            } else
            {
                this.config.configFilePath = filesFolder + Path.DirectorySeparatorChar + "yolov4-tiny.cfg";
                this.config.convWeightFileName = "yolov4-tiny.conv.29";
            }
            this.config.resultConfigFilePath = resultFolder.Path + Path.DirectorySeparatorChar + Path.GetFileName(config.configFilePath);
        }
        public override void Export()
        {
            if (config.ExportConfigOnly)
            {
                CreateYOLOConfig();
            } else
            {
                var size = GetImageSize();
                var dirDataName = "data";
                var yolodata = resultFolder.Path + "/" + dirDataName;
                var dirBackupName = "backup";
                var yolobackup = resultFolder.Path + "/" + dirBackupName;
                var trainFolderName = "traindata";
                var traindata = yolodata + "/" + trainFolderName;

                createDir(yolodata);
                createDir(yolobackup);
                createDir(traindata);
                CreateObjectData(yolodata, dirDataName, dirBackupName);
                CreateObjectName(yolodata);
                CreateYOLOConfig();
                CreateBatFiles();
                using (var traintext = File.CreateText(yolodata + "/train.txt"))
                using(var validtext = File.CreateText(yolodata + "/valid.txt")){
                    var count = GetElements().Count();
                    var current = 0;
                    foreach (CaptureElement? element in GetElements())
                    {
                        current++;
                        string filepath = rootPath + "/" + element.filename;
                        string filename = Path.GetFileNameWithoutExtension(filepath);
                        if (new Random().Next(1, 100) >= 30)
                        {
                            traintext.WriteLine($"{dirDataName}/{trainFolderName}/{filename}.jpg");
                        }
                        else
                        {
                            validtext.WriteLine($"{dirDataName}/{trainFolderName}/{filename}.jpg");
                        }
                        SavePngToJPEG(filepath, traindata + "/" + filename + ".jpg");
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
                            OnSavedElement?.Invoke(new() { Current = current, Count = count });
                        }
                    }
                    traintext.Close();
                    validtext.Close();
                }
                CopyDarknet();
            }
            
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
            arr.Add(config.convWeightFileName);
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
           var yoloConfig = Configuration.LoadFromFile(config.configFilePath);
            var info = GetInfo();
            Section lastSection = new Section("temp");
            // Set net
            Section netSection = yoloConfig.First(s => s.Name == "net");
            if (netSection!=null)
            {
                netSection.First(s => s.Name == "batch")?.SetValue(config.Batch);
                netSection.First(s => s.Name == "subdivisions")?.SetValue(config.Subdivisions);
                netSection.First(s => s.Name == "width")?.SetValue(config.Dimension.Width);
                netSection.First(s => s.Name == "height")?.SetValue(config.Dimension.Height);
            }
            // Setting count of classes  and of filters
            foreach (Section? section in yoloConfig)
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
                    } else if (setting.Name == "random")
                    {
                        setting.SetValue(config.Randomize?1:0);
                    }
                }
            }
            var file = yoloConfig.StringRepresentation;
            file = file.Replace("\"", "");
            File.WriteAllText(config.resultConfigFilePath, file);
        }
        private void CreateBatFiles()
        {
            var testFileName = "test.cmd";
            var firstFileName = "train_first.cmd";
            var lastFileName = "train_last.cmd";
            var lastBackupWeight = config.Type== YOLOType.YOLOV4? "yolov4_last.weights" : "yolov4-tiny_last.weights";
            var convFileName = config.Type == YOLOType.YOLOV4 ? "yolov4.conv.137" : "yolov4-tiny.conv.29";
            var conffilename = Path.GetFileName(config.resultConfigFilePath);
            using (var testfile = File.CreateText(resultFolder.Path + Path.DirectorySeparatorChar + testFileName))
            using (var trainFirstFile = File.CreateText(resultFolder.Path + Path.DirectorySeparatorChar + firstFileName))
            using (var trainLastFile = File.CreateText(resultFolder.Path + Path.DirectorySeparatorChar + lastFileName))
            {
                testfile.WriteLine($"darknet.exe detector map data\\obj.data {conffilename} backup\\{lastBackupWeight}");
                testfile.WriteLine("pause");
                testfile.Close();

                trainFirstFile.WriteLine($"darknet.exe detector train data/obj.data {conffilename} {config.convWeightFileName} -map");
                trainFirstFile.WriteLine("pause");
                trainFirstFile.Close();

                trainLastFile.WriteLine($"darknet.exe detector train data/obj.data {conffilename} backup\\{lastBackupWeight} -map");
                trainLastFile.WriteLine("pause");
                trainLastFile.Close();
            }
        }
    }
}
