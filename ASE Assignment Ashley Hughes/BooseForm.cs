using System.Diagnostics;
using BOOSE;




namespace ASE_Assignment_Ashley_Hughes
{
  
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
            Factory = new AppCommandFactory();
            Program = new StoredProgram(myCanvas);
            Parser = new Parser(Factory, Program);




        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ErrorOutputWindow.Text = AboutBOOSE.about();
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Bitmap b = (Bitmap)myCanvas.getBitmap();
            g.DrawImageUnscaled(b, 0, 0);

        }

     

        private void ClearAll()
        {
            ProgramWindow.Text = string.Empty; 
            ErrorOutputWindow.Text = string.Empty;

        }

        private void ClearErrorOutputWindow()
        {
    
            ErrorOutputWindow.Text = string.Empty;

        }
        private void RunButton_Click(object sender, EventArgs e)
        {
            try
            {
                myCanvas.Clear();
                ClearErrorOutputWindow();
                String ProgramText = ProgramWindow.Text;
                Parser.ParseProgram(ProgramText);

                
                ((AppCanvas)myCanvas).WriteText(ProgramText);

                Program.Run();
                Refresh();
              
            }
            catch (CanvasException ex) 
            {
                myCanvas.Clear();
                Refresh();
                ErrorOutputWindow.Text = "Canvas Error: " + ex.Message;
            }
            catch (Exception ex)
            {
                myCanvas.Clear();
                Refresh();
                ErrorOutputWindow.Text += "Error: " + ex.Message + Environment.NewLine;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            myCanvas.Clear();
            ClearAll();
            myCanvas.PenColour = Color.Black;
            Refresh();
        }
    }
}
