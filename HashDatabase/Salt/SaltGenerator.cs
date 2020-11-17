using System;
using System.Security.Cryptography;

namespace HashDatabase
{
    // This class represents Saltgenerator and implements interface!
    public class SaltGenerator : ISaltGenerator
    {
            // The body of interface method is provided here!
            public string GetSalt(int size)
            {
                // Generate a cryptographic random number using the cryptographic service provider!
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                byte[] buff = new byte[size];
                rng.GetBytes(buff);

                // Return a Base64 string representation of the random number!
                return Convert.ToBase64String(buff);
            }
    }
}
