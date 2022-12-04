namespace Practice7;
class Program
{
    static void Main(string[] args)
    {

         void FillArray(int[,] array, int begin = 0, int range = 10)
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

 


        void Zadacha53()
        {
            int[,] array = new int[4, 5];
            FillArray(array, 0, 100);
            PrintArray(array);

            for (int j = 0; j < 5; j++)
            {
                (array[0, j], array[3, j]) = (array[3, j], array[0, j]);
            }

            PrintArray(array);


        }

        void Zadacha55()
        {
            int rows = 5;
            int columns = 5;
            int[,] array = new int[rows, columns];
            FillArray(array, 0, 100);
            PrintArray(array);

            rows = array.GetLength(0);
            columns = array.GetLength(1);

            if(rows != columns)  
            {
                Console.WriteLine("Массив не квадратный.");
                return;
            } 

            for (int i = 0; i < rows; i++)
                for (int j = i; j < columns; j++)
                    (array[i, j], array[j, i]) = (array[j, i], array[i, j]);
            
            PrintArray(array);


        }

        void Zadacha57()
        {
            //Задача 57: Составить частотный словарь элементов двумерного массива. 
            //Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных.
            int rows = 10;
            int columns = 10;
            int[,] array = new int[rows, columns];
            FillArray(array, 0, 9);
            PrintArray(array);
            int[] dictionary = new int[10];

            for(int i = 0; i < rows; i++)
                for(int j = 0; j < columns; j++)
                    dictionary[array[i,j]]++;
            Console.WriteLine();
            PrintArray2(dictionary);    




        }

        Zadacha57();

        
    }

    static void PrintArray(int[,] array)
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

    static void PrintArray2(int[] array)
    {
        int size = array.Length;
        for (int i = 0; i < size; i++)
        {
            Console.Write($"{array[i]}\t");
        }
        Console.WriteLine();
    }
}
