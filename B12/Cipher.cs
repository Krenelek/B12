using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B12
{
    class Cipher
    {
        public void Showkey()
        {
            for (int i=0;i< 24;i++)
            {
                if (i % 8 == 0)
                    Console.WriteLine();
                Console.Write(key[i]);
            }
        }
        public Cipher()
        {
            key = new int[2048];
            Random rnd = new Random();
            for (int i=0;i<key.Length;i++)
            {
                key[i] = rnd.Next(2);                
            }
        }
        private int[] key;
        public string CesarCipher(string s, int n)
        {
            char[] helper = new char[s.Length];
            for (int i=0; i < s.Length;i++)
            {
                helper[i] = Convert.ToChar(Convert.ToInt32(s[i]) + n % 256);
            }

            string output = string.Concat(helper);
            return output;

        }
        public string XORCipher(string s)
        {
            string str;
            int k = 0;
            string helper = "";
            string result = "";
            int[] binary = new int[s.Length];
            for (int i =0;i<s.Length;i++)
            {
                str = Convert.ToString(s[i], 2).PadLeft(8, '0');
                for(int j=0;j<str.Length;j++)
                {
                    if (((str[j] == '1') ^ (key[k] == 1)))
                    {
                        helper = helper+"1";
                    }
                    else
                    {
                        helper = helper+"0";
                    }
                    k++;                    
                }
                result = result+ Convert.ToChar(Convert.ToInt32(helper, 2));
                helper = "";
            }
            return result;
        }    
    
 
    }
}
