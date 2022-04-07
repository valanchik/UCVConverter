namespace UCVConverter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupFolders = new System.Windows.Forms.GroupBox();
            this.SegmentationFolderName = new System.Windows.Forms.Label();
            this.RGBFolderName = new System.Windows.Forms.Label();
            this.DatasetFolderName = new System.Windows.Forms.Label();
            this.openSegmentationBtn = new System.Windows.Forms.Button();
            this.openRGBBtn = new System.Windows.Forms.Button();
            this.openDatasetBtn = new System.Windows.Forms.Button();
            this.openFolder = new System.Windows.Forms.Button();
            this.currentFolder = new System.Windows.Forms.Label();
            this.convertBtn = new System.Windows.Forms.Button();
            this.groupInfo = new System.Windows.Forms.GroupBox();
            this.classesCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rectCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.imageCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupExport = new System.Windows.Forms.GroupBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.groupFolders.SuspendLayout();
            this.groupInfo.SuspendLayout();
            this.groupExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupFolders
            // 
            this.groupFolders.Controls.Add(this.SegmentationFolderName);
            this.groupFolders.Controls.Add(this.RGBFolderName);
            this.groupFolders.Controls.Add(this.DatasetFolderName);
            this.groupFolders.Controls.Add(this.openSegmentationBtn);
            this.groupFolders.Controls.Add(this.openRGBBtn);
            this.groupFolders.Controls.Add(this.openDatasetBtn);
            this.groupFolders.Location = new System.Drawing.Point(12, 35);
            this.groupFolders.Name = "groupFolders";
            this.groupFolders.Size = new System.Drawing.Size(264, 145);
            this.groupFolders.TabIndex = 10;
            this.groupFolders.TabStop = false;
            this.groupFolders.Text = "Folders";
            // 
            // SegmentationFolderName
            // 
            this.SegmentationFolderName.AutoEllipsis = true;
            this.SegmentationFolderName.Location = new System.Drawing.Point(90, 89);
            this.SegmentationFolderName.Name = "SegmentationFolderName";
            this.SegmentationFolderName.Size = new System.Drawing.Size(168, 15);
            this.SegmentationFolderName.TabIndex = 11;
            this.SegmentationFolderName.Text = "-";
            // 
            // RGBFolderName
            // 
            this.RGBFolderName.AutoEllipsis = true;
            this.RGBFolderName.Location = new System.Drawing.Point(90, 60);
            this.RGBFolderName.Name = "RGBFolderName";
            this.RGBFolderName.Size = new System.Drawing.Size(168, 15);
            this.RGBFolderName.TabIndex = 10;
            this.RGBFolderName.Text = "-";
            // 
            // DatasetFolderName
            // 
            this.DatasetFolderName.AutoEllipsis = true;
            this.DatasetFolderName.Location = new System.Drawing.Point(90, 26);
            this.DatasetFolderName.Name = "DatasetFolderName";
            this.DatasetFolderName.Size = new System.Drawing.Size(168, 15);
            this.DatasetFolderName.TabIndex = 9;
            this.DatasetFolderName.Text = "-";
            // 
            // openSegmentationBtn
            // 
            this.openSegmentationBtn.Location = new System.Drawing.Point(6, 85);
            this.openSegmentationBtn.Name = "openSegmentationBtn";
            this.openSegmentationBtn.Size = new System.Drawing.Size(73, 23);
            this.openSegmentationBtn.TabIndex = 8;
            this.openSegmentationBtn.Text = "Segmentation";
            this.openSegmentationBtn.UseVisualStyleBackColor = true;
            // 
            // openRGBBtn
            // 
            this.openRGBBtn.Location = new System.Drawing.Point(6, 56);
            this.openRGBBtn.Name = "openRGBBtn";
            this.openRGBBtn.Size = new System.Drawing.Size(73, 23);
            this.openRGBBtn.TabIndex = 7;
            this.openRGBBtn.Text = "RGB";
            this.openRGBBtn.UseVisualStyleBackColor = true;
            // 
            // openDatasetBtn
            // 
            this.openDatasetBtn.Location = new System.Drawing.Point(6, 22);
            this.openDatasetBtn.Name = "openDatasetBtn";
            this.openDatasetBtn.Size = new System.Drawing.Size(73, 23);
            this.openDatasetBtn.TabIndex = 6;
            this.openDatasetBtn.Text = "Dataset";
            this.openDatasetBtn.UseVisualStyleBackColor = true;
            // 
            // openFolder
            // 
            this.openFolder.Location = new System.Drawing.Point(12, 6);
            this.openFolder.Name = "openFolder";
            this.openFolder.Size = new System.Drawing.Size(75, 23);
            this.openFolder.TabIndex = 8;
            this.openFolder.Text = "openFolder";
            this.openFolder.UseVisualStyleBackColor = true;
            this.openFolder.Click += new System.EventHandler(this.openFolder_Click);
            // 
            // currentFolder
            // 
            this.currentFolder.AutoEllipsis = true;
            this.currentFolder.Location = new System.Drawing.Point(93, 10);
            this.currentFolder.Name = "currentFolder";
            this.currentFolder.Size = new System.Drawing.Size(183, 15);
            this.currentFolder.TabIndex = 9;
            this.currentFolder.Text = "-";
            // 
            // convertBtn
            // 
            this.convertBtn.Enabled = false;
            this.convertBtn.Location = new System.Drawing.Point(6, 22);
            this.convertBtn.Name = "convertBtn";
            this.convertBtn.Size = new System.Drawing.Size(75, 23);
            this.convertBtn.TabIndex = 11;
            this.convertBtn.Text = "Export";
            this.convertBtn.UseVisualStyleBackColor = true;
            this.convertBtn.Click += new System.EventHandler(this.convertBtn_Click);
            // 
            // groupInfo
            // 
            this.groupInfo.Controls.Add(this.classesCount);
            this.groupInfo.Controls.Add(this.label4);
            this.groupInfo.Controls.Add(this.rectCount);
            this.groupInfo.Controls.Add(this.label3);
            this.groupInfo.Controls.Add(this.imageCount);
            this.groupInfo.Controls.Add(this.label1);
            this.groupInfo.Location = new System.Drawing.Point(282, 35);
            this.groupInfo.Name = "groupInfo";
            this.groupInfo.Size = new System.Drawing.Size(202, 145);
            this.groupInfo.TabIndex = 14;
            this.groupInfo.TabStop = false;
            this.groupInfo.Text = "Info";
            // 
            // classesCount
            // 
            this.classesCount.AutoSize = true;
            this.classesCount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.classesCount.Location = new System.Drawing.Point(142, 72);
            this.classesCount.Name = "classesCount";
            this.classesCount.Size = new System.Drawing.Size(13, 15);
            this.classesCount.TabIndex = 5;
            this.classesCount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoEllipsis = true;
            this.label4.Location = new System.Drawing.Point(18, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Classes";
            // 
            // rectCount
            // 
            this.rectCount.AutoSize = true;
            this.rectCount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rectCount.Location = new System.Drawing.Point(142, 49);
            this.rectCount.Name = "rectCount";
            this.rectCount.Size = new System.Drawing.Size(13, 15);
            this.rectCount.TabIndex = 3;
            this.rectCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.Location = new System.Drawing.Point(18, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Count rects";
            // 
            // imageCount
            // 
            this.imageCount.AutoSize = true;
            this.imageCount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.imageCount.Location = new System.Drawing.Point(142, 26);
            this.imageCount.Name = "imageCount";
            this.imageCount.Size = new System.Drawing.Size(13, 15);
            this.imageCount.TabIndex = 1;
            this.imageCount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Count images";
            // 
            // groupExport
            // 
            this.groupExport.Controls.Add(this.convertBtn);
            this.groupExport.Location = new System.Drawing.Point(12, 186);
            this.groupExport.Name = "groupExport";
            this.groupExport.Size = new System.Drawing.Size(472, 57);
            this.groupExport.TabIndex = 15;
            this.groupExport.TabStop = false;
            this.groupExport.Text = "Export";
            // 
            // progressBar
            // 
            this.progressBar.AccessibleName = "";
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 255);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(496, 23);
            this.progressBar.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 278);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupExport);
            this.Controls.Add(this.groupInfo);
            this.Controls.Add(this.groupFolders);
            this.Controls.Add(this.openFolder);
            this.Controls.Add(this.currentFolder);
            this.Name = "Form1";
            this.Text = "UCVConverter";
            this.groupFolders.ResumeLayout(false);
            this.groupInfo.ResumeLayout(false);
            this.groupInfo.PerformLayout();
            this.groupExport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private FolderBrowserDialog folderDialog;
        private GroupBox groupFolders;
        private Label SegmentationFolderName;
        private Label RGBFolderName;
        private Label DatasetFolderName;
        private Button openSegmentationBtn;
        private Button openRGBBtn;
        private Button openDatasetBtn;
        private Button openFolder;
        private Label currentFolder;
        private Button convertBtn;
        private GroupBox groupInfo;
        private Label imageCount;
        private Label label1;
        private Label rectCount;
        private Label label3;
        private Label classesCount;
        private Label label4;
        private GroupBox groupExport;
        private ProgressBar progressBar;
    }
}