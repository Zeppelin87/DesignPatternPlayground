using System;

namespace DesignPatterPlayground.DesignPatterns.Behavioral.TemplateMethod
{
    public static class FunctionalTemplateMethod
    {
        public static void Run()
        {
            var numberOfPlayers = 2;
            int currentPlayer = 0;
            int turn = 1, maxTurnLimit = 10;

            void Start()
            {
                Console.WriteLine($"Starting a game of chess with {numberOfPlayers} players.");
            }

            void TakeTurn()
            {
                Console.WriteLine($"Turn {turn++} taken by player {currentPlayer}.");
                currentPlayer = (currentPlayer + 1) % numberOfPlayers;
            }

            bool HaveWinner()
            {
                return turn == maxTurnLimit;
            }

            int WinningPlayer()
            {
                return currentPlayer;
            }

            GameTemplate.RunGame(Start, TakeTurn, HaveWinner, WinningPlayer);
        }
    }

    // Instead of using inheritance, you accept arguments through a static function.
    public static class GameTemplate
    {
        public static void RunGame(
            Action start,
            Action takeTurn,
            Func<bool> haveWinner,
            Func<int> winningPlayer)
        {
            start();
            while (!haveWinner())
            {
                takeTurn();
            }

            Console.WriteLine($"Player {winningPlayer()} wins.");
        }
    }
}
