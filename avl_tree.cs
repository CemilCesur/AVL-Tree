using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL_tree
{
    class Node
    {
        private int value;
        private int height;
        private Node left;
        private Node right;
        public Node(int value) { this.value = value; height = 1; }
        public int heightGetSet
        {
            get
            { return height;}
            set
            { height = value;}
        }
        public int valueGetSet
        {
            get
            { return value;}
            set
            {this.value = value;}
        }
        public Node leftGetSet
        {
            get
            {return left;}
            set
            {left = value;}
        }
        public Node rightGetSet
        {
            get
            {return right;}
            set
            {right = value;}
        }

    }
    public class avlTree
    {
        Node root;
        int height(Node currentNode)
        {
            if (currentNode == null) { return 0; }
            return currentNode.heightGetSet;
        }
        public int max(int a, int b)
        {
            return (a > b) ? a : b;
        }
        Node rightRotate(Node y)
        {
            Node x = y.leftGetSet;
            Node T2 = x.rightGetSet;
            x.rightGetSet = y;
            y.leftGetSet = T2;
            
            y.heightGetSet = max(height(y.leftGetSet), height(y.rightGetSet)) + 1;
            x.heightGetSet = max(height(x.leftGetSet),height(x.rightGetSet)) + 1;
            return x;
        }
         Node leftRotate(Node x)
        {
            Node y = x.rightGetSet;
            Node T2 = y.leftGetSet;
            y.leftGetSet = x;
            x.rightGetSet = T2;

            x.heightGetSet = max(height(x.leftGetSet), height(x.rightGetSet)) + 1;
            y.heightGetSet = max(height(y.leftGetSet), height(y.rightGetSet)) + 1;
           
            return y;
        }
         int getBalance(Node N)
        {
            if (N == null)
                return 0;

            return height(N.leftGetSet) - height(N.rightGetSet);
        }
        Node insertion(Node node, int value)
        {
            if (node == null)
                return (new Node(value));

            if (value < node.valueGetSet)
                node.leftGetSet = insertion(node.leftGetSet, value);
            else if (value > node.valueGetSet)
                node.rightGetSet = insertion(node.rightGetSet,value);
            else 
                return node;

            node.heightGetSet = 1 + max(height(node.leftGetSet),
                                height(node.rightGetSet));

            int balance = getBalance(node);
            if (balance > 1 && value < node.leftGetSet.valueGetSet)
                return rightRotate(node);        
            if (balance < -1 && value > node.rightGetSet.valueGetSet)
                return leftRotate(node);
            if (balance > 1 && value > node.leftGetSet.valueGetSet)
            {
                node.leftGetSet = leftRotate(node.leftGetSet);
                return rightRotate(node);}
            if (balance < -1 && value < node.rightGetSet.valueGetSet)
            {
                node.rightGetSet = rightRotate(node.rightGetSet);
                return leftRotate(node);}
            return node;}
        void preOrder(Node node)
        {
            if (node != null)
            {
                Console.Write(node.valueGetSet + " ");
                preOrder(node.leftGetSet);
                preOrder(node.rightGetSet); }}
        static void Main(string[] args)
        { avlTree tree = new avlTree();
            tree.root = tree.insertion(tree.root, 8);
            tree.root = tree.insertion(tree.root, 3);
            tree.root = tree.insertion(tree.root, 19);
            tree.root = tree.insertion(tree.root, 2);
            tree.root = tree.insertion(tree.root, 7);
            tree.root = tree.insertion(tree.root, 15);
            tree.root = tree.insertion(tree.root, 1);
            tree.root = tree.insertion(tree.root, 13);
            tree.root = tree.insertion(tree.root, 6);
            tree.root = tree.insertion(tree.root, 9);
            Console.Write("Ağacın PreOrder Dolaşılması  : ");
            tree.preOrder(tree.root);
            Console.ReadKey();
        }

    }

    }
    
