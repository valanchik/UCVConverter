using System.Diagnostics;
using ThreadState = System.Threading.ThreadState;

namespace UCVConverter
{
    public partial class Form1 : Form
    {
        private YOLOUCV ucv = new("");
        Thread thread;
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
                ucv.Configure(
                        new Size((int)yoloWidth.Value, (int)yoloHeight.Value),
                        randomDimension.Checked,
                        (int)yoloBatch.Value,
                        (int)yoloSubdivisions.Value
                    );
                var cb = () =>
                 {
                     btn.Invoke(new Action(() =>
                     {
                         btn.Enabled = true;
                         openFolder.Enabled = true;
                         progressBar.Value = 0;
                     }));
                     if (thread != null && thread.ThreadState != ThreadState.Stopped){

                     }

                 };
                YOLOUCV.OnExported-=cb;
                YOLOUCV.OnExported+=cb;
                YOLOUCV.OnSavedElement -= Ucv_OnSavedElement;
                YOLOUCV.OnSavedElement += Ucv_OnSavedElement;
                thread = new Thread(yolotread);
                thread.Priority = ThreadPriority.Highest;
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

        private void yolotread(object? yucv)
        {
            var ucv = yucv as YOLOUCV;
            ucv.Export();
        }

    }
}