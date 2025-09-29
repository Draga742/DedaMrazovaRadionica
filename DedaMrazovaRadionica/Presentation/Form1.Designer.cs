namespace DedaMrazovaRadionica
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
            pnlContent = new Panel();
            btnDeca = new Button();
            pnlContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(btnDeca);
            pnlContent.Location = new Point(54, 45);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(561, 393);
            pnlContent.TabIndex = 0;
            // 
            // btnDeca
            // 
            btnDeca.Location = new Point(62, 91);
            btnDeca.Name = "btnDeca";
            btnDeca.Size = new Size(94, 29);
            btnDeca.TabIndex = 0;
            btnDeca.Text = "Deca";
            btnDeca.UseVisualStyleBackColor = true;
            btnDeca.Click += btnDeca_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlContent);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            pnlContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContent;
        private Button btnDeca;
    }
}
