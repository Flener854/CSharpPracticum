using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Rashirenie
{
    public static class StringExtensions
    {
        // 1) Палиндром (без учёта регистра, пробелов и пунктуации)
        public static bool IsPalindrome(this string s)
        {
            if (string.IsNullOrEmpty(s)) return true;

            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(s[left])) left++;
                while (left < right && !char.IsLetterOrDigit(s[right])) right--;

                if (char.ToLowerInvariant(s[left]) != char.ToLowerInvariant(s[right]))
                    return false;

                left++;
                right--;
            }
            return true;
        }

        // 2) Количество слов (разделители — всё, что не буква/цифра)
        public static int WordCount(this string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            int count = 0;
            bool inWord = false;

            foreach (char c in s)
            {
                if (char.IsLetterOrDigit(c))
                {
                    if (!inWord) { count++; inWord = true; }
                }
                else
                {
                    inWord = false;
                }
            }
            return count;
        }

        // 3) Реверс строки (без LINQ и Array.Reverse)
        public static string ReverseString(this string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            char[] chars = s.ToCharArray();
            for (int i = 0, j = chars.Length - 1; i < j; i++, j--)
                (chars[i], chars[j]) = (chars[j], chars[i]);

            return new string(chars);
        }
    }
}
