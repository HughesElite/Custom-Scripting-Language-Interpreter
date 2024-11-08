namespace ASE_Assignment_Ashley_Hughes
{
    partial class BooseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BooseForm));
            ProgramWindow = new TextBox();
            RunButton = new Button();
            PictureWindow = new PictureBox();
            ClearButton = new Button();
            ProgramWindowLabel = new Label();
            OutputWindowLabel = new Label();
            AboutBooseBox = new TextBox();
            BeerImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)PictureWindow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BeerImage).BeginInit();
            SuspendLayout();
            // 
            // ProgramWindow
            // 
            ProgramWindow.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ProgramWindow.Location = new Point(44, 76);
            ProgramWindow.Multiline = true;
            ProgramWindow.Name = "ProgramWindow";
            ProgramWindow.Size = new Size(548, 365);
            ProgramWindow.TabIndex = 0;
            // 
            // RunButton
            // 
            RunButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            RunButton.Location = new Point(44, 491);
            RunButton.Name = "RunButton";
            RunButton.Size = new Size(104, 37);
            RunButton.TabIndex = 1;
            RunButton.Text = "Run";
            RunButton.UseVisualStyleBackColor = true;
            RunButton.Click += RunButton_Click;
            // 
            // PictureWindow
            // 
            PictureWindow.BackColor = SystemColors.Window;
            PictureWindow.Location = new Point(712, 76);
            PictureWindow.Name = "PictureWindow";
            PictureWindow.Size = new Size(548, 365);
            PictureWindow.TabIndex = 2;
            PictureWindow.TabStop = false;
            PictureWindow.Paint += PictureBox_Paint;
            // 
            // ClearButton
            // 
            ClearButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ClearButton.ForeColor = SystemColors.ControlText;
            ClearButton.Location = new Point(163, 491);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(104, 37);
            ClearButton.TabIndex = 5;
            ClearButton.Text = "Clear All";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // ProgramWindowLabel
            // 
            ProgramWindowLabel.AutoSize = true;
            ProgramWindowLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            ProgramWindowLabel.ForeColor = Color.YellowGreen;
            ProgramWindowLabel.Location = new Point(44, 23);
            ProgramWindowLabel.Name = "ProgramWindowLabel";
            ProgramWindowLabel.Size = new Size(198, 32);
            ProgramWindowLabel.TabIndex = 6;
            ProgramWindowLabel.Text = "Program Window";
            // 
            // OutputWindowLabel
            // 
            OutputWindowLabel.AutoSize = true;
            OutputWindowLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            OutputWindowLabel.ForeColor = Color.YellowGreen;
            OutputWindowLabel.Location = new Point(712, 23);
            OutputWindowLabel.Name = "OutputWindowLabel";
            OutputWindowLabel.Size = new Size(184, 32);
            OutputWindowLabel.TabIndex = 7;
            OutputWindowLabel.Text = "Output Window";
            // 
            // AboutBooseBox
            // 
            AboutBooseBox.BackColor = Color.SeaGreen;
            AboutBooseBox.BorderStyle = BorderStyle.None;
            AboutBooseBox.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            AboutBooseBox.ForeColor = Color.YellowGreen;
            AboutBooseBox.Location = new Point(712, 447);
            AboutBooseBox.Multiline = true;
            AboutBooseBox.Name = "AboutBooseBox";
            AboutBooseBox.Size = new Size(297, 159);
            AboutBooseBox.TabIndex = 8;
            // 
            // BeerImage
            // 
            BeerImage.Image = (Image)resources.GetObject("BeerImage.Image");
            BeerImage.Location = new Point(1044, 447);
            BeerImage.Name = "BeerImage";
            BeerImage.Size = new Size(216, 166);
            BeerImage.TabIndex = 9;
            BeerImage.TabStop = false;
            // 
            // BooseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SeaGreen;
            ClientSize = new Size(1303, 635);
            Controls.Add(BeerImage);
            Controls.Add(AboutBooseBox);
            Controls.Add(OutputWindowLabel);
            Controls.Add(ProgramWindowLabel);
            Controls.Add(ClearButton);
            Controls.Add(PictureWindow);
            Controls.Add(RunButton);
            Controls.Add(ProgramWindow);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "BooseForm";
            Text = "Ashley's BOOSE Interpreter";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)PictureWindow).EndInit();
            ((System.ComponentModel.ISupportInitialize)BeerImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ProgramWindow;
        private Button RunButton;
        private PictureBox PictureWindow;
        private Button ClearButton;
        private Label ProgramWindowLabel;
        private Label OutputWindowLabel;
        private TextBox AboutBooseBox;
        private PictureBox BeerImage;
    }
}
