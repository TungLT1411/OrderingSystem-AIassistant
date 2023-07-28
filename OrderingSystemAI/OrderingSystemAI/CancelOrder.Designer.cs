namespace OrderingSystemAI
{
    partial class CancelOrder
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            lblFood = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(100, 129);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(211, 198);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(331, 112);
            label1.Name = "label1";
            label1.Size = new Size(322, 38);
            label1.TabIndex = 1;
            label1.Text = "Do you want to Cancel ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.MenuHighlight;
            label2.Location = new Point(371, 326);
            label2.Name = "label2";
            label2.Size = new Size(232, 38);
            label2.TabIndex = 2;
            label2.Text = "YES      or      NO";
            // 
            // lblFood
            // 
            lblFood.AutoSize = true;
            lblFood.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblFood.ForeColor = Color.MidnightBlue;
            lblFood.Location = new Point(433, 191);
            lblFood.Name = "lblFood";
            lblFood.Size = new Size(100, 38);
            lblFood.TabIndex = 3;
            lblFood.Text = "label3";
            // 
            // CancelOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblFood);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "CancelOrder";
            Text = "CancelOrder";
            Load += CancelOrder_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label lblFood;
    }
}