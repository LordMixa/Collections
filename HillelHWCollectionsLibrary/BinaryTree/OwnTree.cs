using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary.BinaryTree
{
    public class OwnTree
    {
        public BinaryTreeNode? Root { get; private set; }
        public int Count { get; private set; }

        public OwnTree()
        {
            Root = null;
            Count = 0;
        }

        public void Add(int value)
        {
            if (Root == null)
            {
                Root = new BinaryTreeNode(value);
            }
            else
            {
                AddTo(Root, value);
            }
            Count++;
        }

        private void AddTo(BinaryTreeNode node, int value)
        {
            if (value < node.Value)
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode(value);
                }
                else
                {
                    AddTo(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode(value);
                }
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }

        public bool Contains(int value)
        {
            return ContainsIn(Root!, value);
        }

        private bool ContainsIn(BinaryTreeNode node, int value)
        {
            if (node == null)
            {
                return false;
            }

            if (value == node.Value)
            {
                return true;
            }

            if (value < node.Value)
            {
                return ContainsIn(node.Left!, value);
            }
            else
            {
                return ContainsIn(node.Right!, value);
            }
        }

        public void Clear()
        {
            Root = null;
            Count = 0;
        }

        public int[] ToArray()
        {
            List<int> elements = new List<int>();
            ToArray(Root!, elements);
            return elements.ToArray();
        }

        private void ToArray(BinaryTreeNode node, List<int> elements)
        {
            if (node == null)
            {
                return;
            }

            ToArray(node.Left!, elements);
            elements.Add(node.Value);
            ToArray(node.Right!, elements);
        }
    }

}
