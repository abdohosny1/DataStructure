using System;
using System.Collections.Generic;

namespace _6_HashTabel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashTables<string,string> hashTables=new HashTables<string,string>();

            hashTables.Print();
            hashTables.Set("one", "one@yahoo.com");
            hashTables.Set("two", "two@yahoo.com");
            hashTables.Set("three", "three@yahoo.com");
            hashTables.Print();

            Console.WriteLine($"[get] {hashTables.Get("one")}");
            // hashTables.Set("four", "four@yahoo.com");

        }
    }
}
