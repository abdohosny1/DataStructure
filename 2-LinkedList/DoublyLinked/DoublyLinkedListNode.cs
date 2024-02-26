namespace _2_LinkedList.DoublyLinked
{
    class DoublyLinkedListNode
    {
        public int Data;
        public DoublyLinkedListNode Next;
        public DoublyLinkedListNode Back;

        public DoublyLinkedListNode(int data)
        {
            Data = data;
            Next = null;
            Back = null;
        }
    }
}
