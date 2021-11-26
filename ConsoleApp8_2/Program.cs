using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            Program p = new Program();
            Random rand = new Random();
            string path = @"C:\testfolder\text.txt";
            string text = "";
            
            for (int i=0; i<10; i++)
            {                
                text = text  +  rand.Next(0,5000) + " ";
            }
            Console.WriteLine(text);
            p.WriteFile(text, path);
            string sum = p.ReadString(path);
            Console.WriteLine("Сумма чисел: " + sum);

            Console.ReadLine();
            Run();
            Environment.Exit(0);
        }

        
        string WriteFile(string text, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }                
                Console.WriteLine("Запись выполнена \n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        string ReadString(string path)
        {
            string text;
            int sum = 0;
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    text = sr.ReadToEnd();
                    //text = text.Replace("\r\n", "");
                    string[] nums = new string[10];
                    nums = text.Split(' ');
                   
                    for (int i=0; i<nums.Length-1; i++)
                    {
                        sum += Convert.ToInt32(nums[i]);
                    }
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            return sum.ToString();
        }
    }
}