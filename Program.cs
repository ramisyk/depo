using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        public class Range
        {
            public int start;
            public int end;
            public Range(int start, int end)
            {
                this.start = start;
                this.end = end;
            }
        }
        public class Role
        {
            public int id;
            public List<Range> ranges;
        }
        public static string str = "HELLO WORLD RAMİS";
        public static string Encrypt(string input, string key)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Decrypt(string input, string key)
        {
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        //static string Spare(Role role, string Encrypted)
        static void Main(string[] args)
        {
            string CipherText = Encrypt(str, "sblw-3hn8-sqoy19");
            Console.WriteLine(CipherText);
            string PlainText = Decrypt(CipherText, "sblw-3hn8-sqoy19");
            Console.WriteLine(PlainText);

            Role role1 = new Role();
            role1.id = 1;
            Range R1range1 = new Range(0, 4);
            role1.ranges = new List<Range>(); 
            role1.ranges.Add(R1range1);

            Role role2 = new Role();
            role2.id = 2;
            Range R2range1 = new Range(6, 10);
            role2.ranges = new List<Range>();
            role2.ranges.Add(R2range1);

            Role role3 = new Role();
            role3.id = 3;
            Range R3range1 = new Range(0, 10);
            role3.ranges = new List<Range>();
            role3.ranges.Add(R3range1);

            Role role4 = new Role();
            role4.id = 4;
            Range R4range1 = new Range(0, 3);
            Range R4range2 = new Range(7, 10);
            role4.ranges = new List<Range>();
            role4.ranges.Add(R4range1);
            role4.ranges.Add(R4range2);

            Console.Write("Rols(1,2,3,4): ");
            char secim = Convert.ToChar(Console.ReadLine());
            string gorulecek = String.Empty;
            switch (secim)
            {
                case '1':
                    foreach (var item in role1.ranges)
                    {
                        gorulecek += str.Substring(item.start, item.end - item.start+1);
                        gorulecek += "\n";
                    }
                    break;
                case '2':
                    foreach (var item in role2.ranges)
                    {
                        gorulecek += str.Substring(item.start, item.end - item.start+1);
                        gorulecek += "\n";
                    }
                    break;
                case '3':
                    foreach (var item in role3.ranges)
                    {
                        gorulecek += str.Substring(item.start, item.end - item.start+1);
                        gorulecek += "\n";
                    }
                    break;
                case '4':
                    foreach (var item in role4.ranges)
                    {
                        gorulecek += str.Substring(item.start, item.end - item.start+1);
                        gorulecek += "\n";
                    }
                    break;
            }

            Console.WriteLine(gorulecek.ToString());
            Console.ReadKey();
        }
    }
}
