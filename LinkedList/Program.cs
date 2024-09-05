//Author: Per Larsen

using System;
using System.Collections;
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
        Console.WriteLine("\nBeregner summen: " + sum);
        Console.WriteLine();

        Console.WriteLine("indsæt efter 2");
        s.IndSetEfter(2, 200);
        s.printAll();
        Console.WriteLine();

        Console.WriteLine("Slet element 2");
        s.SletElement(2) ;
        s.printAll();
        Console.WriteLine();

        Console.WriteLine("Tilføj under top");
        s.AddUnderTop(220);
        s.printAll();
        Console.WriteLine();

        int hent = s.HentFørste();
        Console.WriteLine("Henter den første i listen:" + hent );
        Console.WriteLine();

        Console.WriteLine("Slet første");
        s.SletFørste();
        s.printAll();
        Console.WriteLine();

        s.IndSetEfter(0, 6);
        int hent2 = s.HentOgSletFoerste();
        Console.WriteLine("hentet og slettet første værdi: " + hent2);
        Console.WriteLine();
        s.printAll();
        Console.WriteLine();

        double snit = s.BeregnSnit();
        Console.WriteLine("Beregnet snit: " + snit);
        Console.WriteLine();

        LinkedList linkedList = s.Getinterval(4, 9);
        linkedList.printAll();

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


    public void AddUnderTop(int tal) 
    {
        Node nyNode = new Node();
        nyNode.data = tal;
        Node temp = Head;
        int count = 0;

        while (temp != null && count < 1 - 1)
        {
            temp = temp.next;
            count++;
        }

        nyNode.next = temp.next;
        temp.next = nyNode;
        
    }

    public void SletElement(int pos)
    {
        Node temp = Head;
        if (pos == 0)
        {
            Head = temp.next;
        }

        for (int i = 0; temp != null && i < pos - 1; i++)
        {
            temp = temp.next;
        }

        if (temp == null || temp.next == null)
        {
            Console.WriteLine($"Position {pos} er ude af rækkevidde.");
        }

        Node next = temp.next.next;
        temp.next = next;
    }

    public void SletFørste()
    {
        Node temp = Head;
        Head = temp.next;
        Node next = temp.next.next;
        temp.next = next;

    }



    public int HentFørste()
    {
        int hent = 0;
        Node temp = Head;
        hent = temp.data;
        return hent;
    }

    public int HentOgSletFoerste()
    {
        int hent = 0;
        Node temp = Head;
        hent = temp.data;

        Head = temp.next;
        Node next = temp.next.next;
        temp.next = next;
        return hent;
    }

    public double BeregnSnit()
    {
        Node temp = Head;
        int count = 0;
        int sum = Beregnsum();
        while (temp != null)
        {
            temp = temp.next;
            count++;
        }
        double snit = sum / count;
        return snit;
    }

    public LinkedList Getinterval(int i1, int i2)
    {
        LinkedList l = new LinkedList();
        Node temp = Head;
        while (temp != null)
        {
            temp = temp.next;
            if (temp != null || temp.data < i2 || temp.data > i1)
            {
                l.add(temp.data);
            }
            else
            {
                return l;
            }
        }
        return l;
    }
}

public class Node
{
    public int data;
    public Node next;
}
