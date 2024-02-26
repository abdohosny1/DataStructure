using System;

namespace _2_LinkedList.DoublyLinked
{
    class DoublyLinkedList
    {
        public DoublyLinkedListNode Head = null;
        public DoublyLinkedListNode Tail = null;

        private int _length = 0;

        public int Length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
            }
        }
            DoublyLinkedListIterator Begin()
        {
            return new DoublyLinkedListIterator(Head);

        }

        public void PrintList()
        {
            for (DoublyLinkedListIterator iterator = Begin(); iterator.current() != null; iterator.Next())
            {
                Console.WriteLine($"Data = {iterator.Data()}");

            }
            Console.WriteLine("/n");
        }

        public DoublyLinkedListNode Find(int data)
        {
            for (DoublyLinkedListIterator iterator = Begin(); iterator.current() != null; iterator.Next())
            {
                if (iterator.Data() == data)
                {
                    return iterator.current();
                }

            }
            return null;
        }
    
        public void InsertAfter(int nodeData, int data)
        {
           

        }
        public void InsertABefor(DoublyLinkedListNode node, int data)
        {
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(data);
            newNode.Next = node;
           if(node.Back is null)
            {
                this.Head = newNode;
            }
            else
            {
                node.Back.Next = newNode;
            }
            node.Back = newNode;
            this._length++;
        }

        public void DeleteNode(DoublyLinkedListNode node)
        {
            if(this.Tail ==  this.Head)
            {
                this.Head = null;
                this.Tail = null;
            }
          else  if(node.Back is null)
            {
                this.Head = node.Next;
                node.Next.Back = null;
            }
          else  if (node.Next is null)
            {
                this.Tail = node.Back;
                node.Back.Next = null;
            }
            else
            {
                node.Next.Back = node.Back;
                node.Back.Next = node.Next;
            }

            this._length--;


        }
        public void InsertAfter(DoublyLinkedListNode node, int data)
        {
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(data);

            newNode.Next = node.Next;
            newNode.Back = node;
            node.Next = newNode;

            if(newNode.Next == null)
            {
                this.Tail = newNode;
            }
            else
            {
                newNode.Next.Back = newNode;
            }

            this._length++;

        }
        public void InsertLast(int data)
        {
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(data);
            
            if(this.Tail is null)
            {
                this.Head = newNode;
                this.Tail = newNode;
            }
            else
            {
                newNode.Back = this.Tail;
                this.Tail.Next = newNode;
                this.Tail = newNode;
                newNode.Next = null;
            }
            this._length++;

        }

    }
}
