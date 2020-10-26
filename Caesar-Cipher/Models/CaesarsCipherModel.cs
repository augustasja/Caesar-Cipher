using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Caesar_Cipher.Models
{
    public class CaesarsCipherModel
    {
        public string Input { get; set; }
        public int Shift { get; set; }
        public string Output { get; set; }

        /// <summary>
        /// English Alphabet Letter Number
        /// </summary>
        private const int engAlphabet = 26;

        public CaesarsCipherModel() { }
        public CaesarsCipherModel(string Input, int Shift)
        {
            this.Input = Input;
            this.Shift = Shift;
        }

        /// <summary>
        /// This method is used in encryption method for building encrypted text
        /// </summary>
        /// <param name="ch"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public char Cipher(char ch, int shift)
        {
            if (!char.IsLetter(ch))
                return ch;

            if (shift > engAlphabet)
                shift %= engAlphabet;

            else if (shift < 0)
                shift = (shift % engAlphabet) + engAlphabet;

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + shift) - d) % 26) + d);
        }

        /// <summary>
        /// Method checking for only english characters
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool IsUnicode(string input)
        {
            var asciiBytesCount = Encoding.ASCII.GetByteCount(input);
            var unicodBytesCount = Encoding.UTF8.GetByteCount(input);
            return asciiBytesCount != unicodBytesCount;
        }

        /// <summary>
        /// Encryption method
        /// </summary>
        /// <param name="input"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public string Encrypt(string input, int shift)
        {
            if (IsUnicode(input))
                throw new ArgumentException("Invalid input (Only english symbols allowed)");

            if (input.Any(Char.IsDigit))
                throw new ArgumentException("Input contains a number");

            string output = string.Empty;

            foreach (char ch in input)
                output += Cipher(ch, shift);

            return output;
        }

        /// <summary>
        /// Decryption method
        /// </summary>
        /// <param name="input"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public string Decrypt(string input, int shift)
        {
            return Encrypt(input, engAlphabet - shift);
        }
    }
}
