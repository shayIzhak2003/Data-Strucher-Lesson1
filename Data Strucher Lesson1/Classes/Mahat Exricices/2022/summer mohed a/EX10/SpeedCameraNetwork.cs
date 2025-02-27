using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Mahat_Exricices._2022.summer_mohed_a.EX10
{
    public class SpeedCameraNetwork
    {
        private Stack<SpeedCamera> cameras; // Stack of speed cameras

        public SpeedCameraNetwork()
        {
            cameras = new Stack<SpeedCamera>();
        }

        public void AddSpeedCamera(SpeedCamera sc)
        {
            cameras.Push(sc);
        }

        public int CountExtremeViolations()
        {
            int count = 0;
            Stack<SpeedCamera> temp = new Stack<SpeedCamera>();

            while (!this.cameras.IsEmpty())
            {
                SpeedCamera currentSc = cameras.Pop();
                temp.Push(currentSc);

                if (currentSc.GetVauletionsNum() > 200)
                {
                    count++;
                }
            }
            while (!temp.IsEmpty())
                this.cameras.Push(temp.Pop());

            return count;
        }

        public bool CheckCarNumForViolations(int carNum)
        {
            Stack<SpeedCamera> temp = new Stack<SpeedCamera>();
            bool flag = false;
            while (!this.cameras.IsEmpty())
            {
                SpeedCamera currentSc = cameras.Pop();
                while(!currentSc.GetViolationsStack().IsEmpty())
                {
                    int currentValue = currentSc.GetViolationsStack().Pop();
                    if (carNum == currentValue)
                    {
                        Console.WriteLine(currentSc.GetCameraID());
                        flag = true;
                    }
                }
                temp.Push(currentSc);
            }
            while (!temp.IsEmpty())
                this.cameras.Push(temp.Pop());

            return flag;
        }
    }
}
