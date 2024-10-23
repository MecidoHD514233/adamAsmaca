using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adamAsmacaSon
{
    using System;
    using System.Collections.Generic;

    class AdamAsmaca8
    {
        static void Main()
        {
            // Şehir listesi
            List<string> sehirler = new List<string>  {
            "adana", "adıyaman", "afyonkarahisar", "ağrı", "aksaray", "amasya", "ankara", "antalya", "ardahan", "artvin",
            "aydın", "balıkesir", "bartın", "batman", "bayburt", "bilecik", "bingöl", "bitlis", "bolu", "burdur",
            "bursa", "çanakkale", "çankırı", "çorum", "denizli", "diyarbakır", "düzce", "edirne", "elazığ", "erzincan",
            "erzurum", "eskişehir", "gaziantep", "giresun", "gümüşhane", "hakkari", "hatay", "ığdır", "isparta", "istanbul",
            "izmir", "kahramanmaraş", "karabük", "karaman", "kars", "kastamonu", "kayseri", "kırıkkale", "kırklareli", "kırşehir",
            "kilis", "kocaeli", "konya", "kütahya", "malatya", "manisa", "mardin", "mersin", "muğla", "muş",
            "nevşehir", "niğde", "ordu", "osmaniye", "rize", "sakarya", "samsun", "siirt", "sinop", "sivas",
            "şanlıurfa", "şırnak", "tekirdağ", "tokat", "trabzon", "tunceli", "uşak", "van", "yalova", "yozgat", "zonguldak"
        };


            //Bilgisayar rastgele bir şehir atar
            Random rnd = new Random();
            string secilenSehir = sehirler[rnd.Next(sehirler.Count)];

            // Tahmin durumunu gösteren dizi
            char[] tahminDurumu = new string('_', secilenSehir.Length).ToCharArray();

            //Yapılan hata ve Kalan tahmin sayacı
            int kalanHak = 5;
            List<char> yanlisTahminler = new List<char>();

            // Genel döngü
            while (kalanHak > 0 && new string(tahminDurumu) != secilenSehir)
            {
                Console.Clear();
                Console.WriteLine("Adam Asmaca - Şehir Tahmini");
                Console.WriteLine($"Kalan Hakkınız: {kalanHak}");
                Console.WriteLine($"Yanlış Harfler: {string.Join(", ", yanlisTahminler)}");
                Console.WriteLine($"Tahmin Durumu: {new string(tahminDurumu)}");
                Console.WriteLine("Bir harf ya da tüm şehri tahmin edin:");

                // Kullanıcıdan tahmini alma
                string tahmin = Console.ReadLine().ToLower();

                if (string.IsNullOrEmpty(tahmin)) continue;

                if (tahmin.Length > 1)  // Şehir tahmini
                {
                    if (tahmin == secilenSehir)
                    {
                        tahminDurumu = secilenSehir.ToCharArray();  // Tahmin doğruysa 
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Yanlış şehir tahmini!");// Tahmin yanlışsa
                        kalanHak--;
                    }
                }
                else  // Harf tahmini
                {
                    char tahminHarf = tahmin[0];
                    if (secilenSehir.Contains(tahminHarf))
                    {
                        for (int i = 0; i < secilenSehir.Length; i++)
                        {
                            if (secilenSehir[i] == tahminHarf) //  Harf doğru ise
                            {
                                tahminDurumu[i] = tahminHarf; 
                            }
                        }
                    }
                    else
                    {
                        if (!yanlisTahminler.Contains(tahminHarf))  //Harf yanlış ise
                        {
                            yanlisTahminler.Add(tahminHarf);
                            kalanHak--;
                        }
                    }
                }
            }

            // Döngü sonu sonuç belirleme
            if (new string(tahminDurumu) == secilenSehir)
            {
                Console.WriteLine($"Tebrikler! Şehri doğru tahmin ettiniz: {secilenSehir}");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Kaybettiniz! Doğru şehir: {secilenSehir}");
                Console.ReadLine();
            }
        }
    }
}