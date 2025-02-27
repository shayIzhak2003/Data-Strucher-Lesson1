using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2022.summer_mohed_a.EX9
{
    public class RealEstateSystem
    {
        private Stack<Appartment> apartmentStack; // Use Stack instead of List

        public RealEstateSystem()
        {
            this.apartmentStack = new Stack<Appartment>();
        }

        // **Add an apartment**
        public void AddApartmentToDB(Appartment apartment)
        {
            apartmentStack.Push(apartment);
            Console.WriteLine("Apartment added successfully!");
        }

        // **Remove the last added apartment**
        public void RemoveApartment()
        {
            if (!apartmentStack.IsEmpty())
            {
                Appartment removed = apartmentStack.Pop();
                Console.WriteLine($"Removed Apartment: {removed}");
            }
            else
            {
                Console.WriteLine("No apartments to remove.");
            }
        }

        // **View the last added apartment**
        public void ViewLastApartment()
        {
            if (!apartmentStack.IsEmpty())
            {
                Console.WriteLine($"Last Apartment: {apartmentStack.Top()}");
            }
            else
            {
                Console.WriteLine("No apartments available.");
            }
        }

        // **Get total cost of all apartments**
        public int GetTotalPurchaseCost()
        {
            int totalCost = 0;
            Stack<Appartment> tempStack = new Stack<Appartment>();

            while (!apartmentStack.IsEmpty())
            {
                Appartment apt = apartmentStack.Pop();
                totalCost += apt.GetPrice();
                tempStack.Push(apt);
            }

            // Restore stack order
            while (!tempStack.IsEmpty())
            {
                apartmentStack.Push(tempStack.Pop());
            }

            return totalCost;
        }

        // **Check if the purchase is possible within a budget**
        public bool CanPurchase(int budget)
        {
            return budget >= GetTotalPurchaseCost();
        }

        // **Display all apartments**
        public void DisplayAll()
        {
            Console.WriteLine("All Apartments: " + apartmentStack.ToString());
        }
    }
}
