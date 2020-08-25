using System;

namespace ForestFire
{
    class Program
    {
        static void Main(string[] args)
        {
            Forest forest = new Forest(4, 4, 100, 4);

            forest.CreateConnections();
            forest.BurnTree(1, 1);
            forest.Main(2000);
        }
    }
}
