using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary.BinaryTree
{
    public class BinaryTreeNode<T> : IComparable<T> where T : IComparable<T>
    {
        public T Value { get; }
        public BinaryTreeNode<T>? Left;
        public BinaryTreeNode<T>? Right;

        public BinaryTreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

        public int CompareTo(T? other)
        {
            if (Value == null)
            {
                if (other == null)
                    return 0;
                else
                    return -1;
            }
            else
            {
                if (other == null)
                    return 1;
                else
                    return Value.CompareTo(other);
            }
        }
    }
}
