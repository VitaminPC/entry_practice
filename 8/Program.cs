using System;

namespace Practice8
{
    class Program
    {
        static void Main(string[] args)
        {
            void Zadacha54()
            {
                //Задача 54. Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
                Random rand = new Random();
                int rows = rand.Next(3, 9);
                int columns = rand.Next(3, 9);
                int[,] array = new int[rows, columns];
                FillArray(array, 0, 100);
                PrintArray(array, message: "Исходный массив:");

                for (int i = 0; i < rows; i++)
                {
                    int[] row = new int[columns];
                    for (int j = 0; j < columns; j++) row[j] = array[i, j];
                    SortArray(row, false); // метод из 4го семинара
                    for (int j = 0; j < columns; j++) array[i, j] = row[j];
                }
                PrintArray(array, message: "Отсортированный массив:");
            }

            void Zadacha56()
            {
                //Задача 56. Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
                Random rand = new Random();
                int size = rand.Next(3, 9);
                int[,] array = new int[size, size];
                FillArray(array, 0, 100);
                PrintArray(array, message: "Исходный массив:");
                int minSum = 0;
                int result = 0;
                for (int i = 0; i < size; i++)
                {
                    int sum = 0;
                    for (int j = 0; j < size; j++) sum += array[i, j];
                    if (i == 0) minSum = sum;
                    else if (sum < minSum)
                    {
                        result = i;
                        minSum = sum;
                    }
                }
                Console.WriteLine($"Номер строки с наименьшей суммов элементов {result}");

            }

            void Zadacha58()
            {
                //Задача 58. Заполните спирально массив 4 на 4 числами от 1 до 16.
                //01 02 03 04
                //12 13 14 05
                //11 16 15 06
                //10 09 08 07
                Random rand = new Random();
                int rows = 4;//rand.Next(3, 4);
                int columns = 4;//rand.Next(3, 9);
                int[,] array = new int[rows, columns];
                FillArray(array, 0, 0);
                PrintArray(array, message: "Исходный массив:");

                FillLikeSpiral(array);

                PrintArray(array, message: "Змейка:");
            }

            void ZadachaDop1()
            {
                // Задача 1. Дан двумерный массив. Заменить в нём элементы первой строки элементами главной диагонали. 
                //А элементы последней строки, элементами побочной диагонали.
                // 1   2   3   4                1   6  11 15
                // 5   6   7   8     =>         5   6   7  8 
                // 9  10  11  12                9  10  11 12
                // 12 13  14  15                12 10   7  4
                Random rand = new Random();
                int rows = rand.Next(3, 5);
                int columns = rand.Next(3, 5);
                int[,] array = new int[rows, columns];
                FillArray(array, 0, 100);
                PrintArray(array, message: "Исходный массив:");
                int minSize = columns;
                if (rows < columns) minSize = rows;
                for (int i = 0; i < minSize; i++) array[0, i] = array[i, i];
                for (int i = 0; i < minSize; i++) array[rows - 1, i] = array[minSize - i - 1, minSize - i - 1];
                PrintArray(array, message: "Результат:");
            }
            void ZadachaDop2()
            {
                // Задача 2. Дан двумерный массив, заполненный случайными числами от -9 до 9. 
                //Подсчитать частоту вхождения каждого числа в массив, используя словарь.
                // Справка:
                // https://docs.microsoft.com/ru-ru/dotnet/api/system.collections.generic.dictionary-2?view=net-6.0
                Random rand = new Random();
                int rows = rand.Next(3, 5);
                int columns = rand.Next(3, 5);
                int[,] array = new int[rows, columns];
                FillArray(array, -9, 9);
                PrintArray(array, message: "Исходный массив:");

                Dictionary<int, int> frequency = new Dictionary<int, int>();
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < columns; j++)
                    {

                        if (frequency.ContainsKey(array[i, j]))
                            frequency[array[i, j]]++;
                        else
                        {
                            frequency.Add(array[i, j], 1);
                        }
                    }

                Console.WriteLine("Частота цифр:");
                foreach (KeyValuePair<int, int> value in frequency)
                {
                    Console.WriteLine($"value = {value.Key}, count = {value.Value}");
                }

            }
            void ZadachaDop3()
            {
                // Задача 3. Найти минимальный по модулю элемент. Вывести все столбцы и строки, содержащие элементы, равные по модулю минимальному.
                Random rand = new Random();
                int rows = rand.Next(3, 5);
                int columns = rand.Next(3, 5);
                int[,] array = new int[rows, columns];
                bool[] minRows = new bool[rows];
                bool[] minColumns = new bool[columns];
                FillArray(array, -9, 9);
                PrintArray(array, message: "Исходный массив:");
                int minMod = array[0, 0];

                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < columns; j++)
                        if (minMod > array[i, j])
                            minMod = array[i, j];

                for (int i = 0; i < rows; i++) minRows[i] = false;
                for (int i = 0; i < columns; i++) minColumns[i] = false;

                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < columns; j++)
                        if (minMod == array[i, j])
                        {
                            minRows[i] = true;
                            minColumns[j] = true;
                        }
                Console.WriteLine("Строки содержащие минимальное значение:");
                for (int i = 0; i < rows; i++)
                    if (minRows[i])
                    {
                        Console.WriteLine();
                        for (int j = 0; j < columns; j++) Console.Write(array[i, j] + "\t");
                    }
                Console.WriteLine();
                Console.WriteLine("Колонки содержащие минимальное значение:");
                for (int i = 0; i < columns; i++)
                    if (minColumns[i])
                    {
                        Console.WriteLine();
                        for (int j = 0; j < rows; j++) Console.WriteLine(array[j, i]);
                    }

            }

            void ZadachaDop4()
            {
                // Задача 4. Заполните двумерный массив 3х3 числами от 1 до 9 змейкой.

                // 1  6  7
                // 2  5  8
                // 3  4  9
                Random rand = new Random();
                int rows = 3;//and.Next(3, 4);
                int columns = 3;//rand.Next(3, 9);
                int[,] array = new int[rows, columns];
                FillArray(array, 0, 0);
                PrintArray(array, message: "Исходный массив:");
                int shift = 1;
                for (int j = 0; j < columns; j++)
                {
                    int direction = j % 2;
                    if (direction == 0)
                    {
                        for (int i = 0; i < rows; i++)
                            array[i, j] = shift++;
                    }
                    else
                    {
                        for (int i = 0; i < rows; i++)
                            array[rows - i - 1, j] = shift++;
                    }
                }


                PrintArray(array, message: "Змейка:");
            }

            ZadachaDop4();
            //ZadachaDop3();
            //ZadachaDop2();
            //ZadachaDop1();
            //Zadacha58();
            //Zadacha56();
            //Zadacha54();
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