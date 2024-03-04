using System;
using System.Drawing;

namespace _4_dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Dictionary<string ,string> dictionary = new Dictionary<string ,string>();
            dictionary.Set("one", "test one");
            dictionary.Set("two", "test two");
            dictionary.Set("three", "test three");

            dictionary.Print();

            Console.WriteLine(  dictionary.Get("two"));
            Console.WriteLine(  dictionary.Remvoe("four"));
            dictionary.Print();

        }
    }

    public class Dictionary<TKey, Tvalue> where TKey : class
    {
        KeyValuePair[] entries;
        int initialSize;
        int entriesCount;

        public Dictionary()
        {
            this.initialSize = 3;
            this.entries = new KeyValuePair[this.initialSize];
            this.entriesCount = 0;
        }

        public void ResizeOrNot()
        {
            if (this.entriesCount < this.entries.Length - 1)
            {
                return;
            }
            int newSize = this.entries.Length + this.initialSize;
            Console.WriteLine($"[resize from ]{this.entries.Length} to  {newSize}");

            KeyValuePair[] newArray = new KeyValuePair[newSize];
            Array.Copy(this.entries, newArray, this.entries.Length);
            this.entries = newArray;

        }
        public int Size() => this.entriesCount;

        public void Set(TKey key ,Tvalue value)
        {
            for (int i = 0; i < this.entries.Length; i++)
            {
                if (entries[i] != null && entries[i].Key == key)
                {
                    entries[i].Value = value;
                    return;
                }
            }
            this.ResizeOrNot();
            KeyValuePair newPair=new KeyValuePair(key, value);
            this.entries[this.entriesCount] = newPair;
            this.entriesCount++;
                 
        }

        public Tvalue Get(TKey key)
        {
            for (int i = 0; i < this.entries.Length; i++)
            {
                if (entries[i] != null && entries[i].Key == key)
                {

                    return entries[i].Value;
                }
            }
            return default(Tvalue);
        }

        public bool Remvoe(TKey key)
        {

            for (int i = 0; i < this.entries.Length; i++)
            {
                if (entries[i] != null && entries[i].Key == key)
                {
                    this.entries[i] = this.entries[this.entriesCount - 1];
                    this.entries[this.entriesCount - 1] = null;
                    this.entriesCount--;
                    return true;
                }
            }
            return false;
        }

        public void Print()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"[size] == {this.Size()}");

            for (int i = 0; i < this.entries.Length; i++)
            {
                if (entries[i] == null)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine($" {this.entries[i].Key} :{this.entries[i].Value}");
                }
            }
            Console.WriteLine("============================================");

        }
        class KeyValuePair
        {
            TKey _key;
            Tvalue _value;

            public TKey Key { get { return _key; } }
            public Tvalue Value { get { return _value; } set { _value = value; } }

            public KeyValuePair(TKey key, Tvalue value)
            {
                _key = key;
                _value = value;
            }
        }

    }
}
