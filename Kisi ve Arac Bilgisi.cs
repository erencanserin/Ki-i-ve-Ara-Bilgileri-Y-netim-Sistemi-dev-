using System;
using System.Collections.Generic;

// Araç türleri için enum
public enum AracTurleri
{
    Taksi,
    Kamyon,
    Otobus,
    Otomobil
}

// Araç sınıfı
public class Arac
{
    public string SasiNumarasi { get; set; }
    public AracTurleri Tur { get; set; }
    public string Model { get; set; }
    public int Yil { get; set; }
    public string Marka { get; set; }
    public DateTime EdinmeTarihi { get; set; }
    public decimal EdinmeFiyati { get; set; }
    public List<Kisi> Sahipler { get; set; }

    public Arac(string sasiNumarasi, AracTurleri tur, string model, int yil, string marka, DateTime edinmeTarihi, decimal edinmeFiyati)
    {
        SasiNumarasi = sasiNumarasi;
        Tur = tur;
        Model = model;
        Yil = yil;
        Marka = marka;
        EdinmeTarihi = edinmeTarihi;
        EdinmeFiyati = edinmeFiyati;
        Sahipler = new List<Kisi>();
    }

    // Araç sahibini ekler
    public void SahipEkle(Kisi sahip)
    {
        Sahipler.Add(sahip);
    }

    // Araç bilgilerini listeler
    public void AracBilgileriniListele()
    {
        var oncekiSahip = Sahipler.Count > 1 ? Sahipler[Sahipler.Count - 2] : null;
        Console.WriteLine($"Şasi Numarası: {SasiNumarasi}");
        Console.WriteLine($"Sahibi: {Sahipler[^1].Adi} {Sahipler[^1].Soyadi} (TC: {FormatTC(Sahipler[^1].TCKimlikNumarasi)})");
        Console.WriteLine($"Edinme Tarihi: {EdinmeTarihi.ToShortDateString()}");
        Console.WriteLine($"Model Yılı: {Yil}");
        if (oncekiSahip != null)
        {
            Console.WriteLine($"Önceki Sahibi: {oncekiSahip.Adi} {oncekiSahip.Soyadi} (TC: {FormatTC(oncekiSahip.TCKimlikNumarasi)})");
        }
        Console.WriteLine();
    }

    // TC kimlik numarasını gizler
    private string FormatTC(string tc)
    {
        if (tc.Length == 11)
        {
            return $"{tc.Substring(0, 2)}****{tc.Substring(6, 1)}";
        }
        return "Geçersiz TC";
    }
}

// Kişi sınıfı
public class Kisi
{
    public string Adi { get; set; }
    public string Soyadi { get; set; }
    public int DogumYili { get; set; }
    public string TCKimlikNumarasi { get; set; }

    public Kisi(string adi, string soyadi, int dogumYili, string tcKimlikNumarasi)
    {
        Adi = adi;
        Soyadi = soyadi;
        DogumYili = dogumYili;
        TCKimlikNumarasi = tcKimlikNumarasi;
    }
}

// Ana program sınıfı
public class Program
{
    static void Main(string[] args)
    {
        // Araç sahiplerinin bilgileri manuel olarak dolduruluyor
        Kisi kisi1 = new Kisi("Murat", "Taşyürek", 1985, "12345678901"); // 4. sahibi
        Kisi kisi2 = new Kisi("Ali", "Yılmaz", 1990, "23456789012");     // 5. sahibi
        Kisi kisi3 = new Kisi("Ayşe", "Kara", 1988, "34567890123");      // 6. sahibi
        Kisi kisi4 = new Kisi("Mehmet", "Demir", 1980, "45678901234");   // 3. sahibi

        // Araç bilgilerini manuel olarak doldur
        Arac arac1 = new Arac("A1234", AracTurleri.Otomobil, "Toyota Corolla", 2020, "Toyota", new DateTime(2020, 1, 1), 150000);
        arac1.SahipEkle(kisi4);  // 1. sahip
        arac1.SahipEkle(kisi3);  // 2. sahip
        arac1.SahipEkle(kisi2);  // 3. sahip
        arac1.SahipEkle(kisi1);  // 4. sahip

        Arac arac2 = new Arac("B5678", AracTurleri.Taksi, "Mercedes-Benz", 2019, "Mercedes", new DateTime(2019, 5, 1), 300000);
        arac2.SahipEkle(kisi4);  // 1. sahip
        arac2.SahipEkle(kisi3);  // 2. sahip
        arac2.SahipEkle(kisi2);  // 3. sahip
        arac2.SahipEkle(kisi1);  // 4. sahip

        Arac arac3 = new Arac("C91011", AracTurleri.Kamyon, "Volvo FH", 2021, "Volvo", new DateTime(2021, 10, 1), 800000);
        arac3.SahipEkle(kisi4);  // 1. sahip
        arac3.SahipEkle(kisi3);  // 2. sahip
        arac3.SahipEkle(kisi2);  // 3. sahip
        arac3.SahipEkle(kisi1);  // 4. sahip

        Arac arac4 = new Arac("D12131", AracTurleri.Otobus, "Scania", 2022, "Scania", new DateTime(2022, 8, 1), 1200000);
        arac4.SahipEkle(kisi4);  // 1. sahip
        arac4.SahipEkle(kisi3);  // 2. sahip
        arac4.SahipEkle(kisi1);  // 3. sahip

        // Araçları listeleme
        Console.WriteLine("\nKişi arabalarımı listele:");
        arac1.AracBilgileriniListele();
        arac2.AracBilgileriniListele();
        arac3.AracBilgileriniListele();
        arac4.AracBilgileriniListele();
    }
}
