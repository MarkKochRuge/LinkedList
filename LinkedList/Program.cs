//Author: Per Larsen

using System;
using System.Collections;
using System.Reflection.Metadata.Ecma335;

public class LLdemo
{
    public static void Main()
    {
        // Opret en ny linkedlist og tilføj elementer
        LinkedList s = new LinkedList();
        s.add(3);
        s.add(7);
        s.add(5);
        s.add(6);

        // Udskriv hele listen 
        s.printAll();

        // Udskriv alle ulige tal i listen 
        s.PrintUlige();

        // Beregn summen af elementerne i listen
        int sum = s.Beregnsum();
        Console.WriteLine("\nBeregner summen: " + sum);
        Console.WriteLine();

        // Indsæt element på specifik plads 
        Console.WriteLine("indsæt efter 2");
        s.IndSetEfter(2, 200);
        s.printAll();
        Console.WriteLine();

        // Slet element på given plads 
        Console.WriteLine("Slet element 2");
        s.SletElement(2);
        s.printAll();
        Console.WriteLine();

        // Tilføj element efter / under det første element
        Console.WriteLine("Tilføj under top");
        s.AddUnderTop(220);
        s.printAll();
        Console.WriteLine();

        // Hent det første element i listen 
        int hent = s.HentFørste();
        Console.WriteLine("Henter den første i listen:" + hent);
        Console.WriteLine();

        // Slet det første element i listen
        Console.WriteLine("Slet første");
        s.SletFørste();
        s.printAll();
        Console.WriteLine();

        // Indsætter værdi tilbage i listen 
        s.IndSetEfter(0, 6);

        // Hent og slet det første element i listen 
        int hent2 = s.HentOgSletFoerste();
        Console.WriteLine("hentet og slettet første værdi: " + hent2);
        Console.WriteLine();
        s.printAll();
        Console.WriteLine();

        // Beregn snittet i listen
        double snit = s.BeregnSnit();
        Console.WriteLine("Beregnet snit: " + snit);
        Console.WriteLine();

        // Indæst værdi tilbage i listen
        s.IndSetEfter(0, 6);

        // Få en ny linkedliste udfra elementer som hører under et bestemt interval
        LinkedList linkedList = s.Getinterval(4, 9);
        linkedList.printAll();

    }
}

class LinkedList
{
    private Node Head;

    public LinkedList()
    {
        Head = null; // Initialiserer head til null ( tom liste ) 
    }

    // Metode til tilføjelæse af element 
    public void add(int n)
    {
        Node node = new Node();
        node.data = n;
        node.next = Head; // Gør det nye node til head ( den forreste ) 
        Head = node;
    }

    // Metode til udskrivelse af alle elementer 
    public void printAll()
    {
        Console.WriteLine("Udprinter alt data:");
        Node temp = Head;
        while (temp != null) // Iterer gennem listen 
        {
            Console.WriteLine($"tmp.data = {temp.data}");
            temp = temp.next;
        }
    }

    // Udskriver alle de ulige elementer i listen 
    public void PrintUlige()
    {
        Console.WriteLine("\nUdprinter alle ulige tal:");
        Node temp = Head;
        while (temp != null) // Iterer gennem listen
        {
            if (temp.data % 2 != 0) // Tjekker efter om tallet er ulige
            {
                Console.WriteLine("tmp.data =" + " " + temp.data);
            }
            temp = temp.next;
        }
    }

    // Beregner summen af alle elementer i listen 
    public int Beregnsum()
    {
        Node temp = Head;
        int sum = 0;
        while (temp != null) // Iterer gennem listen
        {
            sum += temp.data; // Tilføjer og gemmer elementet i sum integer
            temp = temp.next;
        }
        return sum;
    }

    // Indsætter nyt element efter en bestemt position 
    public void IndSetEfter(int pos, int element)
    {
        Node nyNode = new Node();
        nyNode.data = element;

        if (pos == 0) // hvis position er 0 skal den bare sættes ind som den første node 
        {
            nyNode.next = Head;
            Head = nyNode;
        }
        else
        {
            Node temp = Head;
            int count = 0;

            while (temp != null && count < pos - 1) // Find positionen 
            {
                temp = temp.next;
                count++;
            }

            if (temp != null)
            {
                nyNode.next = temp.next; // Indsætter det nye element
                temp.next = nyNode;
            }
            else
            {
                Console.WriteLine($"Position {pos} er ude af rækkevidde");
            }
        }
    }

    // Tilføjer et element under toppen af listen ( Næstøverst position ) 
    public void AddUnderTop(int tal)
    {
        Node nyNode = new Node();
        nyNode.data = tal;
        Node temp = Head;
        int count = 0;

        while (temp != null && count < 1 - 1) // Iterer igennem listen 
        {
            temp = temp.next;
            count++;
        }

        nyNode.next = temp.next; // Sætter nye node under toppen
        temp.next = nyNode;

    }

    // Sletter element på en bestem position 
    public void SletElement(int pos)
    {
        Node temp = Head;
        if (pos == 0) // hvis det er den første position
        {
            Head = temp.next;
        }

        for (int i = 0; temp != null && i < pos - 1; i++) // Find node før den, der skal slettes
        {
            temp = temp.next;
        }

        if (temp == null || temp.next == null) // Tjek om positionen er gyldig
        {
            Console.WriteLine($"Position {pos} er ude af rækkevidde.");
        }

        Node next = temp.next.next;
        temp.next = next;
    }

    // Sletter det første element i listen
    public void SletFørste()
    {
        Node temp = Head;
        Head = temp.next; // flyt head til næste node 
        Node next = temp.next.next;
        temp.next = next;

    }

    // Henter det første element i listen 
    public int HentFørste()
    {
        int hent = 0;
        Node temp = Head;
        hent = temp.data;
        return hent;
    }

    // Henter og sletter første element i listen
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

    // Beregner gennemsnittett af alle elementer i listen
    public double BeregnSnit()
    {
        Node temp = Head;
        int count = 0;
        int sum = Beregnsum(); // Metode kald til anden metode som beregner summen
        while (temp != null) // Tæller antallet af elementer 
        {
            temp = temp.next;
            count++;
        }
        double snit = sum / count; // dividere summen med antallet af elementer 
        return snit; // returnere gennemsnittet 
    }

    // Returnere en ny liste med de elementer som ligger mellem intervallet i1 og i2 
    public LinkedList Getinterval(int i1, int i2)
    {
        LinkedList l = new LinkedList();
        Node temp = Head;
        int tal = 0;
        while (temp != null) // Iterer igennem listen 
        {
            tal = temp.data; // Gemmer elementet i en integer
            if (tal < i2 && tal > i1) // Tjekker om tallet ligger mellem i1 og i2 
            {
                l.add(tal);
            }
            temp = temp.next;
        }
        return l; // returne den nye liste 
    }

    public class Node
    {
        public int data; // Datafelt for noderne i listen
        public Node next; // Reference til næste node 
    }
}
