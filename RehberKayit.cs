using System.Collections.Generic;
using System.Linq;

namespace TelefonRehberi
{
    public static class RehberKayit
    {
        private static List<Kisi> kisiListesi = new List<Kisi>();

        static RehberKayit()
        {
            kisiListesi.AddRange( new List<Kisi> {
                new Kisi { Ad = "Doğan", Soyad = "Yaman", TelefonNumarasi = "05351111111" },
                new Kisi { Ad = "Ayşe", Soyad = "Arda", TelefonNumarasi = "05352222222" },
                new Kisi { Ad = "Ahmet", Soyad = "Yeşiltepe", TelefonNumarasi = "05353333333" },
                new Kisi { Ad = "Zikriye", Soyad = "Ürkmez", TelefonNumarasi = "05354444444" },
                new Kisi { Ad = "Mehmet", Soyad = "Güleryüz", TelefonNumarasi = "05355555555" }
            });

        }

        public static void KisiEkle(Kisi kisi)
        {
            kisiListesi.Add(kisi);
        }

        public static bool KisiSil(Kisi kisi)
        {
            return kisiListesi.Remove(kisi);
        }

        public static void KisiGuncelle(string adVeyaSoyad, Kisi kisiYeni)
        {
            Kisi kisi = KisiBulAdVeyaSoyad(adVeyaSoyad);

            kisi = kisiYeni;
        }

        public static Kisi KisiBulAdVeyaSoyad(string adVeyaSoyad)
        {
            return kisiListesi.FirstOrDefault(kisi => kisi.Ad.ToLower() == adVeyaSoyad.ToLower() || kisi.Soyad.ToLower() == adVeyaSoyad.ToLower());
        }
        
        public static List<Kisi> KisiListeleAdVeyaSoyad(string adVeyaSoyad)
        {
            return kisiListesi.FindAll(kisi => kisi.Ad.ToLower().Contains(adVeyaSoyad.ToLower()) || kisi.Soyad.ToLower().Contains(adVeyaSoyad.ToLower()));
        }

        public static List<Kisi> KisiListeleTelefon(string telefon)
        {
            return kisiListesi.FindAll(kisi => kisi.TelefonNumarasi.Contains(telefon));
        }

        public static List<Kisi> Listele(ListelemeTuru listelemeTuru)
        {

            switch (listelemeTuru)
            {
                case ListelemeTuru.AZ :
                    kisiListesi.Sort((x,y) => x.Ad.CompareTo(y.Ad));
                    break;
                case ListelemeTuru.ZA :
                    kisiListesi.Sort((x,y) => y.Ad.CompareTo(x.Ad));
                    break;
                default :
                    kisiListesi.Sort((x,y) => x.Ad.CompareTo(y.Ad));
                    break;
            }

            return kisiListesi;
        }
    
    
    }
}