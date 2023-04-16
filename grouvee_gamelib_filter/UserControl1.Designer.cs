namespace grouvee_gamelib_filter
{
    partial class UserControl1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gameNameLabel = new Label();
            gameYearLabel = new Label();
            gameCoverPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)gameCoverPictureBox).BeginInit();
            SuspendLayout();
            // 
            // gameNameLabel
            // 
            gameNameLabel.AutoSize = true;
            gameNameLabel.Font = new Font("Arial Narrow", 18F, FontStyle.Regular, GraphicsUnit.Point);
            gameNameLabel.Location = new Point(0, 0);
            gameNameLabel.Name = "gameNameLabel";
            gameNameLabel.Size = new Size(99, 29);
            gameNameLabel.TabIndex = 0;
            gameNameLabel.Text = "Ibb & Obb";
            gameNameLabel.UseMnemonic = false;
            gameNameLabel.SizeChanged += label1_SizeChanged;
            // 
            // gameYearLabel
            // 
            gameYearLabel.AutoSize = true;
            gameYearLabel.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point);
            gameYearLabel.Location = new Point(91, 0);
            gameYearLabel.Name = "gameYearLabel";
            gameYearLabel.Size = new Size(77, 20);
            gameYearLabel.TabIndex = 1;
            gameYearLabel.Text = "(2022-2023)";
            gameYearLabel.UseMnemonic = false;
            // 
            // gameCoverPictureBox
            // 
            gameCoverPictureBox.BackColor = Color.Black;
            gameCoverPictureBox.Location = new Point(3, 32);
            gameCoverPictureBox.Name = "gameCoverPictureBox";
            gameCoverPictureBox.Size = new Size(256, 256);
            gameCoverPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            gameCoverPictureBox.TabIndex = 2;
            gameCoverPictureBox.TabStop = false;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(gameCoverPictureBox);
            Controls.Add(gameYearLabel);
            Controls.Add(gameNameLabel);
            Name = "UserControl1";
            Size = new Size(262, 291);
            ((System.ComponentModel.ISupportInitialize)gameCoverPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label gameNameLabel;
        public Label gameYearLabel;
        public PictureBox gameCoverPictureBox;
    }
}
