using DedaMrazovaRadionica.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DedaMrazovaRadionica.Presentation
{
    public partial class Home : UserControl
    {
        private readonly IDataLayer _dataLayer;
        public Home(IDataLayer dataLayer)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            _dataLayer = dataLayer;
            var session = _dataLayer.OpenSession();
            session.Close();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
