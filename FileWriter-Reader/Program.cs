using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileWriter_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo file = new FileInfo("test.txt");
            string append = "Append by byte[]";

            if (!file.Exists)
            {
                FileStream fs = file.Create();
                fs.Close();
                StreamWriter sw = new StreamWriter(file.FullName);
                sw.WriteLine("Zonk !!!!");
                sw.Close();
            }
            else
            {
                StreamWriter sw = File.AppendText("test.txt");
                sw.WriteLine("und noch ein Zonk !!!!????!!!!");
                sw.Close();

                FileStream fsw = new FileStream("test.txt",FileMode.Append,FileAccess.Write,FileShare.None);
                byte[] info = new UTF8Encoding(true).GetBytes(append);
                fsw.Write(info,0,info.Length);
                fsw.Close();

            }

            // String Lesen
            StreamReader sr = File.OpenText("test.txt");
            string s = "";
            while ((s = sr.ReadLine()) != null) {
                Console.WriteLine(s);
            }

            Console.WriteLine("File.OpenRead");

            // Bytes Lesen
            FileStream fs1 = File.OpenRead("test.txt");
            byte[] b = new byte[512];
            UTF8Encoding temp = new UTF8Encoding(true);

            while (fs1.Read(b, 0, b.Length) > 0) {
                Console.WriteLine(temp.GetString(b));
            }
            fs1.Close();
            Console.ReadKey();


        }
    }
}
