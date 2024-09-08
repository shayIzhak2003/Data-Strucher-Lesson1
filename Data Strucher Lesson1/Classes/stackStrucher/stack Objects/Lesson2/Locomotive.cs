using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.stackStrucher.stack_Objects.Lesson2
{
    public class Locomotive
    {
        private int locomotiveNumber;
        private int yearOfManufacture;

        public Locomotive(int locomotiveNumber, int yearOfManufacture)
        {
            this.locomotiveNumber = locomotiveNumber;
            this.yearOfManufacture = yearOfManufacture;
        }

        public int GetLocomotiveNumber()
        {
            return locomotiveNumber;
        }

        public void SetLocomotiveNumber(int locomotiveNumber)
        {
            this.locomotiveNumber = locomotiveNumber;
        }

        public int GetYearOfManufacture()
        {
            return yearOfManufacture;
        }

        public void SetYearOfManufacture(int yearOfManufacture)
        {
            this.yearOfManufacture = yearOfManufacture;
        }

        public override string ToString()
        {
            return $"Locomotive {locomotiveNumber}, Year: {yearOfManufacture}";
        }
    }

}
