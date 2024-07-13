using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Lesson6
{

    public class Game
    {
        private Node<int> head;
        private Random random = new Random();
        private Node<int> landedHead = null;
        private Node<int> landedTail = null;

        // Constructor to create a circular linked list
        public Game()
        {
            // Create nodes manually to form a circular path
            Node<int> node1 = new Node<int>(1); // First node (not 0)
            Node<int> node2 = new Node<int>(3, node1);
            Node<int> node3 = new Node<int>(5, node2);
            Node<int> node4 = new Node<int>(0, node3);
            Node<int> node5 = new Node<int>(2, node4);
            Node<int> node6 = new Node<int>(4, node5);
            Node<int> node7 = new Node<int>(0, node6);
            Node<int> node8 = new Node<int>(6, node7); // Last node (not 0)

            // Close the loop to make it circular
            node1.SetNext(node8);

            head = node1; // Set the head of the list
        }

        // Roll two dice and return the sum
        private int RollDice()
        {
            int dice1 = random.Next(1, 7);
            int dice2 = random.Next(1, 7);
            int sum = dice1 + dice2;
            Console.WriteLine($"Dice rolled: {dice1} + {dice2} = {sum}");
            return sum;
        }

        // Add value to landed list
        private void AddLandedValue(int value)
        {
            Node<int> newNode = new Node<int>(value);
            if (landedHead == null)
            {
                landedHead = newNode;
                landedTail = newNode;
            }
            else
            {
                landedTail.SetNext(newNode);
                landedTail = newNode;
            }
        }

        // Print the entire circular list
        private void PrintCircularList(Node<int> current)
        {
            Node<int> node = head;
            Console.Write("Circular list: ");
            do
            {
                if (node == current)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(node.GetValue() + " ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(node.GetValue() + " ");
                }
                node = node.GetNext();
            } while (node != head);
            Console.WriteLine();
        }

        // Play the game and return true if the player wins
        public bool Play()
        {
            Node<int> current = head;
            while (true)
            {
                // Print the current state of the circular list
                PrintCircularList(current);

                int diceSum = RollDice();

                // Move forward by diceSum steps
                for (int i = 0; i < diceSum; i++)
                {
                    current = current.GetNext();
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Landed on cell with value: {current.GetValue()}");
                Console.ResetColor();

                AddLandedValue(current.GetValue());

                // Check if landed on a 0
                if (current.GetValue() == 0)
                {
                    // Move one step backward
                    Node<int> previous = head;
                    while (previous.GetNext() != current)
                    {
                        previous = previous.GetNext();
                    }
                    current = previous;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Landed on 0, moving backward 1 step.");
                    Console.ResetColor();

                    // Print the current state of the circular list again
                    PrintCircularList(current);
                }

                // Check if the player wins
                if (current.GetNext() == head)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Congratulations! You landed exactly on the last cell.");
                    Console.ResetColor();
                    return true;
                }

                // Print current state
                Console.WriteLine($"Current cell: {current.GetValue()}");
            }
        }

        // Print all the values landed on
        public void PrintLandedValues()
        {
            Console.WriteLine("Values landed on during the game:");
            Node<int> current = landedHead;
            while (current != null)
            {
                Console.Write(current.GetValue() + " ");
                current = current.GetNext();
            }
            Console.WriteLine();
        }
    }

    public class RunGame
    {
        public static void DemoMain()
        {
            // Create the game instance
            Game game = new Game();

            // Play the game
            bool won = game.Play();

            // Print result
            if (won)
            {
                Console.WriteLine("You have won the game!");
            }
            else
            {
                Console.WriteLine("You lost the game!");
            }

            // Print all landed values
            game.PrintLandedValues();
        }
    }
}



