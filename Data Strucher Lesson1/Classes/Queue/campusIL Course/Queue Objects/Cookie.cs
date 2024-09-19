using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Queue.campusIL_Course.Queue_Objects
{
    public class Cookie
    {
        private string name; // שם העוגיה
        private bool chocolateCrackers; // האם יש פצפוצי שוקולד

        // Constructor - קונסטרוקטור
        public Cookie(string name, bool chocolateCrackers)
        {
            this.name = name;
            this.chocolateCrackers = chocolateCrackers;
        }

        // Getter for name - פונקציית GET לשם
        public string GetName()
        {
            return name;
        }

        // Setter for name - פונקציית SET לשם
        public void SetName(string name)
        {
            this.name = name;
        }

        // Getter for chocolateCrackers - פונקציית GET לפצפוצי שוקולד
        public bool GetChocolateCrackers()
        {
            return chocolateCrackers;
        }

        // Setter for chocolateCrackers - פונקציית SET לפצפוצי שוקולד
        public void SetChocolateCrackers(bool chocolateCrackers)
        {
            this.chocolateCrackers = chocolateCrackers;
        }
        public class CookieFunctions
        {
            public static Queue<Cookie> PackingCookies(Queue<Cookie> qu1, Queue<Cookie> qu2)
            {
                // green means woth chocheclet and red means without chocheclet
                Queue<Cookie> merged = new Queue<Cookie>();
                Queue<Cookie> tmp1 = Chep1.CloneQueue(qu1);
                Queue<Cookie> tmp2 = Chep1.CloneQueue(qu2);

                while (!tmp1.IsEmpty())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Cookie value = tmp1.Remove();
                    merged.Insert(value);
                    Console.ResetColor();
                }

                while (!tmp2.IsEmpty())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Cookie value = tmp2.Remove();
                    merged.Insert(value);
                    Console.ResetColor();
                }

                return merged;
            }
        }
        public class CocckieRunClass
        {
            public static void RunCocckie()
            {
                // Queue for cookies with chocolate
                Queue<Cookie> chocolateQueue = new Queue<Cookie>();

                // Creating Cookie objects with chocolate and inserting them into the chocolateQueue
                Cookie cookie1 = new Cookie("Chocolate Chip", true);
                Cookie cookie2 = new Cookie("Oatmeal Raisin", true);
                Cookie cookie3 = new Cookie("Peanut Butter", true);
                Cookie cookie4 = new Cookie("Sugar Cookie", true);

                chocolateQueue.Insert(cookie1);
                chocolateQueue.Insert(cookie2);
                chocolateQueue.Insert(cookie3);
                chocolateQueue.Insert(cookie4);

                // Queue for cookies without chocolate
                Queue<Cookie> nonChocolateQueue = new Queue<Cookie>();

                // Creating Cookie objects without chocolate and inserting them into the nonChocolateQueue
                Cookie cookie5 = new Cookie("Double Chocolate", false);
                Cookie cookie6 = new Cookie("Snickerdoodle", false);
                Cookie cookie7 = new Cookie("Macadamia Nut", false);
                Cookie cookie8 = new Cookie("Gingerbread", false);

                nonChocolateQueue.Insert(cookie5);
                nonChocolateQueue.Insert(cookie6);
                nonChocolateQueue.Insert(cookie7);
                nonChocolateQueue.Insert(cookie8);

                // Merging the two queues using the PackingCookies method
                Queue<Cookie> mergedQueue = Cookie.CookieFunctions.PackingCookies(chocolateQueue, nonChocolateQueue);

                // Displaying the details of each cookie in the merged queue
                Console.WriteLine("Merged Queue:");
                while (!mergedQueue.IsEmpty())
                {
                    Cookie currentCookie = mergedQueue.Remove();
                    Console.WriteLine("Cookie: " + currentCookie.GetName() + ", Chocolate Crackers: " + currentCookie.GetChocolateCrackers());
                }
            }
        }

    }

}
