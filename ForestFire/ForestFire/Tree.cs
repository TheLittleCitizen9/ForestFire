using System;
using System.Collections.Generic;
using System.Text;

namespace ForestFire
{
    public class Tree
    {
        public int Health { get; set; }
        public TreeStatus TreeStatus { get; set; }
        public Tree RelatedTo { get; set; }
        public event Action RelatedTrees;

        public Tree(int health, TreeStatus status, Tree relatedTo = null)
        {
            Health = health;
            TreeStatus = status;
            RelatedTo = relatedTo;
        }

        public void RelateToTree()
        {
            RelatedTo.RelatedTrees += ChangeStatus;
        }

        public void ChangeTreeStatus()
        {
            RelatedTrees?.Invoke();
        }

        public void BurnTree()
        {
            TreeStatus = TreeStatus.Burning;
            Health--;
            if(Health == 0)
            {
                TreeStatus = TreeStatus.Dead;
            }
        }

        public void ChangeStatus()
        {
            switch (TreeStatus)
            {
                case TreeStatus.Healthy:
                    BurnTree();
                    break;
                case TreeStatus.Burning:
                    if(Health == 0)
                    {
                        TreeStatus = TreeStatus.Dead;
                    }
                    break;
                case TreeStatus.Dead:
                    break;
                default:
                    break;
            }
        }
    }
}
