using System.Diagnostics;
using BOOSE;




namespace ASE_Assignment_Ashley_Hughes
{
    /// <summary>
    /// The main form for all the functionality of the BOOSE Interpreter.
    /// </summary>
    public partial class booseForm : Form
    {

        public booseForm()
        {
            InitializeComponent();

            Bitmap myBitmap = new Bitmap(400, 365);
            outputPictureBox.Image = myBitmap;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
