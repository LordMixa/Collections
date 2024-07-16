using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelHWCollectionsLibrary.BinaryTree
{
    public class BinaryTreeNode<T> : IComparable<T>
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
                {
                    if (Value is IComparable<T> comparable && other is T otherValue)
                    {
                        return comparable.CompareTo(otherValue);
                    }
                    if (Value is IComparable nonGenericComparable && other.GetType() == Value.GetType())
                    {
                        return nonGenericComparable.CompareTo(other);
                    }
                    if (IsNumber(Value) && IsNumber(other))
                    {
                        double xValue = Convert.ToDouble(Value);
                        double yValue = Convert.ToDouble(other);
                        return xValue.CompareTo(yValue);
                    }
                    if (IsNumber(Value) && other is string otherString && int.TryParse(otherString, out int otherInt))
                    {
                        return Convert.ToInt32(Value).CompareTo(otherInt);
                    }
                    if (Value is string stringValue && IsNumber(other) && int.TryParse(stringValue, out int parsedInt))
                    {
                        return parsedInt.CompareTo(Convert.ToInt32(other));
                    }
                    if (Value.Equals(other))
                    {
                        return 0;
                    }
                    else
                    {
                        string xString = Value.ToString()!;
                        string yString = other.ToString()!;
                        return string.Compare(xString, yString, StringComparison.Ordinal);
                    }
                }
            }
        }
        private bool IsNumber(object value)
        {
            return value is byte || value is sbyte ||
                   value is short || value is ushort ||
                   value is int || value is uint ||
                   value is long || value is ulong ||
                   value is float || value is double ||
                   value is decimal;
        }

    }
}
