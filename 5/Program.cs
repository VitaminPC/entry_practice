namespace Practice6;
class Program
{
    static void Main(string[] args)
    {

        void Zadacha34()
        {
            int size = 10;
            int[] numbers = new int[size];
            FillArray(numbers, 100, 999);
            PrintArray(numbers);

            int result = 0;
            for (int i = 0; i < size; i++)
                if (numbers[i] % 2 == 0) result++;

            Console.WriteLine($"Количество четных чисел в массиве = {result}");
        }

        void Zadacha36()
        {
            int size = 10;
            int[] numbers = new int[size];
            FillArray(numbers, 0, 10);
            PrintArray(numbers);

            int result = 0;
            for (int i = 1; i < size; i += 2) result += numbers[i];

            Console.WriteLine($"Сумма чисел с нечетными индексами = {result}");
        }

        void Zadacha38()
        {
            int size = 10;
            double[] numbers = new double[size];
            FillArray(numbers, 100, 2);
            PrintArray(numbers);

            double result = 0;
            double maxEl = numbers[0];
            double minEl = numbers[0];
            for (int i = 0; i < size; i++)
            {
                if (numbers[i] < minEl) minEl = numbers[i];
                if (numbers[i] > maxEl) maxEl = numbers[i];
            }

            Console.WriteLine($"Минимум = {minEl}  Максимум = {maxEl} Разница = {maxEl - minEl}");
        }

        void ZadachaDop1()
        {
            //Задача 1. Задан массив из случайных цифр на 15 элементов. На вход подаётся трёхзначное натуральное число. Напишите программу, которая определяет, есть в массиве последовательность из трёх элементов, совпадающая с введённым числом.
            //{0, 5, 6, 2, 7, 7, 8, 1, 1, 9} - 277 -> да
            //{4, 4, 3, 6, 7, 0, 8, 5, 1, 2} - 812 -> нет

            int size = 10;
            int[] numbers = new int[size];
            FillArray(numbers, 0, 9);
            PrintArray(numbers);

            Console.WriteLine("Введите трехзначное число: ");
            int value = Convert.ToInt32(Console.ReadLine());
            if (value < 100 || value > 999)
            {
                Console.WriteLine("Введите трехзначное число!");
                return;
            }
            bool result = false;
            for (int i = 0; i < size - 2 && !result; i++)
            {
                if (value == numbers[i] * 100 + numbers[i + 1] * 10 + numbers[i + 2]) result = true;
            }

            if (result) Console.WriteLine($"Число присутствует в массиве");
            else Console.WriteLine($"Число отсутствует в массиве");
        }

        void ZadachaDop2()
        {
            //Задача 2. На вход подаются два числа случайной длины. 
            //Найдите произведение каждого разряда первого числа на каждый разряд второго. 
            //Ответ запишите в массив.
            Random rand = new Random();
            int first = rand.Next(0, 10000);
            int second = rand.Next(0, 10000);
            int numberFirst = Number_of_digits(first);
            int numberSecond = Number_of_digits(second);
            int[] array = new int[numberFirst * numberSecond];

            Console.WriteLine($"Первое число {first} Второе число {second}");
            Console.WriteLine($"Разрядов первого числа {numberFirst} Разрядов второго числа {numberSecond}");

            int shift = 0;
            for (int i = 0; i < numberFirst; i++)
            {
                for (int j = 0; j < numberSecond; j++)
                {

                    int delFirst = first / Convert.ToInt32(Math.Pow(10, (numberFirst - i - 1)));
                    int delSecond = second / Convert.ToInt32(Math.Pow(10, (numberSecond - j - 1)));
                    delFirst = delFirst % 10;
                    delSecond = delSecond % 10;
                    array[shift++] = delFirst * delSecond;
                }
            }

            Console.WriteLine($"Результат: ");
            PrintArray(array);
        }

        void ZadachaDop3()
        {
            //Задача 3. Найдите все числа от 1 до 1000000, сумма цифр которых в три раза меньше их произведений. Подсчитайте их количество.

            int counter = 0;
            for (int i = 1; i <= 1000000; i++)
            {
                int value = i;
                int sum = 0;
                int imul = 1;
                while (value > 0)
                {
                    int digit = value % 10;
                    value /= 10;
                    sum += digit;
                    imul *= digit;
                }
                if (imul == 3 * sum)
                {
                    Console.WriteLine($"Сумма цифр числа {i} = {sum} Произведение цифр = {imul} и сумма в три раза меньше произведения.");
                    counter++;
                }
            }
            Console.WriteLine($"Общее количество таких чисел {counter}");
        }

        void ZadachaPow1()
        {
            //Задача 1*. Дан массив массивов, состоящих из натуральных чисел, размер которого 5. 
            //Для каждого элемента-массива требуется найти сумму его элементов и вывести массив с наибольшей суммой. 
            //Если таких массивов несколько, вывести массив с наименьшим индексом.
            int size = 5;
            int[][] arrays= new int[size][];
            Random rand = new Random();
            int max = 0;
            int maxIndex = 0;
            
            Console.WriteLine("Массив массивов:");

            for(int i = 0; i<size;i++)
            {
                arrays[i] = new int[rand.Next(1,10)];
                
                FillArray(arrays[i],0,100);
                PrintArray(arrays[i]);

                int sum = 0;

                for(int j=0; j<arrays[i].Length;j++) sum += arrays[i][j];
                
                if (sum > max)
                {
                    max = sum;
                    maxIndex = i;
                }
            }

            Console.WriteLine("Первый массив с наибольшей суммой:");
            PrintArray(arrays[maxIndex]);
        }


        ZadachaPow1();
        //ZadachaDop3();
        //ZadachaDop2();
        //ZadachaDop1();
        //Zadacha38();
        //Zadacha36();
        //Zadacha34();
    }

   
    static void FillArray(int[] array, int begin = 0, int range = 10)
    {
        range++;
        Random ramdomizer = new Random();
        int size = array.Length;
        for (int i = 0; i < size; i++)
        {
            array[i] = ramdomizer.Next(begin, range);
        }

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
}

