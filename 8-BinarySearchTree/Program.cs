using System;

namespace _8_BinarySearchTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.BSInsert(1);
            tree.BSInsert(2);
            tree.BSInsert(3);
            tree.BSInsert(4);
            tree.BSInsert(5);
            tree.BSInsert(6);
            tree.Print();

            Console.WriteLine(tree.IsExsit(8));
        }
    }
}
