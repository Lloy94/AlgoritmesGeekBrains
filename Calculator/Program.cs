using System;

namespace Calculator

{
    class Program
    {
        //Тимофеев
        //Исполнитель Калькулятор преобразует целое число, записанное на экране. У исполнителя две команды, каждой команде присвоен номер:
        //        Прибавь 1
        //    Умножь на 2

        //Первая команда увеличивает число на экране на 1, вторая увеличивает это число в 2 раза.Сколько существует программ, которые число 3 преобразуют в число 20?
        //а) с использованием массива;
        //б) с использованием рекурсии.
        static int Doubler(int a, int b)
        {
            int[,] arr = new int[2, b + 1];
            arr[0, a] = 3;


            for (int i = 0; i < 1; i++)
            {
                for (int j = a + 1; j <= b; j++)
                {
                    arr[i, j] = arr[i, j - 1] + 1;
                }

            }
            arr[1, a] = 1;
            for (int i = 1; i < 2; i++)
            {
                for (int j = a + 1; j <= b; j++)
                {
                    if (arr[0, j] % 2 == 0 && arr[0, j] / 2 >= a)
                        arr[i, j] = arr[i, j - 1] + arr[i, arr[0, j] / 2];
                    else arr[i, j] = arr[i, j - 1];
                }
            }
            return arr[1, b];
        }

        static int Calc(int a, int b)
        {
            if (a == b) return 1;
            else if (a > b) return 0;
            return Calc(a + 1, b) + Calc(a * 2, b);
        }

        static void Main(string[] args)
        {
            int a = 3;
            int b = 20;
            Console.WriteLine($"Количество возможных программ: {Doubler(a, b)}");
            Console.WriteLine($"Количество возможных прогмамм: {Calc(a, b)}");


        }
    }
}
