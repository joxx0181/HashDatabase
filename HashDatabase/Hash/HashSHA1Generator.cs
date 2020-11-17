using System.Security.Cryptography;
using System.Text;

namespace HashDatabase
{
    // This class represents Hashsha1generator and implements interface!
    class HashSHA1Generator : IHashGenerator
    {
        // The body of interface method is provided here!
        public string GetHash(string input)
        {
            // Create SHA1!  
            using (SHA1 sha1Hash = SHA1.Create())
            {
                // ComputeHash - returns byte array! 
                byte[] bytes = sha1Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string!   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                // Return a string!
                return builder.ToString();
            }
        }
    }
}
