using System.Diagnostics;
using System.IO;
using BOOSE;

namespace ASE_Assignment_Ashley_Hughes
{
    /// <summary>
    /// Represents the main windows form for the BOOSE Interpreter.
    /// Handles the graphical user interface and program execution.
    /// </summary>
    public partial class BooseForm : Form
    {
        /// <summary>
        /// The canvas used for drawing graphics.
        /// </summary>
        ICanvas myCanvas;

        CommandFactory Factory;
        StoredProgram Program;
        Parser Parser;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooseForm"/> class.
        /// </summary>
        public BooseForm()
        {
            InitializeComponent();
            Debug.WriteLine(AboutBOOSE.about());

            myCanvas = new AppCanvas();

            // Set the static canvas for AppWrite
            AppWrite.SetCanvas(myCanvas);
            Factory = new AppCommandFactory();
            Program = new AppStoredProgram(myCanvas);
            Parser = new AppParser(Factory, Program);
        }

        /// <summary>
        /// Loads the form and initializes the AboutBooseBox window with information about the BOOSE language.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            AboutBooseBox.Text = AboutBOOSE.about();
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
        /// Clears all content from the program and output window.
        /// </summary>
        private void ClearAll()
        {
            ProgramWindow.Text = string.Empty;
            AboutBooseBox.Text = string.Empty;
        }

        /// <summary>
        /// Clears all content from only the error output window.
        /// </summary>
        private void ClearAboutBooseBox()
        {
            AboutBooseBox.Text = string.Empty;
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

                BooleanPatch.Apply();
                myCanvas.Clear();
                ClearAboutBooseBox();
                myCanvas.PenColour = Color.Black;
                string programText = ProgramWindow.Text;

                // Resets the program state before running new code
                Program = new AppStoredProgram(myCanvas);
                Parser = new AppParser(Factory, Program);

                // Continues with the rest of the program
                Parser.ParseProgram(programText);
                Program.Run();

                Refresh();
            }
            catch (CanvasException ex)
            {
                ((AppCanvas)myCanvas).DisplayErrorOnCanvas(ex.Message);
                Refresh();
            }

            catch (BOOSEException ex)
            {
                ((AppCanvas)myCanvas).DisplayErrorOnCanvas(ex.Message);
                Refresh();
            }
            catch (Exception ex)
            {
                myCanvas.Clear();
                Refresh();
                ((AppCanvas)myCanvas).DisplayErrorOnCanvas(ex.Message);
                Refresh();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string imagePath = @"C:\Users\G16\source\repos\ase-boose-assignment-HughesElite\ASE Assignment Ashley Hughes\icons\doga.png";

            try
            {
                // Check if the file exists
                if (!File.Exists(imagePath))
                {
                    MessageBox.Show("Image file not found.");
                    return;
                }

                // Load the image
                Bitmap customImage = new Bitmap(imagePath);

                // Clear the canvas first
                myCanvas.Clear();

                // Draw the image
                ((AppCanvas)myCanvas).DrawBitmap(customImage);

                // Refresh the form to show the new image
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }
        }
    }
}
