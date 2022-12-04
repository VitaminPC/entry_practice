namespace Practice4;
class Program
{
    static void Main(string[] args)
    {
        void FillArray(int[] array, int begin = 0, int range = 10)
        {
            range++;
            Random ramdomizer = new Random();
            int size = array.Length;
            for (int i = 0; i < size; i++)
            {
                array[i] = ramdomizer.Next(begin, range);
            }

        }

        void WriteArray(int[] array)
        {
            Console.WriteLine();
            Console.Write("binary array = [ ");
            int size = array.Length;
            for (int i = 0; i < size; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.Write("]");
            Console.WriteLine();
        }

        int FindSum(int[] array, int condition)
        {   //condition 0 - all, -1, 1
            int result = 0;
            int size = array.Length;
            for (int i = 0; i < size; i++)
                if (condition == 0)
                {
                    result += array[i];
                }
                else if (condition == -1 && array[i] < 0)
                {
                    result += array[i];
                }
                else if (condition == 1 && array[i] > 0)
                {
                    result += array[i];
                }
            return result;
        }

        void ChangeSign(int[] array)
        {
            int result = 0;
            int size = array.Length;
            for (int i = 0; i < size; i++) array[i] *= -1;
        }

        void Zadacha25()
        {
            // Задача 25: Используя определение степени числа, напишите цикл, который принимает на вход два натуральных числа (A и B) 
            // и возводит число A в степень B.
            // 3, 5 -> 243 (3⁵)
            // 2, 4 -> 16
        }
        // Задача 27: Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.
        // 452 -> 11
        // 82 -> 10
        // 9012 -> 12

        // Задача 29: Напишите программу, которая задаёт массив из 8 случайных целых чисел и выводит отсортированный по модулю массив.
        // -2, 1, -7, 5, 19 -> [1, -2, 5, -7, 19]
        // 6, 1, -33 -> [1, 6, -33]

        Zadacha25();
    }
}
