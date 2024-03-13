using System;
using System.Drawing;

namespace _4_dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Dictionary<string ,string> dictionary = new Dictionary<string ,string>();
            dictionary.Set("one", "test one");
            dictionary.Set("two", "test two");
            dictionary.Set("three", "test three");

            dictionary.Print();

            Console.WriteLine(  dictionary.Get("two"));
            Console.WriteLine(  dictionary.Remvoe("four"));
            dictionary.Print();

        }
    }
}
