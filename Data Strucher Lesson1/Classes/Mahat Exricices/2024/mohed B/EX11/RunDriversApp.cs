using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2024.mohed_B.EX11
{
    public class RunDriversApp
    {
        public static void DemoMain()
        {
            // Create DriversData instance
            DriversData driversData = new DriversData();

            // Add some drivers
            driversData.AddDriver(new Driver("123456789", "Alice", "DL1001", "1990-05-12", 5, true));
            driversData.AddDriver(new Driver("987654321", "Bob", "DL1002", "1990-07-24", 8, true));
            driversData.AddDriver(new Driver("567890123", "Charlie", "DL1003", "1995-09-30", 2, true));
            driversData.AddDriver(new Driver("456789012", "David", "DL1004", "1995-03-15", 2, true));
            driversData.AddDriver(new Driver("345678901", "Eve", "DL1005", "2000-12-01", 0, true));

            Console.WriteLine("\n--- Drivers Added ---");
            driversData.PrintSuspendedDrivers(); // Initially, no drivers should be suspended.

            // Find max offenses for a specific age
            int age = 34; // Example: Check drivers aged 34
            int maxOffenses = driversData.GetMaxOffensesByAge(age);
            Console.WriteLine($"\nMax offenses for age {age}: {maxOffenses}");

            // Suspend drivers with highest offenses per age group
            driversData.SuspendDriversByMaxOffenses();

            // Display suspended drivers
            Console.WriteLine("\n--- Suspended Drivers ---");
            driversData.PrintSuspendedDrivers();
        }
    }
}
