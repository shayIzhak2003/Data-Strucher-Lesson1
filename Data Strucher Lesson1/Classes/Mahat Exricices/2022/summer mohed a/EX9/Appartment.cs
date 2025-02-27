using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2022.summer_mohed_a.EX9
{
    public class Appartment
    {
        protected string owner;
        protected int floor;
        protected int numApp;
        protected int area;

        protected const int COST_APP = 1000;
        protected const int COST_TERRACE = 300;
        protected const int COST_GARDEN = 50;

        public Appartment(int floor, int numApp, int area)
        {
            this.owner = "FREE";
            this.floor = floor;
            this.numApp = numApp;
            this.area = area;
        }

        public void SetOwner(string name)
        {
            this.owner = name;
        }

        public virtual int GetPrice()
        {
            return area * COST_APP;
        }

        public override string ToString()
        {
            return $"Owner: {owner}, Floor: {floor}, NumApp: {numApp}, Area: {area}, Price: {GetPrice()}";
        }
    }

}
