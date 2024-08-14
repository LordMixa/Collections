using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HillelHWCollectionsLibrary.Interfaces;

namespace HillelHWCollectionsLibrary.Collections.BinaryTree
{
    public class OwnTree<T> : ITree<T> where T : IComparable<T>
    {
        public BinaryTreeNode<T>? Root { get; private set; }
        public int Count { get; private set; }

        public OwnTree()
        {
            Root = null;
            Count = 0;
        }

        public void Add(T value)
        {
            if (Root == null)
            {
                Root = new BinaryTreeNode<T>(value);
            }
            else
            {
                AddTo(Root, value);
            }
            Count++;
        }

        private void AddTo(BinaryTreeNode<T> node, T value)
        {
            if (node.CompareTo(value) > 0)
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value);
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
                    node.Right = new BinaryTreeNode<T>(value);
                }
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }

        public bool Contains(T value)
        {
            return ContainsIn(Root!, value);
        }

        private bool ContainsIn(BinaryTreeNode<T> node, T value)
        {
            if (node == null)
            {
                return false;
            }
            if (node.CompareTo(value) == 0)
            {
                return true;
            }

            if (node.CompareTo(value) < 0)
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

        public T[] ToArray()
        {
            List<T> elements = new List<T>();
            ToArray(Root!, elements);
            return elements.ToArray();
        }

        private void ToArray(BinaryTreeNode<T> node, List<T> elements)
        {
            if (node == null)
            {
                return;
            }

            ToArray(node.Left!, elements);
            elements.Add(node.Value);
            ToArray(node.Right!, elements);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal(Root).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private IEnumerable<T> InOrderTraversal(BinaryTreeNode<T>? node)
        {
            if (node != null)
            {
                foreach (var left in InOrderTraversal(node.Left))
                {
                    yield return left;
                }

                yield return node.Value;

                foreach (var right in InOrderTraversal(node.Right))
                {
                    yield return right;
                }
            }
        }
        //public IEnumerator<T> GetEnumerator()
        //{
        //    return new TreeIterator<T>(Root);
        //}
        //public class TreeIterator<T> : IEnumerator<T> where T : IComparable<T>
        //{
        //    private readonly BinaryTreeNode<T>? root;
        //    private Stack<BinaryTreeNode<T>> stack;
        //    private BinaryTreeNode<T>? current;

        //    public TreeIterator(BinaryTreeNode<T>? root)
        //    {
        //        this.root = root;
        //        stack = new Stack<BinaryTreeNode<T>>();
        //        current = null;
        //        Reset();
        //    }

        //    public T Current
        //    {
        //        get
        //        {
        //            if (current == null)
        //            {
        //                throw new InvalidOperationException();
        //            }
        //            return current.Value;
        //        }
        //    }

        //    object IEnumerator.Current => Current;

        //    public bool MoveNext()
        //    {
        //        if (stack.Count == 0)
        //        {
        //            return false;
        //        }

        //        current = stack.Pop();
        //        BinaryTreeNode<T>? node = current.Right;

        //        while (node != null)
        //        {
        //            stack.Push(node);
        //            node = node.Left;
        //        }

        //        return true;
        //    }

        //    public void Reset()
        //    {
        //        stack.Clear();
        //        BinaryTreeNode<T>? node = root;
        //        while (node != null)
        //        {
        //            stack.Push(node);
        //            node = node.Left;
        //        }
        //        current = null;
        //    }

        //    public void Dispose() { }
        //}
    }
}
