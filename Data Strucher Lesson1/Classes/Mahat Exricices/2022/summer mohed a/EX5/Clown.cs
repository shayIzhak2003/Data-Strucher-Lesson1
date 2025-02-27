using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2022.summer_mohed_a.EX5
{

    public class Clown
    {
        private string name;  // Clown's name
        private int weight;   // Clown's weight

        public Clown(string name, int weight)
        {
            this.name = name;
            this.weight = weight;
        }

        public int GetWeight()
        {
            return this.weight;
        }

        public string GetName()
        {
            return this.name;
        }
        public override string ToString()
        {
            return $"{name} ({weight} kg)";
        }
    }

}
