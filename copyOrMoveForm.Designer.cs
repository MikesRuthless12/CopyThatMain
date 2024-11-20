namespace Havoc__Copy_That
{
    partial class copyOrMoveForm
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
            copyOrMoveComboBox = new ComboBox();
            targetDirLabel = new Label();
            folderPicBox = new PictureBox();
            okButton = new Button();
            cancelButton = new Button();
            minimizePicBox = new PictureBox();
            exitPicBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)folderPicBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minimizePicBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)exitPicBox).BeginInit();
            SuspendLayout();
            // 
            // copyOrMoveComboBox
            // 
            copyOrMoveComboBox.FormattingEnabled = true;
            copyOrMoveComboBox.Items.AddRange(new object[] { "Copy To", "Move To" });
            copyOrMoveComboBox.Location = new Point(12, 83);
            copyOrMoveComboBox.Name = "copyOrMoveComboBox";
            copyOrMoveComboBox.Size = new Size(182, 32);
            copyOrMoveComboBox.TabIndex = 0;
            copyOrMoveComboBox.Text = "Copy To";
            // 
            // targetDirLabel
            // 
            targetDirLabel.Location = new Point(12, 147);
            targetDirLabel.Name = "targetDirLabel";
            targetDirLabel.Size = new Size(665, 214);
            targetDirLabel.TabIndex = 1;
            targetDirLabel.Text = "Target: ";
            // 
            // folderPicBox
            // 
            folderPicBox.BackColor = Color.Transparent;
            folderPicBox.Image = Properties.Resources.icons8_folder_40;
            folderPicBox.Location = new Point(268, 73);
            folderPicBox.Name = "folderPicBox";
            folderPicBox.Size = new Size(37, 42);
            folderPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            folderPicBox.TabIndex = 7;
            folderPicBox.TabStop = false;
            folderPicBox.Click += folderPicBox_Click;
            // 
            // okButton
            // 
            okButton.Location = new Point(379, 81);
            okButton.Name = "okButton";
            okButton.Size = new Size(112, 34);
            okButton.TabIndex = 8;
            okButton.Text = "Ok";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(565, 81);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(112, 34);
            cancelButton.TabIndex = 9;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // minimizePicBox
            // 
            minimizePicBox.BackColor = Color.Transparent;
            minimizePicBox.Image = Properties.Resources.icons8_minimize_40;
            minimizePicBox.Location = new Point(587, 12);
            minimizePicBox.Name = "minimizePicBox";
            minimizePicBox.Size = new Size(37, 42);
            minimizePicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            minimizePicBox.TabIndex = 26;
            minimizePicBox.TabStop = false;
            minimizePicBox.Click += minimizePicBox_Click;
            // 
            // exitPicBox
            // 
            exitPicBox.BackColor = Color.Transparent;
            exitPicBox.Image = Properties.Resources.icons8_close_40;
            exitPicBox.Location = new Point(640, 12);
            exitPicBox.Name = "exitPicBox";
            exitPicBox.Size = new Size(37, 42);
            exitPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            exitPicBox.TabIndex = 25;
            exitPicBox.TabStop = false;
            exitPicBox.Click += exitPicBox_Click;
            // 
            // copyOrMoveForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(680, 382);
            Controls.Add(minimizePicBox);
            Controls.Add(exitPicBox);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(folderPicBox);
            Controls.Add(targetDirLabel);
            Controls.Add(copyOrMoveComboBox);
            Font = new Font("Cascadia Code SemiBold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "copyOrMoveForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Copy/Move To Target";
            ((System.ComponentModel.ISupportInitialize)folderPicBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)minimizePicBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)exitPicBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox copyOrMoveComboBox;
        private Label targetDirLabel;
        private PictureBox folderPicBox;
        private Button okButton;
        private Button cancelButton;
        private PictureBox minimizePicBox;
        private PictureBox exitPicBox;
    }
}