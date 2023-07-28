namespace OrderingSystemAI
{
    partial class StartOrdering
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartOrdering));
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            splitter2 = new Splitter();
            splitter1 = new Splitter();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(503, 154);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(175, 119);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(454, 47);
            label2.Name = "label2";
            label2.Size = new Size(294, 25);
            label2.TabIndex = 11;
            label2.Text = "SAY \"Start Odering\" TO START";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(37, 386);
            label1.Name = "label1";
            label1.Size = new Size(187, 25);
            label1.TabIndex = 12;
            label1.Text = "START ORDERING";
            // 
            // splitter2
            // 
            splitter2.BackColor = SystemColors.ButtonFace;
            splitter2.Location = new Point(3, 0);
            splitter2.Margin = new Padding(3, 4, 3, 4);
            splitter2.Name = "splitter2";
            splitter2.Size = new Size(252, 450);
            splitter2.TabIndex = 10;
            splitter2.TabStop = false;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Margin = new Padding(3, 4, 3, 4);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 450);
            splitter1.TabIndex = 9;
            splitter1.TabStop = false;
            // 
            // StartOrdering
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(splitter2);
            Controls.Add(splitter1);
            Name = "StartOrdering";
            Text = "StartOrdering";
            Load += StartOrdering_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label2;
        private Label label1;
        private Splitter splitter2;
        private Splitter splitter1;
    }
}