using System;
using System.Text;

namespace _5__Hashing
{
    //FNV-1a
    public class Hash
    {
        public uint Hash32(string str)
        {
            uint offestBassic = 2166136261;
            uint FNVPrime = 16777619;

            byte[] data=Encoding.ASCII.GetBytes(str);

            uint hash = offestBassic;

            for (int i = 0; i < data.Length; i++)
            {
                hash = hash ^ data[i];
                hash = hash * FNVPrime;
            }
            Console.WriteLine($"Convert : {str} to hash = {hash}  , hex= {hash.ToString("x")}");
            return hash;
        }

        public ulong Hash64(string str)
        {
            ulong offestBassic = 14695981039346656037;
            ulong FNVPrime = 1099511628211;

            byte[] data = Encoding.ASCII.GetBytes(str);

            ulong hash = offestBassic;

            for (int i = 0; i < data.Length; i++)
            {
                hash = hash ^ data[i];
                hash = hash * FNVPrime;
            }
            Console.WriteLine($"Convert : {str} to hash = {hash}  , hex= {hash.ToString("x")}");
            return hash;
        }
    }
}
