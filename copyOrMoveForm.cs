using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Havoc__Copy_That
{
    public partial class copyOrMoveForm : Form
    {
        string folder = string.Empty;
        public copyOrMoveForm()
        {
            InitializeComponent();
        }

        private void folderPicBox_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                targetDirLabel.Text = folderDlg.SelectedPath;
                folder = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }
        private void okButton_Click(object sender, EventArgs e)
        {

            if (!(folder == string.Empty))
            {
                string selectedItem = copyOrMoveComboBox.Items[copyOrMoveComboBox.SelectedIndex].ToString();
                if (selectedItem == "Copy To")
                {
                    mainForm frm1 = new mainForm();
                    ((Label)frm1.Controls["targetDirLabel"]).Text = folder.ToString();
                    frm1.Show();
                    this.Hide();
                    folder = string.Empty;
                    frm1.Text = "Copy That - By: Havoc - Copy";
                }
                else if(selectedItem == "Move To")
                {
                    mainForm frm2 = new mainForm();
                    ((Label)frm2.Controls["targetDirLabel"]).Text = folder.ToString();
                    frm2.Show();
                    this.Hide();
                    folder = string.Empty;
                    frm2.Text = "Copy That - By: Havoc - Move";
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {


            mainForm frm2 = new mainForm();
            ((Label)frm2.Controls["targetDirLabel"]).Text = folder.ToString();
            //this.Hide();
            folder = string.Empty;

            //mainForm frm2 = new mainForm();
            //((Label)frm2.Controls["targetDirLabel"]).Text = "Select Directory";
            //this.Hide();
            //folder = string.Empty;
        }

        private void minimizePicBox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void exitPicBox_Click(object sender, EventArgs e)
        {
            if (!(folder == string.Empty))
            {
                mainForm frm2 = new mainForm();
                ((Label)frm2.Controls["targetDirLabel"]).Text = folder.ToString();
                this.Hide();
                folder = string.Empty;
            }
        }
    }
}
