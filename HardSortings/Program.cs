using System;

namespace HardSortings
{
    //Тимофеев
    //1. Реализовать сортировку подсчетом.
    //2. Реализовать быструю сортировку.
    //3. * Реализовать сортировку слиянием.
    //4.Проанализировать время работы каждого из вида сортировок для 100 элементов
    class Program
    {
        static int counting;

        static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;
            counting++;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                    counting++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                    counting++;
                }

                index++;
                counting++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
                counting++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
                counting++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
                counting++;
            }
        }

        static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }

            return array;
        }

        static int[] MergeSort(int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }
        static void Swap(ref int x, ref int y)
        {
            var t = x;
            counting++;
            x = y;
            counting++;
            y = t;
            counting++;
        }

        static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                    counting++;
                }
                counting++;
            }

            pivot++;
            counting++;
            Swap(ref array[pivot], ref array[maxIndex]);
            counting++;
            return pivot;
        }

        static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        static int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }

        static int[] CountingSort(int[] array)
        {
            var min = array[0];
            var max = array[0];
            foreach (int element in array)
            {
                if (element > max)
                {
                    max = element;
                }
                else if (element < min)
                {
                    min = element;
                }
            }

            var correctionFactor = min != 0 ? -min : 0;
            max += correctionFactor;

            var count = new int[max + 1];
            for (var i = 0; i < array.Length; i++)
            {
                count[array[i] + correctionFactor]++;
            }

            var index = 0;
            for (var i = 0; i < count.Length; i++)
            {
                for (var j = 0; j < count[i]; j++)
                {
                    array[index] = i - correctionFactor;
                    index++;
                }
            }

            return array;
        }

        static int QuickSortCounting(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return counting;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSortCounting(array, minIndex, pivotIndex - 1);
            counting++;
            QuickSortCounting(array, pivotIndex + 1, maxIndex);
            counting++;

            return counting;
        }

        static int MergeSortCounting(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                counting++;
                MergeSortCounting(array, lowIndex, middleIndex);
                counting++;
                MergeSortCounting(array, middleIndex + 1, highIndex);
                counting++;
                Merge(array, lowIndex, middleIndex, highIndex);
                counting++;
            }

            return counting++;
        }


        static int CountingSortCounting(int[] array)
        {
            int counting = 0;
            var min = array[0];
            var max = array[0];
            foreach (int element in array)
            {
                if (element > max)
                {
                    max = element;
                    counting++;
                }
                else if (element < min)
                {
                    min = element;
                    counting++;
                }
            }

            var correctionFactor = min != 0 ? -min : 0;
            counting++;
            max += correctionFactor;
            counting++;

            var count = new int[max + 1];
            for (var i = 0; i < array.Length; i++)
            {
                count[array[i] + correctionFactor]++;
                counting++;
            }

            var index = 0;
            counting++;
            for (var i = 0; i < count.Length; i++)
            {
                for (var j = 0; j < count[i]; j++)
                {
                    array[index] = i - correctionFactor;
                    index++;
                    counting++;
                }
            }

            return counting;
        }
        public static void Print(int[] arr)
        {
            foreach (int x in arr)
            {
                Console.Write(x + " ");
            }
        }
        static void Main(string[] args)
        {
            int[] arr = new int[100];
            Random rd = new();
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = rd.Next(1, 101);
            }
            int[] arr1 = new int[100];
            Array.Copy(arr, arr1, arr.Length);
            int[] arr2 = new int[100];
            Array.Copy(arr, arr2, arr.Length);
            int[] arr3 = new int[100];
            Array.Copy(arr, arr3, arr.Length);
            int[] arr4 = new int[100];
            Array.Copy(arr, arr4, arr.Length);
            int[] arr5 = new int[100];
            Array.Copy(arr, arr5, arr.Length);
            Console.WriteLine("\nМассив до сортировки");
            Print(arr);
            QuickSort(arr);
            Console.WriteLine("\nМассив после быстрой сортировки");
            Print(arr);
            Console.WriteLine("\nМассив до сортировки");
            Print(arr1);
            MergeSort(arr1);
            Console.WriteLine("\nМассив после сортировки слиянием");
            Print(arr1);
            Console.WriteLine("\nМассив до сортировки");
            Print(arr2);
            CountingSort(arr2);
            Console.WriteLine("\nМассив после сортировки подсчетом");
            Print(arr2);
            int[] bestToWorst = new int[3];
            counting = 0;
            bestToWorst[0] = QuickSortCounting(arr3, 0, 99);
            Console.WriteLine($"\nКоличество операций для  быстрой сортировки -  {bestToWorst[0]}");
            counting = 0;
            bestToWorst[1] = MergeSortCounting(arr3, 0, 99);
            Console.WriteLine($"\nКоличество операций для сортировки слияением -  {bestToWorst[1]}");
            bestToWorst[2] = CountingSortCounting(arr5);
            Console.WriteLine($"\nКоличество операций для сортировки подсчетом - {bestToWorst[2]}");
            Console.WriteLine($"\nОт лучшей к худшей : ");
            QuickSort(bestToWorst);
            Print(bestToWorst);
        }
    }
}