using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KOU_YZM209_CSGameProject_Minesweeper
{
    public partial class ScoreboardWindow : Form
    {
        // Scoreboard nesnesi
        private Scoreboard scoreboard;
        // Skor listesini gösterecek ListView
        private ListView scoreListView;

        // Scoreboard sınıfının yapıcısı
        public ScoreboardWindow(Scoreboard scoreboard)
        {
            this.scoreboard = scoreboard; // Scoreboardu ayarla

            InitializeComponent(); // Form bileşenlerini başlat
            setWindowSize(); // Pencere boyutunu ayarla
            SetupListView(); // ListView bileşenini ayarla
            LoadScores(); // Skorları yükle
        }

        // Pencere boyutunu ayarlayan metod
        private void setWindowSize()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Pencere stilini sabitle
            this.MaximizeBox = false; // Maksimize butonunu kaldır
            this.MinimizeBox = false; // Minimize butonunu kaldır
            this.ClientSize = new Size(400, 250); // Pencere boyutunu belirle
        }

        // ListView bileşenini ayarlayan metod
        private void SetupListView()
        {
            scoreListView = new ListView(); // Yeni bir ListView oluştur
            scoreListView.View = View.Details; // Ayrıntılı görünüm ayarla
            scoreListView.FullRowSelect = true; // Tam satır seçim modunu etkinleştir
            scoreListView.GridLines = true; // Izgara çizgilerini göster
            // ListView için sütun başlıklarını ekle
            scoreListView.Columns.Add("Oyuncu Adı", 100); // Oyuncu adı sütunu
            scoreListView.Columns.Add("Oyun Boyutu", 100); // Oyun boyutu sütunu
            scoreListView.Columns.Add("Mayın Sayısı", 100); // Mayın sayısı sütunu
            scoreListView.Columns.Add("Skor", 100); // Skor sütunu
            scoreListView.Dock = DockStyle.Fill; // ListView'ı forma tam doldur
            this.Controls.Add(scoreListView); // ListView'ı forma ekle
            this.Text = "Skor Tablosu"; // Form başlığını ayarla
        }

        // Skorları yükleyen metod
        private void LoadScores()
        {
            // En yüksek skorları al
            var topScores = scoreboard.GetTopScores();

            // Her bir skoru ListView'a ekle
            foreach (var (playerName, grid, mines, score) in topScores)
            {
                ListViewItem item = new ListViewItem(playerName); // Oyuncu adı için yeni bir ListViewItem oluştur
                item.SubItems.Add(grid.ToString()); // Oyun boyutunu ekle
                item.SubItems.Add(mines.ToString()); // Mayın sayısını ekle
                item.SubItems.Add(score.ToString()); // Skoru ekle
                scoreListView.Items.Add(item); // Item'ı ListView'a ekle
            }
        }
    }
}