using System;
using System.Text;
using Xunit;

namespace CipherTests
{
    public class CipherTests
    {
       
        [Fact]
        public void ContainsNonEnglishChars()
        {
            var data = new Caesar_Cipher.Models.CaesarsCipherModel();
            Assert.Throws<ArgumentException>(
                () => data.Encrypt("фдбdsg", 51)
                );
        }
        [Fact]
        public void NumbersInString()
        {
            var data = new Caesar_Cipher.Models.CaesarsCipherModel();
            Assert.Throws<ArgumentException>(
                () => data.Encrypt("labasd184", 678)
                );
        }
        [Fact]
        public void CipherMatchesOriginal()
        {
            var data = new Caesar_Cipher.Models.CaesarsCipherModel();
            int shift = 65;
            string original = "Labas";
            var encrypted = data.Encrypt(original, shift);
            var decrypted = data.Decrypt(encrypted, shift);
            Assert.Equal(original, decrypted);
        }

        [Fact]
        public void EmptyString()
        {
            var data = new Caesar_Cipher.Models.CaesarsCipherModel();
            data.Input = "";
            data.Shift = 5;
            var encrypted = data.Encrypt(data.Input, data.Shift);
            var decrypted = data.Decrypt(encrypted, data.Shift);
            Assert.Equal(encrypted, decrypted);
        }
        [Fact]
        public void EmptyShiftValue()
        {
            var data = new Caesar_Cipher.Models.CaesarsCipherModel();
            data.Input = "Hello World";
            data.Shift = 0;
            var encrypted = data.Encrypt(data.Input, data.Shift);
            var decrypted = data.Decrypt(encrypted, data.Shift);
            Assert.Equal(data.Input, decrypted);
        }
    }
}
