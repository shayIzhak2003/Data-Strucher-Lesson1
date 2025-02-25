using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2023.EX6
{
    public class Lecturer : Employee
    {
        public string specialization { get; set; }

        public Lecturer(string name, string specialization) : base(name)
        {
            this.specialization = specialization;
        }

        public override string ToString()
        {
            return base.ToString() + $"specialization: {this.specialization}";
        }
    }
}
