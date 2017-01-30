using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {

        static void Main()
        {
            System.Threading.Thread.CurrentThread.Name = "leznovskiu 612 pst.";
            calc<float, float, float> x = new calc<float, float, float>();
            x.menu();
            Console.ReadKey(true);
        }
    }
}
