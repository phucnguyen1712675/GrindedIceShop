using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.SupportCompareStrings
{
    class MyCompareString
    {
        public bool CompareString(string str1, string str2)
        {
            str1 = str1.Replace(" ", "").ToLower();
            str2 = str2.Replace(" ", "").ToLower();
            return str1.Equals(str2);
        }

        public bool CompareChar(char c1, char c2)
        {
            c1 = c1.ToString().ToLower()[0];
            c2 = c2.ToString().ToLower()[0];
            return c1 == c2;
        }

        public char getSizeChar(string size)
        {
            char result = 'm';
            if (!string.IsNullOrEmpty(size))
                result = size.Replace(" ", "").ToLower()[0];
            return result;
        }
    }
}
