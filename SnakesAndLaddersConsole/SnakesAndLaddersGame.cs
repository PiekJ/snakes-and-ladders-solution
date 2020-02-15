using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakesAndLaddersConsole
{
    public class SnakesAndLaddersGame
    {
        public bool IsPlaying => _turn > 0;

        public bool IsGameWon => _players.Any(x => x.IsPlayerFinished);

        public Player Winner => _players.Single(x => x.IsPlayerFinished);

        private readonly Board _board;

        private readonly List<Player> _players;

        private int _turn;

        public SnakesAndLaddersGame(Board board)
        {
            _board = board;
            _players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            if (IsPlaying)
            {
                throw new Exception("Unable to add player to ongoing game!");
            }

            _players.Add(player);
        }

        public void NextTurn()
        {
            if (IsGameWon)
            {
                throw new Exception("Game is already won by a player!");
            }

            _turn++;

            Console.WriteLine($"Playing round {_turn}.");

            foreach (var player in _players)
            {
                player.RollDiceAndMove(_turn, _board);

                if (player.IsPlayerFinished)
                {
                    break;
                }
            }
        }
    }
}