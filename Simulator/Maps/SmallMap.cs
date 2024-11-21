﻿namespace Simulator.Maps
{
    public abstract class SmallMap : Map
    {
        private List<Creature>?[,] _fields;

        protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide (X)");
            if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too tall (Y)");

            _fields = new List<Creature>?[sizeX, sizeY];
        }
    }
}