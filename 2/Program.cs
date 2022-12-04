
internal class Program
{
    private static void Main(string[] args)
    {

        void Zadacha17()
        {
            //Console.WriteLine("Введите координату х");
            //int х = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Введите координату у");
            //int y = Convert.ToInt32(Console.ReadLine());
            Random rand = new Random();
            int x = rand.Next(-10, 11);
            int y = rand.Next(-10, 11);
            Console.WriteLine($"х = {x} y = {y}");

            if (x > 0 && y > 0) Console.WriteLine("1-я четверть");
            else if (x > 0 && y < 0) Console.WriteLine("4-я четверть");
            else if (x < 0 && y < 0) Console.WriteLine("3-я четверть");
            else if (x < 0 && y < 0) Console.WriteLine("2-я четверть");
            else if (x > 0 && y == 0) Console.WriteLine("Справа на оси х");
            else if (x == 0 && y > 0) Console.WriteLine("Вверху на оси у");
            else if (x < 0 && y == 0) Console.WriteLine("Слева на оси х");
            else if (x == 0 && y < 0) Console.WriteLine("Внизу на оси у");
        }

        void Zadacha18()
        {
            Console.WriteLine("Введите номер четверти");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number == 1) Console.WriteLine("x > 0 И y > 0");
            else if (number == 2) Console.WriteLine("x < 0 И y < 0");
            else if (number == 3) Console.WriteLine("x < 0 И y < 0");
            else if (number == 4) Console.WriteLine("x > 0 И y < 0");
            else Console.WriteLine("Такой четверти не существует");
        }

        double gipotenuza(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        void Zadacha21()
        {
            Random rand = new Random();
            int x1 = rand.Next(-10, 11);
            int y1 = rand.Next(-10, 11);
            Console.WriteLine($"х1 = {x1} y1 = {y1}");
            int x2 = rand.Next(-10, 11);
            int y2 = rand.Next(-10, 11);
            Console.WriteLine($"х2 = {x2} y2 = {y2}");

            Console.WriteLine($"Растояние между точками = {gipotenuza(x1, y1, x2, y2)}");
        }
        void Zadacha22()
        {
            Console.WriteLine("Введите целое число");
            int number = Convert.ToInt32(Console.ReadLine());
            int index = 1;
            Console.Write($"{number} -> ");
            while (index <= number)
            {
                Console.Write($"{Math.Pow(index, 2)} ");
                index++;
            }
        }

        Zadacha22();
    }
}