// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    public class Calc
    {
        public static bool AreEqual(int a, int b)
        {
            return a.Equals(b);
        }
    }
    public static void Main(string[] args)
    { 
        bool c = Calc.AreEqual(2, 2);
        if(c== true)
        Console.WriteLine("yes");
    }
}
