using System.Diagnostics;
using System.Linq;

namespace SubstitutionCipher
{
    /**
     * A simple implementation of the Caesar Cipher.
     */
    public class Cipher
    {
        /**
         * Determines the amount that the message will be shifted by the cipher.
         */
        public byte ShiftAmount { get; set; }
        /**
         * Determines whether the message will be shifted to the left or to the right.
         */
        public bool LeftShift { get; set; } = true;

        public Cipher(byte shiftAmount)
        {
            Debug.Assert(shiftAmount > 0 && shiftAmount < 26, "The shift amount needs to be in the interval [1, 25]");
            ShiftAmount = shiftAmount;
        }

        public Cipher(byte shiftAmount, bool leftShift)
        {
            Debug.Assert(shiftAmount > 0 && shiftAmount < 26, "The shift amount needs to be in the interval [1, 25]");
            ShiftAmount = shiftAmount;
            LeftShift = leftShift;
        }

        public string Encrypt(string message)
        {
            return Shift(message, LeftShift);
        }

        public string Decrypt(string message)
        {
            return Shift(message, !LeftShift);
        }

        private string Shift(string message, bool left)
        {
            return string.Join("", message.ToCharArray().Select(character => ShiftChar(character, left)).ToList());
        }

        private char ShiftChar(char character, bool left)
        {
            if (!char.IsLetter(character))
            {
                return character;
            }

            char start = char.IsUpper(character) ? 'A' : 'a';
            return left
                ? (char)((character + (26 - ShiftAmount) - start) % 26 + start)
                : (char)((character + ShiftAmount - start) % 26 + start);
        }
    }
}