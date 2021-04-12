using System;
using System.Collections.Generic;

//Тимофеев
//3. Написать программу обмена значениями двух целочисленных переменных:
//b. * без использования третьей переменной.
//5.С клавиатуры вводится номер месяца. Требуется определить, к какому времени года он относится.
//12.Написать функцию нахождения максимального из трех чисел.
//13. * Написать функцию, генерирующую случайное число от 1 до 100.

//а) с использованием стандартной функции rand()
//14. * Автоморфные числа.Натуральное число называется автоморфным, если оно равно последним цифрам своего квадрата. Например, 252 = 625. Напишите программу, которая вводит натуральное число N и выводит на экран все автоморфные числа, не превосходящие N.

//Достаточно решить 3 задачи. Записывайте в начало программы условие и свою фамилию. Все решения создавайте в одной программе. Задачи со звездочками выполняйте в том случае, если решили базовые. Снабдите программу меню. 123

namespace SimpleAlg
{
    class Program
    {
        public static void ChangeVal(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;

        }

        public static void BoolChangeVal(ref int a, ref int b)
        {
            a = a ^ b;
            b = b ^ a;
            a = a ^ b;
        }

        public static int MaxNumber(int a, int b, int c)
        {
            int[] arr = new int[3];
            arr[0] = a;
            arr[1] = b;
            arr[2] = c;
            int max = a;
            for (int i = 0; i < 3; i++)
            {
                if (arr[i] > max) max = arr[i];
            }
            return max;
        }

        public static int RandomNumber()
        {
            Random rnd = new()
                ;
            int rand = rnd.Next(1, 100);
            return rand;

        }
        public static string SeasonByNumber(int i)
        {
            string s;
            switch (i)
            {
                case 1:
                case 2:
                case 12:
                    s = "Зима";
                    break;
                case 3:
                case 4:
                case 5:
                    s = "Весна";
                    break;
                case 6:
                case 7:
                case 8:
                    s = "Лето";
                    break;
                case 9:
                case 10:
                case 11:
                    s = "Осень";
                    break;
                default:
                    s = "Ничего";
                    break;

            }
            return s;
        }

        public static int[] AutomorphByNumber(int a)
        {
            List<int> temp = new();
            for (int i = 1; i <= a; i++)
                if (IsAutomorph(i) == true) temp.Add(i);
            int[] s = new int[temp.Count];
            temp.CopyTo(s);
            return s;
        }

        static bool IsAutomorph(int a)
        {
            if ((a * a) % (Math.Pow(10, NumLength(a))) == a)
                return true;
            else return false;
        }

        static int NumLength(int a)
        {
            int c = 0;
            while (a > 0) { c++; a /= 10; };
            return c;


        }

        static void Main(string[] args)
        {
            int a = 20;
            int b = 40;
            int c = 100;
            Console.WriteLine($"{a},{b}");
            ChangeVal(ref a, ref b);
            Console.WriteLine($"{a},{b}");
            BoolChangeVal(ref a, ref b);
            Console.WriteLine($"{a},{b}");
            Console.WriteLine("Введите число от 1 до 12");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine(SeasonByNumber(k));
            Console.WriteLine(MaxNumber(a, b, c));
            Console.WriteLine(RandomNumber());
            Console.WriteLine(RandomNumber());
            Console.WriteLine(RandomNumber());
            foreach (int i in AutomorphByNumber(625))
                Console.Write(i + " ");



        }
    }
}

