using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Dynamic;
using ConsoleApplication1;

namespace ConsoleApplication1
{
    //Пользовательское исключение
    class OutOfRengeExc : Exception { }

    class calc<Ta, Tb, Tx>
    {
        int N, n;
        private void enter(ref int count)
        {
            while (true)
            {
                try
                {
                    count = int.Parse(Console.ReadLine());
                    if (count > 1 | count < 1000)
                        break;
                }
                catch (Exception exc) { Console.WriteLine(exc.Message); }
            }
        }
        public calc()
        {
            Console.WriteLine("Размер вектора А:");
            enter(ref n);
            Console.WriteLine("Размер вектора B:");
            enter(ref N);
        }

        private void print_vec<Tc>(vector<Tc> c)
        {
                if (typeof(Tc).ToString() != "ConsoleApplication1.Complex")
                    Console.WriteLine(c.vec);
                else
                {
                    Complex com = (dynamic)c.vec;
                    com.Display();
                }

        }

        private void set_value<Tc>(ref vector<Tc>[] vec, int n)
        {
            while (true)
            {
                try
                {
                    for (int i = 0; i < n; i++)
                    {
                        vec[i] = new vector<Tc>();
                        Console.Write("[" + i + "]=");
                        if (typeof(Tc).ToString() == "ConsoleApplication1.Complex")
                        {
                            Console.Write("\r\n");
                            Complex com = new Complex(double.MinValue, double.MinValue);
                            vec[i].vec = (dynamic)com;
                        }
                        else if (typeof(Tc).ToString() == "System.Int32")
                            vec[i].vec = (dynamic)int.Parse(Console.ReadLine());
                        else if (typeof(Tc).ToString() == "System.Double")
                            vec[i].vec = (dynamic)double.Parse(Console.ReadLine());
                        else if (typeof(Tc).ToString() == "System.Decimal")
                            vec[i].vec = (dynamic)decimal.Parse(Console.ReadLine());
                        else vec[i].vec = (dynamic)float.Parse(Console.ReadLine());
                    }
                    break;
                }
                catch (Exception exc) { Console.WriteLine(exc.Message); }
            }
        }

        private void set_rnd<Tc>(ref vector<Tc>[] vec, int n)
        {
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                vec[i] = new vector<Tc>();
                if (typeof(Tc).ToString() == "ConsoleApplication1.Complex")
                {
                    Complex com = new Complex(rnd.NextDouble() - 0.5, rnd.NextDouble() - 0.5);
                    vec[i].vec = (dynamic)com;
                }else if (typeof(Tc).ToString() == "System.Int32")
                    vec[i].vec = (dynamic)rnd.Next(0, 1000) - 500;
                else if (typeof(Tc).ToString() == "System.Double")
                    vec[i].vec = (dynamic)rnd.NextDouble() - 0.5;
                else if (typeof(Tc).ToString() == "System.Decimal")
                    vec[i].vec = (dynamic)Convert.ToDecimal(rnd.NextDouble() - 0.5);
                else vec[i].vec = (dynamic)Convert.ToSingle(rnd.NextDouble() - 0.5);
            }
        }

        private vector<Tx> get_result(vector<Ta> a, vector<Tb> b)
        {
            vector<Tx> Left = new vector<Tx>(), Right = new vector<Tx>(), Result = new vector<Tx>();
            try
            {
                if (typeof(Ta).ToString() == "ConsoleApplication1.Complex")
                {
                    if ((dynamic)a > b)
                    {
                        Left.vec = (a.vec * (dynamic)b.vec - (new Complex(1,1)));
                        Right.vec = (dynamic)a.vec;
                        if ((dynamic)Right.vec == new Complex(0, 0))
                            throw new DivideByZeroException();
                        Result.vec = Left.vec / (dynamic)Right.vec;
                        Console.Write("a>b");
                        Debug.WriteLine("Override operator >. X = A > B: " + Left.vec + " / " + Right.vec + " = " + Result);
                    }
                    else if ((dynamic)a < b)
                    {
                        Right.vec = (dynamic)b.vec;
                        Complex number = new Complex(5, 5);
                        Complex number1 = new Complex(4, 4);
                        Left.vec = ((dynamic)number1 * a.vec - (dynamic)number);
                        if ((dynamic)Right.vec == new Complex(0, 0))
                            throw new DivideByZeroException();
                        Result.vec = (dynamic)Left.vec / Right.vec;
                        Console.Write("a<b");
                        Debug.WriteLine("Override operator <. X = A < B: " + Left.vec + " / " + Right.vec + " = " + Result);
                    }
                    else if ((dynamic)a == b)
                    {
                        Result.vec = (dynamic)(new Complex(255, 255));
                        Console.Write("a==b");
                        Debug.WriteLine("Override operator ==. X = A == B: " + Result);
                    }
                    else Console.Write(" К сожалению  условия не подошли");
                }
                else
                {
                    if ((dynamic)a > b)
                    {
                        Left.vec = (a.vec * (dynamic)b.vec - (dynamic)1);
                        Right.vec = (dynamic)a.vec;
                        if ((dynamic)Right.vec == 0)
                            throw new DivideByZeroException();
                        Result.vec = Left.vec / (dynamic)Right.vec + (dynamic)1;
                        Console.Write("a>b");
                        Debug.WriteLine("Override operator >. X = A > B: " + Left.vec + " / " + Right.vec + " = " + Result);
                    }
                    else if ((dynamic)a < b)
                    {
                        Right.vec = (dynamic)b.vec;
                        Left.vec = ((dynamic)4 * a.vec - (dynamic)5);
                        if ((dynamic)Right.vec == 0)
                            throw new DivideByZeroException();
                        Result.vec = Left.vec / (dynamic)Right.vec;
                        Console.Write("a<b");
                        Debug.WriteLine("Override operator <. X = A < B: " + Left.vec + " / " + Right.vec + " = " + Result);
                    }
                    else if ((dynamic)a == b)
                    {
                        Result.vec = (dynamic)255;
                        Console.Write("a==b");
                        Debug.WriteLine("Override operator ==. X = A == B: " + Result);
                    }
                    else Console.Write(" К сожалению ниодного условия не подошло");
                }
            }
            catch (Exception exc) { Console.WriteLine(exc.Message); }
            
            return Result;
        }

        public void menu()
        {
            ConsoleKeyInfo e = new ConsoleKeyInfo();
            vector<Ta>[] a_vec = new vector<Ta>[n];
            vector<Ta> a = new vector<Ta>();
            vector<Tb>[] b_vec = new vector<Tb>[N];
            vector<Tb> b = new vector<Tb>();
            Debug.Indent();
            bool enter_value = false;
            //Циклическое "Меню"
            while (e.Key != ConsoleKey.Escape)
            {
                Console.Clear();
                Console.WriteLine("1 Перезаписать размерность векторов А и В");
                Console.WriteLine("2 Перезаписать векторы А и В");
                Console.WriteLine("3 Вывести на экран векторы А и В");
                Console.WriteLine("4 Вычислить результат");
                Console.WriteLine("Esc Выход");
                e = Console.ReadKey(true);
                Console.Clear();
                //Ввод размерности
                if (e.Key == ConsoleKey.D1)
                {
                    Console.WriteLine("Размер вектора А:");
                    enter(ref n);
                    Console.WriteLine("Размер вектора B:");
                    enter(ref N);
                }
                //Ввод данных
                else if (e.Key == ConsoleKey.D2)
                {
                    if (n > 10)
                        set_rnd<Ta>(ref a_vec, n);
                    else
                    {
                        Console.WriteLine("Введите вектор А типа "+typeof(Ta).ToString());
                        Console.Write("a");
                        set_value<Ta>(ref a_vec, n);
                    }

                    if (N > 10)
                        set_rnd<Tb>(ref b_vec, N);
                    else
                    {
                        Console.WriteLine("Введите вектор B типа " + typeof(Tb).ToString() + ":");
                        Console.Write("b");
                        set_value<Tb>(ref b_vec, N);
                    }
                    if (n == N && n == 1)
                    {
                        a = a_vec[0];
                        b = b_vec[0];
                    }
                    enter_value = true;
                    Console.WriteLine("Векторы были успешно записаны");
                }
                //Вывод векторов
                else if (e.Key == ConsoleKey.D3 & enter_value)
                {
                    if (n == N && n == 1)
                    {
                        Console.WriteLine("\r\n\r\nВектор A типа:" + typeof(Ta).ToString() + "\r\n");
                        print_vec<Ta>(a);
                        Console.WriteLine("\r\n\r\nВектор B типа:" + typeof(Tb).ToString() + "\r\n");
                        print_vec<Tb>(b);
                    }
                    else
                    {
                        Console.WriteLine("Вектор А типа:" + typeof(Ta).ToString() + "\r\n");
                        for (int i = 0; i < n; i++)
                            print_vec<Ta>(a_vec[i]);
                        Console.WriteLine("\r\n\r\nВектор B типа:" + typeof(Tb).ToString() + "\r\n");
                        for (int i = 0; i < N; i++)
                            print_vec<Tb>(b_vec[i]);
                    }
                }
                //Вычисление вектора
                else if (e.Key == ConsoleKey.D4 & enter_value)
                {
                    if (n == N && n == 1)
                    {
                        Console.WriteLine("\r\n\r\nВектор A типа:" + typeof(Ta).ToString() + "\r\n");
                        print_vec<Ta>(a);
                        Console.WriteLine("\r\n\r\nВектор B типа:" + typeof(Tb).ToString() + "\r\n");
                        print_vec<Tb>(b);
                    }
                    else
                    {
                        Console.WriteLine("Вектор А типа:" + typeof(Ta).ToString() + "\r\n");
                        for (int i = 0; i < n; i++)
                            print_vec<Ta>(a_vec[i]);
                        Console.WriteLine("\r\n\r\nВектор B типа:" + typeof(Tb).ToString() + "\r\n");
                        for (int i = 0; i < N; i++)
                            print_vec<Tb>(b_vec[i]);
                    }
                    Console.WriteLine("\r\n");
                    if (n == N && n == 1)
                    {
                        vector<Tx> x = new vector<Tx>();
                        Console.WriteLine("\r\n\r\nВектор X типа:" + typeof(Tx).ToString() + "\r\n");
                        x = new vector<Tx>();
                        Console.Write("[" + 0 + "]: ");
                        x = get_result(a, b);
                        Console.Write("   x = ");
                        print_vec<Tx>(x);
                    }
                    else
                    {
                        vector<Tx>[] x = new vector<Tx>[n];
                        Console.WriteLine("\r\n\r\nВектор X типа:" + typeof(Tx).ToString() + "\r\n");
                        if (n > N)
                            n = N;
                        for (int i = 0; i < n; i++)
                        {
                            x[i] = new vector<Tx>();
                            Console.Write("[" + i + "]: ");
                            x[i] = get_result(a_vec[i], b_vec[i]);
                            Console.Write("   x = ");
                            print_vec<Tx>(x[i]);
                        }
                    }
                }
                //Выход из цикла как только нажата клавиша ескейп.
                else if (e.Key == ConsoleKey.Escape) break;
                if (!enter_value)
                    Console.WriteLine("Введите сначала векторы");
                Console.WriteLine("\r\n\r\nДля продолжения нажмите любую кнопку...");
                Console.ReadKey(true);

            }
        }
    }
}
