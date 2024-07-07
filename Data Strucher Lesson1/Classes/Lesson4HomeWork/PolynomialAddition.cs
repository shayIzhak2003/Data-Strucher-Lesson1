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
        // מקדם
        public int Coefficient { get; set; }
        // מעריך
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
        // Adds two polynomials represented as linked lists of Node<Term> objects and returns the resulting polynomial as a linked list
        public Node<Term> AddPolynomials(Node<Term> poly1, Node<Term> poly2)
        {
            Node<Term> resultHead = null;
            Node<Term> resultTail = null;

            // Add terms from both polynomials
            while (poly1 != null || poly2 != null)
            {
                int exponent;
                int coefficient = 0;

                if (poly1 != null && (poly2 == null || poly1.GetValue().Exponent >= poly2.GetValue().Exponent))
                {
                    exponent = poly1.GetValue().Exponent;
                    coefficient += poly1.GetValue().Coefficient;
                    poly1 = poly1.GetNext();
                }
                else
                {
                    exponent = poly2.GetValue().Exponent;
                    coefficient += poly2.GetValue().Coefficient;
                    poly2 = poly2.GetNext();
                }

                if (poly1 != null && poly2 != null && poly1.GetValue().Exponent == poly2.GetValue().Exponent)
                {
                    coefficient += poly2.GetValue().Coefficient;
                    poly2 = poly2.GetNext();
                }

                if (coefficient != 0)
                {
                    Term newTerm = new Term(coefficient, exponent);
                    Node<Term> newNode = new Node<Term>(newTerm);
                    if (resultHead == null)
                    {
                        resultHead = newNode;
                        resultTail = newNode;
                    }
                    else
                    {
                        resultTail.SetNext(newNode);
                        resultTail = newNode;
                    }
                }
            }

            return resultHead;
        }

        // Helper function to print a polynomial
        public void PrintPolynomial(Node<Term> polynomial)
        {
            bool first = true;
            while (polynomial != null)
            {
                if (!first)
                {
                    Console.Write(" + ");
                }
                Console.Write(polynomial.GetValue());
                polynomial = polynomial.GetNext();
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
            Node<Term> polynomial1 = new Node<Term>(new Term(1, 5));
            polynomial1.SetNext(new Node<Term>(new Term(5, 3)));
            polynomial1.GetNext().SetNext(new Node<Term>(new Term(-16, 0)));

            // Second polynomial: 2*x^4 + 6*x^3 + 24*x^1
            Node<Term> polynomial2 = new Node<Term>(new Term(2, 4));
            polynomial2.SetNext(new Node<Term>(new Term(6, 3)));
            polynomial2.GetNext().SetNext(new Node<Term>(new Term(24, 1)));

            // Create an instance of PolynomialAddition
            PolynomialAddition polyAddition = new PolynomialAddition();

            // Print both polynomials
            Console.Write("Polynomial 1: ");
            polyAddition.PrintPolynomial(polynomial1);

            Console.Write("Polynomial 2: ");
            polyAddition.PrintPolynomial(polynomial2);

            // Add the polynomials using the instance method
            Node<Term> result = polyAddition.AddPolynomials(polynomial1, polynomial2);

            // Print the resulting polynomial
            Console.Write("Sum Polynomial: ");
            polyAddition.PrintPolynomial(result);
        }
    }
}
