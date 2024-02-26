using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace _1_Array
{
    class OurArray
    {
        public void Resize<T>( ref T[] source, int newSize)
        {
            if (newSize <= 0) return;
            if (source is null) return;
            if (source.Length >= newSize) return;

            T[] newArray = new T[newSize];

            //copy block of memory to anthor block
            Buffer.BlockCopy(source, 0, newArray, 0, Buffer.ByteLength(source));

            source = newArray;

        }

        public T GetAt<T>(T[] source, int index, int sizeOf)
        {
            if (index < 0 || index >= source.Length)
                return default(T);

            ref T zeroAddress = ref MemoryMarshal.GetArrayDataReference<T>(source);
            ref T indexRef = ref Unsafe.Add(ref zeroAddress, index);

            return indexRef;
        }
    }
}
