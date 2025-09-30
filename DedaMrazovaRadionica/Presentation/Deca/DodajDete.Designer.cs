namespace DedaMrazovaRadionica.Presentation.Deca
{
    partial class DodajDete
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            txtIme = new TextBox();
            txtPrezime = new TextBox();
            txtDrzava = new TextBox();
            txtGrad = new TextBox();
            txtImeoca = new TextBox();
            txtUlica = new TextBox();
            txtImemajke = new TextBox();
            numBroj = new NumericUpDown();
            dtpRodjendan = new DateTimePicker();
            btnDodajDete = new Button();
            nazadlbl = new Label();
            ((System.ComponentModel.ISupportInitialize)numBroj).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 44);
            label1.Name = "label1";
            label1.Size = new Size(37, 20);
            label1.TabIndex = 0;
            label1.Text = "Ime:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 90);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 1;
            label2.Text = "Prezime:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 130);
            label3.Name = "label3";
            label3.Size = new Size(116, 20);
            label3.TabIndex = 2;
            label3.Text = "Datum rodjenja:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 175);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 3;
            label4.Text = "Drzava:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(33, 211);
            label5.Name = "label5";
            label5.Size = new Size(44, 20);
            label5.TabIndex = 4;
            label5.Text = "Grad:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(33, 254);
            label6.Name = "label6";
            label6.Size = new Size(45, 20);
            label6.TabIndex = 5;
            label6.Text = "Ulica:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(33, 290);
            label7.Name = "label7";
            label7.Size = new Size(39, 20);
            label7.TabIndex = 6;
            label7.Text = "Broj:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(33, 326);
            label8.Name = "label8";
            label8.Size = new Size(65, 20);
            label8.TabIndex = 7;
            label8.Text = "Ime oca:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(33, 364);
            label9.Name = "label9";
            label9.Size = new Size(81, 20);
            label9.TabIndex = 8;
            label9.Text = "Ime majke:";
            // 
            // txtIme
            // 
            txtIme.Location = new Point(204, 41);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(125, 27);
            txtIme.TabIndex = 9;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(204, 87);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(125, 27);
            txtPrezime.TabIndex = 10;
            // 
            // txtDrzava
            // 
            txtDrzava.Location = new Point(204, 168);
            txtDrzava.Name = "txtDrzava";
            txtDrzava.Size = new Size(125, 27);
            txtDrzava.TabIndex = 11;
            // 
            // txtGrad
            // 
            txtGrad.Location = new Point(204, 204);
            txtGrad.Name = "txtGrad";
            txtGrad.Size = new Size(125, 27);
            txtGrad.TabIndex = 12;
            // 
            // txtImeoca
            // 
            txtImeoca.Location = new Point(204, 323);
            txtImeoca.Name = "txtImeoca";
            txtImeoca.Size = new Size(125, 27);
            txtImeoca.TabIndex = 13;
            // 
            // txtUlica
            // 
            txtUlica.Location = new Point(204, 251);
            txtUlica.Name = "txtUlica";
            txtUlica.Size = new Size(125, 27);
            txtUlica.TabIndex = 14;
            // 
            // txtImemajke
            // 
            txtImemajke.Location = new Point(204, 361);
            txtImemajke.Name = "txtImemajke";
            txtImemajke.Size = new Size(125, 27);
            txtImemajke.TabIndex = 15;
            // 
            // numBroj
            // 
            numBroj.Location = new Point(204, 288);
            numBroj.Name = "numBroj";
            numBroj.Size = new Size(150, 27);
            numBroj.TabIndex = 16;
            // 
            // dtpRodjendan
            // 
            dtpRodjendan.Location = new Point(205, 131);
            dtpRodjendan.Name = "dtpRodjendan";
            dtpRodjendan.Size = new Size(250, 27);
            dtpRodjendan.TabIndex = 17;
            // 
            // btnDodajDete
            // 
            btnDodajDete.Location = new Point(429, 359);
            btnDodajDete.Name = "btnDodajDete";
            btnDodajDete.Size = new Size(94, 29);
            btnDodajDete.TabIndex = 18;
            btnDodajDete.Text = "Dodaj Dete";
            btnDodajDete.UseVisualStyleBackColor = true;
            btnDodajDete.Click += btnDodajDete_Click;
            // 
            // nazadlbl
            // 
            nazadlbl.AutoSize = true;
            nazadlbl.Location = new Point(535, 27);
            nazadlbl.Name = "nazadlbl";
            nazadlbl.Size = new Size(18, 20);
            nazadlbl.TabIndex = 19;
            nazadlbl.Text = "X";
            // 
            // DodajDete
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(nazadlbl);
            Controls.Add(btnDodajDete);
            Controls.Add(dtpRodjendan);
            Controls.Add(numBroj);
            Controls.Add(txtImemajke);
            Controls.Add(txtUlica);
            Controls.Add(txtImeoca);
            Controls.Add(txtGrad);
            Controls.Add(txtDrzava);
            Controls.Add(txtPrezime);
            Controls.Add(txtIme);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DodajDete";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DodajDete";
            Load += DodajDete_Load;
            ((System.ComponentModel.ISupportInitialize)numBroj).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox txtIme;
        private TextBox txtPrezime;
        private TextBox txtDrzava;
        private TextBox txtGrad;
        private TextBox txtImeoca;
        private TextBox txtUlica;
        private TextBox txtImemajke;
        private NumericUpDown numBroj;
        private DateTimePicker dtpRodjendan;
        private Button btnDodajDete;
        private Label nazadlbl;
    }
}