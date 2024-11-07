using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace KOU_YZM209_CSGameProject_Minesweeper
{
    public class Scoreboard
    {
        // Skor girişlerini temsil eden iç sınıf
        private class ScoreEntry
        {
            public string PlayerName { get; } // Oyuncunun adı
            public int Grid { get; } // Oyun alanının boyutu
            public int Mines { get; } // Mayın sayısı
            public int Score { get; } // Oyuncunun puanı

            // Yapıcı metot
            public ScoreEntry(string playerName, int grid, int mines, int score)
            {
                PlayerName = playerName; // Oyuncunun adını ayarla
                Score = score; // Puanı ayarla
                Grid = grid; // Oyun alanı boyutunu ayarla
                Mines = mines; // Mayın sayısını ayarla
            }
        }

        private List<ScoreEntry> scores; // Skorların tutulduğu liste

        // Skor tablosu yapıcısı
        public Scoreboard()
        {
            scores = new List<ScoreEntry>(); // Skor listesini başlat
        }

        public int calculateScore(int findMines, int elapsedTime)
        {
            if (findMines == 0 || elapsedTime == 0)
            {
                return 0; // Eğer mayın bulunamadı veya süre sıfırsa, 0 döndür
            }
            else
            {

                int scr = (int)((findMines / (double)elapsedTime) * 1000); // Skoru hesapla

                return scr; // Hesaplanan skoru döndür
            }
        }

        // Yeni bir skor ekleme metodu
        public void AddScore(string playerName, int grid, int mines, int score)
        {
            scores.Add(new ScoreEntry(playerName, grid, mines, score)); // Yeni skoru listeye ekle

            // Skor listesini puana göre azalan sıralama yaparak en yüksek 10 skoru tut
            scores = scores.OrderByDescending(s => s.Score).Take(10).ToList();
        }

        // En yüksek skorları alma metodu
        public List<(string, int, int, int)> GetTopScores()
        {
            // Skor listesini tuple olarak döndür
            return scores.Select(s => (s.PlayerName, s.Grid, s.Mines, s.Score)).ToList();
        }
    }
}