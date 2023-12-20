using System;
using System.Collections.Generic;

namespace TelefonRehberi
{
    public static class Rehber
    {
        public static void AnaMenu()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Varolan Numarayı Silmek");
            Console.WriteLine("(3) Varolan Numarayı Güncelleme");
            Console.WriteLine("(4) Rehberi Listelemek");
            Console.WriteLine("(5) Rehberde Arama Yapmak");
            int secim = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (secim)
            {
                case 1 :
                    KisiEkle();
                    break;
                case 2 :
                    KisiSil();
                    break;
                case 3 :
                    KisiGuncelle();
                    break;
                case 4 :
                    RehberListele();
                    break;
                case 5 :
                    RehberAra();
                    break;
                default :
                    Console.WriteLine("Hatalı seçim yaptınız!");
                    break;
            }
        }

        public static void KisiEkle()
        {
            Console.Write("Lütfen isim giriniz             : ");
            string ad = Console.ReadLine();
            Console.Write("Lütfen soyisim giriniz          : ");
            string soyad = Console.ReadLine();
            Console.Write("Lütfen telefon numarası giriniz : ");
            string telefon = Console.ReadLine();

            Kisi kisi = new() { Ad = ad, Soyad = soyad, TelefonNumarasi = telefon}; 

            RehberKayit.KisiEkle(kisi);

            Console.WriteLine();

            AnaMenu();
        }

        public static void KisiSil()
        {
            Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string adVeyaSoyad = Console.ReadLine().Trim();

            Kisi kisi = RehberKayit.KisiBulAdVeyaSoyad(adVeyaSoyad);

            while (kisi == null)
            {
                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için      : (2)");
                int secim = int.Parse(Console.ReadLine()); 

                if(secim == 1)
                {
                    break;
                }
                else if(secim == 2)
                {
                    Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
                    adVeyaSoyad = Console.ReadLine().Trim();
                    kisi = RehberKayit.KisiBulAdVeyaSoyad(adVeyaSoyad);
                }
            }
            

            if (kisi != null )
            {
                Console.WriteLine("{0} {1} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)", kisi.Ad, kisi.Soyad);

                string silmeOnay = Console.ReadLine().ToUpper();
                switch (silmeOnay)
                {
                    case "Y" :
                        bool silindiMi = RehberKayit.KisiSil(kisi);
                        if(silindiMi)
                            Console.WriteLine("Kişi silinmiştir.");
                        break;
                    case "N" :
                        Console.WriteLine("Silme işlemi iptal edilmiştir.");
                        break;
                    default :
                        Console.WriteLine("Hatalı işlem yaptınız..");
                        break;
                }
                
            }

            Console.WriteLine();

            AnaMenu();
        }

        public static void KisiGuncelle()
        {
            Console.Write("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string adVeyaSoyad = Console.ReadLine().Trim();

            Kisi kisi = RehberKayit.KisiBulAdVeyaSoyad(adVeyaSoyad);

            while (kisi == null)
            {
                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Güncellemeyi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için      : (2)");
                int secim = int.Parse(Console.ReadLine()); 

                if(secim == 1)
                {
                    break;
                }
                else if(secim == 2)
                {
                    Console.Write("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
                    adVeyaSoyad = Console.ReadLine().Trim();
                    kisi = RehberKayit.KisiBulAdVeyaSoyad(adVeyaSoyad);
                }
            }
            

            if (kisi != null )
            {
                Console.WriteLine();
                Console.Write("{0} {1} isimli kişinin yeni numarasını giriniz : ", kisi.Ad, kisi.Soyad );
                kisi.TelefonNumarasi = Console.ReadLine().Trim();
            }

            Console.WriteLine();

            AnaMenu();
        }
    
        public static void RehberListele()
        {
            Console.WriteLine("Lütfen öncelikle listeleme türünü seçiniz : (1) A-Z  (2) Z-A");
            int listelemeTuru = int.Parse(Console.ReadLine());

            List<Kisi> liste = null; 
            switch (listelemeTuru)
            {
                case (int)ListelemeTuru.AZ :
                    liste = RehberKayit.Listele(ListelemeTuru.AZ);
                    break;
                case (int)ListelemeTuru.ZA :
                    liste = RehberKayit.Listele(ListelemeTuru.ZA);
                    break;
                default :
                    Console.WriteLine("Hatalı işlem yaptınız..");
                    break;
            }

            if(liste != null)
            {
                Console.WriteLine();
                Console.WriteLine("Telefon Rehberi");
                Console.WriteLine("**********************************************");
                foreach (Kisi kisi in liste)
                {
                    Console.WriteLine("İsim: " + kisi.Ad);
                    Console.WriteLine("Soyisim: " + kisi.Soyad);
                    Console.WriteLine("Telefon Numarası: " + kisi.TelefonNumarasi);

                    if(liste.IndexOf(kisi) < liste.Count-1)
                        Console.WriteLine("-");
                }
            }
            Console.WriteLine("..");

            Console.WriteLine();

            AnaMenu();
        }
    
        public static void RehberAra()
        {
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
            Console.WriteLine("**********************************************");
            Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
            Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");
            string aramaTuru = Console.ReadLine();

            List<Kisi> liste = null; 
            switch (aramaTuru)
            {
                case "1" :
                    Console.WriteLine("Lütfen aramak istediğiniz kişinin adını ya da soyadını giriniz: ");
                    string adVeyaSoyad = Console.ReadLine().Trim();
                    liste = RehberKayit.KisiListeleAdVeyaSoyad(adVeyaSoyad);
                    break;
                case "2" :
                    Console.WriteLine("Lütfen aramak istediğiniz kişinin telefon numarasını giriniz: ");
                    string telefon = Console.ReadLine().Trim();
                    liste = RehberKayit.KisiListeleTelefon(telefon);
                    break;
                default :
                    Console.WriteLine("Hatalı işlem yaptınız..");
                    break;
            }

            if(liste != null)
            {
                Console.WriteLine();
                Console.WriteLine("Arama Sonuçlarınız:");
                Console.WriteLine("**********************************************");
                foreach (Kisi kisi in liste)
                {
                    Console.WriteLine("İsim: " + kisi.Ad);
                    Console.WriteLine("Soyisim: " + kisi.Soyad);
                    Console.WriteLine("Telefon Numarası: " + kisi.TelefonNumarasi);

                    if(liste.IndexOf(kisi) < liste.Count-1)
                        Console.WriteLine("-");
                }
                Console.WriteLine("..");
            }

            Console.WriteLine();

            AnaMenu();
        }

        
    }
}