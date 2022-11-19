internal class Program
{
    private static void Main(string[] args)
    {
        int Max(int digit1, int digit2)
        {
            if (digit1 < digit2)
            {
                return digit2;
            }
            else
            {
                return digit1;
            }
        }

        void Zadacha2()
        {
            Console.WriteLine("Введите первое число");
            int first = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите второе число");
            int second = Convert.ToInt32(Console.ReadLine());

            int max = Max(first, second);
            if (max == second && max != first)
            {
                Console.WriteLine($"Число {first} меньше {second}");
            }
            else if (max != second && max == first)
            {
                Console.WriteLine($"Число {first} больше {second}");
            }
            else
            {
                Console.WriteLine($"Число {first} равно {second}");
            };
        }

        void Zadacha4()
        {
            Console.WriteLine("Введите первое число");
            int first = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите второе число");
            int second = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите третее число");
            int third = Convert.ToInt32(Console.ReadLine());

            int max = Max(Max(first, second), third);

            Console.WriteLine($"Максимум трех чисел = {max}");

        }

        void Zadacha6()
        {
            Console.WriteLine("Введите  число");

            int first = Convert.ToInt32(Console.ReadLine());

            if (first % 2 == 0)
            {
                Console.WriteLine($"Число {first} четное");
            }
            else
            {
                Console.WriteLine($"Число {first} нечетное");
            }
        }

        void Zadacha8()
        {
            Console.WriteLine("Введите  число");

            int first = Convert.ToInt32(Console.ReadLine());
            int index = 2;

            while (index <= first)
            {
                if (index % 2 == 0)
                {
                    Console.Write($"{index} ");
                }
                index++;
            }
        }

        void Zadacha10()
        {
            Console.WriteLine("Введите  число");
            int first = Convert.ToInt32(Console.ReadLine());

            if (first < 1000 && first > 99)
            {
                Console.WriteLine($"Вторая цифра числа = {first / 10 % 10}");
            }
            else
            {
                Console.WriteLine("Число не трехзначное");
            }
        }

        void Zadacha13()
        {
            Console.WriteLine("Введите  число");
            int first = Convert.ToInt32(Console.ReadLine());

            int count = 0, temp = first;

            while (temp > 0)
            {
                count++;
                temp = temp / 10;
                Console.WriteLine(temp);
            }
            Console.WriteLine(count);

            if (count < 3)
            {
                Console.WriteLine("В числе не больше двух знаков");
            }
            else
            {
                Console.WriteLine($"Третяя цифра числа = {first / Convert.ToInt32(Math.Pow(10, count - 3)) % 10}");
            }
        }

        void Zadacha15()
        {
            Console.WriteLine("Введите  номер дня недели");
            int day = Convert.ToInt32(Console.ReadLine());

            string[] days = { "пн", "вт", "ср", "чт", "пт", "сб", "вс" };
            if (day > 7 || day < 0)
            {
                Console.WriteLine($"{day} не номер дня недели");
            }
            else if (days[day - 1].Equals("сб") || days[day - 1].Equals("вс"))
            {
                Console.WriteLine($"День {days[day - 1]} выходной");
            }
            else
            {
                Console.WriteLine($"День {days[day - 1]} рабочий");
            }
        }

        Zadacha15();
    }
}