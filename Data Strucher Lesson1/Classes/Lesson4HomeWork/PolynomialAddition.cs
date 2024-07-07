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
    // Represents a term in the polynomial
    public class Term
    {
        public int Coefficient { get; set; }
        public int Exponent { get; set; }
        public Term Next { get; set; }  // Reference to the next term

        public Term(int coefficient, int exponent)
        {
            Coefficient = coefficient;
            Exponent = exponent;
            Next = null;
        }

        public override string ToString()
        {
            return $"{Coefficient}x^{Exponent}";
        }
    }

    public class PolynomialAddition
    {
        // Adds two polynomials represented as linked lists of Term objects and prints the resulting polynomial
        public void AddPolynomials(Term poly1, Term poly2)
        {
            Term resultHead = null;
            Term resultTail = null;

            // Add terms from both polynomials
            while (poly1 != null || poly2 != null)
            {
                int exponent;
                int coefficient = 0;

                if (poly1 != null && (poly2 == null || poly1.Exponent >= poly2.Exponent))
                {
                    exponent = poly1.Exponent;
                    coefficient += poly1.Coefficient;
                    poly1 = poly1.Next;
                }
                else
                {
                    exponent = poly2.Exponent;
                    coefficient += poly2.Coefficient;
                    poly2 = poly2.Next;
                }

                if (poly1 != null && poly2 != null && poly1.Exponent == poly2.Exponent)
                {
                    coefficient += poly2.Coefficient;
                    poly2 = poly2.Next;
                }

                if (coefficient != 0)
                {
                    Term newTerm = new Term(coefficient, exponent);
                    if (resultHead == null)
                    {
                        resultHead = newTerm;
                        resultTail = newTerm;
                    }
                    else
                    {
                        resultTail.Next = newTerm;
                        resultTail = newTerm;
                    }
                }
            }

            // Print the resulting polynomial
            Console.Write("Sum Polynomial: ");
            PrintPolynomial(resultHead);
        }

        // Helper function to print a polynomial
        public void PrintPolynomial(Term polynomial)
        {
            bool first = true;
            while (polynomial != null)
            {
                if (!first)
                {
                    Console.Write(" + ");
                }
                Console.Write(polynomial);
                polynomial = polynomial.Next;
                first = false;
            }
            Console.WriteLine();
        }
    }

    public class RunApp
    {
        public static void DemoMain()
        {
            // First polynomial: 1*x^5 + 5*x^3 + -16*x^0
            Term polynomial1 = new Term(1, 5);
            polynomial1.Next = new Term(5, 3);
            polynomial1.Next.Next = new Term(-16, 0);

            // Second polynomial: 2*x^4 + 6*x^3 + 24*x^1
            Term polynomial2 = new Term(2, 4);
            polynomial2.Next = new Term(6, 3);
            polynomial2.Next.Next = new Term(24, 1);

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
