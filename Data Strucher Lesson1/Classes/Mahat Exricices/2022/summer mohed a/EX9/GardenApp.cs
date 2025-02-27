using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2022.summer_mohed_a.EX9
{
    class GardenApp : Appartment
    {
        private int gardenArea;

        public GardenApp(int floor, int numApp, int area, int gardenArea) : base(floor, numApp, area)
        {
            this.gardenArea = gardenArea;
        }

        public override int GetPrice()
        {
            return base.GetPrice() + (gardenArea * COST_GARDEN);
        }

        public override string ToString()
        {
            return base.ToString() + $", GardenArea: {gardenArea}";
        }
    }
}
