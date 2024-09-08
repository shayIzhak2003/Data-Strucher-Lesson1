using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.stackStrucher.stack_Objects.Lesson2
{
    public class Ls2
    {
    }
    public class RunLs2
    {
        public static void DemoMain()
        {
            Locomotive locomotive = new Locomotive(1234, 2005);
            Train train = new Train(locomotive);

            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                int serialNumber = 100 + i;
                int passengers = random.Next(5, 51); 
                Carriage carriage = new Carriage(serialNumber, passengers);
                train.AttachCarriage(carriage);
            }

            Console.WriteLine("Original Train:");
            Console.WriteLine(train);

            Locomotive newLocomotive = new Locomotive(5678, 2015);
            Train newTrain = train.ReduceCarriages(newLocomotive);

            Console.WriteLine("Reduced Train:");
            Console.WriteLine(newTrain);
        }
    }
}
