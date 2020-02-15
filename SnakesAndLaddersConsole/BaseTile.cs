using System.Collections.Generic;

namespace SnakesAndLaddersConsole
{
    public class BaseTile : ITile
    {
        public int TileNumber { get; }

        private readonly List<Player> _players;

        public BaseTile(int tileNumber)
        {
            TileNumber = tileNumber;
            _players = new List<Player>();
        }

        public virtual bool IsPlayerOnTile(Player player)
        {
            return _players.Contains(player);
        }

        public virtual void PlacePlayerOnTile(Player player)
        {
            if (!IsPlayerOnTile(player))
            {
                _players.Add(player);
            }
        }

        public virtual void RemovePlayerFromTile(Player player)
        {
            if (IsPlayerOnTile(player))
            {
                _players.Remove(player);
            }
        }
    }
}