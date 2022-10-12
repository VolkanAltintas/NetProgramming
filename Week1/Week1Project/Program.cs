using System;

namespace Week1Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bir telefon numarası giriniz....");
            //05551231231
            //+905551231231
            //905551231231
            //5551231231
            //asadadasdada
            string phoneNumber=Console.ReadLine();
            string checkedPhone=checkPhone(phoneNumber);
            if (checkedPhone.Contains("Hata"))
                Console.WriteLine($"Hata Mesajı: {checkedPhone}");
            else
            {
                Console.WriteLine($"{checkedPhone} Telefona mesaj gönderildi...");
                
            }
            Console.ReadLine();
        }

        static string checkPhone(string phone)
        {
            if (phone=="")
            {
                return ("Hata. Numara giriniz...");
            }
            phone=phone.Replace("+","");
            string firstCharacter=phone.Substring(0,1);
            if(firstCharacter=="9")
            {
                phone=phone.Substring(1,phone.Length-1);
            }
            else if(firstCharacter !="0")
            {
                phone="0"+phone;
            }
            if(phone.Length==11)
            {
                Convert.ToDouble(phone);
                return phone;
            }
            else
            return ("Hata. Telefon numarasını kontrol ediniz...");
        }
    }
}
