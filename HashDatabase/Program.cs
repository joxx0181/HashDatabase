using System;

namespace HashDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter username: ");
            string userName = Console.ReadLine();

            Console.Write("Enter password: ");
            string userPass = Console.ReadLine();

            int saltSize = 2;
            ISaltGenerator salt = new SaltGenerator();
            IHashGenerator hash1 = new HashMD5Generator();
            IHashGenerator hash2 = new HashSHA1Generator();
            IHashGenerator hash3 = new HashSHA256Generator();
            IHashGenerator hash4 = new HashSHA512Generator();

            string passSalt = userPass + salt.GetSalt(saltSize);
            string passMD5 = hash1.GetHash(passSalt);
            string passSHA1 = hash2.GetHash(passSalt);
            string passSHA256 = hash3.GetHash(passSalt);
            string passSHA512 = hash4.GetHash(passSalt);

            Console.WriteLine("\nYour password in Hash values :\r\n");
            Console.WriteLine("SALT  : {0}", passSalt);
            Console.WriteLine("MD5   : {0}", passMD5);
            Console.WriteLine("SHA1  : {0}", passSHA1);
            Console.WriteLine("SHA256: {0}", passSHA256);
            Console.WriteLine("SHA512: {0}", passSHA512);

            IData insertData = new DataInsert();
            IData verifyData = new DataVerify();

            string queryMain = "DROP TABLE IF EXISTS HashDB.dbo.HashTable CREATE TABLE HashTable(Username NVARCHAR(MAX) NULL, SALT NVARCHAR(MAX) NULL, MD5 NVARCHAR(MAX) NULL, SHA1 NVARCHAR(MAX) NULL, SHA256 NVARCHAR(MAX) NULL, SHA512 NVARCHAR(MAX) NULL)";
            string queryInsert = "INSERT INTO HashTable (Username, SALT, MD5, SHA1, SHA256, SHA512) VALUES('" + userName + "', '" + passSalt + "', '" + passMD5 + "', '" + passSHA1 + "', '" + passSHA256 + "', '" + passSHA512 + "')";
            string querySelect = "SELECT SALT FROM HashTable";

            insertData.GetSQLquery(queryMain);
            insertData.GetSQLquery(queryInsert);

            Console.WriteLine("\ndata stored in database\n");

            Console.Write("Re-Enter username: ");
            string userNameRE = Console.ReadLine();

            Console.Write("Re-Enter password: ");
            string userPassRE = Console.ReadLine();

            if (userName == userNameRE && userPass == userPassRE)
            {
                if (verifyData.GetSQLquery(querySelect) == passSalt)
                {
                    Console.WriteLine("password verify");
                }
            }
            else
            {
                Console.WriteLine("Something went wrong - could not recognize the username or password \npassword not verify");
            }
            Console.ReadKey();
        }
    }
}
