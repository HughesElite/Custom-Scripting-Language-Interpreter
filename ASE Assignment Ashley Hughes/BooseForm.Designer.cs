namespace ASE_Assignment_Ashley_Hughes
{
    partial class booseForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(booseForm));
            ProgramWindow = new TextBox();
            RunButton = new Button();
            PictureWindow = new PictureBox();
            ClearButton = new Button();
            ErrorOutputWindow = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)PictureWindow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // ProgramWindow
            // 
            ProgramWindow.Location = new Point(25, 28);
            ProgramWindow.Multiline = true;
            ProgramWindow.Name = "ProgramWindow";
            ProgramWindow.Size = new Size(400, 365);
            ProgramWindow.TabIndex = 0;
            // 
            // RunButton
            // 
            RunButton.Location = new Point(25, 408);
            RunButton.Name = "RunButton";
            RunButton.Size = new Size(87, 30);
            RunButton.TabIndex = 1;
            RunButton.Text = "Run";
            RunButton.UseVisualStyleBackColor = true;
            RunButton.Click += RunButton_Click;
            // 
            // PictureWindow
            // 
            PictureWindow.BackColor = SystemColors.Window;
            PictureWindow.Location = new Point(592, 28);
            PictureWindow.Name = "PictureWindow";
            PictureWindow.Size = new Size(400, 365);
            PictureWindow.TabIndex = 2;
            PictureWindow.TabStop = false;
            PictureWindow.Paint += PictureBox_Paint;
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(25, 447);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(87, 28);
            ClearButton.TabIndex = 5;
            ClearButton.Text = "Clear All";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // ErrorOutputWindow
            // 
            ErrorOutputWindow.Location = new Point(118, 408);
            ErrorOutputWindow.Multiline = true;
            ErrorOutputWindow.Name = "ErrorOutputWindow";
            ErrorOutputWindow.ScrollBars = ScrollBars.Vertical;
            ErrorOutputWindow.Size = new Size(307, 200);
            ErrorOutputWindow.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.SeaGreen;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(665, 408);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(259, 200);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // booseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SeaGreen;
            ClientSize = new Size(1022, 635);
            Controls.Add(pictureBox1);
            Controls.Add(ErrorOutputWindow);
            Controls.Add(ClearButton);
            Controls.Add(PictureWindow);
            Controls.Add(RunButton);
            Controls.Add(ProgramWindow);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "booseForm";
            Text = "Ashley's BOOSE Interpreter";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)PictureWindow).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ProgramWindow;
        private Button RunButton;
        private PictureBox PictureWindow;
        private Button ClearButton;
        private TextBox ErrorOutputWindow;
        private PictureBox pictureBox1;
    }
}
