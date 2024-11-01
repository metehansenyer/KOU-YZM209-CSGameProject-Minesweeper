namespace KOU_YZM209_CSGameProject_Minesweeper
{
    partial class gameArea
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            moves = new Label();
            scorebordButton = new Button();
            infoBox = new Label();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(1, 93);
            panel1.Name = "panel1";
            panel1.Size = new Size(990, 786);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // moves
            // 
            moves.AutoSize = true;
            moves.Location = new Point(772, 30);
            moves.Name = "moves";
            moves.Size = new Size(203, 32);
            moves.TabIndex = 2;
            moves.Text = "Hamle Sayısı: 0";
            // 
            // scorebordButton
            // 
            scorebordButton.ForeColor = Color.Black;
            scorebordButton.Location = new Point(456, 23);
            scorebordButton.Name = "scorebordButton";
            scorebordButton.Size = new Size(181, 46);
            scorebordButton.TabIndex = 4;
            scorebordButton.Text = "Skor Tablosu";
            scorebordButton.UseVisualStyleBackColor = true;
            // 
            // infoBox
            // 
            infoBox.AutoSize = true;
            infoBox.Location = new Point(1, 9);
            infoBox.Name = "infoBox";
            infoBox.Size = new Size(344, 64);
            infoBox.TabIndex = 5;
            infoBox.Text = "Geliştirici: Metehan Şenyer\r\nOkul Numarası: 230229047\r\n";
            infoBox.Click += infoBox_Click;
            // 
            // gameArea
            // 
            AutoScaleDimensions = new SizeF(16F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(59, 104, 28);
            ClientSize = new Size(987, 880);
            Controls.Add(infoBox);
            Controls.Add(scorebordButton);
            Controls.Add(moves);
            Controls.Add(panel1);
            Font = new Font("Arial", 10F);
            ForeColor = Color.White;
            Margin = new Padding(4, 3, 4, 3);
            Name = "gameArea";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Label moves;
        private Button scorebordButton;
        private Label infoBox;
    }
}