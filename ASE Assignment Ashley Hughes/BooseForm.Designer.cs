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
            inputTextBox = new TextBox();
            runButton = new Button();
            outputPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)outputPictureBox).BeginInit();
            SuspendLayout();
            // 
            // inputTextBox
            // 
            inputTextBox.Location = new Point(25, 28);
            inputTextBox.Multiline = true;
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(400, 365);
            inputTextBox.TabIndex = 0;
            inputTextBox.TextChanged += inputTextBox_TextChanged;
            // 
            // runButton
            // 
            runButton.Location = new Point(25, 408);
            runButton.Name = "runButton";
            runButton.Size = new Size(87, 30);
            runButton.TabIndex = 1;
            runButton.Text = "Run";
            runButton.UseVisualStyleBackColor = true;
            // 
            // outputPictureBox
            // 
            outputPictureBox.BackColor = SystemColors.Window;
            outputPictureBox.Location = new Point(576, 28);
            outputPictureBox.Name = "outputPictureBox";
            outputPictureBox.Size = new Size(400, 365);
            outputPictureBox.TabIndex = 2;
            outputPictureBox.TabStop = false;
            // 
            // booseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SeaGreen;
            ClientSize = new Size(1022, 498);
            Controls.Add(outputPictureBox);
            Controls.Add(runButton);
            Controls.Add(inputTextBox);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "booseForm";
            Text = "Ashley's BOOSE Interpreter";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)outputPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox inputTextBox;
        private Button runButton;
        private PictureBox outputPictureBox;
    }
}
