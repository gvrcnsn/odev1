using System;
using System.Collections.Generic;

class Program
{
    class Ogrenci
    {
        public long Numara { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int VizeNotu { get; set; }
        public int FinalNotu { get; set; }
        public double Ortalama { get; set; }
        public string HarfNotu { get; set; }
    }

    static void Main(string[] args)
    {
        Console.Write("Kaç öğrenci kaydetmek istiyorsunuz: ");
        int ogrenciSayisi = int.Parse(Console.ReadLine());

        Ogrenci[] ogrenciler = new Ogrenci[ogrenciSayisi];

        for (int i = 0; i < ogrenciSayisi; i++)
        {
            Ogrenci ogrenci = new Ogrenci();

            Console.WriteLine($"{i + 1}.Öğrencinin Numarasını giriniz:");
            ogrenci.Numara = long.Parse(Console.ReadLine());

            Console.WriteLine($"{i + 1}.Öğrencinin Adını giriniz:");
            ogrenci.Ad = Console.ReadLine();

            Console.WriteLine($"{i + 1}.Öğrencinin Soyadını giriniz:");
            ogrenci.Soyad = Console.ReadLine();

            while (true)
            {
                Console.WriteLine($"{i + 1}.Öğrencinin Vize notunu giriniz:");
                int vizeNotu = int.Parse(Console.ReadLine());
                if (vizeNotu >= 0 && vizeNotu <= 100)
                {
                    ogrenci.VizeNotu = vizeNotu;
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz not. Lütfen 0-100 aralığında bir değer giriniz.");
                }
            }

            while (true)
            {
                Console.WriteLine($"{i + 1}.Öğrencinin Final notunu giriniz:");
                int finalNotu = int.Parse(Console.ReadLine());
                if (finalNotu >= 0 && finalNotu <= 100)
                {
                    ogrenci.FinalNotu = finalNotu;
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz not. Lütfen 0-100 aralığında bir değer giriniz.");
                }
            }

            ogrenci.Ortalama = (ogrenci.VizeNotu * 0.4) + (ogrenci.FinalNotu * 0.6);

            if (ogrenci.Ortalama >= 90)
                ogrenci.HarfNotu = "A";
            else if (ogrenci.Ortalama >= 80)
                ogrenci.HarfNotu = "B";
            else if (ogrenci.Ortalama >= 70)
                ogrenci.HarfNotu = "C";
            else if (ogrenci.Ortalama >= 60)
                ogrenci.HarfNotu = "D";
            else
                ogrenci.HarfNotu = "F";

            ogrenciler[i] = ogrenci;
        }

        double toplamOrtalama = 0;
        double enYuksekNot = double.MinValue;
        double enDusukNot = double.MaxValue;

        for (int i = 0; i < ogrenciSayisi; i++)
        {
            toplamOrtalama += ogrenciler[i].Ortalama;

            if (ogrenciler[i].Ortalama > enYuksekNot)
            {
                enYuksekNot = ogrenciler[i].Ortalama;
            }

            if (ogrenciler[i].Ortalama < enDusukNot)
            {
                enDusukNot = ogrenciler[i].Ortalama;
            }
        }

        double sinifOrtalamasi = toplamOrtalama / ogrenciSayisi;

        Console.WriteLine("\nÖğrencilerin Listesi:");
        for (int i = 0; i < ogrenciSayisi; i++)
        {
            Console.WriteLine($"Numara: {ogrenciler[i].Numara}, Ad: {ogrenciler[i].Ad}, Soyad: {ogrenciler[i].Soyad}, Vize Notu: {ogrenciler[i].VizeNotu}, Final Notu: {ogrenciler[i].FinalNotu}, Ortalama: {ogrenciler[i].Ortalama:F2}, Harf Notu: {ogrenciler[i].HarfNotu}");
        }

        Console.WriteLine($"\nSınıf Ortalaması: {sinifOrtalamasi:F2}");
        Console.WriteLine($"En Yüksek Ortalama: {enYuksekNot:F2}");
        Console.WriteLine($"En Düşük Ortalama: {enDusukNot:F2}");
    }
}
