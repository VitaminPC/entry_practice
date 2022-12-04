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

        double Distance2d(int x1, int y1, int x2, int y2)
        {
            return Math.Round(Math.Sqrt((y2 - y1) * (y2 - y1) + (x2 - x1) * (x2 - x1)), 2);
        }

        double Distance3d(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            return Math.Round(Math.Sqrt((y1 - x1) * (y1 - x1) + (y2 - x2) * (y2 - x2) + (y3 - x3) * (y3 - x3)), 2);
        }

        void ReadPoint(string pointName, int[] pointArray)
        {
            Console.WriteLine($"Введите координаты точки {pointName} (через пробел):");
            string inputValue = Console.ReadLine();
            int dimencity = pointArray.Length;
            string[] strPointArray = new string[dimencity];
            if (inputValue != null)
            {
                strPointArray = inputValue.Split(" ");
                for (int i = 0; i < dimencity; i++) pointArray[i] = Convert.ToInt32(strPointArray[i]);
            }
        }

        bool IsContainDigits(int value, int digit1 = -1, int digit2 = -1)
        {
            int checkvalue = 0;
            int tempvalue = value;

            while (tempvalue > 0)
            {
                checkvalue = tempvalue % 10;

                if (digit1 > -1 && checkvalue == digit1)
                {
                    return true;
                }
                else if (digit2 > -1 && checkvalue == digit2)
                {
                    return true;
                }

                tempvalue /= 10;
            }
            return false;
        }

        void Zadacha19()
        {

            // Задача 19
            // Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.
            // 14212 -> нет
            // 23432 -> да
            // 12821 -> да

            Console.WriteLine("Введите пятизначное число ");
            int value = Convert.ToInt32(Console.ReadLine());

            if (value > 99999 || value < 10000)
            {
                Console.WriteLine("Введенное число не пятизначное");
                return;
            }

            int checkvalue = 0;
            int tempvalue = value;

            int counter = 4;
            while (tempvalue > 0)
            {
                checkvalue += tempvalue % 10 * Convert.ToInt32(Math.Pow(10, counter));
                tempvalue /= 10;
                counter--;
            }
            if (value == checkvalue)
                Console.WriteLine($"{value} является палиндромом");
            else
                Console.WriteLine($"{value} не является палиндромом");
        }

        void Zadacha21()
        {
            // Задача 21
            // Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.
            // A (3,6,8); B (2,1,-7), -> 15.84
            // A (7,-5, 0); B (1,-1,9) -> 11.53
            int[] pointArray = new int[3];
            ReadPoint("А", pointArray);
            var pointA = (pointArray[0], pointArray[1], pointArray[2]);

            ReadPoint("Б", pointArray);
            var pointB = (pointArray[0], pointArray[1], pointArray[2]);

            double distance = Distance3d(pointB.Item1, pointA.Item1, pointB.Item2, pointA.Item2, pointB.Item3, pointA.Item3);

            Console.WriteLine($"Расстояние между А и Б = {distance}");
        }

        void Zadacha23()
        {
            // Задача 23
            // Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.
            // 3 -> 1, 8, 27
            // 5 -> 1, 8, 27, 64, 125
            Console.WriteLine("Введите число ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Таблица кубов данного числа: ");
            for (int i = 1; i <= number; i++)
            {
                Console.Write(i * i * i);
                if (i != number) Console.Write(", ");
            }
        }

        void ZadachaDop1()
        {
            // Задача 1. Рассчитать значение y при заданном x по формуле
            // x > 0: y = sin^2(x);
            // x <=0: y = 1 - 2*sin^2(x);
            Console.WriteLine("Введите число x");
            double x = Convert.ToDouble(Console.ReadLine());
            double y = Math.Sin(x);

            if (x > 0)
                y = y * y;
            else
                y = 1 - 2 * y * y;
            Console.WriteLine($"y = {y}");
        }

        void ZadachaDop2()
        {
            //Задача 2. Дано трёхзначное число N. Определить кратна ли трём сумма всех его цифр.
            Console.WriteLine("Введите трехзначное число ");
            int value = Convert.ToInt32(Console.ReadLine());

            if (value > 999 || value < 100)
            {
                Console.WriteLine("Введенное число не трехзначное");
                return;
            }

            int checkvalue = 0;
            int tempvalue = value;

            while (tempvalue > 0)
            {
                checkvalue += tempvalue % 10;
                tempvalue /= 10;
            }

            if (checkvalue % 3 == 0)
                Console.WriteLine($"Сумма всех цифр = {checkvalue} кратна 3");
            else
                Console.WriteLine($"Сумма всех цифр = {checkvalue} не кратна 3");
        }

        void ZadachaDop3()
        {
            //Задача 3. Дано трёхзначное число N. Определить, есть ли среди его цифр 4 или 7.
            Console.WriteLine("Введите трехзначное число ");
            int value = Convert.ToInt32(Console.ReadLine());

            if (value > 999 || value < 100)
            {
                Console.WriteLine("Введенное число не трехзначное");
                return;
            }

            if (IsContainDigits(value, 4, 7))
                Console.WriteLine("Среди цифр числа есть 4 или 7");
            else
                Console.WriteLine($"Среди цифр числа отсутствуют 4 и 7");
        }
        void ZadachaDop4()
        {
            //Задача 4. Дан массив длиной 10 элементов. Заполнить его последовательно числами от 1 до 10.
            int[] array = new int[10];
            Console.WriteLine("Создан массив: ");
            WriteArray(array);
            for (int i = 0; i < 10; i++) array[i] = i + 1;
            Console.WriteLine("Массив заполнен: ");
            WriteArray(array);
        }

        void ZadachaPow1()
        {
            //Задача 1. На ввод подаётся номер четверти. Создаются 3 случайные точки в этой четверти. 
            //Определите самый оптимальный маршрут для торгового менеджера, который выезжает из центра координат.
            Console.WriteLine("Введите номер четверти:");
            int quart = Convert.ToInt32(Console.ReadLine());
            int signX = 1;
            int signY = 1;
            if (quart == 1)
            {
                signX = 1;
                signY = 1;
            }
            else if (quart == 2)
            {
                signX = 1;
                signY = -1;
            }
            else if (quart == 3)
            {
                signX = -1;
                signY = -1;
            }
            else if (quart == 4)
            {
                signX = -1;
                signY = 1;
            }
            else
            {
                Console.WriteLine("Введите правильный номер четверти");
            }

            Random rand = new Random();

            var point0 = (0, 0, 0);
            var points = ((signX * rand.Next(0, 100), signY * rand.Next(0, 100), "a", 0.00),
                            (signX * rand.Next(0, 100), signY * rand.Next(0, 100), "b", 0.00),
                            (signX * rand.Next(0, 100), signY * rand.Next(0, 100), "c", 0.00));

            points.Item1.Item4 = Distance2d(point0.Item1, points.Item1.Item1, point0.Item2, points.Item1.Item2);
            points.Item2.Item4 = Distance2d(point0.Item1, points.Item2.Item1, point0.Item2, points.Item2.Item2);
            points.Item3.Item4 = Distance2d(point0.Item1, points.Item3.Item1, point0.Item2, points.Item3.Item2);

            Console.WriteLine("Координаты маршрута:");
            Console.WriteLine($"({0},{0})");
            Console.WriteLine($"{points.Item1.Item3} = ({points.Item1.Item1},{points.Item1.Item2}) , расстояние от центра {points.Item1.Item4}");
            Console.WriteLine($"{points.Item2.Item3} = ({points.Item2.Item1},{points.Item2.Item2}) , расстояние от центра {points.Item2.Item4}");
            Console.WriteLine($"{points.Item3.Item3} = ({points.Item3.Item1},{points.Item3.Item2}) , расстояние от центра {points.Item3.Item4}");

            if (points.Item1.Item4 > points.Item2.Item4)
                (points.Item1, points.Item2) = (points.Item2, points.Item1);
            if (points.Item2.Item4 > points.Item3.Item4)
                (points.Item2, points.Item3) = (points.Item3, points.Item2);
            if (points.Item1.Item4 > points.Item2.Item4)
                (points.Item1, points.Item2) = (points.Item2, points.Item1);

            Console.WriteLine("Оптимальный маршрут:");
            Console.WriteLine($"(0,0) -> {points.Item1.Item3} -> {points.Item2.Item3} -> {points.Item3.Item3} -> (0,0)");

        }

        void ZadachaPow2()
        {
            //Задача 2. Даны 4 точки a, b, c, d. Пересекаются ли вектора AB и CD?
            int[] pointArray = new int[2];
            ReadPoint("А", pointArray);
            var pointA = (pointArray[0], pointArray[1]);

            ReadPoint("B", pointArray);
            var pointB = (pointArray[0], pointArray[1]);

            ReadPoint("C", pointArray);
            var pointC = (pointArray[0], pointArray[1]);

            ReadPoint("D", pointArray);
            var pointD = (pointArray[0], pointArray[1]);

            //(x - x1)/(x2 - x1) = (y-y1)/(y2 - y1)
            //K1 = (x2 - x1)/(y2-y1)
            //x =  yK1 - y1*K1 + x1;
            //K2 = y1*K1 - x1;
            //(x - x3)/(x4 - x3) = (y-y3)/(y4 - y3)
            //x =  y * (x4-x3)/(y4-y3) - (y3/(y4-x3) + x3/(x4-x3)) * (x4-x3) = y * K3 - K4;
            //K3 = (x4 - x3)/(y4-y3)
            //K4 = y1*K3 - x3;
            //y = (K2 - K4) / (K1- K3);
            if ((pointB.Item2 - pointA.Item2) == 0 || (pointD.Item2 - pointC.Item2) == 0)
            {
                Console.WriteLine("Прямые AB CD не пересекаются");
                return;
            }
            double K1 = (pointB.Item1 - pointA.Item1) / (pointB.Item2 - pointA.Item2);
            double K2 = pointA.Item2 * K1 - pointA.Item1;

            double K3 = (pointD.Item1 - pointC.Item1) / (pointD.Item2 - pointC.Item2);

            double K4 = pointC.Item2 * K1 - pointC.Item1;
            if ((K1 - K3) == 0)
            {
                Console.WriteLine("Прямые AB CD не пересекаются");
                return;
            }

            double y = (K2 - K4) / (K1 - K3);
            double x = y * K3 - K4;

            Console.WriteLine($"Векторы AB CD пересекаются в точке ({Math.Round(x, 2)},{Math.Round(y, 2)})");
        }
        void ZadachaPow3()
        {
            //Задача 2. Даны 4 точки a, b, c, d. Пересекаются ли вектора AB и CD?
            int[] pointArray = new int[2];
            ReadPoint("А", pointArray);
            var pointA = (pointArray[0], pointArray[1]);

            ReadPoint("B", pointArray);
            var pointB = (pointArray[0], pointArray[1]);

            ReadPoint("C", pointArray);
            var pointC = (pointArray[0], pointArray[1]);

            ReadPoint("D", pointArray);
            var pointD = (pointArray[0], pointArray[1]);

            //(x - x1)/(x2 - x1) = (y-y1)/(y2 - y1)
            //K1 = (x2 - x1)/(y2-y1)
            //x =  yK1 - y1*K1 + x1;
            //K2 = y1*K1 - x1;
            //(x - x3)/(x4 - x3) = (y-y3)/(y4 - y3)
            //x =  y * (x4-x3)/(y4-y3) - (y3/(y4-x3) + x3/(x4-x3)) * (x4-x3) = y * K3 - K4;
            //K3 = (x4 - x3)/(y4-y3)
            //K4 = y1*K3 - x3;
            //y = (K2 - K4) / (K1- K3);
            if ((pointB.Item2 - pointA.Item2) == 0 || (pointD.Item2 - pointC.Item2) == 0)
            {
                Console.WriteLine("Прямые AB CD не пересекаются");
                return;
            }
            double K1 = (pointB.Item1 - pointA.Item1) / (pointB.Item2 - pointA.Item2);
            double K2 = pointA.Item2 * K1 - pointA.Item1;

            double K3 = (pointD.Item1 - pointC.Item1) / (pointD.Item2 - pointC.Item2);

            double K4 = pointC.Item2 * K1 - pointC.Item1;
            if ((K1 - K3) == 0)
            {
                Console.WriteLine("Прямые AB CD не пересекаются");
                return;
            }

            double y = (K2 - K4) / (K1 - K3);
            double x = y * K3 - K4;

            Console.WriteLine($"Векторы AB CD пересекаются в точке ({Math.Round(x, 2)} ; {Math.Round(y, 2)})");
            if (x == 0)
                Console.WriteLine($"Точка пересечения находится на оси координат Х");
            else if (y == 0)
                Console.WriteLine($"Точка пересечения находится на оси координат y");
            else if (x > 0 && y > 0)
                Console.WriteLine($"Точка пересечения находится в первой четверти");
            else if (x > 0 && y < 0)
                Console.WriteLine($"Точка пересечения находится в второй четверти");
            else if (x < 0 && y < 0)
                Console.WriteLine($"Точка пересечения находится в третей четверти");
            else if (x < 0 && y > 0)
                Console.WriteLine($"Точка пересечения находится в четвертой четверти");

        }

        void ZadachaPow4()
        {
            //Задача 4. Дан массив средних температур (массив заполняется случайно) за последние 10 лет. 
            //На ввод подают номер месяца и год начали и конца.
            //Определить самые высокие и низкие температуры для лета, осени, зимы и весны в заданном промежутке. 
            //Если таких температур нет, сообщить, что определить не удалось.
            //
            //Months = (Month2 - d1.Month1) + 12 * (Year2 - Year1);
            Console.WriteLine($"Введите начальные месяц и год (через пробел):");
            string inputValue = Console.ReadLine();
            string[] strPointArray = new string[2];
            strPointArray = inputValue.Split(" ");
            int month1 = Convert.ToInt32(strPointArray[0]);
            int year1 = Convert.ToInt32(strPointArray[1]);

            Console.WriteLine($"Введите конечные месяц и год (через пробел):");
            inputValue = Console.ReadLine();
            strPointArray = inputValue.Split(" ");
            int month2 = Convert.ToInt32(strPointArray[0]);
            int year2 = Convert.ToInt32(strPointArray[1]);


            int monthes = (12 - month1 + month2) + 12 * (year2 - year1 - 1) + 1;

            Console.WriteLine("Месяцев " + monthes);
            int[,] array = new int[monthes, 4];
            Random rand = new Random();

            int currentyear = year1;
            int currentmonth = month1 - 1;
            for (int i = 0; i < monthes; i++)
            {
                currentmonth++;
                if ((month1 + i) % 12 == 0)
                {
                    array[i, 0] = 12;
                    array[i, 1] = currentyear;
                }
                else
                {
                    array[i, 0] = (month1 + i) % 12;
                    currentyear = year1 + (month1 + i) / 12;
                    array[i, 1] = currentyear;

                }
                if (currentmonth == 1 || currentmonth == 2 || currentmonth == 3) array[i, 2] = 0;
                else if (currentmonth == 4 || currentmonth == 6 || currentmonth == 7) array[i, 2] = 1;
                else if (currentmonth == 7 || currentmonth == 8 || currentmonth == 9) array[i, 2] = 2;
                else if (currentmonth == 10 || currentmonth == 11 || currentmonth == 12) array[i, 2] = 3;
                array[i, 3] = rand.Next(-10, 36);
                Console.WriteLine($"Месяц {array[i, 0]}\t\tГод {array[i, 1]}\tВремя года {array[i, 2]}\tТемпература {array[i, 3]}");
                if (currentmonth == 12) currentmonth = 0;
            }

            int winterCount = 0;
            int springCount = 0;
            int summerCount = 0;
            int automnCount = 0;

            int winterDegree = 0;
            int springDegree = 0;
            int summerDegree = 0;
            int automnDegree = 0;

            Console.WriteLine($"Введите месяц и год начала анализа (через пробел):");
            inputValue = Console.ReadLine();
            strPointArray = inputValue.Split(" ");
            int month3 = Convert.ToInt32(strPointArray[0]);
            int year3 = Convert.ToInt32(strPointArray[1]);

            Console.WriteLine($"Введите месяц и год окончания анализа (через пробел):");
            inputValue = Console.ReadLine();
            strPointArray = inputValue.Split(" ");
            int month4 = Convert.ToInt32(strPointArray[0]);
            int year4 = Convert.ToInt32(strPointArray[1]);
            monthes = (12 - month3 + month4) + 12 * (year4 - year3 - 1) + 1;
            int monthesFirst = (12 - month1 + month3) + 12 * (year3 - year1 - 1) + 1;

            for (int i = 0; i < monthes; i++)
            {
                int currentMonth = monthesFirst + i;
                if (array[currentMonth, 2] == 0)
                {
                    winterCount++;
                    winterDegree += array[currentMonth, 3];
                }
                else if (array[currentMonth, 2] == 1)
                {
                    springCount++;
                    springDegree += array[currentMonth, 3];
                }
                else if (array[currentMonth, 2] == 2)
                {
                    summerCount++;
                    summerDegree += array[currentMonth, 3];
                }
                else if (array[currentMonth, 2] == 3)
                {
                    automnCount++;
                    automnDegree += array[currentMonth, 3];
                }
            }

            Console.WriteLine();
            if (winterCount > 0) Console.WriteLine($"Средняя температура за зимние месяцы {winterDegree / winterCount}");
            else Console.WriteLine("Зимние месяцы в заданном интервале отсутствуют");

            Console.WriteLine();
            if (springCount > 0) Console.WriteLine($"Средняя температура за весенние месяцы {springDegree / springCount}");
            else Console.WriteLine("Весение месяцы в заданном интервале отсутствуют");

            Console.WriteLine();
            if (summerCount > 0) Console.WriteLine($"Средняя температура за летние месяцы {summerDegree / summerCount}");
            else Console.WriteLine("Летние месяцы в заданном интервале отсутствуют");

            Console.WriteLine();
            if (automnCount > 0) Console.WriteLine($"Средняя температура за осенние месяцы {automnDegree / automnCount}");
            else Console.WriteLine("Осенние месяцы в заданном интервале отсутствуют");
        }

        void ZadachaPow5()
        {
            //Задача 5. На вход подаётся число n > 4, указывающее длину пароля. 
            //Создайте метод, генерирующий пароль заданной длины. 
            //В пароле обязательно использовать цифру, букву и специальный знак.
            string Digits = "0123456789";
            string Alphabet = "abcdefghijklmnopqrstuvwxyz";
            string Symbols = "~`@#$%^&*()_+-=[]{};'\\:\"|,./<>?";
            Console.WriteLine("Введите нужную длину пароля");
            int count = Convert.ToInt32(Console.ReadLine());

            if (count < 4)
            {
                Console.WriteLine("Длина пароля не может быть меньше 4");
                return;
            }

            string parole = "";
            Random rand = new Random();
            bool digitsUsed = false;
            bool alphabetUsed = false;
            bool symbolsUsed = false;
            int symbolNum = 0;

            for (int i = 0; i < count; i++)
            {
                int tableNum = rand.Next(0, 3);

                if (tableNum == 0)
                {
                    symbolNum = rand.Next(0, Digits.Length);
                    parole += Digits[symbolNum];
                    digitsUsed = true;
                }
                else if (tableNum == 1)
                {
                    symbolNum = rand.Next(0, Alphabet.Length);
                    parole += Alphabet[symbolNum];
                    alphabetUsed = true;
                }
                else if (tableNum == 2)
                {
                    symbolNum = rand.Next(0, Symbols.Length);
                    parole += Symbols[symbolNum];
                    symbolsUsed = true;
                }

            }

            if (!digitsUsed || !alphabetUsed || !symbolsUsed)
            {   //на всякий случай добавляем все три в конец
                parole = parole.Remove(parole.Length - 3, 3);

                symbolNum = rand.Next(0, Digits.Length);
                parole = parole + Digits[symbolNum];

                symbolNum = rand.Next(0, Alphabet.Length);
                parole = parole + Alphabet[symbolNum];

                symbolNum = rand.Next(0, Symbols.Length);
                parole = parole + Symbols[symbolNum];
            }

            Console.WriteLine($"Пароль {parole}");

        }

        void ZadachaPow6()
        {
            //Задача 6. Из центра координат к точке А(x, y) проведён отрезок АО. 
            //Напишите программу, определяющую наименьший угол наклона отрезка AO к оси X.
            //S = x * y / 2
            //z = sqrt(x^2 + y^2)
            //S = z * х * sin L / 2; sin L - S/(z*x/2)
            //L = arcsin(S / (z * x) / 2) radian
            int[] pointArray = new int[2];
            ReadPoint("А", pointArray);
            var pointA = (pointArray[0], pointArray[1]);

            double z = Distance2d(0, 0, pointA.Item1, pointA.Item2);
            Console.WriteLine(z);
            double S = Math.Abs(pointA.Item1 * pointA.Item2 / 2);
            Console.WriteLine(S);
            Console.WriteLine(S / (z * Math.Abs(pointA.Item1) / 2));
            double L = Math.Asin(S / (z * Math.Abs(pointA.Item1) / 2)) * 57.29577951308; //radian->gradus

            Console.WriteLine($"Наименьший угол = {L}");
        }

        void ZadachaPow7()
        {
            //Задача 7. Массив из ста элементов заполняется случайными числами от 1 до 100. 
            //Удалить из массива все элементы, содержащие цифру 3. 
            //Вывести в консоль новый массив и количество удалённых элементов.
            int size = 100;
            int[] array = new int[size];
            FillArray(array, 0, 100);
            WriteArray(array);

            int deletedcounter = 0;

            for (int i = 0; i < size; i++)
                if (IsContainDigits(array[i], 3))
                    deletedcounter++;

            int[] newArray = new int[size - deletedcounter];
            for (int i = 0, j = 0; i < size; i++)
                if (!IsContainDigits(array[i], 3))
                {
                    newArray[j] = array[i];
                    j++;
                }
            array = newArray;

            Console.WriteLine($"Количество удаленных элементов с цифрой 3 {deletedcounter}");
            Console.WriteLine("Результат:");
            Console.WriteLine($"Длина массива {array.Length}");
            WriteArray(array);

        }

        void ZadachaPow8()
        {
            //Задача 8. Напишите программу, который выводит на консоль таблицу умножения от 1 до n, 
            //где n задаётся случайно от 2 до 100.
            Random rand = new Random();
            int n = rand.Next(2, 101);
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    Console.WriteLine($"{i}\t * {j}\t = {i*j}");
                }
                Console.WriteLine();
            }
        }

        void ZadachaPow9()
        {
            //Задача 9. Дана игра со следующими правилами. 
            //Первый игрок называет любое натуральное число от 2 до 9,
            //второй умножает его на любое натуральное число от 2 до 9, 
            //первый умножает результат на любое натуральное число от 2 до 9 и т. д. 
            //Выигрывает тот, у кого впервые получится число больше 1000. Запрограммировать консольный вариант игры.
           string[] menu = {"1й игрок. Выбор числа от 2 до 9",
                            "1й игрок. Выбор числа для умножения от 2 до 9",
                            "2й игрок. Выбор числа для умножения от 2 до 9"
                            };     
            int result = 0;
            int move = 0;
            int currentPlayer = 0;
            while(result <= 1000)
            {
                Console.Clear();
                Console.WriteLine($"Result = {result}");
                Console.WriteLine();

                Console.WriteLine(menu[currentPlayer]);
                move = Convert.ToInt32(Console.ReadLine());

                if(move < 2 || move > 9)
                {
                    Console.WriteLine("Неправильный ход. Введите значение от 2 до 9!");
                    System.Threading.Thread.Sleep(1000);
                }
                else if(currentPlayer == 0)
                {
                   result = move;     
                   currentPlayer = 2;
                }
                else
                {
                    result *= move;
                    if(result <= 1000)
                        if(currentPlayer < 2)
                            currentPlayer = 2;
                        else
                            currentPlayer = 1;
                }
            }

            Console.Clear();
            Console.WriteLine($"Result = {result}");
            Console.WriteLine();

            Console.WriteLine("GAME OVER");
            Console.WriteLine($"Игрок под номером {currentPlayer} проиграл!");
        }

        ZadachaPow9();
        //ZadachaPow8();
        //ZadachaPow7();
        //ZadachaPow6();
        //ZadachaPow5();
        //ZadachaPow4();
        //ZadachaPow3();
        //ZadachaPow2();
        //ZadachaPow1();
        //ZadachaDop4();
        //ZadachaDop3();
        //ZadachaDop2();
        //ZadachaDop1();
        //Zadacha19();
        //Zadacha21();
        //Zadacha23();
    }
}