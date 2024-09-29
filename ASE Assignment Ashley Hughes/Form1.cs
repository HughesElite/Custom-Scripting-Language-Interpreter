using System.Diagnostics;
using BOOSE;




namespace ASE_Assignment_Ashley_Hughes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Debug.WriteLine(AboutBOOSE.about());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
