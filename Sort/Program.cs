using System;

namespace Sort
    //Тимофеев
    //1. Попробовать оптимизировать пузырьковую сортировку. Сравнить количество операций сравнения оптимизированной и не оптимизированной программы. Написать функции сортировки, которые возвращают количество операций.
//2. * Реализовать шейкерную сортировку.
// 3. Реализовать бинарный алгоритм поиска в виде функции, которой передается отсортированный массив. Функция возвращает индекс найденного элемента или -1, если элемент не найден.
//4. *Подсчитать количество операций для каждой из сортировок и сравнить его с асимптотической сложностью алгоритма.
{
    class Program
    {
        static void Swap(ref int a, ref int b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }

        static int[] BubleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                    if (array[j] > array[j + 1])
                        Swap(ref array[j], ref array[j + 1]);
            }
            return array;
        }

        static int[] BubleSortBetter(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                bool flag = false;
                for (int j = 0; j < array.Length - 1; j++)
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        flag = true;
                    }
                if (!flag) break;
            }
            return array;
        }

        static int[] ShakerSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < array.Length - 1; j++)
                        if (array[j] > array[j + 1])
                            Swap(ref array[j], ref array[j + 1]);
                }
                else
                {
                    for (int j = array.Length; j > 0; j--)
                        if (array[j - 1] > array[j])
                            Swap(ref array[j - 1], ref array[j]);
                }
            }

            return array;
        }

        static int BinSearch(int[] array, int a)
        {
            int l = 0;
            int r = array.Length-1;


            int m = l + (r - l) / 2;
            if (a <= r)
            {
                while (l <= r && array[m] != a)
                {
                    if (array[m] < a)
                        l = m + 1;
                    else r = m - 1;
                    m = l + (r - l) / 2;
                    if (array[m] == a)
                        break;
                }
             return m;
                
            }
            else return -1;

        }

        static int BubleSortBetterCount(int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                count++;
                {
                    bool flag = false;
                    for (int j = 0; j < array.Length - 1; j++)
                    {
                        count++;
                        if (array[j] > array[j + 1])
                        {
                            Swap(ref array[j], ref array[j + 1]);
                            count++;
                            flag = true;
                        }
                        if (!flag) break;
                    }
                }
            }
            return count;
    }

        static int BubleSortCount(int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
                {
                count++;
                {
                    for (int j = 0; j < array.Length - 1; j++)
                    {
                        count++;
                        if (array[j] > array[j + 1])
                        {
                            count++;
                            Swap(ref array[j], ref array[j + 1]);
                        }
                    }

                }
            }
            return count;
        }

        static int ShakeSortCount(int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                count++;
                {
                    if (i % 2 == 0)
                    {
                        count++;
                        for (int j = 0; j < array.Length - 1; j++)
                            if (array[j] > array[j + 1])
                                Swap(ref array[j], ref array[j + 1]);
                    }
                    else
                    {
                        for (int j = array.Length-1; j > 0; j--)
                            if (array[j - 1] > array[j])
                                Swap(ref array[j - 1], ref array[j]);
                    }
                }
            }

            return count;
        }

        static void BetterToWorse(int a, int b, int c)
        {
            int min = 0;
            int middle = 0;
            int max = 0;
            if (a < b && a < c) min=a;
            else if (a < b || a < c) middle = a;
            else max = a;
            if (b < a && b < c) min = b;
            else if (b < a || b < c) middle = b;
            else max = b;
            if (c < b && c < a) min = c;
            else if (c < b || c < a) middle = c;
            else max = c;
            Console.WriteLine($"\nот лучшего к худшему {min} {middle} {max}");
        }

        static void PrintArr(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write($"{array[i]} ");
        }
        static void Main(string[] args)
        {
            int[] arr = { 5, 0, 2, 6, 4, 1, 3, 7, 8, 9 };
            //BubleSort(arr);
            //BubleSortBetter(arr);
            ShakeSortCount(arr);
            Console.WriteLine($"\n{BinSearch(arr, 6)}");
            Console.WriteLine($"\n{BinSearch(arr, 15)}");
            PrintArr(arr);
            Console.WriteLine($"\nКоличество операций для пузырьковой сортировки: {BubleSortCount(arr)}");
            Console.WriteLine($"\nКоличество операций для пузырьковой сортировки: {BubleSortBetterCount(arr)}");
            Console.WriteLine($"\nКоличество операций для пузырьковой сортировки: {ShakeSortCount(arr)}");
            BetterToWorse(BubleSortCount(arr),BubleSortBetterCount(arr),ShakeSortCount(arr));


        }
    }
}
