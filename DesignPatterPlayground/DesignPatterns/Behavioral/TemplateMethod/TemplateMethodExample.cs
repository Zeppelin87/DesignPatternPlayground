using System;

namespace DesignPatterPlayground.DesignPatterns.Behavioral.TemplateMethod
{
    public static class TemplateMethodExample
    {
        public static void Run()
        {
            var chess = new Chess();
            chess.Run();
        }
    }

    public abstract class Game
    {
        protected Game(int numberOfPlayers)
        {
            NumberOfPlayers = numberOfPlayers;
        }

        public void Run()
        {
            Start();
            while (!HaveWinner)
            {
                TakeTurn();
            }

            Console.WriteLine($"Player {WinningPlayer} wins.");
        }

        protected int CurrentPlayer;
        protected readonly int NumberOfPlayers;

        // These game specific members are implemented by subclasses. 
        protected abstract void Start();
        protected abstract void TakeTurn();
        protected abstract bool HaveWinner { get; }
        protected abstract int WinningPlayer { get; }
    }

    public class Chess : Game
    {
        // Defaulted to 2 players.
        public Chess() : base(2)
        {

        }

        protected override bool HaveWinner => Turn == MaxTurnLimit;

        protected override int WinningPlayer => CurrentPlayer;

        protected override void Start()
        {
            Console.WriteLine($"Starting a game of chess with {NumberOfPlayers} players.");
        }

        protected override void TakeTurn()
        {
            Console.WriteLine($"Turn {Turn++} taken by player {CurrentPlayer}.");
            CurrentPlayer = (CurrentPlayer + 1) % NumberOfPlayers;
        }

        private int Turn = 1;
        private int MaxTurnLimit = 10;
    }
}
