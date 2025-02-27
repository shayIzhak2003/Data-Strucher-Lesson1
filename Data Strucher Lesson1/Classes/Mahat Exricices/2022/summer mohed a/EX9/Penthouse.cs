using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2022.summer_mohed_a.EX9
{
    class Penthouse : Appartment
    {
        private int numTerr;
        private int terraceArea;
        private bool seaView;

        public Penthouse(int floor, int numApp, int area, int numTerr, int terraceArea, bool seaView)
            : base(floor, numApp, area)
        {
            this.numTerr = numTerr;
            this.terraceArea = terraceArea;
            this.seaView = seaView;
        }

        public override int GetPrice()
        {
            int price = base.GetPrice() + (terraceArea * COST_TERRACE);
            if (!seaView)
            {
                price = (int)(price * 0.95); // Reduce price by 5% if no sea view
            }
            return price;
        }

        public override string ToString()
        {
            return base.ToString() + $", NumTerr: {numTerr}, TerraceArea: {terraceArea}, SeaView: {seaView}";
        }
    }
}
