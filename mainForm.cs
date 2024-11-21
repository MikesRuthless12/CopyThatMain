using System.Diagnostics;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Security;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;
using static System.Windows.Forms.DataFormats;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using Microsoft.VisualBasic.FileIO;
using Timer = System.Windows.Forms.Timer;
using System.Media;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Tracing;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;
using Havoc__Copy_That.Properties;
using System.Reflection.Emit;
using System.Resources;
using System.Security.Cryptography;
using System.Reflection.Metadata;
using static Havoc__Copy_That.mainForm;
using Button = System.Windows.Forms.Button;
using TextBox = System.Windows.Forms.TextBox;
using Label = System.Windows.Forms.Label;
using System.Security.Cryptography;
using Microsoft.Win32;
using static System.Runtime.InteropServices.JavaScript.JSType;
using String = System.String;
namespace Havoc__Copy_That
{
    public partial class mainForm : Form
    {
        public string blah = "Light";
        private mainForm main;

        private emailForm email;

        private System.Windows.Forms.Timer _timer;

        private DateTime _startTime = DateTime.MinValue;
        private TimeSpan _currentElapsedTime = TimeSpan.Zero;
        private TimeSpan _totalElapsedTime = TimeSpan.Zero;

        private bool _timerRunning = false;
        private bool canceled = false;
        private bool paused = false;
        private int totalFiles = 0;
        private long processedFiles = 0;
        private bool isInitialized = false;

        string pathRoot = "";
        string customFolderName = "";
        Stopwatch sw = new Stopwatch();
        Stopwatch SpeedStopWatch = new Stopwatch();
        long num = 0;
        long fileOn = 0;
        long filesProcessed = 0;
        int progressPercentage = 0;
        long totalBytesProcessed = 0;
        long totalBytesProcessed2 = 0;
        long totalBytes = 0;
        double totalPercentDouble = 0;
        double pct = 0;
        long totalFolderBytes = 0;
        int progressPercentageFile = 0;
        long totalBytesProcessedFile = 0;
        long totalFileBytes = 0;
        long newFolder = 0;
        double totalPercentDoubleFile = 0;
        string SOURCEFILEPLEASE = "";
        string overwriteOption = "";
        string fileNow = "";
        string path = "";
        bool duplicateRows = false;
        bool skipFileUser = false;
        bool skipFileExists = false;
        bool skipFileExistsOlder = false;
        bool skipFileExistsSame = false;
        bool multiThread = Properties.Settings.Default.multithreading;
        bool proVersion = Properties.Settings.Default.versionPro;
        bool updateAuto = Properties.Settings.Default.updateAuto;
        bool updateManually = Properties.Settings.Default.updateManually;
        bool updateBeta = Properties.Settings.Default.updateBeta;
        bool onlyNames = Properties.Settings.Default.fileOnlyNames;
        bool fullPaths = Properties.Settings.Default.fileFullPaths;
        bool zipT = Properties.Settings.Default.zipSeparrately;
        bool zipS = Properties.Settings.Default.zipTogether;
        bool undermb = Properties.Settings.Default.underMB;
        bool overmb = Properties.Settings.Default.overMB;
        bool emailFull = Properties.Settings.Default.emailFullPaths;
        bool emailDirNames = Properties.Settings.Default.emailOnlyNames;
        bool restartProgram = Properties.Settings.Default.restartProgram;
        bool closeProgram = Properties.Settings.Default.closeProgram;
        string priority = Properties.Settings.Default.priority;
        double opacity = Properties.Settings.Default.opacity;
        private System.Windows.Forms.ToolTip toolTip1;
        int bufferSize = 0;
        bool verificationPassed = true;
        bool noDragDrop = false;
        public string stringValue;
        bool EXPANDTHAT = false;
        Stopwatch stopWatch = new Stopwatch();
        public mainForm()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Handle the Timer's Tick event
        /// </summary>
        /// <param name="sender">System.Windows.Forms.Timer instance</param>
        /// <param name="e">EventArgs object</param>
        void _timer_Tick(object sender, EventArgs e)
        {
            // Calculate the time elapsed since the start time, truncating milliseconds
            // to mitigate the Timer's inherent inaccuracy and ensure correct formatting.
            var timeSinceStartTime = DateTime.Now - _startTime;
            timeSinceStartTime = new TimeSpan(timeSinceStartTime.Hours,
                                              timeSinceStartTime.Minutes,
                                              timeSinceStartTime.Seconds);

            // Calculate the current elapsed time by adding time since start and total elapsed time.
            _currentElapsedTime = timeSinceStartTime + _totalElapsedTime;

            // Update the UI label to display the current total elapsed time.
            elapsedTimeLabel.Text = "Elapsed Time: " + _currentElapsedTime.ToString();
        }


        private void timeRemainingTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // Calculate the total elapsed time in seconds
                double elapsedSeconds = stopWatch.Elapsed.TotalSeconds;

                // Calculate the remaining time based on the percentage completed
                // using the formula: timeelapsed * ((100 - %complete) / %complete)
                double remainingSeconds2 = (elapsedSeconds * (100 - totalPercentDouble) / totalPercentDouble);
                TimeSpan remainingTime2 = TimeSpan.FromSeconds(remainingSeconds2);

                // Calculate the average rate of progress in bytes per second
                double bytesPerSecond = totalBytesProcessed / elapsedSeconds;

                // Calculate the remaining time based on the remaining bytes and the average rate
                double remainingSeconds = (totalBytes - totalBytesProcessed) / bytesPerSecond;

                // Format and display the remaining time
                TimeSpan remainingTime = TimeSpan.FromSeconds(remainingSeconds);
                timeRemainingLabel.Text = ($"Time Remaining: {remainingTime2.Hours:D2}:{remainingTime2.Minutes:D2}:{remainingTime2.Seconds:D2}");
                timeRemainingLabel.Refresh();
            }
            catch
            {
                // Handle any exceptions silently
            }
        }




        private void exitPicBox_Click(object sender, EventArgs e)
        {
            if (minimizeSystemTrayCheckBox.Checked == true)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                exitPlease();
                canceled = true;

                if (saveAutoCheckBox.Checked)
                {
                    Properties.Settings.Default.Save();
                }
                if (getFoldersBackgroundWorker.IsBusy)
                {
                    // If the background worker is still busy, cancel the operation
                    getFoldersBackgroundWorker.CancelAsync();

                    // Add some delay to allow the cancellation to take effect
                    Thread.Sleep(1000);

                    // Check if the background worker is still busy
                    if (getFoldersBackgroundWorker.IsBusy)
                    {
                        Console.WriteLine("Background worker is still busy. Waiting for completion...");
                        // You may choose to wait for the background worker to complete or handle it according to your application's requirements.
                        getFoldersBackgroundWorker.RunWorkerCompleted += (s, e) => { Application.Exit(); };
                    }
                    else
                    {
                        Console.WriteLine("Background worker completed after cancellation. Exiting...");

                        Application.Exit();
                    }
                }
                else
                {
                    Console.WriteLine("Background worker is not busy. Exiting...");
                    Application.Exit();
                }


                if (DELETEbackgroundWorker.IsBusy)
                {
                    // If the background worker is still busy, cancel the operation
                    DELETEbackgroundWorker.CancelAsync();

                    // Add some delay to allow the cancellation to take effect
                    Thread.Sleep(1000);

                    // Check if the background worker is still busy
                    if (DELETEbackgroundWorker.IsBusy)
                    {
                        Console.WriteLine("Background worker is still busy. Waiting for completion...");
                        // You may choose to wait for the background worker to complete or handle it according to your application's requirements.
                        DELETEbackgroundWorker.RunWorkerCompleted += (s, e) => { Application.Exit(); };
                    }
                    else
                    {
                        Console.WriteLine("Background worker completed after cancellation. Exiting...");

                        Application.Exit();
                    }
                }
                else
                {
                    Console.WriteLine("Background worker is not busy. Exiting...");
                    Application.Exit();
                }

                if (COPYbackgroundWorker.IsBusy)
                {
                    // If the background worker is still busy, cancel the operation
                    COPYbackgroundWorker.CancelAsync();

                    // Add some delay to allow the cancellation to take effect
                    Thread.Sleep(1000);

                    // Check if the background worker is still busy
                    if (COPYbackgroundWorker.IsBusy)
                    {
                        Console.WriteLine("Background worker is still busy. Waiting for completion...");
                        // You may choose to wait for the background worker to complete or handle it according to your application's requirements.
                        COPYbackgroundWorker.RunWorkerCompleted += (s, e) => { Application.Exit(); };
                    }
                    else
                    {
                        Console.WriteLine("Background worker completed after cancellation. Exiting...");

                        Application.Exit();
                    }
                }
                else
                {
                    Console.WriteLine("Background worker is not busy. Exiting...");

                    Application.Exit();
                }

                if (MOVEbackgroundWorker.IsBusy)
                {
                    // If the background worker is still busy, cancel the operation
                    MOVEbackgroundWorker.CancelAsync();

                    // Add some delay to allow the cancellation to take effect
                    Thread.Sleep(1000);

                    // Check if the background worker is still busy
                    if (MOVEbackgroundWorker.IsBusy)
                    {
                        Console.WriteLine("Background worker is still busy. Waiting for completion...");
                        // You may choose to wait for the background worker to complete or handle it according to your application's requirements.
                        MOVEbackgroundWorker.RunWorkerCompleted += (s, e) => { Application.Exit(); };
                    }
                    else
                    {
                        Console.WriteLine("Background worker completed after cancellation. Exiting...");
                        Application.Exit();
                    }
                }
                else
                {

                    Console.WriteLine("Background worker is not busy. Exiting...");
                    Application.Exit();
                }
                Thread.Sleep(500);

                this.Close();
            }

        }

        private void minimizePicBox_Click(object sender, EventArgs e)
        {
            // Check if the saveAutoCheckBox is checked
            if (saveAutoCheckBox.Checked)
            {
                // If checked, save the settings
                Properties.Settings.Default.Save();
            }

            // Minimize the current form
            this.WindowState = FormWindowState.Minimized;
        }


        public void scanIT(string FolderLocation)
        {
            try
            {
                // Create a DirectoryInfo object to represent the specified folder location
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(FolderLocation);

                // Get an array of FileInfo objects representing the files in the folder
                System.IO.FileInfo[] aryFiles = di.GetFiles("*.*");

                // Get an array of DirectoryInfo objects representing the subdirectories in the folder
                System.IO.DirectoryInfo[] aryDirs = di.GetDirectories();

                // Iterate through each file in the folder
                foreach (System.IO.FileInfo fi in aryFiles)
                {
                    // Increment the file count and update total bytes counters
                    num++;
                    totalBytes += fi.Length;
                    totalFolderBytes += fi.Length;
                    // Uncomment the following lines if you want to update UI elements with file count and total copied progress
                    //fileCountOnLabel.Text = "File Count: 0/" + num.ToString("N0") + "";
                    //totalCopiedProgressLabel.Text = "Total C/M/D: 0/" + FormatBytes(totalBytes);
                }

                // Iterate through each subdirectory in the folder
                foreach (System.IO.DirectoryInfo d in aryDirs)
                {
                    // Get the full path and name of the subdirectory
                    string path2 = d.FullName;
                    string folder2 = new DirectoryInfo(path2).Name;

                    // Recursively call the scanIT method for each subdirectory
                    scanIT(d.FullName);
                }
            }
            catch
            {
                // Handle any exceptions silently
            }
        }


        private void getFoldersBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // Retrieve the path to the folder
            string fileNow = path.ToString();
            var fileInfoNow = new FileInfo(fileNow);

            // Check if the directory exists
            if (Directory.Exists(path))
            {
                // Get stats for the directory
                var directoryStats = GetDirectoryStats(path);

                // Update counters for the total number of files and new files
                num += directoryStats.FileCount;
                newFolder += directoryStats.FileCount;

                // Check if there are new files in the folder
                if (newFolder > 0)
                {
                    // Add folder information to the DataGridView
                    this.fileDirDataGridView.Rows.Add(Havoc__Copy_That.Properties.Resources.icons8_folder_40, "Folder", path.ToString(), fileInfoNow.Name.ToString(), ConvertBytesToMegabytes(totalFolderBytes).ToString("00.00 MB"));

                    // Update UI elements with file count and total copied progress
                    fileCountOnLabel.Text = ($"File Count: 0/{num.ToString("N0")}");
                    totalCopiedProgressLabel.Text = ($"Total C/M/D: 0/{FormatBytes(totalBytes)}");

                    // Select the last row in the DataGridView
                    int lastIndex = fileDirDataGridView.Rows.Count - 1;
                    fileDirDataGridView.Rows[lastIndex].Selected = true;
                    fileDirDataGridView.FirstDisplayedScrollingRowIndex = lastIndex;
                    searchTextBox.Focus();

                    // Play sound if the "On Add Files" checkbox is checked
                    if (onAddFilesCheckBox.Checked)
                    {
                        System.IO.Stream str = Properties.Resources.OnAddFiles;
                        System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                        snd.Play();
                    }
                }
                else
                {
                    // Show a message if the folder is empty
                    MessageBox.Show("Cannot add (" + path.ToString() + ") to the list of files/folders because it is empty ",
                        "Copy That - File/Directory Tool - Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                // Reset newFolder counter
                newFolder = 0;
            }
        }

        private void getFoldersBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            // Update UI elements with final file count and total copied progress
            fileCountOnLabel.Text = "File Count: 0/" + num.ToString("N0") + "";
            totalCopiedProgressLabel.Text = "Total C/M/D: 0/" + FormatBytes(totalBytes);

            // Reset totalFolderBytes and enable the start button
            totalFolderBytes = 0;
            startButton.Enabled = true;

            // Export data from fileDirDataGridView to exportDataGridView
            exportDataGridView.Rows.Clear();
            for (int i = 0; i < fileDirDataGridView.Rows.Count; i++)
            {
                // Extract cell values from columns 3 to 5 in fileDirDataGridView
                object cell1Value = fileDirDataGridView.Rows[i].Cells[2].Value;
                object cell2Value = fileDirDataGridView.Rows[i].Cells[3].Value;
                object cell3Value = fileDirDataGridView.Rows[i].Cells[4].Value;

                // Add new row to exportDataGridView with values from fileDirDataGridView
                exportDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                exportDataGridView.Rows.Add(cell1Value, cell2Value, cell3Value);
            }

            ExpandOrRetract();
        }

        public static string bytesToString(long value)
        {
            string suffix;
            double readable;
            switch (Math.Abs(value))
            {
                // Convert bytes to megabytes if the value is greater than or equal to 0x100000 (1,048,576 bytes)
                case >= 0x100000:
                    suffix = "MB";
                    readable = value >> 10;
                    break;
                default:
                    return value.ToString("0 MB");
            }

            // Convert bytes to megabytes and append the suffix
            return (readable / 1024).ToString("0.## ", CultureInfo.InvariantCulture) + suffix;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("SHIIIIITTTT!!!!");

            // Set the application logic - for demonstration purposes, proVersion is set to true
            proVersion = true;

            // Update the title label based on whether it's the Pro version or not
            if (proVersion)
            {
                titleLabel.Text = "Copy That - File/Directory Tool Pro - Home";
            }
            else
            {
                titleLabel.Text = "Copy That - File/Directory Tool - Home";
            }

            // Set overwrite option to "Overwrite Type - If Newer"
            overwriteOption = "Overwrite Type - If Newer";

            // Sort DataGridView by filePathColumn in ascending order
            this.fileDirDataGridView.Sort(this.fileDirDataGridView.Columns["filePathColumn"], ListSortDirection.Ascending);

            // Set size constraints for the form and tabControl
            this.Size = new System.Drawing.Size(1550, 695);
            tabControl1.Size = new System.Drawing.Size(1525, 615);
            tabControl1.MinimumSize = new System.Drawing.Size(1525, 615);
            tabControl1.MaximumSize = new System.Drawing.Size(1525, 995);
            this.MaximumSize = new System.Drawing.Size(1550, 1075);
            this.MinimumSize = new System.Drawing.Size(1550, 695);

            // Disable illegal cross-thread calls checking
            Control.CheckForIllegalCrossThreadCalls = false;

            // Set initial state of UI elements
            fileProgressBar.Value = 0;
            totalProgressBar.Value = 0;
            startButton.Enabled = true;
            pauseResumeButton.Enabled = false;
            cancelButton.Enabled = false;

            // Initialize and configure timer
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(_timer_Tick);

            // Set default values for ComboBoxes
            copyMoveDeleteComboBox.SelectedIndex = 0;
            onFinishComboBox.SelectedIndex = 1;

            // Set initial text of TextBoxes
            allowedTextBox.Text = "*.";
            excludedTextBox.Text = "*.";

            // Set initialization flag
            isInitialized = true;

            // Set font size based on saved settings
            switch (Properties.Settings.Default.fontSize)
            {
                case 9:
                    this.Font = new System.Drawing.Font("Arial Regular", 9);
                    fontNumUpDown.Value = 9;
                    break;
                case 10:
                    this.Font = new System.Drawing.Font("Arial Regular", 10);
                    fontNumUpDown.Value = 10;
                    break;
                case 11:
                    this.Font = new System.Drawing.Font("Arial Regular", 11);
                    fontNumUpDown.Value = 11;
                    break;
            }


            //if (skinsComboBox.SelectedItem.ToString() == "Dark Mode")
            //{
            //    cmdAboutPage.BackgroundImage = null;
            //    cmdMainPage.BackgroundImage = null;
            //    cmdExclusionsPage.BackgroundImage = null;
            //    Properties.Settings.Default.skinImage = "Dark Mode";
            //    if (saveAutoCheckBox.Checked)
            //    {
            //        Properties.Settings.Default.Save();
            //    }

            //    ChangeControlsForeColor(this, Color.White);

            //    ChangeControlsBackColor(this, Color.Black);

            //    ChangeControlColorsLabelsCheckBoxes(Color.Transparent);

            //    this.BackColor = Color.Black;

            //}
            //else if (skinsComboBox.SelectedItem.ToString() == "Light Mode")
            //{
            //    cmdAboutPage.BackgroundImage = null;
            //    cmdMainPage.BackgroundImage = null;
            //    cmdExclusionsPage.BackgroundImage = null;
            //    Properties.Settings.Default.skinImage = "Light Mode";
            //    if (saveAutoCheckBox.Checked)
            //    {
            //        Properties.Settings.Default.Save();
            //    }
            //    ChangeControlsForeColor(this, Color.Black);

            //    ChangeControlsBackColor(this, Color.WhiteSmoke);

            //    ChangeControlColorsLabelsCheckBoxes(Color.Transparent);

            //    this.BackColor = Color.WhiteSmoke;
            //}
            //nLabel.BackColor = Color.Transparent;
            //neLabel.BackColor = Color.Transparent;
            //eLabel.BackColor = Color.Transparent;
            //seLabel.BackColor = Color.Transparent;
            //sLabel.BackColor = Color.Transparent;
            //swLabel.BackColor = Color.Transparent;
            //wLabel.BackColor = Color.Transparent;
            //nwLabel.BackColor = Color.Transparent;

            // Edit saved checkboxes
            editSavedCheckBoxes();

        }

        // This method initiates the process of moving all files and directories from the source directory to the target directory,
        // excluding a specified file name if provided.
        public static void MoveAll(string source, string target, string skipFileName)
        {
            // Create DirectoryInfo objects for the source and target directories
            var sourceDi = new DirectoryInfo(source);
            var targetDi = new DirectoryInfo(target);

            // Call the overloaded MoveAll method with DirectoryInfo parameters
            MoveAll(sourceDi, targetDi, skipFileName);
        }

        // This method moves all files and directories from the source directory to the target directory,
        // excluding a specified file name if provided. It handles various scenarios including file skipping,
        // overwrite options, progress tracking, error handling, and updating UI elements.
        public static void MoveAll(DirectoryInfo source, DirectoryInfo target, string skipFileName)
        {
            // Get the reference to the main form instance
            mainForm fc = (mainForm)Application.OpenForms["mainForm"];
            // Check if the main form instance exists
            if (fc != null)
            {
                // Check if the target directory exists, if not, create it
                if (!Directory.Exists(target.FullName))
                {
                    Directory.CreateDirectory(target.FullName);
                }

                // Loop through each file in the source directory
                foreach (var fileInfo in source.GetFiles())
                {
                    // Get drive information for space calculation
                    string drive = Path.GetPathRoot(target.FullName);
                    long driveSpaceTotal = (fc.GetTotalSpace(drive));
                    long driveSpaceAvailable = (fc.GetTotalAvailableSpace(drive));
                    long driveSpaceUsed = driveSpaceTotal - driveSpaceAvailable;
                    long availableSpaceCopyMove = driveSpaceAvailable;
                    var f2 = new FileInfo(fileInfo.FullName);

                    // Get original timestamp of the file
                    DateTime originalTimestamp = File.GetLastWriteTime(f2.FullName);

                    // Determine the target file path
                    string fileTarget = Path.Combine(target.FullName, f2.Name);
                    var fileTargetInfo = new FileInfo(fileTarget);

                    try
                    {
                        // Check if there is enough space available on the drive for the operation
                        if (fc.totalBytes >= availableSpaceCopyMove)
                        {
                            MessageBox.Show("There is not enough drive space left to perform the move operation!", "Copy That - File/Directory Tool - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Restart the stopwatch for speed calculation
                        fc.SpeedStopWatch.Restart();

                        // Increment file count
                        fc.fileOn++;

                        // Update UI elements with current file count
                        fc.fileCountOnLabel.Text = "File Count: " + fc.fileOn.ToString("N0") + "/" + fc.num.ToString("N0") + "";

                        // Check if the target file already exists
                        if (File.Exists(fileTargetInfo.FullName))
                        {
                            // Handle different overwrite options
                            // Move the file if it's newer or always overwrite is selected
                            if (fc.overwriteIfNewerCHKBOX.Checked == true && f2.LastWriteTime > fileTargetInfo.LastWriteTime)
                            {
                                fc.filesProcessed++;
                                fileInfo.MoveTo(fileTargetInfo.FullName, true);
                                // Update the file's timestamp to the original timestamp
                                File.SetLastWriteTime(fileTargetInfo.FullName, originalTimestamp);
                            }
                            // Skip if the target file is older
                            else if (fc.overwriteIfNewerCHKBOX.Checked == true && f2.LastWriteTime < fileTargetInfo.LastWriteTime)
                            {
                                fc.skipFileExistsOlder = true;
                            }
                            // Skip if the target file is the same
                            else if (fc.overwriteIfNewerCHKBOX.Checked == true && f2.LastWriteTime == fileTargetInfo.LastWriteTime)
                            {
                                fc.skipFileExistsSame = true;
                            }
                            // Always overwrite the target file
                            else if (fc.overwriteAllCHKBOX.Checked == true)
                            {
                                fc.filesProcessed++;
                                fileInfo.MoveTo(fileTargetInfo.FullName, true);
                                // Update the file's timestamp to the original timestamp
                                File.SetLastWriteTime(fileTargetInfo.FullName, originalTimestamp);
                            }
                            // Do not overwrite the target file
                            else if (fc.doNotOverwriteCHKBOX.Checked == true)
                            {
                                fc.skipFileExists = true;
                                goto skipFileExistsTrue;
                            }
                        }

                        // Handle skipping scenarios
                        // Skip if the target file is the same
                        if (fc.skipFileExistsSame)
                        {
                            goto skipFileExistsSameNow;
                        }
                        // Skip if the target file is older
                        if (fc.skipFileExistsOlder)
                        {
                            goto skipFileExistsOlderNow;
                        }
                        // Skip if the user chooses to skip this file
                        if (fc.skipFileUser)
                        {
                            goto skipThisFile;
                        }

                        // Update UI with current file path
                        fc.filePathLabel.Text = f2.FullName;

                        // Check if the operation is canceled
                        if (fc.canceled)
                        {
                            if (fc.MOVEbackgroundWorker.CancellationPending)
                            {
                                fc.canceled = true;
                                fc.MOVEbackgroundWorker.CancelAsync();
                                return;
                            }
                        }

                        // Wait while the operation is paused
                        while (fc.paused)
                        {
                            if (fc.canceled)
                            {
                                if (fc.MOVEbackgroundWorker.CancellationPending)
                                {
                                    fc.canceled = true;
                                    fc.MOVEbackgroundWorker.CancelAsync();
                                    return;
                                }
                            }
                        }

                        // Update progress percentage
                        if (fc.fileOn == 1)
                        {
                            fc.progressPercentage = (int)((double)fc.totalBytesProcessed / fc.totalBytes * 100);
                            fc.totalPercentDouble = ((double)fc.totalBytesProcessed / fc.totalBytes * 100);
                            goto continueFile;
                        }
                        else
                        {
                            fc.progressPercentage = (int)((double)fc.totalBytesProcessed / fc.totalBytes * 100);
                            fc.totalPercentDouble = ((double)fc.totalBytesProcessed / fc.totalBytes * 100);
                            double totalValue4 = Math.Round(fc.totalPercentDouble, 3);
                            if (totalValue4 >= 100)
                                goto continueFile;
                        }

                        // Stop the stopwatch for speed calculation
                        fc.SpeedStopWatch.Stop();

                    skipFileExistsTrue:
                        // Skip if the target file already exists and skipping is required
                        if (fc.skipFileExists == false)
                        {
                            goto continueFile;
                        }
                        // Update progress if the file is skipped
                        fc.totalBytesProcessed += f2.Length;
                        fc.progressPercentage = (int)((double)fc.totalBytesProcessed / fc.totalBytes * 100);
                        fc.totalPercentDouble = ((double)fc.totalBytesProcessed / fc.totalBytes * 100);
                        fc.fileCountOnLabel.Text = "File Count: " + fc.fileOn.ToString("N0") + "/" + fc.num.ToString("N0") + "";
                        fc.fileCountOnLabel.Refresh();
                        fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                        fc.totalCopiedProgressLabel.Refresh();
                        fc.skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                        fc.skippedDataGridView.Rows.Add("Skipped: File Exists", f2.FullName.ToString(), fc.targetDirLabel.Text, f2.Name.ToString(), ConvertBytesToMegabytes(f2.Length).ToString("00.00 MB"));
                        fc.totalSkippedLabel.Text = "Total Skipped Files: " + fc.skippedDataGridView.Rows.Count + "";
                        fc.fileProcessedLabel.Text = "File Processed: " + FormatBytes(fc.totalBytesProcessedFile) + "/" + FormatBytes(f2.Length);
                        fc.fileProcessedLabel.Refresh();
                        fc.skipFileExists = false;
                        goto continueFile;
                    skipThisFile:
                        // If skipping files due to user choice is enabled...
                        if (fc.skipFileUser == false)
                        {
                            // Skip this file and continue to the next file.
                            goto continueFile;
                        }
                        // Update the total bytes processed.
                        fc.totalBytesProcessed += f2.Length;
                        // Update UI elements to reflect the skipped file.
                        fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                        fc.totalCopiedProgressLabel.Refresh();
                        fc.skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                        fc.skippedDataGridView.Rows.Add("Skipped: User", f2.FullName.ToString(), fc.targetDirLabel.Text, f2.Name.ToString(), ConvertBytesToMegabytes(f2.Length).ToString("00.00 MB"));
                        fc.totalSkippedLabel.Text = "Total Skipped Files: " + fc.skippedDataGridView.Rows.Count + "";
                        fc.fileProcessedLabel.Refresh();
                        fc.fileProcessedLabel.Text = "File Processed: " + FormatBytes(fc.totalBytesProcessedFile) + "/" + FormatBytes(f2.Length);
                        fc.fileProcessedLabel.Refresh();
                        fc.skipFileUser = false;
                        // Continue to the next file.
                        goto continueFile;
                    // Check if skipping files that already exist and are older is disabled
                    skipFileExistsOlderNow:
                        if (fc.skipFileExistsOlder == false)
                        {
                            // If skipping is disabled, continue processing the file
                            goto continueFile;
                        }

                        // Update total bytes processed
                        fc.totalBytesProcessed += f2.Length;

                        // Update UI with progress information
                        fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                        fc.totalCopiedProgressLabel.Refresh();

                        // Set color for skippedDataGridView row
                        fc.skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;

                        // Add information about skipped file to skippedDataGridView
                        fc.skippedDataGridView.Rows.Add("Skipped: File is Older", f2.FullName.ToString(), fc.targetDirLabel.Text, f2.Name.ToString(), ConvertBytesToMegabytes(f2.Length).ToString("00.00 MB"));

                        // Update total skipped files label
                        fc.totalSkippedLabel.Text = "Total Skipped Files: " + fc.skippedDataGridView.Rows.Count + "";

                        // Refresh UI
                        fc.fileProcessedLabel.Refresh();
                        fc.fileProcessedLabel.Text = "File Processed: " + FormatBytes(fc.totalBytesProcessedFile) + "/" + FormatBytes(f2.Length);
                        fc.fileProcessedLabel.Refresh();

                        // Reset skipFileExistsOlder flag and continue processing
                        fc.skipFileExistsOlder = false;
                        goto continueFile;

                    // Check if skipping files that already exist and are the same is disabled
                    skipFileExistsSameNow:
                        if (fc.skipFileExistsSame == false)
                        {
                            // If skipping is disabled, continue processing the file
                            goto continueFile;
                        }

                        // Update total bytes processed
                        fc.totalBytesProcessed += f2.Length;

                        // Update UI with progress information
                        fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                        fc.totalCopiedProgressLabel.Refresh();

                        // Set color for skippedDataGridView row
                        fc.skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;

                        // Add information about skipped file to skippedDataGridView
                        fc.skippedDataGridView.Rows.Add("Skipped: Same File", f2.FullName.ToString(), fc.targetDirLabel.Text, f2.Name.ToString(), ConvertBytesToMegabytes(f2.Length).ToString("00.00 MB"));

                        // Update total skipped files label
                        fc.totalSkippedLabel.Text = "Total Skipped Files: " + fc.skippedDataGridView.Rows.Count + "";

                        // Refresh UI
                        fc.fileProcessedLabel.Refresh();
                        fc.fileProcessedLabel.Text = "File Processed: " + FormatBytes(fc.totalBytesProcessedFile) + "/" + FormatBytes(f2.Length);
                        fc.fileProcessedLabel.Refresh();

                        // Reset skipFileExistsSame flag and continue processing
                        fc.skipFileExistsSame = false;
                        goto continueFile;
                    // This label marks the point where the code should continue after skipping a file.
                    continueFile:
                        // Update total bytes processed.
                        fc.totalBytesProcessed += f2.Length;
                        // Update UI elements to reflect progress.
                        fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                        fc.totalCopiedProgressLabel.Refresh();
                        double totalValue = Math.Round(fc.totalPercentDouble, 3);
                        fc.totalProgressLabel.Text = totalValue.ToString("00.00") + "%";
                        fc.totalProgressBar.Value = fc.progressPercentage;
                        fc.totalProgressBar.Refresh();
                        fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                        fc.totalCopiedProgressLabel.Refresh();
                        fc.fileProcessedLabel.Text = "File Processed: " + FormatBytes(fc.totalBytesProcessedFile) + "/" + FormatBytes(f2.Length);
                        fc.fileProcessedLabel.Refresh();
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // If the error sound option is enabled, play the error sound.
                        if (fc.onErrorCheckBox.Checked)
                        {
                            System.IO.Stream str = Properties.Resources.OnError;
                            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                            snd.Play();
                        }

                        // If the restart option is checked, restart the application.
                        if (fc.restartCheckBox.Checked == true)
                        {
                            Application.Restart();
                            Environment.Exit(0);
                        }
                        else
                        {
                            // Otherwise, exit the application.
                            fc.exitPlease();
                        }

                        // Get information about the file causing the unauthorized access exception.
                        var fileInfoNow = new FileInfo(fc.fileNow);
                        // Update the total bytes processed.
                        fc.totalBytesProcessed += fileInfoNow.Length;
                        // Update UI elements to reflect the skipped file due to unauthorized access.
                        fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                        fc.totalCopiedProgressLabel.Refresh();
                        fc.skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                        fc.skippedDataGridView.Rows.Add("Skipped: Unauth. Access", fileInfoNow.FullName.ToString(), fc.targetDirLabel.Text, fileInfoNow.Name.ToString(), ConvertBytesToMegabytes(fileInfoNow.Length).ToString("00.00 MB"));
                        fc.totalSkippedLabel.Text = "Total Skipped Files: " + fc.skippedDataGridView.Rows.Count + "";
                        fc.fileProcessedLabel.Text = "File Processed: " + FormatBytes(fc.totalBytesProcessedFile) + "/" + FormatBytes(f2.Length);
                        fc.fileProcessedLabel.Refresh();
                        double totalValue2 = Math.Round(fc.totalPercentDouble, 3);
                        fc.totalProgressLabel.Text = totalValue2.ToString("00.00") + "%";
                        fc.totalProgressBar.Value = fc.progressPercentage;
                        fc.totalProgressBar.Refresh();
                    }
                    catch (IOException)
                    {
                        // If the error sound option is enabled, play the error sound.
                        if (fc.onErrorCheckBox.Checked)
                        {
                            System.IO.Stream str = Properties.Resources.OnError;
                            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                            snd.Play();
                        }

                        // If the restart option is checked, restart the application.
                        if (fc.restartCheckBox.Checked == true)
                        {
                            Application.Restart();
                            Environment.Exit(0);
                        }
                        else
                        {
                            // Otherwise, exit the application.
                            fc.exitPlease();
                        }

                        // Get information about the file causing the I/O exception.
                        var fileInfoNow = new FileInfo(fc.fileNow);
                        // Update the total bytes processed.
                        fc.totalBytesProcessed += fileInfoNow.Length;
                        // Update UI elements to reflect the skipped file due to an I/O exception.
                        fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                        fc.totalCopiedProgressLabel.Refresh();
                        fc.skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                        fc.skippedDataGridView.Rows.Add("Skipped: IOException", fileInfoNow.FullName.ToString(), fc.targetDirLabel.Text, fileInfoNow.Name.ToString(), ConvertBytesToMegabytes(fileInfoNow.Length).ToString("00.00 MB"));
                        fc.totalSkippedLabel.Text = "Total Skipped Files: " + fc.skippedDataGridView.Rows.Count + "";
                        fc.fileProcessedLabel.Text = "File Processed: " + FormatBytes(fc.totalBytesProcessedFile) + "/" + FormatBytes(f2.Length);
                        fc.fileProcessedLabel.Refresh();
                        double totalValue3 = Math.Round(fc.totalPercentDouble, 3);
                        fc.totalProgressLabel.Text = totalValue3.ToString("00.00") + "%";
                        fc.totalProgressBar.Value = fc.progressPercentage;
                        fc.totalProgressBar.Refresh();
                        fc.fileOn += 1;
                    }
                    finally
                    {
                        // The finally block is empty.
                    }

                    // Retrieve drive information.
                    DriveInfo driveInfo = new DriveInfo(Path.GetPathRoot(drive));
                    if (driveInfo.IsReady)
                    {
                        // Get total and free drive space.
                        long totalDriveSpace = driveInfo.TotalSize;
                        long freeDriveSpace = driveInfo.TotalFreeSpace;

                        // Calculate available space for copying/moving.
                        driveSpaceTotal = driveInfo.TotalSize;
                        driveSpaceAvailable = driveInfo.TotalFreeSpace;
                        availableSpaceCopyMove = totalDriveSpace - freeDriveSpace;

                        // Update UI element to display total available space.
                        fc.totalHDSpaceLeftLabel.Text = "Total Space: " + FormatBytes(availableSpaceCopyMove) + "/" + FormatBytes(driveSpaceTotal) + "";

                        // If there's not enough space on the drive, display a message box and return.
                        if (fc.totalBytes >= availableSpaceCopyMove)
                        {
                            MessageBox.Show("There is not enough drive space left to perform the copy operation. Please remove some files/folders.", "Copy That - File/Directory Tool",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    // Reset file progress bar and labels.
                    fc.fileProgressBar.Value = 0;
                    fc.fileProgressBar.Refresh();
                    fc.fileTotalProgressLabel.Text = "0%";
                    fc.speedLabel.Refresh();

                    // Copy each subdirectory using recursion.
                    foreach (var subDir in source.GetDirectories())
                    {
                        // Check if the subdirectory's name is different from the target directory's name to avoid duplication.
                        if (subDir.Name != target.Name)
                        {
                            // Create a corresponding subdirectory in the target directory.
                            var nextTargetSubDir = target.CreateSubdirectory(subDir.Name);
                            // Recursively call the MoveAll function to copy the contents of the current subdirectory.
                            MoveAll(subDir, nextTargetSubDir, skipFileName);
                        }
                    }
                }
            }
        }
        //MOVE ALL FILES ON DGV BACKGROUNDWORKER
        private void MOVEbackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            // Check if there are rows in the DataGridView
            if (fileDirDataGridView.Rows.Count > 0)
            {
                // Get the index of the currently selected row
                int currentRow = fileDirDataGridView.SelectedRows[0].Index;

                // Loop through each row in the DataGridView
                for (int i = 0; i < fileDirDataGridView.Rows.Count; i++)
                {
                    // Retrieve information about the drive where the files will be moved/copied
                    FileInfo f = new FileInfo(targetDirLabel.Text);
                    string drive = Path.GetPathRoot(f.FullName);
                    long driveSpaceTotal = (GetTotalSpace(drive));
                    long driveSpaceAvailable = (GetTotalAvailableSpace(drive));
                    long availableSpaceCopyMove = driveSpaceAvailable;

                    // Check if the operation has been canceled
                    if (canceled)
                    {
                        if (MOVEbackgroundWorker.CancellationPending)
                        {
                            canceled = true;
                            MOVEbackgroundWorker.CancelAsync();
                            return;
                        }
                    }

                    // Pause the operation if it is currently paused
                    while (paused == true)
                    {
                        if (canceled)
                        {
                            if (MOVEbackgroundWorker.CancellationPending)
                            {
                                canceled = true;
                                MOVEbackgroundWorker.CancelAsync();
                                return;
                            }
                        }
                    }

                    // Select the current row in the DataGridView
                    fileDirDataGridView.Rows[i].Selected = true;
                    DataGridViewRow row = fileDirDataGridView.Rows[i];

                    // Get information about the file/directory
                    string fileNow = row.Cells[2].Value.ToString();
                    var fileInfoNow = new FileInfo(fileNow);

                    // Handle directory
                    if (currentRow <= fileDirDataGridView.RowCount - 1)
                    {
                        if (row.Cells[1].Value == "Folder")
                        {
                            try
                            {
                                // Move the directory and its contents to the target directory
                                var sourceDi = new DirectoryInfo(fileNow.ToString());
                                var targetDi = new DirectoryInfo(Path.Combine(targetDirLabel.Text));
                                MoveAll(sourceDi, targetDi, "");

                                // Update the DataGridView to indicate the move operation was successful
                                fileDirDataGridView.Rows[fileDirDataGridView.SelectedRows[0].Index].Cells[0].Value = Havoc__Copy_That.Properties.Resources.icons8_ok_40;
                                fileDirDataGridView.Rows[fileDirDataGridView.SelectedRows[0].Index].Cells[1].Value = fileOn.ToString() + " Moved Files";
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                        }
                        // Handle file
                        else
                        {
                            try
                            {
                                // Move or copy the file to the target directory based on user preferences
                                var sourceDi = new FileInfo(fileNow.ToString());
                                var targetDi = new DirectoryInfo(targetDirLabel.Text.ToString());
                                // Skips the file if requested by the user
                                if (skipFileUser)
                                {
                                    goto skipThisFile;
                                }

                                // Handle cancellation of the operation
                                if (canceled)
                                {
                                    if (DELETEbackgroundWorker.CancellationPending)
                                    {
                                        canceled = true;
                                        DELETEbackgroundWorker.CancelAsync();
                                        return;
                                    }
                                }

                                // Pause the operation if it is currently paused
                                while (paused == true)
                                {
                                    if (canceled)
                                    {
                                        if (DELETEbackgroundWorker.CancellationPending)
                                        {
                                            canceled = true;
                                            DELETEbackgroundWorker.CancelAsync();
                                            return;
                                        }
                                    }
                                }


                                // Check if the source file exists
                                if (File.Exists(sourceDi.FullName))
                                {
                                    // Handle various overwrite scenarios based on user preferences
                                    if (overwriteIfNewerCHKBOX.Checked == true && sourceDi.LastWriteTime > targetDi.LastWriteTime)
                                    {
                                        File.Move(sourceDi.FullName, targetDi.FullName, true);
                                    }
                                    else if (overwriteIfNewerCHKBOX.Checked == true && sourceDi.LastWriteTime < targetDi.LastWriteTime)
                                    {
                                        skipFileExistsOlder = true;
                                    }
                                    else if (overwriteIfNewerCHKBOX.Checked == true && sourceDi.LastWriteTime == targetDi.LastWriteTime)
                                    {
                                        skipFileExistsSame = true;
                                    }
                                    else if (overwriteAllCHKBOX.Checked == true)
                                    {
                                        File.Move(sourceDi.FullName, targetDi.FullName, true);
                                    }
                                    else if (doNotOverwriteCHKBOX.Checked == true)
                                    {
                                        skipFileExists = true;
                                    }
                                }

                                // Handle scenarios where the file needs to be skipped
                                if (skipFileExistsSame)
                                {
                                    goto skipFileExistsSameNow;
                                }

                                if (skipFileExistsOlder)
                                {
                                    goto skipFileExistsOlderNow;
                                }

                                // Increase the total bytes processed
                                totalBytesProcessed += fileInfoNow.Length;

                                // Update progress indicators
                                if (fileOn == 1)
                                {
                                    progressPercentage = (int)((double)totalBytesProcessed / totalBytes * 100);
                                    totalPercentDouble = ((double)totalBytesProcessed / totalBytes * 100);
                                    progressPercentageFile = (int)((double)totalBytesProcessed / fileInfoNow.Length * 100);
                                    totalPercentDoubleFile = ((double)totalBytesProcessed / fileInfoNow.Length * 100);
                                    goto fileCountOne;
                                }


                            // Label to jump to if the file needs to be skipped
                            skipThisFile:
                                // Check if the file skipping condition is not met
                                if (skipFileUser == false)
                                {
                                    // Continue to the next file
                                    goto continueFile;
                                }
                                // Update total bytes processed and UI elements to reflect the skipped file
                                totalBytesProcessed += fileInfoNow.Length;
                                totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(totalBytesProcessed) + "/" + FormatBytes(totalBytes) + "";
                                totalCopiedProgressLabel.Refresh();
                                skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                                skippedDataGridView.Rows.Add("Skipped: User", sourceDi.FullName.ToString(), targetDirLabel.Text, sourceDi.Name.ToString(), ConvertBytesToMegabytes(sourceDi.Length).ToString("00.00 MB"));
                                totalSkippedLabel.Text = "Total Skipped Files: " + skippedDataGridView.Rows.Count + "";
                                totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(totalBytesProcessed) + "/" + FormatBytes(totalBytes) + "";
                                totalCopiedProgressLabel.Refresh();
                                // Reset skipFileUser flag
                                skipFileUser = false;
                                // Continue to the next file
                                goto continueFile;

                            // Label to jump to if the file already exists and is the same
                            skipFileExistsSameNow:
                                // Check if the file skipping condition is not met
                                if (skipFileUser == false)
                                {
                                    // Continue to the next file
                                    goto continueFile;
                                }
                                // Update total bytes processed and UI elements to reflect the skipped file
                                totalBytesProcessed += fileInfoNow.Length;
                                totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(totalBytesProcessed) + "/" + FormatBytes(totalBytes) + "";
                                totalCopiedProgressLabel.Refresh();
                                skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                                skippedDataGridView.Rows.Add("Skipped: Same File", sourceDi.FullName.ToString(), targetDirLabel.Text, sourceDi.Name.ToString(), ConvertBytesToMegabytes(sourceDi.Length).ToString("00.00 MB"));
                                totalSkippedLabel.Text = "Total Skipped Files: " + skippedDataGridView.Rows.Count + "";
                                totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(totalBytesProcessed) + "/" + FormatBytes(totalBytes) + "";
                                totalCopiedProgressLabel.Refresh();
                                // Reset skipFileExistsSame flag
                                skipFileExistsSame = false;
                                // Continue to the next file
                                goto continueFile;

                            // Label to jump to if the file already exists and is older
                            skipFileExistsOlderNow:
                                // Check if the file skipping condition is not met
                                if (skipFileUser == false)
                                {
                                    // Continue to the next file
                                    goto continueFile;
                                }
                                // Update total bytes processed and UI elements to reflect the skipped file
                                totalBytesProcessed += fileInfoNow.Length;
                                totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(totalBytesProcessed) + "/" + FormatBytes(totalBytes) + "";
                                totalCopiedProgressLabel.Refresh();
                                skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                                skippedDataGridView.Rows.Add("Skipped: File is Older", sourceDi.FullName.ToString(), targetDirLabel.Text, sourceDi.Name.ToString(), ConvertBytesToMegabytes(sourceDi.Length).ToString("00.00 MB"));
                                totalSkippedLabel.Text = "Total Skipped Files: " + skippedDataGridView.Rows.Count + "";
                                totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(totalBytesProcessed) + "/" + FormatBytes(totalBytes) + "";
                                totalCopiedProgressLabel.Refresh();
                                // Reset skipFileExistsOlder flag
                                skipFileExistsOlder = false;
                                // Continue to the next file
                                goto continueFile;

                            // Label to continue processing the next file
                            continueFile:
                                // Check if there are rows in the DataGridView
                                if (fileDirDataGridView.Rows.Count > 0)
                                {
                                    // Select the last row
                                    int lastIndex = fileDirDataGridView.Rows.Count - 1;
                                    fileDirDataGridView.Rows[lastIndex].Selected = true;
                                }
                                // Round the total percentage value
                                double totalValue = Math.Round(totalPercentDouble, 3);
                                // If the total value is equal to or exceeds 100%, continue to the next file
                                if (totalValue >= 100)
                                    goto continueFile;
                                // Update progress indicators
                                totalProgressLabel.Text = totalValue.ToString("00.00") + "%";
                                totalProgressBar.Value = progressPercentage;
                                totalProgressBar.Refresh();
                                totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(totalBytesProcessed) + "/" + FormatBytes(totalBytes) + "";
                                totalCopiedProgressLabel.Refresh();
                                fileProcessedLabel.Refresh();
                            fileCountOne:;
                            }
                            // Catch block for handling UnauthorizedAccessException
                            catch (UnauthorizedAccessException)
                            {
                                // Check if the error sound checkbox is checked
                                if (onErrorCheckBox.Checked)
                                {
                                    // Play error sound
                                    System.IO.Stream str = Properties.Resources.OnError;
                                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                                    snd.Play();
                                }
                                // Check if the restart checkbox is checked
                                if (restartCheckBox.Checked == true)
                                {
                                    // Restart the application and exit
                                    Application.Restart();
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    // Call the exitPlease method
                                    exitPlease();
                                }
                                // Get file info of the current file
                                var sourceDi = new FileInfo(fileNow.ToString());
                                // Update total bytes processed
                                totalBytesProcessed += sourceDi.Length;
                                // Update UI elements to reflect skipped file due to unauthorized access
                                totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(totalBytesProcessed) + "/" + FormatBytes(totalBytes) + "";
                                totalCopiedProgressLabel.Refresh();
                                skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                                skippedDataGridView.Rows.Add("Skipped: Unauth. Access", sourceDi.FullName.ToString(), targetDirLabel.Text, sourceDi.Name.ToString(), ConvertBytesToMegabytes(sourceDi.Length).ToString("00.00 MB"));
                                totalSkippedLabel.Text = "Total Skipped Files: " + skippedDataGridView.Rows.Count + "";
                                // Select the last row in the file directory DataGridView
                                if (fileDirDataGridView.Rows.Count > 0)
                                {
                                    int lastIndex = fileDirDataGridView.Rows.Count - 1;
                                    fileDirDataGridView.Rows[lastIndex].Selected = true;
                                }
                                // Round the total percentage value
                                double totalValue = Math.Round(totalPercentDouble, 3);
                                // Update total progress label and bar
                                totalProgressLabel.Text = totalValue.ToString("00.00") + "%";
                                totalProgressBar.Value = progressPercentage;
                                totalProgressBar.Refresh();
                            }

                            // Catch block for handling IOException
                            catch (IOException)
                            {
                                // Check if the error sound checkbox is checked
                                if (onErrorCheckBox.Checked)
                                {
                                    // Play error sound
                                    System.IO.Stream str = Properties.Resources.OnError;
                                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                                    snd.Play();
                                }
                                // Check if the restart checkbox is checked
                                if (restartCheckBox.Checked == true)
                                {
                                    // Restart the application and exit
                                    Application.Restart();
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    // Call the exitPlease method
                                    exitPlease();
                                }
                                // Get file info of the current file
                                var sourceDi = new FileInfo(fileNow.ToString());
                                // Update total bytes processed
                                totalBytesProcessed += sourceDi.Length;
                                // Update UI elements to reflect skipped file due to IOException
                                totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(totalBytesProcessed) + "/" + FormatBytes(totalBytes) + "";
                                totalCopiedProgressLabel.Refresh();
                                skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                                skippedDataGridView.Rows.Add("Skipped: IOException", sourceDi.FullName.ToString(), targetDirLabel.Text, sourceDi.Name.ToString(), ConvertBytesToMegabytes(sourceDi.Length).ToString("00.00 MB"));
                                totalSkippedLabel.Text = "Total Skipped Files: " + skippedDataGridView.Rows.Count + "";
                                // Select the last row in the file directory DataGridView
                                if (fileDirDataGridView.Rows.Count > 0)
                                {
                                    int lastIndex = fileDirDataGridView.Rows.Count - 1;
                                    fileDirDataGridView.Rows[lastIndex].Selected = true;
                                }
                                // Round the total percentage value
                                double totalValue = Math.Round(totalPercentDouble, 3);
                                // Update total progress label and bar
                                totalProgressLabel.Text = totalValue.ToString("00.00") + "%";
                                totalProgressBar.Value = progressPercentage;
                                totalProgressBar.Refresh();
                                // Increment fileOn counter
                                fileOn += 1;
                            }

                            // Finally block
                            finally
                            {
                                // Get drive information
                                DriveInfo driveInfo = new DriveInfo(Path.GetPathRoot(drive));
                                if (driveInfo.IsReady)
                                {
                                    // Calculate total and free drive space
                                    long totalDriveSpace = driveInfo.TotalSize;
                                    long freeDriveSpace = driveInfo.TotalFreeSpace;
                                    driveSpaceTotal = driveInfo.TotalSize;
                                    driveSpaceAvailable = driveInfo.TotalFreeSpace;
                                    availableSpaceCopyMove = totalDriveSpace - freeDriveSpace;
                                    // Update total hard drive space left label
                                    totalHDSpaceLeftLabel.Text = "Total Space: " + FormatBytes(availableSpaceCopyMove) + "/" + FormatBytes(driveSpaceTotal) + "";
                                }
                                // Reset variables and UI elements related to file processing
                                totalBytesProcessedFile = 0;
                                fileProgressBar.Value = 0;
                                fileProgressBar.Refresh();
                                fileTotalProgressLabel.Text = "0%";
                                speedLabel.Refresh();
                            }
                        }
                    }
                }
            }
        }
        private void MOVEbackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Stop the time remaining timer
            timeRemainingTimer.Stop();

            // Stop and reset the main timer if it was running
            _timer.Stop();
            _timerRunning = false;

            // Reset the elapsed time TimeSpan objects
            _totalElapsedTime = TimeSpan.Zero;
            _currentElapsedTime = TimeSpan.Zero;

            // Check if the operation was canceled
            if (canceled == true)
            {
                // Check if the cancel sound checkbox is checked
                if (onCancelCheckBox.Checked)
                {
                    // Play cancel sound
                    System.IO.Stream str = Properties.Resources.OnCancel;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                }

                // Calculate the number of processed files
                processedFiles = (fileOn - skippedDataGridView.Rows.Count);

                // Show message box indicating the move operation was canceled
                MessageBox.Show("Move Operation was Canceled!" + Environment.NewLine +
                    "" + elapsedTimeLabel.Text + "" + Environment.NewLine +
                    "" + fileCountOnLabel.Text + "" + Environment.NewLine +
                    "" + overwriteOption + "" + Environment.NewLine +
                    "Processed File Count: " + processedFiles.ToString("N0") + "/" + num.ToString("N0") + "" + Environment.NewLine +
                    "Skipped File Count: " + skippedDataGridView.Rows.Count + "/" + num.ToString("N0") + "" + Environment.NewLine +
                    "" + totalCopiedProgressLabel.Text + "", "Copy That - File/Directory Tool - Move Operation was Canceled!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset various variables and UI elements
                // ...

            }
            else
            {
                // Check if the finish sound checkbox is checked
                if (onFinishCheckBox.Checked)
                {
                    // Play finish sound
                    System.IO.Stream str = Properties.Resources.OnFinish;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                }

                // Calculate the number of processed files
                processedFiles = (fileOn - skippedDataGridView.Rows.Count);

                // Show message box indicating the move operation was completed
                MessageBox.Show("Move Operation was Completed!" + Environment.NewLine +
                    "" + elapsedTimeLabel.Text + "" + Environment.NewLine +
                    "" + fileCountOnLabel.Text + "" + Environment.NewLine +
                    "" + overwriteOption + "" + Environment.NewLine +
                    "Processed File Count: " + processedFiles.ToString("N0") + "/" + num.ToString("N0") + "" + Environment.NewLine +
                    "Skipped File Count: " + skippedDataGridView.Rows.Count + "/" + num.ToString("N0") + "" + Environment.NewLine +
                    "" + totalCopiedProgressLabel.Text + "", "Copy That - File/Directory Tool - Move Operation was Completed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                num = 0;
                processedFiles = 0;
                totalBytes = 0;
                totalBytesProcessed = 0;
                totalPercentDouble = 0;
                pct = 0;
                fileOn = 0;
                copyMoveDeleteComboBox.Text = string.Empty;
                totalCopiedProgressLabel.Text = "Total C/M/D: 0/0 Bytes";
                elapsedTimeLabel.Text = "Elapsed Time: 00:00:00";
                timeRemainingLabel.Text = "Time Remaining: 00:00:00";
                totalProgressBar.Value = 0;
                fileProgressBar.Value = 0;
                totalProgressLabel.Text = "0%";
                fileTotalProgressLabel.Text = "0%";
                fileCountOnLabel.Text = "File Count: 0/0";
                filePathLabel.Text = "Nothing";
                fromFilesDirLabel.Text = "Select Files/Directory";
                targetDirLabel.Text = "SelectFiles/Directory";
                fileProcessedLabel.Text = "File Processed: 0/0 Bytes";
                speedLabel.Text = "Speed: 0 Mb/Sec.";
                totalHDSpaceLeftLabel.Text = "Total Space: 0/0 Bytes";
                totalHDSpaceLeftLabel.Refresh();
                fileIconPicBox.Image = (Havoc__Copy_That.Properties.Resources.icons8_file_40);
                fileDirDataGridView.Rows.Clear();
                startButton.Enabled = true;
                cancelButton.Enabled = false;
                pauseResumeButton.Enabled = false;
                clearFileListButton.Enabled = true;
                canceled = false;
                skipButton.Enabled = false;

                copyMoveDeleteComboBox.Enabled = true;
                doNotOverwriteCHKBOX.Enabled = true;
                overwriteAllCHKBOX.Enabled = true;
                overwriteIfNewerCHKBOX.Enabled = true;
                keepDirStructCheckBox.Enabled = true;
                createCustomDirCheckBox.Enabled = true;
                copyFilesDirsCheckBox.Enabled = true;
                clearTextButton.Enabled = true;
                searchTextBox.Enabled = true;
                fromDirPicBox.Enabled = true;
                targetDirPicBox.Enabled = true;
                fileUpPicBox.Enabled = true;
                fileDownPicBox.Enabled = true;
                moveTopPicBox.Enabled = true;
                moveBottomPicBox.Enabled = true;

                // Enable sorting for each column in the fileDirDataGridView
                foreach (DataGridViewColumn column in fileDirDataGridView.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                }

                // Check if there are rows in the skippedDataGridView
                if (skippedDataGridView.Rows.Count > 0)
                {
                    // Disable certain buttons and select the skip page in the tab control
                    ((Control)this.cmdMainPage).Enabled = false;
                    ((Control)this.cmdSkipPage).Enabled = true;
                    ((Control)this.cmdAboutPage).Enabled = false;
                    ((Control)this.cmdSettingsPage).Enabled = false;
                    ((Control)this.cmdCopyHistoryPage).Enabled = false;
                    tabControl1.SelectedTab = cmdSkipPage;
                }
                else
                {
                    // Enable all buttons and select the main page in the tab control
                    ((Control)this.cmdMainPage).Enabled = true;
                    ((Control)this.cmdSkipPage).Enabled = true;
                    ((Control)this.cmdAboutPage).Enabled = true;
                    ((Control)this.cmdSettingsPage).Enabled = true;
                    ((Control)this.cmdCopyHistoryPage).Enabled = true;
                    tabControl1.SelectedTab = cmdMainPage;
                }
            }

            // Get the selected item from the onFinishComboBox
            string selectedAction = onFinishComboBox.SelectedItem.ToString();

            // Determine the action based on the selected item
            switch (selectedAction)
            {
                case "Close Application":
                    // If the selected action is to close the application
                    if (COPYbackgroundWorker.IsBusy)
                    {
                        // If the copy background worker is busy, cancel it
                        MOVEbackgroundWorker.CancelAsync();
                        MOVEbackgroundWorker.Dispose();
                    }
                    // Exit the application
                    Application.Exit();
                    break;

                case "Log Off User":
                    // Log off the current user
                    DoExitWin(EWX_LOGOFF);
                    break;

                case "Restart CPU":
                    // Restart the CPU
                    DoExitWin(EWX_REBOOT);
                    break;

                case "Sleep":
                    // Put the system into standby mode
                    Application.SetSuspendState(PowerState.Suspend, true, true);
                    break;

                case "Shut Down CPU":
                    // Shut down the CPU
                    DoExitWin(EWX_SHUTDOWN);
                    break;

                default:
                    // Keep application open or other unhandled cases
                    // No action needed
                    break;
            }
        }


        static void CopyFiles(string sourceDirectory, string destinationDirectory, int bufferSize)
        {
            // Get the main form instance
            mainForm fc = (mainForm)Application.OpenForms["mainForm"];

            // Check if the main form instance is not null
            if (fc != null)
            {
                // Check if source directory exists
                if (!Directory.Exists(sourceDirectory))
                {
                    Console.WriteLine("Source directory does not exist.");
                    return; // Exit the method
                }

                // Create destination directory if it doesn't exist
                if (!Directory.Exists(destinationDirectory))
                {
                    Directory.CreateDirectory(destinationDirectory);
                }

                // Check if multithreading is enabled
                bool useMultithreading = fc.multithreadCheckBox.Checked;
                // Loop through each file in the source directory and its subdirectories
                foreach (var sourceFilePath in Directory.EnumerateFiles(sourceDirectory, "*", System.IO.SearchOption.AllDirectories))
                {
                    // Extract the icon associated with the file
                    Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(sourceFilePath);
                    if (icon != null)
                    {
                        // Set the extracted icon as the image of the fileIconPicBox control
                        fc.fileIconPicBox.Image = icon.ToBitmap();
                    }

                    // Get the relative path of the file
                    var relativePath = Path.GetRelativePath(sourceDirectory, sourceFilePath);
                    // Combine the relative path with the destination directory to get the destination file path
                    var destinationFilePath = Path.Combine(destinationDirectory, relativePath);

                    // Get file information for both the source and destination files
                    var sourceFileInfo = new FileInfo(sourceFilePath.ToString());
                    var destFileInfo = new FileInfo(destinationFilePath.ToString());

                    // Skip files with zero length
                    if (sourceFileInfo.Length == 0)
                    {
                        goto SkipZero;
                    }

                    // Check if the operation has been canceled
                    if (fc.canceled)
                    {
                        if (fc.COPYbackgroundWorker.CancellationPending)
                        {
                            fc.canceled = true;
                            fc.COPYbackgroundWorker.CancelAsync();
                            return;
                        }
                    }

                    // Determine if the file should be overwritten
                    bool overwrite = false;
                    if (File.Exists(destFileInfo.FullName))
                    {
                        if (fc.overwriteIfNewerCHKBOX.Checked == true && sourceFileInfo.LastWriteTime > destFileInfo.LastWriteTime)
                        {
                            overwrite = true;
                        }
                        else if (fc.overwriteIfNewerCHKBOX.Checked == true && sourceFileInfo.LastWriteTime < destFileInfo.LastWriteTime)
                        {
                            fc.skipFileExistsOlder = true;
                            goto skipFileExistsOlderNow;
                        }
                        else if (fc.overwriteIfNewerCHKBOX.Checked == true && sourceFileInfo.LastWriteTime == destFileInfo.LastWriteTime)
                        {
                            overwrite = false;
                            fc.skipFileExistsSame = true;
                            goto skipFileExistsSameNow;
                        }
                        else if (fc.overwriteAllCHKBOX.Checked == true)
                        {
                            overwrite = true;
                        }
                        else if (fc.doNotOverwriteCHKBOX.Checked == true)
                        {
                            fc.skipFileExists = true;
                            goto skipFileExistsTrue;
                        }
                    }


                    var destinationDirectoryPath = Path.GetDirectoryName(destinationFilePath); // Get the directory path of the destination file
                    Directory.CreateDirectory(destinationDirectoryPath); // Create the directory if it doesn't exist
                    CopyFile(sourceFilePath, destinationFilePath, overwrite); // Copy the file to the destination path
                    goto continueFile; // Jump to the label 'continueFile'

                skipFileExistsTrue: // Label indicating the action if file exists and should be skipped
                    if (fc.skipFileExists == false)
                    {
                        goto continueFile; // Skip the file and continue processing
                    }
                    // Update progress and status when file is skipped due to existence
                    fc.totalBytesProcessed += sourceFileInfo.Length;
                    fc.totalBytesProcessedFile += sourceFileInfo.Length;
                    fc.progressPercentage = (int)((double)fc.totalBytesProcessed / fc.totalBytes * 100);
                    fc.totalPercentDouble = ((double)fc.totalBytesProcessed / fc.totalBytes * 100);
                    fc.totalBytesProcessedFile = sourceFileInfo.Length;
                    fc.progressPercentageFile = (int)((double)sourceFileInfo.Length / sourceFileInfo.Length * 100);
                    fc.totalPercentDoubleFile = ((double)sourceFileInfo.Length / sourceFileInfo.Length * 100);
                    // Update UI elements
                    fc.fileCountOnLabel.Text = "File Count: " + fc.fileOn.ToString("N0") + "/" + fc.num.ToString("N0") + "";
                    fc.fileCountOnLabel.Refresh();
                    fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                    fc.totalCopiedProgressLabel.Refresh();
                    fc.skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                    fc.skippedDataGridView.Rows.Add("Skipped: File Exists", sourceFileInfo.FullName.ToString(), destinationFilePath, sourceFileInfo.Name.ToString(), ConvertBytesToMegabytes(sourceFileInfo.Length).ToString("00.00 MB"));
                    fc.totalSkippedLabel.Text = "Total Skipped Files: " + fc.skippedDataGridView.Rows.Count + "";
                    fc.fileProcessedLabel.Text = "File Processed: " + FormatBytes(fc.totalBytesProcessedFile) + "/" + FormatBytes(sourceFileInfo.Length);
                    fc.fileProcessedLabel.Refresh();
                    goto continueFile; // Continue processing
                skipFileExistsOlderNow: // Label indicating the action if file exists and is older
                    if (fc.skipFileExistsOlder == false)
                    {
                        goto continueFile; // Skip the file and continue processing
                    }
                    // Update progress and status when file is skipped due to being older
                    fc.totalBytesProcessed += sourceFileInfo.Length;
                    fc.totalBytesProcessedFile += sourceFileInfo.Length;
                    fc.progressPercentage = (int)((double)fc.totalBytesProcessed / fc.totalBytes * 100);
                    fc.totalPercentDouble = ((double)fc.totalBytesProcessed / fc.totalBytes * 100);
                    fc.totalBytesProcessedFile = sourceFileInfo.Length;
                    fc.progressPercentageFile = (int)((double)sourceFileInfo.Length / sourceFileInfo.Length * 100);
                    fc.totalPercentDoubleFile = ((double)sourceFileInfo.Length / sourceFileInfo.Length * 100);
                    // Update UI elements
                    fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                    fc.totalCopiedProgressLabel.Refresh();
                    fc.skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                    fc.skippedDataGridView.Rows.Add("Skipped: Older File", sourceFileInfo.FullName.ToString(), destinationFilePath, sourceFileInfo.Name.ToString(), ConvertBytesToMegabytes(sourceFileInfo.Length).ToString("00.00 MB"));
                    fc.totalSkippedLabel.Text = "Total Skipped Files: " + fc.skippedDataGridView.Rows.Count + "";
                    fc.fileProcessedLabel.Text = "File Processed: " + FormatBytes(fc.totalBytesProcessedFile) + "/" + FormatBytes(sourceFileInfo.Length);
                    fc.fileProcessedLabel.Refresh();
                    goto continueFile; // Continue processing

                skipFileExistsSameNow: // Label indicating the action if file exists and is the same
                    if (fc.skipFileExistsSame == false)
                    {
                        goto continueFile; // Skip the file and continue processing
                    }
                    // Update progress and status when file is skipped due to being the same
                    fc.totalBytesProcessedFile += sourceFileInfo.Length;
                    fc.totalBytesProcessed += sourceFileInfo.Length;
                    fc.progressPercentage = (int)((double)fc.totalBytesProcessed / fc.totalBytes * 100);
                    fc.totalPercentDouble = ((double)fc.totalBytesProcessed / fc.totalBytes * 100);
                    fc.totalBytesProcessedFile = sourceFileInfo.Length;
                    fc.progressPercentageFile = (int)((double)sourceFileInfo.Length / sourceFileInfo.Length * 100);
                    fc.totalPercentDoubleFile = ((double)sourceFileInfo.Length / sourceFileInfo.Length * 100);
                    // Update UI elements
                    fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                    fc.totalCopiedProgressLabel.Refresh();
                    fc.skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                    fc.skippedDataGridView.Rows.Add("Skipped: Same File", sourceFileInfo.FullName.ToString(), destinationFilePath, sourceFileInfo.Name.ToString(), ConvertBytesToMegabytes(sourceFileInfo.Length).ToString("00.00 MB"));
                    fc.totalSkippedLabel.Text = "Total Skipped Files: " + fc.skippedDataGridView.Rows.Count + "";
                    fc.fileProcessedLabel.Text = "File Processed: " + FormatBytes(fc.totalBytesProcessedFile) + "/" + FormatBytes(sourceFileInfo.Length);
                    fc.fileProcessedLabel.Refresh();
                    goto continueFile; // Continue processing

                SkipZero:
                    // Label indicating the action if file size is zero
                    // Update progress and status when zero byte file is encountered


                    // Update UI elements
                    fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                    fc.totalCopiedProgressLabel.Refresh();
                    fc.skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                    fc.skippedDataGridView.Rows.Add("Skipped: Zero Byte File", sourceFileInfo.FullName.ToString(), destinationFilePath, sourceFileInfo.Name.ToString(), ConvertBytesToMegabytes(sourceFileInfo.Length).ToString("00.00 MB"));
                    fc.totalSkippedLabel.Text = "Total Skipped Files: " + fc.skippedDataGridView.Rows.Count + "";

                    // Update progress bar and labels for file processing
                    double totalValueFile22 = Math.Round(fc.totalPercentDoubleFile, 3);
                    fc.fileTotalProgressLabel.Text = totalValueFile22.ToString("00.00") + "%";
                    fc.fileProgressBar.Value = fc.progressPercentageFile;
                    fc.fileProgressBar.Refresh();
                    fc.fileProcessedLabel.Text = "File Processed: " + FormatBytes(fc.totalBytesProcessedFile) + "/" + FormatBytes(sourceFileInfo.Length);
                    fc.fileProcessedLabel.Refresh();

                    // Select the last row in the DataGridView
                    if (fc.fileDirDataGridView.Rows.Count > 0)
                    {
                        int lastIndex = fc.fileDirDataGridView.Rows.Count - 1;
                        fc.fileDirDataGridView.Rows[lastIndex].Selected = true;
                    }

                    // Update progress bar and labels for overall progress
                    double totalValue22 = Math.Round(fc.totalPercentDouble, 3);
                    fc.totalProgressLabel.Text = totalValue22.ToString("00.00") + "%";
                    fc.totalProgressBar.Value = fc.progressPercentage;
                    fc.totalProgressBar.Refresh();
                    goto continueFile; // Continue processing

                continueFile: // Label indicating continuation of file processing
                              // Select the last row in the DataGridView
                    if (fc.fileDirDataGridView.Rows.Count > 0)
                    {
                        int lastIndex = fc.fileDirDataGridView.Rows.Count - 1;
                        fc.fileDirDataGridView.Rows[lastIndex].Selected = true;
                    }

                //// Update progress bar and labels for overall progress
                //double totalValue = Math.Round(fc.totalPercentDouble, 3);
                //if (totalValue >= 100)
                //{
                //    fc.progressPercentage = 100;
                //    totalValue = 100;
                //    fc.totalProgressLabel.Text = totalValue.ToString("00.00") + "%";
                //    fc.totalProgressBar.Value = fc.progressPercentage;
                //    fc.totalProgressBar.Refresh();
                //}
                //else
                //{
                //    fc.totalProgressLabel.Text = totalValue.ToString("00.00") + "%";
                //    fc.totalProgressBar.Value = fc.progressPercentage;
                //    fc.totalProgressBar.Refresh();
                //}


                //double totalValueFile = Math.Round(fc.totalPercentDoubleFile, 3);
                //fc.fileTotalProgressLabel.Text = totalValueFile.ToString("00.00") + "%";
                //fc.fileProgressBar.Value = fc.progressPercentageFile;
                //fc.fileProgressBar.Refresh();


                //fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                //fc.totalCopiedProgressLabel.Refresh();

                //fc.fileProcessedLabel.Text = "File Processed: " + FormatBytes(fc.totalBytesProcessedFile) + "/" + FormatBytes(sourceFileInfo.Length);
                //fc.fileProcessedLabel.Refresh();


                //fc.totalBytesProcessedFile = 0;
                //fc.fileProgressBar.Value = 0;
                //fc.fileProgressBar.Refresh();

                //fc.fileTotalProgressLabel.Text = "0%";
                //fc.fileTotalProgressLabel.Refresh();
                fileDone:; // Label indicating the end of the file processing
                }

                // Extracting directory names from source and destination paths
                string dirName = new DirectoryInfo(sourceDirectory).Name;
                string dirName2 = new DirectoryInfo(destinationDirectory).Name;

                // Checking if verification is enabled
                if (fc.verifyCheckBox.Checked == true)
                {
                    // Verifying the copy operation
                    if (VerifyCopy(sourceDirectory, destinationDirectory))
                    {
                        // Verification passed
                        fc.verificationPassed = true;
                    }
                    else
                    {
                        // Verification failed
                        MessageBox.Show("Verification of (" + dirName + ") & (" + dirName2 + ") failed!", "Verification Failed!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // Logging verification failure to a log file
                        string logFilePath = @"\CopyThatLog.txt";
                        logFilePath = Application.StartupPath + logFilePath;

                        if (fc.logFileCheckBox.Checked)
                        {
                            // Writing failure details to the log file
                            using (StreamWriter logWriter = new StreamWriter(logFilePath, true))
                            {
                                logWriter.WriteLine($"Failed verification of files in the following:");
                                logWriter.WriteLine($"Source Dir: {dirName}");
                                logWriter.WriteLine($"Destination Dir: {dirName2}");
                                logWriter.WriteLine();
                            }
                        }
                        fc.verificationPassed = false;
                    }
                }
            }
        }

        // Method to calculate speed based on file size and elapsed time
        static double CalculateSpeed(string filePath, TimeSpan elapsedTime)
        {
            // Getting file information
            FileInfo fileInfo = new FileInfo(filePath);

            // Calculating file size in megabytes
            double fileSizeInMegabytes = fileInfo.Length / (1024.0 * 1024.0);

            // Calculating speed in megabytes per second
            double megabytesPerSecond = fileSizeInMegabytes / elapsedTime.TotalSeconds;

            return megabytesPerSecond;
        }

        // Method to update progress and display speed
        private void UpdateProgress()
        {
            // Calculating elapsed seconds using the SpeedStopWatch
            double elapsedSeconds = SpeedStopWatch.Elapsed.TotalSeconds;

            // Calculating speed in megabytes per second
            double speedMbps = totalBytesProcessedFile / (elapsedSeconds * 1024 * 1024);

            // Checking if operation is canceled
            if (canceled == true)
            {
                return;
            }

            // Update UI in the main thread
            Invoke(new Action(() =>
            {
                // Updating speed label with formatted speed value
                speedLabel.Text = $"Speed: {speedMbps:F2} MB/s";
            }));
        }

        static void CopyFile(string sourceFilePath, string destinationFilePath, bool overwrite)
        {
            // Retrieving reference to the main form
            mainForm fc = (mainForm)Application.OpenForms["mainForm"];
            if (fc != null)
            {
                // Variables to store drive space information
                long driveSpaceTotal;
                long driveSpaceAvailable;
                long driveSpaceUsed;
                long availableSpaceCopyMove;

                // Creating FileInfo object for the destination file
                FileInfo f = new FileInfo(destinationFilePath);

                // Getting the root drive from the destination file path
                string drive = Path.GetPathRoot(f.FullName);
                //string drive = @"C:\";

                // Checking if the source file exists
                if (!File.Exists(sourceFilePath))
                {
                    // Throw an exception if source file not found
                    throw new FileNotFoundException("Source file not found.", sourceFilePath);
                }

                // Restarting the stopwatch for speed calculation
                fc.SpeedStopWatch.Restart();

                try
                {
                    // Incrementing file count and updating UI
                    fc.fileOn++;
                    //fc.filePathLabel.Text = sourceFilePath;
                   // fc.filePathLabel.Refresh();
                    fc.fileCountOnLabel.Text = "File Count: " + fc.fileOn.ToString("N0") + "/" + fc.num.ToString("N0") + "";
                    fc.fileCountOnLabel.Refresh();

                    // Opening source file for reading
                    using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        // Opening destination file for writing
                        using (FileStream destinationStream = new FileStream(destinationFilePath, overwrite ? FileMode.Create : FileMode.CreateNew, FileAccess.Write))
                        {
                            // Getting FileInfo objects for source and destination files
                            var sourceFileInfo = new FileInfo(sourceFilePath);
                            var destFileInfo = new FileInfo(destinationFilePath);
                            string fileName = Path.GetFileName(sourceFileInfo.FullName);
                            string fileExtension = Path.GetExtension(destFileInfo.FullName);



                            // Retrieving excluded and allowed extensions from ListBox items
                            List<string> excludedExtensions = fc.GetListBoxItems(fc.excludedExtListBox);
                            List<string> allowedExtensions = fc.GetListBoxItems(fc.allowedExtListBox);

                            // Checking if the file extension is allowed and not excluded
                            if ((allowedExtensions.Contains(fileExtension, StringComparer.OrdinalIgnoreCase) || !excludedExtensions.Contains(fileExtension, StringComparer.OrdinalIgnoreCase))
                                && !IsExtensionInOppositeList(fileExtension, excludedExtensions, allowedExtensions))
                            {
                                try
                                {

                                    // Setting source file path
                                    fc.SOURCEFILEPLEASE = sourceFilePath;

                                    // Getting original timestamp of the source file
                                    DateTime originalTimestamp = File.GetLastWriteTime(sourceFilePath);

                                    // Extracting associated icon for the file
                                    Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(sourceFilePath);
                                    if (icon != null)
                                    {
                                        fc.fileIconPicBox.Image = icon.ToBitmap();
                                    }

                                    // Setting current file path
                                    fc.fileNow = sourceFilePath.ToString();

                                    // Setting total file bytes
                                    fc.totalFileBytes = sourceFileInfo.Length;

                                    // Getting DriveInfo object for the drive
                                    DriveInfo driveInfo = new DriveInfo(Path.GetPathRoot(drive));

                                    // Checking if the drive is ready
                                    if (driveInfo.IsReady)
                                    {
                                        // Getting drive space information
                                        long totalDriveSpace = driveInfo.TotalSize;
                                        long freeDriveSpace = driveInfo.TotalFreeSpace;

                                        // Calculating available space for copy/move
                                        driveSpaceTotal = driveInfo.TotalSize;
                                        driveSpaceAvailable = driveInfo.TotalFreeSpace;
                                        availableSpaceCopyMove = totalDriveSpace - freeDriveSpace;

                                        // Checking if available space is enough for copy operation
                                        if (fc.totalBytes >= availableSpaceCopyMove)
                                        {
                                            MessageBox.Show("There is not enough drive space left to perform the copy operation!", "Copy That - File/Directory Tool - Error!",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                    }
                                    double filesSize = sourceFileInfo.Length;

                                    // Converting buffer size from MB to bytes
                                    int count = (Convert.ToInt32(fc.bufferNumUpDown.Value) * 1024);

                                    long buff = count;

                                    if (sourceFileInfo.Length < count)
                                    {
                                        buff = sourceFileInfo.Length;
                                        filesSize = buff;

                                    }
                                    var buffer = new byte[buff];
                                    int bytesRead = 0;
                                    fc.totalBytesProcessedFile = 0;
                                    fc.filePathLabel.Text = sourceFileInfo.FullName;
                                    fc.filePathLabel.Refresh();

                                    int underValue = (Convert.ToInt32(fc.setMBGBUnderNumUD.Value) * 1024);
                                    if (fc.underMBCheckBox.Checked)
                                    {
                                        if (filesSize < underValue)
                                        {
                                            goto skippedUnder;
                                        }
                                    }

                                    int overValue = (Convert.ToInt32(fc.setMBGBOverNumUD.Value) * 1024);
                                    if (fc.overMBCheckBox.Checked)
                                    {
                                        if (filesSize > overValue)
                                        {
                                            goto skippedOver;
                                        }
                                    }

                                    // Checking if source file size is 0
                                    if (sourceFileInfo.Length == 0)
                                    {
                                        goto SkipZero;
                                    }

                                    // Read from the source file and write to the destination file
                                    while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        if (fc.skipFileUser)
                                        {
                                            goto skipThisFile;
                                        }

                                        destinationStream.Write(buffer, 0, bytesRead);

                                        if (fc.canceled)
                                        {
                                            if (fc.COPYbackgroundWorker.CancellationPending)
                                            {
                                                fc.canceled = true;
                                                fc.COPYbackgroundWorker.CancelAsync();
                                                return;
                                            }
                                        }
                                        while (fc.paused == true)
                                        {
                                            if (fc.canceled)
                                            {
                                                if (fc.COPYbackgroundWorker.CancellationPending)
                                                {
                                                    fc.canceled = true;
                                                    fc.COPYbackgroundWorker.CancelAsync();
                                                    return;
                                                }
                                            }
                                        }
                                        destinationStream.Write(buffer, 0, bytesRead);

                                        // Calculate the progress percentage
                                        fc.totalBytesProcessed += bytesRead;
                                        fc.totalBytesProcessedFile += bytesRead;

                                        if (fc.totalBytesProcessed > fc.totalBytes)
                                        {
                                            MessageBox.Show("SSSSSSSSHIIIITTTT!!!");
                                            break;
                                        }


                                        if (driveInfo.IsReady)
                                        {
                                            long totalDriveSpace = driveInfo.TotalSize;
                                            long freeDriveSpace = driveInfo.TotalFreeSpace;

                                            driveSpaceTotal = driveInfo.TotalSize;
                                            driveSpaceAvailable = driveInfo.TotalFreeSpace;
                                            availableSpaceCopyMove = totalDriveSpace - freeDriveSpace;

                                            fc.totalHDSpaceLeftLabel.Text = "Total Space: " + FormatBytes(availableSpaceCopyMove) + "/" + FormatBytes(driveSpaceTotal) + "";
                                        }
                                        fc.progressPercentage = (int)((double)fc.totalBytesProcessed / fc.totalBytes * 100);
                                        fc.totalPercentDouble = ((double)fc.totalBytesProcessed / fc.totalBytes * 100);
                                        fc.progressPercentageFile = (int)((double)fc.totalBytesProcessedFile / sourceFileInfo.Length * 100);
                                        fc.totalPercentDoubleFile = ((double)fc.totalBytesProcessedFile / sourceFileInfo.Length * 100);
                                        // Calculate total progress percentage and update UI accordingly
                                        double totalValue = Math.Round(fc.totalPercentDouble, 3);
                                        if (totalValue >= 100)
                                        {
                                            fc.progressPercentage = 100;
                                            totalValue = 100;
                                            fc.totalProgressLabel.Text = totalValue.ToString("00.00") + "%";
                                            fc.totalProgressBar.Value = fc.progressPercentage;
                                            fc.totalProgressBar.Refresh();
                                        }
                                        else
                                        {
                                            fc.totalProgressLabel.Text = totalValue.ToString("00.00") + "%";
                                            fc.totalProgressBar.Value = fc.progressPercentage;
                                            fc.totalProgressBar.Refresh();
                                        }
                                        fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                                        fc.totalCopiedProgressLabel.Refresh();
                                        fc.fileProcessedLabel.Text = "File Processed: " + FormatBytes(fc.totalBytesProcessedFile) + "/" + FormatBytes(sourceFileInfo.Length);
                                        fc.fileProcessedLabel.Refresh();
                                        // Round the total percentage of the file processed to 3 decimal places
                                        double totalValueFile2 = Math.Round(fc.totalPercentDoubleFile, 3);
                                        // Set the text of the file total progress label to the rounded percentage followed by a percentage sign
                                        fc.fileTotalProgressLabel.Text = totalValueFile2.ToString("00.00") + "%";
                                        // Refresh the file total progress label to update its display
                                        fc.fileTotalProgressLabel.Refresh();
                                        // Set the value of the file progress bar to the progress percentage of the file processed
                                        fc.fileProgressBar.Value = fc.progressPercentageFile;
                                        // Refresh the file progress bar to update its display
                                        fc.fileProgressBar.Refresh();
                                        // Get the size of the source file in bytes
                                        long fileSizeBytes = new FileInfo(sourceFilePath).Length;


                                        // Update the progress in the UI
                                        fc.UpdateProgress();
                                    }
                                    // Stop and reset the stopwatch used for speed calculation
                                    fc.SpeedStopWatch.Stop();
                                    fc.SpeedStopWatch.Reset();
                                    // Jump to the label indicating to continue processing the next file
                                    goto continueFile;
                                // Labeling a section of code for handling the case where the file size is zero

                                SkipZero:
                                    // Update total processed bytes and UI elements to reflect the skipped zero-byte file
                                    // fc.totalBytesProcessed += sourceFileInfo.Length;
                                    fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                                    fc.totalCopiedProgressLabel.Refresh();
                                    fc.skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                                    fc.skippedDataGridView.Rows.Add("Skipped: Zero Byte File", sourceFileInfo.FullName.ToString(), destinationFilePath, sourceFileInfo.Name.ToString(), ConvertBytesToMegabytes(sourceFileInfo.Length).ToString("00.00 MB"));
                                    fc.totalSkippedLabel.Text = "Total Skipped Files: " + fc.skippedDataGridView.Rows.Count + "";

                                    // Update file progress UI elements
                                    double totalValueFile22 = Math.Round(fc.totalPercentDoubleFile, 3);
                                    fc.fileTotalProgressLabel.Text = totalValueFile22.ToString("00.00") + "%";
                                    fc.fileProgressBar.Value = fc.progressPercentageFile;
                                    fc.fileProgressBar.Refresh();
                                    fc.fileProcessedLabel.Text = "File Processed: " + FormatBytes(fc.totalBytesProcessedFile) + "/" + FormatBytes(sourceFileInfo.Length);
                                    fc.fileProcessedLabel.Refresh();
                                    goto continueFile;
                                skippedUnder:
                                    // Increment total processed bytes for both overall and current file
                                    fc.totalBytesProcessedFile += sourceFileInfo.Length;
                                    fc.totalBytesProcessed += sourceFileInfo.Length;

                                    // Calculate progress percentage for overall process
                                    fc.progressPercentage = (int)((double)fc.totalBytesProcessed / fc.totalBytes * 100);
                                    fc.totalPercentDouble = ((double)fc.totalBytesProcessed / fc.totalBytes * 100);

                                    // Update total processed bytes for current file
                                    fc.totalBytesProcessedFile = sourceFileInfo.Length;

                                    // Calculate progress percentage for current file
                                    fc.progressPercentageFile = (int)((double)sourceFileInfo.Length / sourceFileInfo.Length * 100);
                                    fc.totalPercentDoubleFile = ((double)sourceFileInfo.Length / sourceFileInfo.Length * 100);

                                    // Update UI labels and controls
                                    fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                                    fc.totalCopiedProgressLabel.Refresh();
                                    fc.skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                                    fc.skippedDataGridView.Rows.Add("Skipped: Under MB", sourceFileInfo.FullName.ToString(), fc.targetDirLabel.Text, sourceFileInfo.Name.ToString(), ConvertBytesToMegabytes(sourceFileInfo.Length).ToString("00.00 MB"));
                                    fc.totalSkippedLabel.Text = "Total Skipped Files: " + fc.skippedDataGridView.Rows.Count + "";
                                    fc.fileProcessedLabel.Text = "File Processed: " + FormatBytes(fc.totalBytesProcessedFile) + "/" + bytesToString(sourceFileInfo.Length);
                                    fc.fileProcessedLabel.Refresh();
                                    fc.skipFileUser = false;

                                    // Jump to continue processing the next file
                                    goto continueFile;
                                skippedOver:
                                    // Increment total processed bytes for both overall and current file
                                    fc.totalBytesProcessedFile += sourceFileInfo.Length;
                                    fc.totalBytesProcessed += sourceFileInfo.Length;

                                    // Calculate progress percentage for overall process
                                    fc.progressPercentage = (int)((double)fc.totalBytesProcessed / fc.totalBytes * 100);
                                    fc.totalPercentDouble = ((double)fc.totalBytesProcessed / fc.totalBytes * 100);

                                    // Update total processed bytes for current file
                                    fc.totalBytesProcessedFile = sourceFileInfo.Length;

                                    // Calculate progress percentage for current file
                                    fc.progressPercentageFile = (int)((double)sourceFileInfo.Length / sourceFileInfo.Length * 100);
                                    fc.totalPercentDoubleFile = ((double)sourceFileInfo.Length / sourceFileInfo.Length * 100);

                                    // Update UI labels and controls
                                    fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                                    fc.totalCopiedProgressLabel.Refresh();
                                    fc.skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                                    fc.skippedDataGridView.Rows.Add("Skipped: Over MB", sourceFileInfo.FullName.ToString(), fc.targetDirLabel.Text, sourceFileInfo.Name.ToString(), ConvertBytesToMegabytes(sourceFileInfo.Length).ToString("00.00 MB"));
                                    fc.totalSkippedLabel.Text = "Total Skipped Files: " + fc.skippedDataGridView.Rows.Count + "";
                                    fc.fileProcessedLabel.Text = "File Processed: " + FormatBytes(fc.totalBytesProcessedFile) + "/" + bytesToString(sourceFileInfo.Length);
                                    fc.fileProcessedLabel.Refresh();
                                    fc.skipFileUser = false;

                                    // Jump to continue processing the next file
                                    goto continueFile;
                                skipThisFile:
                                    // If the user chooses not to skip the file, proceed to continue processing the next file
                                    if (fc.skipFileUser == false)
                                    {
                                        goto continueFile;
                                    }
                                    // Increment total processed bytes for both overall and current file
                                    fc.totalBytesProcessedFile += sourceFileInfo.Length;
                                    fc.totalBytesProcessed += sourceFileInfo.Length;

                                    // Calculate progress percentage for overall process
                                    fc.progressPercentage = (int)((double)fc.totalBytesProcessed / fc.totalBytes * 100);
                                    fc.totalPercentDouble = ((double)fc.totalBytesProcessed / fc.totalBytes * 100);

                                    // Update total processed bytes for current file
                                    fc.totalBytesProcessedFile = sourceFileInfo.Length;

                                    // Calculate progress percentage for current file
                                    fc.progressPercentageFile = (int)((double)sourceFileInfo.Length / sourceFileInfo.Length * 100);
                                    fc.totalPercentDoubleFile = ((double)sourceFileInfo.Length / sourceFileInfo.Length * 100);

                                    // Update UI labels and controls
                                    fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                                    fc.totalCopiedProgressLabel.Refresh();
                                    fc.skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                                    fc.skippedDataGridView.Rows.Add("Skipped: User", sourceFileInfo.FullName.ToString(), fc.targetDirLabel.Text, sourceFileInfo.Name.ToString(), ConvertBytesToMegabytes(sourceFileInfo.Length).ToString("00.00 MB"));
                                    fc.totalSkippedLabel.Text = "Total Skipped Files: " + fc.skippedDataGridView.Rows.Count + "";
                                    fc.fileProcessedLabel.Text = "File Processed: " + FormatBytes(fc.totalBytesProcessedFile) + "/" + bytesToString(sourceFileInfo.Length);
                                    fc.fileProcessedLabel.Refresh();
                                    fc.skipFileUser = false;

                                    // Jump to continue processing the next file
                                    goto continueFile;

                                continueFile:
                                    // After processing a file, continue to the next file
                                    // If there are more files to process, select the last row in the file directory grid view
                                    if (fc.fileDirDataGridView.Rows.Count > 0)
                                    {
                                        int lastIndex = fc.fileDirDataGridView.Rows.Count - 1;
                                        fc.fileDirDataGridView.Rows[lastIndex].Selected = true;
                                    }



                                    // Update drive space information in UI
                                    if (driveInfo.IsReady)
                                    {
                                        long totalDriveSpace = driveInfo.TotalSize;
                                        long freeDriveSpace = driveInfo.TotalFreeSpace;
                                        driveSpaceTotal = driveInfo.TotalSize;
                                        driveSpaceAvailable = driveInfo.TotalFreeSpace;
                                        availableSpaceCopyMove = totalDriveSpace - freeDriveSpace;
                                        fc.totalHDSpaceLeftLabel.Text = "Total Space: " + FormatBytes(availableSpaceCopyMove) + "/" + FormatBytes(totalDriveSpace) + "";
                                    }

                                    // Restore original file timestamp and dispose file streams
                                    File.SetLastWriteTime(destinationFilePath, originalTimestamp);
                                    sourceStream.Dispose();
                                    destinationStream.Dispose();
                                }
                                // If an UnauthorizedAccessException occurs (e.g., lack of permissions), handle it
                                catch (UnauthorizedAccessException)
                                {
                                    // Check if the user wants to play a sound on error
                                    if (fc.onErrorCheckBox.Checked)
                                    {
                                        System.IO.Stream str = Properties.Resources.OnError;
                                        System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                                        snd.Play();
                                    }

                                    // Check if the user wants to restart the application on error
                                    if (fc.restartCheckBox.Checked == true)
                                    {
                                        Application.Restart();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        fc.exitPlease();
                                    }

                                    // Update total processed bytes and UI elements to reflect the skipped file due to unauthorized access
                                    fc.totalBytesProcessed += sourceFileInfo.Length;
                                    fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                                    fc.totalCopiedProgressLabel.Refresh();
                                    fc.skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                                    fc.skippedDataGridView.Rows.Add("Skipped: Unauth. Access", sourceFileInfo.FullName.ToString(), destinationFilePath, sourceFileInfo.Name.ToString(), ConvertBytesToMegabytes(sourceFileInfo.Length).ToString("00.00 MB"));
                                    fc.totalSkippedLabel.Text = "Total Skipped Files: " + fc.skippedDataGridView.Rows.Count + "";
                                    double totalValueFile = Math.Round(fc.totalPercentDoubleFile, 3);
                                    fc.fileTotalProgressLabel.Text = totalValueFile.ToString("00.00") + "%";
                                    fc.fileProgressBar.Value = fc.progressPercentageFile;
                                    fc.fileProgressBar.Refresh();
                                    fc.fileProcessedLabel.Text = "File Processed: " + FormatBytes(fc.totalBytesProcessedFile) + "/" + FormatBytes(sourceFileInfo.Length);
                                    fc.fileProcessedLabel.Refresh();

                                    // If there are more files, select the last row in the file directory grid view
                                    if (fc.fileDirDataGridView.Rows.Count > 0)
                                    {
                                        int lastIndex = fc.fileDirDataGridView.Rows.Count - 1;
                                        fc.fileDirDataGridView.Rows[lastIndex].Selected = true;
                                    }

                                    // Update total progress percentage and UI elements
                                    double totalValue = Math.Round(fc.totalPercentDouble, 3);
                                    fc.totalProgressLabel.Text = totalValue.ToString("00.00") + "%";
                                    fc.totalProgressBar.Value = fc.progressPercentage;
                                    fc.totalProgressBar.Refresh();
                                }
                                // If an IOException occurs (e.g., file in use), handle it
                                catch (IOException)
                                {
                                    // Check if the user wants to play a sound on error
                                    if (fc.onErrorCheckBox.Checked)
                                    {
                                        System.IO.Stream str = Properties.Resources.OnError;
                                        System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                                        snd.Play();
                                    }

                                    // Check if the user wants to restart the application on error
                                    if (fc.restartCheckBox.Checked == true)
                                    {
                                        Application.Restart();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        fc.exitPlease();
                                    }

                                    // Update total processed bytes and UI elements to reflect the skipped file due to IOException
                                    fc.totalBytesProcessed += sourceFileInfo.Length;
                                    fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                                    fc.totalCopiedProgressLabel.Refresh();
                                    fc.skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                                    fc.skippedDataGridView.Rows.Add("Skipped: IOException", sourceFileInfo.FullName.ToString(), destinationFilePath, sourceFileInfo.Name.ToString(), ConvertBytesToMegabytes(sourceFileInfo.Length).ToString("00.00 MB"));
                                    fc.totalSkippedLabel.Text = "Total Skipped Files: " + fc.skippedDataGridView.Rows.Count + "";

                                    double totalValueFile = Math.Round(fc.totalPercentDoubleFile, 3);
                                    fc.fileTotalProgressLabel.Text = totalValueFile.ToString("00.00") + "%";
                                    fc.fileProgressBar.Value = fc.progressPercentageFile;
                                    fc.fileProgressBar.Refresh();
                                    fc.fileProcessedLabel.Text = "File Processed: " + FormatBytes(fc.totalBytesProcessedFile) + "/" + FormatBytes(sourceFileInfo.Length);
                                    fc.fileProcessedLabel.Refresh();

                                    // If there are more files, select the last row in the file directory grid view
                                    if (fc.fileDirDataGridView.Rows.Count > 0)
                                    {
                                        int lastIndex = fc.fileDirDataGridView.Rows.Count - 1;
                                        fc.fileDirDataGridView.Rows[lastIndex].Selected = true;
                                    }

                                    // Update total progress percentage and UI elements
                                    double totalValue = Math.Round(fc.totalPercentDouble, 3);
                                    fc.totalProgressLabel.Text = totalValue.ToString("00.00") + "%";
                                    fc.totalProgressBar.Value = fc.progressPercentage;
                                    fc.totalProgressBar.Refresh();
                                    fc.fileOn += 1;
                                }
                                finally
                                {
                                    // Perform cleanup and update drive space information after handling the exception
                                    DriveInfo driveInfo = new DriveInfo(Path.GetPathRoot(drive));
                                    if (driveInfo.IsReady)
                                    {
                                        long totalDriveSpace = driveInfo.TotalSize;
                                        long freeDriveSpace = driveInfo.TotalFreeSpace;
                                        driveSpaceTotal = driveInfo.TotalSize;
                                        driveSpaceAvailable = driveInfo.TotalFreeSpace;
                                        availableSpaceCopyMove = totalDriveSpace - freeDriveSpace;

                                        fc.totalHDSpaceLeftLabel.Text = "Total Space: " + FormatBytes(availableSpaceCopyMove) + "/" + FormatBytes(totalDriveSpace) + "";
                                    }
                                }
                            }

                            // Update total progress UI elements
                            double totalValue22 = Math.Round(fc.totalPercentDouble, 3);
                            fc.totalProgressLabel.Text = totalValue22.ToString("00.00") + "%";
                            fc.totalProgressBar.Value = fc.progressPercentage;
                            fc.totalProgressBar.Refresh();

                            // MessageBox.Show("Total Space: " + FormatBytes(driveSpaceUsed) + "/" + FormatBytes(driveSpaceAvailable) + "");
                            // This line of code seems to be commented out, it's not active in the current context

                            // Update total copied progress UI elements again
                            fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                            fc.totalCopiedProgressLabel.Refresh();

                            // Reset some UI elements and variables related to file processing
                            fc.totalBytesProcessedFile = 0;
                            fc.fileProgressBar.Value = 0;
                            fc.fileProgressBar.Refresh();
                            fc.fileTotalProgressLabel.Text = "0%";
                            fc.fileTotalProgressLabel.Refresh();
                        }
                    }
                }
                // Exception handling block for UnauthorizedAccessException
                catch (UnauthorizedAccessException)
                {
                    // Check if the error sound checkbox is checked
                    if (fc.onErrorCheckBox.Checked)
                    {
                        // Play error sound
                        System.IO.Stream str = Properties.Resources.OnError;
                        System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                        snd.Play();
                    }

                    // Restart the application if the restart checkbox is checked
                    if (fc.restartCheckBox.Checked == true)
                    {
                        Application.Restart();
                        Environment.Exit(0);
                    }
                    else
                    {
                        // Exit the application gracefully
                        fc.exitPlease();
                    }

                    // Update total processed bytes and UI elements to reflect the unauthorized access exception
                    var fileInfoNow3 = new FileInfo(sourceFilePath);
                    fc.totalBytesProcessed += fileInfoNow3.Length;
                    fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                    fc.totalCopiedProgressLabel.Refresh();
                    fc.skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                    fc.skippedDataGridView.Rows.Add("Skipped: Unauth. Access", fileInfoNow3.FullName.ToString(), destinationFilePath, fileInfoNow3.Name.ToString(), ConvertBytesToMegabytes(fileInfoNow3.Length).ToString("00.00 MB"));
                    fc.totalSkippedLabel.Text = "Total Skipped Files: " + fc.skippedDataGridView.Rows.Count + "";

                    // Update file progress UI elements
                    double totalValueFile = Math.Round(fc.totalPercentDoubleFile, 3);
                    fc.fileTotalProgressLabel.Text = totalValueFile.ToString("00.00") + "%";
                    fc.fileProgressBar.Value = fc.progressPercentageFile;
                    fc.fileProgressBar.Refresh();
                    fc.fileProcessedLabel.Text = "File Processed: " + FormatBytes(fc.totalBytesProcessedFile) + "/" + FormatBytes(fileInfoNow3.Length);
                    fc.fileProcessedLabel.Refresh();

                    // Select the last row in the file directory grid view if available
                    if (fc.fileDirDataGridView.Rows.Count > 0)
                    {
                        int lastIndex = fc.fileDirDataGridView.Rows.Count - 1;
                        fc.fileDirDataGridView.Rows[lastIndex].Selected = true;
                    }

                    // Update total progress UI elements
                    double totalValue = Math.Round(fc.totalPercentDouble, 3);
                    fc.totalProgressLabel.Text = totalValue.ToString("00.00") + "%";
                    fc.totalProgressBar.Value = fc.progressPercentage;
                    fc.totalProgressBar.Refresh();
                }
                // Exception handling block for IOException
                catch (IOException)
                {
                    // Check if the error sound checkbox is checked
                    if (fc.onErrorCheckBox.Checked)
                    {
                        // Play error sound
                        System.IO.Stream str = Properties.Resources.OnError;
                        System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                        snd.Play();
                    }

                    // Restart the application if the restart checkbox is checked
                    if (fc.restartCheckBox.Checked == true)
                    {
                        Application.Restart();
                        Environment.Exit(0);
                    }
                    else
                    {
                        // Exit the application gracefully
                        fc.exitPlease();
                    }

                    // Update total processed bytes and UI elements to reflect the I/O exception
                    var fileInfoNow4 = new FileInfo(sourceFilePath);
                    fc.totalBytesProcessed += fileInfoNow4.Length;
                    fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                    fc.totalCopiedProgressLabel.Refresh();
                    fc.skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                    fc.skippedDataGridView.Rows.Add("Skipped: IOException", fileInfoNow4.FullName.ToString(), destinationFilePath, fileInfoNow4.Name.ToString(), ConvertBytesToMegabytes(fileInfoNow4.Length).ToString("00.00 MB"));
                    fc.totalSkippedLabel.Text = "Total Skipped Files: " + fc.skippedDataGridView.Rows.Count + "";

                    // Update file progress UI elements
                    double totalValueFile = Math.Round(fc.totalPercentDoubleFile, 3);
                    fc.fileTotalProgressLabel.Text = totalValueFile.ToString("00.00") + "%";
                    fc.fileProgressBar.Value = fc.progressPercentageFile;
                    fc.fileProgressBar.Refresh();
                    fc.fileProcessedLabel.Text = "File Processed: " + FormatBytes(fc.totalBytesProcessedFile) + "/" + FormatBytes(fileInfoNow4.Length);
                    fc.fileProcessedLabel.Refresh();

                    // Select the last row in the file directory grid view if available
                    if (fc.fileDirDataGridView.Rows.Count > 0)
                    {
                        int lastIndex = fc.fileDirDataGridView.Rows.Count - 1;
                        fc.fileDirDataGridView.Rows[lastIndex].Selected = true;
                    }

                    // Update total progress UI elements
                    double totalValue = Math.Round(fc.totalPercentDouble, 3);
                    fc.totalProgressLabel.Text = totalValue.ToString("00.00") + "%";
                    fc.totalProgressBar.Value = fc.progressPercentage;
                    fc.totalProgressBar.Refresh();
                    fc.fileOn += 1;
                }
            }
        }



        #region InputBox return result

        /// <summary>
        /// Class used to store the result of an InputBox.Show message.
        /// </summary>
        public class InputBoxResult
        {
            public DialogResult ReturnCode;
            public string Text;
        }

        #endregion

        /// <summary>
        /// Summary description for InputBox.
        /// </summary>
        public class InputBox
        {

            #region Private Windows Contols and Constructor

            // Create a new instance of the form.
            private static Form frmInputDialog;
            private static Label lblPrompt;
            private static Button btnOK;
            private static Button btnCancel;
            private static TextBox txtInput;
            public InputBox()
            {
            }


            #endregion


            #region Private Variables


            private static string _formCaption = string.Empty;
            private static string _formPrompt = string.Empty;
            private static InputBoxResult _outputResponse = new InputBoxResult();
            private static string _defaultValue = string.Empty;
            private static int _xPos = -1;
            private static int _yPos = -1;

            #endregion

            #region Windows Form code  
            private static void InitializeComponent()
            {
                frmInputDialog = new Form();
                lblPrompt = new System.Windows.Forms.Label();
                btnOK = new Button();
                btnCancel = new Button();
                txtInput = new TextBox();
                frmInputDialog.SuspendLayout();
                frmInputDialog.TopMost = true;
                // 
                // lblPrompt
                // 
                lblPrompt.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
                lblPrompt.BackColor = SystemColors.Control;
                lblPrompt.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((Byte)(0)));
                lblPrompt.Location = new Point(12, 9);
                lblPrompt.Name = "lblPrompt";
                lblPrompt.Size = new Size(302, 82);
                lblPrompt.TabIndex = 3;
                // 
                // btnOK
                // 
                btnOK.DialogResult = DialogResult.OK;
                btnOK.FlatStyle = FlatStyle.Popup;
                btnOK.Location = new Point(326, 8);
                btnOK.Name = "btnOK";
                btnOK.Size = new Size(64, 24);
                btnOK.TabIndex = 1;
                btnOK.Text = "&OK";
                btnOK.Click += new EventHandler(btnOK_Click);
                // 
                // btnCancel
                // 
                btnCancel.DialogResult = DialogResult.Cancel;
                btnCancel.FlatStyle = FlatStyle.Popup;
                btnCancel.Location = new Point(326, 40);
                btnCancel.Name = "btnCancel";
                btnCancel.Size = new Size(64, 24);
                btnCancel.TabIndex = 2;
                btnCancel.Text = "&Cancel";
                btnCancel.Click += new EventHandler(btnCancel_Click);
                // 
                // txtInput
                // 
                txtInput.Location = new Point(8, 100);
                txtInput.Name = "txtInput";
                txtInput.Size = new Size(379, 20);
                txtInput.TabIndex = 0;
                txtInput.Text = "";
                // 
                // InputBoxDialog
                // 
                frmInputDialog.AutoScaleBaseSize = new Size(5, 13);
                frmInputDialog.ClientSize = new Size(398, 128);
                frmInputDialog.Controls.Add(txtInput);
                frmInputDialog.Controls.Add(btnCancel);
                frmInputDialog.Controls.Add(btnOK);
                frmInputDialog.Controls.Add(lblPrompt);
                frmInputDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmInputDialog.MaximizeBox = false;
                frmInputDialog.MinimizeBox = false;
                frmInputDialog.Name = "InputBoxDialog";
                frmInputDialog.ResumeLayout(false);
            }

            #endregion

            #region Private function, InputBox Form move and change size

            static private void LoadForm()
            {
                // Initialize the return code and text of the output response
                OutputResponse.ReturnCode = DialogResult.Ignore;
                OutputResponse.Text = string.Empty;

                // Set the default text of the input text box, prompt label, and form caption
                txtInput.Text = _defaultValue;
                lblPrompt.Text = _formPrompt;
                frmInputDialog.Text = _formCaption;

                // Retrieve the working rectangle from the Screen class
                // using the PrimaryScreen and the WorkingArea properties.
                System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;

                // Position the form based on the specified coordinates or center it if coordinates are out of bounds
                if ((_xPos >= 0 && _xPos < workingRectangle.Width - 100) && (_yPos >= 0 && _yPos < workingRectangle.Height - 100))
                {
                    frmInputDialog.StartPosition = FormStartPosition.Manual;
                    frmInputDialog.Location = new System.Drawing.Point(_xPos, _yPos);
                }
                else
                    frmInputDialog.StartPosition = FormStartPosition.CenterScreen;

                // Adjust the position and size of the text box and form based on the number of newline characters in the prompt text
                string PrompText = lblPrompt.Text;
                int n = 0;
                int Index = 0;
                while (PrompText.IndexOf("\n", Index) > -1)
                {
                    Index = PrompText.IndexOf("\n", Index) + 1;
                    n++;
                }

                // If no newline character is found, set n to 1
                if (n == 0)
                    n = 1;

                System.Drawing.Point Txt = txtInput.Location;
                Txt.Y = Txt.Y + (n * 4);
                txtInput.Location = Txt;
                System.Drawing.Size form = frmInputDialog.Size;
                form.Height = form.Height + (n * 4);
                frmInputDialog.Size = form;

                // Set the selection to the entire text in the input text box and focus on it
                txtInput.SelectionStart = 0;
                txtInput.SelectionLength = txtInput.Text.Length;
                txtInput.Focus();
            }


            #endregion


            #region Button control click event


            /// <summary>
            /// Checks whether the given folder name is valid.
            /// </summary>
            /// <param name="folderName">The folder name to validate.</param>
            /// <returns>True if the folder name is valid, otherwise false.</returns>
            private bool IsValidFolderName(string folderName)
            {
                // Check for invalid characters in the folder name
                char[] invalidChars = Path.GetInvalidPathChars();
                if (folderName.Any(c => invalidChars.Contains(c)))
                {
                    return false;
                }

                // Check if the text represents a valid path
                if (!Path.IsPathRooted(folderName))
                {
                    return false;
                }

                // Additional checks if needed...

                return true;
            }

            /// <summary>
            /// Checks whether the given filename is valid.
            /// </summary>
            /// <param name="testName">The filename to validate.</param>
            /// <returns>True if the filename is valid, otherwise false.</returns>
            public bool IsValidFilename(string testName)
            {
                // Placeholder implementation, always returns false
                { return false; };

                // Other checks for UNC, drive-path format, etc

                return true;
            }

            /// <summary>
            /// Event handler for the OK button click.
            /// </summary>
            /// <param name="sender">The object that raised the event.</param>
            /// <param name="e">The event arguments.</param>
            static private void btnOK_Click(object sender, System.EventArgs e)
            {
                // Get the main form instance
                mainForm fc = (mainForm)Application.OpenForms["mainForm"];
                if (fc != null)
                {
                    // Set the return code to OK
                    OutputResponse.ReturnCode = DialogResult.OK;

                    // Store the input text value in OutputResponse.Text
                    string s6 = OutputResponse.Text;
                    bool a = string.IsNullOrWhiteSpace(s6);
                    OutputResponse.Text = txtInput.Text;

                    // Check for invalid characters in the folder name
                    char[] invalidPathChars = Path.GetInvalidPathChars();
                    Regex regex = new Regex(@"^[^\\/:\*\?""<>\|]*$");

                    // Check if the folder name matches the pattern
                    if (!regex.IsMatch(OutputResponse.Text))
                    {
                        MessageBox.Show("Your response contains invalid characters!", "Invalid Response!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        frmInputDialog.Dispose();
                        fc.createCustomDirCheckBox.Checked = false;
                    }
                    else
                    {
                        // Set the custom folder name and check the corresponding checkbox
                        fc.customFolderName = OutputResponse.Text;
                        frmInputDialog.Dispose();
                        fc.createCustomDirCheckBox.Checked = true;
                    }
                }
            }



            /// <summary>
            /// Event handler for the Cancel button click.
            /// </summary>
            /// <param name="sender">The object that raised the event.</param>
            /// <param name="e">The event arguments.</param>
            static private void btnCancel_Click(object sender, System.EventArgs e)
            {
                // Get the main form instance
                mainForm fc = (mainForm)Application.OpenForms["mainForm"];
                if (fc != null)
                {
                    // Set the return code to Cancel and clean the output response
                    OutputResponse.ReturnCode = DialogResult.Cancel;
                    OutputResponse.Text = string.Empty;
                    frmInputDialog.Dispose();
                    fc.createCustomDirCheckBox.Checked = false;
                }
            }


            #endregion


            #region Public Static Show functions

            static public InputBoxResult Show(string Prompt)
            {
                InitializeComponent();
                FormPrompt = Prompt;

                // Display the form as a modal dialog box.
                LoadForm();
                frmInputDialog.ShowDialog();
                return OutputResponse;
            }

            static public InputBoxResult Show(string Prompt, string Title)
            {
                InitializeComponent();

                FormCaption = Title;
                FormPrompt = Prompt;

                // Display the form as a modal dialog box.
                LoadForm();
                frmInputDialog.ShowDialog();
                return OutputResponse;
            }

            static public InputBoxResult Show(string Prompt, string Title, string Default)
            {
                InitializeComponent();

                FormCaption = Title;
                FormPrompt = Prompt;
                DefaultValue = Default;

                // Display the form as a modal dialog box.
                LoadForm();
                frmInputDialog.ShowDialog();
                return OutputResponse;
            }

            static public InputBoxResult Show(string Prompt, string Title, string Default, int XPos, int YPos)
            {
                InitializeComponent();
                FormCaption = Title;
                FormPrompt = Prompt;
                DefaultValue = Default;
                XPosition = XPos;
                YPosition = YPos;

                // Display the form as a modal dialog box.
                LoadForm();
                frmInputDialog.ShowDialog();
                return OutputResponse;
            }


            #endregion


            #region Private Properties

            static private string FormCaption
            {
                set
                {
                    _formCaption = value;
                }
            } // property FormCaption

            static private string FormPrompt
            {
                set
                {
                    _formPrompt = value;
                }
            } // property FormPrompt

            static private InputBoxResult OutputResponse
            {
                get
                {
                    return _outputResponse;
                }
                set
                {
                    _outputResponse = value;
                }
            } // property InputResponse

            static private string DefaultValue
            {
                set
                {
                    _defaultValue = value;
                }
            } // property DefaultValue

            static private int XPosition
            {
                set
                {
                    if (value >= 0)
                        _xPos = value;
                }
            } // property XPos

            static private int YPosition
            {
                set
                {
                    if (value >= 0)
                        _yPos = value;
                }
            } // property YPos


            #endregion
        }
        //COPY ALL FILES ON DGV BACKGROUNDWORKER
        private void COPYbackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Check if there are rows in the DataGridView
            if (fileDirDataGridView.Rows.Count > 0)
            {
                // Get the index of the currently selected row
                int currentRow = fileDirDataGridView.SelectedRows[0].Index;

                // Loop through each row in the DataGridView
                for (int i = 0; i < fileDirDataGridView.Rows.Count; i++)
                {
                    // Select the current row
                    fileDirDataGridView.Rows[i].Selected = true;

                    // Scroll to the current row
                    fileDirDataGridView.FirstDisplayedScrollingRowIndex = i;

                    // Get the DataGridViewRow object for the current row
                    DataGridViewRow row = fileDirDataGridView.Rows[i];

                    // Get the file path from the DataGridView
                    string fileNow = row.Cells[2].Value.ToString();
                    var fileInfoNow = new FileInfo(fileNow);

                    // Check if the DataGridView contains at least one row
                    if (fileDirDataGridView.Rows.Count >= 1)
                    {
                        // Check if the current row represents a folder
                        if (row.Cells[1].Value == "Folder")
                        {
                            // Copy files based on user preferences
                            if (keepDirStructCheckBox.Checked)
                            {
                                string sourceDirectory = fileNow.ToString();
                                filePathLabel.Text = fileNow.ToString();
                                string destinationDirectory = Path.Combine(targetDirLabel.Text, fileInfoNow.Name);
                                CopyFiles(sourceDirectory, destinationDirectory, bufferSize);
                            }
                            else if (createCustomDirCheckBox.Checked)
                            {
                                InputBox.Show("Enter a custom folder for files to be copied into: ");
                                if (customFolderName == string.Empty || customFolderName == null)
                                {
                                    canceled = true;
                                    // User canceled the operation
                                    return;
                                }
                                string sourceDirectory = fileNow.ToString();
                                filePathLabel.Text = fileNow.ToString();
                                string destinationDirectory = Path.Combine(targetDirLabel.Text, customFolderName);
                                CopyFiles(sourceDirectory, destinationDirectory, bufferSize);
                            }
                            else if (copyFilesDirsCheckBox.Checked)
                            {
                                string sourceDirectory = fileNow.ToString();
                                string destinationDirectory = Path.Combine(targetDirLabel.Text);
                                CopyFiles(sourceDirectory, destinationDirectory, bufferSize);
                            }
                        }
                        else
                        {
                            // If the current row represents a file
                            string sourceFilePath2 = fileNow.ToString();
                           // string fileNow2 = sourceFilePath2.ToString();
                            var fileInfoNow2 = new FileInfo(sourceFilePath2.ToString());
                            string destinationFilePath2 = Path.Combine(sourceFilePath2.ToString(), fileInfoNow2.FullName);
                            var fileInfoNowDest = new FileInfo(destinationFilePath2);
                            filePathLabel.Text = fileNow.ToString();

                            // Check if the destination file exists
                            if (File.Exists(fileInfoNowDest.FullName))
                            {
                                // Perform appropriate action based on user preferences
                                if (overwriteIfNewerCHKBOX.Checked == true && fileInfoNow.LastWriteTime > fileInfoNowDest.LastWriteTime)
                                {
                                    filesProcessed++;
                                    CopyFile(sourceFilePath2, destinationFilePath2, true);
                                }
                                else if (overwriteIfNewerCHKBOX.Checked == true && fileInfoNow.LastWriteTime < fileInfoNowDest.LastWriteTime)
                                {
                                    skipFileExistsOlder = true;
                                }
                                else if (overwriteIfNewerCHKBOX.Checked == true && fileInfoNow.LastWriteTime == fileInfoNowDest.LastWriteTime)
                                {
                                    skipFileExistsSame = true;
                                }
                                else if (overwriteAllCHKBOX.Checked == true)
                                {
                                    filesProcessed++;
                                    CopyFile(sourceFilePath2, destinationFilePath2, true);
                                }
                                else if (doNotOverwriteCHKBOX.Checked == true)
                                {
                                    skipFileExists = true;
                                }
                            }
                            Stopwatch stopwatch = Stopwatch.StartNew();
                        }
                    }
                }
            }
        }

        private void COPYbackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Check if the COPYbackgroundWorker is currently running
            if (COPYbackgroundWorker.IsBusy == true)
            {
                // Set the canceled flag to true
                canceled = true;

                // Cancel the COPYbackgroundWorker operation
                COPYbackgroundWorker.CancelAsync();
            }

            // Stop the timeRemainingTimer
            timeRemainingTimer.Stop();

            // Stop and reset the _timer if it was running
            _timer.Stop();
            _timerRunning = false;

            // Reset the elapsed time TimeSpan objects
            _totalElapsedTime = TimeSpan.Zero;
            _currentElapsedTime = TimeSpan.Zero;

            // Enable or disable buttons based on the cancellation state
            startButton.Enabled = true;
            pauseResumeButton.Enabled = false;
            cancelButton.Enabled = false;

            // Check if the operation was canceled
            if (canceled == true)
            {
                // Check if custom folder creation was selected and custom folder name is empty
                if ((createCustomDirCheckBox.Checked) && (customFolderName == null || customFolderName == string.Empty))
                {
                    // Stop the timeRemainingTimer
                    timeRemainingTimer.Stop();

                    // Stop and reset the _timer if it was running
                    _timer.Stop();
                    _timerRunning = false;

                    // Reset the elapsed time TimeSpan objects
                    _totalElapsedTime = TimeSpan.Zero;
                    _currentElapsedTime = TimeSpan.Zero;

                    // Enable or disable buttons and reset UI elements
                    startButton.Enabled = true;
                    pauseResumeButton.Enabled = false;
                    cancelButton.Enabled = false;

                    // Enable sorting for DataGridView columns
                    foreach (DataGridViewColumn column in fileDirDataGridView.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.Automatic;
                    }

                    // Update UI elements and tab control based on skipped files
                    if (skippedDataGridView.Rows.Count > 0)
                    {
                        ((Control)this.cmdMainPage).Enabled = false;
                        ((Control)this.cmdSkipPage).Enabled = true;
                        ((Control)this.cmdAboutPage).Enabled = false;
                        ((Control)this.cmdSettingsPage).Enabled = false;
                        ((Control)this.cmdCopyHistoryPage).Enabled = false;
                        tabControl1.SelectedTab = cmdSkipPage;
                    }
                    else
                    {
                        ((Control)this.cmdMainPage).Enabled = true;
                        ((Control)this.cmdSkipPage).Enabled = true;
                        ((Control)this.cmdAboutPage).Enabled = true;
                        ((Control)this.cmdSettingsPage).Enabled = true;
                        ((Control)this.cmdCopyHistoryPage).Enabled = true;
                        tabControl1.SelectedTab = cmdMainPage;
                    }

                    // Reset various variables and UI elements
                    num = 0;
                    fileDirDataGridView.Rows.Clear();
                    totalPercentDoubleFile = 0;
                    totalPercentDouble = 0;
                    processedFiles = 0;
                    totalBytesProcessed = 0;
                    pct = 0;
                    fileOn = 0;
                    elapsedTimeLabel.Text = "Elapsed Time: 00:00:00";
                    timeRemainingLabel.Text = "Time Remaining: 00:00:00";
                    totalProgressBar.Value = 0;
                    fileProgressBar.Value = 0;
                    totalProgressLabel.Text = "0%";
                    fileTotalProgressLabel.Text = "0%";
                    filePathLabel.Text = "Nothing";
                    fileProcessedLabel.Text = "File Processed: 0/0 Bytes";
                    speedLabel.Text = "Speed: 0 Mb/Sec.";
                    fromFilesDirLabel.Text = "Select Files/Directory";
                    targetDirLabel.Text = "SelectFiles/Directory";
                    fileCountOnLabel.Text = "File Count: 0/0";
                    totalCopiedProgressLabel.Text = "Total C/M/D: 0/0 Bytes";
                    fileIconPicBox.Image = (Havoc__Copy_That.Properties.Resources.icons8_file_40);
                    startButton.Enabled = true;
                    cancelButton.Enabled = false;
                    pauseResumeButton.Enabled = false;
                    clearFileListButton.Enabled = true;
                    canceled = false;
                    skipButton.Enabled = false;
                    customFolderName = "";
                    copyMoveDeleteComboBox.Enabled = true;
                    doNotOverwriteCHKBOX.Enabled = true;
                    overwriteAllCHKBOX.Enabled = true;
                    overwriteIfNewerCHKBOX.Enabled = true;
                    keepDirStructCheckBox.Enabled = true;
                    createCustomDirCheckBox.Enabled = true;
                    copyFilesDirsCheckBox.Enabled = true;
                    clearTextButton.Enabled = true;
                    searchTextBox.Enabled = true;
                    fromDirPicBox.Enabled = true;
                    targetDirPicBox.Enabled = true;
                    fileUpPicBox.Enabled = true;
                    fileDownPicBox.Enabled = true;
                    moveTopPicBox.Enabled = true;
                    moveBottomPicBox.Enabled = true;
                }
                // If the cancellation is not due to the conditions specified earlier
                else
                {
                    // Stop the timeRemainingTimer
                    timeRemainingTimer.Stop();

                    // Stop and reset the _timer if it was running
                    _timer.Stop();
                    _timerRunning = false;

                    // Reset the elapsed time TimeSpan objects
                    _totalElapsedTime = TimeSpan.Zero;
                    _currentElapsedTime = TimeSpan.Zero;

                    // Enable or disable buttons based on the cancellation state
                    startButton.Enabled = true;
                    pauseResumeButton.Enabled = false;
                    cancelButton.Enabled = false;

                    // Check if the onCancelCheckBox is checked and play a sound
                    if (onCancelCheckBox.Checked)
                    {
                        System.IO.Stream str = Properties.Resources.OnCancel;
                        System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                        snd.Play();
                    }

                    // Determine the verification status
                    string verifyStatus = "";
                    if (verifyCheckBox.Checked == true && verificationPassed == true)
                    {
                        verifyStatus = "Every test passed!";
                    }
                    else if (verifyCheckBox.Checked == true && verificationPassed == false)
                    {
                        verifyStatus = "One or more tests failed!";
                    }
                    else
                    {
                        verifyStatus = "Verify Files Unchecked.";
                    }

                    // Calculate the number of processed files
                    processedFiles = (fileOn - skippedDataGridView.Rows.Count);

                    // Show a message box with operation details
                    MessageBox.Show("Copy Operation was Canceled!" + Environment.NewLine +
                        "" + elapsedTimeLabel.Text + "" + Environment.NewLine +
                        "" + fileCountOnLabel.Text + "" + Environment.NewLine +
                        "" + overwriteOption.ToString() + "" + Environment.NewLine +
                        "Processed File Count: " + processedFiles.ToString("N0") + "/" + num.ToString("N0") + "" + Environment.NewLine +
                        "Skipped File Count: " + skippedDataGridView.Rows.Count + "/" + num.ToString("N0") + "" + Environment.NewLine +
                        "" + totalCopiedProgressLabel.Text + "" + Environment.NewLine +
                        "Verification Tests: " + verifyStatus + "", "Copy That - File/Directory Tool - Copy Operation was Canceled!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Define the path for the log file
                    string logFilePath = @"\CopyThatLog.txt";
                    logFilePath = Application.StartupPath + logFilePath;

                    // Write log if logFileCheckBox is checked
                    if (logFileCheckBox.Checked)
                    {
                        using (StreamWriter logWriter = new StreamWriter(logFilePath, true))
                        {
                            logWriter.WriteLine($"Copy process ended at {DateTime.Now}");
                            logWriter.WriteLine($"Copy Operation was Canceled!");
                            logWriter.WriteLine($"" + elapsedTimeLabel.Text + "");
                            logWriter.WriteLine($"" + fileCountOnLabel.Text + "");
                            logWriter.WriteLine($"" + overwriteOption.ToString() + "");
                            logWriter.WriteLine($"Processed File Count: " + processedFiles.ToString("N0") + "/" + num.ToString("N0") + "");
                            logWriter.WriteLine($"Skipped File Count: " + skippedDataGridView.Rows.Count + "/" + num.ToString("N0") + "");
                            logWriter.WriteLine("" + totalCopiedProgressLabel.Text + "");
                            logWriter.WriteLine("Verification Tests: " + verifyStatus + "");
                            logWriter.WriteLine();
                            logWriter.WriteLine();
                        }
                    }

                    // Reset various variables and UI elements
                    num = 0;
                    totalBytes = 0;
                    fileDirDataGridView.Rows.Clear();
                    totalPercentDoubleFile = 0;
                    totalPercentDouble = 0;
                    processedFiles = 0;
                    totalBytes = 0;
                    totalBytesProcessed = 0;
                    totalPercentDouble = 0;
                    pct = 0;
                    fileOn = 0;
                    copyMoveDeleteComboBox.Text = string.Empty;
                    elapsedTimeLabel.Text = "Elapsed Time: 00:00:00";
                    timeRemainingLabel.Text = "Time Remaining: 00:00:00";
                    totalProgressBar.Value = 0;
                    fileProgressBar.Value = 0;
                    totalProgressLabel.Text = "0%";
                    fileTotalProgressLabel.Text = "0%";
                    filePathLabel.Text = "Nothing";
                    fileProcessedLabel.Text = "File Processed: 0/0 Bytes";
                    speedLabel.Text = "Speed: 0 Mb/Sec.";
                    fromFilesDirLabel.Text = "Select Files/Directory";
                    targetDirLabel.Text = "SelectFiles/Directory";
                    fileCountOnLabel.Text = "File Count: 0/0";
                    totalCopiedProgressLabel.Text = "Total C/M/D: 0/0 Bytes";
                    startButton.Enabled = true;
                    cancelButton.Enabled = false;
                    pauseResumeButton.Enabled = false;
                    clearFileListButton.Enabled = true;
                    canceled = false;
                    skipButton.Enabled = false;
                    copyMoveDeleteComboBox.Enabled = true;
                    doNotOverwriteCHKBOX.Enabled = true;
                    overwriteAllCHKBOX.Enabled = true;
                    overwriteIfNewerCHKBOX.Enabled = true;
                    keepDirStructCheckBox.Enabled = true;
                    createCustomDirCheckBox.Enabled = true;
                    copyFilesDirsCheckBox.Enabled = true;
                    clearTextButton.Enabled = true;
                    searchTextBox.Enabled = true;
                    fromDirPicBox.Enabled = true;
                    targetDirPicBox.Enabled = true;
                    fileUpPicBox.Enabled = true;
                    fileDownPicBox.Enabled = true;
                    moveTopPicBox.Enabled = true;
                    moveBottomPicBox.Enabled = true;
                    customFolderName = "";
                    fileIconPicBox.Image = (Havoc__Copy_That.Properties.Resources.icons8_file_40);
                    fileDirDataGridView.Rows.Clear();

                    // Enable sorting for DataGridView columns
                    foreach (DataGridViewColumn column in fileDirDataGridView.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.Automatic;
                    }
                    // Check if there are any skipped files in the skippedDataGridView
                    if (skippedDataGridView.Rows.Count > 0)
                    {
                        // Disable certain controls and enable the skip page
                        ((Control)this.cmdMainPage).Enabled = false;
                        ((Control)this.cmdSkipPage).Enabled = true;
                        ((Control)this.cmdAboutPage).Enabled = false;
                        ((Control)this.cmdSettingsPage).Enabled = false;
                        ((Control)this.cmdCopyHistoryPage).Enabled = false;
                        // Set the selected tab to the skip page in the tab control
                        tabControl1.SelectedTab = cmdSkipPage;
                    }
                    else
                    {
                        // Enable controls and set the selected tab to the main page
                        ((Control)this.cmdMainPage).Enabled = true;
                        ((Control)this.cmdSkipPage).Enabled = true;
                        ((Control)this.cmdAboutPage).Enabled = true;
                        ((Control)this.cmdSettingsPage).Enabled = true;
                        ((Control)this.cmdCopyHistoryPage).Enabled = true;
                        // Set the selected tab to the main page in the tab control
                        tabControl1.SelectedTab = cmdMainPage;
                    }
                }
            }
            else
            {
                // Check if createCustomDirCheckBox is checked and customFolderName is null or empty
                if (createCustomDirCheckBox.Checked && (customFolderName == null || customFolderName == string.Empty))
                {
                    // Check if the background worker is busy
                    if (COPYbackgroundWorker.IsBusy == true)
                    {
                        // Set canceled flag to true and cancel the background worker
                        canceled = true;
                        COPYbackgroundWorker.CancelAsync();
                    }

                    // Stop the time remaining timer
                    timeRemainingTimer.Stop();
                    // Stop and reset the timer if it was running
                    _timer.Stop();
                    _timerRunning = false;

                    // Reset the elapsed time TimeSpan objects
                    _totalElapsedTime = TimeSpan.Zero;
                    _currentElapsedTime = TimeSpan.Zero;

                    // Enable the start button and disable pause/resume and cancel buttons
                    startButton.Enabled = true;
                    pauseResumeButton.Enabled = false;
                    cancelButton.Enabled = false;

                    // Enable automatic sorting for each column in the fileDirDataGridView
                    foreach (DataGridViewColumn column in fileDirDataGridView.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.Automatic;
                    }

                    // Enable or disable controls based on the presence of skipped files
                    if (skippedDataGridView.Rows.Count > 0)
                    {
                        ((Control)this.cmdMainPage).Enabled = false;
                        ((Control)this.cmdSkipPage).Enabled = true;
                        ((Control)this.cmdAboutPage).Enabled = false;
                        ((Control)this.cmdSettingsPage).Enabled = false;
                        ((Control)this.cmdCopyHistoryPage).Enabled = false;
                        tabControl1.SelectedTab = cmdSkipPage;
                    }
                    else
                    {
                        ((Control)this.cmdMainPage).Enabled = true;
                        ((Control)this.cmdSkipPage).Enabled = true;
                        ((Control)this.cmdAboutPage).Enabled = true;
                        ((Control)this.cmdSettingsPage).Enabled = true;
                        ((Control)this.cmdCopyHistoryPage).Enabled = true;
                        tabControl1.SelectedTab = cmdMainPage;
                    }

                    // Reset various variables and labels
                    num = 0;
                    fileDirDataGridView.Rows.Clear();
                    totalPercentDoubleFile = 0;
                    totalPercentDouble = 0;
                    processedFiles = 0;
                    totalBytes = 0;
                    totalBytesProcessed = 0;
                    pct = 0;
                    fileOn = 0;
                    copyMoveDeleteComboBox.Text = string.Empty;
                    elapsedTimeLabel.Text = "Elapsed Time: 00:00:00";
                    timeRemainingLabel.Text = "Time Remaining: 00:00:00";
                    fileCountOnLabel.Text = "File Count: 0/0";
                    totalCopiedProgressLabel.Text = "Total C/M/D: 0/0 Bytes";
                    totalProgressBar.Value = 0;
                    fileProgressBar.Value = 0;
                    totalProgressLabel.Text = "0%";
                    fileTotalProgressLabel.Text = "0%";
                    filePathLabel.Text = "Nothing";
                    fileProcessedLabel.Text = "File Processed: 0/0 Bytes";
                    speedLabel.Text = "Speed: 0 Mb/Sec.";
                    fromFilesDirLabel.Text = "Select Files/Directory";
                    targetDirLabel.Text = "SelectFiles/Directory";
                    fileIconPicBox.Image = (Havoc__Copy_That.Properties.Resources.icons8_file_40);
                    startButton.Enabled = true;
                    cancelButton.Enabled = false;
                    pauseResumeButton.Enabled = false;
                    clearFileListButton.Enabled = true;
                    canceled = false;
                    skipButton.Enabled = false;
                    customFolderName = "";
                    copyMoveDeleteComboBox.Enabled = true;
                    doNotOverwriteCHKBOX.Enabled = true;
                    overwriteAllCHKBOX.Enabled = true;
                    overwriteIfNewerCHKBOX.Enabled = true;
                    keepDirStructCheckBox.Enabled = true;
                    createCustomDirCheckBox.Enabled = true;
                    copyFilesDirsCheckBox.Enabled = true;
                    clearTextButton.Enabled = true;
                    searchTextBox.Enabled = true;
                    fromDirPicBox.Enabled = true;
                    targetDirPicBox.Enabled = true;
                    fileUpPicBox.Enabled = true;
                    fileDownPicBox.Enabled = true;
                    moveTopPicBox.Enabled = true;
                    moveBottomPicBox.Enabled = true;

                }
                else
                {
                    // Check if onFinishCheckBox is checked
                    if (onFinishCheckBox.Checked)
                    {
                        // Play a sound indicating completion
                        System.IO.Stream str = Properties.Resources.OnFinish;
                        System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                        snd.Play();
                    }

                    // Determine the verification status message
                    string verifyStatus = "";
                    if (verifyCheckBox.Checked == true && verificationPassed == true)
                    {
                        verifyStatus = "Every test passed!";
                    }
                    else if (verifyCheckBox.Checked == true && verificationPassed == false)
                    {
                        verifyStatus = "One or more tests failed!";
                    }
                    else
                    {
                        verifyStatus = "Verify Files Unchecked.";
                    }

                    // Delay execution for 3 seconds
                    System.Threading.Thread.Sleep(3000);

                    // Calculate the number of processed files
                    processedFiles = (fileOn - skippedDataGridView.Rows.Count);

                    // Show completion message box
                    MessageBox.Show("Copy Operation was Completed!" + Environment.NewLine +
                        "" + elapsedTimeLabel.Text + "" + Environment.NewLine +
                        "" + fileCountOnLabel.Text + "" + Environment.NewLine +
                        "" + overwriteOption.ToString() + "" + Environment.NewLine +
                        "Processed File Count: " + processedFiles.ToString("N0") + "/" + num.ToString("N0") + "" + Environment.NewLine +
                        "Skipped File Count: " + skippedDataGridView.Rows.Count + "/" + num.ToString("N0") + "" + Environment.NewLine +
                        "" + totalCopiedProgressLabel.Text + "" + Environment.NewLine +
                        "Verification Tests: " + verifyStatus + "", "Copy That - File/Directory Tool - Copy Operation was Completed!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Define the path for the log file
                    string logFilePath = @"\CopyThatLog.txt";
                    logFilePath = Application.StartupPath + logFilePath;

                    // Write to the log file if logFileCheckBox is checked
                    if (logFileCheckBox.Checked)
                    {
                        using (StreamWriter logWriter = new StreamWriter(logFilePath, true))
                        {
                            logWriter.WriteLine($"Copy process ended at {DateTime.Now}");
                            logWriter.WriteLine($"Copy Operation was Completed!");
                            logWriter.WriteLine($"" + elapsedTimeLabel.Text + "");
                            logWriter.WriteLine($"" + fileCountOnLabel.Text + "");
                            logWriter.WriteLine($"" + overwriteOption.ToString() + "");
                            logWriter.WriteLine($"Processed File Count: " + processedFiles.ToString("N0") + "/" + num.ToString("N0") + "");
                            logWriter.WriteLine($"Skipped File Count: " + skippedDataGridView.Rows.Count + "/" + num.ToString("N0") + "");
                            logWriter.WriteLine("" + totalCopiedProgressLabel.Text + "");
                            logWriter.WriteLine("Verification Tests: " + verifyStatus + "");
                            logWriter.WriteLine();
                            logWriter.WriteLine();
                        }
                    }


                    // Set sort mode for each column in the fileDirDataGridView to Automatic
                    foreach (DataGridViewColumn column in fileDirDataGridView.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.Automatic;
                    }

                    // Check if there are any skipped items in the skippedDataGridView
                    if (skippedDataGridView.Rows.Count > 0)
                    {
                        // Disable certain controls and switch to the Skip Page tab if there are skipped items
                        ((Control)this.cmdMainPage).Enabled = false;
                        ((Control)this.cmdSkipPage).Enabled = true;
                        ((Control)this.cmdAboutPage).Enabled = false;
                        ((Control)this.cmdSettingsPage).Enabled = false;
                        ((Control)this.cmdCopyHistoryPage).Enabled = false;
                        tabControl1.SelectedTab = cmdSkipPage;
                    }
                    else
                    {
                        // Enable controls and switch to the Main Page tab if there are no skipped items
                        ((Control)this.cmdMainPage).Enabled = true;
                        ((Control)this.cmdSkipPage).Enabled = true;
                        ((Control)this.cmdAboutPage).Enabled = true;
                        ((Control)this.cmdSettingsPage).Enabled = true;
                        ((Control)this.cmdCopyHistoryPage).Enabled = true;
                        tabControl1.SelectedTab = cmdMainPage;
                    }

                    // Reset various variables and UI elements
                    totalPercentDoubleFile = 0;
                    totalPercentDouble = 0;
                    num = 0;
                    processedFiles = 0;
                    totalBytes = 0;
                    totalBytesProcessed = 0;
                    totalPercentDouble = 0;
                    pct = 0;
                    fileOn = 0;
                    copyMoveDeleteComboBox.Text = string.Empty;
                    fileCountOnLabel.Text = "File Count: 0/0";
                    totalCopiedProgressLabel.Text = "Total C/M/D: 0/0 Bytes";
                    elapsedTimeLabel.Text = "Elapsed Time: 00:00:00";
                    timeRemainingLabel.Text = "Time Remaining: 00:00:00";
                    totalProgressBar.Value = 0;
                    fileProgressBar.Value = 0;
                    totalProgressLabel.Text = "0%";
                    fileTotalProgressLabel.Text = "0%";
                    filePathLabel.Text = "Nothing";
                    fromFilesDirLabel.Text = "Select Files/Directory";
                    targetDirLabel.Text = "SelectFiles/Directory";
                    fileProcessedLabel.Text = "File Processed: 0/0 Bytes";
                    speedLabel.Text = "Speed: 0 Mb/Sec.";
                    totalHDSpaceLeftLabel.Text = "Total Space: 0/0 Bytes";
                    totalHDSpaceLeftLabel.Refresh();
                    fileIconPicBox.Image = (Havoc__Copy_That.Properties.Resources.icons8_file_40);
                    fileDirDataGridView.Rows.Clear();
                    startButton.Enabled = true;
                    cancelButton.Enabled = false;
                    pauseResumeButton.Enabled = false;
                    clearFileListButton.Enabled = true;
                    canceled = false;
                    skipButton.Enabled = false;
                    customFolderName = "";
                    copyMoveDeleteComboBox.Enabled = true;
                    doNotOverwriteCHKBOX.Enabled = true;
                    overwriteAllCHKBOX.Enabled = true;
                    overwriteIfNewerCHKBOX.Enabled = true;
                    keepDirStructCheckBox.Enabled = true;
                    createCustomDirCheckBox.Enabled = true;
                    copyFilesDirsCheckBox.Enabled = true;
                    clearTextButton.Enabled = true;
                    searchTextBox.Enabled = true;
                    fromDirPicBox.Enabled = true;
                    targetDirPicBox.Enabled = true;
                    fileUpPicBox.Enabled = true;
                    fileDownPicBox.Enabled = true;
                    moveTopPicBox.Enabled = true;
                    moveBottomPicBox.Enabled = true;


                    string selectedOption = onFinishComboBox.SelectedItem.ToString();

                    switch (selectedOption)
                    {
                        case "Close Application":
                            if (COPYbackgroundWorker.IsBusy)
                            {
                                COPYbackgroundWorker.CancelAsync();
                                COPYbackgroundWorker.Dispose();
                            }
                            Application.Exit();
                            break;

                        case "Log Off User":
                            DoExitWin(EWX_LOGOFF);
                            break;

                        case "Restart CPU":
                            DoExitWin(EWX_REBOOT);
                            break;

                        case "Sleep":
                            // Standby
                            Application.SetSuspendState(PowerState.Suspend, true, true);
                            break;

                        case "Shut Down CPU":
                            DoExitWin(EWX_SHUTDOWN);
                            break;

                        default:
                            // Keep Application Open or any other option not handled
                            break;
                    }
                }
            }
        }


        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct TokPriv1Luid
        {
            public int Count;
            public long Luid;
            public int Attr;
        }

        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GetCurrentProcess();

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr
        phtok);

        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool LookupPrivilegeValue(string host, string name,
        ref long pluid);

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall,
        ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool ExitWindowsEx(int flg, int rea);

        internal const int SE_PRIVILEGE_ENABLED = 0x00000002;
        internal const int TOKEN_QUERY = 0x00000008;
        internal const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
        internal const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
        internal const int EWX_LOGOFF = 0x00000000;
        internal const int EWX_SHUTDOWN = 0x00000001;
        internal const int EWX_REBOOT = 0x00000002;
        internal const int EWX_FORCE = 0x00000004;
        internal const int EWX_POWEROFF = 0x00000008;
        internal const int EWX_FORCEIFHUNG = 0x00000010;

        private void DoExitWin(int flg)
        {
            bool ok;
            TokPriv1Luid tp;
            IntPtr hproc = GetCurrentProcess();
            IntPtr htok = IntPtr.Zero;
            ok = OpenProcessToken(hproc, TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref htok);
            tp.Count = 1;
            tp.Luid = 0;
            tp.Attr = SE_PRIVILEGE_ENABLED;
            ok = LookupPrivilegeValue(null, SE_SHUTDOWN_NAME, ref tp.Luid);
            ok = AdjustTokenPrivileges(htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero);
            ok = ExitWindowsEx(flg, 0);
        }
        public static void DeleteAll(string source, string target, string skipFileName)
        {
            var sourceDi = new DirectoryInfo(source);
            var targetDi = new DirectoryInfo(target);
            DeleteAll(sourceDi);
        }

        /// <summary>
        /// Recursively delete directory
        /// </summary>
        /// <param name="source">The source.</param>
        // Define a method to delete all files and subdirectories within a given directory.
        public static void DeleteAll(DirectoryInfo source)
        {
            // Check if the target directory exists, if not, return.
            if (Directory.Exists(source.FullName) == false)
            {
                return;
            }

            // Get a reference to the mainForm instance.
            mainForm fc = (mainForm)Application.OpenForms["mainForm"];

            // Check if the mainForm instance exists.
            if (fc != null)
            {
                // Iterate through each file in the directory.
                foreach (var fileInfo in source.GetFiles())
                {
                    var fileNow = new FileInfo(fileInfo.FullName);
                    try
                    {
                        // Check conditions to skip file copying or processing.

                        // If the user has chosen to skip file, skip it.
                        if (fc.skipFileUser)
                        {
                            goto skipThisFile;
                        }

                        // Check if the operation is canceled.
                        if (fc.canceled)
                        {
                            if (fc.DELETEbackgroundWorker.CancellationPending)
                            {
                                fc.canceled = true;
                                fc.DELETEbackgroundWorker.CancelAsync();
                                return;
                            }
                        }

                        // Wait until the operation is resumed.
                        while (fc.paused == true)
                        {
                            if (fc.canceled)
                            {
                                if (fc.DELETEbackgroundWorker.CancellationPending)
                                {
                                    fc.canceled = true;
                                    fc.DELETEbackgroundWorker.CancelAsync();
                                    return;
                                }
                            }
                        }

                        // Delete the file.
                        if (File.Exists(fileNow.FullName))
                        {
                            FileSystem.DeleteFile(fileNow.FullName, UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently, UICancelOption.DoNothing);
                        }

                        // Update total bytes processed if the file is successfully deleted.
                        if (File.Exists(fileNow.FullName) == false)
                        {
                            fc.totalBytesProcessed += fileNow.Length;
                        }

                        // Update UI if there's only one file.
                        if (fc.fileOn == 1)
                        {
                            fc.progressPercentage = (int)((double)fc.fileOn / fc.num * 100);
                            fc.totalPercentDouble = ((double)fc.fileOn / fc.num * 100);
                            goto fileCountOne;
                        }

                    skipThisFile:
                        if (fc.skipFileUser == false)
                        {
                            goto continueFile;
                        }

                        // Add details of the skipped file to UI.
                        fc.skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                        fc.skippedDataGridView.Rows.Add("Skipped: User", fileNow.FullName.ToString(), fc.targetDirLabel.Text, fileNow.Name.ToString(), ConvertBytesToMegabytes(fileNow.Length).ToString("00.00 MB"));
                        fc.totalSkippedLabel.Text = "Total Skipped Files: " + fc.skippedDataGridView.Rows.Count + "";
                        fc.fileProcessedLabel.Refresh();
                        fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                        fc.fileProcessedLabel.Refresh();

                    continueFile:
                        // Select the last row in fileDirDataGridView if it exists.
                        if (fc.fileDirDataGridView.Rows.Count > 0)
                        {
                            int lastIndex = fc.fileDirDataGridView.Rows.Count - 1;
                            fc.fileDirDataGridView.Rows[lastIndex].Selected = true;
                        }

                        // Update total progress information.
                        double totalValue = Math.Round(fc.totalPercentDouble, 3);
                        if (totalValue >= 100)
                            goto continueFile;
                        fc.totalProgressLabel.Text = totalValue.ToString("00.00") + "%";
                        fc.totalProgressBar.Value = fc.progressPercentage;
                        fc.totalProgressBar.Refresh();
                        fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                        fc.fileProcessedLabel.Refresh();

                    fileCountOne:;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // Handle UnauthorizedAccessException, play sound and restart application if configured.
                        if (fc.onErrorCheckBox.Checked)
                        {
                            System.IO.Stream str = Properties.Resources.OnError;
                            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                            snd.Play();
                        }
                        if (fc.restartCheckBox.Checked == true)
                        {
                            Application.Restart();
                            Environment.Exit(0);
                        }
                        else
                        {
                            fc.exitPlease();
                        }
                        // Add details of the skipped file to UI.
                        fc.skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                        fc.skippedDataGridView.Rows.Add("Skipped: Unauth. Access", fileNow.FullName.ToString(), fc.targetDirLabel.Text, fileNow.Name.ToString(), ConvertBytesToMegabytes(fileNow.Length).ToString("00.00 MB"));
                        fc.totalSkippedLabel.Text = "Total Skipped Files: " + fc.skippedDataGridView.Rows.Count + "";
                        if (fc.fileDirDataGridView.Rows.Count > 0)
                        {
                            int lastIndex = fc.fileDirDataGridView.Rows.Count - 1;
                            fc.fileDirDataGridView.Rows[lastIndex].Selected = true;
                        }
                        double totalValue = Math.Round(fc.totalPercentDouble, 3);
                        fc.totalProgressLabel.Text = totalValue.ToString("00.00") + "%";
                        fc.totalProgressBar.Value = fc.progressPercentage;
                        fc.totalProgressBar.Refresh();
                        fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                        fc.fileProcessedLabel.Refresh();
                    }
                    catch (IOException)
                    {
                        // Handle IOException, play sound and restart application if configured.
                        if (fc.onErrorCheckBox.Checked)
                        {
                            System.IO.Stream str = Properties.Resources.OnError;
                            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                            snd.Play();
                        }

                        if (fc.restartCheckBox.Checked == true)
                        {
                            Application.Restart();
                            Environment.Exit(0);
                        }
                        else
                        {
                            fc.exitPlease();
                        }
                        // Add details of the skipped file to UI.
                        fc.skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                        fc.skippedDataGridView.Rows.Add("Skipped: IOException", fileNow.FullName.ToString(), fc.targetDirLabel.Text, fileNow.Name.ToString(), ConvertBytesToMegabytes(fileNow.Length).ToString("00.00 MB"));
                        fc.totalSkippedLabel.Text = "Total Skipped Files: " + fc.skippedDataGridView.Rows.Count + "";
                        fc.totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(fc.totalBytesProcessed) + "/" + FormatBytes(fc.totalBytes) + "";
                        fc.fileProcessedLabel.Refresh();
                        if (fc.fileDirDataGridView.Rows.Count > 0)
                        {
                            int lastIndex = fc.fileDirDataGridView.Rows.Count - 1;
                            fc.fileDirDataGridView.Rows[lastIndex].Selected = true;
                        }
                        double totalValue = Math.Round(fc.totalPercentDouble, 3);
                        fc.totalProgressLabel.Text = totalValue.ToString("00.00") + "%";
                        fc.totalProgressBar.Value = fc.progressPercentage;
                        fc.totalProgressBar.Refresh();
                    }
                    finally
                    {
                        // Reset progress and UI elements.
                        fc.totalBytesProcessedFile = 0;
                        fc.fileProgressBar.Value = 0;
                        fc.fileProgressBar.Refresh();
                        fc.fileTotalProgressLabel.Text = "0";
                        fc.speedLabel.Refresh();
                    }
                }
                // Delete each subdirectory using recursion.
                foreach (var subDir in source.GetDirectories())
                {
                    // Check if the subdirectory exists before attempting deletion.
                    if (Directory.Exists(subDir.FullName))
                    {
                        // Recursively call DeleteAll method for each subdirectory.
                        DeleteAll(subDir);
                    }
                }
            }
        }

        //DELETE ALL FILES ON DGV BACKGROUNDWORKER
        private void DELETEbackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Check if there are rows in the fileDirDataGridView
            if (fileDirDataGridView.Rows.Count > 0)
            {


                // Get the index of the currently selected row
                int currentRow = fileDirDataGridView.SelectedRows[0].Index;
                //MessageBox.Show(fileDirDataGridView.Rows[fileDirDataGridView.SelectedRows[0].Index].Cells[1].Value.ToString());

                // Iterate through each row in the fileDirDataGridView
                for (int i = 0; i < fileDirDataGridView.Rows.Count; i++)
                {


                    // Check if the operation is canceled
                    if (canceled)
                    {
                        if (DELETEbackgroundWorker.CancellationPending)
                        {
                            canceled = true;
                            DELETEbackgroundWorker.CancelAsync();
                            return;
                        }
                    }

                    // Wait until the operation is resumed
                    while (paused == true)
                    {
                        if (canceled)
                        {
                            if (DELETEbackgroundWorker.CancellationPending)
                            {
                                canceled = true;
                                DELETEbackgroundWorker.CancelAsync();
                                return;
                            }
                        }
                    }
                    // Select the current row
                    fileDirDataGridView.Rows[i].Selected = true;

                    // Get information about the file/directory in the current row
                    //fileDirDataGridView.FirstDisplayedScrollingRowIndex = i;
                    //fileDirDataGridView.CurrentCell = fileDirDataGridView.Rows[i].Cells[0];
                    DataGridViewRow row = fileDirDataGridView.Rows[i];

                    string fileNow = row.Cells[2].Value.ToString();
                    var fileInfoNow = new FileInfo(fileNow);

                    // Check if the current row is within the range of rows in the DataGridView
                    if (currentRow <= fileDirDataGridView.RowCount - 1)
                    {
                        // Check if the current row represents a directory
                        if (row.Cells[1].Value == "Folder")
                        {
                            var sourceDi = new DirectoryInfo(fileNow.ToString());
                            var targetDi = new DirectoryInfo(targetDirLabel.Text.ToString());

                            //MessageBox.Show(row.Cells[3].Value.ToString());
                            // MessageBox.Show(fileDirDataGridView.CurrentRow.Index.ToString());
                            try
                            {


                                // Recursively delete the directory and its contents
                                DeleteAll(sourceDi);

                                FileSystem.DeleteDirectory(fileNow, UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently, UICancelOption.DoNothing);

                            }
                            catch (Exception ex1)
                            {
                                // Handle any exception occurred during directory deletion
                                MessageBox.Show("Cannot delete the directory: " + sourceDi.Name + ""
                                    + ". You may not have permission to read the directory, or " +
                                    "don't have the proper authentication.\n\nReported error: " + ex1.Message + "", "Copy That - File/Directory Tool - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {

                            try
                            {
                                fileOn++;
                                // Delete the file

                                // Check if the user has chosen to skip the file
                                if (skipFileUser)
                                {
                                    goto skipThisFile;
                                }

                                // Check if the operation is canceled
                                if (canceled)
                                {
                                    if (DELETEbackgroundWorker.CancellationPending)
                                    {
                                        canceled = true;
                                        DELETEbackgroundWorker.CancelAsync();
                                        return;
                                    }
                                }

                                // Wait until the operation is resumed
                                while (paused == true)
                                {
                                    if (canceled)
                                    {
                                        if (DELETEbackgroundWorker.CancellationPending)
                                        {
                                            canceled = true;
                                            DELETEbackgroundWorker.CancelAsync();
                                            return;
                                        }
                                    }
                                }
                                // Delete the file
                                if (File.Exists(fileInfoNow.FullName))
                                {
                                    File.Delete(fileNow);
                                }
                                // Update total bytes processed if the file is successfully deleted
                                if (File.Exists(fileInfoNow.FullName) == false)
                                {
                                    totalBytesProcessed += fileInfoNow.Length;
                                }
                                // Update UI if there's only one file
                                if (fileOn == 1)
                                {
                                    progressPercentage = (int)((double)totalBytesProcessed / totalBytes * 100);
                                    totalPercentDouble = ((double)totalBytesProcessed / totalBytes * 100);
                                    goto fileCountOne;
                                }

                            skipThisFile:
                                if (skipFileUser == false)
                                {
                                    goto continueFile;
                                }
                                totalBytesProcessed += fileInfoNow.Length;
                                totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(totalBytesProcessed) + "/" + FormatBytes(totalBytes) + "";
                                totalCopiedProgressLabel.Refresh();
                                skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                                skippedDataGridView.Rows.Add("Skipped: User", fileInfoNow.FullName.ToString(), targetDirLabel.Text, fileInfoNow.Name.ToString(), ConvertBytesToMegabytes(fileInfoNow.Length).ToString("00.00 MB"));
                                totalSkippedLabel.Text = "Total Skipped Files: " + skippedDataGridView.Rows.Count + "";
                                fileProcessedLabel.Refresh();
                                if (fileDirDataGridView.Rows.Count > 0)
                                {
                                    // Select the last row
                                    int lastIndex = fileDirDataGridView.Rows.Count - 1;
                                    fileDirDataGridView.Rows[lastIndex].Selected = true;

                                }

                            continueFile:
                                if (fileDirDataGridView.Rows.Count > 0)
                                {
                                    // Select the last row
                                    int lastIndex = fileDirDataGridView.Rows.Count - 1;
                                    fileDirDataGridView.Rows[lastIndex].Selected = true;

                                }
                                double totalValue = Math.Round(totalPercentDouble, 3);
                                if (totalValue >= 100)
                                    goto continueFile;
                                totalProgressLabel.Text = totalValue.ToString("00.00") + "%";
                                totalProgressBar.Value = progressPercentage;
                                totalProgressBar.Refresh();
                                totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(totalBytesProcessed) + "/" + FormatBytes(totalBytes) + "";
                                totalCopiedProgressLabel.Refresh();

                            fileCountOne:;
                            }
                            catch (UnauthorizedAccessException)
                            {
                                // Handle UnauthorizedAccessException, play sound and restart application if configured
                                if (onErrorCheckBox.Checked)
                                {
                                    System.IO.Stream str = Properties.Resources.OnError;
                                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                                    snd.Play();
                                }
                                if (restartCheckBox.Checked == true)
                                {
                                    Application.Restart();
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    exitPlease();
                                }
                                totalBytesProcessed += fileInfoNow.Length;
                                totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(totalBytesProcessed) + "/" + FormatBytes(totalBytes) + "";
                                totalCopiedProgressLabel.Refresh();
                                skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                                skippedDataGridView.Rows.Add("Skipped: Unauth. Access", fileInfoNow.FullName.ToString(), targetDirLabel.Text, fileInfoNow.Name.ToString(), ConvertBytesToMegabytes(fileInfoNow.Length).ToString("00.00 MB"));
                                totalSkippedLabel.Text = "Total Skipped Files: " + skippedDataGridView.Rows.Count + "";
                                if (fileDirDataGridView.Rows.Count > 0)
                                {
                                    // Select the last row
                                    int lastIndex = fileDirDataGridView.Rows.Count - 1;
                                    fileDirDataGridView.Rows[lastIndex].Selected = true;

                                }
                                double totalValue = Math.Round(totalPercentDouble, 3);
                                totalProgressLabel.Text = totalValue.ToString("00.00") + "%";
                                totalProgressBar.Value = progressPercentage;
                                totalProgressBar.Refresh();
                            }
                            // Catch block for handling IOException
                            catch (IOException)
                            {
                                // Check if error sound is enabled
                                if (onErrorCheckBox.Checked)
                                {
                                    // Play error sound
                                    System.IO.Stream str = Properties.Resources.OnError;
                                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                                    snd.Play();
                                }

                                // Check if application restart is configured
                                if (restartCheckBox.Checked == true)
                                {
                                    // Restart the application
                                    Application.Restart();
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    // Exit the application
                                    exitPlease();
                                }

                                // Adjust the total bytes processed
                                totalBytesProcessed -= fileInfoNow.Length;
                                // Update UI elements and add the skipped file to the list
                                totalCopiedProgressLabel.Text = "Total C/M/D: " + FormatBytes(totalBytesProcessed) + "/" + FormatBytes(totalBytes) + "";
                                totalCopiedProgressLabel.Refresh();
                                skippedDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
                                skippedDataGridView.Rows.Add("Skipped: IOException", fileInfoNow.FullName.ToString(), targetDirLabel.Text, fileInfoNow.Name.ToString(), ConvertBytesToMegabytes(fileInfoNow.Length).ToString("00.00 MB"));
                                totalSkippedLabel.Text = "Total Skipped Files: " + skippedDataGridView.Rows.Count + "";

                                // Update total progress values
                                double totalValue = Math.Round(totalPercentDouble, 3);
                                totalProgressLabel.Text = totalValue.ToString("00.00") + "%";
                                totalProgressBar.Value = progressPercentage;
                                totalProgressBar.Refresh();
                            }
                            // Finally block for cleanup and UI updates
                            finally
                            {

                                // Reset total bytes processed for the current file
                                totalBytesProcessedFile = 0;
                                // Reset file progress bar
                                fileProgressBar.Value = 0;
                                fileProgressBar.Refresh();
                                // Reset file total progress label
                                fileTotalProgressLabel.Text = "0%";
                                // Refresh the speed label
                                speedLabel.Refresh();
                            }
                        }
                    }
                }
            }
        }

        private void DELETEbackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Check if the background worker is busy
            if (DELETEbackgroundWorker.IsBusy == true)
            {
                // If busy, set cancellation flag and cancel the asynchronous operation
                canceled = true;
                DELETEbackgroundWorker.CancelAsync();
            }

            // Stop the timer tracking remaining time
            timeRemainingTimer.Stop();

            // Stop and reset the main timer if it was running
            _timer.Stop();
            _timerRunning = false;

            // Reset elapsed time counters
            _totalElapsedTime = TimeSpan.Zero;
            _currentElapsedTime = TimeSpan.Zero;

            // Check if cancellation occurred
            if (canceled == true)
            {
                // If configured, play cancellation sound
                if (onCancelCheckBox.Checked)
                {
                    System.IO.Stream str = Properties.Resources.OnCancel;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                }

                // Display cancellation message with operation statistics
                MessageBox.Show("Deletion of Directory was Canceled!" + Environment.NewLine +
                                "" + elapsedTimeLabel.Text + "" + Environment.NewLine +
                                "" + fileCountOnLabel.Text + "" + Environment.NewLine +
                                "" + totalCopiedProgressLabel.Text + "", "Copy That - File/Directory Tool - Delete Operation was Canceled!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset various operation variables and UI elements
                num = 0;
                totalBytes = 0;
                totalBytesProcessed = 0;
                totalPercentDouble = 0;
                pct = 0;
                fileOn = 0;
                copyMoveDeleteComboBox.Text = string.Empty;
                totalCopiedProgressLabel.Text = "Total C/M/D: 0/0 Bytes";
                elapsedTimeLabel.Text = "Elapsed Time: 00:00:00";
                timeRemainingLabel.Text = "Time Remaining: 00:00:00";
                totalProgressBar.Value = 0;
                fileProgressBar.Value = 0;
                totalProgressLabel.Text = "0%";
                fileTotalProgressLabel.Text = "0%";
                fileCountOnLabel.Text = "File Count: 0/0";
                speedLabel.Text = "Speed: 0 Mb/Sec.";
                filePathLabel.Text = "Nothing";
                fromFilesDirLabel.Text = "Select Files/Directory";
                targetDirLabel.Text = "SelectFiles/Directory";
                fileIconPicBox.Image = (Havoc__Copy_That.Properties.Resources.icons8_file_40);
                fileDirDataGridView.Rows.Clear();

                // Enable appropriate UI elements and disable others
                clearFileListButton.Enabled = true;
                startButton.Enabled = true;
                cancelButton.Enabled = false;
                pauseResumeButton.Enabled = false;
                canceled = false;
                skipButton.Enabled = false;

                copyMoveDeleteComboBox.Enabled = true;
                doNotOverwriteCHKBOX.Enabled = true;
                overwriteAllCHKBOX.Enabled = true;
                overwriteIfNewerCHKBOX.Enabled = true;
                keepDirStructCheckBox.Enabled = true;
                createCustomDirCheckBox.Enabled = true;
                copyFilesDirsCheckBox.Enabled = true;
                clearTextButton.Enabled = true;
                searchTextBox.Enabled = true;
                fromDirPicBox.Enabled = true;
                targetDirPicBox.Enabled = true;
                fileUpPicBox.Enabled = true;
                fileDownPicBox.Enabled = true;
                moveTopPicBox.Enabled = true;
                moveBottomPicBox.Enabled = true;

                // Enable/disable tab controls based on skipped files presence
                foreach (DataGridViewColumn column in fileDirDataGridView.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                }

                if (skippedDataGridView.Rows.Count > 0)
                {
                    ((Control)this.cmdMainPage).Enabled = false;
                    ((Control)this.cmdSkipPage).Enabled = true;
                    ((Control)this.cmdAboutPage).Enabled = false;
                    ((Control)this.cmdSettingsPage).Enabled = false;
                    ((Control)this.cmdCopyHistoryPage).Enabled = false;
                    tabControl1.SelectedTab = cmdSkipPage;
                }
                else
                {
                    ((Control)this.cmdMainPage).Enabled = true;
                    ((Control)this.cmdSkipPage).Enabled = true;
                    ((Control)this.cmdAboutPage).Enabled = true;
                    ((Control)this.cmdSettingsPage).Enabled = true;
                    ((Control)this.cmdCopyHistoryPage).Enabled = true;
                    tabControl1.SelectedTab = cmdMainPage;
                }
            }
            else // If operation completed successfully
            {
                // If configured, play finish sound
                if (onFinishCheckBox.Checked)
                {
                    System.IO.Stream str = Properties.Resources.OnFinish;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                }

                // Display completion message with operation statistics
                MessageBox.Show("Deletion of Directory was Completed!" + Environment.NewLine +
                                "" + elapsedTimeLabel.Text + "" + Environment.NewLine +
                                "" + fileCountOnLabel.Text + "" + Environment.NewLine +
                                "" + totalCopiedProgressLabel.Text + "", "Copy That - File/Directory Tool - Delete Operation Completed!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset various operation variables and UI elements
                num = 0;
                totalBytes = 0;
                totalBytesProcessed = 0;
                totalPercentDouble = 0;
                pct = 0;
                fileOn = 0;
                copyMoveDeleteComboBox.Text = string.Empty;
                totalCopiedProgressLabel.Text = "Total C/M/D: 0/0 Bytes";
                elapsedTimeLabel.Text = "Elapsed Time: 00:00:00";
                timeRemainingLabel.Text = "Time Remaining: 00:00:00";
                totalProgressBar.Value = 0;
                fileProgressBar.Value = 0;
                totalProgressLabel.Text = "0%";
                fileTotalProgressLabel.Text = "0%";
                fileCountOnLabel.Text = "File Count: 0/0";
                speedLabel.Text = "Speed: 0 Mb/Sec.";
                filePathLabel.Text = "Nothing";
                fromFilesDirLabel.Text = "Select Files/Directory";
                targetDirLabel.Text = "SelectFiles/Directory";
                fileIconPicBox.Image = (Havoc__Copy_That.Properties.Resources.icons8_file_40);
                fileDirDataGridView.Rows.Clear();

                // Enable/disable appropriate UI elements
                startButton.Enabled = true;
                cancelButton.Enabled = false;
                pauseResumeButton.Enabled = false;
                clearFileListButton.Enabled = true;
                canceled = false;
                skipButton.Enabled = false;

                copyMoveDeleteComboBox.Enabled = true;
                doNotOverwriteCHKBOX.Enabled = true;
                overwriteAllCHKBOX.Enabled = true;
                overwriteIfNewerCHKBOX.Enabled = true;
                keepDirStructCheckBox.Enabled = true;
                createCustomDirCheckBox.Enabled = true;
                copyFilesDirsCheckBox.Enabled = true;
                clearTextButton.Enabled = true;
                searchTextBox.Enabled = true;
                fromDirPicBox.Enabled = true;
                targetDirPicBox.Enabled = true;
                fileUpPicBox.Enabled = true;
                fileDownPicBox.Enabled = true;
                moveTopPicBox.Enabled = true;
                moveBottomPicBox.Enabled = true;

                // Enable/disable tab controls based on skipped files presence
                foreach (DataGridViewColumn column in fileDirDataGridView.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                }

                if (skippedDataGridView.Rows.Count > 0)
                {
                    ((Control)this.cmdMainPage).Enabled = false;
                    ((Control)this.cmdSkipPage).Enabled = true;
                    ((Control)this.cmdAboutPage).Enabled = false;
                    ((Control)this.cmdSettingsPage).Enabled = false;
                    ((Control)this.cmdCopyHistoryPage).Enabled = false;
                    tabControl1.SelectedTab = cmdSkipPage;
                }
                else
                {
                    ((Control)this.cmdMainPage).Enabled = true;
                    ((Control)this.cmdSkipPage).Enabled = true;
                    ((Control)this.cmdAboutPage).Enabled = true;
                    ((Control)this.cmdSettingsPage).Enabled = true;
                    ((Control)this.cmdCopyHistoryPage).Enabled = true;
                    tabControl1.SelectedTab = cmdMainPage;
                }
            }

            string selectedAction = onFinishComboBox.SelectedItem.ToString();

            switch (selectedAction)
            {
                case "Keep Application Open":
                    // No action needed
                    break;
                case "Close Application":
                    if (COPYbackgroundWorker.IsBusy)
                    {
                        DELETEbackgroundWorker.CancelAsync();
                        DELETEbackgroundWorker.Dispose();
                    }
                    Application.Exit();
                    break;
                case "Log Off User":
                    DoExitWin(EWX_LOGOFF);
                    break;
                case "Restart CPU":
                    DoExitWin(EWX_REBOOT);
                    break;
                case "Sleep":
                    // Standby
                    Application.SetSuspendState(PowerState.Suspend, true, true);
                    break;
                case "Shut Down CPU":
                    DoExitWin(EWX_SHUTDOWN);
                    break;
                default:
                    // Handle unexpected selection
                    break;
            }
        }

        // Constants for Windows messages
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        // Importing functions from user32.dll
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        // Mouse down event handler for the main form
        private void mainForm_MouseDown(object sender, MouseEventArgs e)
        {
            // If the left mouse button is clicked
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture(); // Release mouse capture from a window
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); // Send a message to the window
            }
        }

        private void titleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            // If the left mouse button is clicked
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture(); // Release mouse capture from a window
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); // Send a message to the window
            }
        }


        /// <summary>
        /// Recursively scans a folder and removes all its files and subfolders.
        /// </summary>
        /// <param name="FolderLocation">The location of the folder to be scanned and removed.</param>
        public void ScanRemove(string FolderLocation)
        {
            try
            {
                // Get information about the directory
                DirectoryInfo di = new DirectoryInfo(FolderLocation);

                // Get an array of files and directories within the directory
                FileInfo[] aryFiles = di.GetFiles("*.*");
                DirectoryInfo[] aryDirs = di.GetDirectories();

                // Iterate through each file in the directory
                foreach (FileInfo fi in aryFiles)
                {
                    // Decrease the file count and total bytes
                    num--;
                    totalBytes -= fi.Length;
                    fileCountOnLabel.Text = "File Count: 0/" + num.ToString("N0") + "";
                    totalCopiedProgressLabel.Text = "Total C/M/D: 0/" + FormatBytes(totalBytes);
                }

                // Iterate through each subdirectory in the directory
                foreach (DirectoryInfo d in aryDirs)
                {
                    // Get the full path and folder name of the subdirectory
                    string path2 = d.FullName;
                    string folder2 = new DirectoryInfo(path2).Name;

                    // Recursively call ScanRemove for the subdirectory
                    ScanRemove(d.FullName);
                }
            }
            catch
            {
                // Catch any exceptions that may occur during the process
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {

            // Check if the copy/move/delete combo box is empty
            if (copyMoveDeleteComboBox.Text == "")
            {
                // Display a message informing the user to select directories
                MessageBox.Show("You must have a directory picked for the from and the target directory. " +
                                "You don't need a target directory for the Delete Directory option only!",
                                "Copy That - File/Directory Tool - Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Disable certain buttons and controls
                cancelButton.Enabled = false;
                pauseResumeButton.Enabled = false;
                clearFileListButton.Enabled = false;
            }
            // If the selected operation is 'Copy To Directory'
            else if (copyMoveDeleteComboBox.SelectedItem.ToString() == "Copy To Directory")
            {
                // Check if there are rows in the data grid view and if the target directory is selected
                if ((fileDirDataGridView.Rows.Count > 0) && !(targetDirLabel.Text == "Select Directory"))
                {
                    // Get drive information for the target directory
                    FileInfo f = new FileInfo(targetDirLabel.Text);
                    string drive = Path.GetPathRoot(f.FullName);
                    DriveInfo driveInfo = new DriveInfo(Path.GetPathRoot(drive));
                    long driveSpaceTotal = (GetTotalSpace(drive));
                    // If the drive is ready
                    if (driveInfo.IsReady)
                    {
                        long totalDriveSpace = driveInfo.TotalSize;
                        long freeDriveSpace = driveInfo.TotalFreeSpace;
                        long availableSpaceCopyMove = totalDriveSpace - freeDriveSpace;

                        // Update UI with total available space information
                        totalHDSpaceLeftLabel.Text = "Total Space: " + FormatBytes(availableSpaceCopyMove) + "/" + FormatBytes(driveSpaceTotal) + "";

                        // Check if there's enough space for the copy operation
                        if (totalBytes >= availableSpaceCopyMove)
                        {
                            MessageBox.Show("There is not enough drive space left to perform the copy operation. Please remove some files/folders.",
                                            "Copy That - File/Directory Tool",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    // Enable/disable buttons and controls
                    timeRemainingTimer.Start();
                    startButton.Enabled = false;
                    cancelButton.Enabled = true;
                    pauseResumeButton.Enabled = true;
                    skipButton.Enabled = true;
                    copyMoveDeleteComboBox.Enabled = false;
                    doNotOverwriteCHKBOX.Enabled = false;
                    overwriteAllCHKBOX.Enabled = false;
                    overwriteIfNewerCHKBOX.Enabled = false;
                    keepDirStructCheckBox.Enabled = false;
                    createCustomDirCheckBox.Enabled = false;
                    copyFilesDirsCheckBox.Enabled = false;
                    clearTextButton.Enabled = false;
                    searchTextBox.Enabled = false;
                    fromDirPicBox.Enabled = false;
                    targetDirPicBox.Enabled = false;
                    fileUpPicBox.Enabled = false;
                    fileDownPicBox.Enabled = false;
                    moveTopPicBox.Enabled = false;
                    moveBottomPicBox.Enabled = false;

                    // Log file path
                    string logFilePath = @"\CopyThatLog.txt";
                    logFilePath = Application.StartupPath + logFilePath;

                    // Write log if enabled
                    if (logFileCheckBox.Checked)
                    {
                        using (StreamWriter logWriter = new StreamWriter(logFilePath, true))
                        {
                            logWriter.WriteLine($"Copy process started at {DateTime.Now}");
                            logWriter.WriteLine($"Destination Directory: {targetDirLabel.Text}");
                            logWriter.WriteLine();
                        }
                    }

                    // Run the background worker to perform the copy operation
                    COPYbackgroundWorker.RunWorkerAsync();

                    // Start or stop the timer depending on its current state
                    if (!_timerRunning)
                    {
                        _startTime = DateTime.Now;
                        _totalElapsedTime = _currentElapsedTime;
                        _timer.Start();
                        _timerRunning = true;
                    }
                    else
                    {
                        _timer.Stop();
                        _timerRunning = false;
                    }
                }

                // Disable sorting for columns in the data grid view
                foreach (DataGridViewColumn column in fileDirDataGridView.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                // Enable/disable buttons and controls
                ((Control)this.cmdMainPage).Enabled = true;
                ((Control)this.cmdSkipPage).Enabled = false;
                ((Control)this.cmdAboutPage).Enabled = false;
                ((Control)this.cmdSettingsPage).Enabled = false;
                ((Control)this.cmdCopyHistoryPage).Enabled = false;
                tabControl1.SelectedTab = cmdMainPage;
                stopWatch.Start();
                fileOn = 0;
            }

            else if (copyMoveDeleteComboBox.SelectedItem.ToString() == "Move To Directory")
            {

                if ((fileDirDataGridView.Rows.Count > 0)
                && !(fromFilesDirLabel.Text == "Select Files/Directory"))
                {
                    FileInfo f = new FileInfo(targetDirLabel.Text);
                    string drive = Path.GetPathRoot(f.FullName);
                    //string drive = @"C:\";
                    DriveInfo driveInfo = new DriveInfo(Path.GetPathRoot(drive));
                    if (driveInfo.IsReady)
                    {
                        long driveSpaceTotal;
                        long driveSpaceAvailable;
                        long driveSpaceUsed;
                        long availableSpaceCopyMove;
                        long totalDriveSpace = driveInfo.TotalSize;
                        long freeDriveSpace = driveInfo.TotalFreeSpace;


                        driveSpaceTotal = driveInfo.TotalSize;
                        driveSpaceAvailable = driveInfo.TotalFreeSpace;
                        availableSpaceCopyMove = totalDriveSpace - freeDriveSpace;


                        // MessageBox.Show($"Total Drive Space: {FormatBytes(totalDriveSpace)}");
                        // MessageBox.Show($"Free Drive Space: {FormatBytes(availableSpaceCopyMove)} ");

                        totalHDSpaceLeftLabel.Text = "Total Space: " + FormatBytes(availableSpaceCopyMove) + "/" + FormatBytes(driveSpaceTotal) + "";

                        if (totalBytes >= availableSpaceCopyMove)
                        {
                            MessageBox.Show("There is not enough drive space left to perform the copy operation. Please remove some files/folders.", "Copy That - File/Directory Tool",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                    }
                    startButton.Enabled = false;
                    cancelButton.Enabled = true;
                    pauseResumeButton.Enabled = true;
                    skipButton.Enabled = true;

                    copyMoveDeleteComboBox.Enabled = false;
                    doNotOverwriteCHKBOX.Enabled = false;
                    overwriteAllCHKBOX.Enabled = false;
                    overwriteIfNewerCHKBOX.Enabled = false;
                    keepDirStructCheckBox.Enabled = false;
                    createCustomDirCheckBox.Enabled = false;
                    copyFilesDirsCheckBox.Enabled = false;
                    clearTextButton.Enabled = false;
                    searchTextBox.Enabled = false;
                    fromDirPicBox.Enabled = false;
                    targetDirPicBox.Enabled = false;
                    fileUpPicBox.Enabled = false;
                    fileDownPicBox.Enabled = false;
                    moveTopPicBox.Enabled = false;
                    moveBottomPicBox.Enabled = false;

                    MOVEbackgroundWorker.RunWorkerAsync();

                    //startButton.Enabled = false;

                    // Start the background worker to perform the file copy

                    //If the timer isn't already running
                    if (!_timerRunning)
                    {
                        // Set the start time to Now
                        _startTime = DateTime.Now;

                        // Store the total elapsed time so far
                        _totalElapsedTime = _currentElapsedTime;

                        _timer.Start();
                        _timerRunning = true;
                    }
                    else // If the timer is already running
                    {
                        _timer.Stop();
                        _timerRunning = false;
                    }
                }
                foreach (DataGridViewColumn column in fileDirDataGridView.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                ((Control)this.cmdMainPage).Enabled = true;
                ((Control)this.cmdSkipPage).Enabled = false;
                ((Control)this.cmdAboutPage).Enabled = false;
                ((Control)this.cmdSettingsPage).Enabled = false;
                ((Control)this.cmdCopyHistoryPage).Enabled = false;
                tabControl1.SelectedTab = cmdMainPage;
                stopWatch.Start();
                fileOn = 0;
            }
            // Check if the selected operation is 'Delete Directory'
            else if (copyMoveDeleteComboBox.SelectedItem.ToString() == "Delete Directory")
            {
                // Check if there are rows in the data grid view and if the source directory is selected
                if ((fileDirDataGridView.Rows.Count > 0) && !(fromFilesDirLabel.Text == "Select Files/Directory"))
                {
                    // Disable buttons and controls
                    startButton.Enabled = false;
                    cancelButton.Enabled = true;
                    pauseResumeButton.Enabled = true;
                    skipButton.Enabled = true;
                    copyMoveDeleteComboBox.Enabled = false;
                    doNotOverwriteCHKBOX.Enabled = false;
                    overwriteAllCHKBOX.Enabled = false;
                    overwriteIfNewerCHKBOX.Enabled = false;
                    keepDirStructCheckBox.Enabled = false;
                    createCustomDirCheckBox.Enabled = false;
                    copyFilesDirsCheckBox.Enabled = false;
                    clearTextButton.Enabled = false;
                    searchTextBox.Enabled = false;
                    fromDirPicBox.Enabled = false;
                    targetDirPicBox.Enabled = false;
                    fileUpPicBox.Enabled = false;
                    fileDownPicBox.Enabled = false;
                    moveTopPicBox.Enabled = false;
                    moveBottomPicBox.Enabled = false;

                    // Run the background worker to perform the delete operation
                    DELETEbackgroundWorker.RunWorkerAsync();

                    // Start or stop the timer depending on its current state
                    if (!_timerRunning)
                    {
                        _startTime = DateTime.Now;
                        _totalElapsedTime = _currentElapsedTime;
                        _timer.Start();
                        _timerRunning = true;
                    }
                    else
                    {
                        _timer.Stop();
                        _timerRunning = false;
                    }
                }

                // Disable sorting for columns in the data grid view
                foreach (DataGridViewColumn column in fileDirDataGridView.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                // Enable buttons and controls
                ((Control)this.cmdMainPage).Enabled = true;
                ((Control)this.cmdSkipPage).Enabled = false;
                ((Control)this.cmdAboutPage).Enabled = false;
                ((Control)this.cmdSettingsPage).Enabled = false;
                ((Control)this.cmdCopyHistoryPage).Enabled = false;
                tabControl1.SelectedTab = cmdMainPage;
                stopWatch.Start();
                fileOn = 0;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // Set cancel flag to true
            canceled = true;

            // Cancel any running background workers
            if (MOVEbackgroundWorker.IsBusy == true)
            {
                MOVEbackgroundWorker.CancelAsync();
            }
            if (COPYbackgroundWorker.IsBusy == true)
            {
                COPYbackgroundWorker.CancelAsync();
            }
            if (DELETEbackgroundWorker.IsBusy == true)
            {
                DELETEbackgroundWorker.CancelAsync();
            }

            // Stop and reset the timers if they were running
            timeRemainingTimer.Stop();
            _timer.Stop();
            _timerRunning = false;

            // Enable buttons and controls
            ((Control)this.cmdMainPage).Enabled = true;
            ((Control)this.cmdSkipPage).Enabled = true;
            ((Control)this.cmdAboutPage).Enabled = true;
            ((Control)this.cmdSettingsPage).Enabled = true;
            ((Control)this.cmdCopyHistoryPage).Enabled = true;
            tabControl1.SelectedTab = cmdMainPage;

        }

        private void pauseResumeButton_Click(object sender, EventArgs e)
        {
            // Check if the button text is "Pause"
            if (pauseResumeButton.Text == "Pause")
            {
                // Pause the timer and update button text
                _timer.Stop();
                _timerRunning = false;
                paused = true;
                pauseResumeButton.Text = "Resume";
            }
            else
            {
                // Resume the timer and update button text
                _timer.Start();
                _timerRunning = true;
                paused = false;
                pauseResumeButton.Text = "Pause";
            }

        }
        private void fromDirPicBox_Click(object sender, EventArgs e)
        {
            // Check if the Always On Top option is checked and adjust window behavior accordingly
            if (alwaysOnTopCheckBox.Checked == true)
            {
                // Disable the TopMost property to prevent window always staying on top
                this.TopMost = false;
            }

            // Set flag to disable drag and drop functionality
            noDragDrop = true;

            // Set DataGridView row color back to black
            this.fileDirDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;

            // Open a FolderBrowserDialog to select a directory
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();

            // If a directory is selected
            if (result == DialogResult.OK)
            {
                // Disable various UI controls during directory selection process
                startButton.Enabled = false;
                clearFileListButton.Enabled = false;
                cancelButton.Enabled = false;
                removeFileButton.Enabled = false;
                skipButton.Enabled = false;
                addFileButton.Enabled = false;
                doNotOverwriteCHKBOX.Enabled = false;
                overwriteAllCHKBOX.Enabled = false;
                overwriteIfNewerCHKBOX.Enabled = false;
                clearTextButton.Enabled = false;
                searchTextBox.Enabled = false;
                fromDirPicBox.Enabled = false;
                targetDirPicBox.Enabled = false;
                fileUpPicBox.Enabled = false;
                fileDownPicBox.Enabled = false;
                moveTopPicBox.Enabled = false;
                moveBottomPicBox.Enabled = false;

                // Set the selected directory path
                fromFilesDirLabel.Text = folderDlg.SelectedPath;
                path = folderDlg.SelectedPath;
                string folder = new DirectoryInfo(path).Name;

                // Check if the selected directory is the root directory
                if (folderDlg.SelectedPath == Directory.GetDirectoryRoot(folderDlg.SelectedPath))
                {
                    // Display an error message if trying to perform operations on the root directory
                    MessageBox.Show("You cannot copy/move/delete the root directory!", "Copy That - File/Directory Tool - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    noDragDrop = false;
                }
                else if (fileDirDataGridView.Rows.Count == 0)
                {
                    // If the DataGridView is empty, start background worker to retrieve folder structure
                    if (!getFoldersBackgroundWorker.IsBusy)
                    {
                        getFoldersBackgroundWorker.RunWorkerAsync();
                    }
                    noDragDrop = false;
                }
                else if (fileDirDataGridView.Rows.Count > 0)
                {
                    // If the DataGridView is not empty, check if the selected folder has already been added
                    if (!DoesRowExist(path))
                    {
                        // If the folder doesn't exist in the list, start background worker to retrieve folder structure
                        if (!getFoldersBackgroundWorker.IsBusy)
                        {
                            getFoldersBackgroundWorker.RunWorkerAsync();
                        }
                        noDragDrop = false;
                    }
                    else
                    {
                        // Display an error message if the folder already exists in the list
                        MessageBox.Show("File/Folder was already added to the file/folder list!", "Copy That - File/Directory Tool - File/Folder Already Added!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        noDragDrop = false;
                    }
                }

                // Enable expansion of UI elements if DataGridView has rows
                if (fileDirDataGridView.Rows.Count > 0)
                {
                    ExpandOrRetract();
                }
            }

            // Enable UI controls after directory selection process is completed
            startButton.Enabled = true;
            clearFileListButton.Enabled = true;
            removeFileButton.Enabled = true;
            addFileButton.Enabled = true;
            doNotOverwriteCHKBOX.Enabled = true;
            overwriteAllCHKBOX.Enabled = true;
            overwriteIfNewerCHKBOX.Enabled = true;
            clearTextButton.Enabled = true;
            searchTextBox.Enabled = true;
            fromDirPicBox.Enabled = true;
            targetDirPicBox.Enabled = true;
            fileUpPicBox.Enabled = true;
            fileDownPicBox.Enabled = true;
            moveTopPicBox.Enabled = true;
            moveBottomPicBox.Enabled = true;

            // Check if the Always On Top option is checked and adjust window behavior accordingly
            if (alwaysOnTopCheckBox.Checked == true)
            {
                // Enable the TopMost property to keep window always on top
                this.TopMost = true;
            }

        }


        // Method to retrieve directory statistics recursively
        static DirectoryStatsResult GetDirectoryStats(string rootPath)
        {
            // Initialize the result object to store directory statistics
            DirectoryStatsResult result = new DirectoryStatsResult();

            // Stack to hold directories to be processed
            Stack<string> directoriesToProcess = new Stack<string>();
            directoriesToProcess.Push(rootPath);

            // Access the mainForm instance to update UI elements and check cancellation status
            mainForm fc = (mainForm)Application.OpenForms["mainForm"];

            // If the mainForm instance exists
            if (fc != null)
            {
                // Process directories until the stack is empty
                while (directoriesToProcess.Count > 0)
                {
                    // Get the current directory to process
                    string currentDirectory = directoriesToProcess.Pop();

                    try
                    {
                        // Process files in the current directory
                        string[] files = Directory.GetFiles(currentDirectory);
                        foreach (string file in files)
                        {
                            FileInfo fileInfo = new FileInfo(file);
                            // Check for cancellation and update statistics
                            if (fc.canceled)
                            {
                                if (fc.getFoldersBackgroundWorker.CancellationPending)
                                {
                                    fc.canceled = true;
                                    fc.getFoldersBackgroundWorker.CancelAsync();
                                    break;
                                }
                            }
                            if (fileInfo.Length > 0)
                            {
                                result.TotalSize += fileInfo.Length;
                                result.FileCount++;
                                fc.totalFolderBytes += fileInfo.Length;
                                fc.totalBytes += fileInfo.Length;
                            }
                        }

                        // Process subdirectories and update UI label
                        string[] subdirectories = Directory.GetDirectories(currentDirectory);
                        foreach (string subdirectory in subdirectories)
                        {
                            fc.fromFilesDirLabel.Text = "Scanning: " + subdirectory;
                            directoriesToProcess.Push(subdirectory);
                        }

                        // Calculate directory-specific statistics
                        var directoryStats = new DirectoryStatsResult
                        {
                            FileCount = files.Length,
                            TotalSize = files.Sum(file => new FileInfo(file).Length)
                        };

                        // Update result object with directory statistics
                        result.DirectorySizes[currentDirectory] = directoryStats;

                        // Update parent directory with subdirectory stats
                        var parentDirectory = Path.GetDirectoryName(currentDirectory);
                        if (!string.IsNullOrEmpty(parentDirectory) && result.DirectorySizes.ContainsKey(parentDirectory))
                        {
                            result.DirectorySizes[parentDirectory].Subdirectories[currentDirectory] = directoryStats;
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // Handle unauthorized access exception by restarting the application or exiting
                        if (fc.restartCheckBox.Checked == true)
                        {
                            Application.Restart();
                            Environment.Exit(0);
                        }
                        else
                        {
                            fc.exitPlease();
                        }
                    }
                }
                // Update UI label with the root directory path
                fc.fromFilesDirLabel.Text = rootPath;
            }

            // Return the directory statistics result
            return result;
        }



        // Method to calculate directory statistics by subtracting file sizes
        static DirectoryStatsResult GetDirectoryStats2(string rootPath)
        {
            // Initialize the result object to store directory statistics
            DirectoryStatsResult result = new DirectoryStatsResult();

            // Stack to hold directories to be processed
            Stack<string> directoriesToProcess = new Stack<string>();
            directoriesToProcess.Push(rootPath);

            // Access the mainForm instance to update UI elements
            mainForm fc = (mainForm)Application.OpenForms["mainForm"];

            // If the mainForm instance exists
            if (fc != null)
            {
                // Process directories until the stack is empty
                while (directoriesToProcess.Count > 0)
                {
                    // Get the current directory to process
                    string currentDirectory = directoriesToProcess.Pop();

                    try
                    {
                        // Process files in the current directory
                        string[] files = Directory.GetFiles(currentDirectory);
                        foreach (string file in files)
                        {
                            FileInfo fileInfo = new FileInfo(file);
                            // Subtract file sizes from the total and update UI counters
                            result.TotalSize -= fileInfo.Length;
                            result.FileCount--;
                            fc.totalFolderBytes -= fileInfo.Length;
                            fc.totalBytes -= fileInfo.Length;
                        }

                        // Process subdirectories
                        string[] subdirectories = Directory.GetDirectories(currentDirectory);
                        foreach (string subdirectory in subdirectories)
                        {
                            directoriesToProcess.Push(subdirectory);
                        }

                        // Calculate directory-specific statistics
                        var directoryStats = new DirectoryStatsResult
                        {
                            FileCount = files.Length,
                            TotalSize = files.Sum(file => new FileInfo(file).Length)
                        };

                        // Update result object with directory statistics
                        result.DirectorySizes[currentDirectory] = directoryStats;

                        // Update parent directory with subdirectory stats
                        var parentDirectory = Path.GetDirectoryName(currentDirectory);
                        if (!string.IsNullOrEmpty(parentDirectory) && result.DirectorySizes.ContainsKey(parentDirectory))
                        {
                            result.DirectorySizes[parentDirectory].Subdirectories[currentDirectory] = directoryStats;
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // Handle unauthorized access exception by restarting the application or exiting
                        if (fc.restartCheckBox.Checked == true)
                        {
                            Application.Restart();
                            Environment.Exit(0);
                        }
                        else
                        {
                            fc.exitPlease();
                        }
                    }
                }
            }

            // Return the directory statistics result
            return result;
        }


        // Method to format bytes into human-readable format
        static string FormatBytes(long bytes)
        {
            // Array of byte size suffixes
            string[] suffixes = { "B", "KB", "MB", "GB", "TB" };

            // Initialize index and size
            int index = 0;
            double size = bytes;

            // Iterate through suffixes until size is less than 1024 or end of suffixes array
            while (size >= 1024 && index < suffixes.Length - 1)
            {
                size /= 1024;
                index++;
            }

            // Format size and suffix and return
            return $"{size:00.##} {suffixes[index]}";
        }

        // Class to store directory statistics
        class DirectoryStatsResult
        {
            // Properties for file count, total size, directory sizes, and subdirectories
            public int FileCount { get; set; }
            public long TotalSize { get; set; }
            public Dictionary<string, DirectoryStatsResult> DirectorySizes { get; } = new Dictionary<string, DirectoryStatsResult>();
            public Dictionary<string, DirectoryStatsResult> Subdirectories { get; } = new Dictionary<string, DirectoryStatsResult>();
        }
        private void targetDirPicBox_Click(object sender, EventArgs e)
        {
            // Enable automatic generation of columns for the DataGridView
            this.fileDirDataGridView.AutoGenerateColumns = true;

            // Create a new instance of FolderBrowserDialog
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();

            // Allow the creation of new folders in the dialog
            folderDlg.ShowNewFolderButton = true;

            // Show the FolderBrowserDialog
            DialogResult result = folderDlg.ShowDialog();

            // Check if the user selected a folder
            if (result == DialogResult.OK)
            {
                // Set the selected folder path to the target directory label
                targetDirLabel.Text = folderDlg.SelectedPath;

                // Get the root folder of the selected path
                Environment.SpecialFolder root = folderDlg.RootFolder;

                // Enable or disable the start button based on whether a source directory is selected
                // Uncomment the following lines if enabling/disabling the start button based on source directory selection is desired
                /*
                if (!(fromFilesDirLabel.Text == "Select Files/Directory"))
                {
                    startButton.Enabled = true;
                }
                else
                {
                    startButton.Enabled = false;
                }
                */
            }

        }

        private void skipButton_Click(object sender, EventArgs e)
        {
            skipFileUser = true;
        }

        private void filePathLabel_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the left mouse button is clicked
            if (e.Button == MouseButtons.Left)
            {
                // Release the capture of the mouse
                ReleaseCapture();

                // Send a message to the window to simulate a left mouse button down event on the title bar,
                // allowing the form to be dragged
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

        }

        private void fromFilesDirLabel_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the left mouse button is clicked
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture
                ReleaseCapture();

                // Send a message to the window to simulate a left mouse button down event on the title bar,
                // enabling the user to drag the form
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

        }

        private void targetDirLabel_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the left mouse button is clicked
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture
                ReleaseCapture();

                // Send a message to the window to simulate a left mouse button down event on the title bar,
                // enabling the user to drag the form
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void targetLabel_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the left mouse button is clicked
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture
                ReleaseCapture();

                // Send a message to the window to simulate a left mouse button down event on the title bar,
                // enabling the user to drag the form
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void fromLabel_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the left mouse button is clicked
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture
                ReleaseCapture();

                // Send a message to the window to simulate a left mouse button down event on the title bar,
                // enabling the user to drag the form
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void fileNameLabel_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the left mouse button is clicked
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture
                ReleaseCapture();

                // Send a message to the window to simulate a left mouse button down event on the title bar,
                // enabling the user to drag the form
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the left mouse button is clicked
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture
                ReleaseCapture();

                // Send a message to the window to simulate a left mouse button down event on the title bar,
                // enabling the user to drag the form
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void clearTextButton_Click(object sender, EventArgs e)
        {
            searchTextBox.Text = string.Empty;
            searchTextBox.Focus();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            // Get the search string from the search text box and convert it to lowercase
            string searchString = searchTextBox.Text.ToLower();

            // Iterate through each row in the DataGridView
            foreach (DataGridViewRow row in fileDirDataGridView.Rows)
            {
                // Get the values from the cells you want to search in and convert them to lowercase
                string cellValue1 = row.Cells[2].Value.ToString().ToLower();
                string cellValue2 = row.Cells[3].Value.ToString().ToLower();

                // Check if the search string is contained in any of the cells
                if (cellValue1.Contains(searchString) || cellValue2.Contains(searchString))
                {
                    // Select the row if a match is found
                    row.Selected = true;

                    // Scroll to the selected row (optional)
                    fileDirDataGridView.FirstDisplayedScrollingRowIndex = row.Index;

                    // Break the loop after the first match (optional)
                    break;
                }
                else
                {
                    // Deselect the row if no match is found
                    row.Selected = false;
                }
            }

        }

        private void fileUpPicBox_Click(object sender, EventArgs e)
        {
            try
            {
                // Attempt to move the selected row up
                DataGridViewRow row = new DataGridViewRow();
                int index = fileDirDataGridView.SelectedRows[0].Index;

                // If the selected row is already at the top, return without doing anything
                if (index == 0)
                {
                    return;
                }
                else
                {
                    row = fileDirDataGridView.SelectedRows[0];

                    // Remove the selected row and insert it one position up
                    fileDirDataGridView.Rows.Remove(fileDirDataGridView.SelectedRows[0]);
                    fileDirDataGridView.Rows.Insert(index - 1, row);

                    // Clear the selection and select the row that moved up
                    fileDirDataGridView.ClearSelection();
                    fileDirDataGridView.Rows[index - 1].Selected = true;
                }
            }
            catch
            {
                // Handle any exceptions silently
            }

        }

        private void fileDownPicBox_Click(object sender, EventArgs e)
        {
            try
            {
                // Attempt to move the selected row down
                DataGridViewRow row = new DataGridViewRow();
                int index = fileDirDataGridView.SelectedRows[0].Index;

                // If the selected row is already at the bottom, return without doing anything
                if (index == fileDirDataGridView.Rows.Count - 1)
                {
                    return;
                }
                else
                {
                    row = fileDirDataGridView.SelectedRows[0];

                    // Remove the selected row and insert it one position down
                    fileDirDataGridView.Rows.Remove(fileDirDataGridView.SelectedRows[0]);
                    fileDirDataGridView.Rows.Insert(index + 1, row);

                    // Clear the selection and select the row that moved down
                    fileDirDataGridView.ClearSelection();
                    fileDirDataGridView.Rows[index + 1].Selected = true;
                }
            }
            catch { }

        }

        private void moveTopPicBox_Click(object sender, EventArgs e)
        {
            try
            {
                // Attempt to move the selected row up
                int index = fileDirDataGridView.SelectedRows[0].Index;
                DataGridViewRow row = new DataGridViewRow();

                // If the selected row is already at the top, return without doing anything
                if (index == 0)
                {
                    return;
                }
                else
                {
                    // Move the selected row up to the top
                    row = fileDirDataGridView.SelectedRows[0];
                    fileDirDataGridView.Rows.Remove(fileDirDataGridView.SelectedRows[0]);
                    fileDirDataGridView.Rows.Insert(0, row);

                    // Clear the selection and select the row that moved up
                    fileDirDataGridView.ClearSelection();
                    fileDirDataGridView.Rows[0].Selected = true;
                }
            }
            catch
            {

            }

        }

        private void moveBottomPicBox_Click(object sender, EventArgs e)
        {
            try
            {
                // Attempt to move the selected row down
                int index = fileDirDataGridView.SelectedRows[0].Index;
                DataGridViewRow row = new DataGridViewRow();

                // If the selected row is already at the bottom, return without doing anything
                if (index == fileDirDataGridView.Rows.Count - 1)
                {
                    return;
                }
                else
                {
                    // Move the selected row down to the bottom
                    index = fileDirDataGridView.Rows.Count - 1;
                    row = fileDirDataGridView.SelectedRows[0];
                    fileDirDataGridView.Rows.Remove(fileDirDataGridView.SelectedRows[0]);
                    fileDirDataGridView.Rows.Insert(index, row);

                    // Clear the selection and select the row that moved down
                    fileDirDataGridView.ClearSelection();
                    fileDirDataGridView.Rows[index].Selected = true;
                }
            }
            catch { }

        }

        private void addFileButton_Click(object sender, EventArgs e)
        {
            noDragDrop = true;

            // Show the OpenFileDialog
            DialogResult dr = this.openFileDialog.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                // Disable buttons while processing files
                startButton.Enabled = false;
                clearFileListButton.Enabled = false;
                cancelButton.Enabled = false;
                removeFileButton.Enabled = false;
                skipButton.Enabled = false;
                addFileButton.Enabled = false;

                // Read and process the selected files
                foreach (String file in openFileDialog.FileNames)
                {
                    string fileNow = file.ToString();
                    var fileInfoNow = new FileInfo(fileNow);

                    // Check if file size is greater than 0
                    if (fileInfoNow.Length > 0)
                    {
                        try
                        {
                            // Set the DataGridView row color to black
                            this.fileDirDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;

                            if (!DoesRowExist(path))
                            {
                                // Add a new row for the selected file
                                if (File.Exists(file))
                                {
                                    var fi2 = new FileInfo(file);
                                    this.fileDirDataGridView.Rows.Add(Havoc__Copy_That.Properties.Resources.icons8_file_40, "File", fi2.FullName.ToString(), fi2.Name.ToString(), ConvertBytesToMegabytes(fileInfoNow.Length).ToString("00.00 MB"));

                                    // Update file count and total bytes
                                    num++;
                                    totalBytes += fi2.Length;
                                    this.fileCountOnLabel.Text = "File Count: 0/" + num.ToString("N0") + "";
                                    totalCopiedProgressLabel.Text = "Total C/M/D: 0/" + FormatBytes(totalBytes);
                                }

                                // Expand the DataGridView if necessary
                                ExpandOrRetract();
                            }
                            else
                            {
                                // Show error message if file/folder already exists in the list
                                MessageBox.Show("File/Folder was already added to the file/folder list!", "Copy That - File/Directory Tool - File/Folder Already Added!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                noDragDrop = false;
                                return;
                            }
                        }
                        catch (SecurityException ex)
                        {
                            // Handle security exception
                            MessageBox.Show("Security error!\n\n" +
                                "Error message: " + ex.Message + "\n\n" +
                                "Details:\n\n" + ex.StackTrace + "", "Copy That - File/Directory Tool - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            // Handle other exceptions
                            MessageBox.Show("Cannot display the file: (" + fileInfoNow.Name + ")"
                            + ". You may not have permission to read the file, or " +
                            "it may be corrupt.\n\nReported error: " + ex.Message + "", "Copy That - File/Directory Tool - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                // Enable buttons if no files are selected
                noDragDrop = false;
            }

            // Enable buttons after file processing
            startButton.Enabled = true;
            clearFileListButton.Enabled = true;
            removeFileButton.Enabled = true;
            addFileButton.Enabled = true;

        }

        private void removeFileButton_Click(object sender, EventArgs e)
        {
            // Check if the DataGridView has rows
            if (fileDirDataGridView.Rows.Count > 0)
            {
                // Disable relevant controls while processing
                ((Control)this.cmdMainPage).Enabled = false;
                ((Control)this.cmdSkipPage).Enabled = false;
                ((Control)this.cmdAboutPage).Enabled = false;
                ((Control)this.cmdSettingsPage).Enabled = false;
                ((Control)this.cmdCopyHistoryPage).Enabled = false;
                tabControl1.SelectedTab = cmdMainPage;

                // Check if any row is selected
                if (this.fileDirDataGridView.SelectedRows.Count > 0)
                {
                    try
                    {
                        // Get the value of the selected cell
                        string CellValue = this.fileDirDataGridView.CurrentRow.Cells[2].Value.ToString();
                        string fileNow = CellValue;
                        var fileInfoNow = new FileInfo(fileNow);

                        // Check if any cell is selected
                        if (fileDirDataGridView.SelectedCells.Count > 0)
                        {
                            // Set the DataGridView row color to black
                            this.fileDirDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;

                            // Check if the selected item is a directory
                            if (Directory.Exists(CellValue))
                            {
                                // Update the path and initiate background worker to remove directory
                                string folder = new DirectoryInfo(path).Name;
                                path = CellValue;
                                if (!removeDirBGW.IsBusy)
                                {
                                    removeDirBGW.RunWorkerAsync();
                                }
                            }
                            else
                            {
                                // Update file count and total bytes, and remove the selected row
                                num--;
                                totalBytes -= fileInfoNow.Length;
                                this.fileCountOnLabel.Text = "File Count: 0/" + num.ToString("N0") + "";
                                totalCopiedProgressLabel.Text = "Total C/M/D: 0/" + FormatBytes(totalBytes);
                                fileDirDataGridView.Rows.RemoveAt(this.fileDirDataGridView.SelectedRows[0].Index);

                                // Collapse DataGridView if it's empty
                                if (fileDirDataGridView.Rows.Count == 0)
                                {
                                    ExpandOrRetract();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        MessageBox.Show("Error: " + ex.Message, "Copy That - File/Directory Tool - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // Enable controls after processing
            ((Control)this.cmdMainPage).Enabled = true;
            ((Control)this.cmdSkipPage).Enabled = true;
            ((Control)this.cmdAboutPage).Enabled = true;
            ((Control)this.cmdSettingsPage).Enabled = true;
            ((Control)this.cmdCopyHistoryPage).Enabled = true;
            tabControl1.SelectedTab = cmdMainPage;

        }

        private void clearFileListButton_Click(object sender, EventArgs e)
        {
            // Check if the DataGridView has rows
            if (fileDirDataGridView.Rows.Count > 0)
            {
                // Display the Yes/No/Cancel dialog box
                DialogResult result = MessageBox.Show("Would you like to clear all items in the list?", "Clear All Items In List?", MessageBoxButtons.YesNoCancel);

                // Check the user's choice
                if (result == DialogResult.Yes)
                {
                    // Reset counters and labels
                    num = 0;
                    totalBytes = 0;
                    totalBytesProcessed = 0;
                    totalPercentDouble = 0;
                    pct = 0;

                    // Clear controls and labels
                    copyMoveDeleteComboBox.Text = string.Empty;
                    totalCopiedProgressLabel.Text = "Total C/M/D: 0/0 Bytes";
                    elapsedTimeLabel.Text = "Elapsed Time: 00:00:00";
                    timeRemainingLabel.Text = "Time Remaining: 00:00:00";
                    totalProgressBar.Value = 0;
                    fileProgressBar.Value = 0;
                    totalProgressLabel.Text = "0%";
                    fileTotalProgressLabel.Text = "0%";
                    fileCountOnLabel.Text = "File Count: 0/0";
                    filePathLabel.Text = "Nothing";
                    fromFilesDirLabel.Text = "Select Files/Directory";
                    targetDirLabel.Text = "Select Files/Directory";
                    fileProcessedLabel.Text = "File Processed: 0/0 Bytes";
                    speedLabel.Text = "Speed: 0 Mb/Sec.";

                    // Enable/disable buttons
                    startButton.Enabled = true;
                    cancelButton.Enabled = false;
                    pauseResumeButton.Enabled = false;
                    clearFileListButton.Enabled = true;
                    canceled = false;
                    skipButton.Enabled = false;

                    // Clear DataGridView
                    fileDirDataGridView.Rows.Clear();

                    // Collapse DataGridView
                    ExpandOrRetract();
                }
                else if (result == DialogResult.No)
                {
                    // Perform action for No (optional)
                }
                else if (result == DialogResult.Cancel)
                {
                    // Perform action for Cancel (optional)
                }
            }

        }

        private void fileCountOnLabel_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the left mouse button is clicked
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture from the control
                ReleaseCapture();

                // Send a message to the control to simulate a left mouse button down event on the window caption
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void elapsedTimeLabel_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the left mouse button is clicked
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture from the control
                ReleaseCapture();

                // Send a message to the control to simulate a left mouse button down event on the window caption
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void fileProcessedLabel_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the left mouse button is clicked
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture from the control
                ReleaseCapture();

                // Send a message to the control to simulate a left mouse button down event on the window caption
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void speedLabel_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the left mouse button is clicked
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture from the control
                ReleaseCapture();

                // Send a message to the control to simulate a left mouse button down event on the window caption
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void totalCopiedProgressLabel_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the left mouse button is clicked
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture from the control
                ReleaseCapture();

                // Send a message to the control to simulate a left mouse button down event on the window caption
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void timeRemainingLabel_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the left mouse button is clicked
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture from the control
                ReleaseCapture();

                // Send a message to the control to simulate a left mouse button down event on the window caption
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void RemoveDuplicateRows(DataGridView dataGridView)
        {
            // This method removes duplicate rows from a DataGridView

            // Define a HashSet to store unique string representations of rows
            HashSet<string> uniqueRows = new HashSet<string>();

            // Define a list to store rows that need to be removed
            List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();

            // Iterate through each row in the DataGridView
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Build a unique string representation of the row's values
                string rowString = string.Join(",", Array.ConvertAll(row.Cells.Cast<DataGridViewCell>().ToArray(), cell => cell.Value));

                // Check if the rowString is already in the HashSet
                if (!uniqueRows.Add(rowString))
                {
                    // If it's a duplicate, mark the row for removal
                    rowsToRemove.Add(row);
                }
            }

            // Remove duplicate rows
            foreach (DataGridViewRow rowToRemove in rowsToRemove)
            {
                dataGridView.Rows.Remove(rowToRemove);
            }

            // Reset the duplicateRows flag
            duplicateRows = false;
        }

        private void cmdMainPage_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the left mouse button is clicked
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture from the control
                ReleaseCapture();

                // Send a message to the control to simulate a left mouse button down event on the window caption
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void mainForm_DragEnter(object sender, DragEventArgs e)
        {
            // Toggle the form's "TopMost" property based on the state of the alwaysOnTopCheckBox
            if (alwaysOnTopCheckBox.Checked)
            {
                this.TopMost = false; // Set TopMost to false when the checkbox is checked
            }
            else
            {
                this.TopMost = false; // Set TopMost to false when the checkbox is unchecked (redundant, consider removing)
            }

            // If drag and drop functionality is enabled...
            if (!noDragDrop)
            {
                // Check if the data being dragged is in the format of files
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    // Allow copying files when dragged onto the form
                    e.Effect = DragDropEffects.Copy;
                }
            }
            else
            {
                return; // Exit the method if drag and drop functionality is disabled
            }

            // Toggle the form's "TopMost" property based on the state of the alwaysOnTopCheckBox
            if (alwaysOnTopCheckBox.Checked)
            {
                this.TopMost = true; // Set TopMost to true when the checkbox is checked
            }

        }

        private void mainForm_DragDrop(object sender, DragEventArgs e)
        {

            // Check if the confirmDragDropCheckBox is checked
            if (confirmDragDropCheckBox.Checked == true)
            {
                // Display a dialog box to confirm whether to add the copied files/folders to the list
                DialogResult result = MessageBox.Show("Would you like to add the copied file/folders to the list?", "Add All Items to List?", MessageBoxButtons.YesNo);

                // Check the user's choice
                if (result == DialogResult.Yes)
                {
                    // Check if background workers are not busy
                    if (getFoldersBackgroundWorker.IsBusy == false && COPYbackgroundWorker.IsBusy == false
                        && MOVEbackgroundWorker.IsBusy == false && DELETEbackgroundWorker.IsBusy == false)
                    {
                        // Disable various buttons and controls to prevent user input during processing
                        startButton.Enabled = false;
                        clearFileListButton.Enabled = false;
                        cancelButton.Enabled = false;
                        removeFileButton.Enabled = false;
                        skipButton.Enabled = false;
                        addFileButton.Enabled = false;
                        doNotOverwriteCHKBOX.Enabled = false;
                        overwriteAllCHKBOX.Enabled = false;
                        overwriteIfNewerCHKBOX.Enabled = false;
                        clearTextButton.Enabled = false;
                        searchTextBox.Enabled = false;
                        fromDirPicBox.Enabled = false;
                        targetDirPicBox.Enabled = false;
                        fileUpPicBox.Enabled = false;
                        fileDownPicBox.Enabled = false;
                        moveTopPicBox.Enabled = false;
                        moveBottomPicBox.Enabled = false;

                        // Get the paths of the copied files/folders
                        string[] paths = e.Data.GetData(DataFormats.FileDrop) as string[];

                        // Proceed if paths are not null and contain items
                        if (paths != null && paths.Length > 0)
                        {
                            // Disable navigation between different tabs
                            ((Control)this.cmdMainPage).Enabled = false;
                            ((Control)this.cmdSkipPage).Enabled = false;
                            ((Control)this.cmdAboutPage).Enabled = false;
                            ((Control)this.cmdSettingsPage).Enabled = false;
                            ((Control)this.cmdCopyHistoryPage).Enabled = false;
                            tabControl1.SelectedTab = cmdMainPage;

                            try
                            {
                                // Set the row template's default cell style
                                this.fileDirDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;

                                // Check if alwaysOnTopCheckBox is checked and set TopMost property accordingly
                                if (alwaysOnTopCheckBox.Checked == true)
                                {
                                    this.TopMost = false;
                                }

                                // Check if the first path is a directory
                                if (Directory.Exists(paths[0]))
                                {
                                    string rootDir = Path.GetPathRoot(paths[0].ToString());
                                    pathRoot = rootDir.ToString();
                                    fromFilesDirLabel.Text = paths[0].ToString();
                                    string fileNow = paths[0].ToString();
                                    var fileInfoNow = new FileInfo(fileNow);
                                    path = paths[0];
                                    // Start the background worker to calculate directory size
                                    if (!fileDirSizeBGW.IsBusy)
                                    {
                                        fileDirSizeBGW.RunWorkerAsync(paths);
                                    }
                                }
                                else
                                {
                                    // Check if the file exists
                                    if (File.Exists(path))
                                    {
                                        string rootDir = Path.GetPathRoot(paths[0].ToString());
                                        pathRoot = rootDir.ToString();
                                        fromFilesDirLabel.Text = paths[0].ToString();
                                        string fileNow = paths[0].ToString();
                                        var fileInfoNow = new FileInfo(fileNow);

                                        var fi2 = new FileInfo(paths[0]);

                                        if (fi2.Length > 0)
                                        {
                                            // Check if the row already exists in the DataGridView
                                            if (!DoesRowExist(path))
                                            {
                                                // Add the file to the DataGridView
                                                this.fileDirDataGridView.Rows.Add(Havoc__Copy_That.Properties.Resources.icons8_file_40, "File", fi2.FullName.ToString(), fi2.Name.ToString(), ConvertBytesToMegabytes(fileInfoNow.Length).ToString("00.00 MB"));
                                                num++;
                                                totalBytes += fi2.Length;
                                                this.fileCountOnLabel.Text = "File Count: 0/" + num.ToString("N0") + "";
                                                totalCopiedProgressLabel.Text = "Total C/M/D: 0/" + FormatBytes(totalBytes);
                                                // Play a sound if onAddFilesCheckBox is checked
                                                if (onAddFilesCheckBox.Checked)
                                                {
                                                    System.IO.Stream str = Properties.Resources.OnAddFiles;
                                                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                                                    snd.Play();
                                                }
                                            }
                                            else
                                            {
                                                // Display a message if the file/folder is already added to the list
                                                MessageBox.Show("File/Folder was already added to the file/folder list!", "Copy That - File/Directory Tool - File/Folder Already Added!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                // Display an error message if an exception occurs
                                MessageBox.Show("Error: " + ex.Message, "Copy That - File/Directory Tool - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                startButton.Enabled = true;
                            }
                        }
                    }
                }

                else if (result == DialogResult.No)
                {
                    // Perform action for No
                }

                // Enable various buttons and controls after the operation
                startButton.Enabled = true;
                clearFileListButton.Enabled = true;
                removeFileButton.Enabled = true;
                addFileButton.Enabled = true;
                doNotOverwriteCHKBOX.Enabled = true;
                overwriteAllCHKBOX.Enabled = true;
                overwriteIfNewerCHKBOX.Enabled = true;
                clearTextButton.Enabled = true;
                searchTextBox.Enabled = true;
                fromDirPicBox.Enabled = true;
                targetDirPicBox.Enabled = true;
                fileUpPicBox.Enabled = true;
                fileDownPicBox.Enabled = true;
                moveTopPicBox.Enabled = true;
                moveBottomPicBox.Enabled = true;
            }
            else
            {
                // Check if no other background worker is currently busy
                if (getFoldersBackgroundWorker.IsBusy == false && COPYbackgroundWorker.IsBusy == false
                    && MOVEbackgroundWorker.IsBusy == false && DELETEbackgroundWorker.IsBusy == false)
                {
                    // Disable various buttons and controls during the operation
                    startButton.Enabled = false;
                    clearFileListButton.Enabled = false;
                    cancelButton.Enabled = false;
                    removeFileButton.Enabled = false;
                    skipButton.Enabled = false;
                    addFileButton.Enabled = false;
                    doNotOverwriteCHKBOX.Enabled = false;
                    overwriteAllCHKBOX.Enabled = false;
                    overwriteIfNewerCHKBOX.Enabled = false;
                    clearTextButton.Enabled = false;
                    searchTextBox.Enabled = false;
                    fromDirPicBox.Enabled = false;
                    targetDirPicBox.Enabled = false;
                    fileUpPicBox.Enabled = false;
                    fileDownPicBox.Enabled = false;
                    moveTopPicBox.Enabled = false;
                    moveBottomPicBox.Enabled = false;

                    // Get the paths of the dropped files/folders
                    string[] paths = e.Data.GetData(DataFormats.FileDrop) as string[];

                    // If paths are valid and not null
                    if (paths != null && paths.Length > 0)
                    {
                        // Disable certain buttons and select the main page tab
                        ((Control)this.cmdMainPage).Enabled = false;
                        ((Control)this.cmdSkipPage).Enabled = false;
                        ((Control)this.cmdAboutPage).Enabled = false;
                        ((Control)this.cmdSettingsPage).Enabled = false;
                        ((Control)this.cmdCopyHistoryPage).Enabled = false;
                        tabControl1.SelectedTab = cmdMainPage;


                        try
                        {
                            // Set the default row style to black color
                            this.fileDirDataGridView.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;

                            // Check if the dropped item is a directory
                            if (Directory.Exists(paths[0]))
                            {
                                // Set the root directory path and update the UI
                                string rootDir = Path.GetPathRoot(paths[0].ToString());
                                pathRoot = rootDir.ToString();
                                fromFilesDirLabel.Text = paths[0].ToString();
                                string fileNow = paths[0].ToString();
                                var fileInfoNow = new FileInfo(fileNow);
                                path = paths[0];

                                // Start the background worker to calculate directory size if it's not busy
                                if (!fileDirSizeBGW.IsBusy)
                                {
                                    fileDirSizeBGW.RunWorkerAsync(paths);
                                }
                            }
                            else
                            {
                                // If the dropped item is a file
                                if (File.Exists(path))
                                {
                                    string rootDir = Path.GetPathRoot(paths[0].ToString());
                                    pathRoot = rootDir.ToString();
                                    fromFilesDirLabel.Text = paths[0].ToString();
                                    string fileNow = paths[0].ToString();
                                    var fileInfoNow = new FileInfo(fileNow);

                                    var fi2 = new FileInfo(paths[0]);

                                    // Check if the file is not empty and not already in the list
                                    if (fi2.Length > 0)
                                    {
                                        if (!DoesRowExist(path))
                                        {
                                            // Add the file to the DataGridView
                                            this.fileDirDataGridView.Rows.Add(Havoc__Copy_That.Properties.Resources.icons8_file_40, "File", fi2.FullName.ToString(), fi2.Name.ToString(), ConvertBytesToMegabytes(fileInfoNow.Length).ToString("00.00 MB"));

                                            // Update counters and progress labels
                                            num++;
                                            totalBytes += fi2.Length;
                                            this.fileCountOnLabel.Text = "File Count: 0/" + num.ToString("N0") + "";
                                            totalCopiedProgressLabel.Text = "Total C/M/D: 0/" + FormatBytes(totalBytes);
                                        }
                                        else
                                        {
                                            // Display a message if the file is already in the list
                                            MessageBox.Show("File/Folder was already added to the file/folder list!", "Copy That - File/Directory Tool - File/Folder Already Added!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle any exceptions that might occur during the process
                            MessageBox.Show("Error: " + ex.Message, "Copy That - File/Directory Tool - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            startButton.Enabled = true;
                        }

                    }
                }

                // Enable all UI elements for interaction
                startButton.Enabled = true;
                clearFileListButton.Enabled = true;
                removeFileButton.Enabled = true;
                addFileButton.Enabled = true;
                doNotOverwriteCHKBOX.Enabled = true;
                overwriteAllCHKBOX.Enabled = true;
                overwriteIfNewerCHKBOX.Enabled = true;
                clearTextButton.Enabled = true;
                searchTextBox.Enabled = true;
                fromDirPicBox.Enabled = true;
                targetDirPicBox.Enabled = true;
                fileUpPicBox.Enabled = true;
                fileDownPicBox.Enabled = true;
                moveTopPicBox.Enabled = true;
                moveBottomPicBox.Enabled = true;
            }
        }

        /// <summary>
        /// Checks if a row with a specified value already exists in the DataGridView.
        /// </summary>
        /// <param name="valueToCheck">The value to check for in the DataGridView.</param>
        /// <returns>True if a row with the specified value exists, otherwise false.</returns>
        bool DoesRowExist(string valueToCheck)
        {
            foreach (DataGridViewRow row in this.fileDirDataGridView.Rows)
            {
                // Check the value in column index 2 (adjust the index as needed)
                if (row.Cells[2].Value != null && row.Cells[2].Value.ToString() == valueToCheck)
                {
                    // Select the row and scroll to it
                    row.Selected = true;
                    fileDirDataGridView.FirstDisplayedScrollingRowIndex = row.Index;
                    return true; // Row with the specified value already exists
                }
            }

            return false; // Row does not exist
        }

        private void fileDirSizeBGW_DoWork(object sender, DoWorkEventArgs e)
        {

            string[] paths = e.Argument as string[];

            if (paths != null && paths.Length > 0)
            {
                // Iterate through each path and process the files
                foreach (string path in paths)
                {
                    string fileNow = path.ToString();
                    var fileInfoNow = new FileInfo(fileNow);

                    // Check if the path is a directory
                    if (Directory.Exists(path))
                    {
                        // Get directory statistics
                        var directoryStats = GetDirectoryStats(path);
                        num += directoryStats.FileCount;
                        newFolder += directoryStats.FileCount;

                        // If the directory is not empty
                        if (newFolder > 0)
                        {
                            // Check if the row exists in the DataGridView
                            if (!DoesRowExist(path))
                            {
                                // Add folder information to the DataGridView
                                this.fileDirDataGridView.Rows.Add(Havoc__Copy_That.Properties.Resources.icons8_folder_40, "Folder", path.ToString(), fileInfoNow.Name.ToString(), ConvertBytesToMegabytes(totalFolderBytes).ToString("00.00 MB"));
                                fileCountOnLabel.Text = ($"File Count: 0/{num.ToString("N0")}");
                                totalCopiedProgressLabel.Text = ($"Total C/M/D: 0/{FormatBytes(totalBytes)}");

                                // Select the last row
                                int lastIndex = fileDirDataGridView.Rows.Count - 1;
                                fileDirDataGridView.Rows[lastIndex].Selected = true;
                                fileDirDataGridView.FirstDisplayedScrollingRowIndex = lastIndex;
                                searchTextBox.Focus();

                                // Play notification sound if enabled
                                if (onAddFilesCheckBox.Checked)
                                {
                                    System.IO.Stream str = Properties.Resources.OnAddFiles;
                                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                                    snd.Play();
                                }
                            }
                            else
                            {
                                MessageBox.Show("File/Folder was already added to the file/folder list!", "Copy That - File/Directory Tool - File/Folder Already Added!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cannot add (" + path.ToString() + ")  to the list of files/folders because it is empty",
                                "Copy That - File/Directory Tool - Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Root directory not found.");
                    }
                    totalFolderBytes = 0;
                }
            }
        }


        // This method converts bytes to megabytes.
        static double ConvertBytesToMegabytes(long bytes)
        {
            // Divide bytes by 1024 twice to get megabytes
            return (bytes / 1024f) / 1024f;
        }
        private void fileDirSizeBGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Update the label to display the path
            fromFilesDirLabel.Text = path;

            // Enable the navigation buttons and select the main page
            ((Control)this.cmdMainPage).Enabled = true;
            ((Control)this.cmdSkipPage).Enabled = true;
            ((Control)this.cmdAboutPage).Enabled = true;
            ((Control)this.cmdSettingsPage).Enabled = true;
            ((Control)this.cmdCopyHistoryPage).Enabled = true;
            tabControl1.SelectedTab = cmdMainPage;

            // If new folders were added, select the last row and trigger expansion animation
            if (newFolder > 0)
            {
                // Select the last row
                int lastIndex = fileDirDataGridView.Rows.Count - 1;
                fileDirDataGridView.Rows[lastIndex].Selected = true;
                fileDirDataGridView.FirstDisplayedScrollingRowIndex = lastIndex;

                // Trigger expansion animation
                ExpandOrRetract();

                // Set focus to the search box
                searchTextBox.Focus();

                // Reset newFolder counter
                newFolder = 0;
            }

        }

        private void removeDirBGW_DoWork(object sender, DoWorkEventArgs e)
        {
            string fileNow = path.ToString();
            var fileInfoNow = new FileInfo(fileNow);

            // Check if the path is a directory
            if (Directory.Exists(path))
            {
                // Get directory statistics
                var directoryStats = GetDirectoryStats2(path);

                // Subtract the file count of the deleted directory from the total
                num -= directoryStats.FileCount;

                // Update the file count label
                fileCountOnLabel.Text = ($"File Count: 0/{num.ToString("N0")}");

                // Update the total copied progress label
                totalCopiedProgressLabel.Text = ($"Total C/M/D: 0/{FormatBytes(totalBytes)}");

                // Remove the row corresponding to the deleted directory
                int rowIndex = fileDirDataGridView.CurrentCell.RowIndex;
                fileDirDataGridView.Rows.RemoveAt(rowIndex);

                // If there are remaining rows, select the last one
                if (fileDirDataGridView.Rows.Count > 0)
                {
                    // Select the last row
                    int lastIndex = fileDirDataGridView.Rows.Count - 1;
                    fileDirDataGridView.Rows[lastIndex].Selected = true;
                    fileDirDataGridView.FirstDisplayedScrollingRowIndex = lastIndex;
                }
            }
            else
            {
                // If the root directory is not found, log a message
                Console.WriteLine("Root directory not found.");
            }

            // Reset the totalFolderBytes counter
            totalFolderBytes = 0;

        }

        private void removeDirBGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            ExpandOrRetract();

            // Reset the label for the selected files/directory
            fromFilesDirLabel.Text = "Select Files/Directory";

            // Enable navigation and switch to the main page tab
            ((Control)this.cmdMainPage).Enabled = true;
            ((Control)this.cmdSkipPage).Enabled = true;
            ((Control)this.cmdAboutPage).Enabled = true;
            ((Control)this.cmdSettingsPage).Enabled = true;
            ((Control)this.cmdCopyHistoryPage).Enabled = true;
            tabControl1.SelectedTab = cmdMainPage;

        }

        private void ExpandOrRetract()
        {
            // Set the maximum and minimum size of the form
            this.MaximumSize = new System.Drawing.Size(1550, 1075);
            this.MinimumSize = new System.Drawing.Size(1550, 695);

            // Adjust the height of the form based on the value of EXPANDTHAT
            if (EXPANDTHAT == false)
            {
                if (tabControl1.SelectedTab == cmdMainPage)
                {
                    if (fileDirDataGridView.Rows.Count > 0)
                    {
                        // Set the height to 1075 pixels if EXPANDTHAT is false
                        this.Height = 1075;
                        tabControl1.Height = 995;
                    }
                    else
                    {
                        // Set the height to 695 pixels if EXPANDTHAT is false
                        this.Height = 695;
                        tabControl1.Height = 615;
                    }

                }

                if (tabControl1.SelectedTab == cmdAboutPage)
                {
                    // Set the height to 695 pixels if EXPANDTHAT is false
                    this.Height = 695;
                    tabControl1.Height = 615;

                }

                if (tabControl1.SelectedTab == cmdSkipPage)
                {
                    // Set the height to 695 pixels if EXPANDTHAT is false
                    this.Height = 695;
                    tabControl1.Height = 615;
                }
                if (tabControl1.SelectedTab == cmdSettingsPage)
                {
                    // Set the height to 1075 pixels if EXPANDTHAT is false
                    this.Height = 1075;
                    tabControl1.Height = 995;
                }

                if (tabControl1.SelectedTab == cmdCopyHistoryPage)
                {
                    // Set the height to 695 pixels if EXPANDTHAT is false
                    this.Height = 695;
                    tabControl1.Height = 615;
                }

                if (tabControl1.SelectedTab == cmdExclusionsPage)
                {
                    // Set the height to 695 pixels if EXPANDTHAT is false
                    this.Height = 695;
                    tabControl1.Height = 615;
                }
            }
            else
            {
                // Set the height to 1075 pixels if EXPANDTHAT is true
                this.Height = 1075;
                tabControl1.Height = 995;
            }
        }
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            // Check if the selected tab page is the main page
            if (e.TabPage == cmdMainPage)
            {
                // Enable controls related to the main page and disable others
                ((Control)this.cmdMainPage).Enabled = true;
                ((Control)this.cmdSkipPage).Enabled = false;
                ((Control)this.cmdAboutPage).Enabled = false;
                ((Control)this.cmdSettingsPage).Enabled = false;
                ((Control)this.cmdCopyHistoryPage).Enabled = false;
                ((Control)this.cmdExclusionsPage).Enabled = false; // Disable the exclusions page
                tabControl1.SelectedTab = cmdMainPage; // Set the selected tab to the main page
                scrollTimer.Stop(); // Stop and dispose of the scroll timer
                scrollTimer.Dispose();

                // Update the title label based on whether it's the Pro version
                titleLabel.Text = proVersion ? "Copy That - File/Directory Tool Pro - Home" : "Copy That - File/Directory Tool - Home";


                // Save settings if auto-save is enabled
                if (saveAutoCheckBox.Checked)
                {
                    Properties.Settings.Default.Save();
                }
            }
            // Check if the selected tab page is the exclusions page
            else if (e.TabPage == cmdExclusionsPage)
            {
                // Enable controls related to the exclusions page and disable others
                ((Control)this.cmdMainPage).Enabled = false;
                ((Control)this.cmdSkipPage).Enabled = false;
                ((Control)this.cmdAboutPage).Enabled = false;
                ((Control)this.cmdSettingsPage).Enabled = false;
                ((Control)this.cmdCopyHistoryPage).Enabled = false;
                ((Control)this.cmdExclusionsPage).Enabled = true; // Enable the exclusions page
                tabControl1.SelectedTab = cmdExclusionsPage; // Set the selected tab to the exclusions page
                scrollTimer.Stop(); // Stop and dispose of the scroll timer
                scrollTimer.Dispose();

                // Update the title label based on whether it's the Pro version
                titleLabel.Text = proVersion ? "Copy That - File/Directory Tool Pro - Allow/Exclude" : "Copy That - File/Directory Tool - Allow/Exclude";

                // Save settings if auto-save is enabled
                if (saveAutoCheckBox.Checked)
                {
                    Properties.Settings.Default.Save();
                }
                // Adjust expand/retact settings
                ExpandOrRetract();
            }

            // Check if the selected tab page is the Skip page
            else if (e.TabPage == cmdSkipPage)
            {
                ExpandOrRetract();
                // Enable controls related to the Skip page and disable others
                ((Control)this.cmdMainPage).Enabled = false;
                ((Control)this.cmdSkipPage).Enabled = true;
                ((Control)this.cmdAboutPage).Enabled = false;
                ((Control)this.cmdSettingsPage).Enabled = false;
                ((Control)this.cmdCopyHistoryPage).Enabled = false;
                tabControl1.SelectedTab = cmdSkipPage; // Set the selected tab to the Skip page
                scrollTimer.Stop(); // Stop and dispose of the scroll timer
                scrollTimer.Dispose();

                // Update the title label based on whether it's the Pro version
                titleLabel.Text = proVersion ? "Copy That - File/Directory Tool Pro - Skipped Files/Dirs." : "Copy That - File/Directory Tool - Skipped Files/Dirs.";

                // Save settings if auto-save is enabled
                if (saveAutoCheckBox.Checked)
                {
                    Properties.Settings.Default.Save();
                }
            }
            // Check if the selected tab page is the About page
            else if (e.TabPage == cmdAboutPage)
            {
                // Enable controls related to the About page and disable others
                ((Control)this.cmdMainPage).Enabled = false;
                ((Control)this.cmdSkipPage).Enabled = false;
                ((Control)this.cmdAboutPage).Enabled = true;
                ((Control)this.cmdSettingsPage).Enabled = false;
                ((Control)this.cmdCopyHistoryPage).Enabled = false;
                tabControl1.SelectedTab = cmdAboutPage; // Set the selected tab to the About page
                scrollTimer.Stop(); // Stop and dispose of the scroll timer
                scrollTimer.Dispose();

                ExpandOrRetract();

                // Adjust the position of the credits label
                creditsLabel.Top = this.ClientSize.Height;

                // Update the title label and credits label based on whether it's the Pro version
                titleLabel.Text = proVersion ? "Copy That - File/Directory Tool Pro - About" : "Copy That - File/Directory Tool - About";
                creditsLabel.Text = proVersion ? "Copy That - File/Directory Tool Pro\r\n\r\nBy: Havoc\r\n\r\nVersion: 1.0.0\r\n\r\nIDE: Visual Studio 2022\r\n\r\nProgramming Language: C#\r\n\r\nFramework: .Net 8.0\r\n\r\n"
                                               : "Copy That - File/Directory Tool\r\n\r\nBy: Havoc\r\n\r\nVersion: 1.0.0\r\n\r\nIDE: Visual Studio 2022\r\n\r\nProgramming Language: C#\r\n\r\nFramework: .Net 8.0\r\n\r\n";

                // Save settings if auto-save is enabled
                if (saveAutoCheckBox.Checked)
                {
                    Properties.Settings.Default.Save();
                }
                InitializeScrolling(); // Initialize scrolling for the about page
            }


            // Check if the selected tab page is the Settings page
            else if (e.TabPage == cmdSettingsPage)
            {
                // Enable controls related to the Settings page and disable others
                ((Control)this.cmdMainPage).Enabled = false;
                ((Control)this.cmdSkipPage).Enabled = false;
                ((Control)this.cmdAboutPage).Enabled = false;
                ((Control)this.cmdSettingsPage).Enabled = true;
                ((Control)this.cmdCopyHistoryPage).Enabled = false;
                tabControl1.SelectedTab = cmdSettingsPage; // Set the selected tab to the Settings page
                scrollTimer.Stop(); // Stop and dispose of the scroll timer
                scrollTimer.Dispose();

                // Adjust expand/retact settings
                ExpandOrRetract();

                // Edit saved checkboxes
                editSavedCheckBoxes();

                // Update the title label based on whether it's the Pro version
                titleLabel.Text = proVersion ? "Copy That - File/Directory Tool Pro - Settings" : "Copy That - File/Directory Tool - Settings";


                string skins = Properties.Settings.Default.skinImage;
                if (skins == "Dark Mode")
                {
                    Properties.Settings.Default.skinImage = "Dark Mode";
                    skinsComboBox.SelectedIndex = 0;

                    if (saveAutoCheckBox.Checked)
                    {
                        Properties.Settings.Default.Save();
                    }

                    ChangeControlsForeColor(this, Color.White);

                    ChangeControlsBackColor(this, Color.Black);

                    ChangeControlColorsLabelsCheckBoxes(Color.Transparent);

                    this.BackColor = Color.Black;
                }
                else
                {
                    Properties.Settings.Default.skinImage = "Light Mode";
                    skinsComboBox.SelectedIndex = 1;

                    if (saveAutoCheckBox.Checked)
                    {
                        Properties.Settings.Default.Save();
                    }
                    ChangeControlsForeColor(this, Color.Black);

                    ChangeControlsBackColor(this, Color.WhiteSmoke);

                    ChangeControlColorsLabelsCheckBoxes(Color.Transparent);

                    this.BackColor = Color.WhiteSmoke;
                }

                nLabel.BackColor = Color.Transparent;
                neLabel.BackColor = Color.Transparent;
                eLabel.BackColor = Color.Transparent;
                seLabel.BackColor = Color.Transparent;
                sLabel.BackColor = Color.Transparent;
                swLabel.BackColor = Color.Transparent;
                wLabel.BackColor = Color.Transparent;
                nwLabel.BackColor = Color.Transparent;

                // Save settings if auto-save is enabled
                if (saveAutoCheckBox.Checked)
                {
                    Properties.Settings.Default.Save();
                }
            }
            // Check if the selected tab page is the Copy History page
            else if (e.TabPage == cmdCopyHistoryPage)
            {
                // Adjust expand/retact settings
                ExpandOrRetract();
                // Enable controls related to the Copy History page and disable others
                ((Control)this.cmdMainPage).Enabled = false;
                ((Control)this.cmdSkipPage).Enabled = false;
                ((Control)this.cmdAboutPage).Enabled = false;
                ((Control)this.cmdSettingsPage).Enabled = false;
                ((Control)this.cmdCopyHistoryPage).Enabled = true;
                tabControl1.SelectedTab = cmdCopyHistoryPage; // Set the selected tab to the Copy History page
                scrollTimer.Stop(); // Stop and dispose of the scroll timer
                scrollTimer.Dispose();

                // Update the title label based on whether it's the Pro version
                titleLabel.Text = proVersion ? "Copy That - File/Directory Tool Pro - History" : "Copy That - File/Directory Tool - History";

                // Save settings if auto-save is enabled
                if (saveAutoCheckBox.Checked)
                {
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void btnClearSkippedList_Click(object sender, EventArgs e)
        {
            // Clear the rows in the skippedDataGridView
            skippedDataGridView.Rows.Clear();

            // Update the totalSkippedLabel to reflect the number of rows in the skippedDataGridView
            totalSkippedLabel.Text = "Total Skipped Files: " + skippedDataGridView.Rows.Count + "";

        }

        private static void SelectFileInExplorer(string filePath)
        {
            // Open File Explorer and select the specified file or folder
            Process.Start(new ProcessStartInfo()
            {
                FileName = "explorer.exe",
                Arguments = @$"/select,""{filePath}"""
            });

        }

        private void btnGoToInExplorer_Click(object sender, EventArgs e)
        {
            // Get the index of the currently selected row in the skippedDataGridView
            int currentRow = skippedDataGridView.SelectedRows[0].Index;

            // Get the file path from the selected row
            string file = skippedDataGridView.Rows[currentRow].Cells[2].Value.ToString();

            // Check if the file exists
            if (File.Exists(file))
            {
                // Open File Explorer and select the specified file
                SelectFileInExplorer(file);
            }

        }

        // This method retrieves the total size of the specified drive.
        private long GetTotalSpace(string driveName)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == driveName)
                {
                    return drive.TotalSize;
                }
            }
            return -1; // Return -1 if the drive is not found or not ready
        }

        // This method retrieves the total available free space of the specified drive.
        private long GetTotalAvailableSpace(string driveName)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == driveName)
                {
                    return drive.AvailableFreeSpace;
                }
            }
            return -1; // Return -1 if the drive is not found or not ready
        }

        private void overwriteIfNewerCHKBOX_CheckedChanged(object sender, EventArgs e)
        {
            // If "Overwrite if newer" checkbox is checked
            if (overwriteIfNewerCHKBOX.Checked)
            {
                // Set the overwrite option text
                overwriteOption = "Overwrite Type: If Newer";

                // Uncheck other checkboxes
                overwriteAllCHKBOX.Checked = false;
                doNotOverwriteCHKBOX.Checked = false;
            }
            // If none of the overwrite checkboxes are checked
            else if (!overwriteIfNewerCHKBOX.Checked && !overwriteAllCHKBOX.Checked && !doNotOverwriteCHKBOX.Checked)
            {
                // Default to "Do Not Overwrite"
                doNotOverwriteCHKBOX.Checked = true;
                overwriteIfNewerCHKBOX.Checked = false;
                overwriteAllCHKBOX.Checked = false;
            }

            // If "Restart" checkbox is not checked
            if (!restartCheckBox.Checked)
            {
                // Automatically check "Close Program" checkbox
                closeProgramCheckBox.Checked = true;
            }
            // If "Restart" checkbox is checked
            else if (restartCheckBox.Checked)
            {
                // Uncheck "Close Program" checkbox
                closeProgramCheckBox.Checked = false;
            }
            // If neither "Close Program" nor "Restart" checkboxes are checked
            else if (!closeProgramCheckBox.Checked && !restartCheckBox.Checked)
            {
                // Default to "Restart"
                restartCheckBox.Checked = true;
            }

        }

        private void overwriteAllCHKBOX_CheckedChanged(object sender, EventArgs e)
        {
            // If "Overwrite all" checkbox is checked
            if (overwriteAllCHKBOX.Checked == true)
            {
                // Set the overwrite option text
                overwriteOption = "Overwrite: All Files";

                // Uncheck other checkboxes
                overwriteIfNewerCHKBOX.Checked = false;
                doNotOverwriteCHKBOX.Checked = false;
            }
            // If none of the overwrite checkboxes are checked
            else if (!overwriteIfNewerCHKBOX.Checked && !overwriteAllCHKBOX.Checked && !doNotOverwriteCHKBOX.Checked)
            {
                // Default to "Do Not Overwrite"
                doNotOverwriteCHKBOX.Checked = true;
                overwriteIfNewerCHKBOX.Checked = false;
                overwriteAllCHKBOX.Checked = false;
            }

        }

        private void doNotOverwriteCHKBOX_CheckedChanged(object sender, EventArgs e)
        {
            // If "Do not overwrite" checkbox is checked
            if (doNotOverwriteCHKBOX.Checked == true)
            {
                // Set the overwrite option text
                overwriteOption = "Overwrite: Do Not Overwrite";

                // Uncheck other checkboxes
                overwriteIfNewerCHKBOX.Checked = false;
                overwriteAllCHKBOX.Checked = false;
            }
            // If none of the overwrite checkboxes are checked
            else if (!overwriteIfNewerCHKBOX.Checked && !overwriteAllCHKBOX.Checked && !doNotOverwriteCHKBOX.Checked)
            {
                // Default to "Do Not Overwrite"
                doNotOverwriteCHKBOX.Checked = true;
                overwriteIfNewerCHKBOX.Checked = false;
                overwriteAllCHKBOX.Checked = false;
            }

        }

        private void cmdSkipPage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void cmdCopyHistoryPage_MouseDown(object sender, MouseEventArgs e)
        {
            // If the left mouse button is clicked
            if (e.Button == MouseButtons.Left)
            {
                // Release the capture to allow the form to move
                ReleaseCapture();

                // Send the message to the form's handle to simulate clicking and dragging the caption bar
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

        }

        private void cmdSettingsPage_MouseDown(object sender, MouseEventArgs e)
        {
            // If the left mouse button is clicked
            if (e.Button == MouseButtons.Left)
            {
                // Release the capture to allow the form to move
                ReleaseCapture();

                // Send the message to the form's handle to simulate clicking and dragging the caption bar
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

        }

        private void cmdAboutPage_MouseDown(object sender, MouseEventArgs e)
        {
            // If the left mouse button is clicked
            if (e.Button == MouseButtons.Left)
            {
                // Release the capture to allow the form to move
                ReleaseCapture();

                // Send the message to the form's handle to simulate clicking and dragging the caption bar
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

        }

        private int scrollSpeed = 4; // Adjust the scroll speed as needed

        /// <summary>
        /// Initializes the scrolling timer.
        /// </summary>
        private void InitializeScrolling()
        {
            // Create a new timer for scrolling
            scrollTimer = new Timer();

            // Set the interval for scrolling (adjust as needed)
            scrollTimer.Interval = 30;

            // Attach an event handler for the Tick event of the timer
            scrollTimer.Tick += scrollTimer_Tick;

            // Start the timer
            scrollTimer.Start();
        }


        private void scrollTimer_Tick(object sender, EventArgs e)
        {
            // Move the label position upwards
            creditsLabel.Top -= scrollSpeed;

            // Check if the label has moved completely off the form
            if (creditsLabel.Bottom < 0)
            {
                // Reset the label position to the bottom of the form
                creditsLabel.Top = this.ClientSize.Height;
            }
        }

        private void creditsLabel_MouseDown(object sender, MouseEventArgs e)
        {
            // If the left mouse button is clicked
            if (e.Button == MouseButtons.Left)
            {
                // Release the capture to allow the form to move
                ReleaseCapture();

                // Send the message to the form's handle to simulate clicking and dragging the caption bar
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void aboutPicBox_Click(object sender, EventArgs e)
        {
            // Save settings if auto save is enabled
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }

            // Stop and dispose the scrolling timer
            scrollTimer.Stop();
            scrollTimer.Dispose();

            // Disable buttons and enable About page
            ((Control)this.cmdMainPage).Enabled = false;
            ((Control)this.cmdSkipPage).Enabled = false;
            ((Control)this.cmdAboutPage).Enabled = true;
            ((Control)this.cmdSettingsPage).Enabled = false;
            ((Control)this.cmdCopyHistoryPage).Enabled = false;

            // Switch to the About page in the tab control
            tabControl1.SelectedTab = cmdAboutPage;

            // Adjust expand/collapse settings
            ExpandOrRetract();


            // Edit saved checkboxes and credits label
            editSavedCheckBoxes();
            creditsLabel.Top = this.ClientSize.Height;

            // Update title label and credits label based on the version
            if (proVersion)
            {
                titleLabel.Text = "Copy That - File/Directory Tool Pro - About";
                creditsLabel.Text = "Copy That - File/Directory Tool Pro\r\n\r\nBy: Havoc\r\n\r\nVersion: 1.0.0\r\n\r\nIDE: Visual Studio 2022\r\n\r\nProgramming Language: C#\r\n\r\nFramework: .Net 8.0\r\n\r\n";
            }
            else
            {
                titleLabel.Text = "Copy That - File/Directory Tool - About";
                creditsLabel.Text = "Copy That - File/Directory Tool\r\n\r\nBy: Havoc\r\n\r\nVersion: 1.0.0\r\n\r\nIDE: Visual Studio 2022\r\n\r\nProgramming Language: C#\r\n\r\nFramework: .Net 8.0\r\n\r\n";
            }

            // Initialize scrolling
            InitializeScrolling();

        }

        private void settingsPicBox_Click(object sender, EventArgs e)
        {
            // Save settings if auto save is enabled
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }

            // Stop and dispose the scrolling timer
            scrollTimer.Stop();
            scrollTimer.Dispose();

            // Disable buttons and enable Settings page
            ((Control)this.cmdMainPage).Enabled = false;
            ((Control)this.cmdSkipPage).Enabled = false;
            ((Control)this.cmdAboutPage).Enabled = false;
            ((Control)this.cmdSettingsPage).Enabled = true;
            ((Control)this.cmdCopyHistoryPage).Enabled = false;

            // Switch to the Settings page in the tab control
            tabControl1.SelectedTab = cmdSettingsPage;

            // Adjust expand/collapse settings
            ExpandOrRetract();


            // Edit saved checkboxes and set languageComboBox to default
            editSavedCheckBoxes();
            languageComboBox.SelectedItem = "English";

            // Update title label based on the version
            if (proVersion)
            {
                titleLabel.Text = "Copy That - File/Directory Tool Pro - Settings";
            }
            else
            {
                titleLabel.Text = "Copy That - File/Directory Tool - Settings";
            }
        }

        private void defaultSettingsButton_Click(object sender, EventArgs e)
        {

            // Update settings and checkboxes based on preferences
            Properties.Settings.Default.minimizeToTray = true;
            minimizeSystemTrayCheckBox.Checked = true;

            Properties.Settings.Default.confirmDragDrop = true;
            confirmDragDropCheckBox.Checked = true;

            Properties.Settings.Default.soundOnFinish = true;
            onFinishCheckBox.Checked = true;

            Properties.Settings.Default.soundOnCancel = true;
            onCancelCheckBox.Checked = true;

            Properties.Settings.Default.soundOnError = true;
            onErrorCheckBox.Checked = true;

            Properties.Settings.Default.soundOnFilesAdded = false;
            onAddFilesCheckBox.Checked = false;

            Properties.Settings.Default.saveAutomatically = true;
            saveAutoCheckBox.Checked = true;

            Properties.Settings.Default.contextMenu = true;
            contextMenuCheckBox.Checked = true;

            Properties.Settings.Default.restartProgram = true;
            restartCheckBox.Checked = true;

            Properties.Settings.Default.underMB = false;
            underMBCheckBox.Checked = false;

            Properties.Settings.Default.overMB = false;
            overMBCheckBox.Checked = false;

            Properties.Settings.Default.multithreading = true;
            multithreadCheckBox.Checked = true;

            // Check settings specific to the pro version
            if (proVersion)
            {
                updateAutoCheckBox.Checked = true;
                updateBetaCheckBox.Checked = true;
                updateAuto = true;
                updateBeta = true;
                updateManuallyCheckBox.Checked = false;
                updateManually = false;
                zipTogetherCheckBox.Checked = true;
                fullPathsCheckBox.Checked = true;
                emailPathsCheckBox.Checked = true;
            }
            else
            {
                updateAutoCheckBox.Checked = false;
                updateBetaCheckBox.Checked = false;
                updateAuto = false;
                updateBeta = false;
                updateManuallyCheckBox.Checked = true;
                updateManually = true;
            }
        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            //Save settings
            Properties.Settings.Default.Save();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            // Make the form visible
            Show();

            // Restore the window state to normal if it was minimized or hidden
            this.WindowState = FormWindowState.Normal;

            // Hide the system tray icon
            notifyIcon1.Visible = false;
        }

        private void exitCopyThat_Click(object sender, EventArgs e)
        {
            // Sets the 'canceled' flag to true.

            if (getFoldersBackgroundWorker.IsBusy)
            {
                // If the background worker is still busy, cancel the operation
                getFoldersBackgroundWorker.CancelAsync();

                // Add some delay to allow the cancellation to take effect
                Thread.Sleep(1000);

                // Check if the background worker is still busy
                if (getFoldersBackgroundWorker.IsBusy)
                {
                    // If the background worker is still busy, print a message indicating it's still busy and set up an event handler to exit the environment after completion.
                    Console.WriteLine("Background worker is still busy. Waiting for completion...");
                    getFoldersBackgroundWorker.RunWorkerCompleted += (s, e) => { Environment.Exit(0); };
                }
                else
                {
                    // If the background worker is not busy after cancellation, print a message indicating completion and exit the environment.
                    Console.WriteLine("Background worker completed after cancellation. Exiting...");
                    Environment.Exit(0);
                }
            }
            else
            {
                // If no background worker is currently busy, print a message and exit the environment.
                Console.WriteLine("Background worker is not busy. Exiting...");
                Environment.Exit(0);
            }


            if (DELETEbackgroundWorker.IsBusy)
            {
                // If the background worker is still busy, cancel the operation
                DELETEbackgroundWorker.CancelAsync();

                // Add some delay to allow the cancellation to take effect
                Thread.Sleep(1000);

                // Check if the background worker is still busy
                if (DELETEbackgroundWorker.IsBusy)
                {
                    // If the background worker is still busy, print a message indicating it's still busy and set up an event handler to exit the environment after completion.
                    Console.WriteLine("Background worker is still busy. Waiting for completion...");
                    DELETEbackgroundWorker.RunWorkerCompleted += (s, e) => { Environment.Exit(0); };
                }
                else
                {
                    // If the background worker is not busy after cancellation, print a message indicating completion and exit the environment.
                    Console.WriteLine("Background worker completed after cancellation. Exiting...");
                    Environment.Exit(0);
                }
            }
            else
            {
                // If no background worker is currently busy, print a message and exit the environment.
                Console.WriteLine("Background worker is not busy. Exiting...");
                Environment.Exit(0);
            }

            if (COPYbackgroundWorker.IsBusy)
            {
                // If the background worker is still busy, cancel the operation
                COPYbackgroundWorker.CancelAsync();

                // Add some delay to allow the cancellation to take effect
                Thread.Sleep(1000);

                // Check if the background worker is still busy
                if (COPYbackgroundWorker.IsBusy)
                {
                    // If the background worker is still busy, print a message indicating it's still busy and set up an event handler to exit the environment after completion.
                    Console.WriteLine("Background worker is still busy. Waiting for completion...");
                    COPYbackgroundWorker.RunWorkerCompleted += (s, e) => { Environment.Exit(0); };
                }
                else
                {
                    // If the background worker is not busy after cancellation, print a message indicating completion and exit the environment.
                    Console.WriteLine("Background worker completed after cancellation. Exiting...");
                    Environment.Exit(0);
                }
            }
            else
            {
                // If no background worker is currently busy, print a message and exit the environment.
                Console.WriteLine("Background worker is not busy. Exiting...");
                Environment.Exit(0);
            }

            if (MOVEbackgroundWorker.IsBusy)
            {
                // If the background worker is still busy, cancel the operation
                MOVEbackgroundWorker.CancelAsync();

                // Add some delay to allow the cancellation to take effect
                Thread.Sleep(1000);

                // Check if the background worker is still busy
                if (MOVEbackgroundWorker.IsBusy)
                {
                    // If the background worker is still busy, print a message indicating it's still busy and set up an event handler to exit the environment after completion.
                    Console.WriteLine("Background worker is still busy. Waiting for completion...");
                    MOVEbackgroundWorker.RunWorkerCompleted += (s, e) => { Environment.Exit(0); };
                }
                else
                {
                    // If the background worker is not busy after cancellation, print a message indicating completion and exit the environment.
                    Console.WriteLine("Background worker completed after cancellation. Exiting...");
                    Environment.Exit(0);
                }
            }
            else
            {
                // If no background worker is currently busy, print a message and exit the environment.
                Console.WriteLine("Background worker is not busy. Exiting...");
                Environment.Exit(0);
            }
            // Adds a brief delay before closing the current form.
            Thread.Sleep(500);
            this.Close();

        }

        private void openCopyThat_Click(object sender, EventArgs e)
        {
            // Show the form.
            this.Show();

            // Ensure the form is in the normal state (not minimized or maximized).
            this.WindowState = FormWindowState.Normal;

            // Set the form to be shown in the taskbar.
            this.ShowInTaskbar = true;
        }

        private void recSettingsButton_Click(object sender, EventArgs e)
        {
            // Set the 'alwaysOnTop' setting to false and update the associated checkbox.
            Properties.Settings.Default.alwaysOnTop = false;
            alwaysOnTopCheckBox.Checked = false;

            // Set the 'minimizeToTray' setting to false and update the associated checkbox.
            Properties.Settings.Default.minimizeToTray = false;
            minimizeSystemTrayCheckBox.Checked = false;

            // Set the 'confirmDragDrop' setting to true and update the associated checkbox.
            Properties.Settings.Default.confirmDragDrop = true;
            confirmDragDropCheckBox.Checked = true;

            // Set the 'soundOnFinish' setting to false and update the associated checkbox.
            Properties.Settings.Default.soundOnFinish = false;
            onFinishCheckBox.Checked = true; // Note: The checkbox seems to contradict the setting. 

            // Set the 'soundOnCancel' setting to false and update the associated checkbox.
            Properties.Settings.Default.soundOnCancel = false;
            onCancelCheckBox.Checked = false;

            // Set the 'soundOnError' setting to true and update the associated checkbox.
            Properties.Settings.Default.soundOnError = true;
            onErrorCheckBox.Checked = true;

            // Set the 'soundOnFilesAdded' setting to false and update the associated checkbox.
            Properties.Settings.Default.soundOnFilesAdded = false;
            onAddFilesCheckBox.Checked = false;

            // Set the 'saveAutomatically' setting to true and update the associated checkbox.
            Properties.Settings.Default.saveAutomatically = true;
            saveAutoCheckBox.Checked = true;

            // Set the 'contextMenu' setting to true and update the associated checkbox.
            Properties.Settings.Default.contextMenu = true;
            contextMenuCheckBox.Checked = true;

            // Set the 'restartProgram' setting to true and update the associated checkbox.
            Properties.Settings.Default.restartProgram = true;
            restartCheckBox.Checked = true;

            // Set the 'underMB' setting to false and update the associated checkbox.
            Properties.Settings.Default.underMB = false;
            underMBCheckBox.Checked = false;

            // Set the 'overMB' setting to false and update the associated checkbox.
            Properties.Settings.Default.overMB = false;
            overMBCheckBox.Checked = false;

            // Set the 'multithreading' setting to true and update the associated checkbox.
            Properties.Settings.Default.multithreading = true;
            multithreadCheckBox.Checked = true;

            // Check if the application is the pro version to determine additional settings.
            if (proVersion)
            {
                // Set various settings for the pro version and update their associated checkboxes.
                updateAutoCheckBox.Checked = true;
                updateBetaCheckBox.Checked = true;
                updateAuto = true;
                updateBeta = true;
                updateManuallyCheckBox.Checked = false;
                updateManually = false;
                zipTogetherCheckBox.Checked = true;
                fullPathsCheckBox.Checked = true;
                emailPathsCheckBox.Checked = true;
            }
            else
            {
                // Set various settings for the non-pro version and update their associated checkboxes.
                updateAutoCheckBox.Checked = false;
                updateBetaCheckBox.Checked = false;
                updateAuto = false;
                updateBeta = false;
                updateManuallyCheckBox.Checked = true;
                updateManually = true;
            }

        }

        private void clearSettingsButton_Click(object sender, EventArgs e)
        {
            // Set the 'alwaysOnTop' setting to false and update the associated checkbox.
            Properties.Settings.Default.alwaysOnTop = false;
            alwaysOnTopCheckBox.Checked = false;

            // Set the 'minimizeToTray' setting to false and update the associated checkbox.
            Properties.Settings.Default.minimizeToTray = false;
            minimizeSystemTrayCheckBox.Checked = false;

            // Set the 'confirmDragDrop' setting to false and update the associated checkbox.
            Properties.Settings.Default.confirmDragDrop = false;
            confirmDragDropCheckBox.Checked = false;

            // Set the 'contextMenu' setting to false and update the associated checkbox.
            Properties.Settings.Default.contextMenu = false;
            contextMenuCheckBox.Checked = false;

            // Set the 'soundOnFinish' setting to false and update the associated checkbox.
            Properties.Settings.Default.soundOnFinish = false;
            onFinishCheckBox.Checked = false;

            // Set the 'soundOnCancel' setting to false and update the associated checkbox.
            Properties.Settings.Default.soundOnCancel = false;
            onCancelCheckBox.Checked = false;

            // Set the 'soundOnError' setting to false and update the associated checkbox.
            Properties.Settings.Default.soundOnError = false;
            onErrorCheckBox.Checked = false;

            // Set the 'soundOnFilesAdded' setting to false and update the associated checkbox.
            Properties.Settings.Default.soundOnFilesAdded = false;
            onAddFilesCheckBox.Checked = false;

            // Set the 'saveAutomatically' setting to false and update the associated checkbox.
            Properties.Settings.Default.saveAutomatically = false;
            saveAutoCheckBox.Checked = false;

            // Set the 'updateManually' setting to true and update the associated checkbox.
            Properties.Settings.Default.updateManually = true;
            updateManuallyCheckBox.Checked = true;

            // Set the 'restartProgram' setting to true and update the associated checkbox.
            Properties.Settings.Default.restartProgram = true;
            restartCheckBox.Checked = true;

            // Set the 'underMB' setting to false and update the associated checkbox.
            Properties.Settings.Default.underMB = false;
            underMBCheckBox.Checked = false;

            // Set the 'overMB' setting to false and update the associated checkbox.
            Properties.Settings.Default.overMB = false;
            overMBCheckBox.Checked = false;

            // Set the 'fileFullPaths' setting to true and update the associated checkbox.
            Properties.Settings.Default.fileFullPaths = true;
            fullPathsCheckBox.Checked = true;

            // Set the 'emailFullPaths' setting to true and update the associated checkbox.
            Properties.Settings.Default.emailFullPaths = true;
            emailPathsCheckBox.Checked = true;

        }

        void editSavedCheckBoxes()
        {

            //WINDOW SETTINGS GROUPBOX EDIT
            bool onTop = Properties.Settings.Default.alwaysOnTop;
            if (onTop == true)
            {

                Properties.Settings.Default.alwaysOnTop = true;
                this.TopMost = true;
                alwaysOnTopCheckBox.Checked = true;
            }
            else
            {
                Properties.Settings.Default.alwaysOnTop = false;
                this.TopMost = false;
                alwaysOnTopCheckBox.Checked = false;
            }

            bool alwaysConfirmDragAndDrop = Properties.Settings.Default.confirmDragDrop;
            if (alwaysConfirmDragAndDrop == true)
            {
                Properties.Settings.Default.confirmDragDrop = true;
                confirmDragDropCheckBox.Checked = true;
            }
            else
            {
                Properties.Settings.Default.confirmDragDrop = false;
                confirmDragDropCheckBox.Checked = false;
            }

            bool minimizeToSystemTray = Properties.Settings.Default.minimizeToTray;
            if (minimizeToSystemTray == true)
            {
                Properties.Settings.Default.minimizeToTray = true;
                minimizeSystemTrayCheckBox.Checked = true;
            }
            else
            {
                Properties.Settings.Default.minimizeToTray = false;
                minimizeSystemTrayCheckBox.Checked = false;
            }


            bool contextmenu = Properties.Settings.Default.contextMenu;
            if (contextmenu == true)
            {
                Properties.Settings.Default.contextMenu = true;
                contextMenuCheckBox.Checked = true;
            }
            else
            {
                Properties.Settings.Default.contextMenu = false;
                contextMenuCheckBox.Checked = false;
            }




            //____________________________________________________________




            //SOUND SETTINGS GROUPBOX EDIT
            bool soundAddFiles = Properties.Settings.Default.soundOnFilesAdded;
            if (soundAddFiles == true)
            {
                Properties.Settings.Default.soundOnFilesAdded = true;
                onAddFilesCheckBox.Checked = true;
            }
            else
            {
                Properties.Settings.Default.soundOnFilesAdded = false;
                onAddFilesCheckBox.Checked = false;
            }

            bool soundCancel = Properties.Settings.Default.soundOnCancel;
            if (soundCancel)
            {
                Properties.Settings.Default.soundOnCancel = true;
                onCancelCheckBox.Checked = true;
            }
            else
            {
                Properties.Settings.Default.soundOnCancel = false;
                onCancelCheckBox.Checked = false;
            }

            bool soundError = Properties.Settings.Default.soundOnError;
            if (soundError == true)
            {
                Properties.Settings.Default.soundOnError = true;
                onErrorCheckBox.Checked = true;
            }
            else
            {
                Properties.Settings.Default.soundOnError = false;
                onErrorCheckBox.Checked = false;
            }

            bool soundFinish = Properties.Settings.Default.soundOnFinish;
            if (soundFinish == true)
            {
                Properties.Settings.Default.soundOnFinish = true;
                onFinishCheckBox.Checked = true;
            }
            else
            {
                Properties.Settings.Default.soundOnFinish = false;
                onFinishCheckBox.Checked = false;
            }






            //____________________________________________________________



            //OTHER SETTINGS GROUPBOX EDIT
            if (proVersion == true)
            {
                registerButton.Enabled = false;


            }
            else
            {
                registerButton.Enabled = true;
            }

            if (closeProgram == true)
            {
                restartCheckBox.Checked = false;
                Properties.Settings.Default.closeProgram = true;
                Properties.Settings.Default.restartProgram = false;
            }
            else
            {
                restartCheckBox.Checked = true;
                Properties.Settings.Default.closeProgram = false;
                Properties.Settings.Default.restartProgram = true;

            }

            if (restartProgram == true)
            {
                closeProgramCheckBox.Checked = false;
                Properties.Settings.Default.closeProgram = false;
                Properties.Settings.Default.restartProgram = true;
            }
            else
            {
                closeProgramCheckBox.Checked = true;
                Properties.Settings.Default.closeProgram = true;
                Properties.Settings.Default.restartProgram = false;
            }

            bool startUp = Properties.Settings.Default.startWindows;
            if (startUp == true)
            {
                startWithWindowsCheckBox.Checked = true;
            }
            else
            {
                startWithWindowsCheckBox.Checked = false;
            }




            //____________________________________________________________




            //UPDATE SETTINGS GROUPBOX EDIT

            if (proVersion == true)
            {
                updateBetaCheckBox.Enabled = true;
                updateAutoCheckBox.Enabled = true;
                updateManuallyCheckBox.Enabled = true;
                //if (updateAuto == true)
                //{
                //    updateAutoCheckBox.Checked = true;
                //    updateManuallyCheckBox.Checked = false;
                //}
                //else
                //{
                //    updateAutoCheckBox.Checked = false;
                //}

                //bool updateBeta = Properties.Settings.Default.updateBeta;
                //if (updateBeta == true)
                //{
                //    updateBetaCheckBox.Checked = true;
                //    updateManuallyCheckBox.Checked = false;
                //}
                //else
                //{
                //    updateBetaCheckBox.Checked = false;
                //}

                //bool updateManually = Properties.Settings.Default.updateManually;
                //if (updateManually == true)
                //{
                //    updateManuallyCheckBox.Checked = true;
                //    updateAutoCheckBox.Checked = false;
                //    updateBetaCheckBox.Checked = false;
                //}
                //else
                //{
                //    updateManuallyCheckBox.Checked = false;
                //}

            }
            else
            {
                updateBetaCheckBox.Enabled = false;
                updateAutoCheckBox.Enabled = false;
                updateManuallyCheckBox.Checked = true;
                updateManually = true;
            }




            //____________________________________________________________



            //EMAIL SETTINGS GROUPBOX EDIT







            if (proVersion == true)
            {
                emailGroupBox.Enabled = true;


                if (emailDirNames == true)
                {
                    emailPathsCheckBox.Checked = false;
                    Properties.Settings.Default.emailOnlyNames = true;
                    Properties.Settings.Default.emailFullPaths = false;
                }
                else
                {
                    emailPathsCheckBox.Checked = true;
                    Properties.Settings.Default.emailOnlyNames = false;
                    Properties.Settings.Default.emailFullPaths = true;
                }


                if (emailFull == true)
                {
                    Properties.Settings.Default.emailOnlyNames = false;
                    Properties.Settings.Default.emailFullPaths = true;
                    emailNamesCheckBox.Checked = false;
                }
                else
                {
                    emailNamesCheckBox.Checked = true;
                    Properties.Settings.Default.emailOnlyNames = true;
                    Properties.Settings.Default.emailFullPaths = false;
                }

                //bool emailDirNames = Properties.Settings.Default.emailOnlyNames;
                //if (emailDirNames == true)
                //{
                //    Properties.Settings.Default.emailOnlyNames = true;
                //    emailPathsCheckBox.Checked = false;
                //}
                //else
                //{
                //    Properties.Settings.Default.emailOnlyNames = false;
                //    emailPathsCheckBox.Checked = true;
                //}


                //bool emailfullPaths = Properties.Settings.Default.emailFullPaths;
                //if (emailfullPaths == true)
                //{
                //    Properties.Settings.Default.emailFullPaths = true;
                //    emailNamesCheckBox.Checked = false;
                //}
                //else
                //{
                //    Properties.Settings.Default.emailFullPaths = false;
                //    emailNamesCheckBox.Checked = true;
                //}
            }
            else
            {
                emailGroupBox.Enabled = false;
            }










            //____________________________________________________________



            //FILE/FOLDER SETTINGS GROUPBOX EDIT

            if (proVersion == true)
            {
                fileDirSettingsGroupBox.Enabled = true;
                //emailFileDirNames.Checked = true;
                //emailPathsCheckBox.Checked = true;
                //setUpEmailButton.Enabled = true;
                bool onlyNames = Properties.Settings.Default.fileOnlyNames;
                if (onlyNames == true)
                {
                    Properties.Settings.Default.fileOnlyNames = true;
                    fullPathsCheckBox.Checked = false;

                }
                else
                {
                    Properties.Settings.Default.fileOnlyNames = false;
                    fullPathsCheckBox.Checked = true;
                }

                bool fullPaths = Properties.Settings.Default.fileFullPaths;
                if (fullPaths == true)
                {
                    Properties.Settings.Default.fileFullPaths = true;
                    onlyNamesCheckBox.Checked = false;

                }
                else
                {
                    Properties.Settings.Default.fileFullPaths = false;
                    onlyNamesCheckBox.Checked = true;
                }
            }
            else
            {
                fileDirSettingsGroupBox.Enabled = false;
            }






            //____________________________________________________________




            //PERFORMANCE SETTINGS GROUPBOX EDIT

            bool underMBY = Properties.Settings.Default.underMB;
            if (underMBY == true)
            {
                Properties.Settings.Default.underMB = true;
                underMBCheckBox.Checked = true;
            }
            else if (underMBY == false)
            {
                Properties.Settings.Default.underMB = false;
                underMBCheckBox.Checked = false;
            }


            bool overMBY = Properties.Settings.Default.overMB;
            if (overMBY == true)
            {
                Properties.Settings.Default.overMB = true;
                saveAutoCheckBox.Checked = true;
                overMBCheckBox.Checked = true;
            }
            else if (overMBY == false)
            {
                Properties.Settings.Default.overMB = false;
                overMBCheckBox.Checked = false;
            }

            if (Properties.Settings.Default.multithreading == true)
            {
                multithreadCheckBox.Checked = true;
                multiThread = true;
                Properties.Settings.Default.multithreading = multiThread;
            }
            else
            {
                multithreadCheckBox.Checked = false;
                multiThread = false;
                Properties.Settings.Default.multithreading = multiThread;
            }
















            //____________________________________________________________



            //THEMES AND LANGUAGES SETTINGS GROUPBOX EDIT
  
            string skins = Properties.Settings.Default.skinImage;
            if (skins == "Dark Mode")
            {
                Properties.Settings.Default.skinImage = "Dark Mode";
                skinsComboBox.SelectedIndex = 0;

                if (saveAutoCheckBox.Checked)
                {
                    Properties.Settings.Default.Save();
                }

                ChangeControlsForeColor(this, Color.White);

                ChangeControlsBackColor(this, Color.Black);

                ChangeControlColorsLabelsCheckBoxes(Color.Transparent);

                this.BackColor = Color.Black;
            }
            else
            {
                Properties.Settings.Default.skinImage = "Light Mode";
                skinsComboBox.SelectedIndex = 1;

                if (saveAutoCheckBox.Checked)
                {
                    Properties.Settings.Default.Save();
                }
                ChangeControlsForeColor(this, Color.Black);

                ChangeControlsBackColor(this, Color.WhiteSmoke);

                ChangeControlColorsLabelsCheckBoxes(Color.Transparent);

                this.BackColor = Color.WhiteSmoke;
            }

            nLabel.BackColor = Color.Transparent;
            neLabel.BackColor = Color.Transparent;
            eLabel.BackColor = Color.Transparent;
            seLabel.BackColor = Color.Transparent;
            sLabel.BackColor = Color.Transparent;
            swLabel.BackColor = Color.Transparent;
            wLabel.BackColor = Color.Transparent;
            nwLabel.BackColor = Color.Transparent;


            //____________________________________________________________


            //AUTOMATICALLY SAVE CHECKBOX EDIT SAVE TO LOG FILE, PROGRAM PRIORITY EDIT, & TRANSPARENCY EDIT
            bool saveAuto = Properties.Settings.Default.saveAutomatically;
            if (saveAuto == true)
            {
                Properties.Settings.Default.saveAutomatically = true;
                saveAutoCheckBox.Checked = true;

            }
            else
            {
                Properties.Settings.Default.saveAutomatically = false;
                saveAutoCheckBox.Checked = false;
            }

            bool saveLog = Properties.Settings.Default.logFile;

            if (saveLog == true)
            {
                Properties.Settings.Default.logFile = true;
                logFileCheckBox.Checked = true;
            }
            else
            {
                Properties.Settings.Default.logFile = false;
                logFileCheckBox.Checked = false;
            }


            if (priority == "Below Normal")
            {
                priorityTrackBar.Value = 0;
                priorityLabel.Text = "Program Priority: \nBelow Normal";
                Properties.Settings.Default.priority = "Below Normal";
                using (Process p = Process.GetCurrentProcess())
                {
                    p.PriorityClass = ProcessPriorityClass.BelowNormal;
                }
            }
            else if (priority == "Normal")
            {
                priorityTrackBar.Value = 1;
                priorityLabel.Text = "Program Priority: \nNormal";
                Properties.Settings.Default.priority = "Normal";
                using (Process p = Process.GetCurrentProcess())
                {
                    p.PriorityClass = ProcessPriorityClass.Normal;
                }
            }
            else if (priority == "Above Normal")
            {
                priorityTrackBar.Value = 2;
                priorityLabel.Text = "Program Priority: \nAbove Normal";
                Properties.Settings.Default.priority = "Above Normal";
                using (Process p = Process.GetCurrentProcess())
                {
                    p.PriorityClass = ProcessPriorityClass.AboveNormal;
                }
            }
            else if (priority == "High")
            {
                priorityTrackBar.Value = 3;
                priorityLabel.Text = "Program Priority: \nHigh";
                Properties.Settings.Default.priority = "High";
                using (Process p = Process.GetCurrentProcess())
                {
                    p.PriorityClass = ProcessPriorityClass.High;
                }
            }
            else if (priority == "Real Time")
            {
                priorityTrackBar.Value = 4;
                priorityLabel.Text = "Program Priority: \nReal Time";
                Properties.Settings.Default.priority = "Real Time";
                using (Process p = Process.GetCurrentProcess())
                {
                    p.PriorityClass = ProcessPriorityClass.RealTime;
                }
            }


            // Retrieve the opacity value from application settings
            int opacity = Properties.Settings.Default.opacity;

            // Set the opacityTrackBar value to match the retrieved opacity
            opacityTrackBar.Value = opacity;

            // Calculate the opacity value based on the trackbar value
            double opacityValue = opacityTrackBar.Value / 100.0;

            // Calculate the opacity text for display
            int opacityText = Convert.ToInt32(opacityValue * 100);

            // Update the opacityLabel text with the opacity percentage
            opacityLabel.Text = "Opacity: \n" + opacityText.ToString() + "%";

            // Update the opacity setting in application settings
            Properties.Settings.Default.opacity = opacityText;

            // Set the opacity of the form
            this.Opacity = opacityValue;

            // Save settings if auto-saving is enabled
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }

            // Reset label backgrounds to Transparent color
            nLabel.BackColor = Color.Transparent;
            neLabel.BackColor = Color.Transparent;
            eLabel.BackColor = Color.Transparent;
            seLabel.BackColor = Color.Transparent;
            sLabel.BackColor = Color.Transparent;
            swLabel.BackColor = Color.Transparent;
            wLabel.BackColor = Color.Transparent;
            nwLabel.BackColor = Color.Transparent;

            // Reset label foregrounds to Black color
            nLabel.ForeColor = Color.Black;
            neLabel.ForeColor = Color.Black;
            eLabel.ForeColor = Color.Black;
            seLabel.ForeColor = Color.Black;
            sLabel.ForeColor = Color.Black;
            swLabel.ForeColor = Color.Black;
            wLabel.ForeColor = Color.Black;
            nwLabel.ForeColor = Color.Black;

        }

        private void saveAutoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the save automatically checkbox is checked
            if (saveAutoCheckBox.Checked)
            {
                // If checked, set the saveAutomatically setting to true and update the checkbox state
                Properties.Settings.Default.saveAutomatically = true;
                saveAutoCheckBox.Checked = true;
            }
            else
            {
                // If not checked, set the saveAutomatically setting to false and update the checkbox state
                Properties.Settings.Default.saveAutomatically = false;
                saveAutoCheckBox.Checked = false;
            }

        }

        private void confirmDragDropCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the confirm drag and drop checkbox is checked
            if (confirmDragDropCheckBox.Checked)
            {
                // If checked, set the confirmDragDrop setting to true and update the checkbox state
                Properties.Settings.Default.confirmDragDrop = true;
                confirmDragDropCheckBox.Checked = true;
            }
            else
            {
                // If not checked, set the confirmDragDrop setting to false and update the checkbox state
                Properties.Settings.Default.confirmDragDrop = false;
                confirmDragDropCheckBox.Checked = false;
            }

            // Check if the save automatically checkbox is checked
            if (saveAutoCheckBox.Checked)
            {
                // If checked, save the settings
                Properties.Settings.Default.Save();
            }
        }

        private void minimizeSystemTrayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the minimize to system tray checkbox is checked
            if (minimizeSystemTrayCheckBox.Checked)
            {
                // If checked, set the minimizeToTray setting to true and update the checkbox state
                Properties.Settings.Default.minimizeToTray = true;
                minimizeSystemTrayCheckBox.Checked = true;
            }
            else
            {
                // If not checked, set the minimizeToTray setting to false and update the checkbox state
                Properties.Settings.Default.minimizeToTray = false;
                minimizeSystemTrayCheckBox.Checked = false;
            }

            // Check if the save automatically checkbox is checked
            if (saveAutoCheckBox.Checked)
            {
                // If checked, save the settings
                Properties.Settings.Default.Save();
            }

        }

        private void alwaysOnTopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the always on top checkbox is checked
            if (alwaysOnTopCheckBox.Checked)
            {
                // If checked, check if the context menu checkbox is also checked
                if (contextMenuCheckBox.Checked)
                {
                    // If context menu is checked, inform the user and uncheck always on top
                    alwaysOnTopCheckBox.Checked = false;
                    MessageBox.Show("You may not have this form always on top if you add the context menu item.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // If context menu is not checked, set alwaysOnTop setting to true and update the checkbox state
                    Properties.Settings.Default.alwaysOnTop = true;
                    alwaysOnTopCheckBox.Checked = true;
                }
            }
            else
            {
                // If always on top checkbox is not checked, set alwaysOnTop setting to false and update the checkbox state
                Properties.Settings.Default.alwaysOnTop = false;
                alwaysOnTopCheckBox.Checked = false;
            }

            // Check if the save automatically checkbox is checked and save the settings
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }

        }

        private void onFinishCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the sound on finish checkbox is checked
            if (onFinishCheckBox.Checked)
            {
                // If checked, set the soundOnFinish setting to true and update the checkbox state
                Properties.Settings.Default.soundOnFinish = true;
                onFinishCheckBox.Checked = true;
            }
            else
            {
                // If not checked, set the soundOnFinish setting to false and update the checkbox state
                Properties.Settings.Default.soundOnFinish = false;
                onFinishCheckBox.Checked = false;
            }

            // Check if the save automatically checkbox is checked and save the settings
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void onCancelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the sound on cancel checkbox is checked
            if (onCancelCheckBox.Checked)
            {
                // If checked, set the soundOnCancel setting to true and update the checkbox state
                Properties.Settings.Default.soundOnCancel = true;
                onCancelCheckBox.Checked = true;
            }
            else
            {
                // If not checked, set the soundOnCancel setting to false and update the checkbox state
                Properties.Settings.Default.soundOnCancel = false;
                onCancelCheckBox.Checked = false;
            }

            // Check if the save automatically checkbox is checked and save the settings
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }

        }

        private void onAddFilesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the sound on files added checkbox is checked
            if (onAddFilesCheckBox.Checked)
            {
                // If checked, set the soundOnFilesAdded setting to true and update the checkbox state
                Properties.Settings.Default.soundOnFilesAdded = true;
                onAddFilesCheckBox.Checked = true;
            }
            else
            {
                // If not checked, set the soundOnFilesAdded setting to false and update the checkbox state
                Properties.Settings.Default.soundOnFilesAdded = false;
                onAddFilesCheckBox.Checked = false;
            }

            // Check if the save automatically checkbox is checked and save the settings
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void onErrorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the sound on error checkbox is checked
            if (onErrorCheckBox.Checked)
            {
                // If checked, set the soundOnError setting to true and update the checkbox state
                Properties.Settings.Default.soundOnError = true;
                onErrorCheckBox.Checked = true;
            }
            else
            {
                // If not checked, set the soundOnError setting to false and update the checkbox state
                Properties.Settings.Default.soundOnError = false;
                onErrorCheckBox.Checked = false;
            }

            // Check if the save automatically checkbox is checked and save the settings
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }

        }

        private void restartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the restart checkbox is checked
            if (restartCheckBox.Checked)
            {
                // If checked, update closeProgram setting to false, restartProgram setting to true, and update checkbox states
                closeProgramCheckBox.Checked = false;
                Properties.Settings.Default.closeProgram = false;
                Properties.Settings.Default.restartProgram = true;
            }
            else
            {
                // If not checked, update closeProgram setting to true, restartProgram setting to false, and update checkbox states
                closeProgramCheckBox.Checked = true;
                Properties.Settings.Default.closeProgram = true;
                Properties.Settings.Default.restartProgram = false;
            }

            // Check if the save automatically checkbox is checked and save the settings
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }

        }

        private void closeProgramCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (closeProgramCheckBox.Checked)
            {
                restartCheckBox.Checked = false;
                Properties.Settings.Default.closeProgram = true;
                Properties.Settings.Default.restartProgram = false;
            }
            else
            {
                restartCheckBox.Checked = true;
                Properties.Settings.Default.closeProgram = false;
                Properties.Settings.Default.restartProgram = true;
            }
            if (saveAutoCheckBox.Checked == true)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            // Check if the entered serial matches the pro version format
            if (serialMaskedTextBox.Text == "ABCD-EFGH-IJKL-MN12")
            {
                // If matched, set proVersion to true, disable registerButton, and update saved checkboxes
                proVersion = true;
                registerButton.Enabled = false;
                editSavedCheckBoxes();
                serialMaskedTextBox.Text = "";
            }
            else
            {
                // If not matched, set proVersion to false, enable registerButton, and update saved checkboxes
                proVersion = false;
                registerButton.Enabled = true;
                editSavedCheckBoxes();
            }
        }

        private void updateManuallyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Update the update options based on proVersion status and user selection
            if (proVersion && updateAutoCheckBox.Checked == false && updateBetaCheckBox.Checked == false)
            {
                // If proVersion is true and both auto and beta updates are unchecked, set updateManually to true and others to false
                updateManually = true;
                updateAuto = false;
                updateBeta = false;
                // Update the checkboxes accordingly
                updateManuallyCheckBox.Checked = true;
                updateAutoCheckBox.Checked = false;
                updateBetaCheckBox.Checked = false;
            }
            else if (proVersion && updateManuallyCheckBox.Checked == true)
            {
                // If proVersion is true and updateManually is checked, enable auto updates
                updateBetaCheckBox.Checked = false;
                updateAutoCheckBox.Checked = true;
                updateAuto = true;
            }
            else if (proVersion == false && updateManually == false)
            {
                // If proVersion is false and updateManually is false, set updateManually to true and others to false
                updateManually = true;
                updateAuto = false;
                updateBeta = false;
                // Update the checkboxes accordingly
                updateManuallyCheckBox.Checked = true;
                updateAutoCheckBox.Checked = false;
                updateBetaCheckBox.Checked = false;
            }

            // Save settings if auto-save is enabled
            if (saveAutoCheckBox.Checked == true)
            {
                Properties.Settings.Default.Save();
            }

        }

        private void updateAutoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Update the update options based on proVersion status and user selection
            if (proVersion && updateManuallyCheckBox.Checked == false && updateBetaCheckBox.Checked == false)
            {
                // If proVersion is true and both manually and beta updates are unchecked, enable auto updates
                updateAuto = true;
                updateManually = false;
                updateBeta = false;
                // Update the checkboxes accordingly
                updateAutoCheckBox.Checked = true;
                updateManuallyCheckBox.Checked = false;
            }
            else if (proVersion && updateAutoCheckBox.Checked == false && updateManuallyCheckBox.Checked == false)
            {
                // If proVersion is true and both auto and manually updates are unchecked, enable beta updates
                updateBeta = true;
                updateBetaCheckBox.Checked = true;
            }
            else if (proVersion && updateAutoCheckBox.Checked == true)
            {
                // If proVersion is true and auto updates are checked, disable manual updates
                updateManuallyCheckBox.Checked = false;
                updateAuto = true;
                updateAutoCheckBox.Checked = true;
            }
            else if (proVersion == false && updateManually == false)
            {
                // If proVersion is false and manual updates are unchecked, enable manual updates
                updateManually = true;
                updateAuto = false;
                updateBeta = false;
                // Update the checkboxes accordingly
                updateManuallyCheckBox.Checked = true;
                updateAutoCheckBox.Checked = false;
                updateBetaCheckBox.Checked = false;
            }

            // Save settings if auto-save is enabled
            if (saveAutoCheckBox.Checked == true)
            {
                Properties.Settings.Default.Save();
            }

        }

        private void updateBetaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Update the update options based on proVersion status and user selection
            if (proVersion && updateManuallyCheckBox.Checked == false && updateAutoCheckBox.Checked == false)
            {
                // If proVersion is true and both manually and auto updates are unchecked, enable beta updates
                updateBeta = true;
                updateManually = false;
                updateAuto = false;
                // Update the checkboxes accordingly
                updateBetaCheckBox.Checked = true;
                updateManuallyCheckBox.Checked = false;
            }
            else if (proVersion && updateBetaCheckBox.Checked == false && updateManuallyCheckBox.Checked == false)
            {
                // If proVersion is true and both beta and manually updates are unchecked, enable auto updates
                updateAuto = true;
                updateAutoCheckBox.Checked = true;
            }
            else if (proVersion && updateAutoCheckBox.Checked == false && updateBetaCheckBox.Checked == false)
            {
                // If proVersion is true and both auto and manually updates are unchecked, enable manual updates
                updateManually = true;
                updateAuto = false;
                updateBeta = false;
                // Update the checkboxes accordingly
                updateManuallyCheckBox.Checked = true;
                updateAutoCheckBox.Checked = false;
                updateBetaCheckBox.Checked = false;
            }
            else if (proVersion && updateBetaCheckBox.Checked == true)
            {
                // If proVersion is true and beta updates are checked, disable manual updates
                updateManuallyCheckBox.Checked = false;
                updateBeta = true;
                updateBetaCheckBox.Checked = true;
            }
            else if (proVersion == false && updateManually == false)
            {
                // If proVersion is false and manual updates are unchecked, enable manual updates
                updateManually = true;
                updateAuto = false;
                updateBeta = false;
                // Update the checkboxes accordingly
                updateManuallyCheckBox.Checked = true;
                updateAutoCheckBox.Checked = false;
                updateBetaCheckBox.Checked = false;
            }

            // Save settings if auto-save is enabled
            if (saveAutoCheckBox.Checked == true)
            {
                Properties.Settings.Default.Save();
            }

        }

        private void contextMenuCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Update context menu setting based on user selection
            if (contextMenuCheckBox.Checked == true)
            {
                // If context menu is checked, enable it and uncheck always on top
                Properties.Settings.Default.contextMenu = true;
                contextMenuCheckBox.Checked = true;
                alwaysOnTopCheckBox.Checked = false;
            }
            else
            {
                // If context menu is unchecked, disable it
                Properties.Settings.Default.contextMenu = false;
                contextMenuCheckBox.Checked = false;
            }

            // Save settings if auto-save is enabled
            if (saveAutoCheckBox.Checked == true)
            {
                Properties.Settings.Default.Save();
            }

        }

        private void underMBCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (underMBCheckBox.Checked)
            {
                Properties.Settings.Default.underMB = true;
                Properties.Settings.Default.overMB = false;
                overMBCheckBox.Checked = false;
            }
            else if (underMBCheckBox.Checked == false)
            {
                Properties.Settings.Default.underMB = false;
            }
            else if (underMBCheckBox.Checked = false && overMBCheckBox.Checked == false)
            {
                Properties.Settings.Default.underMB = false;
                Properties.Settings.Default.overMB = false;
            }
            if (saveAutoCheckBox.Checked == true)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void overMBCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (overMBCheckBox.Checked)
            {
                Properties.Settings.Default.overMB = true;
                Properties.Settings.Default.underMB = false;
                underMBCheckBox.Checked = false;
            }
            else if (overMBCheckBox.Checked == false)
            {
                Properties.Settings.Default.overMB = false;
            }
            else if (underMBCheckBox.Checked = false && overMBCheckBox.Checked == false)
            {
                Properties.Settings.Default.underMB = false;
                Properties.Settings.Default.overMB = false;
            }


            if (saveAutoCheckBox.Checked == true)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void onlyNamesCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            if (onlyNamesCheckBox.Checked)
            {
                fullPathsCheckBox.Checked = false;
                onlyNames = true;
            }
            else if (onlyNamesCheckBox.Checked == false && fullPathsCheckBox.Checked == false)
            {
                onlyNames = true;
                onlyNamesCheckBox.Checked = true;
            }


            if (saveAutoCheckBox.Checked == true)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void fullPathsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (fullPathsCheckBox.Checked)
            {
                fullPaths = true;
                onlyNamesCheckBox.Checked = false;
            }
            else if (onlyNamesCheckBox.Checked == false && fullPathsCheckBox.Checked == false)
            {
                fullPaths = true;
                fullPathsCheckBox.Checked = true;
            }


            if (saveAutoCheckBox.Checked == true)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void zipSeparateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save settings if auto-save is enabled
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }

        }

        private void zipTogetherCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save settings if auto-save is enabled
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }

        }

        private void emailFileDirNames_CheckedChanged(object sender, EventArgs e)
        {
            // Configure email settings based on user selection
            if (emailNamesCheckBox.Checked)
            {
                // If only names are checked, disable full paths
                emailPathsCheckBox.Checked = false;
                Properties.Settings.Default.emailOnlyNames = true;
                Properties.Settings.Default.emailFullPaths = false;
            }
            else
            {
                // If full paths are checked, disable only names
                emailPathsCheckBox.Checked = true;
                Properties.Settings.Default.emailOnlyNames = false;
                Properties.Settings.Default.emailFullPaths = true;
            }

            // Save settings if auto-save is enabled
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }

        }

        private void emailPathsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Configure email settings based on user selection
            if (emailPathsCheckBox.Checked)
            {
                // If full paths are checked, disable only names
                Properties.Settings.Default.emailOnlyNames = false;
                Properties.Settings.Default.emailFullPaths = true;
                emailNamesCheckBox.Checked = false;
            }
            else
            {
                // If only names are checked, disable full paths
                emailNamesCheckBox.Checked = true;
                Properties.Settings.Default.emailOnlyNames = true;
                Properties.Settings.Default.emailFullPaths = false;
            }

            // Save settings if auto-save is enabled
            if (saveAutoCheckBox.Checked)
            {
                // Upgrade and save settings
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.Save();
            }
        }

        void exitPlease()
        {
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.Save();
            }
            canceled = true;


            if (getFoldersBackgroundWorker.IsBusy)
            {
                // If the background worker is still busy, cancel the operation
                getFoldersBackgroundWorker.CancelAsync();

                // Add some delay to allow the cancellation to take effect
                Thread.Sleep(1000);

                // Check if the background worker is still busy
                if (getFoldersBackgroundWorker.IsBusy)
                {
                    Console.WriteLine("Background worker is still busy. Waiting for completion...");
                    // You may choose to wait for the background worker to complete or handle it according to your application's requirements.
                    getFoldersBackgroundWorker.RunWorkerCompleted += (s, e) => { Environment.Exit(0); };
                }
                else
                {
                    Console.WriteLine("Background worker completed after cancellation. Exiting...");
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("Background worker is not busy. Exiting...");
                Environment.Exit(0);
            }


            if (DELETEbackgroundWorker.IsBusy)
            {
                // If the background worker is still busy, cancel the operation
                DELETEbackgroundWorker.CancelAsync();

                // Add some delay to allow the cancellation to take effect
                Thread.Sleep(1000);

                // Check if the background worker is still busy
                if (DELETEbackgroundWorker.IsBusy)
                {
                    Console.WriteLine("Background worker is still busy. Waiting for completion...");
                    // You may choose to wait for the background worker to complete or handle it according to your application's requirements.
                    DELETEbackgroundWorker.RunWorkerCompleted += (s, e) => { Environment.Exit(0); };
                }
                else
                {
                    Console.WriteLine("Background worker completed after cancellation. Exiting...");
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("Background worker is not busy. Exiting...");
                Environment.Exit(0);
            }

            if (COPYbackgroundWorker.IsBusy)
            {
                // If the background worker is still busy, cancel the operation
                COPYbackgroundWorker.CancelAsync();

                // Add some delay to allow the cancellation to take effect
                Thread.Sleep(1000);

                // Check if the background worker is still busy
                if (COPYbackgroundWorker.IsBusy)
                {
                    Console.WriteLine("Background worker is still busy. Waiting for completion...");
                    // You may choose to wait for the background worker to complete or handle it according to your application's requirements.
                    COPYbackgroundWorker.RunWorkerCompleted += (s, e) => { Environment.Exit(0); };
                }
                else
                {
                    Console.WriteLine("Background worker completed after cancellation. Exiting...");
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("Background worker is not busy. Exiting...");
                Environment.Exit(0);
            }

            if (MOVEbackgroundWorker.IsBusy)
            {
                // If the background worker is still busy, cancel the operation
                MOVEbackgroundWorker.CancelAsync();

                // Add some delay to allow the cancellation to take effect
                Thread.Sleep(1000);

                // Check if the background worker is still busy
                if (MOVEbackgroundWorker.IsBusy)
                {
                    Console.WriteLine("Background worker is still busy. Waiting for completion...");
                    // You may choose to wait for the background worker to complete or handle it according to your application's requirements.
                    MOVEbackgroundWorker.RunWorkerCompleted += (s, e) => { Environment.Exit(0); };
                }
                else
                {
                    Console.WriteLine("Background worker completed after cancellation. Exiting...");
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("Background worker is not busy. Exiting...");
                Environment.Exit(0);
            }
            Thread.Sleep(500);
            this.Close();
        }

        private void showCopyThat_Click(object sender, EventArgs e)
        {
            //Show program and set windowstate to normal window
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void exitCopyThat_Click_1(object sender, EventArgs e)
        {
            //Exit program
            exitPlease();
        }

        private void mainForm_Resize(object sender, EventArgs e)
        {
            // Minimize to system tray if the form is minimized and the option is enabled
            if (FormWindowState.Minimized == this.WindowState && minimizeSystemTrayCheckBox.Checked == true)
            {
                // Show the notify icon and hide the form
                notifyIcon1.Visible = true;
                this.Hide();
            }
            // Restore from system tray if the form is normal and the option is disabled
            else if (FormWindowState.Normal == this.WindowState && minimizeSystemTrayCheckBox.Checked == false)
            {
                // Hide the notify icon
                notifyIcon1.Visible = false;
            }

        }

        // Method to retrieve items from a ListBox and return them as a list of strings
        private List<string> GetListBoxItems(ListBox listBox)
        {
            List<string> items = new List<string>();
            foreach (var item in listBox.Items)
            {
                items.Add(item.ToString());
            }
            return items;
        }

        // Method to check if an extension is present in both the excluded and allowed lists
        static bool IsExtensionInOppositeList(string extension, List<string> excludedExtensions, List<string> allowedExtensions)
        {
            // Check if the extension is present in both lists using a case-insensitive comparison
            return excludedExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase) && allowedExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
        }

        private void btnAddAllowed_Click(object sender, EventArgs e)
        {
            // Get the text from the TextBox
            string newText = allowedTextBox.Text;

            if (allowedTextBox.Text != string.Empty && (allowedTextBox.TextLength == 5 || allowedTextBox.TextLength == 6))
            {

                // Check if the item already exists in the ListBox
                if (!allowedExtListBox.Items.Contains(newText) && !excludedExtListBox.Items.Contains(newText) && allowedExtListBox.Items.Contains("*.*"))
                {
                    allowedExtListBox.Items.Clear();
                    // Add the item to the ListBox
                    allowedExtListBox.Items.Add(newText);

                    allowedTextBox.Text = "*.";
                    allowedTextBox.SelectionStart = 2;
                }
                else if (!allowedExtListBox.Items.Contains(newText) && !excludedExtListBox.Items.Contains(newText))
                {
                    // Add the item to the ListBox
                    allowedExtListBox.Items.Add(newText);

                    allowedTextBox.Text = "*.";
                    allowedTextBox.SelectionStart = 2;
                }
                else
                {
                    // Optional: Display a message or take other action if the text already exists
                    MessageBox.Show("This extension already exists in the excluded extensions or in the added extensions.",
                        "Copy That File/Directory Tool - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    allowedTextBox.Focus();
                }
            }
        }

        private void btnRemoveAllowed_Click(object sender, EventArgs e)
        {
            if (allowedExtListBox.SelectedIndex != -1)
            {
                // Remove the selected item from the ListBox
                allowedExtListBox.Items.RemoveAt(allowedExtListBox.SelectedIndex);

                // If there are no more items in the allowed extensions list,
                // clear the excluded extensions list and add the default wildcard entry
                if (allowedExtListBox.Items.Count == 0)
                {
                    excludedExtListBox.Items.Clear();
                    allowedExtListBox.Items.Add("*.*");
                }
            }
            else
            {
                // Inform the user to select an item if none is selected
                MessageBox.Show("Please select an item to remove.",
                                "Copy That File/Directory Tool - Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClearAllowed_Click(object sender, EventArgs e)
        {
            // If the allowed extensions list contains items,
            // clear the list, add the default wildcard entry, and clear the excluded extensions list
            if (allowedExtListBox.Items.Count > 0)
            {
                allowedExtListBox.Items.Clear();
                allowedExtListBox.Items.Add("*.*");
                excludedExtListBox.Items.Clear();
            }
            // Set focus to the allowedTextBox
            allowedTextBox.Focus();
        }

        private void btnAddExcluded_Click(object sender, EventArgs e)
        {
            // Get the text from the TextBox
            string newText = excludedTextBox.Text;

            // Check if the TextBox is not empty and has a valid length
            if (excludedTextBox.Text != string.Empty && (excludedTextBox.TextLength == 5 || excludedTextBox.TextLength == 6))
            {
                // Check if the item already exists in the ListBox
                if (!excludedExtListBox.Items.Contains(newText) && !allowedExtListBox.Items.Contains(newText))
                {
                    // Add the item to the ListBox
                    excludedExtListBox.Items.Add(newText);

                    // Reset the TextBox text and set the cursor position
                    excludedTextBox.Text = "*.";
                    excludedTextBox.SelectionStart = 2;
                }
                else
                {
                    // Optional: Display a message or take other action if the text already exists
                    MessageBox.Show("This extension already exists in the excluded extensions or in the added extensions.",
                        "Copy That File/Directory Tool - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Set focus back to the TextBox
                    excludedTextBox.Focus();
                }
            }
        }

        private void btnRemoveExcluded_Click(object sender, EventArgs e)
        {
            if (excludedExtListBox.SelectedIndex != -1)
            {
                // Remove the selected item from the ListBox
                excludedExtListBox.Items.RemoveAt(excludedExtListBox.SelectedIndex);
            }
            else
            {
                // Optional: Display a message or take other action if no item is selected
                MessageBox.Show("Please select an item to remove.",
                        "Copy That File/Directory Tool - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClearExcluded_Click(object sender, EventArgs e)
        {
            if (excludedExtListBox.Items.Count > 0)
            {
                // Clear all items from the ListBox
                excludedExtListBox.Items.Clear();
            }
            // Set focus to the excludedTextBox
            excludedTextBox.Focus();

        }

        private void allowedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow adding characters after the first two characters
            if (allowedTextBox.Text.Length < 2)
            {
                e.Handled = true;
                allowedTextBox.Text = "*.";
                allowedTextBox.SelectionStart = 2;
            }
        }

        private void allowedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((!(char.IsLetter((char)e.KeyValue) || e.KeyCode == Keys.Back)) && allowedTextBox.TextLength < 3)
            {
                // Suppress the key press
                e.SuppressKeyPress = true;
            }
            else if (char.IsLetter((char)e.KeyValue))
            {
                if (allowedTextBox.SelectionStart <= 2)
                {
                    allowedTextBox.Text = "*.";
                    allowedTextBox.SelectionStart = 2;
                }
            }
            // Check if the Delete key is pressed
            if (e.KeyCode == Keys.Delete)
            {
                // Suppress the Delete key press
                e.SuppressKeyPress = true;
                allowedTextBox.Text = "*.";
                allowedTextBox.SelectionStart = 2;
            }
        }

        private void excludedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow adding characters after the first two characters
            if (excludedTextBox.Text.Length < 2)
            {
                e.Handled = true;
                excludedTextBox.Text = "*.";
                excludedTextBox.SelectionStart = 2;
            }
            if (excludedTextBox.Text == "*")
            {
                excludedTextBox.Text = "*.";
            }
        }

        private void excludedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((!(char.IsLetter((char)e.KeyValue) || e.KeyCode == Keys.Back)) && excludedTextBox.TextLength < 3)
            {
                // Suppress the key press
                e.SuppressKeyPress = true;
            }
            else if (char.IsLetter((char)e.KeyValue))
            {
                if (excludedTextBox.SelectionStart <= 2)
                {
                    excludedTextBox.Text = "*.";
                    excludedTextBox.SelectionStart = 2;
                }
            }
            // Check if the Delete key is pressed
            if (e.KeyCode == Keys.Delete)
            {
                // Suppress the Delete key press
                e.SuppressKeyPress = true;
                excludedTextBox.Text = "*.";
                excludedTextBox.SelectionStart = 2;
            }
        }


        private void ChangeControlsForeColor(Control control, Color newColor)
        {
            // Iterate through all controls in the form
            foreach (Control ctrl in control.Controls)
            {
                // Change the ForeColor of the control to white
                ctrl.ForeColor = newColor;

                // If the control has child controls, recursively call the method
                if (ctrl.HasChildren)
                {
                    ChangeControlsForeColor(ctrl, newColor);
                }
            }
        }

        private void ChangeControlsBackColor(Control control, Color newColor)
        {
            // Iterate through all controls in the form
            foreach (Control ctrl in control.Controls)
            {


                // Change the BackColor of the control to black
                ctrl.BackColor = newColor;


                // If the control has child controls, recursively call the method
                if (ctrl.HasChildren)
                {
                    ChangeControlsBackColor(ctrl, newColor);
                }
            }
        }

        private void ChangeControlColorsLabelsCheckBoxes(Color newColor)
        {
            // Iterate through all controls on the form
            foreach (Control control in Controls)
            {
                // Check if the control is neither a Label nor a CheckBox
                if ((control is Label) && (control is CheckBox) && (control is TextBox))
                {
                    // Set the background color of the control
                    control.BackColor = newColor;
                }
            }
        }
        private void skinsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (skinsComboBox.SelectedItem.ToString() == "Dark Mode")
            {
                cmdAboutPage.BackgroundImage = null;
                cmdMainPage.BackgroundImage = null;
                cmdExclusionsPage.BackgroundImage = null;
                Properties.Settings.Default.skinImage = "Dark Mode";
                if (saveAutoCheckBox.Checked)
                {
                    Properties.Settings.Default.Save();
                }

                ChangeControlsForeColor(this, Color.White);

                ChangeControlsBackColor(this, Color.Black);

                ChangeControlColorsLabelsCheckBoxes(Color.Transparent);

                this.BackColor = Color.Black;

            }
            else if (skinsComboBox.SelectedItem.ToString() == "Light Mode")
            {
                cmdAboutPage.BackgroundImage = null;
                cmdMainPage.BackgroundImage = null;
                cmdExclusionsPage.BackgroundImage = null;
                Properties.Settings.Default.skinImage = "Light Mode";
                if (saveAutoCheckBox.Checked)
                {
                    Properties.Settings.Default.Save();
                }
                ChangeControlsForeColor(this, Color.Black);

                ChangeControlsBackColor(this, Color.WhiteSmoke);

                ChangeControlColorsLabelsCheckBoxes(Color.Transparent);

                this.BackColor = Color.WhiteSmoke;
            }
            nLabel.BackColor = Color.Transparent;
            neLabel.BackColor = Color.Transparent;
            eLabel.BackColor = Color.Transparent;
            seLabel.BackColor = Color.Transparent;
            sLabel.BackColor = Color.Transparent;
            swLabel.BackColor = Color.Transparent;
            wLabel.BackColor = Color.Transparent;
            nwLabel.BackColor = Color.Transparent;
        }

        private void fontNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Check the selected font size from the fontNumUpDown
            if (fontNumUpDown.Value == 9)
            {
                // Set the font size to 9
                this.Font = new System.Drawing.Font("Arial Regular", 9);
                Properties.Settings.Default.fontSize = 9;
            }
            else if (fontNumUpDown.Value == 10)
            {
                // Set the font size to 10
                this.Font = new System.Drawing.Font("Arial Regular", 10);
                Properties.Settings.Default.fontSize = 10;
            }
            else if (fontNumUpDown.Value == 11)
            {
                // Set the font size to 11
                this.Font = new System.Drawing.Font("Arial Regular", 11);
                Properties.Settings.Default.fontSize = 11;
            }
            // Check if auto-saving settings is enabled
            if (saveAutoCheckBox.Checked)
            {
                // Save the font size setting
                Properties.Settings.Default.Save();
            }

        }

        private void northeastLabel_Click(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;

            // Get the primary screen's working area
            Screen primaryScreen = Screen.PrimaryScreen;
            Rectangle workingArea = primaryScreen.WorkingArea;

            // Calculate the top right position for the form
            int left = workingArea.Right - this.Width;
            int top = workingArea.Top;

            // Set the form's position
            this.Location = new Point(left, top);
        }

        private void southeastLabel_Click(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;

            // Get the primary screen's working area
            Screen primaryScreen = Screen.PrimaryScreen;
            Rectangle workingArea = primaryScreen.WorkingArea;

            // Calculate the bottom right position for the form
            int left = workingArea.Right - this.Width;
            int top = workingArea.Bottom - this.Height;

            // Set the form's position
            this.Location = new Point(left, top);
        }

        private void southwestLabel_Click(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;

            // Get the primary screen's working area
            Screen primaryScreen = Screen.PrimaryScreen;
            Rectangle workingArea = primaryScreen.WorkingArea;

            // Calculate the bottom left position for the form
            int left = workingArea.Left;
            int top = workingArea.Bottom - this.Height;

            // Set the form's position
            this.Location = new Point(left, top);
        }

        private void northLabel_Click(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;

            // Get the primary screen's working area
            Screen primaryScreen = Screen.PrimaryScreen;
            Rectangle workingArea = primaryScreen.WorkingArea;

            // Calculate the top center position for the form
            int top = workingArea.Top;
            int left = (workingArea.Width - this.Width) / 2;

            // Set the form's position
            this.Location = new Point(left, top);

        }

        private void southLabel_Click(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;

            // Get the primary screen's working area
            Screen primaryScreen = Screen.PrimaryScreen;
            Rectangle workingArea = primaryScreen.WorkingArea;

            // Calculate the bottom center position for the form
            int top = workingArea.Bottom - this.Height;
            int left = (workingArea.Width - this.Width) / 2;

            // Set the form's position
            this.Location = new Point(left, top);
        }

        private void westLabel_Click(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;

            // Get the primary screen's working area
            Screen primaryScreen = Screen.PrimaryScreen;
            Rectangle workingArea = primaryScreen.WorkingArea;

            // Calculate the left center position for the form
            int left = workingArea.Left;
            int top = (workingArea.Height - this.Height) / 2;

            // Set the form's position
            this.Location = new Point(left, top);
        }

        private void eastLabel_Click(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;

            // Get the primary screen's working area
            Screen primaryScreen = Screen.PrimaryScreen;
            Rectangle workingArea = primaryScreen.WorkingArea;

            // Calculate the right center position for the form
            int left = workingArea.Right - this.Width;
            int top = (workingArea.Height - this.Height) / 2;

            // Set the form's position
            this.Location = new Point(left, top);
        }

        private void keepDirStructCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If the user selects to keep directory structure, clear other options
            if (keepDirStructCheckBox.Checked)
            {
                createCustomDirCheckBox.Checked = false;
                copyFilesDirsCheckBox.Checked = false;
            }

            // If neither "Copy Files and Directories" nor "Create Custom Directory Structure" is selected,
            // automatically select "Keep Directory Structure"
            if (!copyFilesDirsCheckBox.Checked && !createCustomDirCheckBox.Checked)
            {
                keepDirStructCheckBox.Checked = true;
            }
        }

        private void createCustomDirCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If the user selects to create a custom directory structure, clear other options
            if (createCustomDirCheckBox.Checked)
            {
                keepDirStructCheckBox.Checked = false;
                copyFilesDirsCheckBox.Checked = false;
            }
            // If neither "Copy Files and Directories" nor "Create Custom Directory Structure" is selected,
            // automatically select "Keep Directory Structure"
            if (!copyFilesDirsCheckBox.Checked && !createCustomDirCheckBox.Checked)
            {
                keepDirStructCheckBox.Checked = true;
            }
        }

        private void copyFIlesDirsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If the user selects to copy files and directories, clear other options
            if (copyFilesDirsCheckBox.Checked)
            {
                keepDirStructCheckBox.Checked = false;
                createCustomDirCheckBox.Checked = false;
            }

            // If neither "Copy Files and Directories" nor "Create Custom Directory Structure" is selected,
            // automatically select "Keep Directory Structure"
            if (!copyFilesDirsCheckBox.Checked && !createCustomDirCheckBox.Checked)
            {
                keepDirStructCheckBox.Checked = true;
            }
        }

        private void multithreadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If multithreading is enabled, set the corresponding property and save settings if auto-save is checked
            if (multithreadCheckBox.Checked)
            {
                multiThread = true;
                Properties.Settings.Default.multithreading = multiThread;
                if (saveAutoCheckBox.Checked)
                {
                    Properties.Settings.Default.Save();
                }
            }
            else // If multithreading is disabled, set the corresponding property and save settings if auto-save is checked
            {
                multiThread = false;
                Properties.Settings.Default.multithreading = multiThread;
                if (saveAutoCheckBox.Checked)
                {
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void northwestLabel_Click(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;

            // Get the primary screen's working area
            Screen primaryScreen = Screen.PrimaryScreen;
            Rectangle workingArea = primaryScreen.WorkingArea;

            // Calculate the top left position for the form
            int left = workingArea.Left;
            int top = workingArea.Top;

            // Set the form's position
            this.Location = new Point(left, top);
        }

        private void priorityTrackBar_Scroll(object sender, EventArgs e)
        {
            // Set program priority based on the value of the priority trackbar
            if (priorityTrackBar.Value == 0)
            {
                priorityLabel.Text = "Program Priority: \nBelow Normal";
                Properties.Settings.Default.priority = "Below Normal";
                using (Process p = Process.GetCurrentProcess())
                {
                    p.PriorityClass = ProcessPriorityClass.BelowNormal;
                }
            }
            else if (priorityTrackBar.Value == 1)
            {
                priorityLabel.Text = "Program Priority: \nNormal";
                Properties.Settings.Default.priority = "Normal";
                using (Process p = Process.GetCurrentProcess())
                {
                    p.PriorityClass = ProcessPriorityClass.Normal;
                }
            }
            else if (priorityTrackBar.Value == 2)
            {
                priorityLabel.Text = "Program Priority: \nAbove Normal";
                Properties.Settings.Default.priority = "Above Normal";
                using (Process p = Process.GetCurrentProcess())
                {
                    p.PriorityClass = ProcessPriorityClass.AboveNormal;
                }
            }
            else if (priorityTrackBar.Value == 3)
            {
                priorityLabel.Text = "Program Priority: \nHigh";
                Properties.Settings.Default.priority = "High";
                using (Process p = Process.GetCurrentProcess())
                {
                    p.PriorityClass = ProcessPriorityClass.High;
                }
            }
            else if (priorityTrackBar.Value == 4)
            {
                priorityLabel.Text = "Program Priority: \nReal Time";
                Properties.Settings.Default.priority = "Real Time";
                using (Process p = Process.GetCurrentProcess())
                {
                    p.PriorityClass = ProcessPriorityClass.RealTime;
                }
            }
            // Save settings if auto-save is enabled
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }
        }
        static bool VerifyCopy(string sourceDir, string destDir)
        {
            // Compare file structures
            string[] sourceFiles = Directory.GetFiles(sourceDir, "*", System.IO.SearchOption.AllDirectories);
            string[] destFiles = Directory.GetFiles(destDir, "*", System.IO.SearchOption.AllDirectories);

            if (sourceFiles.Length != destFiles.Length)
            {
                return false; // Different number of files
            }

            // Compare file sizes and content using MD5 hash
            using (MD5 md5 = MD5.Create())
            {
                for (int i = 0; i < sourceFiles.Length; i++)
                {
                    string sourceFile = sourceFiles[i];
                    string destFile = destFiles[i];

                    long sourceSize = new FileInfo(sourceFile).Length;
                    long destSize = new FileInfo(destFile).Length;

                    if (sourceSize != destSize)
                    {
                        return false; // Different file size
                    }

                    using (FileStream sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
                    using (FileStream destStream = new FileStream(destFile, FileMode.Open, FileAccess.Read))
                    {
                        byte[] sourceHash = md5.ComputeHash(sourceStream);
                        byte[] destHash = md5.ComputeHash(destStream);

                        for (int j = 0; j < sourceHash.Length; j++)
                        {
                            if (sourceHash[j] != destHash[j])
                            {
                                return false; // Different file content
                            }
                        }
                    }
                }
            }

            return true; // Verification passed
        }

        private void logFileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Update the log file setting based on the checkbox state
            if (logFileCheckBox.Checked)
            {
                Properties.Settings.Default.logFile = true;
            }
            else
            {
                Properties.Settings.Default.logFile = false;
            }

            // Save settings if auto-save is enabled
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void opacityTrackBar_Scroll(object sender, EventArgs e)
        {
            // Calculate the opacity value based on the trackbar value
            double opacityValue = opacityTrackBar.Value / 100.0;

            // Convert the opacity value to an integer percentage
            int opacityText = Convert.ToInt32(opacityValue * 100);

            // Update the opacity label text to display the current opacity percentage
            opacityLabel.Text = "Opacity: \n" + opacityText.ToString() + "%";

            // Update the opacity setting in the application settings
            Properties.Settings.Default.opacity = opacityText;

            // Set the opacity of the form
            this.Opacity = opacityValue;

            // Save settings if auto-save is enabled
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }
        }

        int heightNow = 0;
        private void rollUpPicBox_Click(object sender, EventArgs e)
        {
            // Set the maximum and minimum size of the form
            this.MaximumSize = new System.Drawing.Size(1550, 1075);
            this.MinimumSize = new System.Drawing.Size(1550, 68);

            // Store the current height of the form
            heightNow = this.Height;

            // Set the height of the form to 68 pixels
            this.Height = 68;
        }

        private void rollDownPicBox_Click(object sender, EventArgs e)
        {
            // Set the maximum and minimum size of the form
            this.MaximumSize = new System.Drawing.Size(1550, 1075);
            this.MinimumSize = new System.Drawing.Size(1550, 695);

            // Adjust the height of the form based on the value of EXPANDTHAT
            if (EXPANDTHAT == false)
            {
                if (tabControl1.SelectedTab == cmdMainPage)
                {
                    if(fileDirDataGridView.Rows.Count > 0)
                    {
                        // Set the height to 1075 pixels if EXPANDTHAT is false
                        this.Height = 1075;
                    }
                    else
                    {
                        // Set the height to 695 pixels if EXPANDTHAT is false
                        this.Height = 695;
                    }

                }

                if (tabControl1.SelectedTab == cmdAboutPage)
                {
                        // Set the height to 695 pixels if EXPANDTHAT is false
                        this.Height = 695;
                }

                if (tabControl1.SelectedTab == cmdSkipPage)
                {
                    // Set the height to 695 pixels if EXPANDTHAT is false
                    this.Height = 695;
                }
                if (tabControl1.SelectedTab == cmdSettingsPage)
                {
                    // Set the height to 1075 pixels if EXPANDTHAT is false
                    this.Height = 1075;
                }

                if (tabControl1.SelectedTab == cmdCopyHistoryPage)
                {
                    // Set the height to 695 pixels if EXPANDTHAT is false
                    this.Height = 695;
                }

                if (tabControl1.SelectedTab == cmdExclusionsPage)
                {
                    // Set the height to 695 pixels if EXPANDTHAT is false
                    this.Height = 695;
                }
            }
            else
            {
                // Set the height to 1075 pixels if EXPANDTHAT is true
                this.Height = 1075;
            }
        }

        /// <summary>
        /// Exports data from a DataGridView to a text file.
        /// </summary>
        /// <param name="filePath">The file path to save the exported data.</param>
        private void ExportToTextFile(string filePath)
        {
            try
            {
                // Create a StreamWriter to write to the file
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    // Loop through each row in the DataGridView
                    foreach (DataGridViewRow row in exportDataGridView.Rows)
                    {
                        // Check if full paths option is selected
                        if (fullPathsCheckBox.Checked)
                        {
                            // Get the value from the first column (index 0)
                            object cellValueFullPath = row.Cells[0].Value;

                            // If the value is not null
                            if (cellValueFullPath != null)
                            {
                                // If the value represents a directory
                                if (Directory.Exists(cellValueFullPath.ToString()))
                                {
                                    // Get all files recursively from the directory
                                    foreach (var sourceFilePath in Directory.EnumerateFiles(cellValueFullPath.ToString(), "*", System.IO.SearchOption.AllDirectories))
                                    {
                                        // Get the relative path of the file
                                        var relativePath = Path.GetRelativePath(cellValueFullPath.ToString(), sourceFilePath);
                                        // Write the full path of the file to the text file
                                        sw.WriteLine(sourceFilePath.ToString());
                                    }
                                }
                                else
                                {
                                    // Write the full path to the text file
                                    sw.WriteLine(cellValueFullPath.ToString());
                                }
                            }
                        }
                        // Check if only names option is selected
                        else if (onlyNamesCheckBox.Checked)
                        {
                            // Get the value from the second column (index 1)
                            object cellValueFileDirNames = row.Cells[1].Value;

                            // If the value is not null
                            if (cellValueFileDirNames != null)
                            {
                                // If the value represents a directory
                                if (Directory.Exists(cellValueFileDirNames.ToString()))
                                {
                                    // Get all files recursively from the directory
                                    foreach (var sourceFilePath in Directory.EnumerateFiles(cellValueFileDirNames.ToString(), "*", System.IO.SearchOption.AllDirectories))
                                    {
                                        // Get the relative path of the file
                                        var relativePath = Path.GetRelativePath(cellValueFileDirNames.ToString(), sourceFilePath);
                                        // Write the full path of the file to the text file
                                        sw.WriteLine(sourceFilePath.ToString());
                                    }
                                }
                                else
                                {
                                    // Write the name of the file/directory to the text file
                                    sw.WriteLine(cellValueFileDirNames.ToString());
                                }
                            }
                        }
                    }
                }
                // Show success message if export is successful
                MessageBox.Show("Data exported successfully to: " + filePath, "Export Success - Copy That File/Directory Tool", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Show error message if export fails
                MessageBox.Show("Error exporting data: " + ex.Message, "Export Error - Copy That File/Directory Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            // Choose the file path for the text file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.Title = "Save As Text File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // Call the export method
                ExportToTextFile(filePath);
            }
        }


        //public class emailForm : Form
        //{
        //    private emailForm email;
        //    public emailForm()
        //    {
        //        InitializeComponent();
        //    }

        //    private void InitializeComponent()
        //    {
        //        email = new emailForm();
        //    }


        //    private void ChangeControlsForeColor(Control control, Color newColor)
        //    {
        //        // Iterate through all controls in the form
        //        foreach (Control ctrl in control.Controls)
        //        {
        //            // Change the ForeColor of the control to white
        //            ctrl.ForeColor = newColor;

        //            // If the control has child controls, recursively call the method
        //            if (ctrl.HasChildren)
        //            {
        //                ChangeControlsForeColor(ctrl, newColor);
        //            }
        //        }
        //    }
        //    private void ChangeLabelsForeColorBlack(Control control, Color newColor)
        //    {
        //        // Iterate through all controls in the form
        //        foreach (Control ctrl in control.Controls)
        //        {
        //            // Check if the control is a label
        //            if (ctrl is Label)
        //            {
        //                // Change the ForeColor of the label to black
        //                ((Label)ctrl).ForeColor = newColor;
        //            }

        //            // If the control has child controls, recursively call the method
        //            if (ctrl.HasChildren)
        //            {
        //                ChangeLabelsForeColorBlack(ctrl, newColor);
        //            }
        //        }
        //    }

        //    private void ChangeControlsBackColor(Control control, Color newColor)
        //    {
        //        // Iterate through all controls in the form
        //        foreach (Control ctrl in control.Controls)
        //        {
        //            // Change the ForeColor of the control to white
        //            ctrl.BackColor = newColor;

        //            // If the control has child controls, recursively call the method
        //            if (ctrl.HasChildren)
        //            {
        //                ChangeControlsBackColor(ctrl, newColor);
        //            }
        //        }
        //    }
        //    private void ChangeLabelsForeColorColorBlack(Control control, Color newColor)
        //    {
        //        // Iterate through all controls in the form
        //        foreach (Control ctrl in control.Controls)
        //        {
        //            // Check if the control is a label
        //            if (ctrl is Label)
        //            {
        //                // Change the ForeColor of the label to black
        //                ((Label)ctrl).BackColor = newColor;
        //            }

        //            // If the control has child controls, recursively call the method
        //            if (ctrl.HasChildren)
        //            {
        //                ChangeLabelsForeColorColorBlack(ctrl, newColor);
        //            }
        //        }
        //    }
        //}

        public static String globalMODE = "";
        public string GetStringVariable()
        {
            return globalMODE;
        }
        private void setUpEmailButton_Click(object sender, EventArgs e)
        {
            // Check if there are rows in the DataGridView
            if (exportDataGridView.Rows.Count > 0)
            {
                // Check if an item is selected in the skinsComboBox and set the globalMODE accordingly
                if (skinsComboBox.SelectedItem != null)
                {
                    string selectedSkin = skinsComboBox.SelectedItem.ToString();
                    switch (selectedSkin)
                    {
                        case "Dark Mode":
                            globalMODE = "Dark Mode";
                            break;
                        case "Light Mode":
                            // Assuming this option represents Light Mode
                            globalMODE = "Light Mode";
                            break;
                        default:
                            globalMODE = "Dark Mode"; // Default to Dark Mode if skin not recognized
                            break;
                    }
                    // Show the other form
                    new emailForm().ShowDialog();
                }
            }
        }

        // Method to get data from DataGridView
        public List<string> GetDataGridViewData()
        {
            List<string> data = new List<string>();

            foreach (DataGridViewRow row in fileDirDataGridView.Rows)
            {


                if (fullPathsCheckBox.Checked == true)
                {
                    // Assuming the first column is at index 0
                    object cellValueFullPath = row.Cells[0].Value;

                    if (cellValueFullPath != null)
                    {
                        if (Directory.Exists(cellValueFullPath.ToString()))
                        {

                            foreach (var sourceFilePath in Directory.EnumerateFiles(cellValueFullPath.ToString(), "*", System.IO.SearchOption.AllDirectories))
                            {
                                data.Add(sourceFilePath.ToString());
                            }
                        }
                        else
                        {
                            // Write the cell value to the text file
                            data.Add(cellValueFullPath.ToString());
                        }
                    }
                }
                else if (onlyNamesCheckBox.Checked == true)
                {
                    // Assuming the first column is at index 1
                    object cellValueFileDirNames = row.Cells[1].Value;

                    if (cellValueFileDirNames != null)
                    {
                        if (Directory.Exists(cellValueFileDirNames.ToString()))
                        {

                            foreach (var sourceFilePath in Directory.EnumerateFiles(cellValueFileDirNames.ToString(), "*", System.IO.SearchOption.AllDirectories))
                            {
                                data.Add(sourceFilePath.ToString());
                            }
                        }
                        else
                        {
                            data.Add(cellValueFileDirNames.ToString());
                        }
                    }
                }



            }

            return data;
        }

        // Method to export data to text file
        public void ExportDataToFile(string filePath, List<string> data)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (var item in data)
                {
                    sw.WriteLine(item);
                }
            }
        }

        private void allowedTextBox_TextChanged(object sender, EventArgs e)
        {
            // If the allowedTextBox contains only "*", append a dot and set the cursor after it
            if (allowedTextBox.Text == "*")
            {
                allowedTextBox.Text = "*.";
                allowedTextBox.SelectionStart = 2;
            }
        }

        private void excludedTextBox_TextChanged(object sender, EventArgs e)
        {
            // If the excludedTextBox contains only "*", append a dot and set the cursor after it
            if (excludedTextBox.Text == "*")
            {
                excludedTextBox.Text = "*.";
                excludedTextBox.SelectionStart = 2;
            }
        }

        static string GetApplicationName()
        {
            // Get the assembly that contains the entry point (Main method)
            Assembly assembly = Assembly.GetEntryAssembly();

            // Get the assembly's simple name (without the file extension)
            string appName = assembly?.GetName().Name;

            return appName ?? "UnknownApplication";
        }
        private bool IsStartupEnabled()
        {

            string appName = GetApplicationName();
            // MessageBox.Show($"Application Name: {appName}");
            // Check the registry to determine if startup is enabled
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", false);

            return registryKey?.GetValue(appName) != null;
        }

        private void UpdateStartupRegistry(bool enableStartup)
        {
            string appName = GetApplicationName();
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            string appPath = Application.ExecutablePath;
            if (enableStartup)
            {
                // Add or update the registry entry
                registryKey.SetValue(appName, appPath + " /onboot");
            }
            else
            {
                // Remove the registry entry
                registryKey.DeleteValue(appName, false);
            }
        }
        private void SetStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (startWithWindowsCheckBox.Checked)
                rk.SetValue("Copy That", Application.ExecutablePath);
            else
                rk.DeleteValue("Copy That", false);

        }

        private void SetStartup2()
        {
            try
            {
                string keys =
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run";
                string value = "CopyThat";

                if (startWithWindowsCheckBox.Checked)
                {
                    if (Registry.GetValue(keys, value, null) == null)
                    {
                        // if key doesn't exist
                        using (RegistryKey key =
                        Registry.CurrentUser.OpenSubKey
                        ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                        {
                            key.SetValue("CopyThat", (Application.ExecutablePath));
                            key.Dispose();
                            key.Flush();
                        }
                    }
                }
                else
                {
                    if (Registry.GetValue(keys, value, null) != null)
                    {
                        // if key doesn't exist
                        using (RegistryKey key =
                        Registry.CurrentUser.OpenSubKey
                        ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                        {
                            key.DeleteValue("CopyThat", false);
                            key.Dispose();
                            key.Flush();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void startWithWindowsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (startWithWindowsCheckBox.Checked == true)
            {
                Properties.Settings.Default.startWindows = true;
            }
            else
            {
                Properties.Settings.Default.startWindows = false;
            }
            SetStartup();
            SetStartup2();
            if (saveAutoCheckBox.Checked == true)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void nLabel_Click(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;

            // Get the primary screen's working area
            Screen primaryScreen = Screen.PrimaryScreen;
            Rectangle workingArea = primaryScreen.WorkingArea;

            // Calculate the top center position for the form
            int top = workingArea.Top;
            int left = (workingArea.Width - this.Width) / 2;

            // Set the form's position
            this.Location = new Point(left, top);
        }

        private void neLabel_Click(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;

            // Get the primary screen's working area
            Screen primaryScreen = Screen.PrimaryScreen;
            Rectangle workingArea = primaryScreen.WorkingArea;

            // Calculate the top right position for the form
            int left = workingArea.Right - this.Width;
            int top = workingArea.Top;

            // Set the form's position
            this.Location = new Point(left, top);
        }

        private void eLabel_Click(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;

            // Get the primary screen's working area
            Screen primaryScreen = Screen.PrimaryScreen;
            Rectangle workingArea = primaryScreen.WorkingArea;

            // Calculate the right center position for the form
            int left = workingArea.Right - this.Width;
            int top = (workingArea.Height - this.Height) / 2;

            // Set the form's position
            this.Location = new Point(left, top);
        }

        private void seLabel_Click(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;

            // Get the primary screen's working area
            Screen primaryScreen = Screen.PrimaryScreen;
            Rectangle workingArea = primaryScreen.WorkingArea;

            // Calculate the bottom right position for the form
            int left = workingArea.Right - this.Width;
            int top = workingArea.Bottom - this.Height;

            // Set the form's position
            this.Location = new Point(left, top);
        }

        private void sLabel_Click(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;

            // Get the primary screen's working area
            Screen primaryScreen = Screen.PrimaryScreen;
            Rectangle workingArea = primaryScreen.WorkingArea;

            // Calculate the bottom center position for the form
            int top = workingArea.Bottom - this.Height;
            int left = (workingArea.Width - this.Width) / 2;

            // Set the form's position
            this.Location = new Point(left, top);
        }

        private void swLabel_Click(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;

            // Get the primary screen's working area
            Screen primaryScreen = Screen.PrimaryScreen;
            Rectangle workingArea = primaryScreen.WorkingArea;

            // Calculate the bottom left position for the form
            int left = workingArea.Left;
            int top = workingArea.Bottom - this.Height;

            // Set the form's position
            this.Location = new Point(left, top);
        }

        private void wLabel_Click(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;

            // Get the primary screen's working area
            Screen primaryScreen = Screen.PrimaryScreen;
            Rectangle workingArea = primaryScreen.WorkingArea;

            // Calculate the left center position for the form
            int left = workingArea.Left;
            int top = (workingArea.Height - this.Height) / 2;

            // Set the form's position
            this.Location = new Point(left, top);
        }

        private void nwLabel_Click(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;

            // Get the primary screen's working area
            Screen primaryScreen = Screen.PrimaryScreen;
            Rectangle workingArea = primaryScreen.WorkingArea;

            // Calculate the top left position for the form
            int left = workingArea.Left;
            int top = workingArea.Top;

            // Set the form's position
            this.Location = new Point(left, top);
        }
    }
}