using System;
using System.Collections.Generic;

// Ara� t�rleri i�in enum
public enum AracTurleri
{
    Taksi,
    Kamyon,
    Otobus,
    Otomobil
}

// Ara� s�n�f�
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

    // Ara� sahibini ekler
    public void SahipEkle(Kisi sahip)
    {
        Sahipler.Add(sahip);
    }

    // Ara� bilgilerini listeler
    public void AracBilgileriniListele()
    {
        var oncekiSahip = Sahipler.Count > 1 ? Sahipler[Sahipler.Count - 2] : null;
        Console.WriteLine($"�asi Numaras�: {SasiNumarasi}");
        Console.WriteLine($"Sahibi: {Sahipler[^1].Adi} {Sahipler[^1].Soyadi} (TC: {FormatTC(Sahipler[^1].TCKimlikNumarasi)})");
        Console.WriteLine($"Edinme Tarihi: {EdinmeTarihi.ToShortDateString()}");
        Console.WriteLine($"Model Y�l�: {Yil}");
        if (oncekiSahip != null)
        {
            Console.WriteLine($"�nceki Sahibi: {oncekiSahip.Adi} {oncekiSahip.Soyadi} (TC: {FormatTC(oncekiSahip.TCKimlikNumarasi)})");
        }
        Console.WriteLine();
    }

    // TC kimlik numaras�n� gizler
    private string FormatTC(string tc)
    {
        if (tc.Length == 11)
        {
            return $"{tc.Substring(0, 2)}****{tc.Substring(6, 1)}";
        }
        return "Ge�ersiz TC";
    }
}

// Ki�i s�n�f�
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

// Ana program s�n�f�
public class Program
{
    static void Main(string[] args)
    {
        List<Arac> araclar = new List<Arac>();

        Console.WriteLine("Ka� adet ara� girmek istiyorsunuz?");
        int aracSayisi = int.Parse(Console.ReadLine());

        for (int i = 0; i < aracSayisi; i++)
        {
            Console.WriteLine($"\n{i + 1}. ara� bilgilerini girin:");

            Console.Write("�asi Numaras�: ");
            string sasiNumarasi = Console.ReadLine();

            Console.Write("Ara� T�r� (Taksi, Kamyon, Otobus, Otomobil): ");
            AracTurleri tur = (AracTurleri)Enum.Parse(typeof(AracTurleri), Console.ReadLine());

            Console.Write("Model: ");
            string model = Console.ReadLine();

            Console.Write("Y�l: ");
            int yil = int.Parse(Console.ReadLine());

            Console.Write("Marka: ");
            string marka = Console.ReadLine();

            Console.Write("Edinme Tarihi (GG/AA/YYYY): ");
            DateTime edinmeTarihi = DateTime.Parse(Console.ReadLine());

            Console.Write("Edinme Fiyat�: ");
            decimal edinmeFiyati = decimal.Parse(Console.ReadLine());

            Arac arac = new Arac(sasiNumarasi, tur, model, yil, marka, edinmeTarihi, edinmeFiyati);

            Console.Write("Ka� adet sahip gireceksiniz? ");
            int sahipSayisi = int.Parse(Console.ReadLine());

            for (int j = 0; j < sahipSayisi; j++)
            {
                Console.WriteLine($"\n{j + 1}. sahibin bilgilerini girin:");

                Console.Write("Ad�: ");
                string ad = Console.ReadLine();

                Console.Write("Soyad�: ");
                string soyad = Console.ReadLine();

                Console.Write("Do�um Y�l�: ");
                int dogumYili = int.Parse(Console.ReadLine());

                Console.Write("TC Kimlik Numaras�: ");
                string tcKimlik = Console.ReadLine();

                Kisi sahip = new Kisi(ad, soyad, dogumYili, tcKimlik);
                arac.SahipEkle(sahip);
            }

            araclar.Add(arac);
        }

        Console.WriteLine("\nAra�lar listeleniyor:\n");
        foreach (var arac in araclar)
        {
            arac.AracBilgileriniListele();
        }
    }
}