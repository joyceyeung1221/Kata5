using System;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            bool? restart;
            do
            {
                Console.Clear();
                new BlackJackEngine().StartGame();
                restart = null;
                while (restart == null)
                {
                    Console.WriteLine("\nContinue? (Y/N) ");
                    var input = Console.ReadKey();
                    switch (input.Key)
                    {
                        case ConsoleKey.Y:
                            restart = true;
                            break;
                        case ConsoleKey.N:
                            restart = false;
                            break;
                        default:
                            restart = null;
                            break;
                    }
                    
                }
            }
            while (restart.GetValueOrDefault());
        }
    }
}
