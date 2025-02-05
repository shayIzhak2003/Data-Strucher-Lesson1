using System;

namespace Data_Strucher_Lesson1.Classes
{
    public class DriversData
    {
        private Stack<Driver> driversStack;

        public DriversData()
        {
            this.driversStack = new Stack<Driver>();
        }

        // **Add a driver to the system**
        public void AddDriver(Driver driver)
        {
            driversStack.Push(driver);
        }

        // **Remove a driver by their ID**
        public void RemoveDriverById(string driverId)
        {
            Stack<Driver> temp = new Stack<Driver>();

            while (!driversStack.IsEmpty())
            {
                Driver driver = driversStack.Pop();
                if (driver.GetId() != driverId)
                {
                    temp.Push(driver);
                }
            }

            while (!temp.IsEmpty())
            {
                driversStack.Push(temp.Pop());
            }
        }

        // **Get the highest number of offenses committed by an active driver of a specific age**
        public int GetMaxOffensesByAge(int age)
        {
            int maxOffenses = 0;
            Stack<Driver> temp = new Stack<Driver>();

            while (!driversStack.IsEmpty())
            {
                Driver driver = driversStack.Pop();
                if (driver.GetAge() == age && driver.IsActive() && driver.GetTrafficOffenses() > maxOffenses)
                {
                    maxOffenses = driver.GetTrafficOffenses();
                }
                temp.Push(driver);
            }

            while (!temp.IsEmpty())
            {
                driversStack.Push(temp.Pop());
            }

            return maxOffenses;
        }

        // **Suspend licenses for drivers with the highest offenses per age group**
        public void SuspendDriversByMaxOffenses()
        {
            Stack<Driver> temp = new Stack<Driver>();
            Stack<Driver> ageCheckStack = new Stack<Driver>();

            while (!driversStack.IsEmpty())
            {
                Driver driver = driversStack.Pop();
                int age = driver.GetAge();

                // Get the max offenses for this age
                int maxOffenses = GetMaxOffensesByAge(age);

                if (driver.IsActive() && driver.GetTrafficOffenses() == maxOffenses && maxOffenses > 0)
                {
                    driver.SetActive(false); // Suspend license
                }

                temp.Push(driver);
            }

            // Restore stack
            while (!temp.IsEmpty())
            {
                driversStack.Push(temp.Pop());
            }
        }

        // **Print all suspended drivers**
        public void PrintSuspendedDrivers()
        {
            Stack<Driver> temp = new Stack<Driver>();

            Console.WriteLine("Suspended Drivers:");
            while (!driversStack.IsEmpty())
            {
                Driver driver = driversStack.Pop();
                if (!driver.IsActive()) // If license is suspended
                {
                    Console.WriteLine(driver);
                }
                temp.Push(driver);
            }

            while (!temp.IsEmpty())
            {
                driversStack.Push(temp.Pop());
            }
        }
    }
}
