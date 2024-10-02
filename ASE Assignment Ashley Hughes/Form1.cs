using System.Diagnostics;
using BOOSE;




namespace ASE_Assignment_Ashley_Hughes
{
    public partial class booseForm : Form
    {
        public booseForm()
        {
            InitializeComponent();
            Debug.WriteLine(AboutBOOSE.about());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
