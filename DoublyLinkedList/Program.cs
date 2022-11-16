using System;
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
        public void addNode()/*Adds a new node*/
        {
            int rollNo;
            string nm;
            Console.Write("\nEnter the roll number of the student: ");
            rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student: ");
            nm = Console.ReadLine();
            Node newnode = new Node();
            newnode.rollNumber = rollNo;
            newnode.name = nm;
            /*Checks if the list is empty*/
            if(START == null || rollNo <= START.rollNumber)
            {
                if((START != null) && (rollNo == START.rollNumber))
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return;
                }
                newnode.next = START;
                if(START != null)
                    START.prev = newnode;
                newnode.prev = null;
                START = newnode;
                return;
            }
            Node previous, current;
            for (current = previous = START; current != null &&
                rollNo >= current.rollNumber; previous = current, current
                = current.next)
            {
                if(rollNo == current.rollNumber)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return;
                }
            }
            newnode.next = current;
            newnode.prev = previous;
            /*if the node is to be inserted at the end of the list.*/
            if(current == null)
            {
                newnode.next = null;
                previous.next = newnode;
                return;
            }
            current.prev = newnode;
            previous.next = newnode;
        }
        /*Checks wheteher the specified node is present*/
        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            for(previous = current = START; current != null &&
                rollNo != current.rollNumber; previous = current,
                current = current.next) { }
            return (current != null);
        }
        /*Deletes the specified node*/
        public bool delNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if(Search(rollNo, ref previous, ref current) == false)
                return false;
            if(current == START)/*If the first node is to be deleted*/
            {
                START = START.next;
                if(START != null)
                    START.prev = null;
                return true;
            }
            if(current.next == null)/*If the last node is to be deleted*/
            {
                previous.next = null;
                return true;
            }
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }

        /*Traverses the list*/
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the ascending order of " + "roll numbers are:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null;
                    currentNode = currentNode.next)
                    Console.Write(currentNode.rollNumber + "   "
                        + currentNode.name + "\n");
            }
        }

        /*Traverses the list in the reverse direction*/
        public void revtraverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the descending order of "
                    + "roll numbers are:\n");
                Node currentNode;
                for(currentNode = START; currentNode.next != null;
                    currentNode = currentNode.next) { }
                while(currentNode != null)
                {
                    Console.Write(currentNode.rollNumber + "   "
                        + currentNode.name + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
