using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using myFormBuilder.Presenter;
using myFormBuilder.View;

namespace myFormBuilder.WindowsUI
{
    public partial class MainForm : Form, IMainForm
    {
        private const string XML = "XML";
        private const string EXCEL = "Excel";
        private const int PROGRESS_BAR_SPEED = 30;

        private MainFormPresenter _presenter;

        #region IMainForm Implementation
        public string UserId { get; set; }
        public string FileType { get; set; }
        public string CurrentContext { get; set; }
        public string File { get; set; }
        public string ExamCode{ get; set; }
        public string FormName
        {
            get
            {
                return formNameTextBox.Text;
            }
            set
            {
                formNameTextBox.Text = value;
            }
        }
      
        #endregion

        public MainForm(string userId)
        {
            _presenter = new MainFormPresenter(this);
            InitializeComponent();
            MaximizeBox = false;
            UserId = userId;
            LoadForm();
        }

        private void LoadForm()
        {
            var contextNamesAndIDs = _presenter.LoadUserContexts();
            foreach (var context in contextNamesAndIDs.Values)
            {
                contextComboBox.Items.Add(context);
            }

            if (contextComboBox.Items.Count > 0)
                contextComboBox.SelectedIndex = 0;
        }

        private void ExportBtnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FormName))
            {
                MessageBox.Show("You must give the Form a name!", "Input Error....");
                return;
            }
            if (!fileTextBox.Text.Equals(@"C:\"))
            {
                DisableControls();

                if (!worker.IsBusy)
                {
                    progressBar.MarqueeAnimationSpeed = PROGRESS_BAR_SPEED;
                    worker.RunWorkerAsync(new[] { fileTextBox.Text });
                }
            }
            else
            {
                MessageBox.Show("Please Select a File containing Items with their Master Codes!", "Input Error....");
            }
        }

        private const int FILE_INDEX = 0;

        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var args = e.Argument as object[];
                if (args != null)
                {
                    File = args[FILE_INDEX].ToString();
                    var message = _presenter.MakeFormFromFile();
                    MessageBox.Show(message, "Intelitest Erica Form Build");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EnableControls();
            progressBar.MarqueeAnimationSpeed = 0;
            progressBar.Refresh();
        }

        private void FileButton_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(fileDialog.FileName);
                if (fileTypeComboBox.SelectedItem.ToString().Equals(XML))
                {
                    if (!extension.Equals(".xml"))
                    {
                        buildFormButton.Visible = false;
                        MessageBox.Show("Please upload an XML file...", "Intelitest Erica Form Build");
                        fileDialog.Filter = null;
                        return;
                    }
                }
                else if (fileTypeComboBox.SelectedItem.ToString().Equals(EXCEL))
                {
                    if (!(extension.Equals(".xlsx") || extension.Equals(".xls")))
                    {
                        buildFormButton.Visible = false;
                        MessageBox.Show("Please upload an Excel file...", "Intelitest Erica Form Build");
                        fileDialog.Filter = null;
                        return;
                    }
                }
                FileType = fileTypeComboBox.SelectedItem.ToString();
                fileTextBox.Text = fileDialog.FileName;
                buildFormButton.Visible = true;
            }
        }

        private void DisableControls()
        {
            progressBar.Visible = true;
            buildFormButton.Enabled = false;
            fileButton.Enabled = false;
            fileTextBox.Enabled = false;
            contextComboBox.Enabled = false;
            fileTypeComboBox.Enabled = false;
            examComboBox.Enabled = false;
            formNameTextBox.Enabled = false;
        }

        private void EnableControls()
        {
            buildFormButton.Enabled = true;
            fileButton.Enabled = true;
            progressBar.Visible = false;
            contextComboBox.Enabled = true;
            fileTypeComboBox.Enabled = true;
            examComboBox.Enabled = true;
            formNameTextBox.Enabled = true;
        }

        private void ContextComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            examComboBox.Items.Clear();
            if (!string.IsNullOrEmpty(contextComboBox.Text))
            {
                CurrentContext = contextComboBox.Text;
                _presenter.SetCurrentContext();

                var examNames = _presenter.LoadContextExams();

                foreach (var exam in examNames.Values)
                {
                    examComboBox.Items.Add(exam);
                }

                if (examComboBox.Items.Count > 0)
                    examComboBox.SelectedIndex = 0;
            }
        }

        private void ExamComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            ExamCode = examComboBox.Text;
        }
    }
}
