using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class BinaryTree
    {
        private Node _head;
        private string expSrt;
        int pos = 0;
        public BinaryTree(string constructStr)
        {
            expSrt = constructStr;
            _head = CreateTree();
        }

        private Node CreateTree()
        {
            Node head = null;
            char ch;
            while (pos < expSrt.Length)
            {
                Node node;
                ch = expSrt[pos];
                node = GetNode();
                if (head == null)
                {
                    head = node;
                }
                else if (!head.IsOptr)
                {
                    node.Left = head;
                    head = node;
                }
                else if (!node.IsOptr)
                {
                    Node tempNode = head;
                    while (tempNode.Right != null)
                    {
                        tempNode = tempNode.Right;
                    }
                    tempNode.Right = node;
                }
                else
                {
                    if(GetPriority((char)node.Data) <= GetPriority((char)head.Data))
                    {
                        node.Left = head;
                        head = node;
                    }
                    else
                    {
                        node.Left = head.Right;
                        head.Right = node;
                    }
                }
            }
            return head;
        }

        private Node GetNode()
        {
            char ch = expSrt[pos];
            if (char.IsDigit(ch))
            {
                StringBuilder numStr = new StringBuilder();
                while((pos < expSrt.Length && char.IsDigit(ch = expSrt[pos]))||(pos < expSrt.Length && (ch = expSrt[pos]) == '.'))
                {
                    numStr.Append(ch);
                    pos++;
                }
                return new Node(double.Parse(numStr.ToString()));
            }
            else
            {
                pos++;
                return new Node(ch);
            }
        }

        private int GetPriority(char optr)
        {
            if(optr == '+'||optr == '-')
            {
                return 1;
            }
            else if(optr == '*'||optr == '/')
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }

        private double PreOrderCalc(Node node)
        {
            double n1, n2;
            if (node.IsOptr)
            {
                n1 = PreOrderCalc(node.Left);
                n2 = PreOrderCalc(node.Right);
                char optr = (char)node.Data;
                switch (optr)
                {
                    case '+':
                        node.Data = n1 + n2;
                        break;
                    case '-':
                        node.Data = n1 - n2;
                        break;
                    case '*':
                        node.Data = n1 * n2;
                        break;
                    case '/':
                        node.Data = n1 / n2;
                        break;
                }
            }
            return node.Data;
        }
        public double GetResult()
        {
            return PreOrderCalc(_head);
        }
    }
}
