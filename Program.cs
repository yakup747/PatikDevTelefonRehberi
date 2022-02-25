using System;
using System.Linq;
using System.Collections.Generic;

namespace PatikDev_Telefon_Rehberi_Uygulaması
{
    class GlobalVariables
    {
        public static Dictionary<string, string> contact = new Dictionary<string, string>()
        {
            {"Berkan", "Layık"},
            {"Meliha", "Arslan"},
            {"Efe", "Koçyiğit"},
            {"Esra", "Yaman"},
            {"Yakup", "Layık"},
        };
        
        public static List<long> phoneNumbers = new List<long>()
        {
            9166, 5433364195, 415680 ,7407830783, 1992
        };
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            MainMenu();
        }

        private static void MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz: ");
            Console.WriteLine("*******************************************");

            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Varolan Numarayı Silmek");
            Console.WriteLine("(3) Varolan Numarayı Güncelleme");
            Console.WriteLine("(4) Rehberi Listelemek");
            Console.WriteLine("(5) Rehberde Arama Yapmak﻿");

            int operationNumber = int.Parse(Console.ReadLine());
            switch (operationNumber)
            {
                case 1:
                    SavePhoneNumber();
                    break;

                case 2:
                    DeletePhoneNumber();
                    break;

                case 3:
                    UpdatePhoneNumber();
                    break;

                case 4:
                    ListContact();
                    break;

                case 5:
                    SearchContact();
                    break;
            }
        }


        private static void ListContact()
        {
            Console.WriteLine("Telefon Rehberi");
            Console.WriteLine("**********************************************");

            int phoneIndex = 0;
            foreach (var item in GlobalVariables.contact)
            {
                Console.WriteLine("İsim : " + item.Key.ToString());
                Console.WriteLine("Soyisim : " + item.Value.ToString());
                Console.WriteLine("Telefon Numarası : " + GlobalVariables.phoneNumbers[phoneIndex].ToString());

                Console.WriteLine("-");
                phoneIndex++;
            }

            Console.WriteLine("");
            MainMenu();
        }


        private static void DeletePhoneNumber()
        {
            Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
            string inputName = Console.ReadLine();

            int index = 0;
            foreach (var item in GlobalVariables.contact)
            {
                if (GlobalVariables.contact.ContainsKey(inputName))
                {
                    if (item.Key.ToString() == inputName || item.Value.ToString() == inputName)
                    {
                        Console.WriteLine("{0} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ? (y/n)", inputName);
                        string operationString = Console.ReadLine();
                        if (operationString == "y")
                        {
                            GlobalVariables.contact.Remove(item.Key);
                            GlobalVariables.phoneNumbers.RemoveAt(index);

                            Console.WriteLine("Kişi Silindi. Ana Menüye Gidiliyor.");
                            MainMenu();
                        }
                        else
                        {
                            Console.WriteLine("İşlem İptal Edildi. Ana Menüye Gidiliyor.");
                            MainMenu();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");

                    Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                    Console.WriteLine("* Yeniden denemek için      : (2)");

                    int operationIndex = int.Parse(Console.ReadLine());
                    if (operationIndex == 1)
                    {
                        Console.WriteLine("Ana Menüye Gidiliyor.");
                        MainMenu();
                    }
                    else
                    {
                        DeletePhoneNumber();
                    }
                }

                index++;
            }
        }


        private static void UpdatePhoneNumber()
        {
            Console.WriteLine(" Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz:");
            string inputName = Console.ReadLine();

            int index = 0;
            foreach (var item in GlobalVariables.contact)
            {
                if (GlobalVariables.contact.ContainsKey(inputName))
                {
                    if (item.Key.ToString() == inputName)
                    {
                        Console.WriteLine("{0} isimli kişi için yeni numarayı giriniz.", inputName);
                        long newNumber = long.Parse(Console.ReadLine());
                        GlobalVariables.phoneNumbers[index] = newNumber;

                        Console.WriteLine("Numara başarı ile güncellendi.Ana Menüye Dönülüyor.");
                        MainMenu();

                    }
                }
                else
                {
                    Console.WriteLine("Girdiğiniz bilgilere ait veri bulunamadı.Ana menüye gidiliyor.");
                    MainMenu();
                }

                index++;
            }
        }


        private static void SavePhoneNumber()
        {
            Console.Write("Lütfen isim giriniz : ");
            string name = Console.ReadLine();

            Console.Write("Lütfen soyisim giriniz : ");
            string surname = Console.ReadLine();

            Console.Write("Lütfen telefon numarası giriniz : ");
            var phoneNumber = long.Parse(Console.ReadLine());

            GlobalVariables.contact.Add(name, surname);
            GlobalVariables.phoneNumbers.Add(phoneNumber);

            Console.WriteLine("Kişi Kaydedildi.Ana Menüye Dönülüyor.");
            Console.WriteLine("-");
            MainMenu();
        }


        private static void SearchContact()
        {
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
            Console.WriteLine("**********************************************");


            Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
            Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");

            int operationIndex = int.Parse(Console.ReadLine());
            if(operationIndex == 1)
            {
                Console.WriteLine("Lütfen isim veya soyisim giriniz.");
                string inputName = Console.ReadLine();


                int index = 0;
                foreach (var item in GlobalVariables.contact)
                {
                    if (GlobalVariables.contact.ContainsKey(inputName))
                    {
                        if(item.Key.ToString() == inputName)
                        {
                            Console.WriteLine("İsim : " + item.Key.ToString());
                            Console.WriteLine("Soyisim : " + item.Value.ToString());
                            Console.WriteLine("Telefon Numarası : " + GlobalVariables.phoneNumbers[index].ToString());

                            Console.WriteLine("-");
                        }
                    }
                    
                    index++;
                }
            }
            else
            {
                Console.WriteLine("Lütfen aramak istediğiniz kişiye ait telefon numarasını giriniz.");
                long inputFindPhoneNumber = long.Parse(Console.ReadLine());

                int phoneNumberIndex = GlobalVariables.phoneNumbers.IndexOf(inputFindPhoneNumber);

                if (GlobalVariables.phoneNumbers.Contains(inputFindPhoneNumber))
                {
                    var foundName = GlobalVariables.contact.ElementAt(phoneNumberIndex);
                    
                    Console.WriteLine("İsim : " + foundName.Key.ToString());
                    Console.WriteLine("Soyisim : " + foundName.Value.ToString());
                    Console.WriteLine("Telefon Numarası : " + inputFindPhoneNumber.ToString());

                    Console.WriteLine("-");

                    MainMenu();
                }
                else
                {
                    Console.WriteLine("Aradığınız numara kayıtlı değildir.Menüye Gidiliyor.");
                    MainMenu();

                }
            }
        }
    }
}
