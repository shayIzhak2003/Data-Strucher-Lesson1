using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2023.EX6
{
    public class Tutor : Employee
    {
        public int num {  get; set; }
        public int courseNum { get; set; }

        public Tutor(string name, int courseNum): base(name)
        {
            this.courseNum = courseNum;
        }

        public override string ToString()
        {
            return base.ToString() + $"num: {this.num}, courseNum: {this.courseNum}";
        }
    }
}
