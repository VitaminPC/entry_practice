namespace Practice6;
class Program
{
    static void Main(string[] args)
    {
        void Zadacha41()
        {
            //Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
            //0, 7, 8, -2, -2 -> 2
            //1, -7, 567, 89, 223-> 3
            Random rand = new Random();
            int size = rand.Next(3, 8);
            Console.WriteLine($"Введите {size} чисел через пробел:");
            string inputValue = Console.ReadLine();
            string[] strArray = inputValue.Split(" ");
            int counter = 0;
            for (int i = 0; i < size && i < strArray.Length; i++)
                if (Convert.ToInt32(strArray[i]) > 0) counter++;

            Console.WriteLine($"В введенном массиве {counter} положительных чисел. ");
        }

        void Zadacha43()
        {
            //Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями 
            //y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.
            //b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)

            // k1 * x + b1 = k2*x + b2;
            // x = (b2 - b1)/(k1 - k2)
            Console.WriteLine($"Введите коэффициенты уравнений k1, b1, k2, b2 через пробел:");
            string inputValue = Console.ReadLine();
            string[] strArray = inputValue.Split(" ");
            if (strArray.Length != 4)
            {
                Console.WriteLine("Введите 4 числа");
                return;
            }
            int k1 = Convert.ToInt32(strArray[0]);
            int b1 = Convert.ToInt32(strArray[1]);
            int k2 = Convert.ToInt32(strArray[2]);
            int b2 = Convert.ToInt32(strArray[3]);

            if (k1 == k2)
            {
                Console.WriteLine("Прямые не пересекаются");
                return;
            }
            double x = 1.0 * (b2 - b1) / (k1 - k2);
            double y = k1 * x + b1;
            Console.WriteLine($"Точка пересечения двух границ ({x},{y})");
        }

        long Cnv10to2(int value, int level)
        {
            if (value == 0) return 0;
            return (value % 2 * level + Cnv10to2(value / 2, level * 10));
        }

        void ZadachaDop1()
        {
            //Задача 1. Написать перевод десятичного числа в двоичное, используя рекурсию.

            Console.WriteLine("Введите целое число: ");
            int value = Convert.ToInt32(Console.ReadLine());

            int level = 1;

            long result = Cnv10to2(value, level);
            Console.WriteLine($"Двоичное представление числа = {result}");
        }

        int CountOfSymbols(string str, string symbols, int position)
        {
            if (position == str.Length) return 0;
            char symbol = str[position];
            position++;
            for (int i = 0; i < symbols.Length; i++)
                if (symbols[i] == symbol) return 1 + CountOfSymbols(str, symbols, position);
            return CountOfSymbols(str, symbols, position);
        }



        void ZadachaDop2()
        {
            //Задача 2. На вход подаётся поговорка “без труда не выловишь и рыбку из пруда”. 
            //Используя рекурсию, подсчитайте, сколько в поговорке гласных букв.
            string proverb = "без труда не выловишь и рыбку из пруда";
            string symbols = "аеёиоуыэюя";
            int result = CountOfSymbols(proverb, symbols, 0);
            Console.WriteLine($"В пословице '{proverb}' {result} гласных");
        }

        bool isPowOf(int value, int pow)
        {

            if (value == pow) return true;
            else if (value < pow) return false;
            return (value % pow == 0) && isPowOf(value / pow, pow);
        }

        void ZadachaDop3()
        {
            //Задача 3. Дано число N. Используя только операцию деления и рекурсию, определите, что оно является степенью числа 3.
            Console.WriteLine("Введите целое число: ");
            int value = Convert.ToInt32(Console.ReadLine());
            if (isPowOf(value, 3)) Console.WriteLine($"Введенное число является степенью числа 3");
            else Console.WriteLine($"Введенное число не является степенью числа 3");
        }

        void ZadachaPow1()
        {
            //Задача 1*. Создайте программу, показывающую текущее время. Для вывода чисел используйте двумерные массивы.
            //https://docs.microsoft.com/ru-ru/dotnet/api/system.datetime?view=net-6.0
            int[][,] diggits = new int[11][,];

            diggits[0] = new int[,]
            {
                {0,1,1,1,0},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {0,1,1,1,0},
            };

            diggits[1] = new int[,]
            {
                {0,0,1,0,0},
                {0,1,1,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {1,1,1,1,1},
            };

            diggits[2] = new int[,]
            {
                {0,1,1,1,0},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {0,0,0,1,0},
                {0,0,1,0,0},
                {0,1,0,0,0},
                {1,1,1,1,1},
            };

            diggits[3] = new int[,]
            {
                {0,1,1,1,0},
                {1,0,0,0,1},
                {0,0,0,0,1},
                {0,0,1,1,0},
                {0,0,0,0,1},
                {1,0,0,0,1},
                {0,1,1,1,0},
            };

            diggits[4] = new int[,]
            {
                {1,0,0,0,1},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {1,1,1,1,1},
                {0,0,0,0,1},
                {0,0,0,0,1},
                {0,0,0,0,1},
            };

            diggits[5] = new int[,]
            {
                {1,1,1,1,1},
                {1,0,0,0,0},
                {1,0,0,0,0},
                {1,1,1,1,0},
                {0,0,0,0,1},
                {0,0,0,0,1},
                {1,1,1,1,0},
            };

            diggits[6] = new int[,]
            {
                {0,1,1,1,0},
                {1,0,0,0,1},
                {1,0,0,0,0},
                {1,1,1,1,0},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {0,1,1,1,0},
            };

            diggits[7] = new int[,]
            {
                {1,1,1,1,1},
                {0,0,0,0,1},
                {0,0,0,0,1},
                {0,0,0,1,0},
                {0,0,1,0,0},
                {0,1,0,0,0},
                {1,0,0,0,0},
            };

            diggits[8] = new int[,]
            {
                {0,1,1,1,0},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {0,1,1,1,0},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {0,1,1,1,0},
            };

            diggits[9] = new int[,]
            {
                {0,1,1,1,0},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {0,1,1,1,1},
                {0,0,0,0,1},
                {0,0,0,0,1},
                {0,1,1,1,0},
            };

            diggits[10] = new int[,]
            {
                {0,0,0,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,0,0,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,0,0,0,0},
            };

            string prevTimeShort = "";//DateTime.Now.ToShortTimeString();

            while (true)
            {
                string curTimeShort = DateTime.Now.ToLongTimeString();

                if (!prevTimeShort.Equals(curTimeShort))
                {
                    string[] times = curTimeShort.Split(":");

                    int hour = Convert.ToInt32(times[0]);
                    int minute = Convert.ToInt32(times[1]);
                    int seconds = Convert.ToInt32(times[2]);

                    int first = hour / 10;
                    int second = hour % 10;
                    int third = minute / 10;
                    int forth = minute % 10;
                    int fifth = seconds / 10;
                    int sixth = seconds % 10;

                    string GetString(int[,] array, int i)
                    {
                        int size = array.GetLength(1);
                        string result = "";
                        for (int j = 0; j < size; j++)
                            if (array[i, j] == 0) result = result + " ";
                            else result = result + "█";//@";
                        return result;
                    }
                    Console.Clear();
                    Console.SetCursorPosition(0, 6);
                    for (int i = 0; i < 7; i++)
                    {
                        string nextstring = "";
                        nextstring = nextstring + GetString(diggits[first], i);
                        nextstring = nextstring + " ";
                        nextstring = nextstring + GetString(diggits[second], i);
                        nextstring = nextstring + " ";
                        nextstring = nextstring + GetString(diggits[10], i);
                        nextstring = nextstring + " ";
                        nextstring = nextstring + GetString(diggits[third], i);
                        nextstring = nextstring + " ";
                        nextstring = nextstring + GetString(diggits[forth], i);
                        nextstring = nextstring + " ";
                        nextstring = nextstring + GetString(diggits[10], i);
                        nextstring = nextstring + " ";
                        nextstring = nextstring + GetString(diggits[fifth], i);
                        nextstring = nextstring + " ";
                        nextstring = nextstring + GetString(diggits[sixth], i);
                        Console.WriteLine(nextstring);
                    }
                    prevTimeShort = curTimeShort;
                }
            }
        }

        ZadachaPow1();
        //ZadachaDop3();
        //ZadachaDop2();
        //ZadachaDop1();
        //Zadacha43();
        //Zadacha41();
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

    static void FillArray(int[,] array, int begin = 0, int range = 10)
    {
        range++;
        Random ramdomizer = new Random();
        int rows = array.GetLength(0);
        int columns = array.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                array[i, j] = ramdomizer.Next(begin, range);
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
    static void PrintArray(int[,] array, char symbol = '\t')
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
