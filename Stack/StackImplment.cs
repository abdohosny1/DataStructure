using System;

namespace Stack
{
    class StackImplment
    {
        int [] data_list;
        int top_index;
        int initial_size;
        int current_size;

        public StackImplment()
        {
            this.initial_size = 6;
            this.data_list = new int[initial_size];
            this.current_size = this.initial_size;
            this.top_index = -1;
        }

      private  void resizeOrNot()
        {
            if (this.top_index > data_list.Length - 1) return;

            Resize<int>( ref this.data_list,data_list.Length+this.initial_size);
        }
        public void Push(int data)
        {
            this.resizeOrNot();

            this.data_list[++this.top_index] = data; 
        }

        public int Peek()
        {
            if (top_index == -1) return 0;

            return data_list[top_index];
        }

        public int Pop()
        {
            if (top_index == -1) return 0;

            int head_data = this.data_list[top_index];
            this.data_list[top_index]=0;
            this.top_index --;
            return head_data;
        }
        public bool isEmpty()
        {
            return this.top_index <= 0;
        }

        public int Size()
        {
            return this.top_index + 1;
        }

        public void Print()
        {
            for (int i = this.top_index; i >= 0; i--)
            {
                Console.WriteLine($"{this.data_list[i]}");
            }
            Console.WriteLine("End print ");
        }
        private void Resize<T>(ref T[] source, int newSize)
        {
            if (newSize <= 0) return;
            if (source is null) return;
            if (source.Length >= newSize) return;

            T[] newArray = new T[newSize];

            //copy block of memory to anthor block
            Buffer.BlockCopy(source, 0, newArray, 0, Buffer.ByteLength(source));

            source = newArray;

        }
    }
}
