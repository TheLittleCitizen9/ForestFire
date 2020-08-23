using System;

namespace ForestFire
{
    class Program
    {
        static void Main(string[] args)
        {
            Forest forest = new Forest(4, 4);
            forest.PrintForest();
            forest.CreateTree(3, TreeStatus.Healthy);
            forest.CreateTree(3, TreeStatus.Healthy);
            forest.BurnTree(0, 0);
            forest.KillTree(0, 1);
            forest.PrintForest();
        }
    }
}
