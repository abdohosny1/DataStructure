namespace _2_LinkedList
{
    class LinkedListIterator
    {
        private LinkedListNode CurrentNode;

        public LinkedListIterator()
        {
            CurrentNode = null;
        }

        public LinkedListIterator(LinkedListNode _current)
        {
            CurrentNode = _current;
        }

        public int Data()
        {
            return this.CurrentNode.Data;
        }

       public LinkedListIterator Next()
        {
            this.CurrentNode = this.CurrentNode.Next;
            return this;
        }

      public  LinkedListNode current()
        {
            return this.CurrentNode;
        }




    }
}
