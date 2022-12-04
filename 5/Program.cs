void Zadacha39()
{
    Random rand = new Random();
    int size = rand.Next(4, 9);
    int[] array = new int[size];

    FillArray(array, 0, 101);
    PrintArray(array);

    for (int i = 0; i < size / 2; i++)
        (array[i], array[size - 1 - i]) = (array[size - 1 - i], array[i]);

    PrintArray(array);
}

void Zadacha40()
{
    Console.WriteLine("Введите длину AB");
    int AB = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите длину BC");
    int BC = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите длину CA");
    int CA = Convert.ToInt32(Console.ReadLine());
    if (AB < (BC + CA) && BC < (AB + CA) && CA < (BC + AB))
        Console.WriteLine("Треугольник с такими сторонами существует");
    else
        Console.WriteLine("Треугольник с такими сторонами не существует");
}

void Zadacha42()
{
    Console.WriteLine("Введите десятичное число");
    int tenX = Convert.ToInt32(Console.ReadLine());
    string result = String.Empty;
    int temp = tenX;
    while (temp > 0)
    {
        result = temp % 2 + result;
        temp /= 2;
    }
    Console.WriteLine($"Двоичная форма числа {result}");
}

void Zadacha44()
{
    Console.WriteLine("Введите границу чисел фибоначи");
    int max = Convert.ToInt32(Console.ReadLine());
    int prev = 0;
    int prev2 = 1;
    Console.Write($"{prev} {prev2} ");
    for (int i = 2; i < max; i++)
    {
        int current = prev + prev2;
        prev = prev2;
        prev2 = current;
        Console.Write($"{current} ");
    }
    Console.WriteLine();
} 

void Zadacha45()
{
    Random rand = new Random();
    int size = rand.Next(4, 9);
    int[] array = new int[size];

    FillArray(array, 0, 101);
    PrintArray(array);  

    int[] copyarray = new int[size];
    CopyArray(array, copyarray);
    PrintArray(copyarray);
}

void CopyArray(int[] from, int[] to)
{
    int size = from.Length;
    for (int i = 0; i < size; i++)
       to[i] = from[i];
}
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

void PrintArray(int[] array)
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

Zadacha45();
