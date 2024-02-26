using System;
using System.Linq;

namespace _1_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] source = new int[] { 3, 5, 6 };

            Console.WriteLine($"sourcr length befor  ={source.Length}");

           // source.NewResize(5);

             OurArray ourArray = new OurArray();

             ourArray.Resize<int>(ref source, 5);
            Console.WriteLine($"sourcr after befor  ={source.Length}");

            Console.WriteLine(String.Join(",",source) );

           var item= ourArray.GetAt<int>(source, 2, sizeof(int));
            Console.WriteLine($"item =={item} ");
        }
    }
}
