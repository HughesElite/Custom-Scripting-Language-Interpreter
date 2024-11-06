using System.Diagnostics;
using BOOSE;

namespace ASE_Assignment_Ashley_Hughes
{
    /// <summary>
    /// Represents the main windows form for the BOOSE Interpreter.
    /// Handles the graphical user interface and program execution.
    /// </summary>
    public partial class booseForm : Form
    {
        /// <summary>
        /// The canvas used for drawing graphics.
        /// </summary>
        ICanvas myCanvas;

        CommandFactory Factory;
        StoredProgram Program;
        Parser Parser;

        /// <summary>
        /// Initializes a new instance of the <see cref="booseForm"/> class.
        /// </summary>
        public booseForm()
        {
            InitializeComponent();
            Debug.WriteLine(AboutBOOSE.about());
            myCanvas = new AppCanvas();
            Factory = new CommandFactory();
            Program = new StoredProgram(myCanvas);
            Parser = new Parser(Factory, Program);
        }

        /// <summary>
        /// Loads the form and initializes the error output window with information about the BOOSE language.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            ErrorOutputWindow.Text = AboutBOOSE.about();
        }

        /// <summary>
        /// Paints the graphics on the PictureBox using the current bitmap from the canvas.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Bitmap b = (Bitmap)myCanvas.getBitmap();
            g.DrawImageUnscaled(b, 0, 0);

        }

        /// <summary>
        /// Clears all content from the program and error output windows.
        /// </summary>
        private void ClearAll()
        {
            ProgramWindow.Text = string.Empty;
            ErrorOutputWindow.Text = string.Empty;

        }

        /// <summary>
        /// Clears all content from only the error output window.
        /// </summary>
        private void ClearErrorOutputWindow()
        {

            ErrorOutputWindow.Text = string.Empty;

        }

        /// <summary>
        /// Executes the program when the Run button is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void RunButton_Click(object sender, EventArgs e)
        {
            try
            {
                myCanvas.Clear();
                ClearErrorOutputWindow();

                string programText = ProgramWindow.Text;

                // Split program into lines
                string[] lines = programText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                // Loop through lines containing "write"
                foreach (var line in lines.Where(l => l.ToLower().Contains("write")))
                {

                    if (line.ToLower().Contains("write"))
                    {
                        string cleanedLine = line.Replace("write", "").Replace("\"", "").Trim(); // trims the word 'write' and quotation marks before drawing
                        ((AppCanvas)myCanvas).WriteText(cleanedLine);  // Draw each line with "write"
                    }
                }
                // Continue with the rest of the program
                Parser.ParseProgram(programText);
                Program.Run();
                Refresh();
                ErrorOutputWindow.Text = "No Errors";
            }
            catch (Exception ex)
            {
                myCanvas.Clear();
                Refresh();
                ErrorOutputWindow.Text = "Error: " + ex.Message + Environment.NewLine;
            }
        }

        /// <summary>
        /// Clears the Picture, ErrorOutput and Program Windows when Clear All button is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            myCanvas.Clear();
            ClearAll();
            myCanvas.PenColour = Color.Black;
            Refresh();
        }
    }
}
