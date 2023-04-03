namespace grouvee_gamelib_filter
{
    partial class MainWindow
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
            gameInfoPanel = new Panel();
            yearFilterComboBox = new ComboBox();
            yearFilterLabel = new Label();
            yearFilterPanel = new Panel();
            yearFilterPanel.SuspendLayout();
            SuspendLayout();
            // 
            // gameInfoPanel
            // 
            gameInfoPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            gameInfoPanel.AutoScroll = true;
            gameInfoPanel.Location = new Point(12, 12);
            gameInfoPanel.Name = "gameInfoPanel";
            gameInfoPanel.Size = new Size(701, 525);
            gameInfoPanel.TabIndex = 4;
            // 
            // yearFilterComboBox
            // 
            yearFilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            yearFilterComboBox.FormattingEnabled = true;
            yearFilterComboBox.Location = new Point(0, 18);
            yearFilterComboBox.Name = "yearFilterComboBox";
            yearFilterComboBox.Size = new Size(121, 23);
            yearFilterComboBox.TabIndex = 5;
            // 
            // yearFilterLabel
            // 
            yearFilterLabel.AutoSize = true;
            yearFilterLabel.Location = new Point(0, 0);
            yearFilterLabel.Name = "yearFilterLabel";
            yearFilterLabel.Size = new Size(67, 15);
            yearFilterLabel.TabIndex = 2;
            yearFilterLabel.Text = "Year Played";
            // 
            // yearFilterPanel
            // 
            yearFilterPanel.Controls.Add(yearFilterComboBox);
            yearFilterPanel.Controls.Add(yearFilterLabel);
            yearFilterPanel.Location = new Point(719, 12);
            yearFilterPanel.Name = "yearFilterPanel";
            yearFilterPanel.Size = new Size(128, 54);
            yearFilterPanel.TabIndex = 3;
            // 
            // MainWindow
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(848, 549);
            Controls.Add(gameInfoPanel);
            Controls.Add(yearFilterPanel);
            Name = "MainWindow";
            Text = "Grouvee Filter";
            DragDrop += Form1_DragDrop;
            DragEnter += Form1_DragEnter;
            yearFilterPanel.ResumeLayout(false);
            yearFilterPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel gameInfoPanel;
        private ComboBox yearFilterComboBox;
        private Label yearFilterLabel;
        private Panel yearFilterPanel;
    }
}