using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Forms;

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using SHDocVw;

namespace Havoc__Copy_That
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            listBox1.DragEnter += ListBox1_DragEnter;
            listBox1.DragDrop += ListBox1_DragDrop;
        }



        private void ListBox1_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the data being dragged is of type FileDrop
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Allow the drop
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                // Don't allow the drop
                e.Effect = DragDropEffects.None;
            }
        }

        private void ListBox1_DragDrop(object sender, DragEventArgs e)
        {


        }

        private string GetDestinationFolder(int x, int y)
        {
            // Use Windows API or other mechanisms to determine the destination folder
            // For simplicity, this example returns the desktop folder
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            var unparsedFilesList = Clipboard.GetFileDropList();
            foreach (var filePath in unparsedFilesList)
            {
                MessageBox.Show(filePath);
            }
            Clipboard.Clear();
            timer1.Start();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            // Show the OpenFileDialog to select a file
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a File";
                openFileDialog.Filter = "All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Add the selected file path to the ListBox
                    listBox1.Items.Add(openFileDialog.FileName);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer2.Start();


        }



        // COM Imports

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
        private static string GetActiveExplorerPath()
        {
            Form1 fc = (Form1)Application.OpenForms["Form1"];
            if (fc != null)
            {
                // get the active window
                IntPtr handle = GetForegroundWindow();

                // Required ref: SHDocVw (Microsoft Internet Controls COM Object) - C:\Windows\system32\ShDocVw.dll
                ShellWindows shellWindows = new SHDocVw.ShellWindows();

                // loop through all windows
                foreach (InternetExplorer window in shellWindows)
                {
                    // match active window
                    if (window.HWND == (int)handle)
                    {
                        // Required ref: Shell32 - C:\Windows\system32\Shell32.dll
                        var shellWindow = window.Document as Shell32.IShellFolderViewDual2;

                        // will be null if you are in Internet Explorer for example
                        if (shellWindow != null)
                        {
                            // Item without an index returns the current object
                            var currentFolder = shellWindow.Folder.Items().Item();
                            const int nChars = 256;
                            StringBuilder Buff = new StringBuilder(nChars);
                            // special folder - use window title
                            // for some reason on "Desktop" gives null
                            if (currentFolder == null || currentFolder.Path.StartsWith("::"))
                            {
                                // Get window title instead

                                if (GetWindowText(handle, Buff, nChars) > 0)
                                {
                                    if (Buff.ToString() == "Home")
                                    {
                                       // MessageBox.Show("HOME SILLY");
                                        fc.dirTextBox.Text = Buff.ToString();
                                        fc.timer2.Stop();
                                        //MessageBox.Show(currentFolder.Path);
                                        fc.dirTextBox.Text = currentFolder.Path.ToString();
                                        return Buff.ToString();

                                    }
                                    

                                }
                            }
                            else if(GetWindowText(handle, Buff, nChars) > 0)
                            {
                                fc.dirTextBox.Text = currentFolder.Path.ToString();
                                fc.timer2.Stop();
                                //MessageBox.Show(currentFolder.Path);
 
                                return Buff.ToString();
                            }
                        }

                        break;
                    }
                }
            }
                return null;
            }



    
        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {

            GetActiveExplorerPath();
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // Trigger the drag-and-drop operation on mouse click
            DoDragDrop(new DataObject(DataFormats.FileDrop, listBox1.Items), DragDropEffects.Copy);
        }

        private void listBox1_DragDrop_1(object sender, DragEventArgs e)
        {
            // Get the dropped files
            StringCollection droppedFiles = e.Data.GetData(DataFormats.FileDrop) as StringCollection;

            if (droppedFiles != null && droppedFiles.Count > 0)
            {
                // Perform file handling logic here
                foreach (string file in droppedFiles)
                {
                    // Add the dropped file to the ListBox or process it as needed
                    listBox1.Items.Add(file);
                }

                // Optionally, clear the selection after processing the drop
                listBox1.ClearSelected();
            }
        }

        private void listBox1_DragEnter_1(object sender, DragEventArgs e)
        {
            // Check if the data being dragged is of type FileDrop
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Allow the drop
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                // Don't allow the drop
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }


        private void button4_Click(object sender, EventArgs e)
        {


        }






        private void browseButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = dirTextBox.Text;
            DialogResult drResult = folderBrowserDialog1.ShowDialog();
            if (drResult == System.Windows.Forms.DialogResult.OK)
                dirTextBox.Text = folderBrowserDialog1.SelectedPath;
        }




        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string rootDirectory = "C:\\"; // Change this to the desired directory


            //AddEmptyFoldersToTreeView(rootDirectory, treeView1.Nodes, backgroundWorker1, e);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label1.Text = "Process completed!";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            MessageBox.Show(GetActiveExplorerPath());
        }
    }
}