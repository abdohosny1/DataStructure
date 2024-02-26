namespace _2_LinkedList.DoublyLinked
{
    class DoublyLinkedListIterator
    {
        private DoublyLinkedListNode CurrentNode;

        public DoublyLinkedListIterator()
        {
            CurrentNode = null;
        }

        public DoublyLinkedListIterator(DoublyLinkedListNode _current)
        {
            CurrentNode = _current;
        }

        public int Data()
        {
            return CurrentNode.Data;
        }

        public DoublyLinkedListIterator Next()
        {
            CurrentNode = CurrentNode.Next;
            return this;
        }

        public DoublyLinkedListNode current()
        {
            return CurrentNode;
        }




    }
}
