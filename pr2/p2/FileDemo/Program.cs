using System;
using System.IO;

namespace FileDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter writer = File.CreateText(@"d:\newfile.txt"); 
            writer.WriteLine("This is my new file");
            writer.WriteLine("Do you like its format?"); 
            writer.Close();

            StreamReader reader = File.OpenText(@"d:\newfile.txt");
            string contents = reader.ReadToEnd();
            reader.Close();
            Console.WriteLine(contents);

        }
    }
}
