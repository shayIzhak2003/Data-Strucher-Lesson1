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

        // Constructor to create a circular linked list from an array of values
        public Game(int[] values)
        {
            if (values.Length < 2)
                throw new ArgumentException("Path must have at least two cells.");

            head = new Node<int>(values[0]);
            Node<int> current = head;
            for (int i = 1; i < values.Length; i++)
            {
                current.SetNext(new Node<int>(values[i]));
                current = current.GetNext();
            }
            current.SetNext(head); // Close the loop to make it circular
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

                Console.WriteLine($"Landed on cell with value: {current.GetValue()}");

                // Check if landed on a 0
                if (current.GetValue() == 0)
                {
                    current = current.GetNext(); // Move one step back
                    Console.WriteLine("Landed on 0, moving back 1 step.");
                }

                // Check if the player wins
                if (current.GetNext() == head)
                {
                    Console.WriteLine("Congratulations! You landed exactly on the last cell.");
                    return true;
                }

                // Print current state
                Console.WriteLine($"Current cell: {current.GetValue()}");
            }
        }
    }

    public class RunGame
    {
        public static void DemoMain()
        {
            // Define the game path values
            int[] pathValues = { 1, 3, 5, 0, 2, 4, 0, 6 };

            // Create the game instance
            Game game = new Game(pathValues);

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
        }
    }
}
