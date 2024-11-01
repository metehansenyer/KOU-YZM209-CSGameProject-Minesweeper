using System;

namespace KOU_YZM209_CSGameProject_Minesweeper
{
    public partial class Window : Form
    {
        // Pencere sınıfının yapıcı metodu
        public Window()
        {
            InitializeComponent(); // Bileşenleri başlat
        }

        // Kullanıcı kimlik doğrulama durumu
        public bool Authentication_success = false;

        // Oyunu başlatma metodu
        private void startGame(string userName, int gridSize, int mineCount)
        {
            // Yeni bir oyun nesnesi oluştur
            Game startedGame = new Game(userName, gridSize, mineCount, this);

            // Önceki kontrolleri ve eventleri temizle
            Controls.Clear();
            Resize -= setObjectLocations;

            //OnGame
            startedGame.onGame();
        }

        // Pencere boyutunu ayarlama metodu
        private void setWindowSize(object sender, EventArgs e)
        {
            // Ekran genişliğini ve yüksekliğini al
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            // Pencere boyutunu ekranın üçte biri kadar yap
            this.Size = new Size(screenWidth / 3, screenHeight / 3);
        }

        // Kullanıcı verilerini gönderme metodu
        private void sendUserData(object sender, EventArgs e)
        {
            string sendUserName; // Kullanıcı adı
            int sendGridSize;    // Oyun alanı boyutu
            int sendMineCount;   // Mayın sayısı

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

                    // Geçerli bir boyut olup olmadığını kontrol et
                    if (sayi_1 < 4)
                    {
                        MessageBox.Show("Lütfen 4 ve 4'ten büyük bir sayi giriniz!"); // Uyarı mesajı
                    }
                    else if (sayi_1 > 30)
                    {
                        MessageBox.Show("Lütfen 30 ve 30'dan kücük bir sayi giriniz!"); // Uyarı mesajı
                    }
                    else
                    {
                        // Mayın sayısını al
                        int sayi_2 = int.Parse(mineBox.Text);

                        // Geçerli bir mayın sayısı olup olmadığını kontrol et
                        if (sayi_2 < 10)
                        {
                            MessageBox.Show("Lütfen 10 ve 10'dan büyük bir sayi giriniz!"); // Uyarı mesajı
                        }
                        else if (sayi_2 > (sayi_1 * sayi_1 - 1))
                        {
                            MessageBox.Show($"Lütfen {sayi_1 * sayi_1} sayisindan daha kücük bir sayi giriniz!"); // Uyarı mesajı
                        }
                        else
                        {
                            // Kullanıcı verilerini hazırla
                            sendUserName = userNameBox.Text;
                            sendGridSize = sayi_1;
                            sendMineCount = sayi_2;

                            MessageBox.Show("BASARILI!"); // Başarılı mesajı

                            // Oyunu başlat
                            startGame(sendUserName, sendGridSize, sendMineCount);
                        }
                    }
                }
                catch (FormatException)
                {
                    // Hata durumunda uyarı mesajı
                    MessageBox.Show("Lütfen gecerli bir sayi girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Nesne konumlarını ayarlama metodu
        private void setObjectLocations(object sender, EventArgs e)
        {
            // Pencere boyutunu minimum boyutlara ayarla
            if (this.Width < 420) this.Width = 420;
            if (this.Height < 280) this.Height = 280;

            // Oyun adı konumunu ayarla
            gameName.Left = this.Width / 2 - gameName.Width / 2;
            gameName.Top = (int)(this.Height * 0.1);

            // Kullanıcı adı giriş alanı konumunu ayarla
            userNameBox.Left = this.Width / 2 - userNameBox.Width / 2;
            userNameBox.Top = gameName.Top + 50;

            // Kullanıcı adı label konumunu ayarla
            userName.Left = userNameBox.Left - userName.Width;
            userName.Top = userNameBox.Top;

            // Oyun alanı boyutu giriş alanı konumunu ayarla
            gameAreaBox.Left = this.Width / 2 - gameAreaBox.Width / 2;
            gameAreaBox.Top = userNameBox.Top + 30;

            // Oyun alanı label konumunu ayarla
            gameArea.Left = gameAreaBox.Left - gameArea.Width;
            gameArea.Top = gameAreaBox.Top;

            // Mayın sayısı giriş alanı konumunu ayarla
            mineBox.Left = this.Width / 2 - mineBox.Width / 2;
            mineBox.Top = gameAreaBox.Top + 30;

            // Mayın label konumunu ayarla
            mines.Left = mineBox.Left - mines.Width;
            mines.Top = mineBox.Top;

            // Verileri gönder butonu konumunu ayarla
            sendDataButton.Left = this.Width / 2 - sendDataButton.Width / 2;
            sendDataButton.Top = mineBox.Top + 50;
        }
    }
}