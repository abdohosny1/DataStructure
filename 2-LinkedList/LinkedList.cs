using System;
using System.Xml.Linq;

namespace _2_LinkedList
{
    class LinkedList
    {
        public LinkedListNode Head = null;
        public LinkedListNode Tail = null;

        LinkedListIterator Begin()
        {
            return   new LinkedListIterator(this.Head);

        }

      public  void PrintList()
        {
            for (LinkedListIterator iterator = this.Begin(); iterator.current() !=null; iterator.Next())
            {
                Console.WriteLine($"Data = {iterator.Data()}");

            }
            Console.WriteLine("/n");
        }

        public LinkedListNode Find(int data)
        {
            for (LinkedListIterator iterator = this.Begin(); iterator.current() != null; iterator.Next())
            {
                if (iterator.Data() == data)
                {
                    return iterator.current();
                }

            }
            return null;
        }
        public LinkedListNode FindParent(LinkedListNode  node)
        {
            for (LinkedListIterator iterator = this.Begin(); iterator.current() != null; iterator.Next())
            {
                if (iterator.current().Next == node)
                {
                    return iterator.current();
                }

            }
            return null;
        }
        public void InsertAfter(int nodeData, int data)
        {
            LinkedListNode newNode = new LinkedListNode(data);
            LinkedListNode node= null;
            node = Find(nodeData);

            if(node != null)
            {
                newNode.Next = node.Next;
                node.Next = newNode;

                if (this.Tail == node)
                {
                    this.Tail = newNode;
                }
            }
           
        }
        public void InsertABefor(LinkedListNode node, int data)
        {
            LinkedListNode newNode = new LinkedListNode(data);
            newNode.Next = node;
            var parent = FindParent(node);

            if(parent is null)
            {
                this.Head = newNode;
            }
            else
            {
                parent.Next = newNode;
            }

        }

        public void DeleteNode(LinkedListNode node)
        {
            if(this.Head == this.Tail)
            {
                this.Tail = null;
                this.Head = null;
            }else if (this.Head==node)
            {
                this.Head = node.Next;
            }
            else
            {
                var parent = FindParent(node);
                if(this.Tail == node)
                {
                    this.Tail = parent;
                }
                else
                {
                    parent.Next = node.Next;
                }
            }

        }
        public void InsertAfter(LinkedListNode node,int data)
        {
            LinkedListNode newNode = new LinkedListNode(data);

            newNode.Next = node.Next;
            node.Next = newNode;

            if(this.Tail == node)
            {
                this.Tail = newNode;
            }


        }
        public void InsertLast(int data)
        {
            LinkedListNode newNode = new LinkedListNode(data);

            if(this.Head is null)
            {
                this.Head = newNode;
                this.Tail = newNode;
            }
            else
            {
                this.Tail.Next = newNode;
                this.Tail = newNode;
            }
        }
    }
}
