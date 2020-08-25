using System;
using System.Collections.Generic;
using System.Text;

namespace ForestFire
{
    public class Tree
    {
        public int Health { get; set; }
        public TreeStatus TreeStatus { get; set; }
        public event Action RelatedTrees;
        public TreeStatus NextTreeStatus { get; set; }

        public Tree(int health, TreeStatus status, Tree relatedTo = null)
        {
            Health = health;
            TreeStatus = status;
            NextTreeStatus = status;
        }

        public void RelateToTree(Tree relatedTree)
        {
            relatedTree.RelatedTrees += BurnTree;
        }

        public void ChangeTreeStatus()
        {
            RelatedTrees?.Invoke();
        }

        public void BurnTree()
        {
            if(NextTreeStatus == TreeStatus.Healthy)
                NextTreeStatus = TreeStatus.Burning;
        }

        public void KillTree()
        {
            Health = 0;
            TreeStatus = TreeStatus.Dead;
        }

       public void UpdateTreeStatus()
        {
            TreeStatus = NextTreeStatus;
        }

        public void TreeLifeCycle()
        {
            if(TreeStatus == TreeStatus.Burning)
            {
                if(Health == 0)
                {
                    NextTreeStatus = TreeStatus.Dead;
                }
                else
                {
                    Health--;
                }
                ChangeTreeStatus();
            }
        }
    }
}
