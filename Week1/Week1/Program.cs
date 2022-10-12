using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a=0;
            string name = "Ahmet";
            long numbers = 123456789101;
            var value = 7;

            if (value > numbers) { a++; } else { a--; }
            //Array
            string[] sehirler = new string[3] { "Ankara", "İstanbul", "İzmir" };
            for(int i=0;i<sehirler.Length;i++)
                Console.WriteLine(sehirler[i]);

            foreach(string s in sehirler) { Console.WriteLine(s); }

            sehirler = new string[4];
            sehirler[3] = "Manisa";
            
            for (int i = 0; i < sehirler.Length; i++)
                Console.WriteLine(sehirler[i]);
            //LIST
            List<string> list = new List<string> {"Ankara","İstanbul","İzmir" };
            foreach(string s in list) { Console.WriteLine(s); }
            list.Add("Bursa");
            foreach (string s in list) { Console.WriteLine(s); }

            string sentence = "Manisa Celal Bayar University";

            var result1 = sentence.Length;
            var result2 = sentence.Clone();
            var result3 = sentence.EndsWith("a");
            var result4 = sentence.IndexOf("a");
            var result5= sentence.LastIndexOf("a");
            var result6 = sentence.Insert(0, "MCBU ");
            var result7 = sentence.Substring(0,6);
            var result8 = sentence.ToLower();
            var result9= sentence.ToUpper();
            var result10 = sentence.Replace(" ", "-");
            var result11 = sentence.Remove(0,7);

            Console.WriteLine(result11);

            Console.ReadLine();
            
        }

        static void Warning(string s) { Console.WriteLine("Be Careful "+s); }
        static int sum(int x,int y)
        {
            return x + y;
        }

        static int multiply(int x,int y) { return x * y; }


    }
}
