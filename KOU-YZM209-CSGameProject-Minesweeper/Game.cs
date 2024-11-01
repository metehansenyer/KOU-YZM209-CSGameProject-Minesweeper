using Microsoft.VisualBasic.Devices;
using System;
using System.Drawing;

namespace KOU_YZM209_CSGameProject_Minesweeper
{
    public class Game
    {
        private readonly string userName;
        private readonly int gridSize;
        private readonly int mineCount;

        private int moveCount = 0;
        private Window window;

        private Button[,] grid;
        bool[,] mineField;
        private Label moves = new Label();
        private Panel drawingPanel = new Panel();

        public Game(string userName, int gridSize, int mineCount, Window window)
        {
            this.userName = userName;
            this.gridSize = gridSize;
            this.mineCount = mineCount;
            this.window = window;
        }

        public void onGame()
        {
            setWindowSize();
            addMainObjects();
            plantMines();
            createGrid();
        }

        private void setWindowSize()
        {
            int screenWidth, screenHeight;

            screenWidth = gridSize * 30 + 150;
            screenHeight = gridSize * 30 + 80;

            window.Size = new Size(screenWidth, screenHeight);
        }

        private void addMainObjects()
        {
            Label infoBox = new Label();
            infoBox.AutoSize = true;
            infoBox.Location = new Point((gridSize * 30 / 2) - 87, (gridSize * 30) + 5);
            infoBox.Name = "infoText";
            infoBox.Size = new Size(344, 64);
            infoBox.TabIndex = 1;
            infoBox.Text = "Geliştirici: Metehan Şenyer\r\nOkul Numarası: 230229047\r\n";

            Button scorebordButton = new Button();
            scorebordButton.ForeColor = Color.Black;
            scorebordButton.Location = new Point((gridSize * 30) + 15, 30);
            scorebordButton.Name = "scorebordButton";
            scorebordButton.Size = new Size(110, 30);
            scorebordButton.TabIndex = 2;
            scorebordButton.Text = "Skor Tablosu";
            scorebordButton.UseVisualStyleBackColor = true;

            moves.AutoSize = true;
            moves.Location = new Point((gridSize * 30) + 17, 90);
            moves.Name = "movesText";
            moves.Size = new Size(203, 32);
            moves.TabIndex = 3;
            moves.Text = $"Hamle Sayısı: {moveCount}";

            window.Controls.Add(infoBox);
            window.Controls.Add(scorebordButton);
            window.Controls.Add(moves);
        }

        private void plantMines()
        {
            Random random = new Random();

            mineField = new bool[gridSize, gridSize];

            int placedMines = 0;

            while (placedMines < mineCount)
            {
                int randomX = random.Next(0, gridSize);
                int randomY = random.Next(0, gridSize);
                if (!mineField[randomX, randomY])
                {
                    mineField[randomX, randomY] = true;
                    placedMines++;
                }
            }
        }

        private void createGrid()
        {
            drawingPanel.Size = new Size(gridSize * 30, gridSize * 30);
            drawingPanel.Location = new Point(0, 0);
            window.Controls.Add(drawingPanel);

            grid = new Button[gridSize, gridSize];

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Button button = new Button
                    {
                        Size = new Size(30, 30),
                        Location = new Point(i * 30, j * 30),
                        Tag = mineField[i, j] ? "MINE" : "SAFE",

                        FlatStyle = FlatStyle.Flat,
                        BackColor = ((i+j)%2 == 0) ? Color.FromArgb(157, 213, 57) : Color.FromArgb(130, 197, 42),
                    };
                    button.MouseUp += OnCellClick;
                    grid[i, j] = button;
                    drawingPanel.Controls.Add(button);
                }
            }

        }

        private void OnCellClick(object sender, MouseEventArgs e)
        {
            Button clickedButton = sender as Button;

            if (e.Button == MouseButtons.Left)
            {
                if(clickedButton.Text != "🚩")
                {
                    moveCount++;
                    moves.Text = $"Hamle Sayısı: {moveCount}";

                    checkCell(clickedButton);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if((string)clickedButton.Tag != "OPENED")
                {
                    if (clickedButton.Text != "🚩")
                    {
                        clickedButton.Text = "🚩";
                    }
                    else
                    {
                        clickedButton.Text = "";
                    }
                }
            }
        }

        private void checkCell(Button cell)
        {
            if((string)cell.Tag == "MINE")
            {
                cell.Text = "💣";
                //Oyun bitirelecek.
            } 
            else
            {
                checkNeighbors(cell);
            }
        }

        private void checkNeighbors(Button cell)
        {
            if((string)cell.Tag != "OPENED")
            {
                cell.Tag = "OPENED";
                cell.Enabled = false;
                cell.BackColor = ((cell.Location.X / 30 + cell.Location.Y / 30) % 2 == 0) ? Color.FromArgb(226, 187, 149) : Color.FromArgb(210, 176, 142);

                int neighbors = 0;
                int X_1 = (cell.Location.X / 30 - 1) < 0 ? 0 : (cell.Location.X / 30 - 1);
                int X_2 = (cell.Location.X / 30 + 1) > gridSize - 1 ? gridSize - 1 : (cell.Location.X / 30 + 1);
                int Y_1 = (cell.Location.Y / 30 - 1) < 0 ? 0 : (cell.Location.Y / 30 - 1);
                int Y_2 = (cell.Location.Y / 30 + 1) > gridSize - 1 ? gridSize - 1 : (cell.Location.Y / 30 + 1);

                for (int i = X_1; i <= X_2; i++)
                {
                    for (int j = Y_1; j <= Y_2; j++)
                    {
                        if ((string)grid[i, j].Tag == "MINE")
                        {
                            neighbors++;
                        }
                        else
                        {
                            checkNeighbors(grid[i, j]);
                        }
                    }
                }

                cell.Text = $"{neighbors}";
            }
        }

        private void RevealAllMines()
        {
            foreach (var button in grid)
            {
                if ((string)button.Tag == "MINE")
                {
                    button.Text = "💣";
                    button.BackColor = Color.Red;
                }
            }
        }
    }
}