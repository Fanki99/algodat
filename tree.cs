using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Algodat
{
    class Node
    {
        public int key;
        public Node left;
        public Node right;
        
        public Node(int initial){
            key = initial;
            left = null;
            right = null;
        }
    }
    
    class Tree 
    {   
        bool isAVL = true;
        int min, max, avgSum, avgCount;
        bool first = true;
        public Node root;
        public Tree()
        {
            root = null;
        }

        public Tree(int initial)
        {
            root = new Node(initial);
        }

        //recursive add
        public void Add(int key)
        {
            AddR(ref root, key);
        }

        public void AddR(ref Node N, int key)
        {
            
            if (N == null)
            {
                Node NewNode = new Node(key);
                N = NewNode;
                return;
            }
            if(key == N.key){
                return;
            }
            if (key < N.key)
            {
                AddR(ref N.left, key);
                return;
            }
            if (key >= N.key)
            {
                AddR(ref N.right, key);
                return;
            }
            
        }

        public void parse(){
            parseR(ref root);

            Console.Write("AVL: ");
            if(isAVL) {
                Console.Write("yes ");
            }
            else {
                Console.Write("no \n");
            }
            Console.WriteLine("min: " + min + "; max: " + max + "; avg:" + ((Double)avgSum / (Double)avgCount)); 
        }

        private void parseR(ref Node N)
        {
            if(N !=null)
            {
                parseR(ref N.right);
                parseR(ref N.left);

                int rbalance = isBalanced(ref N.right);
                int lbalance = isBalanced(ref N.left);
                int difference = rbalance - lbalance;

                Console.Write("bal(");
                Console.Write(N.key);
                Console.Write(") = ");
                Console.Write(difference);

                if(difference != 0 && difference !=1 && difference !=-1)
                {
                    Console.Write(" AVL violation!");
                    isAVL = false;
                }
                
                if(first){
                    min = N.key;
                    first = false;
                }
                Console.Write("\n");
                if(min > N.key) min = N.key;
                if(max < N.key) max = N.key;
                avgCount++;
                avgSum += N.key;

            }
        }

        public int isBalanced(ref Node N)
        {
            int balance = 0;
            if(N != null)
            {
                int lbalance = isBalanced(ref N.left);
                int rbalance = isBalanced(ref N.right);

                balance = Math.Max(lbalance, rbalance) +1;
            }

            return balance;
        }

    } 
}