using System.Security.Cryptography;
using System.Text;

namespace HashDatabase
{
    // This class represents Hashsha256generator and implements interface!
    class HashSHA256Generator : IHashGenerator
    {
        // The body of interface method is provided here!
        public string GetHash(string input)
        {
            // Create SHA256! 
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array!  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

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
