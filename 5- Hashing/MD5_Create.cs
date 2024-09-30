using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5__Hashing
{
    internal class MD5_Create
    {
        private uint A, B, C, D;
        private uint[] T;

        public MD5_Create()
        {
            T = Enumerable.Range(0, 64).Select(i => (uint)(Math.Pow(2, 32) * Math.Abs(Math.Sin(i + 1)))).Select(x => (uint)x).ToArray();

            // Initialize variables
            A = 0x67452301;
            B = 0xEFCDAB89;
            C = 0x98BADCFE;
            D = 0x10325476;
        }

        public byte[] ComputeHash(byte[] input)
        {
            // Padding the input
            var paddedInput = PadInput(input);
            ProcessBlocks(paddedInput);
            return GetHash();
        }
        private byte[] PadInput(byte[] input)
        {
            // Original length
            ulong originalLength = (ulong)input.Length * 8;
            int paddingLength = (448 - (input.Length * 8 % 512) + 512) % 512;

            // Create padded array
            var paddedInput = new byte[input.Length + (paddingLength / 8) + 8];
            Array.Copy(input, paddedInput, input.Length);
            paddedInput[input.Length] = 0x80; // Append the bit '1'

            // Append length
            BitConverter.GetBytes(originalLength).CopyTo(paddedInput, paddedInput.Length - 8);

            return paddedInput;
        }

        private uint RotateLeft(uint value, int count)
        {
            return (value << count) | (value >> (32 - count));
        }

        private byte[] GetHash()
        {
            byte[] hash = new byte[16];
            Buffer.BlockCopy(BitConverter.GetBytes(A), 0, hash, 0, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(B), 0, hash, 4, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(C), 0, hash, 8, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(D), 0, hash, 12, 4);
            return hash;
        }
        private void ProcessBlocks(byte[] input)
        {
            for (int i = 0; i < input.Length; i += 64)
            {
                uint[] M = new uint[16];
                for (int j = 0; j < 16; j++)
                {
                    M[j] = BitConverter.ToUInt32(input, i + j * 4);
                }

                uint a = A, b = B, c = C, d = D;

                // 64 operations
                for (int j = 0; j < 64; j++)
                {
                    uint f = j < 16 ? (b & c) | (~b & d) :
                             j < 32 ? (d & b) | (~d & c) :
                             j < 48 ? b ^ c ^ d :
                             c ^ (b | ~d);

                    // Explicitly cast to uint for operations
                    uint g = j < 16 ? (uint)j :
                              j < 32 ? (uint)((5 * j + 1) % 16) :
                              j < 48 ? (uint)((3 * j + 5) % 16) :
                              (uint)((7 * j) % 16);

                    uint temp = d;
                    d = c;
                    c = b;
                    // Ensure the RotateLeft result is also a uint
                    b = b + RotateLeft(a + f + M[g] + T[j], (j < 16 ? 7 : j < 32 ? 5 : j < 48 ? 4 : 6));
                    a = temp;
                }

                // Add the results to the current hash value
                A += a;
                B += b;
                C += c;
                D += d;
            }
        }

    }
}
