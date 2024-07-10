using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary.BinaryTree
{
    public class BinaryTreeNode
    {
        public int Value { get; }
        public BinaryTreeNode? Left;
        public BinaryTreeNode? Right;

        public BinaryTreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }
}
