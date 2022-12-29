/******************************************************************************************************
**					                     SAKARYA ÜNİVERSİTESİ
**				    BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				          NESNEYE DAYALI PROGRAMLAMA DERSİ 2021-2022 BAHAR DÖNEMİ
**                              Nesneye Dayali Programlama 2.Dönem 1.Ödevi
**					
**	
**				ÖDEV NUMARASI..........: 1
**				ÖĞRENCİ ADI............: EREN KARA
**				ÖĞRENCİ NUMARASI.......: B211210031
**              DERSİN ALINDIĞI GRUP...: 1-B
*******************************************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Donem1.Odev
{
    static class Kontrol
    {
        // bosluk icermemeli ,Buyuk harf , kucuk harf, rakam, sembol  

        private static int puan = 0;
        private static int kHarf=0;
        private static int bHarf=0;
        private static int rakamSayisi=0;
        private static int sembolSayisi=0;
        private static int boslukSayisi=0;

        
        public static void cizgi() // ekrandaki anlaşılabilirliği arttırmak için çizgi ekleyen metod
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        public static void renkDegistirme(string a) // kırmızı rengi çok kullandığımdan konsola kırmızı yazdırma metodu.
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(a);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
        }

        public static void kurallar()  // kuralları ekrana yazdırmak için.
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Sifre kuralları:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Sifreniz Buyuk harf, Kucukk harf, Rakam ve Sembol icerebilir ancak Bosluk iceremez.");
            Console.WriteLine("Puan 70 den kucukk ise sifreniz kabul edilemez.");
            Console.WriteLine("Puan 70 ile 90 arasında ise sifre kabul edilir.");
            Console.WriteLine("Puan 90 ile 100 sifre kabul edilir ve sifreniz guclu.");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void reset()  // geçersiz şifre girildiğinde tekrar şifre girdireceğim için field'ları resetledim.
        {
            puan = 0;
            boslukSayisi = 0;
            kHarf = 0;
            bHarf = 0;
            rakamSayisi = 0;
            sembolSayisi = 0;
        }

        public static void kntrol(char a) // şifrenin içerisindeki karakterlerin türünü anlamak için
        {
            if (a == 32)
            {
                boslukSayisi++;
            }
            else if (char.IsLower(a))
            {
                kHarf++;
            }
            else if (char.IsUpper(a))
            {
                bHarf++; 
            }
            else if (char.IsDigit(a))
            {
                rakamSayisi++;
            }
            else if (char.IsSymbol(a) || char.IsPunctuation(a))
            {
                sembolSayisi++;
            }
        }
        
        // klasik get komutları
        public static int getBosluk()
        {
            return boslukSayisi;
        }
        public static int getkHarf()
        {
            return kHarf;
        }
        public static int getbHarf()
        {
            return bHarf;
        }
        public static int getRakamSayisi()
        {
            return rakamSayisi;
        }
        public static int getSembolSayisi()
        {
            return sembolSayisi;
        }

        public static int puanHesaplama(string sifre) // şifrenin gücünü hesaplamak için puan hesaplattım.
        {
            
            if (kHarf > 2)
                puan += 20;
            else
                puan+=(kHarf*10);

            if (bHarf > 2)
                puan += 20;
            else
                puan += (bHarf * 10);

            if (rakamSayisi > 2)
                puan += 20;
            else
                puan += (rakamSayisi * 10);

            if (sembolSayisi > 3)
                puan += 30;
            else
                puan += (sembolSayisi * 10);

            if (sifre.Length >= 9)
                puan += 10;
            return puan;
        }

        public static int GetPuan() 
        {
            return puan;
        }
        public static bool Olabilirlik() // bir kaç yerde kullandığım için ve çok uzun olduğu için fonksiyon yaptım.
        {
            return (Kontrol.getkHarf() == 0 || Kontrol.getbHarf() == 0 || Kontrol.getRakamSayisi() == 0 || Kontrol.getSembolSayisi() == 0);
        }
    }

    
    class Program
    {

        static void Main(string[] args)
        {

            string sifre;
            do
            {
                do
                {
                    Kontrol.reset();
                    Kontrol.cizgi();
                    Kontrol.kurallar();

                    Console.Write("Sifrenizi Giriniz: ");
                    sifre = Console.ReadLine();

                    Console.WriteLine("");
                    if (sifre.Length < 9)
                    {
                        Kontrol.renkDegistirme("9 Karakterden kucuk sifre giremezsiniz.");
                    }

                    foreach (char a in sifre)  // sifrenin içerisinde gezinip karakterleri tespit etmek için kullanılan for döngüsü
                    {
                        Kontrol.kntrol(a);
                    }
                    
                    if(Kontrol.getBosluk()>0)
                    {
                        Kontrol.renkDegistirme("Sifreniz Bosluk karakteri iceremez.");
                    }

                } while (sifre.Length < 9 || Kontrol.getBosluk()> 0 );



                Kontrol.renkDegistirme("Sifrenizin puani: " + Kontrol.puanHesaplama(sifre));

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Sifrenizdeki");
                Console.WriteLine("Kucuk harf sayisi: "+ Kontrol.getkHarf());
                Console.WriteLine("Buyuk harf sayisi: "+ Kontrol.getbHarf());
                Console.WriteLine("Rakam sayisi: "+ Kontrol.getRakamSayisi());
                Console.WriteLine("Sembol sayisi: "+ Kontrol.getSembolSayisi());
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");

                if(Kontrol.Olabilirlik())
                {
                    Kontrol.renkDegistirme("Sifrenizde olmasi gereken 4 farklı karakterden herhangi birisi 0 oldugu icin sifreniz kabul edilemez.");
                }

                else if (Kontrol.GetPuan() < 70)
                {
                    Kontrol.renkDegistirme("Sifreniz kabul edilemez lutfen tekrar deneyiniz.");
                }
                    
                else if (Kontrol.GetPuan()>=70&& Kontrol.GetPuan()<90)
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Sifreniz kabul edilebilir.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
                else if(Kontrol.GetPuan()==100||Kontrol.GetPuan()==90)
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Sifreniz guclü bir sifre.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
            } while (Kontrol.GetPuan()<70 || Kontrol.Olabilirlik());  // kurallara uymayan şifreleri kabul etmeyip yeni şifre istedim.

        }
    }
}
