using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.stackStrucher.stack_Objects.Lesson2
{
    public class Carriage
    {
        private static readonly int MaxPassengers = 50;
        private int serialNumber;
        private int numberOfPassengers;

        public Carriage(int serialNumber, int numberOfPassengers)
        {
            this.serialNumber = serialNumber;
            this.numberOfPassengers = Math.Min(numberOfPassengers, MaxPassengers); 
        }

        public int GetSerialNumber()
        {
            return serialNumber;
        }

        public void SetSerialNumber(int serialNumber)
        {
            this.serialNumber = serialNumber;
        }

        public int GetNumberOfPassengers()
        {
            return numberOfPassengers;
        }

        public void SetNumberOfPassengers(int numberOfPassengers)
        {
            this.numberOfPassengers = Math.Min(numberOfPassengers, MaxPassengers);
        }

        public static int GetMaxPassengers()
        {
            return MaxPassengers;
        }

        public override string ToString()
        {
            return $"Carriage {serialNumber}: {numberOfPassengers}/{MaxPassengers} passengers";
        }
    }

}
