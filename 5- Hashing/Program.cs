using System;
using System.Security.Cryptography;
using System.Text;

namespace _5__Hashing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hash hash = new Hash();
            hash.Hash32("abdo");
            hash.Hash64("abdo");

            MD5_Create md5 = new MD5_Create();
            byte[] input = System.Text.Encoding.UTF8.GetBytes("Hello World!");
            byte[] hash_md5 = md5.ComputeHash(input);

            Console.WriteLine("from me");
            Console.WriteLine(BitConverter.ToString(hash_md5).Replace("-", "").ToLower());

            Console.WriteLine("from build in");
            string hash_m = CreateMD5("Hello World!");
            Console.WriteLine($"MD5 Hash: {hash_m}");

            Console.ReadLine();

        }
        static string CreateMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input); // Convert input to bytes
                byte[] hashBytes = md5.ComputeHash(inputBytes); // Compute the MD5 hash

                // Convert byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // Format as hex
                }
                return sb.ToString();
            } // MD5 object is disposed here
        }
    }
}
