using System.Diagnostics;

namespace UCVConverter
{
    public partial class Form1 : Form
    {
        private YOLOUCV ucv = new("");
        
        public Form1()
        {
            InitializeComponent();
        }
        private void openFolder_Click(object sender, EventArgs e)
        {
            var result = folderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                currentFolder.Text = folderDialog.SelectedPath;
                ucv = new YOLOUCV(folderDialog.SelectedPath);
                DatasetFolderName.Text = ucv.GetDatasetFolder().Name;
                openDatasetBtn.Click -= openDatasetBtn_Click;
                openDatasetBtn.Click += openDatasetBtn_Click;
                
                RGBFolderName.Text = ucv.GetRGBFolder().Name;
                openRGBBtn.Click -= openRGBBtn_Click;
                openRGBBtn.Click += openRGBBtn_Click;

                SegmentationFolderName.Text = ucv.GetSegmentationFolder().Name;
                openSegmentationBtn.Click -= openSegmentationBtn_Click;
                openSegmentationBtn.Click += openSegmentationBtn_Click;
                

                YOLOUCV.OnLoadObjects += ()=>
                {
                    var info = ucv.GetInfo();
                    imageCount.Text = info.ImageCount.ToString();
                    rectCount.Text = info.RectagleCount.ToString();
                    classesCount.Text = info.ClassesCount.ToString();
                    convertBtn.Enabled = true;
                    Size size = ucv.GetImageSize();
                    imageSize.Text = $"{size.Width}x{size.Height}";
                    ucv.SetYOLODimension(new Size((int)yoloWidth.Value, (int)yoloHeight.Value));
                };
                ucv.GetCaptureObject();
            }
        }
        private void OnLoadObjectsOnce()
        {
            
        }
        private void openSegmentationBtn_Click(object? sender, EventArgs e) => openFolderInExplorer(ucv.GetSegmentationFolder().Path);

        private void openRGBBtn_Click(object? sender, EventArgs e) => openFolderInExplorer(ucv.GetRGBFolder().Path);

        private void openDatasetBtn_Click(object? sender, EventArgs e) => openFolderInExplorer(ucv.GetDatasetFolder().Path);

        private void openFolderInExplorer(string folder) => Process.Start("explorer.exe", folder);
        private void convertBtn_Click(object sender, EventArgs e)
        {
            var result = folderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (ucv is null) return;
                Button? btn = sender as Button;
                btn.Enabled = false;
                openFolder.Enabled = false;
                ucv.SetResultFolder(folderDialog.SelectedPath);
                var cb = () =>
                 {
                     btn.Invoke(new Action(() => { 
                         btn.Enabled = true; 
                         openFolder.Enabled = true;
                         progressBar.Value = 0;
                     }));
                 };
                YOLOUCV.OnExported-=cb;
                YOLOUCV.OnExported+=cb;
                YOLOUCV.OnSavedElement -= Ucv_OnSavedElement;
                YOLOUCV.OnSavedElement += Ucv_OnSavedElement;
                var thread = new Thread(yootread);
                thread.Start(ucv);
            }
        }

        private void Ucv_OnSavedElement(ProgressInfo info)
        {
            progressBar.Invoke(new Action(() => {
                progressBar.Maximum = info.Count;
                progressBar.Value = info.Current;
            }));
        }

        private void yootread(object? yucv)
        {
            var ucv = yucv as YOLOUCV;
            ucv.Export();
        }

        private void yoloWidth_Scroll(object sender, ScrollEventArgs e)
        {
            Debug.WriteLine("Scroll");
        }

        private void yoloWidth_ValueChanged(object sender, EventArgs e)
        {
            var val = sender as NumericUpDown;
            Debug.WriteLine(val.Value);    
        }
    }
}