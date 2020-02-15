using System;

namespace SnakesAndLaddersConsole
{
    public class FinishTile : BaseTile
    {
        public FinishTile(int tileNumber)
            : base(tileNumber)
        {
        }

        public override void PlacePlayerOnTile(Player player)
        {
            base.PlacePlayerOnTile(player);

            Console.WriteLine($"{player} finished!");
        }
    }
}