//Author: Per Larsen

using System;
using System.Reflection.Metadata.Ecma335;

public class LLdemo
{
    public static void Main()
    {
        LL s = new LL();
        s.add(3);
        s.add(7);
        s.add(5);
        s.add(6);
        s.printAll();
        s.PrintUlige();
        int sum = s.Beregnsum();
        Console.WriteLine(sum);
        s.IndSetEfter(2, 200);
        Console.WriteLine();
        s.printAll();
        Console.WriteLine();
        s.SletElement(3);
        s.printAll();
    }
}

class LL
{
    private L f;

    public LL()
    {
        f = null;
    }

    public void add(int n)
    {
        L node = new L();
        node.data = n;
        node.next = f;
        f = node;
    }

    public void printAll()
    {
        Console.WriteLine("Udprinter alt data:");
        L tmp = f;
        while (tmp != null)
        {
            Console.WriteLine($"tmp.data = {tmp.data}");
            tmp = tmp.next;
        }
    }

    public void PrintUlige()
    {
        Console.WriteLine("\nUdprinter alle ulige tal:");
        L temp = f;
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
        L temp = f;
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
        L nyNode = new L();
        nyNode.data = element;

        if (pos == 0)
        {
            nyNode.next = f;
            f = nyNode;
        }
        else
        {
            L temp = f; 
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

    }
}

public class L
{
    public int data;
    public L next;
}
