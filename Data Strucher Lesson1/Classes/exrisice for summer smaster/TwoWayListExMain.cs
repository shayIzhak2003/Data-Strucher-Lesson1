using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.exrisice_for_summer_smaster
{

    public class TwoWayListExMain
    {
        public static BinNode<int> GetBiList(int size, int from, int to)
        {
            if (size <= 0)
                throw new ArgumentException("Size must be a positive number.", nameof(size));
            if (from >= to)
                throw new ArgumentException("From must be less than to.", nameof(from));

            Random rnd = new Random();
            int rootValue = rnd.Next(from, to);
            BinNode<int> root = new BinNode<int>(rootValue);
            BinNode<int> pos = root;

            for (int i = 1; i < size; i++)
            {
                int newValue = rnd.Next(from, to);
                pos.SetRight(new BinNode<int>(pos, newValue, null));
                pos = pos.GetRight();
            }

            return root;
        }
        public static void PrintBinNodeList(BinNode<int> lst)
        {
            Console.Write("[");
            BinNode<int> pos = lst;

            while (pos != null)
            {
                Console.Write(pos.GetValue());
                if (pos.HasRight())
                    Console.Write(", ");

                pos = pos.GetRight();
            }
            Console.Write("]");
        }
    }
    public class RunTwoWayListExMain
    {
        public static void DemoMain()
        {
            int from = 1;
            int to = 30;
            int size = 10;

            BinNode<int> list =  TwoWayListExMain.GetBiList(size, from, to);
            TwoWayListExMain.PrintBinNodeList(list);


        }
    }
}
