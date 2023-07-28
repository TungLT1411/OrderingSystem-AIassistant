namespace OrderingSystemAI
{
    partial class AskContinue
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
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            textBox1.Location = new Point(368, 44);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(343, 149);
            textBox1.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.AppWorkspace;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(560, 320);
            label2.Name = "label2";
            label2.Size = new Size(94, 38);
            label2.TabIndex = 4;
            label2.Text = "Finish";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.AppWorkspace;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(152, 320);
            label3.Name = "label3";
            label3.Size = new Size(136, 38);
            label3.TabIndex = 5;
            label3.Text = "Continue";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(107, 218);
            label1.Name = "label1";
            label1.Size = new Size(593, 41);
            label1.TabIndex = 3;
            label1.Text = "Do you want to Finish or Continue order?";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(126, 44);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(162, 149);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // AskContinue
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "AskContinue";
            Text = "AskContinue";
            Load += AskContinue_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private Label label1;
        private PictureBox pictureBox1;
    }
}