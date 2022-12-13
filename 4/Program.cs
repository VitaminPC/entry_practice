namespace Practice4;
class Program
{
    static void Main(string[] args)
    {
        void FillArray(int[] array, int begin = 0, int range = 10)
        {
            range++;
            int modificator = 0;
            if (begin < 0) modificator = -begin;
            Random ramdomizer = new Random();
            int size = array.Length;
            for (int i = 0; i < size; i++)
            {
                array[i] = ramdomizer.Next(begin + modificator, range + modificator) - modificator;
            }

        }

        void WriteArray(int[] array, string message = "")
        {
            Console.WriteLine();
            Console.WriteLine(message);
            int size = array.Length;
            for (int i = 0; i < size; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        void SortArray(int[] array, string message = "", bool Asc = true, bool SortByAbs = false)
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

        long ConvertToBinary(int value)
        {
            int num10 = value;
            int a = 0;
            int i = 0;

            long result = 0;

            while (num10 >= 1)
            {
                a = num10 % 2;
                result += a * Convert.ToInt64(Math.Pow(10, i));
                i++;

                num10 = num10 / 2;
            };
            return result;
        }

        long Reverse(long value)
        {
            long tempvalue = value;
            int counter = 0;
            long result = 0;
            while (tempvalue > 0)
            {
                tempvalue /= 10;
                counter++;
            };
            counter--;
            tempvalue = value;
            while (tempvalue > 0)
            {
                result += tempvalue % 10 * Convert.ToInt32(Math.Pow(10, counter));
                tempvalue /= 10;
                counter--;
            }

            return result;
        }

        void Zadacha25()
        {
            // Задача 25: Используя определение степени числа, напишите цикл, который принимает на вход два натуральных числа (A и B) 
            // и возводит число A в степень B.
            // 3, 5 -> 243 (3⁵)
            // 2, 4 -> 16
            Console.WriteLine("Введите число");
            int value = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите степень числа");
            int power = Convert.ToInt32(Console.ReadLine());

            int result = value;

            for (int i = 1; i < power; i++) result *= value;

            Console.WriteLine($"{value} в степени {power} = {result}");

        }

        void Zadacha27()
        {
            // Задача 27: Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.
            // 452 -> 11
            // 82 -> 10
            // 9012 -> 12
            Console.WriteLine("Введите число");
            int value = Convert.ToInt32(Console.ReadLine());
            int temp = value;
            int result = 0;

            while (temp > 0)
            {
                result += temp % 10;
                temp /= 10;
            }

            Console.WriteLine($"Сумма цифр числа {value} = {result}");
        }

        void Zadacha29()
        {
            // Задача 29: Напишите программу, которая задаёт массив из 8 случайных целых чисел и выводит отсортированный по модулю массив.
            // -2, 1, -7, 5, 19 -> [1, -2, 5, -7, 19]
            // 6, 1, -33 -> [1, 6, -33]
            int size = 8;
            int[] array = new int[8];
            FillArray(array, -100, 100);
            WriteArray(array, "Исходный массив");
            SortArray(array: array, SortByAbs: true);
            WriteArray(array, "Отсортированный по модулю массив");
        }

        void ZadachaDop1()
        {
            //Задача 1. На вход подаётся натуральное десятичное число. Проверьте, является ли оно палиндромом в двоичной записи.
            Console.WriteLine("Введите число");
            int value = Convert.ToInt32(Console.ReadLine());
            long binary = ConvertToBinary(value);
            Console.WriteLine($"Двоичное представление {binary}");

            long reverse = Reverse(binary);
            Console.WriteLine($"Обратное двоичное представление {reverse} (Ведущие нули могут быть утеряны. Для условия задачи это не важно.");

            if (reverse == binary) Console.WriteLine("Двоичное представление является палиндромом");
            else Console.WriteLine("Двоичное представление не является палиндромом");
        }

        void ZadachaDop2()
        {
            //Задача 2. Напишите метод, который заполняет массив случайным количеством (от 1 до 100) нулей и единиц. 
            //Размер массива должен совпадать с квадратом количества единиц в нём.
            Random rand = new Random();
            int ones = rand.Next(1, 101);
            long size = ones * ones;
            int[] array = new int[size];
            for (int i = 0; i < ones; i++)
            {
                bool found = false;
                long position = 0;
                while (!found)
                {
                    position = rand.NextInt64(0, size);
                    if (array[position] == 0)
                    {
                        array[position] = 1;
                        found = true;
                    }
                }
            }
            WriteArray(array, $"Массив в котором случайное количество единиц({ones}) и нулей. Размер массива {size}");
        }

        void ZadachaDop3()
        {
            //Задача 3. Массив на 100 элементов задаётся случайными числами от 1 до 99. 
            //Определите самый часто встречающийся элемент в массиве. Если таких элементов несколько, вывести их все.
            int size = 100;
            int[] array = new int[size];
            FillArray(array, 1, 99);
            WriteArray(array, "Исходный массив");

            int[,] statistic = new int[size, 2];
            int margine = 0;
            int j = 0;

            for (int i = 0; i < size; i++)
            {
                bool found = false;
                j = 0;
                while (j < margine && !found)
                {
                    if (statistic[j, 0] == array[i])
                    {
                        statistic[j, 1]++;
                        found = true;
                    }
                    else
                        j++;
                }
                if (!found)
                {
                    statistic[margine, 0] = array[i];
                    statistic[margine, 1] = 1;
                    margine++;
                }
            }

            int maxStat = 0;
            for (int i = 0; i < size; i++)
                if (statistic[i, 1] > maxStat)
                    maxStat = statistic[i, 1];

            j = 0;
            Console.WriteLine("Статистика");
            while (statistic[j, 1] != 0 && j < size)
            //while (j < size)
            {
                if (maxStat == statistic[j, 1]) Console.WriteLine($"Число {statistic[j, 0]} встречается {statistic[j, 1]} раза");
                j++;
            }
        }

        void TextDoom(int[,] map)
        {
            Random randomizer = new Random();
            var personPosition = (19, 10);
            var treasurePosition = (randomizer.Next(1, 20), randomizer.Next(1, 20));
            int rows = map.GetLength(0);
            int columns = map.GetLength(1);
            int target = 10;
            int counter = 0;
            int headerCount = 4;
            int statString = 2;
            // map section
            Console.Clear();
            Console.WriteLine("!!! DOOM ZERO !!!");
            Console.WriteLine($"Found treasures {counter}/10");
            Console.WriteLine();
            Console.WriteLine("+--------------------+");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("|");
                for (int j = 0; j < columns; j++)
                    if (map[i, j] == 0)
                        Console.Write(" ");
                    else if (map[i, j] == 1)
                        Console.Write("*");
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("+---------  ---------+");

            int treasureLiveTime = 0;
            int maxTreasureLiveTime = 20;
            bool treasureFound = false;

            while (counter < target)
            {
                Console.SetCursorPosition(personPosition.Item2, headerCount + personPosition.Item1);
                Console.Write("@");
                Console.SetCursorPosition(treasurePosition.Item2, headerCount + treasurePosition.Item1);
                Console.Write("$");
                //if (personPosition.Equ2als(treasurePosition))
                if (personPosition.Item1 == treasurePosition.Item1 && personPosition.Item2 == treasurePosition.Item2)
                {
                    treasureFound = true;
                    counter++;
                }
                if (treasureLiveTime == maxTreasureLiveTime || treasureFound)
                {
                    Console.SetCursorPosition(treasurePosition.Item2, headerCount + treasurePosition.Item1);
                    Console.Write(" ");
                    treasurePosition = (randomizer.Next(1, 20), randomizer.Next(1, 20));
                    treasureFound = false;
                    treasureLiveTime = 0;
                    Console.SetCursorPosition(0, statString - 1);
                    Console.WriteLine($"Found treasures {counter}/10");
                }
                treasureLiveTime++;
                Console.SetCursorPosition(personPosition.Item2, headerCount + personPosition.Item1);
                ConsoleKey pressedKey = Console.ReadKey().Key;
                if (pressedKey == ConsoleKey.LeftArrow)
                {
                    Console.Write(" ");
                    personPosition.Item2 = Math.Max(1, personPosition.Item2 - 1);
                }
                else if (pressedKey == ConsoleKey.RightArrow)
                {
                    Console.Write(" ");
                    personPosition.Item2 = Math.Min(columns, personPosition.Item2 + 1);
                }
                else if (pressedKey == ConsoleKey.UpArrow)
                {
                    Console.Write(" ");
                    personPosition.Item1 = Math.Max(0, personPosition.Item1 - 1);
                }
                else if (pressedKey == ConsoleKey.DownArrow)
                {
                    Console.Write(" ");
                    personPosition.Item1 = Math.Min(rows - 1, personPosition.Item1 + 1);
                }
                else if (pressedKey == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Console.WriteLine("Bye!!!");
                    return;
                }
            }
            Console.Clear();
            Console.WriteLine("!!!\t\t DOOM ZERO\t !!!");
            Console.WriteLine("!!!\t\t YOU WIN\t !!!");
            Console.WriteLine($"!!! Found treasures {counter}\t\t !!!");
            Console.WriteLine("!!! Found secret places - 100%\t !!!");
        }

        void ZadachaPow1()
        {
            int[,] map =
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            };

            TextDoom(map);
        }

        void TextDoom2(int[,] map, int[,] objects)
        {
            Random randomizer = new Random();
            var personPosition = (19, 19);
            bool deathFromMonsters = false;
            int rows = map.GetLength(0);
            int columns = map.GetLength(1);
            int target = 10;
            int counter = 0;
            int monstersCounter = 0;
            int treasureCounter = 0;
            int treasureCount = 0;
            int headerCount = 8;
            bool chainsawOn = false;
            int chainsawOnCounter = 0;
            int mapShift = 1;
            char wall = '█';
            char space = ' ';
            void ShowDebug(string text, int row = 6)
            {
                Console.SetCursorPosition(0, row);
                Console.Write(text);
            }
            // map section
            Console.Clear();
            Console.WriteLine("!!! DOOM II !!! FIND ALL TREASURES TO WIN !!!");
            Console.WriteLine($"Found treasures {treasureCounter}/{treasureCount}");
            Console.WriteLine($"Killed monstres {monstersCounter}");
            Console.WriteLine($"Arrows - mooving left, back,rught, forward");
            Console.WriteLine($"SPACE - Chainsaw ON/OFF. To kill monsters(O) your Chainsaw have to be ON or you'll DIE!");
            Console.WriteLine($"Objects: ^ - key, # - door; $ - treasure, @ - monster");
            Console.WriteLine();
            Console.WriteLine("+--------------------+");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("|");
                for (int j = 0; j < columns; j++)
                    if (map[i, j] == 0)
                        Console.Write(space);
                    else if (map[i, j] == 1)
                        Console.Write(wall);
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("+---------  ---------+");


            while (counter < target)
            {
                int objectscount = objects.GetLength(0);
                treasureCount = 0;

                chainsawOnCounter++;
                if (chainsawOnCounter > 5) { chainsawOn = false; chainsawOnCounter = 0; }

                for (int i = 0; i < objectscount; i++)
                {
                    var objectposition = (objects[i, 1], objects[i, 2]);
                    if (!((objectposition.Item1, objectposition.Item2) == (-1, -1)))
                    {
                        int type = objects[i, 0];
                        int status = objects[i, 3];
                        string keychar = " ";
                        if (type == 2)
                        {

                            if (status == 0) keychar = "^";

                        }
                        else if (type == 3)
                        {
                            if (status == 0) keychar = "@";
                        }
                        else if (type == 6)
                        {
                            if (status == 0) keychar = "#";
                        }
                        else if (type == 10)
                        {
                            if (status == 0)
                            {
                                keychar = "$";
                            };
                            treasureCount++;
                        }
                        ShowDebug($"Found treasures {treasureCounter}/{treasureCount}", 1);
                        Console.SetCursorPosition(objectposition.Item2 + mapShift, headerCount + objectposition.Item1);
                        Console.Write(keychar);
                    }
                }
                Console.SetCursorPosition(personPosition.Item2 + mapShift, headerCount + personPosition.Item1);
                Console.Write("\x2");

                Console.SetCursorPosition(personPosition.Item2 + mapShift, headerCount + personPosition.Item1);
                var newPosition = personPosition;
                bool CheckPosition(int y, int x)
                {
                    rows = map.GetLength(0);
                    columns = map.GetLength(1);
                    bool result = y >= 0 && x >= 0 && y <= rows - 1 && x <= columns - 1;
                    string debugText = $"row = {y} column = {x}";
                    //debugText += "checkMargines = " + result.ToString() + " ";

                    result = result && map[y, x] == 0;
                    //debugText += "checkWalls = " + result.ToString() + " ";

                    int objectcount = objects.GetLength(0);
                    bool objectoff = true;
                    for (int i = 0; i < objectcount; i++)
                    {
                        if ((y, x) == (objects[i, 1], objects[i, 2]))
                        {
                            int type = objects[i, 0];
                            int status = objects[i, 3];
                            if (status == 0)
                            {
                                objectoff = false;
                                if (type == 2)
                                {
                                    objects[i, 3] = 1;
                                    objects[objects[i, 4], 3] = 1;
                                }
                                else if (type == 3)
                                {
                                    if (chainsawOn)
                                    {
                                        objects[i, 3] = 1;
                                        monstersCounter++;
                                        ShowDebug($"Killed monstres {monstersCounter}", 2);
                                    }
                                    else
                                    {
                                        if (deathFromMonsters)
                                        {
                                            ShowDebug($"GAME OVER!!! YOU'RE KILLED");
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Environment.Exit(0);
                                        }
                                    }

                                }
                                else if (type == 10)
                                {
                                    objects[i, 3] = 1;
                                    treasureCounter++;
                                    ShowDebug($"Found treasures {treasureCounter}/{treasureCount}", 1);
                                    if (treasureCounter == treasureCount)
                                    {

                                        ShowDebug($"YOU WIN!!!");
                                        Console.WriteLine("YOU FOUND ALL TREASURES!!!");
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Environment.Exit(0);
                                        //Process.GetCurrentProcess().Kill();
                                    }
                                }

                            }
                        }
                    }
                    result = result && objectoff;
                    debugText += "checkObjects = " + result.ToString() + " ";
                    string textChain = "!!! OFF !!!";
                    if (chainsawOn) textChain = "!!!  ON !!!";
                    ShowDebug($"Chainsaw: " + textChain);
                    //ShowDebug(debugText);
                    return result;
                }

                ConsoleKey pressedKey = Console.ReadKey().Key;

                if (pressedKey == ConsoleKey.LeftArrow) newPosition.Item2--;
                else if (pressedKey == ConsoleKey.RightArrow) newPosition.Item2++;
                else if (pressedKey == ConsoleKey.UpArrow) newPosition.Item1--;
                else if (pressedKey == ConsoleKey.DownArrow) newPosition.Item1++;
                else if (pressedKey == ConsoleKey.Spacebar) {chainsawOn = true; chainsawOnCounter = 0;}
                else if (pressedKey == ConsoleKey.Escape)
                {
                    ShowDebug("      GAME OVER!!!      ");
                    return;
                }
                if (CheckPosition(newPosition.Item1, newPosition.Item2))
                {
                    Console.SetCursorPosition(personPosition.Item2 + mapShift, headerCount + personPosition.Item1);
                    Console.Write(" ");
                    personPosition = newPosition;
                }

            }
        }

        void ZadachaPow2()
        {
            int[,] map =
            {
                // 0 - empty
                // 1 - wall
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0},
                {0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0},
                {0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,1,0,0},
                {1,1,1,1,1,0,0,0,0,0,0,1,0,1,1,1,1,1,0,1},
                {0,0,0,0,0,0,0,1,0,1,1,1,0,0,0,0,0,1,0,0},
                {0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,1,1,0,0},
                {0,0,0,0,0,0,0,1,0,1,1,1,1,0,0,0,1,0,0,0},
                {0,0,1,1,1,1,1,1,0,0,0,0,1,0,0,0,1,1,0,0},
                {0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,1,1,0,1,1,1,1,1,1,1,1,0,0,0},
                {1,1,0,0,1,0,1,0,0,0,0,0,0,0,0,1,1,0,0,0},
                {0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1},
                {0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,1,1,0,0,0},
                {0,0,0,0,1,0,1,0,0,0,1,1,1,1,1,1,0,0,0,0},
                {1,1,1,1,1,0,1,1,1,0,1,0,0,0,1,1,1,0,0,0},
                {0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0},
                {0,0,0,0,1,0,0,0,1,0,1,0,0,0,1,0,0,1,0,0},
                {1,1,0,1,1,0,0,0,1,1,1,1,1,1,1,0,1,1,0,0},
                {0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1},
                {0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0,0,0},
            };

            //0 type - treasure, monstr, kay, door
            //key: 2, x,y, found, door index
            //door: 6, x,y, closed
            //monstr 3, x,y, died
            //treasure 10, x,y, found
            int[,] objects =
            {   //kays
                { 2, 12, 19, 0, 3},
                { 3, 13, 19, 0, 0},
                { 3, 18,  1, 0, 8},
                { 6, 14,  5, 0, 0},
                {10, 17, 19, 0, 0},

                {10, 18,  0, 0, 0},
                {10, 15,  0, 0, 0},
                {10, 11,  0, 0, 0},
                {10,  6,  6, 0, 0},
                {10,  2,  6, 0, 0},

                {10,  5, 11, 0, 0},
                {10, 11, 15, 0, 0},
                {10, 16, 13, 0, 0},
                {10,  7, 11, 0, 0},
                { 2, 13,  0, 0,15},

                { 6,  9,  8, 0, 0},
                { 2, 14, 13, 0,17},
                { 6,  3, 12, 0, 0},
                { 2, 10, 17, 0,19},
                { 6,  1, 14, 0, 0},

                {10,  5, 10, 0, 0},
                {10,  0, 19, 0, 0},
                {10,  2,  0, 0, 0},
                {10,  2,  1, 0, 0},
                {10,  2,  2, 0, 0},

                {10,  2,  3, 0, 0},
                { 3, 15,  4, 0, 0},
                { 3, 11,  1, 0, 0},
                { 3,  6,  5, 0, 0},
                { 3,  2,  5, 0, 0},

                { 3,  7, 10, 0, 0},
                { 3, 10, 14, 0, 0},
                { 3, 11, 14, 0, 0},
                { 3, 12, 14, 0, 0},
                { 3,  9, 17, 0, 0},

                { 3,  1, 18, 0, 0},
                { 3,  1,  0, 0, 0},
                { 3,  1,  1, 0, 0},
                { 3,  1,  2, 0, 0},
                { 3,  1,  3, 0, 0},

                { 3,  5, 12, 0, 0}

            };


            TextDoom2(map, objects);
        }

        ZadachaPow2();
        //ZadachaPow1();
        //ZadachaDop3();
        //ZadachaDop2();
        //ZadachaDop1();
        //Zadacha29();
        //Zadacha27();
        //Zadacha25();
    }
}

