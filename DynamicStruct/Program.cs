using System;
using System.Collections.Generic;

namespace DynamicStruct

//Тимофеев
//5. **Реализовать алгоритм перевода из инфиксной записи арифметического выражения в постфиксную.
{
    class Program
    {
        internal static int Prec(char ch)
        {
            return ch switch
            {
                '+' or '-' => 1,
                '*' or '/' => 2,
                '^' => 3,
                _ => -1,
            };
        }

        public static string InfixToPostfix(string exp)
        {
            string result = "";

            Stack<char> stack = new();

            for (int i = 0; i < exp.Length; ++i)
            {
                char c = exp[i];

                if (char.IsLetterOrDigit(c))
                {
                    result += c;
                }

                else if (c == '(')
                {
                    stack.Push(c);
                }

                else if (c == ')')
                {

                    while (stack.Count > 0 &&
                            stack.Peek() != '(')
                    {
                        result += stack.Pop();
                    }

                    if (stack.Count > 0 && stack.Peek() != '(')
                    {
                        return "Неверное выражение, расставьте скобки правильно";
                    }
                    else
                    {
                        if (stack.Count > 0) stack.Pop();
                        else return "Неверное выражение, расставьте скобки правильно";
                    }

                }
                else
                {
                    while (stack.Count > 0 && Prec(c) <=
                                      Prec(stack.Peek()))
                    {
                        result += stack.Pop();
                    }
                    stack.Push(c);
                }

            }

            while (stack.Count > 0)
            {
                result += stack.Pop();
            }

            return result;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Введите выражение");
            string s = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Результат перевода в постфиксную");
            Console.WriteLine(InfixToPostfix(s));
        }
    }

}
