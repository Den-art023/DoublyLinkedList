﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    class Node
    {
        /*Node class represents the node of doubly linked list.*/
        public int rollNumber;
        public string name;
        public Node next;
        public Node prev;
    }

    class DoubleLinkedList
    {
        Node START;
        public DoubleLinkedList()
        {
            START = null;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
