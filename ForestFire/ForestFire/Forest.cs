using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ForestFire
{
    public class Forest
    {
        public char[,] ForestDisplayer;
        public Tree[,] ForestTreeStatus;

        public Forest(int row, int col)
        {
            ForestDisplayer = new char[row, col];
            ForestTreeStatus = new Tree[row, col];
            GenerateForest();
        }

        public Tree CreateTree(int health, TreeStatus status, Tree relatedTo = null)
        {
            Tree tree = new Tree(health, status, relatedTo);
            for (int i = 0; i < ForestDisplayer.GetLength(0); i++)
            {
                for (int j = 0; j < ForestDisplayer.GetLength(1); j++)
                {
                    if(ForestTreeStatus[i, j] == null)
                    {
                        ForestTreeStatus[i, j] = tree;
                    }
                }
            }
            return tree;
        }


        private void GenerateForest()
        {
            for (int i = 0; i < ForestDisplayer.GetLength(0); i++)
            {
                for (int j = 0; j < ForestDisplayer.GetLength(1); j++)
                {
                    ForestDisplayer[i, j] = 'O';
                }
            }
        }

        public void PrintForest()
        {
            for (int i = 0; i < ForestDisplayer.GetLength(0); i++)
            {
                for (int j = 0; j < ForestDisplayer.GetLength(1); j++)
                {
                    Console.Write(ForestDisplayer[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void BurnTree(int row, int col)
        {
            ForestTreeStatus[row, col].BurnTree();
            ForestDisplayer[row, col] = 'X';
        }

        public void KillTree(int row, int col)
        {
            ForestTreeStatus[row, col].TreeStatus = TreeStatus.Dead;
            ForestDisplayer[row, col] = '.';
        }

    }
}
