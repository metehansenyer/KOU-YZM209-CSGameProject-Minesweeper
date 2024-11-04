namespace KOU_YZM209_CSGameProject_Minesweeper
{
    public partial class Window : Form
    {
        //Scoreboard nesnesi
        private Scoreboard scoreboard = new Scoreboard();

        // Kullanıcı arayüzü bileşenleri
        private Label userName = new Label();
        private Label gameName = new Label();
        private Label gameArea = new Label();
        private Label mines = new Label();
        private TextBox userNameBox = new TextBox();
        private TextBox gameAreaBox = new TextBox();
        private TextBox mineBox = new TextBox();
        private Button sendDataButton = new Button();

        // Ekran boyutları için değişkenler
        private int screenWidth;
        private int screenHeight;

        // Form yapıcısı.
        public Window()
        {
            InitializeComponent(); // Form bileşenlerini başlat
            InitializeStartScreen(); // Başlangıç fonksiyonunu çağır
        }

        // Pencere boyutunu ayarlayan metod
        private void setWindowSize()
        {
            // Ekranın boyutlarını al
            screenWidth = Screen.PrimaryScreen.Bounds.Width;
            screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // Pencere stilini ve boyutunu ayarla
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new Size(screenWidth / 3, screenHeight / 3);

            // Ekran boyutlarını Client Boyutlarına ayarla
            screenWidth = this.ClientSize.Width;
            screenHeight = this.ClientSize.Height;
        }

        // Giriş sayfasını oluşturan fonksiyon
        private void userPage()
        {
            // Mevcut bileşenleri temizle
            Controls.Clear();

            // 
            // gameName
            // 
            gameName.AutoSize = true;
            gameName.Name = "gameName";
            gameName.Location = new Point(screenWidth / 2 - gameName.Width / 2, screenHeight / 10);
            gameName.Text = "Mayın Tarlası"; // Oyun ismi
            // 
            // userNameBox
            // 
            userNameBox.Name = "userNameBox";
            userNameBox.Text = "";
            userNameBox.Size = new Size(screenWidth / 3, 0);
            userNameBox.Location = new Point(screenWidth / 2 - userNameBox.Width / 2, 70);
            // 
            // userName
            // 
            userName.AutoSize = true;
            userName.Name = "userName";
            userName.Location = new Point(105, 70);
            userName.Text = "Adınız: "; // Kullanıcı adı etiketi
            //
            // gameAreaBox
            // 
            gameAreaBox.Name = "gameAreaBox";
            gameAreaBox.Text = "";
            gameAreaBox.Size = new Size(screenWidth / 3, 0);
            gameAreaBox.Location = new Point(screenWidth / 2 - gameAreaBox.Width / 2, 100);
            // 
            // gameArea
            // 
            gameArea.AutoSize = true;
            gameArea.Name = "gameArea";
            gameArea.Location = new Point(62, 100);
            gameArea.Text = "Saha Boyutu: "; // Oyun alanı etiketi
            // 
            // mineBox
            // 
            mineBox.Name = "mineBox";
            mineBox.Text = "";
            mineBox.Size = new Size(screenWidth / 3, 0);
            mineBox.Location = new Point(screenWidth / 2 - mineBox.Width / 2, 130);
            // 
            // mines
            // 
            mines.AutoSize = true;
            mines.Name = "mines";
            mines.Location = new Point(62, 130);
            mines.Text = "Mayın Sayısı: "; // Mayın sayısı etiketi
            // 
            // sendDataButton
            // 
            sendDataButton.ForeColor = Color.Black;
            sendDataButton.UseVisualStyleBackColor = true;
            sendDataButton.Name = "sendDataButton";
            sendDataButton.Size = new Size(screenWidth / 5, screenHeight / 7);
            sendDataButton.Text = "BAŞLAT"; // Buton metni
            sendDataButton.Location = new Point(screenWidth / 2 - screenWidth / 9, 170);
            sendDataButton.Click += sendUserData; // Butona tıklama olayını bağla

            // Kontrolleri forma ekle
            Controls.Add(sendDataButton);
            Controls.Add(mineBox);
            Controls.Add(gameAreaBox);
            Controls.Add(userNameBox);
            Controls.Add(mines);
            Controls.Add(gameArea);
            Controls.Add(gameName);
            Controls.Add(userName);
        }

        // Kullanıcı verilerini kontrol eden ve oyunu başlatan fonksiyona gönderen metod
        private void sendUserData(object sender, EventArgs e)
        {
            string sendUserName;
            int sendGridSize;
            int sendMineCount;

            // Kullanıcı adının boş olup olmadığını kontrol et
            if (userNameBox.Text == "")
            {
                MessageBox.Show("Lütfen bir isim giriniz!"); // Uyarı mesajı
            }
            else
            {
                try
                {
                    // Oyun alanı boyutunu al
                    int sayi_1 = int.Parse(gameAreaBox.Text);

                    // Oyun alanı boyutunu kontrol et
                    if (sayi_1 < 4)
                    {
                        MessageBox.Show("Lütfen oyun alanı için 4 ve 4'ten büyük bir sayi giriniz!");
                    }
                    else if (sayi_1 > 30)
                    {
                        MessageBox.Show("Lütfen oyun alanı için 30 ve 30'dan kücük bir sayi giriniz!");
                    }
                    else
                    {
                        // Mayın sayısını al
                        int sayi_2 = int.Parse(mineBox.Text);

                        // Mayın sayısını kontrol et
                        if (sayi_2 < 10)
                        {
                            MessageBox.Show("Lütfen mayın sayısı için 10 ve 10'dan büyük bir sayi giriniz!");
                        }
                        else if (sayi_2 > (sayi_1 * sayi_1 - 1))
                        {
                            MessageBox.Show($"Lütfen mayın sayısı için {sayi_1 * sayi_1} sayisindan daha kücük bir sayi giriniz!");
                        }
                        else
                        {
                            // Kullanıcı adı ve parametreleri ayarla
                            sendUserName = userNameBox.Text;
                            sendGridSize = sayi_1;
                            sendMineCount = sayi_2;

                            // Oyunu başlat
                            startGame(sendUserName, sendGridSize, sendMineCount);
                        }
                    }
                }
                catch (FormatException)
                {
                    // Hatalı format durumunda mesaj göster
                    MessageBox.Show("Lütfen gecerli bir sayi girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Başlangıç ekranını başlatan metod
        public void InitializeStartScreen()
        {
            Controls.Clear(); // Mevcut kontrolleri temizle
            setWindowSize(); // Pencere boyutunu ayarla
            userPage(); // Giriş sayfasını oluştur.
        }

        // Oyunu başlatan metod
        private void startGame(string userName, int gridSize, int mineCount)
        {
            // Yeni bir oyun nesnesi oluştur
            Game startedGame = new Game(userName, gridSize, mineCount, this, scoreboard);

            Controls.Clear(); // Mevcut kontrolleri temizle

            // Oyunu başlat
            startedGame.onGame();
        }
    }
}