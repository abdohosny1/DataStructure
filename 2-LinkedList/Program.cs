using _2_LinkedList.DoublyLinked;
using System;

namespace _2_LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList  linkedList = new DoublyLinkedList();
            linkedList.InsertLast(5);
            linkedList.InsertLast(4);
            linkedList.InsertLast(3);
            linkedList.InsertLast(2);
            linkedList.PrintList();
            Console.WriteLine($"Length === {linkedList.Length}");

            linkedList.InsertAfter(linkedList.Find(3),77);

            linkedList.PrintList();
            Console.WriteLine($"Length === {linkedList.Length}");

            linkedList.DeleteNode(linkedList.Find(2));
            linkedList.DeleteNode(linkedList.Find(5));
            //linkedList.DeleteNode(linkedList.Find(77));

            linkedList.PrintList();
            Console.WriteLine($"Length === {linkedList.Length}");


            ////     linkedList.InsertAfter(linkedList.Find(3), 55);
            //     linkedList.PrintList();

            //     linkedList.InsertAfter(55, 66);
            //     linkedList.PrintList();

            //     linkedList.InsertABefor(linkedList.Find(55), 77);
            //     linkedList.PrintList();

            Console.ReadLine();

        }
    }
}
