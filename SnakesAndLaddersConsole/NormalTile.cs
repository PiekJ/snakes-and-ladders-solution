using System;

namespace SnakesAndLaddersConsole
{
    public class NormalTile : BaseTile
    {
        public NormalTile(int tileNumber)
            : base(tileNumber)
        {
        }

        public override void PlacePlayerOnTile(Player player)
        {
            base.PlacePlayerOnTile(player);

            Console.WriteLine($"{player} moved on tile {TileNumber}.");
        }
    }
}