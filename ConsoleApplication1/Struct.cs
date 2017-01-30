using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ConsoleApplication1;

namespace ConsoleApplication1
{
    //комплексные числа
    struct Complex
    {
        double re;
        double im;
        public Complex(double r, double i)
        {
            while(true)
                try
                {
                    if (r == double.MinValue & i == double.MinValue)
                    {
                        Console.Write("r="); re = double.Parse(Console.ReadLine());
                        Console.Write("i="); im = double.Parse(Console.ReadLine());
                    }
                    else
                    {
                        re = r; im = i;
                    }
                    break;
                }
                catch (Exception exc) { Console.WriteLine(exc.Message); } 
        }
        //Вывод комплексного числа
        public void Display()
        {
            Console.Write(re + ", " + im+"\r\n");
        }

        //Перегрузка операторов > < == для комплексных чисел
        public static bool operator >(Complex a, Complex b)
        {
            if (a.re > b.re & a.im > b.im)
                return true;
            else return false;
        }

        public static bool operator <(Complex a, Complex b)
        {
            if (a.re < b.re & a.im < b.im)
                return true;
            else return false;
        }

        public static bool operator ==(Complex a, Complex b)
        {
            if (a.re == b.re & a.im == b.im)
                return true;
            else return false;
        }

        public static bool operator !=(Complex a, Complex b)
        {
            if (a.re != b.re & a.im != b.im)
                return true;
            else return false;
        }

        //Перегрузка операторов + - для комплексных чисел
        public static Complex operator +(Complex a, Complex b)
        {
            Complex res = new Complex(0.0, 0.0);
            res.re = a.re + b.re; res.im = a.im + b.im;
            return res;
        }

        public static Complex operator -(Complex a, Complex b)
        {
            Complex res = new Complex(0.0, 0.0);
            res.re = a.re - b.re; res.im = a.im - b.im;
            return res;
        }
        //Перегрузка операторов / *
        public static Complex operator /(Complex a, Complex b)
        {
            Complex res = new Complex(0.0, 0.0);
            res.re = a.re / b.re; res.im = a.im / b.im;
            return res;
        }

        public static Complex operator *(Complex a, Complex b)
        {
            Complex res = new Complex(0.0, 0.0);
            res.re = a.re * b.re; res.im = a.im * b.im;
            return res;
        }
    }


    //Класс описываюший вектор
    class vector<Ta>
    {
        public Ta vec { get; set; }

        public static bool operator >(dynamic a, vector<Ta> b)
        {
            bool Result = false;
            if (a.vec > b.vec)
                Result = true;

            return Result;
        }

        public static bool operator <(dynamic a, vector<Ta> b)
        {
            bool Result = false;
            if (a.vec < b.vec)
                Result = true;

            return Result;
        }

        public static bool operator ==(dynamic a, vector<Ta> b)
        {
            bool Result = false;
            if (a.vec == b.vec)
                Result = true;

            return Result;
        }

        public static bool operator !=(dynamic a, vector<Ta> b)
        {
            bool Result = false;
            if (a.vec != b.vec)
                Result = true;

            return Result;
        }

    }
}
