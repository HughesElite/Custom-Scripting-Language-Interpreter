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
        CommandFactory Factory; // design pattern, a good way of creating classes, a factory which makes commands 
        StoredProgram Program; // if parser can create the commands this is where it stores them
        Parser Parser; // reads the text of the program and tries to make commands out of them, if it can it stores them in stored program and runs it

        public booseForm()
        {
            InitializeComponent();
            Debug.WriteLine(AboutBOOSE.about());
            myCanvas = new AppCanvas();



            Factory = new CommandFactory();
            Program = new StoredProgram(myCanvas);
            Parser = new Parser(Factory, Program);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Bitmap b = (Bitmap)myCanvas.getBitmap();
            g.DrawImageUnscaled(b, 0, 0);

        }
        private void DisplayError(string message)
        {
            // Check if the errorListBox is not null
            if (ErrorWindow != null)
            {
                // Add the new error message to the ListBox
                ErrorWindow.Items.Add(message);

                // Optionally scroll to the last item
                ErrorWindow.SelectedIndex = ErrorWindow.Items.Count - 1; // Select the last item
                ErrorWindow.TopIndex = ErrorWindow.Items.Count - 1; // Scroll to the last item
            }
        }

        private void ClearTextBox()
        {
            ProgramWindow.Text = string.Empty; // Clears the text box

        }
        private void RunButton_Click(object sender, EventArgs e)
        {
            try
            {
                myCanvas.Clear();
                String ProgramText = ProgramWindow.Text;
                Parser.ParseProgram(ProgramText);
                Program.Run();
                Refresh();
                Debug.WriteLine(" ** All inputs are currently valid ** ");
            }
            catch (Exception ex)
            {
                myCanvas.Clear();
                Refresh();
                DisplayError("Error: " + ex.Message);

            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            myCanvas.Clear();
            ClearTextBox();
            myCanvas.PenColour = Color.Black;
            Refresh();
        }
    }
}
