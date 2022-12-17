namespace Practice7;
class Program
{
    static void Main(string[] args)
    {
        void Zadacha47()
        {
            // Задача 47: Задайте двумерный массив размером m×n, заполненный случайными вещественными числами, округлёнными до одного знака.
            // m = 3, n = 4.
            // 0,5 7 -2 -0,2
            // 1 -3,3 8 -9,9
            // 8 7,8 -7,1 9
            Random rand = new Random();
            int rows = rand.Next(3, 9);
            int columns = rand.Next(3, 9);
            double[,] array = new double[rows, columns];
            FillArray(array, 100, 1);
            Console.WriteLine($"Двумерный массив размером {rows}*{columns}, заполненный случайными вещественными числами, округлёнными до одного знака");
            PrintArray(array);
        }

        void Zadacha50()
        {
            // Задача 50. Напишите программу, которая на вход принимает индексы элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.
            // Например, задан массив:
            // 1 4 7 2
            // 5 9 2 3
            // 8 4 2 4
            // 1, 3 -> 3

            Random rand = new Random();
            int rows = rand.Next(3, 9);
            int columns = rand.Next(3, 9);
            double[,] array = new double[rows, columns];
            FillArray(array, 100, 1);
            PrintArray(array);

            Console.WriteLine($"Введите индексы необходимого элемента через запятую(например 2, 5 ):");
            string inputValue = Console.ReadLine();
            string[] strArray = inputValue.Split(",");
            if (strArray.Length != 2)
            {
                Console.WriteLine("Введите 2 числа через запятую");
                return;
            }

            int i = Convert.ToInt32(strArray[0]);
            int j = Convert.ToInt32(strArray[1]);
            if (i > rows || j > columns || i < 0 || j < 0)
                Console.WriteLine("Выход за пределы массива. Числа с таким индексом в массиве нет.");
            else
                Console.WriteLine($"Значение = {array[i, j]}");
        }

        void Zadacha52()
        {
            // Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
            // Например, задан массив:
            // 1 4 7 2
            // 5 9 5 3
            // 8 4 6 4
            // Среднее арифметическое каждого столбца: 4,6; 5,6; 6; 3.
            Random rand = new Random();
            int rows = rand.Next(3, 9);
            int columns = rand.Next(3, 9);
            double[,] array = new double[rows, columns];
            FillArray(array, 100, 1);
            PrintArray(array);
            Console.WriteLine();
            Console.Write("Среднее арифметическое каждого столбца: ");
            for (int j = 0; j < columns; j++)
            {
                double sum = 0;
                for (int i = 0; i < rows; i++) sum += array[i, j];
                Console.Write($"{sum / rows}");
                if (j != (columns - 1)) Console.Write(", ");
            }
        }

        void ZadachaDop1()
        {
            //Задача 1. Даны две матрицы, количество строк и столбцов которых может быть 3 или 4, заполнены числами от -9 до 9. Выполните умножение матриц.
            //      Дополнительный материал по задаче:
            //      https://portal.tpu.ru/SHARED/k/KONVAL/Sites/Russian_sites/1/04.htm
            Random rand = new Random();
            int rows = rand.Next(3, 5);
            int columns = rand.Next(3, 5);
            int[,] array1 = new int[rows, columns];
            FillArray(array1, -9, 9);
            PrintArray(array: array1, message: "Матрица 1");
            int[,] array2 = new int[columns, rows];
            FillArray(array2, -9, 9);
            PrintArray(array: array2, message: "Матрица 2");

            //if (array1.GetLength(1) != array2.GetLength(0)) { Console.WriteLine("Матрицы нельзя перемножить"); return; };
            //сделали так что всегда можно.

            PrintArray(array: mulMatrix(array1, array2), message: "Произведение матриц");
        }

        void ZadachaDop2()
        {
            //Задача 2. Двумерный массив размером 3х4 заполнен числами от 100 до 9999. 
            //Найдите в этом массиве и сохраните в одномерный массив все числа, сумма цифр которых больше их произведения. Выведите оба массива.
            int rows = 3;
            int columns = 4;
            int[,] array = new int[rows, columns];
            FillArray(array, 100, 9999);
            PrintArray(array: array, message: "Массив 3 на 4 заполнен числами от 100 до 9999");

            int counter = 0;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    if (sumOfDigits(array[i, j]) > mulOfDigits(array[i, j]))
                        counter++;

            int[] result = new int[counter];

            counter = 0;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    if (sumOfDigits(array[i, j]) > mulOfDigits(array[i, j]))
                    {
                        result[counter] = array[i, j];
                        counter++;
                    }
            Console.WriteLine();
            Console.WriteLine("Результат: ");
            PrintArray(result);
        }

        void ZadachaDop3()
        {
            //Задача 3. Двумерный массив размером 5х5 заполнен случайными нулями и единицами. 
            //Игрок может ходить только по полям, заполненным единицами. Проверьте, существует ли путь из точки [0, 0] в точку [4, 4] 
            //(эти поля требуется принудительно задать равными единице).
            int rows = 5;
            int columns = 5;
            int[,] array = new int[rows, columns];
            int[,] ways = new int[rows, columns];
            FillArray(array, 0, 1);
            FillArray(array, 0, 1, true); //обычно бывает разряжено. Добавляем еще больше единичек
            FillArray(ways, 0, 0);

            array[0, 0] = 1;
            array[rows - 1, columns - 1] = 1;
            ways[0, 0] = 1;
            PrintArray(array: array, message: "Карта:");
            //инвертируем поле для алгоритма 
            for(int i = 0; i<rows;i++)
                for(int j = 0; j<columns;j++)
                    if (array[i,j] == 0) array[i,j] = 1;
                    else array[i,j] = 0;
            //

            int maxSteps = array.Length;

            int step = 1;
            bool foundSteps = true;
            while (ways[rows - 1, columns - 1] == 0 & foundSteps) 
            {    
                foundSteps = Run(step);
                step++;
            }    

            if (foundSteps)
                Console.WriteLine("Выход из лабиринта существет");
            else
                Console.WriteLine("Выход из лабиринта не существет");

            PrintArray(array: ways, message: "Путь:");

            bool Run(int step)
            {
                bool stepsFound = false;

                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < columns; j++)
                    {
                        if (ways[i, j] == step)
                        {                            
                            if (i > 0 && ways[i - 1, j] == 0 && array[i - 1, j] == 0)
                            { 
                                ways[i - 1, j] = step + 1; 
                                stepsFound = true; 
                            }
                            if (j > 0 && ways[i, j - 1] == 0 && array[i, j - 1] == 0)
                            { 
                                ways[i, j - 1] = step + 1; 
                                stepsFound = true; 
                            }
                            if (i < rows - 1 && ways[i + 1, j] == 0 && array[i + 1, j] == 0)
                            { 
                                ways[i + 1, j] = step + 1; stepsFound = true; 
                            }
                            if (j < columns - 1 && ways[i, j + 1] == 0 && array[i, j + 1] == 0)
                            { 
                                ways[i, j + 1] = step + 1; 
                                stepsFound = true; 
                            }
                        }
                    }
                return stepsFound;    
            }
        }

        ZadachaDop3();
        //ZadachaDop2();
        //ZadachaDop1();
        //Zadacha52();
        //Zadacha50();
        //Zadacha47();
    }
    static int sumOfDigits(int value)
    {
        int sum = 0;
        while (value > 0)
        {
            int digit = value % 10;
            value /= 10;
            sum += digit;
        }
        return sum;
    }
    static int mulOfDigits(int value)
    {
        int mul = 1;
        while (value > 0)
        {
            int digit = value % 10;
            value /= 10;
            mul *= digit;
        }
        return mul;
    }
    static int Number_of_digits(int n)
    {
        int count = 0;
        while (n > 0)
        {
            n /= 10;
            count++;
        }

        return count;
    }

    static int[,] mulMatrix(int[,] array1, int[,] array2)
    {
        int rows = array1.GetLength(0);
        int columns = array2.GetLength(1);
        int columns2 = array1.GetLength(1);
        int[,] result = new int[rows, columns];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
                for (int k = 0; k < columns2; k++)
                    result[i, j] += array1[i, k] * array2[k, j];
        return result;
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

