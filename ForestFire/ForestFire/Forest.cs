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

        public Forest(int row, int col)
        {
            ForestDisplayer = new char[row, col];
            ForestTreeStatus = new Tree[row, col];
            GenerateForest();
        }

        public void InitTimer(int interval)
        {
            System.Timers.Timer timer = new System.Timers.Timer(interval);
            timer.AutoReset = true; // the key is here so it repeats
            timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimeEvent);
            timer.Start();
        }

        private void OnTimeEvent(object obj, ElapsedEventArgs e)
        {
            PrintForest();
        }

        public void Main(int interval)
        {

        }

        public void CreateTree(Tree tree)
        {
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
            Console.WriteLine("---------------------------------------------");
        }

        public void BurnTree(int row, int col)
        {
            ForestTreeStatus[row, col].BurnTree();
            ForestDisplayer[row, col] = 'X';
            ForestTreeStatus[row, col].ChangeTreeStatus();
        }

        public void KillTree(int row, int col)
        {
            ForestTreeStatus[row, col].TreeStatus = TreeStatus.Dead;
            ForestDisplayer[row, col] = '.';
        }

        public void CreateConnections(int chance)
        {
            for (int i = 0; i < ForestDisplayer.GetLength(0); i++)
            {
                for (int j = 0; j < ForestDisplayer.GetLength(1); j++)
                {
                    if(IsConnectionCreated(chance))
                    {
                        if(i!= 0 && i!= ForestDisplayer.GetLength(0) && j!= 0 && j!= ForestDisplayer.GetLength(1))
                        {
                            ForestTreeStatus[i, j].RelateToTree(ForestTreeStatus[i, j - 1]);
                            ForestTreeStatus[i, j].RelateToTree(ForestTreeStatus[i, j + 1]);
                            ForestTreeStatus[i, j].RelateToTree(ForestTreeStatus[i - 1, j]);
                            ForestTreeStatus[i, j].RelateToTree(ForestTreeStatus[i + 1, j]);
                        }
                        else if(i == 0 && j!=0 && j!= ForestDisplayer.GetLength(1))
                        {
                            ForestTreeStatus[i, j].RelateToTree(ForestTreeStatus[i, j - 1]);
                            ForestTreeStatus[i, j].RelateToTree(ForestTreeStatus[i, j + 1]);
                            ForestTreeStatus[i, j].RelateToTree(ForestTreeStatus[i + 1, j]);
                        }
                        else if(i!=0 && i!=ForestDisplayer.GetLength(0) && j==0 && j!=ForestDisplayer.GetLength(1))
                        {
                            ForestTreeStatus[i, j].RelateToTree(ForestTreeStatus[i, j + 1]);
                            ForestTreeStatus[i, j].RelateToTree(ForestTreeStatus[i - 1, j]);
                            ForestTreeStatus[i, j].RelateToTree(ForestTreeStatus[i + 1, j]);
                        }
                        else if(i!=0 && i!=ForestDisplayer.GetLength(0) && j!=0 && j== ForestDisplayer.GetLength(1))
                        {
                            ForestTreeStatus[i, j].RelateToTree(ForestTreeStatus[i, j - 1]);
                            ForestTreeStatus[i, j].RelateToTree(ForestTreeStatus[i - 1, j]);
                            ForestTreeStatus[i, j].RelateToTree(ForestTreeStatus[i + 1, j]);
                        }
                        else if(i!=0 && i==ForestDisplayer.GetLength(0) && j!=0 && j!=ForestDisplayer.GetLength(1))
                        {
                            ForestTreeStatus[i, j].RelateToTree(ForestTreeStatus[i, j - 1]);
                            ForestTreeStatus[i, j].RelateToTree(ForestTreeStatus[i, j + 1]);
                            ForestTreeStatus[i, j].RelateToTree(ForestTreeStatus[i - 1, j]);
                        }
                        else if(i == 0 && j == 0)
                        {
                            ForestTreeStatus[i, j].RelateToTree(ForestTreeStatus[i, j + 1]);
                            ForestTreeStatus[i, j].RelateToTree(ForestTreeStatus[i + 1, j]);
                        }
                        else if(i == ForestDisplayer.GetLength(0) && j == ForestDisplayer.GetLength(1))
                        {
                            ForestTreeStatus[i, j].RelateToTree(ForestTreeStatus[i, j - 1]);
                            ForestTreeStatus[i, j].RelateToTree(ForestTreeStatus[i - 1, j]);
                        }
                        else if(i == 0 && j == ForestDisplayer.GetLength(1))
                        {
                            ForestTreeStatus[i, j].RelateToTree(ForestTreeStatus[i, j - 1]);
                            ForestTreeStatus[i, j].RelateToTree(ForestTreeStatus[i + 1, j]);
                        }
                        else
                        {
                            ForestTreeStatus[i, j].RelateToTree(ForestTreeStatus[i, j + 1]);
                            ForestTreeStatus[i, j].RelateToTree(ForestTreeStatus[i - 1, j]);
                        }
                    }
                }
            }
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
