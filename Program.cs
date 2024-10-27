using System;
using System.Collections.Generic;

namespace egtm1a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Araba Yönetim Sistemine Hoş Geldiniz!");
            bool girisBasarili = KullaniciGirisi();

            if (girisBasarili)
            {
                Console.WriteLine("\nGiriş Başarılı! Araba Yönetim Sistemine Hoş Geldiniz.");
                ArabaYonetimSistemi();
            }
            else
            {
                Console.WriteLine("Giriş başarısız. Programdan çıkılıyor...");
            }
        }
        static bool KullaniciGirisi()
        {
            const string dogruKullaniciAdi = "alpy";
            const string dogruSifre = "alpy54";
            int denemeHakki = 3;


            while (denemeHakki > 0)
            {
                Console.Write("Kullanıcı Adı: ");
                string kullaniciAdi = Console.ReadLine();

                Console.Write("Şifre: ");
                string sifre = Console.ReadLine();

                if (kullaniciAdi == dogruKullaniciAdi && sifre == dogruSifre)
                {
                    return true;
                }
                else
                {
                    denemeHakki--;
                    Console.WriteLine($"Hatalı giriş! Kalan deneme hakkınız: {denemeHakki}");
                }
            }
            return false;
        }
        static void ArabaYonetimSistemi()
        {
            List<Araba> arabaListesi = new List<Araba>();
            string[] arabaTurleri = { "Sedan", "Hatchbak", "SUV", "Cabrio" };

            while (true)
            {
                Console.WriteLine("\nAraba Yönetim Sistemi");
                Console.WriteLine("1. Araba Ekle");
                Console.WriteLine("2. Arabaları Listele");
                Console.WriteLine("3. Araba Türlerini Göster");
                Console.WriteLine("4. Çıkış");
                Console.Write("Bir seçenek girin (1-4): ");

                int secim;
                while (!int.TryParse(Console.ReadLine(), out secim) || secim < 1 || secim > 4)
                {
                    Console.Write("Geçersiz seçim! Lütfen 1-4 arasında bir sayı girin: ");
                }

                switch (secim)
                {
                    case 1:
                        Console.WriteLine("\nYeni Araba Bilgileri:");
                        Araba yeniAraba = ArabaBilgisiAl();
                        arabaListesi.Add(yeniAraba);
                        break;

                    case 2:
                        ArabalariListele(arabaListesi);
                        break;

                    case 3:
                        Console.WriteLine("\nMevcut Araba Türleri:");
                        foreach (string tur in arabaTurleri)
                        {
                            Console.WriteLine("- " + tur);
                        }
                        break;

                    case 4:
                        Console.WriteLine("Programdan çıkılıyor...");
                        return;

                    default:
                        Console.WriteLine("Geçersiz İŞLEM 1-4 Arasında değer girin.");
                        break;
                }
            }
        }
        static Araba ArabaBilgisiAl()
        {
            Console.Write("Araba Markası: ");
            string marka = Console.ReadLine();

            while (string.IsNullOrEmpty(marka))
            {
                Console.Write("Geçresi giriş. Lütfen geçerli marka adı giriniz: ");
                marka = Console.ReadLine();
            }

            Console.Write("Araba Modeli: ");
            string model = Console.ReadLine();

            int yil;
            Console.Write("Üretim Yılı: ");
            while (!int.TryParse(Console.ReadLine(), out yil))
            {
                Console.Write("Geçresi giriş. Lütfen bir sayı girin: ");
            }

            return new Araba(marka, model, yil);
        }
        static void ArabalariListele(List<Araba> arabaListesi)
        {
            if (arabaListesi == null || arabaListesi.Count == 0)
            {
                Console.WriteLine("Listede araba yok.");
                return;
            }

            Console.WriteLine("\nEklenen Arabalar:");
            foreach (Araba araba in arabaListesi)
            {
                araba.BilgiYazdir ();
            }
        }
    }
    class Araba
    {
        public string Marka;
        public string Model;
        public int UretimYili;

        public Araba(string marka, string model, int uretimYili)
        {
            Marka = marka;
            Model = model;
            UretimYili = uretimYili;
        }

       

        public void BilgiYazdir()
        {
            Console.WriteLine($"Marka: {Marka}, Model: {Model}, Üretim Yılı: {UretimYili}");
        }
    }
}


