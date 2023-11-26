using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module12pr
{
    delegate double MathOperation(double x, double y);

    class Program
    {
        static double Add(double x, double y) => x + y;
        static double Subtract(double x, double y) => x - y;
        static double Multiply(double x, double y) => x * y;
        static double Divide(double x, double y) => y != 0 ? x / y : double.NaN;

        static double PerformOperation(double x, double y, MathOperation operation)
        {
            return operation(x, y);
        }

        static void Main()
        {
            MathOperation addDelegate = Add;
            MathOperation subtractDelegate = Subtract;
            MathOperation multiplyDelegate = Multiply;
            MathOperation divideDelegate = Divide;
            double resultAdd = PerformOperation(5, 3, addDelegate);
            Console.WriteLine($"5 + 3 = {resultAdd}");

            double resultMultiply = PerformOperation(5, 3, multiplyDelegate);
            Console.WriteLine($"5 * 3 = {resultMultiply}");
            MathOperation anonymousDelegate = delegate (double x, double y)
            {
                return x / (y + 1);
            };

            double resultAnonymous = PerformOperation(10, 2, anonymousDelegate);
            Console.WriteLine($"(10 / (2 + 1)) = {resultAnonymous}");
            MathOperation lambdaDelegate = (x, y) => x * y;

            double resultLambda = PerformOperation(4, 7, lambdaDelegate);
            Console.WriteLine($"4 * 7 = {resultLambda}");

            MathOperation chainDelegate = addDelegate + multiplyDelegate + lambdaDelegate;
            double resultChain = chainDelegate(2, 3);
            Console.WriteLine($"(2 + 3) * 3 = {resultChain}");
        }
    }

}
