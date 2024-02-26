using System;

namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StackImplment stack = new StackImplment();

            Console.WriteLine($"{stack.isEmpty()}");

            stack.Push(10);
            stack.Push(40);
            stack.Push(50);
            stack.Push(60);
            stack.Print();
            stack.Pop();
            stack.Print();

        }
    }
}
