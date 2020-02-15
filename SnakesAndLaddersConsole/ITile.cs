namespace SnakesAndLaddersConsole
{
    public interface ITile
    {
        int TileNumber { get; }

        bool IsPlayerOnTile(Player player);

        void PlacePlayerOnTile(Player player);

        void RemovePlayerFromTile(Player player);
    }
}