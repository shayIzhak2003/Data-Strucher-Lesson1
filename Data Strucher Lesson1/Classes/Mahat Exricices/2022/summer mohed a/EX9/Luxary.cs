using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2022.summer_mohed_a.EX9
{
    class Luxary : Penthouse
    {
        public Luxary(int floor, int numApp, int area, int numTerr, int terraceArea, bool seaView)
            : base(floor, numApp, area, numTerr, terraceArea, seaView) { }

        public override string ToString()
        {
            return "Luxury Apartment: " + base.ToString();
        }
    }
}
