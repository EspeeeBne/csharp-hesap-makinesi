using System;
using System.Collections.Generic;

namespace HesapMakinesi
{
    class Program
    {
        static void Main(string[] args)
        {
            bool devam = true;
            List<string> islemGecmisi = new List<string>();

            while (devam)
            {
                Console.WriteLine("Hesap Makinesi\n");
                Console.WriteLine("Yapmak istediğiniz işlemi seçin:");
                Console.WriteLine("1. Toplama");
                Console.WriteLine("2. Çıkarma");
                Console.WriteLine("3. Çarpma");
                Console.WriteLine("4. Bölme");
                Console.WriteLine("5. Üs Alma");
                Console.WriteLine("6. Karekök Alma");
                Console.WriteLine("7. Ortalama Hesaplama");
                Console.WriteLine("8. Faktoriyel Hesaplama");
                Console.WriteLine("9. Geçmiş İşlemleri Görüntüle");
                Console.WriteLine("Çıkmak için q'ya basın\n");

                Console.Write("Seçiminizi yapın: ");
                string secim = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(secim))
                {
                    Console.WriteLine("Hata: Boş giriş yaptınız, lütfen geçerli bir işlem seçin.\n");
                    continue;
                }

                if (secim.ToLower() == "q")
                {
                    devam = false;
                    break;
                }

                double sonuc = 0;
                bool gecerliIslem = true;

                switch (secim)
                {
                    case "1":
                        Console.Write("Birinci sayıyı girin: ");
                        double sayi1 = GetValidDoubleInput();

                        Console.Write("İkinci sayıyı girin: ");
                        double sayi2 = GetValidDoubleInput();

                        sonuc = sayi1 + sayi2;
                        islemGecmisi.Add($"{sayi1} + {sayi2} = {sonuc}");
                        break;
                    case "2":
                        Console.Write("Birinci sayıyı girin: ");
                        sayi1 = GetValidDoubleInput();

                        Console.Write("İkinci sayıyı girin: ");
                        sayi2 = GetValidDoubleInput();

                        sonuc = sayi1 - sayi2;
                        islemGecmisi.Add($"{sayi1} - {sayi2} = {sonuc}");
                        break;
                    case "3":
                        Console.Write("Birinci sayıyı girin: ");
                        sayi1 = GetValidDoubleInput();

                        Console.Write("İkinci sayıyı girin: ");
                        sayi2 = GetValidDoubleInput();

                        sonuc = sayi1 * sayi2;
                        islemGecmisi.Add($"{sayi1} * {sayi2} = {sonuc}");
                        break;
                    case "4":
                        Console.Write("Birinci sayıyı girin: ");
                        sayi1 = GetValidDoubleInput();

                        Console.Write("İkinci sayıyı girin: ");
                        sayi2 = GetValidDoubleInput();

                        if (sayi2 != 0)
                        {
                            sonuc = sayi1 / sayi2;
                            islemGecmisi.Add($"{sayi1} / {sayi2} = {sonuc}");
                        }
                        else
                        {
                            Console.WriteLine("Hata: Bir sayı sıfıra bölünemez.\n");
                            gecerliIslem = false;
                        }
                        break;
                    case "5":
                        Console.Write("Taban sayıyı girin: ");
                        sayi1 = GetValidDoubleInput();

                        Console.Write("Üs değerini girin: ");
                        double us = GetValidDoubleInput();

                        sonuc = Math.Pow(sayi1, us);
                        islemGecmisi.Add($"{sayi1} ^ {us} = {sonuc}");
                        break;
                    case "6":
                        Console.Write("Sayıyı girin: ");
                        sayi1 = GetValidDoubleInput();

                        if (sayi1 >= 0)
                        {
                            sonuc = Math.Sqrt(sayi1);
                            islemGecmisi.Add($"√{sayi1} = {sonuc}");
                        }
                        else
                        {
                            Console.WriteLine("Hata: Negatif bir sayının karekökü alınamaz.\n");
                            gecerliIslem = false;
                        }
                        break;
                    case "7":
                        Console.Write("Kaç sayı gireceksiniz?: ");
                        int adet = Convert.ToInt32(GetValidDoubleInput());
                        double toplam = 0;

                        for (int i = 1; i <= adet; i++)
                        {
                            Console.Write($"{i}. sayıyı girin: ");
                            toplam += GetValidDoubleInput();
                        }

                        sonuc = toplam / adet;
                        islemGecmisi.Add($"Girilen {adet} sayının ortalaması = {sonuc}");
                        break;
                    case "8":
                        Console.Write("Faktoriyelini almak istediğiniz sayıyı girin: ");
                        int faktoriyelSayisi = Convert.ToInt32(GetValidDoubleInput());
                        sonuc = 1;

                        for (int i = 1; i <= faktoriyelSayisi; i++)
                        {
                            sonuc *= i;
                        }

                        islemGecmisi.Add($"{faktoriyelSayisi}! = {sonuc}");
                        break;
                    case "9":
                        Console.WriteLine("Geçmiş İşlemler:");
                        foreach (string islem in islemGecmisi)
                        {
                            Console.WriteLine(islem);
                        }
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim. Lütfen 1-9 arasında bir seçim yapın.\n");
                        gecerliIslem = false;
                        break;
                }

                if (gecerliIslem && secim != "9")
                {
                    Console.WriteLine($"Sonuç: {sonuc}\n");
                }
            }

            Console.WriteLine("Programdan çıkılıyor. Görüşürüz!");
        }

        static double GetValidDoubleInput()
        {
            double sayi;
            string giris;

            while (true)
            {
                giris = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(giris) && double.TryParse(giris, out sayi))
                {
                    return sayi;
                }
                else
                {
                    Console.Write("Hata: Geçerli bir sayı girin: ");
                }
            }
        }
    }
}