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
        public int Coefficient { get; set; }
        public int Exponent { get; set; }

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
            foreach (var term in polynomial1)
            {
                if (term.Exponent > maxExponent)
                    maxExponent = term.Exponent;
            }
            foreach (var term in polynomial2)
            {
                if (term.Exponent > maxExponent)
                    maxExponent = term.Exponent;
            }

            Term[] result = new Term[maxExponent + 1]; // Resulting polynomial array

            // Initialize the result array with zero coefficients
            for (int i = 0; i <= maxExponent; i++)
            {
                result[i] = new Term(0, i);
            }

            // Add coefficients from polynomial1
            foreach (var term in polynomial1)
            {
                result[term.Exponent].Coefficient += term.Coefficient;
            }

            // Add coefficients from polynomial2
            foreach (var term in polynomial2)
            {
                result[term.Exponent].Coefficient += term.Coefficient;
            }

            // Print the resulting polynomial
            Console.Write("Sum Polynomial: ");
            for (int i = maxExponent; i >= 0; i--)
            {
                if (result[i].Coefficient != 0)
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
