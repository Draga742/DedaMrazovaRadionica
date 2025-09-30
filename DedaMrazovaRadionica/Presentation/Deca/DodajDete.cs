using DedaMrazovaRadionica.App.DTOs;
using DedaMrazovaRadionica.App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DedaMrazovaRadionica.Presentation.Deca
{
    public partial class DodajDete : Form
    {
        private readonly IDeteService _deteService;
        public DodajDete(IDeteService deteService)
        {
            InitializeComponent();
            _deteService = deteService;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DodajDete_Load(object sender, EventArgs e)
        {

        }

        private void btnDodajDete_Click(object sender, EventArgs e)
        {
            string ime = txtIme.Text.Trim();
            string prezime = txtPrezime.Text.Trim();
            DateTime datumRodjenja = dtpRodjendan.Value;
            string drzava = txtDrzava.Text.Trim();
            string grad = txtGrad.Text.Trim();
            string ulica = txtUlica.Text.Trim();
            int broj = (int)numBroj.Value;
            string imeOca = txtImeoca.Text.Trim();
            string imeMajke = txtImemajke.Text.Trim();

            DeteDTO newDete = new DeteDTO
            {
                Ime = ime,
                Prezime = prezime,
                DatumRodjenja = datumRodjenja,
                Drzava = drzava,
                Grad = grad,
                Ulica = ulica,
                Broj = broj,
                ImeOca = imeOca,
                ImeMajke = imeMajke
            };

            var result = _deteService.Add(newDete);

            if(result.IsSuccess)
            {
                MessageBox.Show("Dete je uspesno dodato!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Greska prilikom dodavanja deteta!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
