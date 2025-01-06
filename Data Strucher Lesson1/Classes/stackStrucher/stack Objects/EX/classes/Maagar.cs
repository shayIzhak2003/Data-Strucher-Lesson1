using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.stackStrucher.stack_Objects.EX.classes
{
    public class Maagar
    {
        // Constants
        const int MAX_APARTMENTS_NUM = 200;

        // Fields
        private House[] houseArr = new House[MAX_APARTMENTS_NUM];
        private int currentApartmentsCount;

        // Constructor
        public Maagar()
        {
            currentApartmentsCount = 0;
        }

        // Getter for houseArr
        public House[] GetHouseArr()
        {
            return houseArr;
        }

        // Setter for houseArr
        public void SetHouseArr(House[] houses)
        {
            if (houses.Length > MAX_APARTMENTS_NUM)
            {
                throw new ArgumentException($"Cannot have more than {MAX_APARTMENTS_NUM} apartments.");
            }
            houseArr = houses;
            currentApartmentsCount = houses.Length;
        }

        // Getter for currentApartmentsCount
        public int GetCurrentApartmentsCount()
        {
            return currentApartmentsCount;
        }

        // Setter for currentApartmentsCount
        public void SetCurrentApartmentsCount(int count)
        {
            if (count < 0 || count > MAX_APARTMENTS_NUM)
            {
                throw new ArgumentException($"Apartment count must be between 0 and {MAX_APARTMENTS_NUM}.");
            }
            currentApartmentsCount = count;
        }

        // Add a House to the Maagar
        public void AddHouse(House house)
        {
            if (currentApartmentsCount >= MAX_APARTMENTS_NUM)
            {
                throw new InvalidOperationException("Cannot add more houses. Maximum capacity reached.");
            }

            houseArr[currentApartmentsCount] = house;
            currentApartmentsCount++;
        }

        // Remove a House from the Maagar by index
        public void RemoveHouse(int index)
        {
            if (index < 0 || index >= currentApartmentsCount)
            {
                throw new ArgumentException("Invalid index for house removal.");
            }

            for (int i = index; i < currentApartmentsCount - 1; i++)
            {
                houseArr[i] = houseArr[i + 1];
            }

            houseArr[currentApartmentsCount - 1] = null;
            currentApartmentsCount--;
        }

        // Check if a house is for rent by address
        public bool CheckIfForRent(string address)
        {
            for (int i = 0; i < currentApartmentsCount; i++)
            {
                if (houseArr[i] != null && houseArr[i].address == address && houseArr[i].isForRent)
                {
                    return true;
                }
            }
            return false;
        }

        // Get count of 5+ room apartments available for rent
        public int GetFiveRoomsApartmentForRent()
        {
            int count5RoomsForRent = 0;
            for (int i = 0; i <=currentApartmentsCount; i++)
            {
                if (houseArr[i] != null && CheckIfForRent(houseArr[i].address) && houseArr[i].roomsCount >= 5)
                {
                    count5RoomsForRent++;
                }
            }
            return count5RoomsForRent;
        }

        // Display all Houses
        public void DisplayHouses()
        {
            Console.WriteLine("List of Houses in Maagar:");
            for (int i = 0; i < currentApartmentsCount; i++)
            {
                Console.WriteLine(houseArr[i]?.ToString());
            }
        }
    }

    public class RunMaagar
    {
        public static void DemoMain()
        {
            // Create an instance of Maagar
            Maagar maagar = new Maagar();

            // Add some houses
            maagar.AddHouse(new House(5, 70, "123 Main St", true));
            maagar.AddHouse(new House(5, 40, "456 Elm St", false));
            maagar.AddHouse(new House(4, 80, "789 Oak St", true));

            // Display all houses
            Console.WriteLine("All houses in Maagar:");
            maagar.DisplayHouses();

            // Check if a specific address is for rent
            string addressToCheck = "123 Main St";
            bool isForRent = maagar.CheckIfForRent(addressToCheck);
            Console.WriteLine($"\nIs the house at '{addressToCheck}' for rent? {isForRent}");

            // Get count of 5+ room apartments available for rent
            int countFiveRoomForRent = maagar.GetFiveRoomsApartmentForRent();
            Console.WriteLine($"\nNumber of apartments with 5+ rooms available for rent: {countFiveRoomForRent}");

            // Remove a house and display updated list
            maagar.RemoveHouse(1);
            Console.WriteLine("\nAfter removing the second house:");
            maagar.DisplayHouses();

            Console.ReadLine();
        }
    }
}
