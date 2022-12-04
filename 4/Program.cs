namespace Practice3;
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


        void Zadacha32()
        {
            int size = 12;
            int[] array = new int[12];

            FillArray(array, -10);
            WriteArray(array);

            ChangeSign(array);

            Console.WriteLine("После изменения знака");

            WriteArray(array);
        }

        int FindValue(int[] array, int value)
        {
            int result = -1, size = array.Length;
            for (int i = 0; i < size; i++)
            {
                if (array[i] == value)
                {
                    result = i;
                    i = size;
                }
            }
            result++;
            return result;
        }
        void Zadacha33()
        {
            int size = 12;
            int[] array = new int[size];

            FillArray(array, -9, 9);
            WriteArray(array);
            Console.WriteLine("Введите нужное число: ");
            int value = Convert.ToInt32(Console.ReadLine());
            int position = FindValue(array, value);
            if (position == -1) Console.WriteLine("Данного числа в массиве нет");
            else Console.WriteLine($"Первая позиция введенного числа {position}");
        }

        void Zadacha35()
        {
            //   Задача 35: Задайте одномерный массив из 10 случайных чисел. 
            //   Найдите количество элементов массива, 
            //   значения которых лежат в отрезке [10,99]. 
            //   [5, 18, 123, 6, 2] -> 1
            //   [1, 2, 3, 6, 2] -> 0
            //   [10, 11, 12, 13, 14] -> 5

            int size = 10;
            int[] array = new int[size];
            int first = 10, last = 99, counter = 0;

            FillArray(array, 0, 110);
            WriteArray(array);

            size = array.Length;

            for (int i = 0; i < size; i++)
                if ((array[i] >= first) && (array[i] <= last)) counter++;


            Console.WriteLine($"В массиве {counter} чисел из интервала [{first}:{last}]");
        }

        void Zadacha37()
        {
            //Задача 37: Найдите произведение пар чисел в одномерном массиве. Парой считаем первый и последний элемент, второй и предпоследний и т.д. Результат запишите в новом массиве.
            //[1 2 3 4 5] -> 5 8 3
            //[6 7 3 6] -> 36 21


            int arraySize = 11;
            int[] array = new int[arraySize];

            FillArray(array, 0, 10);
            WriteArray(array);

            int halfSize = arraySize / 2;
            int[] result = new int[halfSize + arraySize % 2];

            int size = result.Length;

            for (int i = 0; i < halfSize; i++)
                result[i] = array[i] * array[arraySize - i - 1];

            if (arraySize % 2 == 1)
                result[halfSize] = array[halfSize];

            WriteArray(result);
        }

        void Zadacha31()
        {
            int size = 12;
            int[] array = new int[12];

            FillArray(array, -9, 9);
            FillArray(array);
            WriteArray(array);

            Console.WriteLine($"Сумма всех чисел {FindSum(array, 0)}");
            Console.WriteLine($"Сумма всех отрицательных чисел {FindSum(array, -1)}");
            Console.WriteLine($"Сумма всех положительных чисел {FindSum(array, 1)}");
        }

        Zadacha37();
    }
}
