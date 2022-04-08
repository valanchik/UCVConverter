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
            this.imageSize = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.classesCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rectCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.imageCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupExport = new System.Windows.Forms.GroupBox();
            this.randomDimension = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.yoloHeight = new System.Windows.Forms.NumericUpDown();
            this.yoloWidth = new System.Windows.Forms.NumericUpDown();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.yoloSubdivisions = new System.Windows.Forms.NumericUpDown();
            this.yoloBatch = new System.Windows.Forms.NumericUpDown();
            this.groupFolders.SuspendLayout();
            this.groupInfo.SuspendLayout();
            this.groupExport.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yoloHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoloWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoloSubdivisions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoloBatch)).BeginInit();
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
            this.convertBtn.Location = new System.Drawing.Point(435, 82);
            this.convertBtn.Name = "convertBtn";
            this.convertBtn.Size = new System.Drawing.Size(75, 23);
            this.convertBtn.TabIndex = 11;
            this.convertBtn.Text = "Export";
            this.convertBtn.UseVisualStyleBackColor = true;
            this.convertBtn.Click += new System.EventHandler(this.convertBtn_Click);
            // 
            // groupInfo
            // 
            this.groupInfo.Controls.Add(this.imageSize);
            this.groupInfo.Controls.Add(this.label6);
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
            // imageSize
            // 
            this.imageSize.AutoSize = true;
            this.imageSize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.imageSize.Location = new System.Drawing.Point(121, 93);
            this.imageSize.Name = "imageSize";
            this.imageSize.Size = new System.Drawing.Size(61, 15);
            this.imageSize.TabIndex = 7;
            this.imageSize.Text = "1920x1920";
            this.imageSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Image Size";
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
            this.groupExport.Controls.Add(this.randomDimension);
            this.groupExport.Controls.Add(this.groupBox1);
            this.groupExport.Controls.Add(this.convertBtn);
            this.groupExport.Location = new System.Drawing.Point(12, 186);
            this.groupExport.Name = "groupExport";
            this.groupExport.Size = new System.Drawing.Size(516, 115);
            this.groupExport.TabIndex = 15;
            this.groupExport.TabStop = false;
            this.groupExport.Text = "Export";
            // 
            // randomDimension
            // 
            this.randomDimension.AutoSize = true;
            this.randomDimension.Location = new System.Drawing.Point(361, 33);
            this.randomDimension.Name = "randomDimension";
            this.randomDimension.Size = new System.Drawing.Size(149, 19);
            this.randomDimension.TabIndex = 13;
            this.randomDimension.Text = "Randomize dimensions";
            this.randomDimension.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.yoloSubdivisions);
            this.groupBox1.Controls.Add(this.yoloBatch);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.yoloHeight);
            this.groupBox1.Controls.Add(this.yoloWidth);
            this.groupBox1.Location = new System.Drawing.Point(16, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 83);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Net";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Width";
            // 
            // yoloHeight
            // 
            this.yoloHeight.Increment = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.yoloHeight.Location = new System.Drawing.Point(65, 53);
            this.yoloHeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.yoloHeight.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.yoloHeight.Name = "yoloHeight";
            this.yoloHeight.ReadOnly = true;
            this.yoloHeight.Size = new System.Drawing.Size(67, 23);
            this.yoloHeight.TabIndex = 15;
            this.yoloHeight.Value = new decimal(new int[] {
            416,
            0,
            0,
            0});
            // 
            // yoloWidth
            // 
            this.yoloWidth.Increment = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.yoloWidth.Location = new System.Drawing.Point(65, 24);
            this.yoloWidth.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.yoloWidth.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.yoloWidth.Name = "yoloWidth";
            this.yoloWidth.ReadOnly = true;
            this.yoloWidth.Size = new System.Drawing.Size(67, 23);
            this.yoloWidth.TabIndex = 14;
            this.yoloWidth.Value = new decimal(new int[] {
            416,
            0,
            0,
            0});
            // 
            // progressBar
            // 
            this.progressBar.AccessibleName = "";
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 305);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(540, 23);
            this.progressBar.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(139, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "Subdivisions";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(175, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "Batch";
            // 
            // yoloSubdivisions
            // 
            this.yoloSubdivisions.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.yoloSubdivisions.Location = new System.Drawing.Point(218, 53);
            this.yoloSubdivisions.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.yoloSubdivisions.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.yoloSubdivisions.Name = "yoloSubdivisions";
            this.yoloSubdivisions.ReadOnly = true;
            this.yoloSubdivisions.Size = new System.Drawing.Size(67, 23);
            this.yoloSubdivisions.TabIndex = 19;
            this.yoloSubdivisions.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // yoloBatch
            // 
            this.yoloBatch.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.yoloBatch.Location = new System.Drawing.Point(218, 24);
            this.yoloBatch.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.yoloBatch.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.yoloBatch.Name = "yoloBatch";
            this.yoloBatch.ReadOnly = true;
            this.yoloBatch.Size = new System.Drawing.Size(67, 23);
            this.yoloBatch.TabIndex = 18;
            this.yoloBatch.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 328);
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
            this.groupExport.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yoloHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoloWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoloSubdivisions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoloBatch)).EndInit();
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
        private GroupBox groupBox1;
        private Label label5;
        private Label label2;
        private NumericUpDown yoloHeight;
        private NumericUpDown yoloWidth;
        private Label imageSize;
        private Label label6;
        private CheckBox randomDimension;
        private Label label7;
        private Label label8;
        private NumericUpDown yoloSubdivisions;
        private NumericUpDown yoloBatch;
    }
}