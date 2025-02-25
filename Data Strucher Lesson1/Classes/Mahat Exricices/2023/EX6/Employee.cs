using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2023.EX6
{
    public class Employee
    {
        public string name { get; set; }
        public static int id = 1;
        public int publicID { get; }

        public Employee(string name)
        {
            this.name = name;
            this.publicID = id++;
        }

        public override string ToString()
        {
            return $"name: {this.name}, id: {this.publicID}";
        }
    }
}
