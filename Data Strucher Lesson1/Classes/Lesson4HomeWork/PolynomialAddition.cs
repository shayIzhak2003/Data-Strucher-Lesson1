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
            // Determine the length of the resulting array
            int resultLength = Math.Max(polynomial1.Length, polynomial2.Length);
            Term[] result = new Term[resultLength];

            int i = 0, j = 0, k = 0;

            // Merge the terms from both polynomials
            while (i < polynomial1.Length && j < polynomial2.Length)
            {
                if (polynomial1[i].Exponent > polynomial2[j].Exponent)
                {
                    result[k++] = new Term(polynomial1[i].Coefficient, polynomial1[i].Exponent);
                    i++;
                }
                else if (polynomial1[i].Exponent < polynomial2[j].Exponent)
                {
                    result[k++] = new Term(polynomial2[j].Coefficient, polynomial2[j].Exponent);
                    j++;
                }
                else
                {
                    // Same exponent, add coefficients
                    int sum = polynomial1[i].Coefficient + polynomial2[j].Coefficient;
                    if (sum != 0)
                    {
                        result[k++] = new Term(sum, polynomial1[i].Exponent);
                    }
                    i++;
                    j++;
                }
            }

            // Append remaining terms from either polynomial
            while (i < polynomial1.Length)
            {
                result[k++] = new Term(polynomial1[i].Coefficient, polynomial1[i].Exponent);
                i++;
            }

            while (j < polynomial2.Length)
            {
                result[k++] = new Term(polynomial2[j].Coefficient, polynomial2[j].Exponent);
                j++;
            }

            // Print the resulting polynomial
            Console.Write("Sum Polynomial: ");
            for (int m = 0; m < k; m++)
            {
                Console.Write(result[m]);
                if (m < k - 1)
                {
                    Console.Write(" + ");
                }
            }
            Console.WriteLine();
        }

        // Example usage

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
