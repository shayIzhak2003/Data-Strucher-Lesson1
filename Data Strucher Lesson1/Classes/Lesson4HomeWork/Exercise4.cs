using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Lesson4HomeWork
{
    public class Exercise4
    {
        // Method to create and return a new list containing values from lst1 whose squares exist in lst2
        public Node<int> listSqr(Node<int> lst1, Node<int> lst2)
        {
            Node<int> dummyHead = new Node<int>(0); // Dummy head node for the result list
            Node<int> current = dummyHead;

            while (lst1 != null)
            {
                int value = lst1.GetValue();
                int squareValue = value * value;

                if (isContained(squareValue, lst2))
                {
                    current.SetNext(new Node<int>(value));
                    current = current.GetNext();
                }

                lst1 = lst1.GetNext();
            }

            return dummyHead.GetNext(); // Return the head of the resulting list (lst3)
        }

        // Helper method to check if a value exists in lst2
        private bool isContained(int value, Node<int> lst2)
        {
            while (lst2 != null)
            {
                if (lst2.GetValue() == value)
                {
                    return true;
                }
                lst2 = lst2.GetNext();
            }
            return false;
        }

        // Method to print a linked list
        public void PrintList(Node<int> head)
        {
            Node<int> current = head;
            while (current != null)
            {
                Console.Write(current.GetValue() + " ");
                current = current.GetNext();
            }
            Console.WriteLine();
        }
    }

    public class RunExercise4
    {
        public static void DemoMain()
        {
            Exercise4 exercise = new Exercise4();

            // Example lists initialization
            Node<int> lst1 = new Node<int>(1);
            lst1.SetNext(new Node<int>(2));
            lst1.GetNext().SetNext(new Node<int>(3));
            lst1.GetNext().GetNext().SetNext(new Node<int>(4));

            Node<int> lst2 = new Node<int>(1);
            lst2.SetNext(new Node<int>(4));
            lst2.GetNext().SetNext(new Node<int>(9));
            lst2.GetNext().GetNext().SetNext(new Node<int>(16));

            // Call listSqr method and print the result
            Node<int> lst3 = exercise.listSqr(lst1, lst2);
            Console.Write("Result List: ");
            exercise.PrintList(lst3);
        }
    }
}
