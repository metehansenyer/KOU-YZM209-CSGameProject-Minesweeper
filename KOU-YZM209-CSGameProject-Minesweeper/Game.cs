using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace KOU_YZM209_CSGameProject_Minesweeper
{
    public class Game
    {
        // Kullanıcı adı, grid boyutu ve mayın sayısı için sabit değişkenler
        private readonly string userName;
        private readonly int gridSize;
        private readonly int mineCount;

        private int cellSize; // Her hücrenin boyutu (bir kenarı)
        private int moveCount = 0; // Yapılan hamle sayısı
        private int score; // Kullanıcının skoru
        private Window window; // Oyun penceresi için referans tutucu
        private Scoreboard scoreboard; // Skor tablosu

        private Button[,] grid; // Oyun alanının kendisi
        private bool[,] mineField; // Mayın tutucu
        private Label moves = new Label(); // Hamle sayısını gösterecek yazı
        private Label timerText = new Label(); // Zamanı gösterecek yazı
        private Panel drawingPanel = new Panel(); // Oyun alanının çizileceği panel

        private System.Windows.Forms.Timer timer; // Zamanlayıcı
        private int elapsedTime = 0; // Geçen zaman (sn)

        // Oyun sınıfının yapıcı metodu
        public Game(string userName, int gridSize, int mineCount, Window window, Scoreboard scoreboard)
        {
            this.userName = userName; // Kullanıcı adını al
            this.gridSize = gridSize; // Grid boyutunu ayarla
            this.mineCount = mineCount; // Mayın sayısını ayarla
            this.window = window; // Oyun penceresini ayarla
            this.scoreboard = scoreboard; // Skor tablosunu ayarla

            // Grid boyutuna göre hücre boyutunu ayarla
            if(gridSize < 10)
            {
                cellSize = 50; // Küçük grid için hücre boyutu
            }
            else if (gridSize < 25)
            {
                cellSize = 30; // Orta grid için hücre boyutu
            }
            else
            {
                cellSize = 20; // Büyük grid için hücre boyutu

                // Panel fontunu küçült
                Font currentFont = drawingPanel.Font;
                float newFontSize = currentFont.Size * 0.8f;
                drawingPanel.Font = new Font(currentFont.FontFamily, newFontSize, currentFont.Style);
            }
        }

        // Oyun başladığında çağrılan metod
        public void onGame()
        {
            setWindowSize(); // Pencere boyutunu ayarla
            addMainObjects(); // Ana nesneleri ekle
            plantMines(); // Mayınları yerleştir
            createGrid(); // Oyun alanını oluştur
            setMineCountForOneCell(); // Her hücre için mayın sayısını ayarla
            InitializeTimer(); // Zamanlayıcıyı başlat
            timer.Start(); // Zamanlayıcıyı çalıştır
        }

        // Zamanlayıcıyı başlatma metod
        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer(); // Zamanlayıcı nesnesi oluştur
            timer.Interval = 1000; // Her bir saniyede bir tetiklenecek
            timer.Tick += Timer_Tick; // Zamanlayıcı tetiklendiğinde çağrılacak metod
        }

        // Zamanlayıcı tetiklendiğinde çağrılan metod
        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTime++; // Geçen zamanı artır
            UpdateTimerText(); // Zamanı güncelle
        }

        // Zaman etiketini güncelleme metod
        private void UpdateTimerText()
        {
            int minutes = elapsedTime / 60; // Dakikaları hesapla
            int seconds = elapsedTime % 60; // Saniyeleri hesapla
            timerText.Text = $"Geçen Süre:\r\n{minutes:D2}:{seconds:D2}"; // Zamanı yazdır
        }

        // Zamanlayıcıyı durdurma metod
        private void StopTimer()
        {
            timer.Stop(); // Zamanlayıcıyı durdur
        }

        // Pencere boyutunu ayarlama metod
        private void setWindowSize()
        {
            int screenWidth, screenHeight;

            screenWidth = gridSize * cellSize + 150; // Genişlik hesapla
            screenHeight = gridSize * cellSize + 80; // Yükseklik hesapla

            window.Size = new Size(screenWidth, screenHeight); // Pencere boyutunu ayarla
        }

        // Ana nesneleri ekleme metod
        private void addMainObjects()
        {
            // Bilgi kutusu için yazı oluştur
            Label infoBox = new Label();
            infoBox.AutoSize = true;
            infoBox.Location = new Point((gridSize * cellSize / 2) - 87, (gridSize * cellSize) + 5);
            infoBox.Name = "infoText";
            infoBox.Size = new Size(344, 64);
            infoBox.TabIndex = 1;
            infoBox.Text = "Geliştirici: Metehan Şenyer\r\nOkul Numarası: 230229047\r\n";

            // Skor tablosunu gösteren buton oluştur
            Button scorebordButton = new Button();
            scorebordButton.ForeColor = Color.Black;
            scorebordButton.Location = new Point((gridSize * cellSize) + 15, 30);
            scorebordButton.Name = "scorebordButton";
            scorebordButton.Size = new Size(110, 30);
            scorebordButton.TabIndex = 2;
            scorebordButton.Text = "Skor Tablosu";
            scorebordButton.UseVisualStyleBackColor = true;
            scorebordButton.Click += (sender, e) => ShowScoreboard(); // Butona tıklandığında skor tablosunu göster

            // Hamle sayısını gösteren etiket
            moves.AutoSize = true;
            moves.Location = new Point((gridSize * cellSize) + 17, 90);
            moves.Name = "movesText";
            moves.Size = new Size(203, 32);
            moves.TabIndex = 3;
            moves.Text = $"Hamle Sayısı: {moveCount}"; // Başlangıçta hamle sayısı 0

            // Zamanı gösterecek etiket
            timerText.AutoSize = true;
            timerText.Location = new Point((gridSize * cellSize) + 25, 120);
            timerText.Name = "timerText";
            timerText.Size = new Size(167, 64);
            timerText.TabIndex = 4;
            timerText.Text = $"Geçen Süre:\r\n{elapsedTime:D2}:{0:D2}"; // Başlangıçta zaman 00.00
            timerText.TextAlign = ContentAlignment.MiddleCenter;

            // Tüm nesneleri pencereye ekle
            window.Controls.Add(infoBox);
            window.Controls.Add(scorebordButton);
            window.Controls.Add(moves);
            window.Controls.Add(timerText);
        }

        // Mayınları yerleştirme metod
        private void plantMines()
        {
            Random random = new Random(); // Rastgele sayı üreteci

            mineField = new bool[gridSize, gridSize]; // Mayın alanını oluştur

            int placedMines = 0; // Yerleştirilen mayın sayısını takip et

            // Mayınları rastgele yerleştir
            while (placedMines < mineCount)
            {
                int randomX = random.Next(0, gridSize);
                int randomY = random.Next(0, gridSize);
                if (!mineField[randomX, randomY])
                {
                    mineField[randomX, randomY] = true; // Mayın yerleştir
                    placedMines++; // Yerleştirilen mayın sayısını artır
                }
            }
        }

        private void createGrid()
        {
            // Oyun alanının boyutunu ayarla
            drawingPanel.Size = new Size(gridSize * cellSize, gridSize * cellSize);
            drawingPanel.Location = new Point(0, 0);
            window.Controls.Add(drawingPanel); // Paneli pencereye ekle

            // Grid için buton dizisini oluştur
            grid = new Button[gridSize, gridSize];

            // Gridin her hücresine buton ekle
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Button button = new Button
                    {
                        Size = new Size(cellSize, cellSize), // Buton boyutu
                        Location = new Point(i * cellSize, j * cellSize), // Butonun konumu
                        Tag = mineField[i, j] ? "MINE" : "SAFE", // Butonun etiketini belirle

                        FlatStyle = FlatStyle.Flat, // Buton stilini düz yap
                        BackColor = ((i + j) % 2 == 0) ? Color.FromArgb(157, 213, 57) : Color.FromArgb(130, 197, 42), // Arka plan rengi
                    };
                    button.MouseUp += OnCellClick; // Butona tıklandığında çağrılacak olay
                    grid[i, j] = button; // Butonu grid dizisine ekle
                    drawingPanel.Controls.Add(button); // Butonu panelde göster
                }
            }
        }

        private void OnCellClick(object sender, MouseEventArgs e)
        {
            Button clickedButton = sender as Button; // Tıklanan butonu al

            if (e.Button == MouseButtons.Left) // Sol tıklama kontrolü
            {
                if (clickedButton.Text != "🚩") // Eğer buton işaretlenmemişse
                {
                    moveCount++; // Hamle sayısını artır
                    moves.Text = $"Hamle Sayısı: {moveCount}"; // Hamle sayısını güncelle

                    checkCell(clickedButton); // Butonun durumunu kontrol et
                }
            }
            else if (e.Button == MouseButtons.Right) // Sağ tıklama kontrolü
            {
                if ((string)clickedButton.Tag != "OPENED") // Eğer hücre açılmamışsa
                {
                    if (clickedButton.Text != "🚩") // Eğer hücre işaretlenmemişse
                    {
                        clickedButton.Text = "🚩"; // Hücreyi işaretle
                    }
                    else
                    {
                        clickedButton.Text = ""; // İşareti kaldır
                    }
                }
            }
        }

        private void checkCell(Button cell)
        {
            if ((string)cell.Tag == "MINE") // Eğer hücre mayınsa
            {
                cell.Text = "💣"; // Mayın simgesini göster
                StopTimer(); // Zamanlayıcıyı durdur

                score = returnScore(); // Skoru hesapla
                
                if(score != 0)
                {
                    scoreboard.AddScore(userName, gridSize, mineCount, score);
                }

                RevealAllMines(); // Tüm mayınları göster

                // Oyun sonu mesajı için yazı oluştur
                Label endBox = new Label();
                endBox.AutoSize = true;
                endBox.Location = new Point((gridSize * cellSize) + 10, 180);
                endBox.Name = "endText";
                endBox.Size = new Size(245, 64);
                endBox.TabIndex = 5;
                endBox.Text = $"MAYINA BASTINIZ\r\nSkorunuz: {score}\r\n";
                endBox.TextAlign = ContentAlignment.MiddleCenter;

                // Yeni oyun butonu oluştur
                Button newGameButton = new Button();
                newGameButton.ForeColor = Color.Black;
                newGameButton.Location = new Point((gridSize * cellSize) + 15, 240);
                newGameButton.Name = "newGameButton";
                newGameButton.Size = new Size(110, 30);
                newGameButton.TabIndex = 2;
                newGameButton.Text = "Yeni Oyun";
                newGameButton.UseVisualStyleBackColor = true;
                newGameButton.MouseUp += NewGameClick; // Butona tıklandığında yeni oyun başlat

                // Sonuç mesajını ve yeni oyun butonunu pencereye ekle
                window.Controls.Add(endBox);
                window.Controls.Add(newGameButton);
            }
            else
            {
                openCell(cell); // Hücreyi aç

                int control = 0; // Açılmamış hücre sayısını takip et

                // Tüm butonları kontrol et
                foreach (var button in grid)
                {
                    if ((string)button.Tag != "MINE" && (string)button.Tag != "OPENED") // Açılmamış ve mayın olmayan hücreleri say
                    {
                        control++;
                    }
                }

                // Eğer açılmamış hücre yoksa oyunu kazan
                if (control == 0)
                {
                    StopTimer(); // Zamanlayıcıyı durdur

                    score = returnScore(); // Skoru hesapla

                    if (score != 0)
                    {
                        scoreboard.AddScore(userName, gridSize, mineCount, score);
                    }

                    RevealAllMines(); // Tüm mayınları göster

                    // Oyun kazanma mesajı için yazı oluştur
                    Label endBox = new Label();
                    endBox.AutoSize = true;
                    endBox.Location = new Point((gridSize * cellSize) + 10, 180);
                    endBox.Name = "endText";
                    endBox.Size = new Size(245, 64);
                    endBox.TabIndex = 5;
                    endBox.Text = $"KAZANDINIZ\r\nSkorunuz: {score}\r\n";
                    endBox.TextAlign = ContentAlignment.MiddleCenter;

                    // Yeni oyun butonu oluştur
                    Button newGameButton = new Button();
                    newGameButton.ForeColor = Color.Black;
                    newGameButton.Location = new Point((gridSize * cellSize) + 15, 240);
                    newGameButton.Name = "newGameButton";
                    newGameButton.Size = new Size(110, 30);
                    newGameButton.TabIndex = 2;
                    newGameButton.Text = "Yeni Oyun";
                    newGameButton.UseVisualStyleBackColor = true;
                    newGameButton.MouseUp += NewGameClick; // Butona tıklandığında yeni oyun başlat

                    // Sonuç mesajını ve yeni oyun butonunu pencereye ekle
                    window.Controls.Add(endBox);
                    window.Controls.Add(newGameButton);
                }
            }
        }

        private void openCell(Button cell)
        {
            if ((string)cell.Tag != "OPENED") // Eğer hücre daha önce açılmamışsa
            {
                string mineCount = (string)cell.Tag; // Hücredeki mayın sayısını al

                cell.Tag = "OPENED"; // Hücreyi açılmış olarak işaretle
                cell.Enabled = false; // Butonu devre dışı bırak
                cell.BackColor = ((cell.Location.X / cellSize + cell.Location.Y / cellSize) % 2 == 0) ? Color.FromArgb(226, 187, 149) : Color.FromArgb(210, 176, 142); // Arka plan rengini değiştir

                if (mineCount != "0") // Eğer hücrede mayın yoksa
                {
                    cell.Text = mineCount; // Hücredeki mayın sayısını göster
                }
                else
                {
                    // Komşu hücrelerin X ve Y koordinatlarını belirle
                    int X_1 = (cell.Location.X / cellSize - 1) < 0 ? 0 : (cell.Location.X / cellSize - 1);
                    int X_2 = (cell.Location.X / cellSize + 1) > gridSize - 1 ? gridSize - 1 : (cell.Location.X / cellSize + 1);
                    int Y_1 = (cell.Location.Y / cellSize - 1) < 0 ? 0 : (cell.Location.Y / cellSize - 1);
                    int Y_2 = (cell.Location.Y / cellSize + 1) > gridSize - 1 ? gridSize - 1 : (cell.Location.Y / cellSize + 1);

                    // Komşu hücreleri kontrol et
                    for (int i = X_1; i <= X_2; i++)
                    {
                        for (int j = Y_1; j <= Y_2; j++)
                        {
                            openCell(grid[i, j]);
                        }
                    }
                }
            }
        }

        private int checkNeighbors(Button cell)
        {
            int neighbors = 0;

            // Komşu hücrelerin X ve Y koordinatlarını belirle
            int X_1 = (cell.Location.X / cellSize - 1) < 0 ? 0 : (cell.Location.X / cellSize - 1);
            int X_2 = (cell.Location.X / cellSize + 1) > gridSize - 1 ? gridSize - 1 : (cell.Location.X / cellSize + 1);
            int Y_1 = (cell.Location.Y / cellSize - 1) < 0 ? 0 : (cell.Location.Y / cellSize - 1);
            int Y_2 = (cell.Location.Y / cellSize + 1) > gridSize - 1 ? gridSize - 1 : (cell.Location.Y / cellSize + 1);

            // Komşu hücreleri kontrol et ve mayın sayısını hesapla
            for (int i = X_1; i <= X_2; i++)
            {
                for (int j = Y_1; j <= Y_2; j++)
                {
                    if ((string)grid[i, j].Tag == "MINE")
                    {
                        neighbors++;
                    }
                }
            }

            return neighbors; // Bulunan komşu mayın sayısını döndür
        }

        private void setMineCountForOneCell()
        {
            // Tüm hücreleri gezerek mayın sayısını ayarla
            foreach (var button in grid)
            {
                if ((string)button.Tag != "MINE") // Eğer hücre mayın değilse
                {
                    button.Tag = $"{checkNeighbors(button)}"; // Komşu mayın sayısını ata
                }
            }
        }

        private void RevealAllMines()
        {
            // Tüm hücrelerdeki mayınları aç
            foreach (var button in grid)
            {
                button.Enabled = false; // Tüm hücreleri devre dışı bırak

                if ((string)button.Tag == "MINE")
                {
                    if (button.Text != "🚩")
                    {
                        button.Text = "💣"; // Mayın hücresini göster
                    }

                    button.BackColor = Color.Red; // Mayın hücresinin arka plan rengini kırmızı yap
                }
            }
        }

        private void NewGameClick(object sender, MouseEventArgs e)
        {
            Button clickedButton = sender as Button;

            // Yeni oyun butonuna tıklanırsa
            if (e.Button == MouseButtons.Left)
            {
                window.InitializeStartScreen(); // Oyun giriş ekranını başlat
            }
        }

        private int returnScore()
        {
            int findMines = 0;

            // Doğru bir şekilde işaretlenmiş mayınları say
            foreach (var button in grid)
            {
                if (button.Text == "🚩" && (string)button.Tag == "MINE")
                {
                    findMines++;
                }
            }

            return scoreboard.calculateScore(findMines, elapsedTime);
        }

        private void ShowScoreboard()
        {
            ScoreboardWindow scoreboardWindow = new ScoreboardWindow(scoreboard); // Scoreboard penceresini oluştur
            scoreboardWindow.Show(); // Scoreboard penceresini göster
        }
    }
}
