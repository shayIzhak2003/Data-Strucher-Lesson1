using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.Lesson7
{
    public class BuildRandomList
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
    }
    public class RunBuildRandomList
    {
      public static void DemoMain()
        {
            int size = 10; 
            int from = 10;  
            int to = 100; 

            BinNode<int> root = BuildRandomList.GetBiList(size, from, to);
            Console.WriteLine("Generated binary tree:");
            PrinList(root);

        }
        public static void PrinList(BinNode<int>lst)
        {
            BinNode<int> pos = lst;
            while (pos != null)
            {
                Console.WriteLine(pos);
                pos = pos.GetRight();
            }
            Console.WriteLine();
        }

   


    }
}
