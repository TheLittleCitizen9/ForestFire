using System;

namespace ForestFire
{
    class Program
    {
        static void Main(string[] args)
        {
            Forest forest = new Forest(4, 4);
            Tree tree1 = new Tree(3, TreeStatus.Healthy);
            Tree tree2 = new Tree(3, TreeStatus.Healthy);
            forest.CreateTree(tree1);
            forest.CreateTree(tree2);
            
            forest.BurnTree(0, 0);
            forest.KillTree(0, 1);
            forest.PrintForest();
            forest.InitTimer(2000);
        }
    }
}
