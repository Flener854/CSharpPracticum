using CSharpPracticum.Common;
using CSharpPracticum.Rashirenie;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks.Level2
{
    [Common.TaskInfoAttribute("Level-2", 18)]
    internal class Task18_PARS_VS_CATCH : Common.ITask
    {
        string ITask.Title => "TryParse vs try/catch";

        string ITask.Description => "Что сделать: сравнить два способа обработки некорректного ввода числа.";

        string[] ITask.Requirements => new[] { "Способ 1: int.TryParse — вернуть bool + значение через out.", "Способ 2: int.Parse внутри try/catch — ловить FormatException.", "Оба оформить отдельными методами.", "Продемонстрировать на корректном и некорректном вводе." };

        static bool TryParseMethod(string input, out int value)
        {
            return int.TryParse(input, out value);
        }


        static bool TryCatchMethod(string input, out int value)
        {
            value = 0;
            try
            {
                value = int.Parse(input);
                return true;
            }
            catch (FormatException)
            {
                return false;           // "abc", "", "3.14" — не число
            }
            catch (ArgumentNullException)
            {
                return false;           // null
            }
            catch (OverflowException)
            {
                return false;           // слишком большое число
            }
        }

        void ITask.Run()
        {
            string[] inputs = { "123", "abc", "-42", "3.14", "", "  7  ", null };

            foreach (string input in inputs)
            {
                string shown = input == null ? "<null>" : $"\"{input}\"";


                bool ok1 = TryParseMethod(input, out int value1);


                bool ok2 = TryCatchMethod(input, out int value2);

                Console.WriteLine($"Ввод: {shown,-10}");
                Console.WriteLine($"  TryParse:  ok={ok1,-5} value={value1}");
                Console.WriteLine($"  try/catch: ok={ok2,-5} value={value2}");
                Console.WriteLine();
            }
        }
    }
}
