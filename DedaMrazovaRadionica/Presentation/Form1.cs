using DedaMrazovaRadionica.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Media;
using DedaMrazovaRadionica.Presentation;
using DedaMrazovaRadionica.Presentation.Deca;

namespace DedaMrazovaRadionica
{
    public partial class Form1 : Form
    {
        private readonly IServiceProvider _serviceProvider;

        private Button? _activeButton;
        private readonly Color _activeColor = Color.LightBlue;
        private readonly Color _defaultColor = SystemColors.Control;
        public Form1(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            var control = _serviceProvider.GetRequiredService<Home>();
            LoadControl(control);
        }

        private void LoadControl(UserControl control)
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(control);
        }

        private void SetActiveButton(Button clickedButton)
        {
            if (_activeButton != null)
                _activeButton.BackColor = _defaultColor;

            _activeButton = clickedButton;
            _activeButton.BackColor = _activeColor;
        }

        private void btnDeca_Click(object sender, EventArgs e)
        {
            SetActiveButton((Button)sender);  
            var control = _serviceProvider.GetRequiredService<DecaUC>();
            LoadControl(control);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
