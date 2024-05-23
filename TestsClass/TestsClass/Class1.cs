using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestsClass
{
    public class TextClass
    {
        public static bool IsOnlyDigits(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c)) 
                { 
                return false;
                }
            }
            return true;
        }

        public static bool IsCyrillic(string text)
        {
            foreach (char c in text)
            {
                if (!(c >= 'а' && c <= 'я' || c >= 'А' && c <= 'Я'))
                {
                    return false;
                }
            }
            return true;
        }


    }
}
