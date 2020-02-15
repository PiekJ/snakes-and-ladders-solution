using System;

namespace SnakesAndLaddersConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new BoardBuilder(10, 10)
                .GenerateRandomBoard(10)
                .BuildBoard();

            var game = new SnakesAndLaddersGame(board);

            game.AddPlayer(new Player("Joopie"));

            do
            {
                game.NextTurn();
            } while (!game.IsGameWon);
        }
    }
}
