using System;
using UnityEngine;
public class Game 
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Press Escape to exit.");

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true); // Read key without displaying it

            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Application.Quit();
            }
            // Add other logic here if needed
        }
    }
}
