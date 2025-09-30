namespace DedaMrazovaRadionica.Presentation.Deca
{
    partial class DecaUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lvDeca = new ListView();
            btnDodajDete = new Button();
            SuspendLayout();
            // 
            // lvDeca
            // 
            lvDeca.Location = new Point(3, 3);
            lvDeca.Name = "lvDeca";
            lvDeca.Size = new Size(619, 492);
            lvDeca.TabIndex = 0;
            lvDeca.UseCompatibleStateImageBehavior = false;
            lvDeca.View = View.Details;
            // 
            // btnDodajDete
            // 
            btnDodajDete.Location = new Point(658, 73);
            btnDodajDete.Name = "btnDodajDete";
            btnDodajDete.Size = new Size(94, 29);
            btnDodajDete.TabIndex = 1;
            btnDodajDete.Text = "Dodaj dete";
            btnDodajDete.UseVisualStyleBackColor = true;
            btnDodajDete.Click += btnDodajDete_Click;
            // 
            // DecaUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnDodajDete);
            Controls.Add(lvDeca);
            Name = "DecaUC";
            Size = new Size(788, 498);
            Load += DecaUC_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView lvDeca;
        private Button btnDodajDete;
    }
}
