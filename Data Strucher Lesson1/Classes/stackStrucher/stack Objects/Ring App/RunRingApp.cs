using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.stackStrucher.stack_Objects.Ring_App
{
    public class RunRingApp
    {
        public static void DemoMain()
        {
            // Create a Pole object
            Pole pole = new Pole();

            // Add rings to the pole
            pole.Add(new Ring("L", 1));
            pole.Add(new Ring("S", 2));
            pole.Add(new Ring("L", 3));
            pole.Add(new Ring("S", 4));

            // Display the pole's content before sorting
            Console.WriteLine("Pole before sorting:");
            PrintPole(pole);

            // Sort the rings on the pole
            pole.Sort();

            // Display the pole's content after sorting
            Console.WriteLine("Pole after sorting:");
            PrintPole(pole);
        }

        static void PrintPole(Pole pole)
        {
            // Since we can't directly access the stack, we'll use a temporary stack to display the contents
            Stack<Ring> tempStack = new Stack<Ring>();
            while (!pole.IsEmpty())
            {
                Ring ring = pole.Remove(null);  // Use a null value because the parameter is not necessary
                tempStack.Push(ring);
                Console.WriteLine($"Ring size: {ring.GetSize()}, color: {ring.GetColor()}");
            }

            // Restore the rings back to the original pole
            while (!tempStack.IsEmpty())
            {
                pole.Add(tempStack.Pop());
            }
        }
    }
}
