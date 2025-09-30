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
            btnRadionica = new Button();
            btnTovar = new Button();
            btnPokloni = new Button();
            btnRadnici = new Button();
            btnDeca = new Button();
            panelContent = new Panel();
            pnlContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.Maroon;
            pnlContent.Controls.Add(btnRadionica);
            pnlContent.Controls.Add(btnTovar);
            pnlContent.Controls.Add(btnPokloni);
            pnlContent.Controls.Add(btnRadnici);
            pnlContent.Controls.Add(btnDeca);
            pnlContent.Dock = DockStyle.Left;
            pnlContent.Location = new Point(0, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(202, 580);
            pnlContent.TabIndex = 5;
            // 
            // btnRadionica
            // 
            btnRadionica.Location = new Point(0, 240);
            btnRadionica.Name = "btnRadionica";
            btnRadionica.Size = new Size(201, 54);
            btnRadionica.TabIndex = 4;
            btnRadionica.Text = "Deo radionice";
            btnRadionica.UseVisualStyleBackColor = true;
            // 
            // btnTovar
            // 
            btnTovar.Location = new Point(0, 180);
            btnTovar.Name = "btnTovar";
            btnTovar.Size = new Size(201, 54);
            btnTovar.TabIndex = 3;
            btnTovar.Text = "Tovar/Irvasi";
            btnTovar.UseVisualStyleBackColor = true;
            // 
            // btnPokloni
            // 
            btnPokloni.Location = new Point(0, 120);
            btnPokloni.Name = "btnPokloni";
            btnPokloni.Size = new Size(201, 54);
            btnPokloni.TabIndex = 2;
            btnPokloni.Text = "Pokloni";
            btnPokloni.UseVisualStyleBackColor = true;
            // 
            // btnRadnici
            // 
            btnRadnici.Location = new Point(0, 60);
            btnRadnici.Name = "btnRadnici";
            btnRadnici.Size = new Size(201, 54);
            btnRadnici.TabIndex = 1;
            btnRadnici.Text = "Radnici";
            btnRadnici.UseVisualStyleBackColor = true;
            btnRadnici.Click += button1_Click;
            // 
            // btnDeca
            // 
            btnDeca.Location = new Point(0, 0);
            btnDeca.Name = "btnDeca";
            btnDeca.Size = new Size(201, 54);
            btnDeca.TabIndex = 0;
            btnDeca.Text = "Deca";
            btnDeca.UseVisualStyleBackColor = true;
            btnDeca.Click += btnDeca_Click;
            // 
            // panelContent
            // 
            panelContent.Location = new Point(207, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(730, 580);
            panelContent.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 580);
            Controls.Add(panelContent);
            Controls.Add(pnlContent);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            pnlContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContent;
        private Label lblNaslov;
        private Button btnRadnici;
        private Button btnDeca;
        private Button btnTovar;
        private Button btnPokloni;
        private Button btnRadionica;
        private Panel panelContent;
    }
}
