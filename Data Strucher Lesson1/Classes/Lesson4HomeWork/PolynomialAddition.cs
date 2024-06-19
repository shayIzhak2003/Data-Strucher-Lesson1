using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data_Strucher_Lesson1.Classes.Lesson4HomeWork.PolynomialAddition;

namespace Data_Strucher_Lesson1.Classes.Lesson4HomeWork
{
    //EX1
    // Represents a term in the polynomial
    // Represents a term in the polynomial
    public class Term
    {
        private int Coefficient;
        private int Exponent;

        public int GetCoefficient()
        {
            return this.Coefficient;
        }
        public int GetExponent()
        {
           return this.Exponent;
        }
        public void SetCoefficient(int coefficient)
        {
            this.Coefficient = coefficient;
        }
        public Term(int coefficient, int exponent)
        {
            Coefficient = coefficient;
            Exponent = exponent;
        }

        public override string ToString()
        {
            return $"{Coefficient}x^{Exponent}";
        }
    }

    public class PolynomialAddition
    {
        // Adds two polynomials represented as arrays of Term objects and prints the resulting polynomial
        public void AddPolynomials(Term[] polynomial1, Term[] polynomial2)
        {
            // Find the maximum exponent to determine the length of the result array
            int maxExponent = 0;
    
            for (int i = 0; i < polynomial1.Length; i++)
            {
                if (polynomial1[i].GetExponent() > maxExponent)
                    maxExponent = polynomial1[i].GetExponent();
            }
            for (int i = 0; i < polynomial2.Length; i++)
            {
                if (polynomial2[i].GetExponent() > maxExponent)
                    maxExponent = polynomial2[i].GetExponent();
            }
          

            Term[] result = new Term[maxExponent + 1]; // Resulting polynomial array

            // Initialize the result array with zero coefficients
            for (int i = 0; i <= maxExponent; i++)
            {
                result[i] = new Term(0, i);
            }

            // Add coefficients from polynomial1
            for (int i = 0; i < polynomial1.Length; i++)
            {
                int exponent = polynomial1[i].GetExponent();
                result[exponent].SetCoefficient(
                    result[exponent].GetCoefficient() + polynomial1[i].GetCoefficient()
                );
            }

            // Add coefficients from polynomial2
            for (int i = 0; i < polynomial2.Length; i++)
            {
                int exponent = polynomial2[i].GetExponent();
                result[exponent].SetCoefficient(
                    result[exponent].GetCoefficient() + polynomial2[i].GetCoefficient()
                );
            }

            // Print the resulting polynomial
            Console.Write("Sum Polynomial: ");
            for (int i = maxExponent; i >= 0; i--)
            {
                if (result[i].GetCoefficient() != 0)
                {
                    Console.Write(result[i]);
                    if (i > 0)
                    {
                        Console.Write(" + ");
                    }
                }
            }
            Console.WriteLine();
        }

        // Helper function to print a polynomial
        public void PrintPolynomial(Term[] polynomial)
        {
            for (int i = 0; i < polynomial.Length; i++)
            {
                Console.Write(polynomial[i]);
                if (i < polynomial.Length - 1)
                {
                    Console.Write(" + ");
                }
            }
            Console.WriteLine();
        }
    }

    public class RunApp
    {
        public static void DemoMain()
        {
            // First polynomial: 1*x^5 + 5*x^3 + -16*x^0
            Term[] polynomial1 = {
                new Term(1, 5),
                new Term(5, 3),
                new Term(-16, 0)
            };

            // Second polynomial: 2*x^4 + 6*x^3 + 24*x^1
            Term[] polynomial2 = {
                new Term(2, 4),
                new Term(6, 3),
                new Term(24, 1)
            };

            // Create an instance of PolynomialAddition
            PolynomialAddition polyAddition = new PolynomialAddition();

            // Print both polynomials
            Console.Write("Polynomial 1: ");
            polyAddition.PrintPolynomial(polynomial1);

            Console.Write("Polynomial 2: ");
            polyAddition.PrintPolynomial(polynomial2);

            // Add the polynomials using the instance method
            polyAddition.AddPolynomials(polynomial1, polynomial2);
        }
    }
}
