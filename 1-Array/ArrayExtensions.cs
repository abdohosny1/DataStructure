using System;

namespace _1_Array
{
    static class ArrayExtensions
    {
        public static void Resize<T>(this  T[] source, int newSize) where T : struct
        {
            if (newSize <= 0) return;
            if (source is null) return;
            if (source.Length >= newSize) return;

            T[] newArray = new T[newSize];

            // Copy block of memory to another block
            Buffer.BlockCopy(source, 0, newArray, 0, Buffer.ByteLength(source));

            source = newArray;
        }
        public static void NewResize(  this int[] source, int newSize)
        {
            if (newSize <= 0) return;
            if (source is null) return;
            if (source.Length >= newSize) return;

            int[] newArray = new int[newSize];

            //copy block of memory to anthor block
            Buffer.BlockCopy(source, 0, newArray, 0, Buffer.ByteLength(source));

           // source = newArray;
        }
    }
}
