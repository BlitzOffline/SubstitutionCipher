using System;

namespace SubstitutionCipher
{
    internal class Program
    {
        public static void Main()
        {
            var leftCipher = new Cipher(3, true);
            var rightCipher = new Cipher(3, false);
            Console.Out.WriteLine(leftCipher.Encrypt("AbcdEfgHijKlmnopQrstUvwXYZ!"));
            Console.Out.WriteLine(rightCipher.Encrypt("AbcdEfgHijKlmnopQrstUvwXYZ!"));
        }
    }
}