using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StraightMovement
{
    public class FunctionManager
    {
        public static double sin(double arg, int n)
        {
            double result = 0;
            for (int i = 1; i <= n; i++)
            {
                int multiplier = i % 2 == 0 ? -1 : 1;
                double term = multiplier * Math.Pow(arg, 2 * i - 1) / fact(2 * i - 1);
                result += term;
            }
            return result;
        }
        public static double cos(double arg, int n)
        {
            double result = 0;
            for(int i = 1; i <= n; i++)
            {
                int multiplier = i % 2 == 0 ? -1 : 1;
                double term = multiplier * Math.Pow(arg, 2 * i - 2) / fact(2 * i - 2);
                result += term;
            }
            return result;
        }
        public static double atan(double arg, int n)
        {
            if(Math.Abs(arg) > 1)
            {
                return Math.PI / 2 - atan(1 / arg, n);
            }

            double result = 0;
            for (int i = 1; i <= n; i++)
            {
                int multiplier = i % 2 == 0 ? -1 : 1;
                double term = multiplier * Math.Pow(arg, 2 * i - 1) / (2 * i - 1);
                result += term;
            }
            return result;
        }
        private static int fact(int arg)
        {
            if (arg == 0) return 1;
            return arg * fact(arg - 1);
        }
    }
}
