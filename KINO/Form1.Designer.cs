namespace KINO
{
    partial class Form1
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
            btnRefill = new Button();
            txtInfo = new RichTextBox();
            txtOut = new RichTextBox();
            btnGet = new Button();
            KinoBar = new ProgressBar();
            kinoBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)kinoBox).BeginInit();
            SuspendLayout();
            // 
            // btnRefill
            // 
            btnRefill.Location = new Point(120, 53);
            btnRefill.Name = "btnRefill";
            btnRefill.Size = new Size(407, 33);
            btnRefill.TabIndex = 0;
            btnRefill.Text = "Заполняем";
            btnRefill.UseVisualStyleBackColor = true;
            btnRefill.Click += btnRefill_Click;
            // 
            // txtInfo
            // 
            txtInfo.BorderStyle = BorderStyle.None;
            txtInfo.Location = new Point(120, 118);
            txtInfo.Name = "txtInfo";
            txtInfo.ReadOnly = true;
            txtInfo.Size = new Size(404, 85);
            txtInfo.TabIndex = 1;
            txtInfo.Text = "";
            // 
            // txtOut
            // 
            txtOut.Location = new Point(120, 260);
            txtOut.Name = "txtOut";
            txtOut.ReadOnly = true;
            txtOut.Size = new Size(250, 144);
            txtOut.TabIndex = 2;
            txtOut.Text = "";
            // 
            // btnGet
            // 
            btnGet.Location = new Point(391, 260);
            btnGet.Name = "btnGet";
            btnGet.Size = new Size(144, 143);
            btnGet.TabIndex = 3;
            btnGet.Text = "Забираем";
            btnGet.UseVisualStyleBackColor = true;
            btnGet.Click += btnGet_Click;
            // 
            // KinoBar
            // 
            KinoBar.Location = new Point(120, 197);
            KinoBar.Name = "KinoBar";
            KinoBar.Size = new Size(404, 33);
            KinoBar.TabIndex = 4;
            // 
            // kinoBox
            // 
            kinoBox.Location = new Point(616, 55);
            kinoBox.Name = "kinoBox";
            kinoBox.Size = new Size(380, 348);
            kinoBox.SizeMode = PictureBoxSizeMode.StretchImage;
            kinoBox.TabIndex = 5;
            kinoBox.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1061, 450);
            Controls.Add(kinoBox);
            Controls.Add(KinoBar);
            Controls.Add(btnGet);
            Controls.Add(txtOut);
            Controls.Add(txtInfo);
            Controls.Add(btnRefill);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)kinoBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnRefill;
        private RichTextBox txtInfo;
        private RichTextBox txtOut;
        private Button btnGet;
        private ProgressBar KinoBar;
        private PictureBox kinoBox;
    }
}
