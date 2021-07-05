using System;
using System.IO;

namespace ConsoleApp1

    //Тимофеев
    //2. Переписать программу, реализующую двоичное дерево поиска.

//а) Добавить в него обход дерева различными способами;
//б) Реализовать поиск в двоичном дереве поиска;
//в) *Добавить в программу обработку командной строки, с помощью которой можно указывать, из какого файла считывать данные, каким образом обходить дерево.
{
    class Program
    {
        class Node
        {
            public Node LeftNode { get; set; }
            public Node RightNode { get; set; }
            public int Data { get; set; }
        }

        class BinaryTree
        {
            public Node Root { get; set; }

            public bool Add(int value)
            {
                Node before = null, after = Root;

                while (after != null)
                {
                    before = after;
                    if (value < after.Data)
                        after = after.LeftNode;
                    else if (value > after.Data)
                        after = after.RightNode;
                    else
                    {
                        return false;
                    }
                }

                Node newNode = new()
                {
                    Data = value
                };

                if (Root == null)
                    Root = newNode;
                else
                {
                    if (value < before.Data)
                        before.LeftNode = newNode;
                    else
                        before.RightNode = newNode;
                }

                return true;
            }

            public Node Find(int value)
            {
                return Find(value, Root);
            }




            private Node Find(int value, Node parent)
            {
                if (parent != null)
                {
                    if (value == parent.Data) return parent;
                    if (value < parent.Data)
                        return Find(value, parent.LeftNode);
                    else
                        return Find(value, parent.RightNode);
                }

                return null;
            }

            public void Search (int value)
            { 
                if (Find(value) == null) Console.WriteLine("Элемент не найден ");
                else Console.WriteLine("Элемент найден ");
            }

            public void TraversePreOrder(Node parent)
            {
                if (parent != null)
                {
                    Console.Write(parent.Data + "  ");
                    TraversePreOrder(parent.LeftNode);
                    TraversePreOrder(parent.RightNode);

                }
            }

            public void TraverseInOrder(Node parent)
            {
                if (parent != null)
                {
                    TraverseInOrder(parent.LeftNode);
                    Console.Write(parent.Data + " ");
                    TraverseInOrder(parent.RightNode);
                }
            }

            public void TraversePostOrder(Node parent)
            {
                if (parent != null)
                {
                    TraversePostOrder(parent.LeftNode);
                    TraversePostOrder(parent.RightNode);
                    Console.Write(parent.Data + " ");
                }
            }

            

        }

        public void LoadFromFile(string filename)
        {
            BinaryTree binaryTree = new();
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string num;

                    while ((num = sr.ReadLine()) != null)
                    {
                        binaryTree.Add(int.Parse(num));
                    }
                }
            }
            catch (Exception) { Console.WriteLine("файл не обнаружен"); }
        }
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new();

            binaryTree.Add(1);
            binaryTree.Add(2);
            binaryTree.Add(7);
            binaryTree.Add(3);
            binaryTree.Add(10);
            binaryTree.Add(5);
            binaryTree.Add(8);

            

           
            Console.WriteLine("Выберите метод обхода: 1 - КЛП, 2 - ЛКП, 3 - ЛПК");
            int i = int.Parse(Console.ReadLine());
            switch (i) {
            case 1:
                Console.WriteLine("КЛП обход ");
                binaryTree.TraversePreOrder(binaryTree.Root);
                Console.WriteLine();
            break;

            case 2:
                Console.WriteLine("ЛКП обход ");
                binaryTree.TraverseInOrder(binaryTree.Root);
                Console.WriteLine();
                break;

            case 3:
                Console.WriteLine("ЛПК обход");
                binaryTree.TraversePostOrder(binaryTree.Root);
                Console.WriteLine();
                break;
            default:
                Console.WriteLine("Введён неверный номер, выберите другой");
                break;
            }

            Console.WriteLine("Поиск заданного элемента в дереве. Введите число");
            int k = int.Parse(Console.ReadLine());
            binaryTree.Search(k);

            //Console.WriteLine("Выберите файл для чтения");
            //int j = int.Parse(Console.ReadLine());
            //switch (j)
            //{
            //    case 1:
            //        LoadFromFile(filename1);
            //        break;
            //    case 2:
            //        LoadFromFile(filename2);
            //        break;
            //    default:
            //        Console.WriteLine("Введён неверный номер, введите другой");
            //        break;
            //}
                
            
        }

    }
}