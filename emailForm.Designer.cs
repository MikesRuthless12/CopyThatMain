namespace Havoc__Copy_That
{
    partial class emailForm
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
            exitPicBox = new PictureBox();
            sendEmailGroupBox = new GroupBox();
            emailBodyTextBox = new TextBox();
            emailBodyLabel = new Label();
            clearButton = new Button();
            emailSubjectTextBox = new TextBox();
            emailSubjectLabel = new Label();
            emailAddressToTextBox = new TextBox();
            emailAddressToLabel = new Label();
            emailAddressFromPassword = new TextBox();
            emailAddressPasswordLabel = new Label();
            emailFromTextBox = new TextBox();
            fromEmailLabel = new Label();
            sendEmailButton = new Button();
            ((System.ComponentModel.ISupportInitialize)exitPicBox).BeginInit();
            sendEmailGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // exitPicBox
            // 
            exitPicBox.BackColor = Color.Transparent;
            exitPicBox.Image = Properties.Resources.icons8_close_40;
            exitPicBox.Location = new Point(751, 12);
            exitPicBox.Name = "exitPicBox";
            exitPicBox.Size = new Size(37, 42);
            exitPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            exitPicBox.TabIndex = 27;
            exitPicBox.TabStop = false;
            exitPicBox.Click += exitPicBox_Click;
            // 
            // sendEmailGroupBox
            // 
            sendEmailGroupBox.Controls.Add(emailBodyTextBox);
            sendEmailGroupBox.Controls.Add(emailBodyLabel);
            sendEmailGroupBox.Controls.Add(clearButton);
            sendEmailGroupBox.Controls.Add(emailSubjectTextBox);
            sendEmailGroupBox.Controls.Add(emailSubjectLabel);
            sendEmailGroupBox.Controls.Add(emailAddressToTextBox);
            sendEmailGroupBox.Controls.Add(emailAddressToLabel);
            sendEmailGroupBox.Controls.Add(emailAddressFromPassword);
            sendEmailGroupBox.Controls.Add(emailAddressPasswordLabel);
            sendEmailGroupBox.Controls.Add(emailFromTextBox);
            sendEmailGroupBox.Controls.Add(fromEmailLabel);
            sendEmailGroupBox.Controls.Add(sendEmailButton);
            sendEmailGroupBox.ForeColor = Color.White;
            sendEmailGroupBox.Location = new Point(12, 66);
            sendEmailGroupBox.Name = "sendEmailGroupBox";
            sendEmailGroupBox.Size = new Size(776, 471);
            sendEmailGroupBox.TabIndex = 75;
            sendEmailGroupBox.TabStop = false;
            sendEmailGroupBox.Text = "Email Settings:";
            // 
            // emailBodyTextBox
            // 
            emailBodyTextBox.BorderStyle = BorderStyle.FixedSingle;
            emailBodyTextBox.Location = new Point(6, 315);
            emailBodyTextBox.MaxLength = 100;
            emailBodyTextBox.Multiline = true;
            emailBodyTextBox.Name = "emailBodyTextBox";
            emailBodyTextBox.Size = new Size(764, 110);
            emailBodyTextBox.TabIndex = 105;
            // 
            // emailBodyLabel
            // 
            emailBodyLabel.AutoSize = true;
            emailBodyLabel.Location = new Point(6, 287);
            emailBodyLabel.Name = "emailBodyLabel";
            emailBodyLabel.Size = new Size(311, 25);
            emailBodyLabel.TabIndex = 104;
            emailBodyLabel.Text = "Email Body (Text File Will Be Included):";
            // 
            // clearButton
            // 
            clearButton.BackColor = Color.Black;
            clearButton.ForeColor = Color.White;
            clearButton.Location = new Point(595, 431);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(175, 34);
            clearButton.TabIndex = 103;
            clearButton.Text = "Clear Fields";
            clearButton.UseVisualStyleBackColor = false;
            // 
            // emailSubjectTextBox
            // 
            emailSubjectTextBox.BorderStyle = BorderStyle.FixedSingle;
            emailSubjectTextBox.Location = new Point(269, 218);
            emailSubjectTextBox.MaxLength = 100;
            emailSubjectTextBox.Name = "emailSubjectTextBox";
            emailSubjectTextBox.Size = new Size(501, 31);
            emailSubjectTextBox.TabIndex = 102;
            // 
            // emailSubjectLabel
            // 
            emailSubjectLabel.AutoSize = true;
            emailSubjectLabel.Location = new Point(108, 221);
            emailSubjectLabel.Name = "emailSubjectLabel";
            emailSubjectLabel.Size = new Size(121, 25);
            emailSubjectLabel.TabIndex = 101;
            emailSubjectLabel.Text = "Email Subject:";
            // 
            // emailAddressToTextBox
            // 
            emailAddressToTextBox.BorderStyle = BorderStyle.FixedSingle;
            emailAddressToTextBox.Location = new Point(269, 154);
            emailAddressToTextBox.MaxLength = 60;
            emailAddressToTextBox.Name = "emailAddressToTextBox";
            emailAddressToTextBox.Size = new Size(501, 31);
            emailAddressToTextBox.TabIndex = 100;
            // 
            // emailAddressToLabel
            // 
            emailAddressToLabel.AutoSize = true;
            emailAddressToLabel.Location = new Point(38, 157);
            emailAddressToLabel.Name = "emailAddressToLabel";
            emailAddressToLabel.Size = new Size(191, 25);
            emailAddressToLabel.TabIndex = 99;
            emailAddressToLabel.Text = "Email Address Sent To:";
            // 
            // emailAddressFromPassword
            // 
            emailAddressFromPassword.BorderStyle = BorderStyle.FixedSingle;
            emailAddressFromPassword.Location = new Point(269, 96);
            emailAddressFromPassword.MaxLength = 60;
            emailAddressFromPassword.Name = "emailAddressFromPassword";
            emailAddressFromPassword.Size = new Size(501, 31);
            emailAddressFromPassword.TabIndex = 98;
            // 
            // emailAddressPasswordLabel
            // 
            emailAddressPasswordLabel.AutoSize = true;
            emailAddressPasswordLabel.Location = new Point(21, 97);
            emailAddressPasswordLabel.Name = "emailAddressPasswordLabel";
            emailAddressPasswordLabel.Size = new Size(208, 25);
            emailAddressPasswordLabel.TabIndex = 97;
            emailAddressPasswordLabel.Text = "Email Address Password:";
            // 
            // emailFromTextBox
            // 
            emailFromTextBox.BorderStyle = BorderStyle.FixedSingle;
            emailFromTextBox.Location = new Point(269, 38);
            emailFromTextBox.MaxLength = 60;
            emailFromTextBox.Name = "emailFromTextBox";
            emailFromTextBox.Size = new Size(501, 31);
            emailFromTextBox.TabIndex = 96;
            // 
            // fromEmailLabel
            // 
            fromEmailLabel.AutoSize = true;
            fromEmailLabel.Location = new Point(14, 41);
            fromEmailLabel.Name = "fromEmailLabel";
            fromEmailLabel.Size = new Size(215, 25);
            fromEmailLabel.TabIndex = 95;
            fromEmailLabel.Text = "Email Address Sent From:";
            // 
            // sendEmailButton
            // 
            sendEmailButton.BackColor = Color.Black;
            sendEmailButton.ForeColor = Color.White;
            sendEmailButton.Location = new Point(14, 431);
            sendEmailButton.Name = "sendEmailButton";
            sendEmailButton.Size = new Size(175, 34);
            sendEmailButton.TabIndex = 91;
            sendEmailButton.Text = "Send Email";
            sendEmailButton.UseVisualStyleBackColor = false;
            sendEmailButton.Click += sendEmailButton_Click;
            // 
            // emailForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 591);
            Controls.Add(sendEmailGroupBox);
            Controls.Add(exitPicBox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "emailForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Email Form";
            Load += emailForm_Load;
            ((System.ComponentModel.ISupportInitialize)exitPicBox).EndInit();
            sendEmailGroupBox.ResumeLayout(false);
            sendEmailGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox exitPicBox;
        private GroupBox sendEmailGroupBox;
        private Button sendEmailButton;
        private TextBox emailAddressToTextBox;
        private Label emailAddressToLabel;
        private TextBox emailAddressFromPassword;
        private Label emailAddressPasswordLabel;
        private TextBox emailFromTextBox;
        private Label fromEmailLabel;
        private TextBox emailBodyTextBox;
        private Label emailBodyLabel;
        private Button clearButton;
        private TextBox emailSubjectTextBox;
        private Label emailSubjectLabel;
    }
}