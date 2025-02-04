using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2024.mohed_B.EX11
{
    public class DriversData
    {
        private Stack<Driver> driversStack;

        public DriversData()
        {
            this.driversStack = new Stack<Driver>();
        }

        // add driver function 
        public void AddDriver(Driver driver)
        {
            driversStack.Push(driver);
        }

        // remove driver function
        public void RemoveDriverById(string driverId)
        {
            Stack<Driver> temp = new Stack<Driver>();
            while (!driversStack.IsEmpty())
            {
                Driver driver = driversStack.Pop();
                if(driver.GetId() != driverId)
                {
                    temp.Push(driver);
                }
            }
            while (!temp.IsEmpty())
            {
                driversStack.Push(temp.Pop());
            }
        }

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
    }
}
