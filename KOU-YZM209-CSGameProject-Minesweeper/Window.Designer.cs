
namespace KOU_YZM209_CSGameProject_Minesweeper
{
    partial class Window
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
            userName = new Label();
            gameName = new Label();
            gameArea = new Label();
            mines = new Label();
            userNameBox = new TextBox();
            gameAreaBox = new TextBox();
            mineBox = new TextBox();
            sendDataButton = new Button();
            SuspendLayout();
            // 
            // userName
            // 
            userName.AutoSize = true;
            userName.Location = new Point(363, 184);
            userName.Margin = new Padding(4, 0, 4, 0);
            userName.Name = "userName";
            userName.Size = new Size(103, 32);
            userName.TabIndex = 1;
            userName.Text = "Adınız: ";
            userName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gameName
            // 
            gameName.AutoSize = true;
            gameName.Location = new Point(528, 106);
            gameName.Margin = new Padding(4, 0, 4, 0);
            gameName.Name = "gameName";
            gameName.Size = new Size(173, 32);
            gameName.TabIndex = 3;
            gameName.Text = "Mayın Tarlası";
            // 
            // gameArea
            // 
            gameArea.AutoSize = true;
            gameArea.Location = new Point(288, 258);
            gameArea.Margin = new Padding(4, 0, 4, 0);
            gameArea.Name = "gameArea";
            gameArea.Size = new Size(178, 32);
            gameArea.TabIndex = 5;
            gameArea.Text = "Saha Boyutu:";
            gameArea.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // mines
            // 
            mines.AutoSize = true;
            mines.Location = new Point(290, 327);
            mines.Margin = new Padding(4, 0, 4, 0);
            mines.Name = "mines";
            mines.Size = new Size(176, 32);
            mines.TabIndex = 7;
            mines.Text = "Mayın Sayısı:";
            mines.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // userNameBox
            // 
            userNameBox.Location = new Point(473, 184);
            userNameBox.Name = "userNameBox";
            userNameBox.Size = new Size(302, 39);
            userNameBox.TabIndex = 8;
            // 
            // gameAreaBox
            // 
            gameAreaBox.Location = new Point(473, 258);
            gameAreaBox.Name = "gameAreaBox";
            gameAreaBox.Size = new Size(302, 39);
            gameAreaBox.TabIndex = 9;
            // 
            // mineBox
            // 
            mineBox.Location = new Point(473, 327);
            mineBox.Name = "mineBox";
            mineBox.Size = new Size(302, 39);
            mineBox.TabIndex = 10;
            // 
            // sendDataButton
            // 
            sendDataButton.ForeColor = Color.Black;
            sendDataButton.Location = new Point(540, 394);
            sendDataButton.Name = "sendDataButton";
            sendDataButton.Size = new Size(150, 46);
            sendDataButton.TabIndex = 11;
            sendDataButton.Text = "GÖNDER";
            sendDataButton.UseVisualStyleBackColor = true;
            sendDataButton.Click += sendUserData;
            // 
            // Window
            // 
            AutoScaleDimensions = new SizeF(16F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(59, 104, 28);
            ClientSize = new Size(1225, 683);
            Controls.Add(sendDataButton);
            Controls.Add(mineBox);
            Controls.Add(gameAreaBox);
            Controls.Add(userNameBox);
            Controls.Add(mines);
            Controls.Add(gameArea);
            Controls.Add(gameName);
            Controls.Add(userName);
            Font = new Font("Arial", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Window";
            Text = "Form1";
            Load += setWindowSize;
            Resize += setObjectLocations;
            ResumeLayout(false);
            PerformLayout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

#endregion
        private Label userName;
        private Label gameName;
        private Label gameArea;
        private Label mines;
        private TextBox userNameBox;
        private TextBox gameAreaBox;
        private TextBox mineBox;
        private Button sendDataButton;
    }
}