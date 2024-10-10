using System.Diagnostics;
using BOOSE;




namespace ASE_Assignment_Ashley_Hughes
{
    /// <summary>
    /// The main form for all the functionality of the BOOSE Interpreter.
    /// </summary>
    public partial class booseForm : Form
    {
        ICanvas myCanvas;
        CommandFactory Factory;
        StoredProgram Program;
        Parser Parser;





        public booseForm()
        {
            InitializeComponent();
            Debug.WriteLine(AboutBOOSE.about());

            myCanvas = new AppCanvas();
            myCanvas.MoveTo(100, 100);
            myCanvas.PenColour = Color.Red;
            myCanvas.DrawTo(200, 200);
            myCanvas.Circle(50, false);
            Refresh();

            Factory = new CommandFactory();
            Program = new StoredProgram(myCanvas);
            Parser = new Parser(Factory, Program);




        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Bitmap b = (Bitmap)myCanvas.getBitmap();
            g.DrawImageUnscaled(b, 0, 0);
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            String syntaxErrorList = "";
            String runtimeErrorList = "";
            String ProgramText = ProgramWindow.Text;

            Parser.ParseProgram(ProgramText);


        }
    }
}
