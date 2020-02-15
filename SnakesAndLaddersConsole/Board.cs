using System;

namespace SnakesAndLaddersConsole
{
    public class Board
    {
        private readonly ITile[,] _tiles;

        public Board(ITile[,] tiles)
        {
            _tiles = tiles;
        }

        public ITile GetTileFromNumber(int tileNumber)
        {
            var width = _tiles.GetUpperBound(0) + 1;
            var height = _tiles.GetUpperBound(1) + 1;

            var tileIndex = Math.Min(tileNumber, width * height) - 1;

            var x = tileIndex % width;
            var y = tileIndex / width;

            return _tiles[x, y];
        }
    }
}