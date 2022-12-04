namespace Practice6;
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

        void Fill2DArray(int[,] array, int begin = 0, int range = 10)
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

        void WriteArray(int[] array)
        {
            Console.WriteLine();
            Console.Write("binary array = [ ");
            int size = array.Length;
            for (int i = 0; i < size; i++)
            {
                Console.Write(array[i] + "\t");
            }
            Console.Write("]");
            Console.WriteLine();
        }

        void Write2dArray(int[,] array)
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{array[i, j]}\t");
                }
            }
            Console.WriteLine();
        }


        void Zadacha46()
        {
            int rows = 4;
            int columns = 5;
            int[,] numbers = new int[rows, columns];
            Fill2DArray(numbers, 0, 9);
            Write2dArray(numbers);
        }

        void Zadacha48()
        {
            Console.WriteLine("Введите количество строк");
            int rows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество колонок");
            int columns = Convert.ToInt32(Console.ReadLine());
            int[,] numbers = new int[rows, columns];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    numbers[i, j] = i + j;
            Write2dArray(numbers);
        }

        void Zadacha49()
        {
            //Задача 49: Задайте двумерный массив. Найдите элементы, у которых оба индекса чётные, и замените эти элементы на их квадраты
            int rows = 4;
            int columns = 5;
            int[,] numbers = new int[rows, columns];
            Fill2DArray(numbers, 0, 9);
            Write2dArray(numbers);
            for (int i = 0; i < rows; i += 2)
            {
                for (int j = 0; j < columns; j += 2)
                {
                    numbers[i, j] = numbers[i, j] * numbers[i, j];
                }
            }
            Write2dArray(numbers);
        }

        void Zadacha51()
        {
            //Задача 49: Задайте двумерный массив. Найдите элементы, у которых оба индекса чётные, и замените эти элементы на их квадраты
            int rows = 4;
            int columns = 5;
            int[,] numbers = new int[rows, columns];
            Fill2DArray(numbers, 0, 9);
            Write2dArray(numbers);
            int sum = 0;
            int count = Math.Min(rows, columns);
            for (int i = 0; i < count; i++)
            {
                sum = sum + numbers[i, i];
                Console.Write($"{numbers[i, i]}");
                if(i != (count-1)) Console.Write($" + ");
            } 
             Console.Write($" = {sum}");   

        }

        Zadacha51();
    }
}
