using System;
using System.Collections.Generic;
using System.Linq;
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
        public bool CheckIfForRent(string address)
        {

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
}
