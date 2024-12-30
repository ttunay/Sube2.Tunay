using System.Drawing;

namespace Sube2.Tunay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ogrenciSayisi;

            while (true)
            {
                try
                {
                    Console.Write("Kaç öğrenci kaydetmek istiyorsunuz? ");
                    ogrenciSayisi = int.Parse(Console.ReadLine().Trim());

                    if (ogrenciSayisi <= 0)
                    {
                        Console.WriteLine("Öğrenci sayısı sıfır veya negatif girilemez.");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Lütfen sadece sayı giriniz.");
                }
            }

            int[] numara = new int[ogrenciSayisi];
            string[] ad = new string[ogrenciSayisi];
            string[] soyad = new string[ogrenciSayisi];
            int[] vizeNotu = new int[ogrenciSayisi];
            int[] finalNotu = new int[ogrenciSayisi];
            double[] ortalama = new double[ogrenciSayisi];
            string[] harfNotu = new string[ogrenciSayisi];

            for (int i = 0; i < ogrenciSayisi; i++)
            {
                Console.WriteLine($"\nÖğrenci({i + 1}) için istenilen bilgileri giriniz.");

                while (true)
                {
                    try
                    {
                        Console.Write("\nNumara: ");
                        numara[i] = int.Parse(Console.ReadLine().Trim());

                        if (numara[i] <= 0)
                        {
                            Console.WriteLine("Öğrenci numarası sıfır veya negatif girilemez.");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Lütfen sadece sayı giriniz.");
                    }
                }
                
                Console.Write("Ad: ");
                ad[i] = Console.ReadLine().Trim().ToUpper();

                Console.Write("Soyad: ");
                soyad[i] = Console.ReadLine().Trim().ToUpper();

                while (true)
                {
                    try
                    {
                        Console.Write("Vize Notu (0-100): ");
                        int vize = int.Parse(Console.ReadLine().Trim());

                        if (vize < 0 || vize > 100)
                        {
                            Console.WriteLine("Vize notu 0 ile 100 arasında girilmelidir.");
                        }
                        else
                        {
                            vizeNotu[i] = vize;
                            break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Lütfen sadece sayı giriniz.");
                    }
                }

                while (true)
                {
                    try
                    {
                        Console.Write("Final Notu (0-100): ");
                        int final = int.Parse(Console.ReadLine().Trim());

                        if (final < 0 || final > 100)
                        {
                            Console.WriteLine("Final notu 0 ile 100 arasında girilmelidir.");
                        }
                        else
                        {
                            finalNotu[i] = final;
                            break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Lütfen sadece sayı giriniz.");
                    }
                }

                ortalama[i] = (vizeNotu[i] * 0.4) + (finalNotu[i] * 0.6);

                if (ortalama[i] >= 85 && ortalama[i] <= 100) harfNotu[i] = "AA";
                else if (ortalama[i] >= 75 && ortalama[i] <= 84) harfNotu[i] = "BA";
                else if (ortalama[i] >= 60 && ortalama[i] <= 74) harfNotu[i] = "BB";
                else if (ortalama[i] >= 50 && ortalama[i] <= 59) harfNotu[i] = "CB";
                else if (ortalama[i] >= 40 && ortalama[i] <= 49) harfNotu[i] = "CC";
                else if (ortalama[i] >= 30 && ortalama[i] <= 39) harfNotu[i] = "DC";
                else if (ortalama[i] >= 20 && ortalama[i] <= 29) harfNotu[i] = "DD";
                else if (ortalama[i] >= 10 && ortalama[i] <= 19) harfNotu[i] = "FD";
                else harfNotu[i] = "FF";
            }

            double toplamOrtalama = 0;
            for (int i = 0; i < ogrenciSayisi; i++)
            {
                toplamOrtalama += ortalama[i];
            }

            double[] siraliOrtalamalar = new double[ogrenciSayisi];
            for (int i = 0; i < ogrenciSayisi; i++)
            {
                siraliOrtalamalar[i] = ortalama[i];
            }
            Array.Sort(siraliOrtalamalar);

            double sinifOrtalamasi = toplamOrtalama / ogrenciSayisi;

            double enDusuk = siraliOrtalamalar[0];
            double enYuksek = siraliOrtalamalar[ogrenciSayisi - 1];

            Console.WriteLine("\nTablo:");
            Console.WriteLine(string.Format("{0,-12} {1,-8} {2,-11} {3,-14} {4,-15} {5,-14} {6,-14}", "Numara", "Ad", "Soyad", "VizeNotu", "FinalNotu", "Ortalama", "HarfNotu"));

            for (int i = 0; i < ogrenciSayisi; i++)
            {
                Console.WriteLine(string.Format("{0,-12} {1,-8} {2,-11} {3,-14} {4,-15} {5,-14} {6,-14}",
                    numara[i], ad[i], soyad[i], vizeNotu[i], finalNotu[i], ortalama[i], harfNotu[i]));
            }

            Console.WriteLine($"\nSınıf Ortalaması: {sinifOrtalamasi}");
            Console.WriteLine($"En Düşük Not: {enDusuk}");
            Console.WriteLine($"En Yüksek Not: {enYuksek}");

        }
    }
}