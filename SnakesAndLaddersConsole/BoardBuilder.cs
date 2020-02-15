using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace SnakesAndLaddersConsole
{
    public class BoardBuilder
    {
        private readonly int _width;

        private readonly int _height;

        private readonly Dictionary<int, int> _moveToTiles;

        private int MaxTileNumber => _width * _height;

        public BoardBuilder(int width, int height)
        {
            _width = width;
            _height = height;
            _moveToTiles = new Dictionary<int, int>();
        }

        public BoardBuilder GenerateRandomBoard(int density, int seed = 0)
        {
            var amountOfMoves = _width * _height / 100 * density;

            var random = new Random(seed);

            for (var i = 0; i < amountOfMoves; i++)
            {
                int fromTileNumber;
                int toTileNumber;

                do
                {
                    fromTileNumber = random.Next(1, MaxTileNumber);
                } while (_moveToTiles.ContainsKey(fromTileNumber));

                do
                {
                    toTileNumber = random.Next(1, MaxTileNumber);
                } while (fromTileNumber == toTileNumber);

                _moveToTiles.Add(fromTileNumber, toTileNumber);
            }

            return this;
        }

        public BoardBuilder AddSnake(int fromTileNumber, int toTileNumber)
        {
            if (fromTileNumber < toTileNumber)
            {
                throw new ArgumentException("Snakes aren't ladders!", nameof(toTileNumber));
            }

            if (_moveToTiles.ContainsKey(fromTileNumber))
            {
                throw new ArgumentException("Tile already in use", nameof(fromTileNumber));
            }

            _moveToTiles.Add(fromTileNumber, toTileNumber);

            return this;
        }

        public BoardBuilder AddLadder(int fromTileNumber, int toTileNumber)
        {
            if (fromTileNumber > toTileNumber)
            {
                throw new ArgumentException("Ladders aren't snakes!", nameof(toTileNumber));
            }

            if (_moveToTiles.ContainsKey(fromTileNumber))
            {
                throw new ArgumentException("Tile already in use", nameof(fromTileNumber));
            }

            _moveToTiles.Add(fromTileNumber, toTileNumber);

            return this;
        }

        public Board BuildBoard()
        {
            var tiles = new ITile[_width, _height];

            var finishPosition = GetPositionFromTileNumber(MaxTileNumber, _width, _height);

            tiles[finishPosition.x, finishPosition.y] = new FinishTile(MaxTileNumber);

            for (var i = 0; i < MaxTileNumber - 1; i++)
            {
                var tileNumber = i + 1;

                if (_moveToTiles.ContainsKey(tileNumber))
                {
                    continue;
                }

                var position = GetPositionFromTileNumber(tileNumber, _width, _height);

                tiles[position.x, position.y] = new NormalTile(tileNumber);
            }

            foreach (var (fromTileNumber, toTileNumber) in _moveToTiles)
            {
                var fromPosition = GetPositionFromTileNumber(fromTileNumber, _width, _height);
                var toPosition = GetPositionFromTileNumber(toTileNumber, _width, _height);

                var toTile = tiles[toPosition.x, toPosition.y];

                if (toTile == null)
                {
                    throw new InvalidOperationException("This shouldn't happen!");
                }

                tiles[fromPosition.x, fromPosition.y] = new MoveToTile(fromTileNumber, toTile);
            }

            return new Board(tiles);
        }

        private static (int x, int y) GetPositionFromTileNumber(int tileNumber, int width, int height)
        {
            if (tileNumber > width * height)
            {
                throw new ArgumentException("TileNumber exceeds max possible size.");
            }

            return ((tileNumber - 1) % width, (tileNumber - 1) / width);
        }
    }
}