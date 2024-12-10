namespace Havoc__Copy_That
{
    partial class mainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            exitPicBox = new PictureBox();
            timeRemainingTimer = new System.Windows.Forms.Timer(components);
            getFoldersBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            COPYbackgroundWorker = new System.ComponentModel.BackgroundWorker();
            DELETEbackgroundWorker = new System.ComponentModel.BackgroundWorker();
            MOVEbackgroundWorker = new System.ComponentModel.BackgroundWorker();
            minimizePicBox = new PictureBox();
            settingsPicBox = new PictureBox();
            aboutPicBox = new PictureBox();
            expandTimer = new System.Windows.Forms.Timer(components);
            retractTimer = new System.Windows.Forms.Timer(components);
            openFileDialog = new OpenFileDialog();
            fileDirSizeBGW = new System.ComponentModel.BackgroundWorker();
            removeDirBGW = new System.ComponentModel.BackgroundWorker();
            cmdAboutPage = new TabPage();
            havocSoftwarePicBox = new PictureBox();
            copyThatPicBox = new PictureBox();
            creditsLabel = new Label();
            cmdCopyHistoryPage = new TabPage();
            cmdSkipPage = new TabPage();
            totalSkippedLabel = new Label();
            btnClearSkippedList = new Button();
            btnGoToInExplorer = new Button();
            skippedDataGridView = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            sourcePath = new DataGridViewTextBoxColumn();
            destinationPath = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            cmdMainPage = new TabPage();
            verifyCheckBox = new CheckBox();
            copyFilesDirsCheckBox = new CheckBox();
            createCustomDirCheckBox = new CheckBox();
            keepDirStructCheckBox = new CheckBox();
            totalHDSpaceLeftLabel = new Label();
            doNotOverwriteCHKBOX = new CheckBox();
            overwriteAllCHKBOX = new CheckBox();
            overwriteIfNewerCHKBOX = new CheckBox();
            filesIconLabel = new Label();
            removeFileButton = new Button();
            addFileButton = new Button();
            clearFileListButton = new Button();
            moveBottomPicBox = new PictureBox();
            moveBottomLabel = new Label();
            moveTopPicBox = new PictureBox();
            moveTopLabel = new Label();
            fileDownPicBox = new PictureBox();
            fileDownLabel = new Label();
            fileUpPicBox = new PictureBox();
            fileUpLabel = new Label();
            clearTextButton = new Button();
            searchTextBox = new TextBox();
            searchFileFolderLabel = new Label();
            fileListLabel = new Label();
            onFinishLabel = new Label();
            cmdLabel = new Label();
            onFinishComboBox = new ComboBox();
            skipButton = new Button();
            fileIconPicBox = new PictureBox();
            speedLabel = new Label();
            fileProcessedLabel = new Label();
            copyMoveDeleteComboBox = new ComboBox();
            totalCopiedProgressLabel = new Label();
            fileCountOnLabel = new Label();
            timeRemainingLabel = new Label();
            elapsedTimeLabel = new Label();
            pauseResumeButton = new Button();
            overallProgressLabel = new Label();
            fileProgressLabel = new Label();
            fileTotalProgressLabel = new Label();
            totalProgressLabel = new Label();
            fileProgressBar = new ProgressBar();
            totalProgressBar = new ProgressBar();
            fileDirDataGridView = new DataGridView();
            statusIcon = new DataGridViewImageColumn();
            statusColumn = new DataGridViewTextBoxColumn();
            filePathColumn = new DataGridViewTextBoxColumn();
            fileFolderNameColumn = new DataGridViewTextBoxColumn();
            fileSize = new DataGridViewTextBoxColumn();
            cancelButton = new Button();
            startButton = new Button();
            targetDirPicBox = new PictureBox();
            fromDirPicBox = new PictureBox();
            fileNamePicBox = new PictureBox();
            targetDirLabel = new Label();
            fromFilesDirLabel = new Label();
            filePathLabel = new Label();
            targetLabel = new Label();
            fromLabel = new Label();
            fileNameLabel = new Label();
            cmdSettingsPage = new TabPage();
            exportDataGridView = new DataGridView();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            exportFileListLabel = new Label();
            opacityLabel = new Label();
            opacityTrackBar = new TrackBar();
            logFileCheckBox = new CheckBox();
            priorityLabel = new Label();
            priorityTrackBar = new TrackBar();
            saveAutoCheckBox = new CheckBox();
            defaultSettingsButton = new Button();
            recSettingsButton = new Button();
            clearSettingsButton = new Button();
            saveSettingsButton = new Button();
            emailGroupBox = new GroupBox();
            setUpEmailButton = new Button();
            emailPathsCheckBox = new CheckBox();
            emailNamesCheckBox = new CheckBox();
            whenEmailingLabel = new Label();
            updateGroupBox = new GroupBox();
            updateManuallyCheckBox = new CheckBox();
            checkForUpdatesButton = new Button();
            updateBetaCheckBox = new CheckBox();
            updateAutoCheckBox = new CheckBox();
            performanceGroupBox = new GroupBox();
            kbLabel = new Label();
            multithreadCheckBox = new CheckBox();
            cmOnlyIfLabel = new Label();
            overMBCheckBox = new CheckBox();
            underMBCheckBox = new CheckBox();
            setMBGBOLabel = new Label();
            setMBGBULabel = new Label();
            setMBGBUnderNumUD = new NumericUpDown();
            setMBUmderLabel = new Label();
            setMBGBOverNumUD = new NumericUpDown();
            setMBGBOverLabel = new Label();
            bufferNumUpDown = new NumericUpDown();
            setBufferLabel = new Label();
            otherSettingsGroupBox = new GroupBox();
            seLabel = new Label();
            sLabel = new Label();
            swLabel = new Label();
            eLabel = new Label();
            neLabel = new Label();
            nLabel = new Label();
            nwLabel = new Label();
            wLabel = new Label();
            label1 = new Label();
            startWithWindowsCheckBox = new CheckBox();
            serialMaskedTextBox = new MaskedTextBox();
            registerButton = new Button();
            serialNumberLabel = new Label();
            errorOccursLabel = new Label();
            restartCheckBox = new CheckBox();
            closeProgramCheckBox = new CheckBox();
            fileDirSettingsGroupBox = new GroupBox();
            exportButton = new Button();
            zipSettingsLabel = new Label();
            zipTogetherCheckBox = new CheckBox();
            zipSeparateCheckBox = new CheckBox();
            exportListLabel = new Label();
            fullPathsCheckBox = new CheckBox();
            onlyNamesCheckBox = new CheckBox();
            soundsGroupBox = new GroupBox();
            onAddFilesCheckBox = new CheckBox();
            onErrorCheckBox = new CheckBox();
            onCancelCheckBox = new CheckBox();
            onFinishCheckBox = new CheckBox();
            skinsLanguageGoupBox = new GroupBox();
            fontNumUpDown = new NumericUpDown();
            fontsLabel = new Label();
            skinsComboBox = new ComboBox();
            skinsLabel = new Label();
            languageComboBox = new ComboBox();
            languageLabel = new Label();
            windowGroupBox = new GroupBox();
            contextMenuCheckBox = new CheckBox();
            pasteLabel = new Label();
            settingsWindowLabel = new Label();
            minimizeSystemTrayCheckBox = new CheckBox();
            alwaysOnTopCheckBox = new CheckBox();
            confirmDragDropCheckBox = new CheckBox();
            dragDropLabel = new Label();
            tabControl1 = new TabControl();
            cmdExclusionsPage = new TabPage();
            btnClearExcluded = new Button();
            btnRemoveExcluded = new Button();
            btnAddExcluded = new Button();
            btnClearAllowed = new Button();
            btnRemoveAllowed = new Button();
            btnAddAllowed = new Button();
            excludedTextBox = new TextBox();
            allowedTextBox = new TextBox();
            excludedLabel = new Label();
            allowedLabel = new Label();
            excludedExtListBox = new ListBox();
            allowedExtListBox = new ListBox();
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            showCopyThat = new ToolStripMenuItem();
            exitCopyThat = new ToolStripMenuItem();
            rollDownPicBox = new PictureBox();
            rollUpPicBox = new PictureBox();
            titleLabel = new Label();
            scrollTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)exitPicBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minimizePicBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)settingsPicBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)aboutPicBox).BeginInit();
            cmdAboutPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)havocSoftwarePicBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)copyThatPicBox).BeginInit();
            cmdSkipPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)skippedDataGridView).BeginInit();
            cmdMainPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)moveBottomPicBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)moveTopPicBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileDownPicBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileUpPicBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileIconPicBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileDirDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)targetDirPicBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fromDirPicBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileNamePicBox).BeginInit();
            cmdSettingsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)exportDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)opacityTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)priorityTrackBar).BeginInit();
            emailGroupBox.SuspendLayout();
            updateGroupBox.SuspendLayout();
            performanceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)setMBGBUnderNumUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)setMBGBOverNumUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bufferNumUpDown).BeginInit();
            otherSettingsGroupBox.SuspendLayout();
            fileDirSettingsGroupBox.SuspendLayout();
            soundsGroupBox.SuspendLayout();
            skinsLanguageGoupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fontNumUpDown).BeginInit();
            windowGroupBox.SuspendLayout();
            tabControl1.SuspendLayout();
            cmdExclusionsPage.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rollDownPicBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rollUpPicBox).BeginInit();
            SuspendLayout();
            // 
            // exitPicBox
            // 
            exitPicBox.BackColor = Color.Transparent;
            exitPicBox.Image = Properties.Resources.icons8_close_40;
            exitPicBox.Location = new Point(1497, 20);
            exitPicBox.Name = "exitPicBox";
            exitPicBox.Size = new Size(37, 42);
            exitPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            exitPicBox.TabIndex = 23;
            exitPicBox.TabStop = false;
            exitPicBox.Click += exitPicBox_Click;
            // 
            // timeRemainingTimer
            // 
            timeRemainingTimer.Interval = 1000;
            timeRemainingTimer.Tick += timeRemainingTimer_Tick;
            // 
            // getFoldersBackgroundWorker
            // 
            getFoldersBackgroundWorker.WorkerSupportsCancellation = true;
            getFoldersBackgroundWorker.DoWork += getFoldersBackgroundWorker_DoWork;
            getFoldersBackgroundWorker.RunWorkerCompleted += getFoldersBackgroundWorker_RunWorkerCompleted;
            // 
            // COPYbackgroundWorker
            // 
            COPYbackgroundWorker.WorkerReportsProgress = true;
            COPYbackgroundWorker.WorkerSupportsCancellation = true;
            COPYbackgroundWorker.DoWork += COPYbackgroundWorker_DoWork;
            COPYbackgroundWorker.RunWorkerCompleted += COPYbackgroundWorker_RunWorkerCompleted;
            // 
            // DELETEbackgroundWorker
            // 
            DELETEbackgroundWorker.WorkerSupportsCancellation = true;
            DELETEbackgroundWorker.DoWork += DELETEbackgroundWorker_DoWork;
            DELETEbackgroundWorker.RunWorkerCompleted += DELETEbackgroundWorker_RunWorkerCompleted;
            // 
            // MOVEbackgroundWorker
            // 
            MOVEbackgroundWorker.WorkerReportsProgress = true;
            MOVEbackgroundWorker.WorkerSupportsCancellation = true;
            MOVEbackgroundWorker.DoWork += MOVEbackgroundWorker_DoWork;
            MOVEbackgroundWorker.RunWorkerCompleted += MOVEbackgroundWorker_RunWorkerCompleted;
            // 
            // minimizePicBox
            // 
            minimizePicBox.BackColor = Color.Transparent;
            minimizePicBox.Image = Properties.Resources.icons8_minimize_40;
            minimizePicBox.Location = new Point(1432, 23);
            minimizePicBox.Name = "minimizePicBox";
            minimizePicBox.Size = new Size(37, 42);
            minimizePicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            minimizePicBox.TabIndex = 24;
            minimizePicBox.TabStop = false;
            minimizePicBox.Click += minimizePicBox_Click;
            // 
            // settingsPicBox
            // 
            settingsPicBox.BackColor = Color.Transparent;
            settingsPicBox.Image = Properties.Resources.icons8_settings_40;
            settingsPicBox.Location = new Point(1302, 23);
            settingsPicBox.Name = "settingsPicBox";
            settingsPicBox.Size = new Size(37, 42);
            settingsPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            settingsPicBox.TabIndex = 32;
            settingsPicBox.TabStop = false;
            settingsPicBox.Click += settingsPicBox_Click;
            // 
            // aboutPicBox
            // 
            aboutPicBox.BackColor = Color.Transparent;
            aboutPicBox.Image = Properties.Resources.icons8_about_40;
            aboutPicBox.Location = new Point(1367, 23);
            aboutPicBox.Name = "aboutPicBox";
            aboutPicBox.Size = new Size(37, 42);
            aboutPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            aboutPicBox.TabIndex = 33;
            aboutPicBox.TabStop = false;
            aboutPicBox.Click += aboutPicBox_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.Multiselect = true;
            openFileDialog.ReadOnlyChecked = true;
            // 
            // fileDirSizeBGW
            // 
            fileDirSizeBGW.DoWork += fileDirSizeBGW_DoWork;
            fileDirSizeBGW.RunWorkerCompleted += fileDirSizeBGW_RunWorkerCompleted;
            // 
            // removeDirBGW
            // 
            removeDirBGW.DoWork += removeDirBGW_DoWork;
            removeDirBGW.RunWorkerCompleted += removeDirBGW_RunWorkerCompleted;
            // 
            // cmdAboutPage
            // 
            cmdAboutPage.BackColor = Color.Black;
            cmdAboutPage.BackgroundImageLayout = ImageLayout.Stretch;
            cmdAboutPage.Controls.Add(havocSoftwarePicBox);
            cmdAboutPage.Controls.Add(copyThatPicBox);
            cmdAboutPage.Controls.Add(creditsLabel);
            cmdAboutPage.Location = new Point(4, 30);
            cmdAboutPage.Name = "cmdAboutPage";
            cmdAboutPage.Padding = new Padding(3);
            cmdAboutPage.Size = new Size(1517, 961);
            cmdAboutPage.TabIndex = 4;
            cmdAboutPage.Text = "- About";
            cmdAboutPage.MouseDown += cmdAboutPage_MouseDown;
            // 
            // havocSoftwarePicBox
            // 
            havocSoftwarePicBox.BackgroundImageLayout = ImageLayout.Stretch;
            havocSoftwarePicBox.Image = (Image)resources.GetObject("havocSoftwarePicBox.Image");
            havocSoftwarePicBox.Location = new Point(774, 6);
            havocSoftwarePicBox.Name = "havocSoftwarePicBox";
            havocSoftwarePicBox.Size = new Size(749, 385);
            havocSoftwarePicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            havocSoftwarePicBox.TabIndex = 105;
            havocSoftwarePicBox.TabStop = false;
            // 
            // copyThatPicBox
            // 
            copyThatPicBox.BackgroundImageLayout = ImageLayout.Stretch;
            copyThatPicBox.Image = Properties.Resources.Copy_That_Logo;
            copyThatPicBox.Location = new Point(-7, 6);
            copyThatPicBox.Name = "copyThatPicBox";
            copyThatPicBox.Size = new Size(749, 385);
            copyThatPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            copyThatPicBox.TabIndex = 104;
            copyThatPicBox.TabStop = false;
            // 
            // creditsLabel
            // 
            creditsLabel.AutoSize = true;
            creditsLabel.BackColor = Color.Transparent;
            creditsLabel.Font = new Font("Cascadia Code", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            creditsLabel.Location = new Point(496, 394);
            creditsLabel.Name = "creditsLabel";
            creditsLabel.Size = new Size(524, 470);
            creditsLabel.TabIndex = 35;
            creditsLabel.Text = "By: Havoc\r\n\r\nVersion: 1.0.0\r\n\r\nIDE: Visual Studio 2022\r\n\r\nProgramming Language: C#\r\n\r\nFramework: .Net 8.0\r\n\r\n";
            creditsLabel.TextAlign = ContentAlignment.MiddleCenter;
            creditsLabel.MouseDown += creditsLabel_MouseDown;
            // 
            // cmdCopyHistoryPage
            // 
            cmdCopyHistoryPage.BackColor = Color.Black;
            cmdCopyHistoryPage.BackgroundImageLayout = ImageLayout.Stretch;
            cmdCopyHistoryPage.Location = new Point(4, 34);
            cmdCopyHistoryPage.Name = "cmdCopyHistoryPage";
            cmdCopyHistoryPage.Padding = new Padding(3);
            cmdCopyHistoryPage.Size = new Size(1517, 957);
            cmdCopyHistoryPage.TabIndex = 2;
            cmdCopyHistoryPage.Text = "- Copy History";
            cmdCopyHistoryPage.MouseDown += cmdCopyHistoryPage_MouseDown;
            // 
            // cmdSkipPage
            // 
            cmdSkipPage.BackColor = Color.Black;
            cmdSkipPage.BackgroundImageLayout = ImageLayout.Stretch;
            cmdSkipPage.Controls.Add(totalSkippedLabel);
            cmdSkipPage.Controls.Add(btnClearSkippedList);
            cmdSkipPage.Controls.Add(btnGoToInExplorer);
            cmdSkipPage.Controls.Add(skippedDataGridView);
            cmdSkipPage.Location = new Point(4, 34);
            cmdSkipPage.Name = "cmdSkipPage";
            cmdSkipPage.Padding = new Padding(3);
            cmdSkipPage.Size = new Size(1517, 957);
            cmdSkipPage.TabIndex = 1;
            cmdSkipPage.Text = "- Skipped Files";
            cmdSkipPage.MouseDown += cmdSkipPage_MouseDown;
            // 
            // totalSkippedLabel
            // 
            totalSkippedLabel.AutoSize = true;
            totalSkippedLabel.BackColor = Color.Transparent;
            totalSkippedLabel.Location = new Point(632, 30);
            totalSkippedLabel.Name = "totalSkippedLabel";
            totalSkippedLabel.Size = new Size(182, 21);
            totalSkippedLabel.TabIndex = 85;
            totalSkippedLabel.Text = "Total Skipped Files: 0";
            // 
            // btnClearSkippedList
            // 
            btnClearSkippedList.BackColor = Color.Black;
            btnClearSkippedList.Location = new Point(1176, 25);
            btnClearSkippedList.Name = "btnClearSkippedList";
            btnClearSkippedList.Size = new Size(335, 34);
            btnClearSkippedList.TabIndex = 75;
            btnClearSkippedList.Text = "Clear Skipped List";
            btnClearSkippedList.UseVisualStyleBackColor = false;
            btnClearSkippedList.Click += btnClearSkippedList_Click;
            // 
            // btnGoToInExplorer
            // 
            btnGoToInExplorer.BackColor = Color.Black;
            btnGoToInExplorer.Location = new Point(6, 25);
            btnGoToInExplorer.Name = "btnGoToInExplorer";
            btnGoToInExplorer.Size = new Size(335, 34);
            btnGoToInExplorer.TabIndex = 73;
            btnGoToInExplorer.Text = "Open File In Explorer";
            btnGoToInExplorer.UseVisualStyleBackColor = false;
            btnGoToInExplorer.Click += btnGoToInExplorer_Click;
            // 
            // skippedDataGridView
            // 
            skippedDataGridView.AllowUserToAddRows = false;
            skippedDataGridView.AllowUserToDeleteRows = false;
            skippedDataGridView.AllowUserToOrderColumns = true;
            skippedDataGridView.AllowUserToResizeColumns = false;
            skippedDataGridView.AllowUserToResizeRows = false;
            skippedDataGridView.BackgroundColor = Color.DarkGray;
            skippedDataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            skippedDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            skippedDataGridView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, sourcePath, destinationPath, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            skippedDataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            skippedDataGridView.Location = new Point(4, 65);
            skippedDataGridView.MultiSelect = false;
            skippedDataGridView.Name = "skippedDataGridView";
            skippedDataGridView.ReadOnly = true;
            skippedDataGridView.RowHeadersVisible = false;
            skippedDataGridView.RowHeadersWidth = 62;
            skippedDataGridView.ScrollBars = ScrollBars.Vertical;
            skippedDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            skippedDataGridView.Size = new Size(1508, 507);
            skippedDataGridView.TabIndex = 72;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Status";
            dataGridViewTextBoxColumn1.MinimumWidth = 8;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.True;
            dataGridViewTextBoxColumn1.Width = 300;
            // 
            // sourcePath
            // 
            sourcePath.HeaderText = "Source File Path";
            sourcePath.MinimumWidth = 8;
            sourcePath.Name = "sourcePath";
            sourcePath.ReadOnly = true;
            sourcePath.Width = 300;
            // 
            // destinationPath
            // 
            destinationPath.HeaderText = "Destination File Path";
            destinationPath.MinimumWidth = 8;
            destinationPath.Name = "destinationPath";
            destinationPath.ReadOnly = true;
            destinationPath.Width = 300;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "File Name";
            dataGridViewTextBoxColumn3.MinimumWidth = 8;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 400;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "File's Size";
            dataGridViewTextBoxColumn4.MinimumWidth = 8;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Width = 225;
            // 
            // cmdMainPage
            // 
            cmdMainPage.BackColor = Color.Black;
            cmdMainPage.BackgroundImageLayout = ImageLayout.Stretch;
            cmdMainPage.Controls.Add(verifyCheckBox);
            cmdMainPage.Controls.Add(copyFilesDirsCheckBox);
            cmdMainPage.Controls.Add(createCustomDirCheckBox);
            cmdMainPage.Controls.Add(keepDirStructCheckBox);
            cmdMainPage.Controls.Add(totalHDSpaceLeftLabel);
            cmdMainPage.Controls.Add(doNotOverwriteCHKBOX);
            cmdMainPage.Controls.Add(overwriteAllCHKBOX);
            cmdMainPage.Controls.Add(overwriteIfNewerCHKBOX);
            cmdMainPage.Controls.Add(filesIconLabel);
            cmdMainPage.Controls.Add(removeFileButton);
            cmdMainPage.Controls.Add(addFileButton);
            cmdMainPage.Controls.Add(clearFileListButton);
            cmdMainPage.Controls.Add(moveBottomPicBox);
            cmdMainPage.Controls.Add(moveBottomLabel);
            cmdMainPage.Controls.Add(moveTopPicBox);
            cmdMainPage.Controls.Add(moveTopLabel);
            cmdMainPage.Controls.Add(fileDownPicBox);
            cmdMainPage.Controls.Add(fileDownLabel);
            cmdMainPage.Controls.Add(fileUpPicBox);
            cmdMainPage.Controls.Add(fileUpLabel);
            cmdMainPage.Controls.Add(clearTextButton);
            cmdMainPage.Controls.Add(searchTextBox);
            cmdMainPage.Controls.Add(searchFileFolderLabel);
            cmdMainPage.Controls.Add(fileListLabel);
            cmdMainPage.Controls.Add(onFinishLabel);
            cmdMainPage.Controls.Add(cmdLabel);
            cmdMainPage.Controls.Add(onFinishComboBox);
            cmdMainPage.Controls.Add(skipButton);
            cmdMainPage.Controls.Add(fileIconPicBox);
            cmdMainPage.Controls.Add(speedLabel);
            cmdMainPage.Controls.Add(fileProcessedLabel);
            cmdMainPage.Controls.Add(copyMoveDeleteComboBox);
            cmdMainPage.Controls.Add(totalCopiedProgressLabel);
            cmdMainPage.Controls.Add(fileCountOnLabel);
            cmdMainPage.Controls.Add(timeRemainingLabel);
            cmdMainPage.Controls.Add(elapsedTimeLabel);
            cmdMainPage.Controls.Add(pauseResumeButton);
            cmdMainPage.Controls.Add(overallProgressLabel);
            cmdMainPage.Controls.Add(fileProgressLabel);
            cmdMainPage.Controls.Add(fileTotalProgressLabel);
            cmdMainPage.Controls.Add(totalProgressLabel);
            cmdMainPage.Controls.Add(fileProgressBar);
            cmdMainPage.Controls.Add(totalProgressBar);
            cmdMainPage.Controls.Add(fileDirDataGridView);
            cmdMainPage.Controls.Add(cancelButton);
            cmdMainPage.Controls.Add(startButton);
            cmdMainPage.Controls.Add(targetDirPicBox);
            cmdMainPage.Controls.Add(fromDirPicBox);
            cmdMainPage.Controls.Add(fileNamePicBox);
            cmdMainPage.Controls.Add(targetDirLabel);
            cmdMainPage.Controls.Add(fromFilesDirLabel);
            cmdMainPage.Controls.Add(filePathLabel);
            cmdMainPage.Controls.Add(targetLabel);
            cmdMainPage.Controls.Add(fromLabel);
            cmdMainPage.Controls.Add(fileNameLabel);
            cmdMainPage.ForeColor = Color.White;
            cmdMainPage.Location = new Point(4, 30);
            cmdMainPage.Name = "cmdMainPage";
            cmdMainPage.Padding = new Padding(3);
            cmdMainPage.Size = new Size(1517, 961);
            cmdMainPage.TabIndex = 0;
            cmdMainPage.Text = "- Home";
            cmdMainPage.MouseDown += cmdMainPage_MouseDown;
            // 
            // verifyCheckBox
            // 
            verifyCheckBox.AutoSize = true;
            verifyCheckBox.Location = new Point(1107, 634);
            verifyCheckBox.Name = "verifyCheckBox";
            verifyCheckBox.Size = new Size(235, 25);
            verifyCheckBox.TabIndex = 116;
            verifyCheckBox.Text = "Verify Files After Copying";
            verifyCheckBox.UseVisualStyleBackColor = true;
            // 
            // copyFilesDirsCheckBox
            // 
            copyFilesDirsCheckBox.AutoSize = true;
            copyFilesDirsCheckBox.BackColor = Color.Transparent;
            copyFilesDirsCheckBox.ForeColor = Color.White;
            copyFilesDirsCheckBox.Location = new Point(784, 433);
            copyFilesDirsCheckBox.Name = "copyFilesDirsCheckBox";
            copyFilesDirsCheckBox.Size = new Size(322, 25);
            copyFilesDirsCheckBox.TabIndex = 115;
            copyFilesDirsCheckBox.Text = "Copy Only Files/Dirs. Inside Folders";
            copyFilesDirsCheckBox.UseVisualStyleBackColor = false;
            copyFilesDirsCheckBox.CheckedChanged += copyFIlesDirsCheckBox_CheckedChanged;
            // 
            // createCustomDirCheckBox
            // 
            createCustomDirCheckBox.AutoSize = true;
            createCustomDirCheckBox.BackColor = Color.Transparent;
            createCustomDirCheckBox.ForeColor = Color.White;
            createCustomDirCheckBox.Location = new Point(503, 433);
            createCustomDirCheckBox.Name = "createCustomDirCheckBox";
            createCustomDirCheckBox.Size = new Size(231, 25);
            createCustomDirCheckBox.TabIndex = 114;
            createCustomDirCheckBox.Text = "Create Custom Dir. Prior";
            createCustomDirCheckBox.UseVisualStyleBackColor = false;
            createCustomDirCheckBox.CheckedChanged += createCustomDirCheckBox_CheckedChanged;
            // 
            // keepDirStructCheckBox
            // 
            keepDirStructCheckBox.AutoSize = true;
            keepDirStructCheckBox.BackColor = Color.Transparent;
            keepDirStructCheckBox.Checked = true;
            keepDirStructCheckBox.CheckState = CheckState.Checked;
            keepDirStructCheckBox.ForeColor = Color.White;
            keepDirStructCheckBox.Location = new Point(211, 433);
            keepDirStructCheckBox.Name = "keepDirStructCheckBox";
            keepDirStructCheckBox.Size = new Size(233, 25);
            keepDirStructCheckBox.TabIndex = 113;
            keepDirStructCheckBox.Text = "Keep Directory Structure";
            keepDirStructCheckBox.UseVisualStyleBackColor = false;
            keepDirStructCheckBox.CheckedChanged += keepDirStructCheckBox_CheckedChanged;
            // 
            // totalHDSpaceLeftLabel
            // 
            totalHDSpaceLeftLabel.AutoSize = true;
            totalHDSpaceLeftLabel.BackColor = Color.Transparent;
            totalHDSpaceLeftLabel.ForeColor = Color.White;
            totalHDSpaceLeftLabel.Location = new Point(1058, 393);
            totalHDSpaceLeftLabel.Name = "totalHDSpaceLeftLabel";
            totalHDSpaceLeftLabel.Size = new Size(250, 21);
            totalHDSpaceLeftLabel.TabIndex = 112;
            totalHDSpaceLeftLabel.Text = "Total Space: 0 Bytes / 0 Bytes";
            // 
            // doNotOverwriteCHKBOX
            // 
            doNotOverwriteCHKBOX.AutoSize = true;
            doNotOverwriteCHKBOX.BackColor = Color.Transparent;
            doNotOverwriteCHKBOX.ForeColor = Color.White;
            doNotOverwriteCHKBOX.Location = new Point(784, 393);
            doNotOverwriteCHKBOX.Name = "doNotOverwriteCHKBOX";
            doNotOverwriteCHKBOX.Size = new Size(217, 25);
            doNotOverwriteCHKBOX.TabIndex = 111;
            doNotOverwriteCHKBOX.Text = "Do Not Overwrite Files";
            doNotOverwriteCHKBOX.UseVisualStyleBackColor = false;
            doNotOverwriteCHKBOX.CheckedChanged += doNotOverwriteCHKBOX_CheckedChanged;
            // 
            // overwriteAllCHKBOX
            // 
            overwriteAllCHKBOX.AutoSize = true;
            overwriteAllCHKBOX.BackColor = Color.Transparent;
            overwriteAllCHKBOX.ForeColor = Color.White;
            overwriteAllCHKBOX.Location = new Point(503, 393);
            overwriteAllCHKBOX.Name = "overwriteAllCHKBOX";
            overwriteAllCHKBOX.Size = new Size(179, 25);
            overwriteAllCHKBOX.TabIndex = 110;
            overwriteAllCHKBOX.Text = "Overwrite All Files";
            overwriteAllCHKBOX.UseVisualStyleBackColor = false;
            overwriteAllCHKBOX.CheckedChanged += overwriteAllCHKBOX_CheckedChanged;
            // 
            // overwriteIfNewerCHKBOX
            // 
            overwriteIfNewerCHKBOX.AutoSize = true;
            overwriteIfNewerCHKBOX.BackColor = Color.Transparent;
            overwriteIfNewerCHKBOX.Checked = true;
            overwriteIfNewerCHKBOX.CheckState = CheckState.Checked;
            overwriteIfNewerCHKBOX.ForeColor = Color.White;
            overwriteIfNewerCHKBOX.Location = new Point(211, 393);
            overwriteIfNewerCHKBOX.Name = "overwriteIfNewerCHKBOX";
            overwriteIfNewerCHKBOX.Size = new Size(218, 25);
            overwriteIfNewerCHKBOX.TabIndex = 109;
            overwriteIfNewerCHKBOX.Text = "Overwrite File If Newer";
            overwriteIfNewerCHKBOX.UseVisualStyleBackColor = false;
            overwriteIfNewerCHKBOX.CheckedChanged += overwriteIfNewerCHKBOX_CheckedChanged;
            // 
            // filesIconLabel
            // 
            filesIconLabel.AutoSize = true;
            filesIconLabel.BackColor = Color.Transparent;
            filesIconLabel.ForeColor = Color.White;
            filesIconLabel.Location = new Point(1184, 197);
            filesIconLabel.Name = "filesIconLabel";
            filesIconLabel.Size = new Size(94, 21);
            filesIconLabel.TabIndex = 108;
            filesIconLabel.Text = "File's Icon:";
            // 
            // removeFileButton
            // 
            removeFileButton.BackColor = Color.Black;
            removeFileButton.ForeColor = Color.White;
            removeFileButton.Location = new Point(1096, 263);
            removeFileButton.Name = "removeFileButton";
            removeFileButton.Size = new Size(193, 36);
            removeFileButton.TabIndex = 107;
            removeFileButton.Text = "- File/Folder";
            removeFileButton.UseVisualStyleBackColor = false;
            removeFileButton.Click += removeFileButton_Click;
            // 
            // addFileButton
            // 
            addFileButton.BackColor = Color.Black;
            addFileButton.ForeColor = Color.White;
            addFileButton.Location = new Point(913, 263);
            addFileButton.Name = "addFileButton";
            addFileButton.Size = new Size(160, 36);
            addFileButton.TabIndex = 106;
            addFileButton.Text = "+ File(s)";
            addFileButton.UseVisualStyleBackColor = false;
            addFileButton.Click += addFileButton_Click;
            // 
            // clearFileListButton
            // 
            clearFileListButton.BackColor = Color.Black;
            clearFileListButton.ForeColor = Color.White;
            clearFileListButton.Location = new Point(1309, 263);
            clearFileListButton.Name = "clearFileListButton";
            clearFileListButton.Size = new Size(196, 36);
            clearFileListButton.TabIndex = 105;
            clearFileListButton.Text = "Clear File List";
            clearFileListButton.UseVisualStyleBackColor = false;
            clearFileListButton.Click += clearFileListButton_Click;
            // 
            // moveBottomPicBox
            // 
            moveBottomPicBox.BackColor = Color.Transparent;
            moveBottomPicBox.Image = Properties.Resources.icons8_downchevron_40;
            moveBottomPicBox.Location = new Point(1027, 626);
            moveBottomPicBox.Name = "moveBottomPicBox";
            moveBottomPicBox.Size = new Size(37, 42);
            moveBottomPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            moveBottomPicBox.TabIndex = 104;
            moveBottomPicBox.TabStop = false;
            moveBottomPicBox.Click += moveBottomPicBox_Click;
            // 
            // moveBottomLabel
            // 
            moveBottomLabel.AutoSize = true;
            moveBottomLabel.Location = new Point(801, 635);
            moveBottomLabel.Name = "moveBottomLabel";
            moveBottomLabel.Size = new Size(174, 21);
            moveBottomLabel.TabIndex = 103;
            moveBottomLabel.Text = "Move File to Bottom:";
            // 
            // moveTopPicBox
            // 
            moveTopPicBox.BackColor = Color.Transparent;
            moveTopPicBox.Image = Properties.Resources.icons8_chevron_40;
            moveTopPicBox.Location = new Point(755, 622);
            moveTopPicBox.Name = "moveTopPicBox";
            moveTopPicBox.Size = new Size(37, 42);
            moveTopPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            moveTopPicBox.TabIndex = 102;
            moveTopPicBox.TabStop = false;
            moveTopPicBox.Click += moveTopPicBox_Click;
            // 
            // moveTopLabel
            // 
            moveTopLabel.AutoSize = true;
            moveTopLabel.Location = new Point(526, 635);
            moveTopLabel.Name = "moveTopLabel";
            moveTopLabel.Size = new Size(180, 21);
            moveTopLabel.TabIndex = 101;
            moveTopLabel.Text = "Move File/Dir. to Top:";
            // 
            // fileDownPicBox
            // 
            fileDownPicBox.BackColor = Color.Transparent;
            fileDownPicBox.Image = Properties.Resources.icons8_down_40;
            fileDownPicBox.Location = new Point(483, 623);
            fileDownPicBox.Name = "fileDownPicBox";
            fileDownPicBox.Size = new Size(37, 42);
            fileDownPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            fileDownPicBox.TabIndex = 100;
            fileDownPicBox.TabStop = false;
            fileDownPicBox.Click += fileDownPicBox_Click;
            // 
            // fileDownLabel
            // 
            fileDownLabel.AutoSize = true;
            fileDownLabel.Location = new Point(255, 635);
            fileDownLabel.Name = "fileDownLabel";
            fileDownLabel.Size = new Size(176, 21);
            fileDownLabel.TabIndex = 99;
            fileDownLabel.Text = "Move File/Dir. Down:";
            // 
            // fileUpPicBox
            // 
            fileUpPicBox.BackColor = Color.Transparent;
            fileUpPicBox.Image = Properties.Resources.icons8_up_40;
            fileUpPicBox.Location = new Point(211, 626);
            fileUpPicBox.Name = "fileUpPicBox";
            fileUpPicBox.Size = new Size(37, 42);
            fileUpPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            fileUpPicBox.TabIndex = 98;
            fileUpPicBox.TabStop = false;
            fileUpPicBox.Click += fileUpPicBox_Click;
            // 
            // fileUpLabel
            // 
            fileUpLabel.AutoSize = true;
            fileUpLabel.Location = new Point(7, 635);
            fileUpLabel.Name = "fileUpLabel";
            fileUpLabel.Size = new Size(153, 21);
            fileUpLabel.TabIndex = 97;
            fileUpLabel.Text = "Move File/Dir. Up:";
            // 
            // clearTextButton
            // 
            clearTextButton.BackColor = Color.Black;
            clearTextButton.ForeColor = Color.White;
            clearTextButton.Location = new Point(1292, 589);
            clearTextButton.Name = "clearTextButton";
            clearTextButton.Size = new Size(213, 34);
            clearTextButton.TabIndex = 95;
            clearTextButton.Text = "Clear Text";
            clearTextButton.UseVisualStyleBackColor = false;
            clearTextButton.Click += clearTextButton_Click;
            // 
            // searchTextBox
            // 
            searchTextBox.BorderStyle = BorderStyle.FixedSingle;
            searchTextBox.Location = new Point(274, 589);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(1008, 28);
            searchTextBox.TabIndex = 94;
            searchTextBox.TextChanged += searchTextBox_TextChanged;
            // 
            // searchFileFolderLabel
            // 
            searchFileFolderLabel.AutoSize = true;
            searchFileFolderLabel.Location = new Point(5, 589);
            searchFileFolderLabel.Name = "searchFileFolderLabel";
            searchFileFolderLabel.Size = new Size(194, 21);
            searchFileFolderLabel.TabIndex = 93;
            searchFileFolderLabel.Text = "Search For File/Folder:";
            // 
            // fileListLabel
            // 
            fileListLabel.AutoSize = true;
            fileListLabel.BackColor = Color.Transparent;
            fileListLabel.ForeColor = Color.White;
            fileListLabel.Location = new Point(698, 266);
            fileListLabel.Name = "fileListLabel";
            fileListLabel.Size = new Size(144, 21);
            fileListLabel.TabIndex = 92;
            fileListLabel.Text = "File List Options:";
            // 
            // onFinishLabel
            // 
            onFinishLabel.AutoSize = true;
            onFinishLabel.BackColor = Color.Transparent;
            onFinishLabel.ForeColor = Color.White;
            onFinishLabel.Location = new Point(547, 197);
            onFinishLabel.Name = "onFinishLabel";
            onFinishLabel.Size = new Size(92, 21);
            onFinishLabel.TabIndex = 91;
            onFinishLabel.Text = "On Finish:";
            // 
            // cmdLabel
            // 
            cmdLabel.AutoSize = true;
            cmdLabel.BackColor = Color.Transparent;
            cmdLabel.ForeColor = Color.White;
            cmdLabel.Location = new Point(12, 197);
            cmdLabel.Name = "cmdLabel";
            cmdLabel.Size = new Size(66, 21);
            cmdLabel.TabIndex = 90;
            cmdLabel.Text = "C/M/D:";
            // 
            // onFinishComboBox
            // 
            onFinishComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            onFinishComboBox.FormattingEnabled = true;
            onFinishComboBox.Items.AddRange(new object[] { "Close Application", "Keep Application Open", "Log Off User", "Restart CPU", "Sleep", "Shut Down CPU" });
            onFinishComboBox.Location = new Point(668, 194);
            onFinishComboBox.Name = "onFinishComboBox";
            onFinishComboBox.Size = new Size(398, 29);
            onFinishComboBox.TabIndex = 89;
            // 
            // skipButton
            // 
            skipButton.BackColor = Color.Black;
            skipButton.Enabled = false;
            skipButton.ForeColor = Color.White;
            skipButton.Location = new Point(447, 263);
            skipButton.Name = "skipButton";
            skipButton.Size = new Size(209, 36);
            skipButton.TabIndex = 87;
            skipButton.Text = "Skip Current File";
            skipButton.UseVisualStyleBackColor = false;
            skipButton.Click += skipButton_Click;
            // 
            // fileIconPicBox
            // 
            fileIconPicBox.BackColor = Color.Transparent;
            fileIconPicBox.Image = Properties.Resources.icons8_file_40;
            fileIconPicBox.Location = new Point(1332, 189);
            fileIconPicBox.Name = "fileIconPicBox";
            fileIconPicBox.Size = new Size(40, 42);
            fileIconPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            fileIconPicBox.TabIndex = 86;
            fileIconPicBox.TabStop = false;
            // 
            // speedLabel
            // 
            speedLabel.AutoSize = true;
            speedLabel.BackColor = Color.Transparent;
            speedLabel.ForeColor = Color.White;
            speedLabel.Location = new Point(466, 353);
            speedLabel.Name = "speedLabel";
            speedLabel.Size = new Size(153, 21);
            speedLabel.TabIndex = 85;
            speedLabel.Text = "Speed: 0 Mb/Sec.";
            speedLabel.MouseDown += speedLabel_MouseDown;
            // 
            // fileProcessedLabel
            // 
            fileProcessedLabel.AutoSize = true;
            fileProcessedLabel.BackColor = Color.Transparent;
            fileProcessedLabel.ForeColor = Color.White;
            fileProcessedLabel.Location = new Point(466, 313);
            fileProcessedLabel.Name = "fileProcessedLabel";
            fileProcessedLabel.Size = new Size(279, 21);
            fileProcessedLabel.TabIndex = 84;
            fileProcessedLabel.Text = "File Processed: 0 Bytes /  0 Bytes";
            fileProcessedLabel.MouseDown += fileProcessedLabel_MouseDown;
            // 
            // copyMoveDeleteComboBox
            // 
            copyMoveDeleteComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            copyMoveDeleteComboBox.FormattingEnabled = true;
            copyMoveDeleteComboBox.Items.AddRange(new object[] { "Copy To Directory", "Move To Directory", "Delete Directory" });
            copyMoveDeleteComboBox.Location = new Point(94, 194);
            copyMoveDeleteComboBox.Name = "copyMoveDeleteComboBox";
            copyMoveDeleteComboBox.Size = new Size(417, 29);
            copyMoveDeleteComboBox.TabIndex = 83;
            // 
            // totalCopiedProgressLabel
            // 
            totalCopiedProgressLabel.AutoSize = true;
            totalCopiedProgressLabel.BackColor = Color.Transparent;
            totalCopiedProgressLabel.ForeColor = Color.White;
            totalCopiedProgressLabel.Location = new Point(1058, 313);
            totalCopiedProgressLabel.Name = "totalCopiedProgressLabel";
            totalCopiedProgressLabel.Size = new Size(255, 21);
            totalCopiedProgressLabel.TabIndex = 82;
            totalCopiedProgressLabel.Text = "Total C/M/D: 0 Bytes /  0 Bytes";
            totalCopiedProgressLabel.MouseDown += totalCopiedProgressLabel_MouseDown;
            // 
            // fileCountOnLabel
            // 
            fileCountOnLabel.AutoSize = true;
            fileCountOnLabel.BackColor = Color.Transparent;
            fileCountOnLabel.ForeColor = Color.White;
            fileCountOnLabel.Location = new Point(12, 313);
            fileCountOnLabel.Name = "fileCountOnLabel";
            fileCountOnLabel.Size = new Size(181, 21);
            fileCountOnLabel.TabIndex = 81;
            fileCountOnLabel.Text = "File Count: 0 Out of 0";
            fileCountOnLabel.MouseDown += fileCountOnLabel_MouseDown;
            // 
            // timeRemainingLabel
            // 
            timeRemainingLabel.AutoSize = true;
            timeRemainingLabel.BackColor = Color.Transparent;
            timeRemainingLabel.ForeColor = Color.White;
            timeRemainingLabel.Location = new Point(1059, 353);
            timeRemainingLabel.Name = "timeRemainingLabel";
            timeRemainingLabel.Size = new Size(219, 21);
            timeRemainingLabel.TabIndex = 80;
            timeRemainingLabel.Text = "Time Remaining: 00:00:00";
            timeRemainingLabel.MouseDown += timeRemainingLabel_MouseDown;
            // 
            // elapsedTimeLabel
            // 
            elapsedTimeLabel.AutoSize = true;
            elapsedTimeLabel.BackColor = Color.Transparent;
            elapsedTimeLabel.ForeColor = Color.White;
            elapsedTimeLabel.Location = new Point(12, 352);
            elapsedTimeLabel.Name = "elapsedTimeLabel";
            elapsedTimeLabel.Size = new Size(199, 21);
            elapsedTimeLabel.TabIndex = 79;
            elapsedTimeLabel.Text = "Elapsed Time: 00:00:00";
            elapsedTimeLabel.MouseDown += elapsedTimeLabel_MouseDown;
            // 
            // pauseResumeButton
            // 
            pauseResumeButton.BackColor = Color.Black;
            pauseResumeButton.ForeColor = Color.White;
            pauseResumeButton.Location = new Point(157, 263);
            pauseResumeButton.Name = "pauseResumeButton";
            pauseResumeButton.Size = new Size(112, 36);
            pauseResumeButton.TabIndex = 78;
            pauseResumeButton.Text = "Pause";
            pauseResumeButton.UseVisualStyleBackColor = false;
            pauseResumeButton.Click += pauseResumeButton_Click;
            // 
            // overallProgressLabel
            // 
            overallProgressLabel.AutoSize = true;
            overallProgressLabel.BackColor = Color.Transparent;
            overallProgressLabel.ForeColor = Color.White;
            overallProgressLabel.Location = new Point(5, 506);
            overallProgressLabel.Name = "overallProgressLabel";
            overallProgressLabel.Size = new Size(193, 21);
            overallProgressLabel.TabIndex = 77;
            overallProgressLabel.Text = "Total Overall Progress:";
            // 
            // fileProgressLabel
            // 
            fileProgressLabel.AutoSize = true;
            fileProgressLabel.BackColor = Color.Transparent;
            fileProgressLabel.ForeColor = Color.White;
            fileProgressLabel.Location = new Point(5, 437);
            fileProgressLabel.Name = "fileProgressLabel";
            fileProgressLabel.Size = new Size(165, 21);
            fileProgressLabel.TabIndex = 76;
            fileProgressLabel.Text = "File Total Progress:";
            // 
            // fileTotalProgressLabel
            // 
            fileTotalProgressLabel.AutoSize = true;
            fileTotalProgressLabel.BackColor = Color.Transparent;
            fileTotalProgressLabel.ForeColor = Color.White;
            fileTotalProgressLabel.Location = new Point(1385, 474);
            fileTotalProgressLabel.Name = "fileTotalProgressLabel";
            fileTotalProgressLabel.Size = new Size(36, 21);
            fileTotalProgressLabel.TabIndex = 75;
            fileTotalProgressLabel.Text = "0%";
            // 
            // totalProgressLabel
            // 
            totalProgressLabel.AutoSize = true;
            totalProgressLabel.BackColor = Color.Transparent;
            totalProgressLabel.ForeColor = Color.White;
            totalProgressLabel.Location = new Point(1385, 543);
            totalProgressLabel.Name = "totalProgressLabel";
            totalProgressLabel.Size = new Size(36, 21);
            totalProgressLabel.TabIndex = 74;
            totalProgressLabel.Text = "0%";
            // 
            // fileProgressBar
            // 
            fileProgressBar.Location = new Point(5, 464);
            fileProgressBar.Name = "fileProgressBar";
            fileProgressBar.Size = new Size(1374, 34);
            fileProgressBar.TabIndex = 73;
            // 
            // totalProgressBar
            // 
            totalProgressBar.Location = new Point(5, 533);
            totalProgressBar.Name = "totalProgressBar";
            totalProgressBar.Size = new Size(1374, 34);
            totalProgressBar.TabIndex = 72;
            // 
            // fileDirDataGridView
            // 
            fileDirDataGridView.AllowUserToAddRows = false;
            fileDirDataGridView.AllowUserToDeleteRows = false;
            fileDirDataGridView.AllowUserToOrderColumns = true;
            fileDirDataGridView.AllowUserToResizeColumns = false;
            fileDirDataGridView.AllowUserToResizeRows = false;
            fileDirDataGridView.BackgroundColor = Color.DarkGray;
            fileDirDataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            fileDirDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            fileDirDataGridView.Columns.AddRange(new DataGridViewColumn[] { statusIcon, statusColumn, filePathColumn, fileFolderNameColumn, fileSize });
            fileDirDataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            fileDirDataGridView.Location = new Point(4, 670);
            fileDirDataGridView.MultiSelect = false;
            fileDirDataGridView.Name = "fileDirDataGridView";
            fileDirDataGridView.ReadOnly = true;
            fileDirDataGridView.RowHeadersVisible = false;
            fileDirDataGridView.RowHeadersWidth = 62;
            fileDirDataGridView.ScrollBars = ScrollBars.Vertical;
            fileDirDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            fileDirDataGridView.Size = new Size(1508, 292);
            fileDirDataGridView.TabIndex = 71;
            // 
            // statusIcon
            // 
            statusIcon.HeaderText = "Status Icon";
            statusIcon.MinimumWidth = 8;
            statusIcon.Name = "statusIcon";
            statusIcon.ReadOnly = true;
            statusIcon.Width = 225;
            // 
            // statusColumn
            // 
            statusColumn.HeaderText = "Status";
            statusColumn.MinimumWidth = 8;
            statusColumn.Name = "statusColumn";
            statusColumn.ReadOnly = true;
            statusColumn.Resizable = DataGridViewTriState.True;
            statusColumn.Width = 300;
            // 
            // filePathColumn
            // 
            filePathColumn.HeaderText = "File/Dir. Path";
            filePathColumn.MinimumWidth = 8;
            filePathColumn.Name = "filePathColumn";
            filePathColumn.ReadOnly = true;
            filePathColumn.Width = 400;
            // 
            // fileFolderNameColumn
            // 
            fileFolderNameColumn.HeaderText = "File/Dir. Name";
            fileFolderNameColumn.MinimumWidth = 8;
            fileFolderNameColumn.Name = "fileFolderNameColumn";
            fileFolderNameColumn.ReadOnly = true;
            fileFolderNameColumn.Width = 400;
            // 
            // fileSize
            // 
            fileSize.HeaderText = "File/Dir. Size";
            fileSize.MinimumWidth = 8;
            fileSize.Name = "fileSize";
            fileSize.ReadOnly = true;
            fileSize.Width = 225;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.Black;
            cancelButton.Enabled = false;
            cancelButton.ForeColor = Color.White;
            cancelButton.Location = new Point(302, 263);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(112, 36);
            cancelButton.TabIndex = 70;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // startButton
            // 
            startButton.BackColor = Color.Black;
            startButton.ForeColor = Color.White;
            startButton.Location = new Point(12, 263);
            startButton.Name = "startButton";
            startButton.Size = new Size(112, 36);
            startButton.TabIndex = 69;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += startButton_Click;
            // 
            // targetDirPicBox
            // 
            targetDirPicBox.BackColor = Color.Transparent;
            targetDirPicBox.Image = Properties.Resources.icons8_folder_40;
            targetDirPicBox.Location = new Point(12, 112);
            targetDirPicBox.Name = "targetDirPicBox";
            targetDirPicBox.Size = new Size(40, 42);
            targetDirPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            targetDirPicBox.TabIndex = 68;
            targetDirPicBox.TabStop = false;
            targetDirPicBox.Click += targetDirPicBox_Click;
            // 
            // fromDirPicBox
            // 
            fromDirPicBox.BackColor = Color.Transparent;
            fromDirPicBox.Image = Properties.Resources.icons8_folder_40;
            fromDirPicBox.Location = new Point(12, 57);
            fromDirPicBox.Name = "fromDirPicBox";
            fromDirPicBox.Size = new Size(40, 40);
            fromDirPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            fromDirPicBox.TabIndex = 67;
            fromDirPicBox.TabStop = false;
            fromDirPicBox.Click += fromDirPicBox_Click;
            // 
            // fileNamePicBox
            // 
            fileNamePicBox.BackColor = Color.Transparent;
            fileNamePicBox.Image = Properties.Resources.icons8_file_40;
            fileNamePicBox.Location = new Point(12, 2);
            fileNamePicBox.Name = "fileNamePicBox";
            fileNamePicBox.Size = new Size(37, 42);
            fileNamePicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            fileNamePicBox.TabIndex = 66;
            fileNamePicBox.TabStop = false;
            // 
            // targetDirLabel
            // 
            targetDirLabel.BackColor = Color.Transparent;
            targetDirLabel.ForeColor = Color.White;
            targetDirLabel.Location = new Point(141, 121);
            targetDirLabel.Name = "targetDirLabel";
            targetDirLabel.Size = new Size(1364, 52);
            targetDirLabel.TabIndex = 65;
            targetDirLabel.Text = "Select Directory";
            targetDirLabel.MouseDown += targetDirLabel_MouseDown;
            // 
            // fromFilesDirLabel
            // 
            fromFilesDirLabel.BackColor = Color.Transparent;
            fromFilesDirLabel.ForeColor = Color.White;
            fromFilesDirLabel.Location = new Point(141, 65);
            fromFilesDirLabel.Name = "fromFilesDirLabel";
            fromFilesDirLabel.Size = new Size(1364, 56);
            fromFilesDirLabel.TabIndex = 64;
            fromFilesDirLabel.Text = "Select Files/Directory";
            fromFilesDirLabel.MouseDown += fromFilesDirLabel_MouseDown;
            // 
            // filePathLabel
            // 
            filePathLabel.BackColor = Color.Transparent;
            filePathLabel.ForeColor = Color.White;
            filePathLabel.Location = new Point(141, 9);
            filePathLabel.Name = "filePathLabel";
            filePathLabel.Size = new Size(1364, 56);
            filePathLabel.TabIndex = 63;
            filePathLabel.Text = "Nothing";
            filePathLabel.MouseDown += filePathLabel_MouseDown;
            // 
            // targetLabel
            // 
            targetLabel.AutoSize = true;
            targetLabel.BackColor = Color.Transparent;
            targetLabel.ForeColor = Color.White;
            targetLabel.Location = new Point(58, 121);
            targetLabel.Name = "targetLabel";
            targetLabel.Size = new Size(66, 21);
            targetLabel.TabIndex = 62;
            targetLabel.Text = "Target:";
            targetLabel.MouseDown += targetLabel_MouseDown;
            // 
            // fromLabel
            // 
            fromLabel.AutoSize = true;
            fromLabel.BackColor = Color.Transparent;
            fromLabel.ForeColor = Color.White;
            fromLabel.Location = new Point(59, 65);
            fromLabel.Name = "fromLabel";
            fromLabel.Size = new Size(56, 21);
            fromLabel.TabIndex = 61;
            fromLabel.Text = "From:";
            fromLabel.MouseDown += fromLabel_MouseDown;
            // 
            // fileNameLabel
            // 
            fileNameLabel.AutoSize = true;
            fileNameLabel.BackColor = Color.Transparent;
            fileNameLabel.ForeColor = Color.White;
            fileNameLabel.Location = new Point(59, 9);
            fileNameLabel.Name = "fileNameLabel";
            fileNameLabel.Size = new Size(44, 21);
            fileNameLabel.TabIndex = 60;
            fileNameLabel.Text = "File:";
            fileNameLabel.MouseDown += fileNameLabel_MouseDown;
            // 
            // cmdSettingsPage
            // 
            cmdSettingsPage.BackColor = Color.Black;
            cmdSettingsPage.BackgroundImageLayout = ImageLayout.Stretch;
            cmdSettingsPage.Controls.Add(exportDataGridView);
            cmdSettingsPage.Controls.Add(exportFileListLabel);
            cmdSettingsPage.Controls.Add(opacityLabel);
            cmdSettingsPage.Controls.Add(opacityTrackBar);
            cmdSettingsPage.Controls.Add(logFileCheckBox);
            cmdSettingsPage.Controls.Add(priorityLabel);
            cmdSettingsPage.Controls.Add(priorityTrackBar);
            cmdSettingsPage.Controls.Add(saveAutoCheckBox);
            cmdSettingsPage.Controls.Add(defaultSettingsButton);
            cmdSettingsPage.Controls.Add(recSettingsButton);
            cmdSettingsPage.Controls.Add(clearSettingsButton);
            cmdSettingsPage.Controls.Add(saveSettingsButton);
            cmdSettingsPage.Controls.Add(emailGroupBox);
            cmdSettingsPage.Controls.Add(updateGroupBox);
            cmdSettingsPage.Controls.Add(performanceGroupBox);
            cmdSettingsPage.Controls.Add(otherSettingsGroupBox);
            cmdSettingsPage.Controls.Add(fileDirSettingsGroupBox);
            cmdSettingsPage.Controls.Add(soundsGroupBox);
            cmdSettingsPage.Controls.Add(skinsLanguageGoupBox);
            cmdSettingsPage.Controls.Add(windowGroupBox);
            cmdSettingsPage.Location = new Point(4, 34);
            cmdSettingsPage.Name = "cmdSettingsPage";
            cmdSettingsPage.Padding = new Padding(3);
            cmdSettingsPage.Size = new Size(1517, 957);
            cmdSettingsPage.TabIndex = 3;
            cmdSettingsPage.Text = "- Settings";
            cmdSettingsPage.MouseDown += cmdSettingsPage_MouseDown;
            // 
            // exportDataGridView
            // 
            exportDataGridView.AllowUserToAddRows = false;
            exportDataGridView.AllowUserToDeleteRows = false;
            exportDataGridView.AllowUserToOrderColumns = true;
            exportDataGridView.AllowUserToResizeColumns = false;
            exportDataGridView.AllowUserToResizeRows = false;
            exportDataGridView.BackgroundColor = Color.DarkGray;
            exportDataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            exportDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            exportDataGridView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7 });
            exportDataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            exportDataGridView.Location = new Point(6, 727);
            exportDataGridView.MultiSelect = false;
            exportDataGridView.Name = "exportDataGridView";
            exportDataGridView.ReadOnly = true;
            exportDataGridView.RowHeadersVisible = false;
            exportDataGridView.RowHeadersWidth = 62;
            exportDataGridView.ScrollBars = ScrollBars.Vertical;
            exportDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            exportDataGridView.Size = new Size(1508, 228);
            exportDataGridView.TabIndex = 101;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "File/Dir. Path";
            dataGridViewTextBoxColumn5.MinimumWidth = 8;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            dataGridViewTextBoxColumn5.Width = 520;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "File/Dir. Name";
            dataGridViewTextBoxColumn6.MinimumWidth = 8;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            dataGridViewTextBoxColumn6.Width = 500;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "File/Dir. Size";
            dataGridViewTextBoxColumn7.MinimumWidth = 8;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            dataGridViewTextBoxColumn7.Width = 500;
            // 
            // exportFileListLabel
            // 
            exportFileListLabel.AutoSize = true;
            exportFileListLabel.Location = new Point(6, 703);
            exportFileListLabel.Name = "exportFileListLabel";
            exportFileListLabel.Size = new Size(133, 21);
            exportFileListLabel.TabIndex = 102;
            exportFileListLabel.Text = "Export File List:";
            // 
            // opacityLabel
            // 
            opacityLabel.AutoSize = true;
            opacityLabel.Location = new Point(657, 291);
            opacityLabel.Name = "opacityLabel";
            opacityLabel.Size = new Size(76, 21);
            opacityLabel.TabIndex = 100;
            opacityLabel.Text = "Opacity:";
            // 
            // opacityTrackBar
            // 
            opacityTrackBar.AutoSize = false;
            opacityTrackBar.Location = new Point(648, 349);
            opacityTrackBar.Maximum = 100;
            opacityTrackBar.Minimum = 60;
            opacityTrackBar.Name = "opacityTrackBar";
            opacityTrackBar.Size = new Size(211, 49);
            opacityTrackBar.TabIndex = 99;
            opacityTrackBar.Value = 100;
            opacityTrackBar.Scroll += opacityTrackBar_Scroll;
            // 
            // logFileCheckBox
            // 
            logFileCheckBox.AutoSize = true;
            logFileCheckBox.Checked = true;
            logFileCheckBox.CheckState = CheckState.Checked;
            logFileCheckBox.Location = new Point(657, 415);
            logFileCheckBox.Name = "logFileCheckBox";
            logFileCheckBox.Size = new Size(120, 25);
            logFileCheckBox.TabIndex = 98;
            logFileCheckBox.Text = "Log to File";
            logFileCheckBox.UseVisualStyleBackColor = true;
            logFileCheckBox.CheckedChanged += logFileCheckBox_CheckedChanged;
            // 
            // priorityLabel
            // 
            priorityLabel.AutoSize = true;
            priorityLabel.Location = new Point(657, 147);
            priorityLabel.Name = "priorityLabel";
            priorityLabel.Size = new Size(144, 21);
            priorityLabel.TabIndex = 96;
            priorityLabel.Text = "Program Priority:";
            // 
            // priorityTrackBar
            // 
            priorityTrackBar.AutoSize = false;
            priorityTrackBar.Location = new Point(648, 205);
            priorityTrackBar.Maximum = 4;
            priorityTrackBar.Name = "priorityTrackBar";
            priorityTrackBar.Size = new Size(211, 49);
            priorityTrackBar.TabIndex = 61;
            priorityTrackBar.Value = 2;
            priorityTrackBar.Scroll += priorityTrackBar_Scroll;
            // 
            // saveAutoCheckBox
            // 
            saveAutoCheckBox.AutoSize = true;
            saveAutoCheckBox.BackColor = Color.Transparent;
            saveAutoCheckBox.Checked = true;
            saveAutoCheckBox.CheckState = CheckState.Checked;
            saveAutoCheckBox.Location = new Point(657, 468);
            saveAutoCheckBox.Name = "saveAutoCheckBox";
            saveAutoCheckBox.Size = new Size(180, 25);
            saveAutoCheckBox.TabIndex = 95;
            saveAutoCheckBox.Text = "Autosave Settings";
            saveAutoCheckBox.UseVisualStyleBackColor = false;
            saveAutoCheckBox.CheckedChanged += saveAutoCheckBox_CheckedChanged;
            // 
            // defaultSettingsButton
            // 
            defaultSettingsButton.BackColor = Color.Black;
            defaultSettingsButton.ForeColor = Color.White;
            defaultSettingsButton.Location = new Point(657, 39);
            defaultSettingsButton.Name = "defaultSettingsButton";
            defaultSettingsButton.Size = new Size(202, 34);
            defaultSettingsButton.TabIndex = 94;
            defaultSettingsButton.Text = "Restore Defaults";
            defaultSettingsButton.UseVisualStyleBackColor = false;
            defaultSettingsButton.Click += defaultSettingsButton_Click;
            // 
            // recSettingsButton
            // 
            recSettingsButton.BackColor = Color.Black;
            recSettingsButton.ForeColor = Color.White;
            recSettingsButton.Location = new Point(657, 101);
            recSettingsButton.Name = "recSettingsButton";
            recSettingsButton.Size = new Size(202, 34);
            recSettingsButton.TabIndex = 93;
            recSettingsButton.Text = "Recommended";
            recSettingsButton.UseVisualStyleBackColor = false;
            recSettingsButton.Click += recSettingsButton_Click;
            // 
            // clearSettingsButton
            // 
            clearSettingsButton.BackColor = Color.Black;
            clearSettingsButton.ForeColor = Color.White;
            clearSettingsButton.Location = new Point(657, 521);
            clearSettingsButton.Name = "clearSettingsButton";
            clearSettingsButton.Size = new Size(202, 34);
            clearSettingsButton.TabIndex = 92;
            clearSettingsButton.Text = "Clear Settings";
            clearSettingsButton.UseVisualStyleBackColor = false;
            clearSettingsButton.Click += clearSettingsButton_Click;
            // 
            // saveSettingsButton
            // 
            saveSettingsButton.BackColor = Color.Black;
            saveSettingsButton.ForeColor = Color.White;
            saveSettingsButton.Location = new Point(657, 583);
            saveSettingsButton.Name = "saveSettingsButton";
            saveSettingsButton.Size = new Size(202, 34);
            saveSettingsButton.TabIndex = 91;
            saveSettingsButton.Text = "Save Settings";
            saveSettingsButton.UseVisualStyleBackColor = false;
            saveSettingsButton.Click += saveSettingsButton_Click;
            // 
            // emailGroupBox
            // 
            emailGroupBox.Controls.Add(setUpEmailButton);
            emailGroupBox.Controls.Add(emailPathsCheckBox);
            emailGroupBox.Controls.Add(emailNamesCheckBox);
            emailGroupBox.Controls.Add(whenEmailingLabel);
            emailGroupBox.ForeColor = Color.White;
            emailGroupBox.Location = new Point(875, 350);
            emailGroupBox.Name = "emailGroupBox";
            emailGroupBox.Size = new Size(636, 124);
            emailGroupBox.TabIndex = 78;
            emailGroupBox.TabStop = false;
            emailGroupBox.Text = "Email Settings (Pro):";
            // 
            // setUpEmailButton
            // 
            setUpEmailButton.BackColor = Color.Black;
            setUpEmailButton.ForeColor = Color.White;
            setUpEmailButton.Location = new Point(14, 71);
            setUpEmailButton.Name = "setUpEmailButton";
            setUpEmailButton.Size = new Size(346, 34);
            setUpEmailButton.TabIndex = 90;
            setUpEmailButton.Text = "Set Up Email";
            setUpEmailButton.UseVisualStyleBackColor = false;
            setUpEmailButton.Click += setUpEmailButton_Click;
            // 
            // emailPathsCheckBox
            // 
            emailPathsCheckBox.AutoSize = true;
            emailPathsCheckBox.Checked = true;
            emailPathsCheckBox.CheckState = CheckState.Checked;
            emailPathsCheckBox.Location = new Point(366, 75);
            emailPathsCheckBox.Name = "emailPathsCheckBox";
            emailPathsCheckBox.Size = new Size(153, 25);
            emailPathsCheckBox.TabIndex = 80;
            emailPathsCheckBox.Text = "Use Full Paths";
            emailPathsCheckBox.UseVisualStyleBackColor = true;
            emailPathsCheckBox.CheckedChanged += emailPathsCheckBox_CheckedChanged;
            // 
            // emailNamesCheckBox
            // 
            emailNamesCheckBox.AutoSize = true;
            emailNamesCheckBox.Location = new Point(366, 32);
            emailNamesCheckBox.Name = "emailNamesCheckBox";
            emailNamesCheckBox.Size = new Size(200, 25);
            emailNamesCheckBox.TabIndex = 79;
            emailNamesCheckBox.Text = "Only File/Dir. Names";
            emailNamesCheckBox.UseVisualStyleBackColor = true;
            emailNamesCheckBox.CheckedChanged += emailFileDirNames_CheckedChanged;
            // 
            // whenEmailingLabel
            // 
            whenEmailingLabel.AutoSize = true;
            whenEmailingLabel.Location = new Point(14, 32);
            whenEmailingLabel.Name = "whenEmailingLabel";
            whenEmailingLabel.Size = new Size(258, 21);
            whenEmailingLabel.TabIndex = 78;
            whenEmailingLabel.Text = "When Emailing File/Folder List:";
            // 
            // updateGroupBox
            // 
            updateGroupBox.Controls.Add(updateManuallyCheckBox);
            updateGroupBox.Controls.Add(checkForUpdatesButton);
            updateGroupBox.Controls.Add(updateBetaCheckBox);
            updateGroupBox.Controls.Add(updateAutoCheckBox);
            updateGroupBox.ForeColor = Color.White;
            updateGroupBox.Location = new Point(6, 496);
            updateGroupBox.Name = "updateGroupBox";
            updateGroupBox.Size = new Size(636, 203);
            updateGroupBox.TabIndex = 77;
            updateGroupBox.TabStop = false;
            updateGroupBox.Text = "Update Settings:";
            // 
            // updateManuallyCheckBox
            // 
            updateManuallyCheckBox.AutoSize = true;
            updateManuallyCheckBox.Checked = true;
            updateManuallyCheckBox.CheckState = CheckState.Checked;
            updateManuallyCheckBox.Location = new Point(415, 27);
            updateManuallyCheckBox.Name = "updateManuallyCheckBox";
            updateManuallyCheckBox.Size = new Size(171, 25);
            updateManuallyCheckBox.TabIndex = 89;
            updateManuallyCheckBox.Text = "Update Manually";
            updateManuallyCheckBox.UseVisualStyleBackColor = true;
            updateManuallyCheckBox.CheckedChanged += updateManuallyCheckBox_CheckedChanged;
            // 
            // checkForUpdatesButton
            // 
            checkForUpdatesButton.BackColor = Color.Black;
            checkForUpdatesButton.ForeColor = Color.White;
            checkForUpdatesButton.Location = new Point(415, 85);
            checkForUpdatesButton.Name = "checkForUpdatesButton";
            checkForUpdatesButton.Size = new Size(209, 34);
            checkForUpdatesButton.TabIndex = 88;
            checkForUpdatesButton.Text = "Check for Updates";
            checkForUpdatesButton.UseVisualStyleBackColor = false;
            // 
            // updateBetaCheckBox
            // 
            updateBetaCheckBox.AutoSize = true;
            updateBetaCheckBox.Location = new Point(12, 89);
            updateBetaCheckBox.Name = "updateBetaCheckBox";
            updateBetaCheckBox.Size = new Size(200, 25);
            updateBetaCheckBox.TabIndex = 81;
            updateBetaCheckBox.Text = "Check for Beta (Pro)";
            updateBetaCheckBox.UseVisualStyleBackColor = true;
            updateBetaCheckBox.CheckedChanged += updateBetaCheckBox_CheckedChanged;
            // 
            // updateAutoCheckBox
            // 
            updateAutoCheckBox.AutoSize = true;
            updateAutoCheckBox.Location = new Point(12, 31);
            updateAutoCheckBox.Name = "updateAutoCheckBox";
            updateAutoCheckBox.Size = new Size(248, 25);
            updateAutoCheckBox.TabIndex = 77;
            updateAutoCheckBox.Text = "Update Automatically (Pro)";
            updateAutoCheckBox.UseVisualStyleBackColor = true;
            updateAutoCheckBox.CheckedChanged += updateAutoCheckBox_CheckedChanged;
            // 
            // performanceGroupBox
            // 
            performanceGroupBox.Controls.Add(kbLabel);
            performanceGroupBox.Controls.Add(multithreadCheckBox);
            performanceGroupBox.Controls.Add(cmOnlyIfLabel);
            performanceGroupBox.Controls.Add(overMBCheckBox);
            performanceGroupBox.Controls.Add(underMBCheckBox);
            performanceGroupBox.Controls.Add(setMBGBOLabel);
            performanceGroupBox.Controls.Add(setMBGBULabel);
            performanceGroupBox.Controls.Add(setMBGBUnderNumUD);
            performanceGroupBox.Controls.Add(setMBUmderLabel);
            performanceGroupBox.Controls.Add(setMBGBOverNumUD);
            performanceGroupBox.Controls.Add(setMBGBOverLabel);
            performanceGroupBox.Controls.Add(bufferNumUpDown);
            performanceGroupBox.Controls.Add(setBufferLabel);
            performanceGroupBox.ForeColor = Color.White;
            performanceGroupBox.Location = new Point(875, 18);
            performanceGroupBox.Name = "performanceGroupBox";
            performanceGroupBox.Size = new Size(636, 150);
            performanceGroupBox.TabIndex = 76;
            performanceGroupBox.TabStop = false;
            performanceGroupBox.Text = "Performance Settings:";
            // 
            // kbLabel
            // 
            kbLabel.AutoSize = true;
            kbLabel.Location = new Point(285, 31);
            kbLabel.Name = "kbLabel";
            kbLabel.Size = new Size(34, 21);
            kbLabel.TabIndex = 80;
            kbLabel.Text = "KB";
            // 
            // multithreadCheckBox
            // 
            multithreadCheckBox.AutoSize = true;
            multithreadCheckBox.Checked = true;
            multithreadCheckBox.CheckState = CheckState.Checked;
            multithreadCheckBox.Location = new Point(343, 23);
            multithreadCheckBox.Name = "multithreadCheckBox";
            multithreadCheckBox.Size = new Size(237, 25);
            multithreadCheckBox.TabIndex = 79;
            multithreadCheckBox.Text = "Copy With Multithreading";
            multithreadCheckBox.UseVisualStyleBackColor = true;
            multithreadCheckBox.CheckedChanged += multithreadCheckBox_CheckedChanged;
            // 
            // cmOnlyIfLabel
            // 
            cmOnlyIfLabel.AutoSize = true;
            cmOnlyIfLabel.Location = new Point(26, 89);
            cmOnlyIfLabel.Name = "cmOnlyIfLabel";
            cmOnlyIfLabel.Size = new Size(104, 21);
            cmOnlyIfLabel.TabIndex = 78;
            cmOnlyIfLabel.Text = "C/M Only If:";
            // 
            // overMBCheckBox
            // 
            overMBCheckBox.AutoSize = true;
            overMBCheckBox.Location = new Point(172, 107);
            overMBCheckBox.Name = "overMBCheckBox";
            overMBCheckBox.Size = new Size(107, 25);
            overMBCheckBox.TabIndex = 77;
            overMBCheckBox.Text = "Over MB";
            overMBCheckBox.UseVisualStyleBackColor = true;
            overMBCheckBox.CheckedChanged += overMBCheckBox_CheckedChanged;
            // 
            // underMBCheckBox
            // 
            underMBCheckBox.AutoSize = true;
            underMBCheckBox.Location = new Point(172, 67);
            underMBCheckBox.Name = "underMBCheckBox";
            underMBCheckBox.Size = new Size(117, 25);
            underMBCheckBox.TabIndex = 76;
            underMBCheckBox.Text = "Under MB";
            underMBCheckBox.UseVisualStyleBackColor = true;
            underMBCheckBox.CheckedChanged += underMBCheckBox_CheckedChanged;
            // 
            // setMBGBOLabel
            // 
            setMBGBOLabel.AutoSize = true;
            setMBGBOLabel.Location = new Point(567, 108);
            setMBGBOLabel.Name = "setMBGBOLabel";
            setMBGBOLabel.Size = new Size(37, 21);
            setMBGBOLabel.TabIndex = 75;
            setMBGBOLabel.Text = "MB";
            // 
            // setMBGBULabel
            // 
            setMBGBULabel.AutoSize = true;
            setMBGBULabel.Location = new Point(567, 71);
            setMBGBULabel.Name = "setMBGBULabel";
            setMBGBULabel.Size = new Size(37, 21);
            setMBGBULabel.TabIndex = 74;
            setMBGBULabel.Text = "MB";
            // 
            // setMBGBUnderNumUD
            // 
            setMBGBUnderNumUD.Location = new Point(448, 66);
            setMBGBUnderNumUD.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            setMBGBUnderNumUD.Name = "setMBGBUnderNumUD";
            setMBGBUnderNumUD.ReadOnly = true;
            setMBGBUnderNumUD.Size = new Size(113, 28);
            setMBGBUnderNumUD.TabIndex = 73;
            setMBGBUnderNumUD.TextAlign = HorizontalAlignment.Center;
            setMBGBUnderNumUD.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // setMBUmderLabel
            // 
            setMBUmderLabel.AutoSize = true;
            setMBUmderLabel.Location = new Point(305, 66);
            setMBUmderLabel.Name = "setMBUmderLabel";
            setMBUmderLabel.Size = new Size(116, 21);
            setMBUmderLabel.TabIndex = 72;
            setMBUmderLabel.Text = "C/M If Under:";
            // 
            // setMBGBOverNumUD
            // 
            setMBGBOverNumUD.Location = new Point(448, 107);
            setMBGBOverNumUD.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            setMBGBOverNumUD.Name = "setMBGBOverNumUD";
            setMBGBOverNumUD.ReadOnly = true;
            setMBGBOverNumUD.Size = new Size(113, 28);
            setMBGBOverNumUD.TabIndex = 71;
            setMBGBOverNumUD.TextAlign = HorizontalAlignment.Center;
            setMBGBOverNumUD.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // setMBGBOverLabel
            // 
            setMBGBOverLabel.AutoSize = true;
            setMBGBOverLabel.Location = new Point(315, 107);
            setMBGBOverLabel.Name = "setMBGBOverLabel";
            setMBGBOverLabel.Size = new Size(106, 21);
            setMBGBOverLabel.TabIndex = 70;
            setMBGBOverLabel.Text = "C/M If Over:";
            // 
            // bufferNumUpDown
            // 
            bufferNumUpDown.Location = new Point(171, 27);
            bufferNumUpDown.Maximum = new decimal(new int[] { 1024, 0, 0, 0 });
            bufferNumUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            bufferNumUpDown.Name = "bufferNumUpDown";
            bufferNumUpDown.ReadOnly = true;
            bufferNumUpDown.Size = new Size(108, 28);
            bufferNumUpDown.TabIndex = 69;
            bufferNumUpDown.TextAlign = HorizontalAlignment.Center;
            bufferNumUpDown.Value = new decimal(new int[] { 1024, 0, 0, 0 });
            // 
            // setBufferLabel
            // 
            setBufferLabel.AutoSize = true;
            setBufferLabel.Location = new Point(28, 27);
            setBufferLabel.Name = "setBufferLabel";
            setBufferLabel.Size = new Size(102, 21);
            setBufferLabel.TabIndex = 68;
            setBufferLabel.Text = "Buffer Size:";
            // 
            // otherSettingsGroupBox
            // 
            otherSettingsGroupBox.Controls.Add(seLabel);
            otherSettingsGroupBox.Controls.Add(sLabel);
            otherSettingsGroupBox.Controls.Add(swLabel);
            otherSettingsGroupBox.Controls.Add(eLabel);
            otherSettingsGroupBox.Controls.Add(neLabel);
            otherSettingsGroupBox.Controls.Add(nLabel);
            otherSettingsGroupBox.Controls.Add(nwLabel);
            otherSettingsGroupBox.Controls.Add(wLabel);
            otherSettingsGroupBox.Controls.Add(label1);
            otherSettingsGroupBox.Controls.Add(startWithWindowsCheckBox);
            otherSettingsGroupBox.Controls.Add(serialMaskedTextBox);
            otherSettingsGroupBox.Controls.Add(registerButton);
            otherSettingsGroupBox.Controls.Add(serialNumberLabel);
            otherSettingsGroupBox.Controls.Add(errorOccursLabel);
            otherSettingsGroupBox.Controls.Add(restartCheckBox);
            otherSettingsGroupBox.Controls.Add(closeProgramCheckBox);
            otherSettingsGroupBox.ForeColor = Color.White;
            otherSettingsGroupBox.Location = new Point(875, 496);
            otherSettingsGroupBox.Name = "otherSettingsGroupBox";
            otherSettingsGroupBox.Size = new Size(636, 203);
            otherSettingsGroupBox.TabIndex = 75;
            otherSettingsGroupBox.TabStop = false;
            otherSettingsGroupBox.Text = "Other Settings:";
            // 
            // seLabel
            // 
            seLabel.AutoSize = true;
            seLabel.ForeColor = Color.White;
            seLabel.Location = new Point(338, 158);
            seLabel.Name = "seLabel";
            seLabel.Size = new Size(17, 21);
            seLabel.TabIndex = 100;
            seLabel.Text = "°";
            seLabel.Click += seLabel_Click;
            // 
            // sLabel
            // 
            sLabel.AutoSize = true;
            sLabel.ForeColor = Color.White;
            sLabel.Location = new Point(308, 168);
            sLabel.Name = "sLabel";
            sLabel.Size = new Size(20, 21);
            sLabel.TabIndex = 99;
            sLabel.Text = "\\/";
            sLabel.Click += sLabel_Click;
            // 
            // swLabel
            // 
            swLabel.AutoSize = true;
            swLabel.ForeColor = Color.White;
            swLabel.Location = new Point(281, 158);
            swLabel.Name = "swLabel";
            swLabel.Size = new Size(17, 21);
            swLabel.TabIndex = 98;
            swLabel.Text = "°";
            swLabel.Click += swLabel_Click;
            // 
            // eLabel
            // 
            eLabel.AutoSize = true;
            eLabel.ForeColor = Color.White;
            eLabel.Location = new Point(362, 131);
            eLabel.Name = "eLabel";
            eLabel.Size = new Size(21, 21);
            eLabel.TabIndex = 97;
            eLabel.Text = ">";
            eLabel.Click += eLabel_Click;
            // 
            // neLabel
            // 
            neLabel.AutoSize = true;
            neLabel.ForeColor = Color.White;
            neLabel.Location = new Point(338, 103);
            neLabel.Name = "neLabel";
            neLabel.Size = new Size(17, 21);
            neLabel.TabIndex = 96;
            neLabel.Text = "°";
            neLabel.Click += neLabel_Click;
            // 
            // nLabel
            // 
            nLabel.AutoSize = true;
            nLabel.ForeColor = Color.White;
            nLabel.Location = new Point(308, 84);
            nLabel.Name = "nLabel";
            nLabel.Size = new Size(20, 21);
            nLabel.TabIndex = 95;
            nLabel.Text = "/\\";
            nLabel.Click += nLabel_Click;
            // 
            // nwLabel
            // 
            nwLabel.AutoSize = true;
            nwLabel.ForeColor = Color.White;
            nwLabel.Location = new Point(281, 103);
            nwLabel.Name = "nwLabel";
            nwLabel.Size = new Size(17, 21);
            nwLabel.TabIndex = 94;
            nwLabel.Text = "°";
            nwLabel.Click += nwLabel_Click;
            // 
            // wLabel
            // 
            wLabel.AutoSize = true;
            wLabel.ForeColor = Color.White;
            wLabel.Location = new Point(261, 129);
            wLabel.Name = "wLabel";
            wLabel.Size = new Size(21, 21);
            wLabel.TabIndex = 93;
            wLabel.Text = "<";
            wLabel.Click += wLabel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(264, 31);
            label1.Name = "label1";
            label1.Size = new Size(120, 42);
            label1.TabIndex = 92;
            label1.Text = "App Location\r\n(Click Below):";
            // 
            // startWithWindowsCheckBox
            // 
            startWithWindowsCheckBox.AutoSize = true;
            startWithWindowsCheckBox.Location = new Point(14, 146);
            startWithWindowsCheckBox.Name = "startWithWindowsCheckBox";
            startWithWindowsCheckBox.Size = new Size(193, 25);
            startWithWindowsCheckBox.TabIndex = 91;
            startWithWindowsCheckBox.Text = "Start With Windows";
            startWithWindowsCheckBox.UseVisualStyleBackColor = true;
            startWithWindowsCheckBox.CheckedChanged += startWithWindowsCheckBox_CheckedChanged;
            // 
            // serialMaskedTextBox
            // 
            serialMaskedTextBox.Location = new Point(410, 58);
            serialMaskedTextBox.Mask = "AAAA-AAAA-AAAA-AAAA";
            serialMaskedTextBox.Name = "serialMaskedTextBox";
            serialMaskedTextBox.Size = new Size(215, 28);
            serialMaskedTextBox.TabIndex = 90;
            // 
            // registerButton
            // 
            registerButton.BackColor = Color.Black;
            registerButton.ForeColor = Color.White;
            registerButton.Location = new Point(410, 94);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(214, 34);
            registerButton.TabIndex = 89;
            registerButton.Text = "Register Serial #";
            registerButton.UseVisualStyleBackColor = false;
            registerButton.Click += registerButton_Click;
            // 
            // serialNumberLabel
            // 
            serialNumberLabel.AutoSize = true;
            serialNumberLabel.Location = new Point(410, 31);
            serialNumberLabel.Name = "serialNumberLabel";
            serialNumberLabel.Size = new Size(124, 21);
            serialNumberLabel.TabIndex = 79;
            serialNumberLabel.Text = "Enter Serial #:";
            // 
            // errorOccursLabel
            // 
            errorOccursLabel.AutoSize = true;
            errorOccursLabel.Location = new Point(14, 32);
            errorOccursLabel.Name = "errorOccursLabel";
            errorOccursLabel.Size = new Size(194, 21);
            errorOccursLabel.TabIndex = 78;
            errorOccursLabel.Text = "When an Error Occurs:";
            // 
            // restartCheckBox
            // 
            restartCheckBox.AutoSize = true;
            restartCheckBox.Checked = true;
            restartCheckBox.CheckState = CheckState.Checked;
            restartCheckBox.Location = new Point(14, 104);
            restartCheckBox.Name = "restartCheckBox";
            restartCheckBox.Size = new Size(162, 25);
            restartCheckBox.TabIndex = 77;
            restartCheckBox.Text = "RestartProgram";
            restartCheckBox.UseVisualStyleBackColor = true;
            restartCheckBox.CheckedChanged += restartCheckBox_CheckedChanged;
            // 
            // closeProgramCheckBox
            // 
            closeProgramCheckBox.AutoSize = true;
            closeProgramCheckBox.Location = new Point(17, 62);
            closeProgramCheckBox.Name = "closeProgramCheckBox";
            closeProgramCheckBox.Size = new Size(155, 25);
            closeProgramCheckBox.TabIndex = 76;
            closeProgramCheckBox.Text = "Close Program";
            closeProgramCheckBox.UseVisualStyleBackColor = true;
            closeProgramCheckBox.CheckedChanged += closeProgramCheckBox_CheckedChanged;
            // 
            // fileDirSettingsGroupBox
            // 
            fileDirSettingsGroupBox.Controls.Add(exportButton);
            fileDirSettingsGroupBox.Controls.Add(zipSettingsLabel);
            fileDirSettingsGroupBox.Controls.Add(zipTogetherCheckBox);
            fileDirSettingsGroupBox.Controls.Add(zipSeparateCheckBox);
            fileDirSettingsGroupBox.Controls.Add(exportListLabel);
            fileDirSettingsGroupBox.Controls.Add(fullPathsCheckBox);
            fileDirSettingsGroupBox.Controls.Add(onlyNamesCheckBox);
            fileDirSettingsGroupBox.ForeColor = Color.White;
            fileDirSettingsGroupBox.Location = new Point(875, 190);
            fileDirSettingsGroupBox.Name = "fileDirSettingsGroupBox";
            fileDirSettingsGroupBox.Size = new Size(636, 138);
            fileDirSettingsGroupBox.TabIndex = 74;
            fileDirSettingsGroupBox.TabStop = false;
            fileDirSettingsGroupBox.Text = "File/Folder Settings (Pro):";
            // 
            // exportButton
            // 
            exportButton.BackColor = Color.Black;
            exportButton.ForeColor = Color.White;
            exportButton.Location = new Point(145, 96);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(175, 34);
            exportButton.TabIndex = 91;
            exportButton.Text = "Export File List";
            exportButton.UseVisualStyleBackColor = false;
            exportButton.Click += exportButton_Click;
            // 
            // zipSettingsLabel
            // 
            zipSettingsLabel.AutoSize = true;
            zipSettingsLabel.Location = new Point(326, 23);
            zipSettingsLabel.Name = "zipSettingsLabel";
            zipSettingsLabel.Size = new Size(240, 21);
            zipSettingsLabel.TabIndex = 78;
            zipSettingsLabel.Text = "Before C/M Zip File Settings:";
            // 
            // zipTogetherCheckBox
            // 
            zipTogetherCheckBox.AutoSize = true;
            zipTogetherCheckBox.Location = new Point(326, 105);
            zipTogetherCheckBox.Name = "zipTogetherCheckBox";
            zipTogetherCheckBox.Size = new Size(222, 25);
            zipTogetherCheckBox.TabIndex = 77;
            zipTogetherCheckBox.Text = "Zip Files/Dirs. Together";
            zipTogetherCheckBox.UseVisualStyleBackColor = true;
            zipTogetherCheckBox.CheckedChanged += zipTogetherCheckBox_CheckedChanged;
            // 
            // zipSeparateCheckBox
            // 
            zipSeparateCheckBox.AutoSize = true;
            zipSeparateCheckBox.Location = new Point(326, 62);
            zipSeparateCheckBox.Name = "zipSeparateCheckBox";
            zipSeparateCheckBox.Size = new Size(237, 25);
            zipSeparateCheckBox.TabIndex = 76;
            zipSeparateCheckBox.Text = "Zip Files/Dirs. Separately";
            zipSeparateCheckBox.UseVisualStyleBackColor = true;
            zipSeparateCheckBox.CheckedChanged += zipSeparateCheckBox_CheckedChanged;
            // 
            // exportListLabel
            // 
            exportListLabel.AutoSize = true;
            exportListLabel.Location = new Point(14, 23);
            exportListLabel.Name = "exportListLabel";
            exportListLabel.Size = new Size(169, 21);
            exportListLabel.TabIndex = 75;
            exportListLabel.Text = "Export List Settings:";
            // 
            // fullPathsCheckBox
            // 
            fullPathsCheckBox.AutoSize = true;
            fullPathsCheckBox.Checked = true;
            fullPathsCheckBox.CheckState = CheckState.Checked;
            fullPathsCheckBox.Location = new Point(14, 105);
            fullPathsCheckBox.Name = "fullPathsCheckBox";
            fullPathsCheckBox.Size = new Size(116, 25);
            fullPathsCheckBox.TabIndex = 74;
            fullPathsCheckBox.Text = "Full Paths";
            fullPathsCheckBox.UseVisualStyleBackColor = true;
            fullPathsCheckBox.CheckedChanged += fullPathsCheckBox_CheckedChanged;
            // 
            // onlyNamesCheckBox
            // 
            onlyNamesCheckBox.AutoSize = true;
            onlyNamesCheckBox.Location = new Point(14, 62);
            onlyNamesCheckBox.Name = "onlyNamesCheckBox";
            onlyNamesCheckBox.Size = new Size(200, 25);
            onlyNamesCheckBox.TabIndex = 73;
            onlyNamesCheckBox.Text = "Only File/Dir. Names";
            onlyNamesCheckBox.UseVisualStyleBackColor = true;
            onlyNamesCheckBox.CheckedChanged += onlyNamesCheckBox_CheckedChanged;
            // 
            // soundsGroupBox
            // 
            soundsGroupBox.Controls.Add(onAddFilesCheckBox);
            soundsGroupBox.Controls.Add(onErrorCheckBox);
            soundsGroupBox.Controls.Add(onCancelCheckBox);
            soundsGroupBox.Controls.Add(onFinishCheckBox);
            soundsGroupBox.ForeColor = Color.White;
            soundsGroupBox.Location = new Point(6, 350);
            soundsGroupBox.Name = "soundsGroupBox";
            soundsGroupBox.Size = new Size(636, 124);
            soundsGroupBox.TabIndex = 73;
            soundsGroupBox.TabStop = false;
            soundsGroupBox.Text = "Sound Settings:";
            // 
            // onAddFilesCheckBox
            // 
            onAddFilesCheckBox.AutoSize = true;
            onAddFilesCheckBox.Location = new Point(13, 88);
            onAddFilesCheckBox.Name = "onAddFilesCheckBox";
            onAddFilesCheckBox.Size = new Size(278, 25);
            onAddFilesCheckBox.TabIndex = 75;
            onAddFilesCheckBox.Text = "Play Sound When Files Added";
            onAddFilesCheckBox.UseVisualStyleBackColor = true;
            onAddFilesCheckBox.CheckedChanged += onAddFilesCheckBox_CheckedChanged;
            // 
            // onErrorCheckBox
            // 
            onErrorCheckBox.AutoSize = true;
            onErrorCheckBox.Checked = true;
            onErrorCheckBox.CheckState = CheckState.Checked;
            onErrorCheckBox.Location = new Point(367, 88);
            onErrorCheckBox.Name = "onErrorCheckBox";
            onErrorCheckBox.Size = new Size(198, 25);
            onErrorCheckBox.TabIndex = 74;
            onErrorCheckBox.Text = "Play Sound on Error";
            onErrorCheckBox.UseVisualStyleBackColor = true;
            onErrorCheckBox.CheckedChanged += onErrorCheckBox_CheckedChanged;
            // 
            // onCancelCheckBox
            // 
            onCancelCheckBox.AutoSize = true;
            onCancelCheckBox.Checked = true;
            onCancelCheckBox.CheckState = CheckState.Checked;
            onCancelCheckBox.Location = new Point(367, 35);
            onCancelCheckBox.Name = "onCancelCheckBox";
            onCancelCheckBox.Size = new Size(214, 25);
            onCancelCheckBox.TabIndex = 73;
            onCancelCheckBox.Text = "Play Sound on Cancel";
            onCancelCheckBox.UseVisualStyleBackColor = true;
            onCancelCheckBox.CheckedChanged += onCancelCheckBox_CheckedChanged;
            // 
            // onFinishCheckBox
            // 
            onFinishCheckBox.AutoSize = true;
            onFinishCheckBox.Checked = true;
            onFinishCheckBox.CheckState = CheckState.Checked;
            onFinishCheckBox.Location = new Point(13, 35);
            onFinishCheckBox.Name = "onFinishCheckBox";
            onFinishCheckBox.Size = new Size(206, 25);
            onFinishCheckBox.TabIndex = 72;
            onFinishCheckBox.Text = "Play Sound on Finish";
            onFinishCheckBox.UseVisualStyleBackColor = true;
            onFinishCheckBox.CheckedChanged += onFinishCheckBox_CheckedChanged;
            // 
            // skinsLanguageGoupBox
            // 
            skinsLanguageGoupBox.Controls.Add(fontNumUpDown);
            skinsLanguageGoupBox.Controls.Add(fontsLabel);
            skinsLanguageGoupBox.Controls.Add(skinsComboBox);
            skinsLanguageGoupBox.Controls.Add(skinsLabel);
            skinsLanguageGoupBox.Controls.Add(languageComboBox);
            skinsLanguageGoupBox.Controls.Add(languageLabel);
            skinsLanguageGoupBox.ForeColor = Color.White;
            skinsLanguageGoupBox.Location = new Point(6, 190);
            skinsLanguageGoupBox.Name = "skinsLanguageGoupBox";
            skinsLanguageGoupBox.Size = new Size(636, 138);
            skinsLanguageGoupBox.TabIndex = 72;
            skinsLanguageGoupBox.TabStop = false;
            skinsLanguageGoupBox.Text = "Themes and Language";
            // 
            // fontNumUpDown
            // 
            fontNumUpDown.Location = new Point(531, 55);
            fontNumUpDown.Maximum = new decimal(new int[] { 11, 0, 0, 0 });
            fontNumUpDown.Minimum = new decimal(new int[] { 9, 0, 0, 0 });
            fontNumUpDown.Name = "fontNumUpDown";
            fontNumUpDown.Size = new Size(85, 28);
            fontNumUpDown.TabIndex = 91;
            fontNumUpDown.TextAlign = HorizontalAlignment.Center;
            fontNumUpDown.Value = new decimal(new int[] { 9, 0, 0, 0 });
            fontNumUpDown.ValueChanged += fontNumUpDown_ValueChanged;
            // 
            // fontsLabel
            // 
            fontsLabel.AutoSize = true;
            fontsLabel.Location = new Point(407, 55);
            fontsLabel.Name = "fontsLabel";
            fontsLabel.Size = new Size(90, 21);
            fontsLabel.TabIndex = 90;
            fontsLabel.Text = "Font Size:";
            // 
            // skinsComboBox
            // 
            skinsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            skinsComboBox.ForeColor = Color.Black;
            skinsComboBox.FormattingEnabled = true;
            skinsComboBox.Items.AddRange(new object[] { "Dark Mode", "Light Mode" });
            skinsComboBox.Location = new Point(182, 88);
            skinsComboBox.Name = "skinsComboBox";
            skinsComboBox.Size = new Size(200, 29);
            skinsComboBox.TabIndex = 70;
            skinsComboBox.SelectedIndexChanged += skinsComboBox_SelectedIndexChanged;
            // 
            // skinsLabel
            // 
            skinsLabel.AutoSize = true;
            skinsLabel.Location = new Point(74, 91);
            skinsLabel.Name = "skinsLabel";
            skinsLabel.Size = new Size(59, 21);
            skinsLabel.TabIndex = 69;
            skinsLabel.Text = "Skins:";
            // 
            // languageComboBox
            // 
            languageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            languageComboBox.FormattingEnabled = true;
            languageComboBox.Items.AddRange(new object[] { "English", "French", "German" });
            languageComboBox.Location = new Point(182, 27);
            languageComboBox.Name = "languageComboBox";
            languageComboBox.Size = new Size(200, 29);
            languageComboBox.TabIndex = 68;
            // 
            // languageLabel
            // 
            languageLabel.AutoSize = true;
            languageLabel.Location = new Point(44, 30);
            languageLabel.Name = "languageLabel";
            languageLabel.Size = new Size(95, 21);
            languageLabel.TabIndex = 67;
            languageLabel.Text = "Language:";
            // 
            // windowGroupBox
            // 
            windowGroupBox.Controls.Add(contextMenuCheckBox);
            windowGroupBox.Controls.Add(pasteLabel);
            windowGroupBox.Controls.Add(settingsWindowLabel);
            windowGroupBox.Controls.Add(minimizeSystemTrayCheckBox);
            windowGroupBox.Controls.Add(alwaysOnTopCheckBox);
            windowGroupBox.Controls.Add(confirmDragDropCheckBox);
            windowGroupBox.Controls.Add(dragDropLabel);
            windowGroupBox.ForeColor = Color.White;
            windowGroupBox.Location = new Point(6, 18);
            windowGroupBox.Name = "windowGroupBox";
            windowGroupBox.Size = new Size(636, 150);
            windowGroupBox.TabIndex = 71;
            windowGroupBox.TabStop = false;
            windowGroupBox.Text = "Window Settings:";
            // 
            // contextMenuCheckBox
            // 
            contextMenuCheckBox.AutoSize = true;
            contextMenuCheckBox.Checked = true;
            contextMenuCheckBox.CheckState = CheckState.Checked;
            contextMenuCheckBox.Location = new Point(136, 111);
            contextMenuCheckBox.Name = "contextMenuCheckBox";
            contextMenuCheckBox.Size = new Size(272, 25);
            contextMenuCheckBox.TabIndex = 74;
            contextMenuCheckBox.Text = "Add Copy That Context Menu";
            contextMenuCheckBox.UseVisualStyleBackColor = true;
            contextMenuCheckBox.CheckedChanged += contextMenuCheckBox_CheckedChanged;
            // 
            // pasteLabel
            // 
            pasteLabel.AutoSize = true;
            pasteLabel.Location = new Point(44, 112);
            pasteLabel.Name = "pasteLabel";
            pasteLabel.Size = new Size(61, 21);
            pasteLabel.TabIndex = 73;
            pasteLabel.Text = "Paste:";
            // 
            // settingsWindowLabel
            // 
            settingsWindowLabel.AutoSize = true;
            settingsWindowLabel.Location = new Point(25, 42);
            settingsWindowLabel.Name = "settingsWindowLabel";
            settingsWindowLabel.Size = new Size(79, 21);
            settingsWindowLabel.TabIndex = 70;
            settingsWindowLabel.Text = "Window:";
            // 
            // minimizeSystemTrayCheckBox
            // 
            minimizeSystemTrayCheckBox.AutoSize = true;
            minimizeSystemTrayCheckBox.Checked = true;
            minimizeSystemTrayCheckBox.CheckState = CheckState.Checked;
            minimizeSystemTrayCheckBox.Location = new Point(334, 40);
            minimizeSystemTrayCheckBox.Name = "minimizeSystemTrayCheckBox";
            minimizeSystemTrayCheckBox.Size = new Size(230, 25);
            minimizeSystemTrayCheckBox.TabIndex = 72;
            minimizeSystemTrayCheckBox.Text = "Minimize to System Tray";
            minimizeSystemTrayCheckBox.UseVisualStyleBackColor = true;
            minimizeSystemTrayCheckBox.CheckedChanged += minimizeSystemTrayCheckBox_CheckedChanged;
            // 
            // alwaysOnTopCheckBox
            // 
            alwaysOnTopCheckBox.AutoSize = true;
            alwaysOnTopCheckBox.Checked = true;
            alwaysOnTopCheckBox.CheckState = CheckState.Checked;
            alwaysOnTopCheckBox.Location = new Point(136, 41);
            alwaysOnTopCheckBox.Name = "alwaysOnTopCheckBox";
            alwaysOnTopCheckBox.Size = new Size(152, 25);
            alwaysOnTopCheckBox.TabIndex = 71;
            alwaysOnTopCheckBox.Text = "Always on Top";
            alwaysOnTopCheckBox.UseVisualStyleBackColor = true;
            alwaysOnTopCheckBox.CheckedChanged += alwaysOnTopCheckBox_CheckedChanged;
            // 
            // confirmDragDropCheckBox
            // 
            confirmDragDropCheckBox.AutoSize = true;
            confirmDragDropCheckBox.Checked = true;
            confirmDragDropCheckBox.CheckState = CheckState.Checked;
            confirmDragDropCheckBox.Location = new Point(136, 76);
            confirmDragDropCheckBox.Name = "confirmDragDropCheckBox";
            confirmDragDropCheckBox.Size = new Size(237, 25);
            confirmDragDropCheckBox.TabIndex = 66;
            confirmDragDropCheckBox.Text = "Always Confirm File Drop";
            confirmDragDropCheckBox.UseVisualStyleBackColor = true;
            confirmDragDropCheckBox.CheckedChanged += confirmDragDropCheckBox_CheckedChanged;
            // 
            // dragDropLabel
            // 
            dragDropLabel.AutoSize = true;
            dragDropLabel.Location = new Point(6, 77);
            dragDropLabel.Name = "dragDropLabel";
            dragDropLabel.Size = new Size(98, 21);
            dragDropLabel.TabIndex = 65;
            dragDropLabel.Text = "Drag Drop:";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(cmdMainPage);
            tabControl1.Controls.Add(cmdSkipPage);
            tabControl1.Controls.Add(cmdCopyHistoryPage);
            tabControl1.Controls.Add(cmdExclusionsPage);
            tabControl1.Controls.Add(cmdSettingsPage);
            tabControl1.Controls.Add(cmdAboutPage);
            tabControl1.Location = new Point(13, 68);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1525, 995);
            tabControl1.TabIndex = 60;
            tabControl1.Selected += tabControl1_Selected;
            tabControl1.MouseDown += tabControl1_MouseDown;
            // 
            // cmdExclusionsPage
            // 
            cmdExclusionsPage.BackColor = Color.Black;
            cmdExclusionsPage.BackgroundImageLayout = ImageLayout.Stretch;
            cmdExclusionsPage.Controls.Add(btnClearExcluded);
            cmdExclusionsPage.Controls.Add(btnRemoveExcluded);
            cmdExclusionsPage.Controls.Add(btnAddExcluded);
            cmdExclusionsPage.Controls.Add(btnClearAllowed);
            cmdExclusionsPage.Controls.Add(btnRemoveAllowed);
            cmdExclusionsPage.Controls.Add(btnAddAllowed);
            cmdExclusionsPage.Controls.Add(excludedTextBox);
            cmdExclusionsPage.Controls.Add(allowedTextBox);
            cmdExclusionsPage.Controls.Add(excludedLabel);
            cmdExclusionsPage.Controls.Add(allowedLabel);
            cmdExclusionsPage.Controls.Add(excludedExtListBox);
            cmdExclusionsPage.Controls.Add(allowedExtListBox);
            cmdExclusionsPage.Location = new Point(4, 34);
            cmdExclusionsPage.Name = "cmdExclusionsPage";
            cmdExclusionsPage.Padding = new Padding(3);
            cmdExclusionsPage.Size = new Size(1517, 957);
            cmdExclusionsPage.TabIndex = 5;
            cmdExclusionsPage.Text = "- Allowed/Exclusions";
            // 
            // btnClearExcluded
            // 
            btnClearExcluded.BackColor = Color.Black;
            btnClearExcluded.ForeColor = Color.White;
            btnClearExcluded.Location = new Point(1249, 17);
            btnClearExcluded.Name = "btnClearExcluded";
            btnClearExcluded.Size = new Size(161, 34);
            btnClearExcluded.TabIndex = 75;
            btnClearExcluded.Text = "Clear List";
            btnClearExcluded.UseVisualStyleBackColor = false;
            btnClearExcluded.Click += btnClearExcluded_Click;
            // 
            // btnRemoveExcluded
            // 
            btnRemoveExcluded.BackColor = Color.Black;
            btnRemoveExcluded.ForeColor = Color.White;
            btnRemoveExcluded.Location = new Point(1043, 17);
            btnRemoveExcluded.Name = "btnRemoveExcluded";
            btnRemoveExcluded.Size = new Size(161, 34);
            btnRemoveExcluded.TabIndex = 74;
            btnRemoveExcluded.Text = "Remove Ext.";
            btnRemoveExcluded.UseVisualStyleBackColor = false;
            btnRemoveExcluded.Click += btnRemoveExcluded_Click;
            // 
            // btnAddExcluded
            // 
            btnAddExcluded.BackColor = Color.Black;
            btnAddExcluded.ForeColor = Color.White;
            btnAddExcluded.Location = new Point(837, 17);
            btnAddExcluded.Name = "btnAddExcluded";
            btnAddExcluded.Size = new Size(161, 34);
            btnAddExcluded.TabIndex = 73;
            btnAddExcluded.Text = "Add Ext.";
            btnAddExcluded.UseVisualStyleBackColor = false;
            btnAddExcluded.Click += btnAddExcluded_Click;
            // 
            // btnClearAllowed
            // 
            btnClearAllowed.BackColor = Color.Black;
            btnClearAllowed.ForeColor = Color.White;
            btnClearAllowed.Location = new Point(517, 17);
            btnClearAllowed.Name = "btnClearAllowed";
            btnClearAllowed.Size = new Size(161, 34);
            btnClearAllowed.TabIndex = 72;
            btnClearAllowed.Text = "Clear List";
            btnClearAllowed.UseVisualStyleBackColor = false;
            btnClearAllowed.Click += btnClearAllowed_Click;
            // 
            // btnRemoveAllowed
            // 
            btnRemoveAllowed.BackColor = Color.Black;
            btnRemoveAllowed.ForeColor = Color.White;
            btnRemoveAllowed.Location = new Point(311, 17);
            btnRemoveAllowed.Name = "btnRemoveAllowed";
            btnRemoveAllowed.Size = new Size(161, 34);
            btnRemoveAllowed.TabIndex = 71;
            btnRemoveAllowed.Text = "Remove Ext.";
            btnRemoveAllowed.UseVisualStyleBackColor = false;
            btnRemoveAllowed.Click += btnRemoveAllowed_Click;
            // 
            // btnAddAllowed
            // 
            btnAddAllowed.BackColor = Color.Black;
            btnAddAllowed.ForeColor = Color.White;
            btnAddAllowed.Location = new Point(105, 17);
            btnAddAllowed.Name = "btnAddAllowed";
            btnAddAllowed.Size = new Size(161, 34);
            btnAddAllowed.TabIndex = 70;
            btnAddAllowed.Text = "Add Ext.";
            btnAddAllowed.UseVisualStyleBackColor = false;
            btnAddAllowed.Click += btnAddAllowed_Click;
            // 
            // excludedTextBox
            // 
            excludedTextBox.Location = new Point(837, 89);
            excludedTextBox.MaxLength = 6;
            excludedTextBox.Name = "excludedTextBox";
            excludedTextBox.Size = new Size(574, 28);
            excludedTextBox.TabIndex = 11;
            excludedTextBox.TextChanged += excludedTextBox_TextChanged;
            excludedTextBox.KeyDown += excludedTextBox_KeyDown;
            excludedTextBox.KeyPress += excludedTextBox_KeyPress;
            // 
            // allowedTextBox
            // 
            allowedTextBox.Location = new Point(105, 89);
            allowedTextBox.MaxLength = 6;
            allowedTextBox.Name = "allowedTextBox";
            allowedTextBox.Size = new Size(574, 28);
            allowedTextBox.TabIndex = 10;
            allowedTextBox.TextChanged += allowedTextBox_TextChanged;
            allowedTextBox.KeyDown += allowedTextBox_KeyDown;
            allowedTextBox.KeyPress += allowedTextBox_KeyPress;
            // 
            // excludedLabel
            // 
            excludedLabel.AutoSize = true;
            excludedLabel.BackColor = Color.Transparent;
            excludedLabel.Location = new Point(837, 133);
            excludedLabel.Name = "excludedLabel";
            excludedLabel.Size = new Size(180, 21);
            excludedLabel.TabIndex = 9;
            excludedLabel.Text = "Excluded Extensions:";
            // 
            // allowedLabel
            // 
            allowedLabel.AutoSize = true;
            allowedLabel.BackColor = Color.Transparent;
            allowedLabel.Location = new Point(105, 133);
            allowedLabel.Name = "allowedLabel";
            allowedLabel.Size = new Size(169, 21);
            allowedLabel.TabIndex = 8;
            allowedLabel.Text = "Allowed Extensions:";
            // 
            // excludedExtListBox
            // 
            excludedExtListBox.FormattingEnabled = true;
            excludedExtListBox.ItemHeight = 21;
            excludedExtListBox.Location = new Point(837, 160);
            excludedExtListBox.Name = "excludedExtListBox";
            excludedExtListBox.ScrollAlwaysVisible = true;
            excludedExtListBox.Size = new Size(574, 382);
            excludedExtListBox.TabIndex = 1;
            // 
            // allowedExtListBox
            // 
            allowedExtListBox.FormattingEnabled = true;
            allowedExtListBox.ItemHeight = 21;
            allowedExtListBox.Items.AddRange(new object[] { "*.*" });
            allowedExtListBox.Location = new Point(105, 160);
            allowedExtListBox.Name = "allowedExtListBox";
            allowedExtListBox.ScrollAlwaysVisible = true;
            allowedExtListBox.Size = new Size(574, 382);
            allowedExtListBox.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Copy That File/Directory Tool";
            notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { showCopyThat, exitCopyThat });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(215, 68);
            // 
            // showCopyThat
            // 
            showCopyThat.Name = "showCopyThat";
            showCopyThat.Size = new Size(214, 32);
            showCopyThat.Text = "Show Copy That";
            showCopyThat.Click += showCopyThat_Click;
            // 
            // exitCopyThat
            // 
            exitCopyThat.Name = "exitCopyThat";
            exitCopyThat.Size = new Size(214, 32);
            exitCopyThat.Text = "Exit Copy That";
            exitCopyThat.Click += exitCopyThat_Click_1;
            // 
            // rollDownPicBox
            // 
            rollDownPicBox.BackColor = Color.Transparent;
            rollDownPicBox.Image = Properties.Resources.icons8_down_40;
            rollDownPicBox.Location = new Point(1239, 23);
            rollDownPicBox.Name = "rollDownPicBox";
            rollDownPicBox.Size = new Size(37, 42);
            rollDownPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            rollDownPicBox.TabIndex = 102;
            rollDownPicBox.TabStop = false;
            rollDownPicBox.Click += rollDownPicBox_Click;
            // 
            // rollUpPicBox
            // 
            rollUpPicBox.BackColor = Color.Transparent;
            rollUpPicBox.Image = Properties.Resources.icons8_up_40;
            rollUpPicBox.Location = new Point(1172, 20);
            rollUpPicBox.Name = "rollUpPicBox";
            rollUpPicBox.Size = new Size(37, 42);
            rollUpPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            rollUpPicBox.TabIndex = 101;
            rollUpPicBox.TabStop = false;
            rollUpPicBox.Click += rollUpPicBox_Click;
            // 
            // titleLabel
            // 
            titleLabel.BorderStyle = BorderStyle.Fixed3D;
            titleLabel.Font = new Font("Cascadia Code", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(12, 7);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(1139, 58);
            titleLabel.TabIndex = 34;
            titleLabel.Text = "Copy That By: Havoc";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.MouseDown += titleLabel_MouseDown;
            // 
            // scrollTimer
            // 
            scrollTimer.Interval = 30;
            scrollTimer.Tick += scrollTimer_Tick;
            // 
            // mainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.Black;
            ClientSize = new Size(1550, 1074);
            Controls.Add(tabControl1);
            Controls.Add(rollDownPicBox);
            Controls.Add(rollUpPicBox);
            Controls.Add(titleLabel);
            Controls.Add(aboutPicBox);
            Controls.Add(settingsPicBox);
            Controls.Add(minimizePicBox);
            Controls.Add(exitPicBox);
            Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "mainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Copy That By: Havoc";
            Load += mainForm_Load;
            DragDrop += mainForm_DragDrop;
            DragEnter += mainForm_DragEnter;
            MouseDown += mainForm_MouseDown;
            Resize += mainForm_Resize;
            ((System.ComponentModel.ISupportInitialize)exitPicBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)minimizePicBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)settingsPicBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)aboutPicBox).EndInit();
            cmdAboutPage.ResumeLayout(false);
            cmdAboutPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)havocSoftwarePicBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)copyThatPicBox).EndInit();
            cmdSkipPage.ResumeLayout(false);
            cmdSkipPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)skippedDataGridView).EndInit();
            cmdMainPage.ResumeLayout(false);
            cmdMainPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)moveBottomPicBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)moveTopPicBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileDownPicBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileUpPicBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileIconPicBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileDirDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)targetDirPicBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)fromDirPicBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileNamePicBox).EndInit();
            cmdSettingsPage.ResumeLayout(false);
            cmdSettingsPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)exportDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)opacityTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)priorityTrackBar).EndInit();
            emailGroupBox.ResumeLayout(false);
            emailGroupBox.PerformLayout();
            updateGroupBox.ResumeLayout(false);
            updateGroupBox.PerformLayout();
            performanceGroupBox.ResumeLayout(false);
            performanceGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)setMBGBUnderNumUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)setMBGBOverNumUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)bufferNumUpDown).EndInit();
            otherSettingsGroupBox.ResumeLayout(false);
            otherSettingsGroupBox.PerformLayout();
            fileDirSettingsGroupBox.ResumeLayout(false);
            fileDirSettingsGroupBox.PerformLayout();
            soundsGroupBox.ResumeLayout(false);
            soundsGroupBox.PerformLayout();
            skinsLanguageGoupBox.ResumeLayout(false);
            skinsLanguageGoupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fontNumUpDown).EndInit();
            windowGroupBox.ResumeLayout(false);
            windowGroupBox.PerformLayout();
            tabControl1.ResumeLayout(false);
            cmdExclusionsPage.ResumeLayout(false);
            cmdExclusionsPage.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)rollDownPicBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)rollUpPicBox).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox exitPicBox;
        private System.Windows.Forms.Timer timeRemainingTimer;
        public System.ComponentModel.BackgroundWorker getFoldersBackgroundWorker;
        private System.ComponentModel.BackgroundWorker COPYbackgroundWorker;
        private System.ComponentModel.BackgroundWorker DELETEbackgroundWorker;
        private System.ComponentModel.BackgroundWorker MOVEbackgroundWorker;
        private PictureBox minimizePicBox;
        private PictureBox settingsPicBox;
        private PictureBox aboutPicBox;
        private System.Windows.Forms.Timer expandTimer;
        private System.Windows.Forms.Timer retractTimer;
        private OpenFileDialog openFileDialog;
        private System.ComponentModel.BackgroundWorker fileDirSizeBGW;
        private System.ComponentModel.BackgroundWorker removeDirBGW;
        private CheckBox createCustomDirCheckBox;
        private Label excludedLabel;
        private CheckBox checkBox6;
        private CheckBox keepDirStructCheckBox;
        private TabPage cmdAboutPage;
        private Label creditsLabel;
        private TabPage cmdCopyHistoryPage;
        private TabPage cmdSkipPage;
        private Label totalSkippedLabel;
        private Button btnClearSkippedList;
        private Button btnGoToInExplorer;
        private DataGridView skippedDataGridView;
        private TabPage cmdMainPage;
        private Label totalHDSpaceLeftLabel;
        private CheckBox doNotOverwriteCHKBOX;
        private CheckBox overwriteAllCHKBOX;
        private CheckBox overwriteIfNewerCHKBOX;
        private Label filesIconLabel;
        private Button removeFileButton;
        private Button addFileButton;
        private Button clearFileListButton;
        private PictureBox moveBottomPicBox;
        private Label moveBottomLabel;
        private PictureBox moveTopPicBox;
        private Label moveTopLabel;
        private PictureBox fileDownPicBox;
        private Label fileDownLabel;
        private PictureBox fileUpPicBox;
        private Label fileUpLabel;
        private Button clearTextButton;
        private TextBox searchTextBox;
        private Label searchFileFolderLabel;
        private Label fileListLabel;
        private Label onFinishLabel;
        private Label cmdLabel;
        private ComboBox onFinishComboBox;
        private Button skipButton;
        private PictureBox fileIconPicBox;
        private Label speedLabel;
        private Label fileProcessedLabel;
        private ComboBox copyMoveDeleteComboBox;
        private Label totalCopiedProgressLabel;
        private Label fileCountOnLabel;
        private Label timeRemainingLabel;
        private Label elapsedTimeLabel;
        private Button pauseResumeButton;
        private Label overallProgressLabel;
        private Label fileProgressLabel;
        private Label fileTotalProgressLabel;
        private Label totalProgressLabel;
        private ProgressBar fileProgressBar;
        private ProgressBar totalProgressBar;
        private DataGridView fileDirDataGridView;
        private DataGridViewImageColumn statusIcon;
        private DataGridViewTextBoxColumn statusColumn;
        private DataGridViewTextBoxColumn filePathColumn;
        private DataGridViewTextBoxColumn fileFolderNameColumn;
        private DataGridViewTextBoxColumn fileSize;
        private Button cancelButton;
        private Button startButton;
        private PictureBox targetDirPicBox;
        private PictureBox fromDirPicBox;
        private PictureBox fileNamePicBox;
        private Label targetDirLabel;
        private Label fromFilesDirLabel;
        private Label filePathLabel;
        private Label targetLabel;
        private Label fromLabel;
        private Label fileNameLabel;
        private TabPage cmdSettingsPage;
        private CheckBox saveAutoCheckBox;
        private Button defaultSettingsButton;
        private Button recSettingsButton;
        private Button clearSettingsButton;
        private Button saveSettingsButton;
        private GroupBox emailGroupBox;
        private Button setUpEmailButton;
        private CheckBox emailPathsCheckBox;
        private CheckBox emailNamesCheckBox;
        private Label whenEmailingLabel;
        private GroupBox updateGroupBox;
        private CheckBox updateManuallyCheckBox;
        private Button checkForUpdatesButton;
        private CheckBox updateBetaCheckBox;
        private CheckBox updateAutoCheckBox;
        private GroupBox performanceGroupBox;
        private CheckBox overMBCheckBox;
        private CheckBox underMBCheckBox;
        private Label setMBGBOLabel;
        private Label setMBGBULabel;
        private NumericUpDown setMBGBUnderNumUD;
        private Label setMBUmderLabel;
        private NumericUpDown setMBGBOverNumUD;
        private Label setMBGBOverLabel;
        private NumericUpDown bufferNumUpDown;
        private Label setBufferLabel;
        private GroupBox otherSettingsGroupBox;
        private MaskedTextBox serialMaskedTextBox;
        private Button registerButton;
        private Label serialNumberLabel;
        private Label errorOccursLabel;
        private CheckBox restartCheckBox;
        private CheckBox closeProgramCheckBox;
        private GroupBox fileDirSettingsGroupBox;
        private Label zipSettingsLabel;
        private CheckBox zipTogetherCheckBox;
        private CheckBox zipSeparateCheckBox;
        private Label exportListLabel;
        private CheckBox fullPathsCheckBox;
        private CheckBox onlyNamesCheckBox;
        private GroupBox soundsGroupBox;
        private CheckBox onAddFilesCheckBox;
        private CheckBox onErrorCheckBox;
        private CheckBox onCancelCheckBox;
        private CheckBox onFinishCheckBox;
        private GroupBox skinsLanguageGoupBox;
        private Label fontsLabel;
        private ComboBox skinsComboBox;
        private Label skinsLabel;
        private ComboBox languageComboBox;
        private Label languageLabel;
        private GroupBox windowGroupBox;
        private CheckBox contextMenuCheckBox;
        private Label pasteLabel;
        private Label settingsWindowLabel;
        private CheckBox minimizeSystemTrayCheckBox;
        private CheckBox alwaysOnTopCheckBox;
        private CheckBox confirmDragDropCheckBox;
        private Label dragDropLabel;
        private TabControl tabControl1;
        private Label cmOnlyIfLabel;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem showCopyThat;
        private ToolStripMenuItem exitCopyThat;
        private TabPage cmdExclusionsPage;
        private TextBox excludedTextBox;
        private TextBox allowedTextBox;
        private Label allowedLabel;
        private ListBox excludedExtListBox;
        private ListBox allowedExtListBox;
        private Button btnClearExcluded;
        private Button btnRemoveExcluded;
        private Button btnAddExcluded;
        private Button btnClearAllowed;
        private Button btnRemoveAllowed;
        private Button btnAddAllowed;
        private NumericUpDown fontNumUpDown;
        private Button exportButton;
        private CheckBox copyFilesDirsCheckBox;
        private Label northEastLabel;
        private CheckBox multithreadCheckBox;
        private Label kbLabel;
        private TrackBar priorityTrackBar;
        private Label priorityLabel;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn sourcePath;
        private DataGridViewTextBoxColumn destinationPath;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private CheckBox verifyCheckBox;
        private CheckBox logFileCheckBox;
        private Label opacityLabel;
        private TrackBar opacityTrackBar;
        private PictureBox rollDownPicBox;
        private PictureBox rollUpPicBox;
        private DataGridView exportDataGridView;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private Label exportFileListLabel;
        private Label titleLabel;
        private CheckBox startWithWindowsCheckBox;
        private Label label1;
        private Label seLabel;
        private Label sLabel;
        private Label swLabel;
        private Label eLabel;
        private Label neLabel;
        private Label nLabel;
        private Label nwLabel;
        private Label wLabel;
        private System.Windows.Forms.Timer scrollTimer;
        private PictureBox copyThatPicBox;
        private PictureBox havocSoftwarePicBox;
    }
}
