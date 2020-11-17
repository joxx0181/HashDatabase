using System.Security.Cryptography;
using System.Text;

namespace HashDatabase
{
    // This class represents Hashmd5generator and implements interface!
    public class HashMD5Generator : IHashGenerator
    {
        // The body of interface method is provided here!
        public string GetHash(string input)
        {
            // Create MD5!   
            using (MD5 md5Hash = MD5.Create())
            {
                // ComputeHash - returns byte array!  
                byte[] bytes = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

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
