 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2022.summer_mohed_a.EX5
{
    public class RunClownApp
    {
        public static void DemoMain()
        {
            Pyramid pyramid = new Pyramid();

            // Creating some clowns
            Clown c1 = new Clown("Bozo", 50);
            Clown c2 = new Clown("Jester", 40);
            Clown c3 = new Clown("Chuckles", 30);
            

            // Adding clowns to the pyramid
            Console.WriteLine($"Adding {c1.GetName()} (Weight: {c1.GetWeight()}): {pyramid.AddClown(c1)}");
            Console.WriteLine($"Adding {c2.GetName()} (Weight: {c2.GetWeight()}): {pyramid.AddClown(c2)}");
            Console.WriteLine($"Adding {c3.GetName()} (Weight: {c3.GetWeight()}): {pyramid.AddClown(c3)}");


            // Check if the pyramid is stable
            Console.WriteLine($"Is the pyramid stable? {pyramid.IsStable()}");
        }
    }
}
