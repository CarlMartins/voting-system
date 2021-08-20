using System;

namespace voting_system
{
    class Program
    {
        static void Main(string[] args)
        {
            int yesCounter = 4;
            int noCounter = 2;
            int maybeCounter = 3;

            int total = yesCounter + noCounter + maybeCounter;

            double yesPercent = Math.Round((double)yesCounter / total * 100f, 2);
            double noPercent = Math.Round((double)noCounter / total * 100f, 2);
            double maybePercent = Math.Round((double)maybeCounter / total * 100f, 2);

            double excess = Math.Round(100 - yesPercent - maybePercent - noPercent, 2);
            Console.WriteLine($"Excess: {excess}");


            if (yesCounter > noCounter)
            {
                if (yesCounter > maybeCounter)
                {
                    Console.WriteLine("Yes won!");
                    yesPercent += excess;
                }
                else if (maybeCounter > yesCounter)
                {
                    Console.WriteLine("Maybe won!");
                    maybePercent += excess;
                }
                else
                {
                    Console.WriteLine("Draw!");
                    noPercent += excess;
                }
            }
            else if (noCounter > yesCounter)
            {
                if (noCounter > maybeCounter)
                {
                    Console.WriteLine("No won!");
                    noPercent += excess;
                }
                else if (maybeCounter > noCounter)
                {
                    Console.WriteLine("Maybe won!");
                    maybePercent += excess;
                }
                else
                {
                    Console.WriteLine("Draw!");
                    yesPercent += excess;
                }
            }
            else
            {
                if (maybeCounter > yesCounter)
                {
                    Console.WriteLine("Maybe won!");
                    maybePercent += excess;
                }
                else
                {
                    Console.WriteLine("Draw!");
                }
            }
                        
            Console.WriteLine($"Yes count: {yesCounter} / Percentage: {Math.Round(yesPercent, 2)}%");
            Console.WriteLine($"No count: {noCounter} / No Percentage: {Math.Round(noPercent, 2)}%");
            Console.WriteLine($"Maybe count: {maybeCounter} / No Percentage: {Math.Round(maybePercent, 2)}%");
        }
    }
}