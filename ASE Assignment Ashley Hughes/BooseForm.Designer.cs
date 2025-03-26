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
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)PictureWindow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BeerImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // ProgramWindow
            // 
            ProgramWindow.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ProgramWindow.Location = new Point(50, 101);
            ProgramWindow.Margin = new Padding(3, 4, 3, 4);
            ProgramWindow.Multiline = true;
            ProgramWindow.Name = "ProgramWindow";
            ProgramWindow.Size = new Size(626, 485);
            ProgramWindow.TabIndex = 0;
            // 
            // RunButton
            // 
            RunButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            RunButton.Location = new Point(50, 655);
            RunButton.Margin = new Padding(3, 4, 3, 4);
            RunButton.Name = "RunButton";
            RunButton.Size = new Size(119, 49);
            RunButton.TabIndex = 1;
            RunButton.Text = "Run";
            RunButton.UseVisualStyleBackColor = true;
            RunButton.Click += RunButton_Click;
            // 
            // PictureWindow
            // 
            PictureWindow.BackColor = SystemColors.Window;
            PictureWindow.Location = new Point(814, 101);
            PictureWindow.Margin = new Padding(3, 4, 3, 4);
            PictureWindow.Name = "PictureWindow";
            PictureWindow.Size = new Size(626, 487);
            PictureWindow.TabIndex = 2;
            PictureWindow.TabStop = false;
            PictureWindow.Paint += PictureBox_Paint;
            // 
            // ClearButton
            // 
            ClearButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ClearButton.ForeColor = SystemColors.ControlText;
            ClearButton.Location = new Point(186, 655);
            ClearButton.Margin = new Padding(3, 4, 3, 4);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(119, 49);
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
            ProgramWindowLabel.Location = new Point(50, 31);
            ProgramWindowLabel.Name = "ProgramWindowLabel";
            ProgramWindowLabel.Size = new Size(250, 41);
            ProgramWindowLabel.TabIndex = 6;
            ProgramWindowLabel.Text = "Program Window";
            // 
            // OutputWindowLabel
            // 
            OutputWindowLabel.AutoSize = true;
            OutputWindowLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            OutputWindowLabel.ForeColor = Color.YellowGreen;
            OutputWindowLabel.Location = new Point(814, 31);
            OutputWindowLabel.Name = "OutputWindowLabel";
            OutputWindowLabel.Size = new Size(231, 41);
            OutputWindowLabel.TabIndex = 7;
            OutputWindowLabel.Text = "Output Window";
            // 
            // AboutBooseBox
            // 
            AboutBooseBox.BackColor = Color.SeaGreen;
            AboutBooseBox.BorderStyle = BorderStyle.None;
            AboutBooseBox.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            AboutBooseBox.ForeColor = Color.YellowGreen;
            AboutBooseBox.Location = new Point(814, 596);
            AboutBooseBox.Margin = new Padding(3, 4, 3, 4);
            AboutBooseBox.Multiline = true;
            AboutBooseBox.Name = "AboutBooseBox";
            AboutBooseBox.Size = new Size(339, 212);
            AboutBooseBox.TabIndex = 8;
            // 
            // BeerImage
            // 
            BeerImage.BackColor = Color.Transparent;
            BeerImage.Image = (Image)resources.GetObject("BeerImage.Image");
            BeerImage.Location = new Point(1193, 596);
            BeerImage.Margin = new Padding(3, 4, 3, 4);
            BeerImage.Name = "BeerImage";
            BeerImage.Size = new Size(247, 221);
            BeerImage.SizeMode = PictureBoxSizeMode.CenterImage;
            BeerImage.TabIndex = 9;
            BeerImage.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 775);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(60, 60);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // BooseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SeaGreen;
            ClientSize = new Size(1489, 847);
            Controls.Add(pictureBox1);
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
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "BooseForm";
            Text = "Ashley's BOOSE Interpreter";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)PictureWindow).EndInit();
            ((System.ComponentModel.ISupportInitialize)BeerImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private PictureBox pictureBox1;
    }
}
