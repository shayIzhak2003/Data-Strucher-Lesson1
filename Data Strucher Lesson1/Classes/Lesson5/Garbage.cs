using Data_Strucher_Lesson1.Classes.Lesson5;
using Data_Strucher_Lesson1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Lesson5
{
    public class Garbage
    {
        private string num;
        private double capacity;
        private double quantity;
        private string neighbor;

        // get functions
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

        public Garbage(string num, double capacity, double quantity, string neighbor)
        {
            this.num = num;
            this.capacity = capacity;
            this.quantity = quantity;
            this.neighbor = neighbor;
        }
        public static Node<Garbage> GetGarbageToEmpty(Node<Garbage> garbages)
        {
            Node<Garbage> garbagesToEmptyHead = null;
            Node<Garbage> garbagesToEmptyTail = null;

            Node<Garbage> current = garbages;
            while (current != null)
            {
                Garbage garbage = current.GetValue();

                // Check if the garbage needs to be emptied (at least 80% full)
                if (garbage.GetQuantity() >= 0.8 * garbage.GetQuantity())
                {
                    Node<Garbage> newNode = new Node<Garbage>(garbage);

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

                current = current.GetNext();
            }

            return garbagesToEmptyHead;
        }
        public static Node<Garbage> GetGarbageByNeighborhood(Node<Garbage> garbages, string neighborhood)
        {
            Node<Garbage> garbagesInNeighborhoodHead = null;
            Node<Garbage> garbagesInNeighborhoodTail = null;

            Node<Garbage> current = garbages;

            while (current != null)
            {
                Garbage garbage = current.GetValue();
                if (garbage.GetNeighbor() == neighborhood)
                {
                    Node<Garbage> newNode = new Node<Garbage>(garbage);
                    if (garbagesInNeighborhoodHead == null)
                    {
                        garbagesInNeighborhoodHead = newNode;
                        garbagesInNeighborhoodTail = newNode;
                    }
                    else
                    {
                        garbagesInNeighborhoodHead.SetNext(newNode);
                        garbagesInNeighborhoodHead = newNode;
                    }
                }
                current = current.GetNext();
            }
            return garbagesInNeighborhoodTail;
        }
        public static Node<Garbage> GetMaxCapacity(Node<Garbage> garbages)
        {
            Node<Garbage> garbagesWithSmallCapHead = null;
            Node<Garbage> garbagesWithSmallCapTail = null;

            Node<Garbage> current = garbages;

            while (current != null)
            {
                Garbage garbage = current.GetValue();
                if (garbage.GetCapacity() < 1000)
                {
                    Node<Garbage> newNode = new Node<Garbage>(garbage);
                    if (garbagesWithSmallCapHead == null)
                    {
                        garbagesWithSmallCapHead = newNode;
                        garbagesWithSmallCapTail = newNode;
                    }
                    else
                    {
                        garbagesWithSmallCapHead.SetNext(newNode);
                        garbagesWithSmallCapHead = newNode;
                    }
                }
                current = current.GetNext();
            }
            return garbagesWithSmallCapTail;
        }
        public static string GetMaxGarbageNeighborhood(Node<Garbage> garbages)
        {
            string maxNeighborhood = "";
            int maxCount = 0;

            Node<Garbage> current = garbages;

            while (current != null)
            {
                Garbage currentGarbage = current.GetValue();
                string currentNeighborhood = currentGarbage.GetNeighbor();

                // Get all garbage bins in the current neighborhood
                Node<Garbage> binsInCurrentNeighborhood = GetGarbageByNeighborhood(garbages, currentNeighborhood);

                // Count the number of bins in the current neighborhood
                int currentCount = CountNodes(binsInCurrentNeighborhood);

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

        // Helper function to count nodes in a linked list
        private static int CountNodes(Node<Garbage> head)
        {
            int count = 0;
            Node<Garbage> current = head;
            while (current != null)
            {
                count++;
                current = current.GetNext();
            }
            return count;
        }
    }

}
public class RunGarbage
{
    public static void DemoMain()
    {
        // Step 1: Create a linked list of Garbage bins
        Node<Garbage> garbages = new Node<Garbage>(new Garbage("001", 1001.0, 80.0, "NeighborhoodA"));
        garbages.SetNext(new Node<Garbage>(new Garbage("002", 150.0, 120.0, "NeighborhoodB")));
        garbages.GetNext().SetNext(new Node<Garbage>(new Garbage("003", 120.0, 100.0, "NeighborhoodB")));
        garbages.GetNext().GetNext().SetNext(new Node<Garbage>(new Garbage("004", 180.0, 50.0, "NeighborhoodC")));
        garbages.GetNext().GetNext().GetNext().SetNext(new Node<Garbage>(new Garbage("005", 200.0, 180.0, "NeighborhoodB")));

        // Step 2: Get and print garbage bins to empty (80% full or more)
        Node<Garbage> garbagesToEmpty = Garbage.GetGarbageToEmpty(garbages);
        Console.WriteLine("Garbage bins to empty:");
        PrintGarbageList(garbagesToEmpty);

        // Step 3: Get and print garbage bins by neighborhood (e.g., "NeighborhoodA")
        string targetNeighborhood = "NeighborhoodA";
        Node<Garbage> garbagesInNeighborhood = Garbage.GetGarbageByNeighborhood(garbages, targetNeighborhood);
        Console.WriteLine($"\nGarbage bins in {targetNeighborhood}:");
        PrintGarbageList(garbagesInNeighborhood);

        // Step 4: Get and print the garbage bins that has a capacity less than 1000KG
        Node<Garbage> garbagesWithSmallCap = Garbage.GetMaxCapacity(garbages);
        Console.WriteLine("\nGarbage bins with less than 1000KG capacity:");
        PrintGarbageList(garbagesWithSmallCap);

        // Step 5: Get the neighborhood with the most garbage bins
        string maxNeighborhood = Garbage.GetMaxGarbageNeighborhood(garbages);
        Console.WriteLine($"\nThe neighborhood with the most garbage bins: {maxNeighborhood}");
    }
    // the PrintGarbageList function!
    private static void PrintGarbageList(Node<Garbage> head)
    {
        Node<Garbage> current = head;
        while (current != null)
        {
            Garbage garbage = current.GetValue();
            Console.WriteLine($"Num: {garbage.GetNum()}, Capacity: {garbage.GetCapacity()} kg, Quantity: {garbage.GetQuantity()} kg, Neighbor: {garbage.GetNeighbor()}");
            current = current.GetNext();
        }
    }

}

