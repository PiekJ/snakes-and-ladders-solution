using System;

namespace SnakesAndLaddersConsole
{
    public class MoveToTile : BaseTile
    {
        public bool IsLadder => TileNumber < _moveToTile.TileNumber;

        private readonly ITile _moveToTile;

        public MoveToTile(int tileNumber, ITile moveToTile)
            : base(tileNumber)
        {
            _moveToTile = moveToTile;
        }

        public override void PlacePlayerOnTile(Player player)
        {
            base.PlacePlayerOnTile(player);

            Console.WriteLine($"{player} moved on {(IsLadder ? "ladder" : "snake")} and went from {TileNumber} to {_moveToTile.TileNumber}.");

            player.MoveToTile(_moveToTile);
        }
    }
}