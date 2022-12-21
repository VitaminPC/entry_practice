
using System;

namespace Practice9
{
    class Program
    {
        static void Main(string[] args)
        {
            void Zadacha64()
            {
                // Задача 64: Задайте значения M и N. Напишите рекурсивный метод, который выведет все натуральные числа кратные 3-ём в промежутке от M до N.
                // M = 1; N = 9. -> "3, 6, 9"
                // M = 13; N = 20. -> "15, 18"        
                Console.WriteLine("Input M:");
                int m = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input N:");
                int n = Convert.ToInt32(Console.ReadLine());
                WriteThirds(m, n);
                void WriteThirds(int m, int n)
                {
                    if (m % 3 == 0) Console.Write($"{m} ");
                    if (m < n) WriteThirds(++m, n);
                    else return;
                }
            }

            void Zadacha66()
            {
                // Задача 66: Задайте значения M и N. Напишите рекурсивный метод, который найдёт сумму натуральных элементов в промежутке от M до N.
                // M = 1; N = 15 -> 120
                // M = 4; N = 8. -> 30

                Console.WriteLine("Input M:");
                int m = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input N:");
                int n = Convert.ToInt32(Console.ReadLine());
                int result = Sum(m, n);
                Console.WriteLine($"Sum = {result}");
                int Sum(int m, int n)
                {
                    if (m < n) m = m + Sum(++m, n);
                    return m;
                }
            }

            void Zadacha68()
            {
                // Задача 68: Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.
                // m = 2, n = 3 -> A(m,n) = 9
                // m = 3, n = 2 -> A(m,n) = 29        

                Console.WriteLine("Input M:");
                int m = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input N:");
                int n = Convert.ToInt32(Console.ReadLine());
                int result = Akkerman(m, n);
                Console.WriteLine($"Sum = {result}");
                int Akkerman(int m, int n)
                {
                    if (m == 0) return n + 1;
                    else if (n == 0) return Akkerman(m - 1, 1);
                    else return Akkerman(m - 1, Akkerman(m, n - 1));
                }
            }

            void ZadachaDop1()
            {
                // Задача 1. Дано предложение. Напишите рекурсивный метод, подсчитывающий количество слов в данном предложении. 
                // Словом считается последовательность символов без пробелов.
                Console.WriteLine("Введите предложение:");
                string str = Console.ReadLine();
                str = str + " ";
                int result = WordCounter(str, 0);
                Console.WriteLine($"Количество слов {result}");
                int WordCounter(string str, int position)
                {
                    if (position >= str.Length) return 0;
                    else
                    {
                        if (position > 0 && str[position] == ' ' && str[position - 1] != ' ')
                            return 1 + WordCounter(str, position + 1);
                        else
                            return WordCounter(str, position + 1);
                    }
                }
            }

            void ZadachaDop2()
            {
                // Задача 2. Известно, что пароль длиной 3 символа состоит из латинских букв строчного регистра и цифр от 0 до 9. 
                // Напишите рекурсивный метод, который перебирает все комбинации паролей. 
                string symbols = "abcdefghijklmnopqrstuvwxyz0123456789";
                TryToOpen(0, 0, 0);
                int i = 0; int j = 0; int k = 0;
                //TryToOpen2(0);

                bool TryKeyForDoor(string key)
                {
                    if (key.Equals("apy")) return true;
                    return false;
                }

                bool TryToOpen(int i, int j, int k)
                {

                    //Console.WriteLine($"i ={i} j = {j} k = {k}");
                    if (i == symbols.Length - 1 && j == symbols.Length - 1 && k == symbols.Length - 1)
                    {
                        Console.WriteLine("Can't open the door.");
                        return false;
                    }

                    if (TryKeyForDoor($"{symbols[i]}{symbols[j]}{symbols[k]}"))
                    {
                        Console.WriteLine($"Key for door = {symbols[i]}{symbols[j]}{symbols[k]}");
                        return true;
                    }
                    if (k < symbols.Length - 1) { k++; return TryToOpen(i, j, k); }
                    if (j < symbols.Length - 1) { j++; return TryToOpen(i, j, 0); }
                    if (i < symbols.Length - 1) { i++; return TryToOpen(i, 0, 0); }

                    return false;

                }

                bool TryToOpen2(int variant)
                {
                    i = variant / (symbols.Length * symbols.Length);
                    j = (variant % (symbols.Length * symbols.Length)) / symbols.Length;
                    k = variant % symbols.Length;
                    //Console.WriteLine($"i ={i} j = {j} k = {k}");
                    if (i == symbols.Length - 1 && j == symbols.Length - 1 && k == symbols.Length - 1)
                    {
                        Console.WriteLine("Can't open the door.");
                        return false;
                    }

                    if (TryKeyForDoor($"{symbols[i]}{symbols[j]}{symbols[k]}"))
                    {
                        Console.WriteLine($"Key for door = {symbols[i]}{symbols[j]}{symbols[k]}");
                        return true;
                    }
                    return TryToOpen2(++variant);

                }
            }

            void ZadachaDop3()
            {
                // Задача 3. Даны два числа a, b. Сложите их, используя только операции инкремента и декремента.
                Console.WriteLine("Input M:");
                int m = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input N:");
                int n = Convert.ToInt32(Console.ReadLine());
                int absN = Math.Abs(n);
                int result = m;
                for (int i = 0; i < absN; i++)
                    if (n > 0) result++;
                    else result--;
                Console.WriteLine($"M + N = {result}");
            }

            void ZadachaDop4()
            {
                // Задача 4. Даны два числа a, b. Перемножьте их, используя только операции инкремента и декремента. 
                Console.WriteLine("Input M:");
                int m = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input N:");
                int n = Convert.ToInt32(Console.ReadLine());
                int absN = Math.Abs(n);
                int absM = Math.Abs(m);
                int result = 0;
                for (int i = 0; i < absM; i++)
                    for (int j = 0; j < absN; j++) result++;

                Console.WriteLine($"M * N = {Math.Sign(m * n) * result}");
            }
            ZadachaDop4();
            //ZadachaDop3();
            //ZadachaDop2();
            //ZadachaDop1();      
            //Zadacha68();
            //Zadacha66();
            //Zadacha64();
        }


        static void FillLikeSpiral(int[,] array)
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);
            int size = array.Length;
            int i = 0;
            int j = 0;
            int columnDirection = 1;
            int rowDirection = 0;
            int direction = 0;
            int margine = columns;

            for (int k = 0; k < size; k++)
            {
                array[i, j] = k + 1;
                margine--;
                if (margine == 0)
                {
                    margine = columns * (direction % 2) + rows * ((direction + 1) % 2) - 1 - direction / 2;
                    int temp = columnDirection;
                    columnDirection = -rowDirection;
                    rowDirection = temp;
                    direction++;
                }
                j += columnDirection;
                i += rowDirection;
            }
        }
        static void SortArray(int[] array, bool Asc = true, bool SortByAbs = false)
        {
            int size = array.Length;
            int firstValue;
            int secondValue;
            bool exchange;

            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    firstValue = array[i];
                    secondValue = array[j];
                    if (SortByAbs)
                    {
                        firstValue = Math.Abs(array[i]);
                        secondValue = Math.Abs(array[j]);
                    }
                    if (Asc) exchange = firstValue > secondValue; else exchange = firstValue < secondValue;
                    if (exchange) (array[i], array[j]) = (array[j], array[i]);
                }
            }
        }
        static void FillArray(int[] array, int begin = 0, int range = 10)
        {
            range++;
            Random ramdomizer = new Random();
            int size = array.Length;
            for (int i = 0; i < size; i++)
                array[i] = ramdomizer.Next(begin, range);
        }

        static void FillArray(double[] array, int range = 100, int rnd = 2)
        {
            range++;
            Random ramdomizer = new Random();
            int size = array.Length;
            for (int i = 0; i < size; i++)
            {
                array[i] = Math.Round(ramdomizer.NextDouble() * range, rnd);
            }
        }
        static void FillArray(int[,] array, int begin = 0, int range = 10, bool onlyOnes = false)
        {
            range++;

            Random ramdomizer = new Random();
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int value = ramdomizer.Next(begin, range);
                    if (!onlyOnes || value == 1) array[i, j] = value;
                }
            }
        }

        static void FillArray(double[,] array, int range = 0, int rnd = 10)
        {
            Random ramdomizer = new Random();
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array[i, j] = Math.Round(ramdomizer.NextDouble() * range, rnd);
                }
            }
        }
        static void PrintArray(int[] array)
        {
            Console.WriteLine();
            int size = array.Length;
            for (int i = 0; i < size; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        static void PrintArray(double[] array)
        {
            Console.WriteLine();
            int size = array.Length;
            for (int i = 0; i < size; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
        static void PrintArray(int[,] array, char symbol = '\t', string message = "")
        {
            if (!message.Equals(""))
            {
                Console.WriteLine();
                Console.WriteLine(message);
            }
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{array[i, j]}{symbol}");
                }
            }
            Console.WriteLine();
        }

        static void PrintArray(double[,] array, char symbol = '\t')
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{array[i, j]}{symbol}");
                }
            }
            Console.WriteLine();
        }
    }
}