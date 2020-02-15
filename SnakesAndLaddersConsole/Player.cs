using System;

namespace SnakesAndLaddersConsole
{
    public class Player
    {
        private static readonly Random _random = new Random();

        public string Name { get; }

        public bool IsPlayerFinished => _currentTile is FinishTile;

        private ITile _currentTile;

        public Player(string name)
        {
            Name = name;
        }

        public void RollDiceAndMove(int turn, Board board)
        {
            var randomDiceRoll = _random.Next(1, 7);

            var nextTileNumber = (_currentTile?.TileNumber ?? 1) + randomDiceRoll;

            MoveToTile(nextTileNumber, board);
        }

        public void MoveToTile(int tileNumber, Board board)
        {
            _currentTile?.RemovePlayerFromTile(this);

            _currentTile = board.GetTileFromNumber(tileNumber);

            _currentTile.PlacePlayerOnTile(this);
        }

        public void MoveToTile(ITile tile)
        {
            _currentTile?.RemovePlayerFromTile(this);

            _currentTile = tile;

            _currentTile.PlacePlayerOnTile(this);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}