using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ForestFire
{
    public class Forest
    {
        public char[,] ForestDisplayer;
        public Tree[,] ForestTreeStatus;
        private int _chance;

        public Forest(int row, int col, int chance, int health)
        {
            ForestDisplayer = new char[row, col];
            ForestTreeStatus = new Tree[row, col];
            GenerateForest(health);
            _chance = chance;
        }

        public void Main(int interval)
        {
            while(true)
            {
                PrintForest();
                RunForestFlow();
                
                Thread.Sleep(interval);
            }
        }

        public void PrintForest()
        {
            for (int i = 0; i < ForestTreeStatus.GetLength(0); i++)
            {
                for (int j = 0; j < ForestTreeStatus.GetLength(1); j++)
                {
                    Console.Write((char)ForestTreeStatus[i, j].TreeStatus + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("---------------------------------------------");
        }

        public void BurnTree(int row, int col)
        {
            ForestTreeStatus[row, col].BurnTree();
        }

        public void KillTree(int row, int col)
        {
            ForestTreeStatus[row, col].KillTree();
        }

        public void CreateConnections()
        {
            for (int i = 0; i < ForestDisplayer.GetLength(0); i++)
            {
                for (int j = 0; j < ForestDisplayer.GetLength(1); j++)
                {
                    if(IsConnectionCreated(_chance))
                    {
                        if (i != 0)
                            ForestTreeStatus[i-1, j].RelateToTree(ForestTreeStatus[i, j]);
                        if (i != ForestDisplayer.GetLength(0) - 1)
                            ForestTreeStatus[i + 1, j].RelateToTree(ForestTreeStatus[i, j]);
                        if (j != 0)
                            ForestTreeStatus[i, j - 1].RelateToTree(ForestTreeStatus[i, j]);
                        if (j != ForestDisplayer.GetLength(1) - 1)
                            ForestTreeStatus[i, j + 1].RelateToTree(ForestTreeStatus[i, j]);
                    }
                }
            }
        }
        public void RunForestFlow()
        {
            for (int i = 0; i < ForestDisplayer.GetLength(0); i++)
            {
                for (int j = 0; j < ForestDisplayer.GetLength(1); j++)
                {
                   ForestTreeStatus[i,j].TreeLifeCycle();
                }
            }
            for (int i = 0; i < ForestDisplayer.GetLength(0); i++)
            {
                for (int j = 0; j < ForestDisplayer.GetLength(1); j++)
                {
                    ForestTreeStatus[i, j].UpdateTreeStatus();
                }
            }
        }

        private void GenerateForest(int health)
        {
            Random random = new Random();
            for (int i = 0; i < ForestDisplayer.GetLength(0); i++)
            {
                for (int j = 0; j < ForestDisplayer.GetLength(1); j++)
                {
                    ForestDisplayer[i, j] = 'O';
                    ForestTreeStatus[i, j] = new Tree(health, TreeStatus.Healthy);
                }
            }
        }

        private bool IsConnectionCreated(int chance)
        {
            Random rnd = new Random();
            int randomValueBetween0And99 = rnd.Next(100);
            if (randomValueBetween0And99 < chance)
            {
                return true;
            }
            return false;
        }
    }
}
