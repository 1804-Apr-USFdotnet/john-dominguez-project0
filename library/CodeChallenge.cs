using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace library
{
    public class CodeChallenge
    {
        public static bool isPalindrome(string text)
        {
            if (text == "") return true;
            text = text.ToLower();
            Regex rgx = new Regex("[^a-zA-Z0-9-]");
            text = rgx.Replace(text, "");
            int l = text.Length;
            for (int i = 0; i < l / 2; i++)
            {
                if (text[i] != text[l - i - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
