using Data_Strucher_Lesson1.Classes.Lesson5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.extrecices_for_test
{
    public class ItemObject
    {
        private int from;
        private int to;

        public int GetFrom()
        {
            return this.from;
        }
        public int GetTo()
        {
            return this.to;
        }
        public ItemObject(int from, int to)
        {
            this.from = from;
            this.to = to;
        }

        public override string ToString()
        {
            return $"({this.from}, {this.to})";
        }
    }
    public class GarbageObject
    {
        private string num;
        private double capacity;
        private double quantity;
        private string neighbor;

        // Get functions
        public string GetNum()
        {
            return this.num;
        }
        public double GetCapacity()
        {
            return this.capacity;
        }
        public double GetQuantity()
        {
            return this.quantity;
        }
        public string GetNeighbor()
        {
            return this.neighbor;
        }

        public GarbageObject(string num, double capacity, double quantity, string neighbor)
        {
            this.num = num;
            this.capacity = capacity;
            this.quantity = quantity;
            this.neighbor = neighbor;
        }

        public static Node<GarbageObject> FindFullGarbageCans(Node<GarbageObject> lst)
        {
            Node<GarbageObject> garbagesToEmptyHead = null;
            Node<GarbageObject> garbagesToEmptyTail = null;

            Node<GarbageObject> pos = lst;
            while (pos != null)
            {
                GarbageObject garbage = pos.GetValue();
                // Check if the garbage needs to be emptied (at least 80% full)
                if (garbage.GetQuantity() >= 0.8 * garbage.GetCapacity())
                {
                    Node<GarbageObject> newNode = new Node<GarbageObject>(garbage);
                    if (garbagesToEmptyHead == null)
                    {
                        garbagesToEmptyHead = newNode;
                        garbagesToEmptyTail = newNode;
                    }
                    else
                    {
                        garbagesToEmptyTail.SetNext(newNode);
                        garbagesToEmptyTail = newNode;
                    }
                }
                pos = pos.GetNext();
            }
            return garbagesToEmptyHead;
        }

        public static Node<GarbageObject> FindLessThenThaosendCapacity(Node<GarbageObject> lst)
        {
            Node<GarbageObject> garbagesToEmptyHead = null;
            Node<GarbageObject> garbagesToEmptyTail = null;

            Node<GarbageObject> pos = lst;
            while (pos != null)
            {
                GarbageObject garbage = pos.GetValue();
                // Check if the garbage needs to be emptied (at least 80% full)
                if (garbage.GetCapacity() < 1000)
                {
                    Node<GarbageObject> newNode = new Node<GarbageObject>(garbage);
                    if (garbagesToEmptyHead == null)
                    {
                        garbagesToEmptyHead = newNode;
                        garbagesToEmptyTail = newNode;
                    }
                    else
                    {
                        garbagesToEmptyTail.SetNext(newNode);
                        garbagesToEmptyTail = newNode;
                    }
                }
                pos = pos.GetNext();
            }
            return garbagesToEmptyHead;
        }

        public static Node<GarbageObject> PrintCansInNigborhood(Node<GarbageObject> lst, string nigborhoodName)
        {
            Node<GarbageObject> garbagesToEmptyHead = null;
            Node<GarbageObject> garbagesToEmptyTail = null;
            Node<GarbageObject> pos = lst;
            while (pos != null)
            {
                if (pos.GetValue().GetNeighbor() == nigborhoodName)
                {
                    GarbageObject currentGarbegeCan = pos.GetValue();
                    Node<GarbageObject> newNode = new Node<GarbageObject>(currentGarbegeCan);

                    if (garbagesToEmptyHead == null)
                    {
                        garbagesToEmptyHead = newNode;
                        garbagesToEmptyTail = newNode;
                    }
                    else
                    {
                        garbagesToEmptyHead.SetNext(newNode);
                        garbagesToEmptyTail = newNode;
                    }
                }
                pos = pos.GetNext();
            }
            return garbagesToEmptyHead;
        }

        public static string GetMaxNigborhood(Node<GarbageObject> lst)
        {
            string maxNeighborhood = "";
            int maxCount = 0;

            Node<GarbageObject> current = lst;

            while (current != null)
            {
                GarbageObject currentGarbage = current.GetValue();
                string currentNeighborhood = currentGarbage.GetNeighbor();

                // Get all garbage bins in the current neighborhood
                Node<GarbageObject> binsInCurrentNeighborhood = PrintCansInNigborhood(lst, currentNeighborhood);

                // Count the number of bins in the current neighborhood
                int currentCount = CountNodesInList(binsInCurrentNeighborhood);

                // Determine if the current neighborhood has more bins than the max
                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    maxNeighborhood = currentNeighborhood;
                }
                // If counts are equal, prioritize the first encountered neighborhood
                else if (currentCount == maxCount && maxNeighborhood == "")
                {
                    maxNeighborhood = currentNeighborhood;
                }

                current = current.GetNext();
            }

            return maxNeighborhood;
        }
        private static int CountNodesInList(Node<GarbageObject> lst)
        {
            int count = 0;
            Node<GarbageObject> pos = lst;
            while (pos != null)
            {
                count++;
                pos = pos.GetNext();
            }
            return count;
        }
    }
    public class ListsAndObjectsEx
    {
        public void FindOddDays(bool[] rainfallArray, Node<ItemObject> rainDaysList)
        {
            bool[] DaysOfRain = new bool[31];

            Node<ItemObject> pos = rainDaysList;

            while (pos != null)
            {
                ItemObject range = pos.GetValue();
                for (int i = range.GetFrom(); i < range.GetTo(); i++)
                {
                    if (i >= 1 && i <= 30)
                    {
                        DaysOfRain[i - 1] = true;
                    }
                }
                pos = pos.GetNext();
            }

            for (int i = 1; i <= 30; i++) // ימי 1 עד 30 (לא כולל 0)
            {
                bool expectedRain = rainfallArray[i]; // שימוש באינדקס מבוסס 1
                bool actualRain = DaysOfRain[i - 1]; // המרה לאינדקס מבוסס 0
                if (expectedRain != actualRain)
                {
                    Console.WriteLine($"Mismatch on day {i}");
                }
            }
        }


    }
    public class RunGarbageObjects
    {
        public static void DemoMain()
        {
            // Create a linked list of GarbageObject instances
            Node<GarbageObject> garbage1 = new Node<GarbageObject>(new GarbageObject("G001", 100.0, 50.5, "Neighbor A"));
            Node<GarbageObject> garbage2 = new Node<GarbageObject>(new GarbageObject("G002", 150.0, 120.3, "Neighbor C"));
            Node<GarbageObject> garbage3 = new Node<GarbageObject>(new GarbageObject("G003", 200.0, 75.0, "Neighbor A"));
            Node<GarbageObject> garbage4 = new Node<GarbageObject>(new GarbageObject("G004", 180.0, 180.0, "Neighbor C"));
            Node<GarbageObject> garbage5 = new Node<GarbageObject>(new GarbageObject("G005", 250.0, 220.0, "Neighbor C"));

            // Link the nodes to form a linked list
            garbage1.SetNext(garbage2);
            garbage2.SetNext(garbage3);
            garbage3.SetNext(garbage4);
            garbage4.SetNext(garbage5);

            // Find the full garbage cans
            Node<GarbageObject> fullGarbageCans = GarbageObject.FindFullGarbageCans(garbage1);

            // Print the full garbage cans
            Console.WriteLine("Full Garbage Cans:");
            PrintGarbageList(fullGarbageCans);
            Console.WriteLine();
            Node<GarbageObject> lessthen1000 = GarbageObject.FindLessThenThaosendCapacity(garbage1);
            Console.WriteLine("cans that thire capacity in less then a 1000kg :");
            PrintGarbageList(lessthen1000);
            Console.WriteLine();
            Node<GarbageObject> NigborToPicklUp = GarbageObject.PrintCansInNigborhood(garbage1, "Neighbor A");
            Console.WriteLine("Print all the Neighbor A Cans:");
            PrintGarbageList(NigborToPicklUp);

            Console.WriteLine();

            Console.WriteLine("all cans :");
            PrintGarbageList(garbage1);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("the max nigborhood is :");
            string name = GarbageObject.GetMaxNigborhood(garbage1);
            Console.WriteLine(name);
            Console.ResetColor();
        }

        private static void PrintGarbageList(Node<GarbageObject> head)
        {
            Node<GarbageObject> current = head;
            while (current != null)
            {
                GarbageObject garbage = current.GetValue();
                Console.WriteLine($"Num: {garbage.GetNum()}, Capacity: {garbage.GetCapacity()} kg, Quantity: {garbage.GetQuantity()} kg, Neighbor: {garbage.GetNeighbor()}");
                current = current.GetNext();
            }
        }
    }



    public class RunListsAndObjectsEx
    {
        public static void DemoMainForReal()
        {
            // יצירת מערך המייצג ימי גשם בחודש (האינדקס ה-0 אינו בשימוש, ימים מ-1 עד 30)
            bool[] rainfallArray = new bool[31];
            rainfallArray[1] = false;
            rainfallArray[2] = true;
            rainfallArray[3] = true;
            rainfallArray[4] = false;
            rainfallArray[5] = false;
            rainfallArray[6] = true;
            rainfallArray[7] = false;
            // הוספת עוד ערכים בהתאם לצורך

            // הוספת הדפסות לבדיקה
            Console.WriteLine("Rainfall Array: ");
            for (int i = 1; i <= 30; i++)
            {
                Console.WriteLine($"Day {i}: {(rainfallArray[i] ? "Rain" : "No Rain")}");
            }

            // יצירת רשימה מקושרת של DayRange
            Node<DayRange> head = new Node<DayRange>(new DayRange(2, 3));
            Node<DayRange> node2 = new Node<DayRange>(new DayRange(6, 6));
            head.SetNext(node2);

            // הוספת הדפסות לבדיקה
            Console.WriteLine("Day Ranges:");
            Node<DayRange> current = head;
            while (current != null)
            {
                Console.WriteLine(current.GetValue());
                current = current.GetNext();
            }

            // יצירת אובייקט של RainfallMismatch
            RainfallMismatch rainfallMismatch = new RainfallMismatch();

            // מציאת והדפסת ימי גשם לא תואמים
            rainfallMismatch.FindMismatchedDays(rainfallArray, head);
        }
    }
}
