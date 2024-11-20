namespace Havoc__Copy_That
{
    partial class havocForm
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
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            progressBar1 = new ProgressBar();
            splashLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Interval = 50;
            timer1.Tick += timer1_Tick;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(22, 395);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(398, 34);
            progressBar1.TabIndex = 1;
            // 
            // splashLabel
            // 
            splashLabel.AutoSize = true;
            splashLabel.BackColor = Color.Black;
            splashLabel.ForeColor = Color.White;
            splashLabel.Location = new Point(22, 367);
            splashLabel.Name = "splashLabel";
            splashLabel.Size = new Size(103, 25);
            splashLabel.TabIndex = 2;
            splashLabel.Text = "Initializing...";
            // 
            // havocForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(666, 441);
            Controls.Add(splashLabel);
            Controls.Add(progressBar1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "havocForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "'";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private ProgressBar progressBar1;
        private Label splashLabel;
    }
}