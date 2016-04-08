using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen
{
    public class PasswordGenerator
    {
        Random rnd = new Random();
        const string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowerCase = "abcdefghijklmnopqrstuvwxyz";
        const string numbers = "0123456789";

        public string GetPassword()
        {
            
            string password = string.Empty;
            int key = 0;
            for (int i = 0; i < 20; i++)
            {
                key = rnd.Next(1, 101);
                if (key < 34)
                    password += upperCase[rnd.Next(0, upperCase.Length)];
                else if (key > 33 && key < 68)
                    password += lowerCase[rnd.Next(0, lowerCase.Length)];
                else
                    password += numbers[rnd.Next(0, numbers.Length)];
            }
            return password;
        }
    }
}
