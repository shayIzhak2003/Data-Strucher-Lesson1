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
        private List<int> landedValues = new List<int>();

        // Constructor to create a circular linked list
        public Game()
        {
            // Create nodes manually to form a circular path
            Node<int> node1 = new Node<int>(1);
            Node<int> node2 = new Node<int>(3, node1);
            Node<int> node3 = new Node<int>(5, node2);
            Node<int> node4 = new Node<int>(0, node3);
            Node<int> node5 = new Node<int>(2, node4);
            Node<int> node6 = new Node<int>(4, node5);
            Node<int> node7 = new Node<int>(0, node6);
            Node<int> node8 = new Node<int>(6, node7);

            // Close the loop to make it circular
            node1.SetNext(node8);

            head = node1; // Set the head of the list
        }

        // Roll two dice and return the sum
        private int RollDice()
        {
            return random.Next(1, 7) + random.Next(1, 7);
        }

        // Play the game and return true if the player wins
        public bool Play()
        {
            Node<int> current = head;
            while (true)
            {
                int diceSum = RollDice();
                Console.WriteLine($"Rolled: {diceSum}");

                // Move forward by diceSum steps
                for (int i = 0; i < diceSum; i++)
                {
                    current = current.GetNext();
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Landed on cell with value: {current.GetValue()}");
                Console.ResetColor();

                landedValues.Add(current.GetValue());

                // Check if landed on a 0
                if (current.GetValue() == 0)
                {
                    current = current.GetNext(); // Move one step back
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Landed on 0, moving forward 1 step.");
                    Console.ResetColor();
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
            foreach (var value in landedValues)
            {
                Console.Write(value + " ");
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


