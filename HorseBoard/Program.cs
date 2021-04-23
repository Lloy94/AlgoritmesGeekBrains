using System;

namespace HorseBoard
{
    //Тимофеев
    //3. ***Требуется обойти конем шахматную доску размером NxM, пройдя через все поля доски по одному разу.
    /*class Program
    {
        static int N =9;

        static int M = 5;


        public static int[,] board = new int[N, M];

        public static int SearchSolution(int n)
        {
            if (CheckBoard() == false) return 0 ;
            if (n == M * N+1) return 1;
            for (int row = 0; row < N; row++)
                for (int col = 0; col < M; col++)
                {
                    if (board[row, col] == 0)
                    {
                        board[row, col] = n;
                        if (SearchSolution(n + 1) == 1) return 1;
                        board[row, col] = 0;
                    }
                }
            return 0;

        }

        public static bool CheckBoard()
        {
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    if (board[i, j] != 0)
                        if (CheckHorse(i, j) == false) return false;
            return true;
        }

        public static bool CheckHorse(int x, int y)
        {
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    if (board[i, j] != 0)
                        if (!(i == x && j == y))
                        {
                            if (i == x + 1 &&j == y - 2) return false;
                            else if (i == x + 2 && j == y + 1) return false;
                            else if (i == x - 1 && j == y + 2) return false;
                            else if (i == x - 2 && j == y - 1) return false;
                            else if (i == x - 1 && j == y - 2) return false;
                            else if (i == x + 2 && j == y - 1) return false;
                            else if (i == x + 1 && j == y + 2) return false;
                            else if (i == x - 2 && j == y + 1) return false;

                        }
            return true;
        }
        static void Main(string[] args)
        {
            
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++) Console.WriteLine($"{ board[i, j]}");
            SearchSolution(1);
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++) Console.WriteLine($"{ board[i, j]}");
        }
    }
}
*/

    class Program
    {
        static int[] arri = { 1, 1, -1, -1, -2, -2, 2, 2 };
        static int[] arrj = { -2, 2, 2, -2, -1, 1, 1, -1 };
        static int[,] dock = new int[100, 100];
        static int M;
        static int N;        
        static void Print (int [,]arr)
        {
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {                
                    Console.Write(string.Format(" {0,3} ", dock[i, j]));
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Введите M");
             M = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите N");
             N = Convert.ToInt32(Console.ReadLine());
            Print(dock);  
            rekt(0, 0, 1);
            Console.WriteLine("-------------------------------------------");
            Print(dock);


            Console.ReadLine();

        }

        static void rekt(int x, int y, int step)
        {

            dock[x, y] = step;
            int i;
            int j;

            for (i = 0; i < 8; i++)

            {
                if (i < 4)
                {
                    for (j = 0; j < 4; j++)

                    {
                        int x1 = x + arri[i];
                        int y1 = y + arrj[j];

                        if ((x1 == x) && (y1 == y))
                            rekt(x1, y1, step);
                        else if ((x1 >=0)&&(y1>=0)&&(x1 < M) && (y1 < N) && (dock[x1, y1] == 0))

                        {

                            rekt(x1, y1, step + 1);

                        }
                    }
                }
                else
                {
                    for (j = 4; j < 8; j++)

                    {
                        int x1 = x + arri[i];
                        int y1 = y + arrj[j];

                        if ((x1 == x) && (y1 == y))
                            rekt(x1, y1, step);
                        else if ((x1 >= 0) && (y1 >= 0) && (x1 < M) && (y1 < N) && (dock[x1, y1] == 0))

                        {

                            rekt(x1, y1, step + 1);

                        }
                    }
                }
            }
        }
    }
}
