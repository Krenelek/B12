using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B12
{
    class Program
    {
        static void Main(string[] args)
        {
            string a1 = "Tajne haslo to: akustyka";
            string a2 = "Testowa wiadomosc hakera";
            Cipher szyfrowanko = new Cipher();
            Console.WriteLine(szyfrowanko.CesarCipher(a1,3));
            string b1=szyfrowanko.XORCipher(a1);
            Console.WriteLine(b1);
            string b2 = szyfrowanko.XORCipher(a2);
            string guessed="";
            Console.WriteLine(b2);
            for (int i=0;i<a2.Length;i++)
            {
                string sum = "";
                string sb1 = Convert.ToString(b1[i], 2).PadLeft(8, '0');
                string sb2 = Convert.ToString(b2[i], 2).PadLeft(8, '0');
                string sa2 = Convert.ToString(a2[i], 2).PadLeft(8, '0');
                for (int j=0;j<8;j++)
                {
                    int bb1 = (Convert.ToInt32(sb1[j]) - 48);
                    int bb2 = ((Convert.ToInt32(sb2[j])) - 48);
                    int aa2 = ((Convert.ToInt32(sa2[j])) - 48);
                    sum = sum + ((bb1^bb2)^aa2).ToString();
                    Console.WriteLine(bb1 + " " + bb2 + " " + aa2 + " " + ((bb1 ^ bb2) ^ aa2).ToString());
                }
                Console.WriteLine(sum);

                Console.WriteLine(Convert.ToChar(Convert.ToInt32(sum, 2)));
                guessed = guessed + Convert.ToChar(Convert.ToInt32(sum, 2));
            }
            Console.WriteLine();
            Console.WriteLine(guessed);
        }
    }
}
