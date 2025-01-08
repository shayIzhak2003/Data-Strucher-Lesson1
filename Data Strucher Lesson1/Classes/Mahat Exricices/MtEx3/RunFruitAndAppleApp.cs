using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices.MtEx3
{
    public class RunFruitAndAppleApp
    {
        public static void CountObjects(Object[] objects)
        {
            int fruitCount = 0;
            int appleCount = 0;
            int otherCount = 0;

            foreach (Object obj in objects)
            {
                if (obj is Apple) // בדיקה ראשונית עבור Apple
                {
                    appleCount++;

                }
                else if (obj is Fruit) // לאחר מכן בודקים עבור Fruit
                {
                    fruitCount++;
                }
                else // אחרת זה אובייקט אחר
                {
                    otherCount++;
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Apple Objects Count: => {appleCount}");
            Console.WriteLine($"Fruit Objects Count: => {fruitCount}");
            Console.WriteLine($"Other Objects Count: => {otherCount}");
            Console.ResetColor();
        }

        // demo main function
        public static void DemoMain()
        {
            // object array type
            Object[] objects = new Object[]
               {
                new Apple(100, "Red"),
                new Fruit(120),
                new Apple(85, "Green"),
                "Random String",
                42
               };


            CountObjects(objects);
        }
    }
}
