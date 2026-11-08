using System;
using CSharpPracticum.Common;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level1
{
    [Common.TaskInfoAttribute("Level-1")]
    internal class Task12_Palindrom : Common.ITask
    {
        string ITask.Title => "Палиндром (без учёта регистра/пробелов)";

        string ITask.Description => "Что сделать: проверить, является ли строка палиндромом.";

        string[] ITask.Requirements => new[] { "Игнорировать регистр (ToLower/ToUpper).", "Игнорировать пробелы и знаки пунктуации (или хотя бы пробелы).", "Не использовать LINQ Reverse.", "Пустая строка и строка из одного символа — палиндром." };

        static bool IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return true;   

            int left = 0;
            int right = s.Length - 1;

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

        void ITask.Run()
        {
            Console.Write("Введите строку: ");
            string input = Console.ReadLine() ?? "";

            bool isPal = IsPalindrome(input);
            Console.WriteLine(isPal ? "Палиндром" : "Не палиндром");
        }
    }
}
