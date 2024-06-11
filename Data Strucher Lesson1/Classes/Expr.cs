using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes
{
    public class Expr
    {
        private int num1;
        private int num2;
        private char op;

        public Expr(int num1, int num2, char op)
        {
            if (num1 <= 0 || num2 <= 0)
            {
                // Set the text color to red
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Numbers must be greater than 0");

                // Reset the color to default
                Console.ResetColor();
            }
                

            if (op != '+' && op != '-' && op != '*' && op != '/')
                throw new ArgumentException("Invalid operator");

            this.num1 = num1;
            this.num2 = num2;
            this.op = op;
        }

        public int GetNum1()
        {
            return num1;
        }

        public int GetNum2()
        {
            return num2;
        }

        public char GetOp()
        {
            return op;
        }

        public override string ToString()
        {
            return $"{num1} {op} {num2}";
        }

        public double Calculate()
        {
            if (op == '+')
                return num1 + num2;
            else if (op == '-')
                return num1 - num2;
            else if (op == '*')
                return num1 * num2;
            else if (op == '/')
                return (double)num1 / num2;
            else
                throw new InvalidOperationException("Invalid operator");
        }

        public static double SumExpressions(List<Expr> expressions)
        {
            double sum = 0;

            for (int i = 0; i < expressions.Count; i++)
            {
                sum += expressions[i].Calculate();
            }

            return sum;
        }
    }
}
