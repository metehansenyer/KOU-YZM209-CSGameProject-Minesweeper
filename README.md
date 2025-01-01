# KOÜ Yazılım Müh. Programlama Laboratuvarı III Dersi Projesi
Kocaeli Üniversitesi Mühendislik Fakültesi Yazılım Mühendisliği 24-25 Programlama Laboratuvarı III Projesi GitHub sayfası. Minesweeper.

# İçerik

- [Kullanılan Araçlar](https://github.com/metehansenyer/KOU-YZM209-CSGameProject-Minesweeper?tab=readme-ov-file#kullanılan-araçlar)
- [Amaç](https://github.com/metehansenyer/KOU-YZM209-CSGameProject-Minesweeper?tab=readme-ov-file#amaç)
- [Projeden Beklenenler](https://github.com/metehansenyer/KOU-YZM209-CSGameProject-Minesweeper?tab=readme-ov-file#projeden-beklenenler)
- [Karşılanan Beklentiler](https://github.com/metehansenyer/KOU-YZM209-CSGameProject-Minesweeper?tab=readme-ov-file#karşılanan-beklentiler)
- [İndirme ve Çalıştırma](https://github.com/metehansenyer/KOU-YZM209-CSGameProject-Minesweeper?tab=readme-ov-file#i%CC%87ndirme-ve-%C3%A7al%C4%B1%C5%9Ft%C4%B1rma)
- [Teşekkürler](https://github.com/metehansenyer/KOU-YZM209-CSGameProject-Minesweeper?tab=readme-ov-file#teşekkürler)
- [Oynanış Videosu](https://github.com/metehansenyer/KOU-YZM209-CSGameProject-Minesweeper?tab=readme-ov-file#oynan%C4%B1%C5%9F-videosu)

## Kullanılan Araçlar

<p align="center">
  <a href="https://learn.microsoft.com/tr-tr/dotnet/csharp/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/ca28c779441053191ff11710fe24a9e6c23690d6/icons/csharp/csharp-original.svg" alt="csharp" width="40" height="40"/> </a>
  <a href="https://learn.microsoft.com/en-us/dotnet/desktop/winforms/" target="_blank" rel="noreferrer"> <img src="https://upload.wikimedia.org/wikipedia/commons/3/37/WinForms_Logo.png" alt="winforms" width="40" height="40"/> </a>
  <a href="https://dotnet.microsoft.com/en-us/" target="_blank" rel="noreferrer"> <img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/dot-net/dot-net-plain-wordmark.svg" alt="dotnet" width="40" height="40"/> </a>
  <a href="https://visualstudio.microsoft.com/tr/" target="_blank" rel="noreferrer"> <img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/visualstudio/visualstudio-original.svg" alt="visualstudio" width="40" height="40"/> </a>
</p>

- Oyunun yapımında sadece C# dili kullanılmıtır.
- Geliştirme sürecinde Microsoft'un Visual Studio yazılımı kullanılmıştır.
- WinForms uygulaması olarak geliştirildi.
- Windos işletim sisteminde test edildi.

| Kullanılan Araç | Tavsiye Linkler |
|:---:|:---:|
| C# | [Microsoft](https://learn.microsoft.com/tr-tr/collections/yz26f8y64n7k07) |
| C# | [Murat Yücedağ C# Eğitim Kampı](https://youtube.com/playlist?list=PLKnjBHu2xXNPmFMvGKVHA_ijjrgUyNIXr&si=gL6c-oeP9LUJCN2u) |
| WinForms | [Winforms C# Tutorials](https://youtube.com/playlist?list=PLp_RsiLZjwQRqemuY82VEYvgyJ7uI04sm&si=xe6qiGXioaBvPOZn) |
| Minesweeper | [Referans Oyun](https://www.google.com/fbx?fbx=minesweeper) |

## Amaç

YZM209 dersi kapsamında, bugüne kadar öğrendiğimiz bilgiler ve C# dili kullanılarak, bir Mayın Tarlası Oyunu geliştirmek hedeflenmektedir. Bu proje, algoritma geliştirme ve kullanıcı arayüzü tasarımı konularında öğrencilerin becerilerini pekiştirmeyi amaçlamaktadır.

## Projeden Beklenenler

```json
{  
  "Anahtar Özellikler": {  
    "Mayın Yerleşimi": "Mayınların başlangıçta rastgele yerleştirilmesi.",  
    "Hücre İşlemleri": "Sol tıkla hücre açma, sağ tıkla bayrak koyma.",  
    "Oyun Bitişi": "Mayına tıklanması ya da tüm mayınsız hücrelerin açılması durumunda oyunun bitirilmesi.",  
    "Skor Hesaplama": "Bayrakların doğruluğu ve geçen süreye göre skor hesaplanması."  
  },  
  "Sınıflar ve Özellikleri": {  
    "Oyun": {  
      "Özellikler": [  
        "Grid boyutları.",  
        "Mayınların konumu.",  
        "Oyuncu adı ve skor bilgileri."  
      ],  
      "Metotlar": [  
        "StartGame(): Oyunu başlatır.",  
        "PlaceMines(): Mayınları rastgele yerleştirir.",  
        "OpenCell(): Hücreyi açar ve gerekli işlemleri yapar.",  
        "EndGame(): Oyun bitiş işlemlerini yönetir."  
      ]  
    },  
    "Skorboard": {  
      "Özellikler": [  
        "En iyi 10 oyuncunun skorları."  
      ],  
      "Metotlar": [  
        "UpdateScores(): Skorları günceller.",  
        "DisplayScores(): Skorları kullanıcıya gösterir."  
      ]  
    }  
  },  
  "Ek İşlevsellikler": {  
    "Otomatik Açılma": "Komşu hücrelerde mayın yoksa hücrelerin otomatik açılması.",  
    "Hamle Sayacı": "Yapılan hamlelerin sayısını gösteren sayaç.",  
    "Kullanıcı Bilgileri": "Arayüzde oyuncu adı ve geliştirici bilgileri."  
  },  
  "Görsel ve Teknik Gereklilikler": {  
    "GUI": "Grafiksel kullanıcı arayüzü oluşturulması.",  
    "Dil": "C# programlama dili kullanılması.",  
    "Raporlama": "Proje kodlarının ve açıklamalarının raporlanması."  
  }  
}  
```

## Karşılanan Beklentiler

| Beklenti | Durum | Detay |
|:---:|:---:|:---:|
| Anahtar Özellikler | ✅ | Tüm anahtar özellikler sağlanmıştır. |
| Sınıflar ve Özellikleri | ✅ | Tüm anahtar özellikler sağlanmıştır. |
| Ek İşlevsellikler | ✅ | Otomatik açılma ve hamle sayacı gibi ek özellikler tamamlanmıştır. |
| Görsel ve Teknik Gereklilikler | ✅ | Grafiksel arayüz ve raporlama işlemleri başarıyla yapılmıştır. |

## İndirme ve Çalıştırma

[Bu bağlantıyı](https://github.com/metehansenyer/KOU-YZM209-CSGameProject-Minesweeper/archive/refs/heads/main.zip) kullanarak kaynak dosyaları indirebilir ve projemizi yerel olarak çalıştırabilirsiniz. Git üzerinden indirmek isterseniz:
```
https://github.com/metehansenyer/KOU-YZM209-CSGameProject-Minesweeper.git
```

> [!IMPORTANT]  
> Proje WinForms kullanması sebebiyle sadece Windows platformunda çalışmaktadır.

## Teşekkürler

Zor şartlar altındaki proje sunumumdaki yardımlarından dolayı Kocaeli Üniversitesi Yazılım Mühendisliği Bölümü'den Araştırma Görevlisi Melike Bektaş Kösesoy ve Araştırma Görevlisi Şevval Şolpan hocama teşekkürlerimi arz ederim.

## Oynanış Videosu

https://github.com/user-attachments/assets/e0387de4-4ae9-48e1-a83f-5686828ad200
