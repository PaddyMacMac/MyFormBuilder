
namespace myFormBuilder.WindowsUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buildFormButton = new System.Windows.Forms.Button();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.fileLabel = new System.Windows.Forms.Label();
            this.fileButton = new System.Windows.Forms.Button();
            this.contextsLbl = new System.Windows.Forms.Label();
            this.contextComboBox = new System.Windows.Forms.ComboBox();
            this.fileTypeLabel = new System.Windows.Forms.Label();
            this.fileTypeComboBox = new System.Windows.Forms.ComboBox();
            this.examLabel = new System.Windows.Forms.Label();
            this.formNameTextBox = new System.Windows.Forms.TextBox();
            this.formNameLabel = new System.Windows.Forms.Label();
            this.examComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buildFormButton
            // 
            this.buildFormButton.Location = new System.Drawing.Point(247, 213);
            this.buildFormButton.Name = "buildFormButton";
            this.buildFormButton.Size = new System.Drawing.Size(87, 23);
            this.buildFormButton.TabIndex = 0;
            this.buildFormButton.Text = "&Build Form";
            this.buildFormButton.UseVisualStyleBackColor = true;
            this.buildFormButton.Visible = false;
            this.buildFormButton.Click += new System.EventHandler(this.ExportBtnClick);
            // 
            // worker
            // 
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WorkerDoWork);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.WorkerRunWorkerCompleted);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(381, 302);
            this.progressBar.MarqueeAnimationSpeed = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(77, 16);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 0;
            this.progressBar.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Location = new System.Drawing.Point(159, 260);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(138, 58);
            this.panel2.TabIndex = 24;
            // 
            // fileTextBox
            // 
            this.fileTextBox.Enabled = false;
            this.fileTextBox.Location = new System.Drawing.Point(115, 180);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.ReadOnly = true;
            this.fileTextBox.Size = new System.Drawing.Size(171, 20);
            this.fileTextBox.TabIndex = 25;
            this.fileTextBox.Text = "C:\\";
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.ForeColor = System.Drawing.Color.White;
            this.fileLabel.Location = new System.Drawing.Point(9, 180);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(50, 13);
            this.fileLabel.TabIndex = 26;
            this.fileLabel.Text = "Input File";
            // 
            // fileButton
            // 
            this.fileButton.Location = new System.Drawing.Point(309, 180);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(25, 23);
            this.fileButton.TabIndex = 27;
            this.fileButton.Text = "...";
            this.fileButton.UseVisualStyleBackColor = true;
            this.fileButton.Click += new System.EventHandler(this.FileButton_Click);
            // 
            // contextsLbl
            // 
            this.contextsLbl.AutoSize = true;
            this.contextsLbl.ForeColor = System.Drawing.SystemColors.Control;
            this.contextsLbl.Location = new System.Drawing.Point(9, 23);
            this.contextsLbl.Name = "contextsLbl";
            this.contextsLbl.Size = new System.Drawing.Size(76, 13);
            this.contextsLbl.TabIndex = 28;
            this.contextsLbl.Text = "Select Context";
            // 
            // contextComboBox
            // 
            this.contextComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.contextComboBox.FormattingEnabled = true;
            this.contextComboBox.Location = new System.Drawing.Point(115, 23);
            this.contextComboBox.Name = "contextComboBox";
            this.contextComboBox.Size = new System.Drawing.Size(171, 21);
            this.contextComboBox.TabIndex = 29;
            this.contextComboBox.SelectedIndexChanged += new System.EventHandler(this.ContextComboBoxSelectedIndexChanged);
            // 
            // fileTypeLabel
            // 
            this.fileTypeLabel.AutoSize = true;
            this.fileTypeLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.fileTypeLabel.Location = new System.Drawing.Point(9, 120);
            this.fileTypeLabel.Name = "fileTypeLabel";
            this.fileTypeLabel.Size = new System.Drawing.Size(83, 13);
            this.fileTypeLabel.TabIndex = 30;
            this.fileTypeLabel.Text = "Select File Type";
            // 
            // fileTypeComboBox
            // 
            this.fileTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fileTypeComboBox.FormattingEnabled = true;
            this.fileTypeComboBox.Items.AddRange(new object[] {
            "XML",
            "Excel"});
            this.fileTypeComboBox.Location = new System.Drawing.Point(115, 112);
            this.fileTypeComboBox.Name = "fileTypeComboBox";
            this.fileTypeComboBox.Size = new System.Drawing.Size(171, 21);
            this.fileTypeComboBox.TabIndex = 31;
            // 
            // examLabel
            // 
            this.examLabel.AutoSize = true;
            this.examLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.examLabel.Location = new System.Drawing.Point(9, 64);
            this.examLabel.Name = "examLabel";
            this.examLabel.Size = new System.Drawing.Size(66, 13);
            this.examLabel.TabIndex = 32;
            this.examLabel.Text = "Select Exam";
            // 
            // formNameTextBox
            // 
            this.formNameTextBox.Location = new System.Drawing.Point(115, 147);
            this.formNameTextBox.Name = "formNameTextBox";
            this.formNameTextBox.Size = new System.Drawing.Size(171, 20);
            this.formNameTextBox.TabIndex = 35;
            // 
            // formNameLabel
            // 
            this.formNameLabel.AutoSize = true;
            this.formNameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.formNameLabel.Location = new System.Drawing.Point(9, 155);
            this.formNameLabel.Name = "formNameLabel";
            this.formNameLabel.Size = new System.Drawing.Size(61, 13);
            this.formNameLabel.TabIndex = 34;
            this.formNameLabel.Text = "Form Name";
            // 
            // examComboBox
            // 
            this.examComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.examComboBox.FormattingEnabled = true;
            this.examComboBox.Location = new System.Drawing.Point(115, 56);
            this.examComboBox.Name = "examComboBox";
            this.examComboBox.Size = new System.Drawing.Size(171, 21);
            this.examComboBox.TabIndex = 36;
            this.examComboBox.SelectedIndexChanged += new System.EventHandler(this.ExamComboBoxSelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(461, 320);
            this.Controls.Add(this.examComboBox);
            this.Controls.Add(this.formNameTextBox);
            this.Controls.Add(this.formNameLabel);
            this.Controls.Add(this.examLabel);
            this.Controls.Add(this.fileTypeComboBox);
            this.Controls.Add(this.fileTypeLabel);
            this.Controls.Add(this.contextComboBox);
            this.Controls.Add(this.contextsLbl);
            this.Controls.Add(this.fileButton);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.fileTextBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buildFormButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.Text = "myFormBuilder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buildFormButton;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.Button fileButton;
        private System.Windows.Forms.Label contextsLbl;
        private System.Windows.Forms.ComboBox contextComboBox;
        private System.Windows.Forms.Label fileTypeLabel;
        private System.Windows.Forms.ComboBox fileTypeComboBox;
        private System.Windows.Forms.Label examLabel;
        private System.Windows.Forms.TextBox formNameTextBox;
        private System.Windows.Forms.Label formNameLabel;
        private System.Windows.Forms.ComboBox examComboBox;

        
    }
}