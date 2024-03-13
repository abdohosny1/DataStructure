using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace _8_BinarySearchTree
{
    public class BinaryTree<TData> where TData : IComparable<TData>
    {
        TreeNode Root;

        NodeAndParent FindNodeAndParent(TData _data)
        {
            TreeNode currentNode = this.Root;
            TreeNode Parent = null;
            NodeAndParent nodeAndParentInfo = null;
            bool left = false;
            while (currentNode != null)
            {
                if (currentNode._data.CompareTo(_data) == 0)
                {
                    nodeAndParentInfo = new NodeAndParent() { Node = currentNode, Parent = Parent, isLeft = left };
                    break;
                }
                else if (currentNode._data.CompareTo(_data) > 0)
                {
                    Parent = currentNode;
                    left = true;
                    currentNode = currentNode.Left;
                }
                else
                {
                    Parent = currentNode;
                    left = false;
                    currentNode = currentNode.Right;
                }
            }
            return nodeAndParentInfo;
        }

        public bool IsExsit(TData _data)
        {
            return BSFind(_data) != null;
        }
        TreeNode BSFind(TData _data)
        {
            TreeNode currentNode = this.Root;
            while (currentNode != null)
            {
                if (currentNode._data.CompareTo(_data) == 0)
                {
                    return currentNode;
                }
                else if (currentNode._data.CompareTo(_data) > 0)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }
            return null;
        }

        public void BSInsert(TData data)
        {
            TreeNode newNode = new TreeNode(data);

            if (this.Root == null)
            {
                this.Root = newNode;
                return;
            }

            TreeNode currentNode= this.Root;

            while (currentNode != null)
            {
                if (currentNode._data.CompareTo(data) > 0) // currentNode.Data > data
                {
                    if (currentNode.Left == null)
                    {
                        currentNode.Left = newNode;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.Left;
                    }
                }
                else
                {
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = newNode;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.Right;
                    }
                }
            }
        }
            public void Insert(TData data)
        {
            TreeNode newNode = new TreeNode(data);

            if(this.Root == null) 
            {
                this.Root = newNode;
                return;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.enqueue(this.Root);
            while(queue.hasData())
            {
                TreeNode currentNode=queue.dequeue();
                if(currentNode.Left == null)
                {
                    currentNode.Left = newNode;
                    break;
                }
                else
                {
                    queue.enqueue(currentNode.Left);
                }

                if (currentNode.Right == null)
                {
                    currentNode.Right = newNode;
                    break;

                }
                else
                {
                    queue.enqueue(currentNode.Right);
                }

            }


        }

        public int Height()
        {
            return InternalHeight(this.Root);
        }

         int InternalHeight(TreeNode node)
        {
            if (node is null) return 0;

            return  1 + Math.Max(InternalHeight(node.Left), InternalHeight(node.Right));
        }

        public void PreOrder()
        {
             InternalPerOrder(this.Root);
            Console.WriteLine("");
        }

        void InternalPerOrder(TreeNode node)
        {
            if (node is null) return;
            Console.Write(node._data +"->");
            InternalPerOrder(node.Left);
            InternalPerOrder(node.Right);
        }

        public void InOrder()
        {
            InternalInOrder(this.Root);
            Console.WriteLine("");
        }

        void InternalInOrder(TreeNode node)
        {
            if (node is null) return;
            InternalInOrder(node.Left);
            Console.Write(node._data + "->");
            InternalInOrder(node.Right);
        }

        public void PostOrder()
        {
            InternalPostOrder(this.Root);
            Console.WriteLine("");
        }

        void InternalPostOrder(TreeNode node)
        {
            if (node is null) return;
            InternalPostOrder(node.Left);
            InternalPostOrder(node.Right);
            Console.Write(node._data + "->");

        }
        private void Print(NodeInfo item, int top)
        {
            SwapColors();
            Print(item.Text, top, item.StartPos);
            SwapColors();
            if (item.Left != null)
                PrintLink(top + 1, "┌", "┘", item.Left.StartPos + item.Left.Size / 2, item.StartPos);
            if (item.Right != null)
                PrintLink(top + 1, "└", "┐", item.EndPos - 1, item.Right.StartPos + item.Right.Size / 2);
        }

        private void PrintLink(int top, string start, string end, int startPos, int endPos)
        {
            Print(start, top, startPos);
            Print("─", top, startPos + 1, endPos);
            Print(end, top, endPos);
        }

        private void Print(string s, int top, int Left, int Right = -1)
        {
            Console.SetCursorPosition(Left, top);
            if (Right < 0) Right = Left + s.Length;
            while (Console.CursorLeft < Right) Console.Write(s);
        }

        private void SwapColors()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
        }
        public void Print(int topMargin = 2, int LeftMargin = 2)
        {
            if (this.Root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo>();
            var next = this.Root;
            for (int level = 0; next != null; level++)
            {
                var item = new NodeInfo { Node = next, Text = next._data.ToString() };
                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + 1;
                    last[level] = item;
                }
                else
                {
                    item.StartPos = LeftMargin;
                    last.Add(item);
                }
                if (level > 0)
                {
                    item.Parent = last[level - 1];
                    if (next == item.Parent.Node.Left)
                    {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos);
                    }
                    else
                    {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos);
                    }
                }
                next = next.Left ?? next.Right;
                for (; next == null; item = item.Parent)
                {
                    Print(item, rootTop + 2 * level);
                    if (--level < 0) break;
                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos;
                        next = item.Parent.Node.Right;
                    }
                    else
                    {
                        if (item.Parent.Left == null)
                            item.Parent.EndPos = item.StartPos;
                        else
                            item.Parent.StartPos += (item.StartPos - item.Parent.EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }


        class TreeNode
        {
            public TData _data;
            public TreeNode Left;
            public TreeNode Right;

            public TreeNode(TData data)
            {
                    _data=data;
            }
        }

        class NodeAndParent
        {
            public TreeNode Node;
            public TreeNode Parent;
            public bool isLeft;
        }

        class NodeInfo
        {
            public TreeNode Node;
            public string Text;
            public int StartPos;
            public int Size { get { return Text.Length; } }
            public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
            public NodeInfo Parent, Left, Right;
        }
    }


}
