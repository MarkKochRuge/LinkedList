//Author: Per Larsen

using System;
using System.Reflection.Metadata.Ecma335;

public class LLdemo
{
    public static void Main()
    {
        LinkedList s = new LinkedList();
        s.add(3);
        s.add(7);
        s.add(5);
        s.add(6);
        s.printAll();
        s.PrintUlige();

        int sum = s.Beregnsum();
        Console.WriteLine(sum);
        Console.WriteLine();

        s.IndSetEfter(2, 200);
        s.printAll();
        Console.WriteLine();

        s.SletElement(2) ;
        s.printAll();
    }
}

class LinkedList
{
    private Node Head;

    public LinkedList()
    {
        Head = null;
    }

    public void add(int n)
    {
        Node node = new Node();
        node.data = n;
        node.next = Head;
        Head = node;
    }

    public void printAll()
    {
        Console.WriteLine("Udprinter alt data:");
        Node temp = Head;
        while (temp != null)
        {
            Console.WriteLine($"tmp.data = {temp.data}");
            temp = temp.next;
        }
    }

    public void PrintUlige()
    {
        Console.WriteLine("\nUdprinter alle ulige tal:");
        Node temp = Head;
        while (temp != null)
        {
            if (temp.data % 2 != 0)
            {
                Console.WriteLine("tmp.data =" + " " + temp.data);
            }
            temp = temp.next;
        }
    }

    public int Beregnsum()
    {
        Console.WriteLine("\nBeregner summen af alt data:");
        Node temp = Head;
        int sum = 0;
        while (temp != null)
        {
            sum += temp.data;
            temp = temp.next;
        }
        return sum;
    }

    public void IndSetEfter(int pos, int element)
    {
        Node nyNode = new Node();
        nyNode.data = element;

        if (pos == 0)
        {
            nyNode.next = Head;
            Head = nyNode;
        }
        else
        {
            Node temp = Head; 
            int count = 0;

            while (temp != null && count < pos - 1)
            {
                temp = temp.next;
                count++;
            }

            if (temp != null)
            {
                nyNode.next = temp.next;
                temp.next = nyNode;
            }
            else
            {
                Console.WriteLine($"Position {pos} er ude af rækkevidde");
            }
        }
    }

    public void SletElement(int pos)
    {
        Node temp = Head;
        // If the position is 0, delete the head node
        if (pos == 0)
        {
            Head = temp.next; // Change head to the next node
        }

        // Find the previous node of the node to be deleted
        for (int i = 0; temp != null && i < pos - 1; i++)
        {
            temp = temp.next;
        }

        // If the position is greater than the number of nodes
        if (temp == null || temp.next == null)
        {
            Console.WriteLine($"Position {pos} er ude af rækkevidde.");
        }

        // Node temp.next is the node to be deleted
        Node next = temp.next.next;

        // Unlink the node from the linked list
        temp.next = next;



    }
}

public class Node
{
    public int data;
    public Node next;
}
