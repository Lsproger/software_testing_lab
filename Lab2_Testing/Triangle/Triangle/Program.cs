using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    class Program
    {
        public static bool IsTriangleExist(double a, double b, double c)
        {
            double[] sides = new double[] { a, b, c };
            foreach (double s in sides)
            {
                if (s <= 0)
                    return false;
                
            }

            for (int i = 0; i < 3; i++)
            {
                if (sides[i] + sides[(i + 1) % 3] < sides[(i + 2) % 3])
                    return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(IsTriangleExist(0, 0, 0).ToString());
            Console.WriteLine("------------------------------------");
            Object o = new Object();
            o = "xxx";
            Double val = (Double)o;
            Console.WriteLine(val.GetType().ToString());
        }




    }
}
