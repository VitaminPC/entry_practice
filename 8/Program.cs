using System;

namespace Practice3
{
    class Program
    {
        static void Main(string[] args)
        {
            void Zadacha63()
            {
                Console.WriteLine("Введите число:");

                int number = Convert.ToInt32(Console.ReadLine());
                int counter = 0;
                Recursion( number, counter);
                return;

                while(counter <= number)
                {
                    Console.WriteLine($"{counter} "); 
                    counter++;
                }
            }



            void Zadacha65()
            {
                Console.WriteLine("Введите начальное число:");
                int number1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите конечное число:");
                int number2 = Convert.ToInt32(Console.ReadLine());

                int counter = number1;
                Recursion( number2, counter);
                return;
                //Без рекурсии
                while(counter <= number2)
                {
                    Console.WriteLine($"{counter} "); 
                    counter++;
                }
            }         

             void Zadacha67()
            {
                Console.WriteLine("Введите число:");
                int number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"сумма цифр = {DigitsSum(number)}");
                return;
                int temp = number;                
                int result = 0;
                //Без рекурсии
                while(temp > 0)
                {
                    result += temp%10;
                    temp /= 10;
                }
                
            }    

            int DigitsSum(int number)
            {
                if (number == 0) return 0;
                return number%10 + DigitsSum(number/10);
            }

            void Recursion(int number, int counter)
            {
                if(counter > number) return;
                Console.WriteLine($"{counter} "); 
                counter++;
                Recursion(number, counter);

            }

            void Zadacha69()
            {
                //Задача 69: Напишите программу, которая на вход принимает два числа A и B, и возводит число А в целую степень B с помощью рекурсии.
                //A = 3; B = 5 -> 243 (3⁵)
                //A = 2; B = 3 -> 8
                Console.WriteLine("Введите число:");
                int number1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите степень:");
                int number2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"{number1} в степени {number2}  = {RecPow(number1, number2)}");
                return;    
            }

            int RecPow(int number, int pow)
            {
                if(pow == 0) return 1;
                return number * RecPow(number, pow-1);
            }

            Zadacha69();
        }
            
    }
}