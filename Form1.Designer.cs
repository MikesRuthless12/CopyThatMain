namespace Havoc__Copy_That
{
    partial class Form1
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
            timer1 = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            listBox1 = new ListBox();
            openFileDialog1 = new OpenFileDialog();
            treeView1 = new TreeView();
            loadDirButton = new Button();
            selectDirLabel = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            dirTextBox = new TextBox();
            browseButton = new Button();
            dirProgressBar = new ProgressBar();
            folderBrowserDialog1 = new FolderBrowserDialog();
            toolTip1 = new ToolTip(components);
            label1 = new Label();
            timer2 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Interval = 500;
            timer1.Tick += timer1_Tick;
            // 
            // button1
            // 
            button1.Location = new Point(84, 117);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(99, 483);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(99, 706);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 3;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(286, 43);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(180, 129);
            listBox1.TabIndex = 4;
            listBox1.MouseClick += listBox1_MouseClick;
            listBox1.DragDrop += listBox1_DragDrop_1;
            listBox1.DragEnter += listBox1_DragEnter_1;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // treeView1
            // 
            treeView1.Location = new Point(295, 232);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(791, 455);
            treeView1.TabIndex = 5;
            // 
            // loadDirButton
            // 
            loadDirButton.Location = new Point(974, 693);
            loadDirButton.Name = "loadDirButton";
            loadDirButton.Size = new Size(112, 34);
            loadDirButton.TabIndex = 6;
            loadDirButton.Text = "Load Directory";
            loadDirButton.UseVisualStyleBackColor = true;
            loadDirButton.Click += button4_Click;
            // 
            // selectDirLabel
            // 
            selectDirLabel.AutoSize = true;
            selectDirLabel.Location = new Point(295, 192);
            selectDirLabel.Name = "selectDirLabel";
            selectDirLabel.Size = new Size(139, 25);
            selectDirLabel.TabIndex = 7;
            selectDirLabel.Text = "Select Directory:";
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // dirTextBox
            // 
            dirTextBox.Location = new Point(436, 192);
            dirTextBox.Name = "dirTextBox";
            dirTextBox.Size = new Size(548, 31);
            dirTextBox.TabIndex = 8;
            // 
            // browseButton
            // 
            browseButton.Location = new Point(990, 192);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(96, 34);
            browseButton.TabIndex = 9;
            browseButton.Text = "...";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
            // 
            // dirProgressBar
            // 
            dirProgressBar.Location = new Point(295, 693);
            dirProgressBar.Name = "dirProgressBar";
            dirProgressBar.Size = new Size(673, 34);
            dirProgressBar.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(295, 751);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 11;
            label1.Text = "label1";
            // 
            // timer2
            // 
            timer2.Interval = 4000;
            timer2.Tick += timer2_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1239, 941);
            Controls.Add(label1);
            Controls.Add(dirProgressBar);
            Controls.Add(browseButton);
            Controls.Add(dirTextBox);
            Controls.Add(selectDirLabel);
            Controls.Add(loadDirButton);
            Controls.Add(treeView1);
            Controls.Add(listBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Paint += Form1_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Button button1;
        private Button button2;
        private Button button3;
        private ListBox listBox1;
        private OpenFileDialog openFileDialog1;
        private TreeView treeView1;
        private Button loadDirButton;
        private Label selectDirLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox dirTextBox;
        private Button browseButton;
        private ProgressBar dirProgressBar;
        private FolderBrowserDialog folderBrowserDialog1;
        private ToolTip toolTip1;
        private Label label1;
        private System.Windows.Forms.Timer timer2;
    }
}