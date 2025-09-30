using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DedaMrazovaRadionica.App.Services.Interfaces;
using DedaMrazovaRadionica.App.Services.Implementation;
using DedaMrazovaRadionica.App.DTOs;
using Microsoft.Extensions.DependencyInjection;

namespace DedaMrazovaRadionica.Presentation.Deca
{
    public partial class DecaUC : UserControl
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IDeteService _deteService;
        private IList<DeteDTO> _deca = [];
        public DecaUC(IServiceProvider serviceProvider, IDeteService deteService)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            _deteService = deteService;
            _serviceProvider = serviceProvider;

            //Define columns for ListView:
            lvDeca.Columns.Add("Ime");
            lvDeca.Columns.Add("Prezime");
            lvDeca.Columns.Add("Datum rodjenja");
            lvDeca.Columns.Add("Drzava");
            lvDeca.Columns.Add("Grad");
            lvDeca.Columns.Add("Ulica");
            lvDeca.Columns.Add("Broj");
            lvDeca.Columns.Add("Ime oca");
            lvDeca.Columns.Add("Ime majke");

            LoadData();
        }

        private void LoadData()
        {
            var result = _deteService.GetAll();
            if (result.IsSuccess)
            {
                _deca = result.Data!;
                InsertDataIntoListView();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Greska prilikom ucitavanja podataka!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertDataIntoListView()
        {
            lvDeca.Items.Clear();
            foreach (var dete in _deca)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    dete.Ime,
                    dete.Prezime,
                    dete.DatumRodjenja.ToShortDateString(),
                    dete.Drzava,
                    dete.Grad,
                    dete.Ulica,
                    dete.Broj.ToString(),
                    dete.ImeOca,
                    dete.ImeMajke
                });
                lvDeca.Items.Add(item);
            }

            foreach (ColumnHeader column in lvDeca.Columns)
            {
                column.Width = -2;
            }
            lvDeca.Refresh();
        }

        private void DecaUC_Load(object sender, EventArgs e)
        {

        }

        private void btnDodajDete_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<DodajDete>();
            DialogResult dialogResult = form.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                LoadData();
            }
        }
    }
}
