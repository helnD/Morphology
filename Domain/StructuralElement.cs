﻿namespace Domain
{
    public class StructuralElement : IGrid
    {
        private Pixel[][] _pixels;

        public StructuralElement(int[][] values)
        {

            Height = values.Length;
            Width = values[0].Length;
            
            _pixels = new Pixel[Height][];

            for (var i = 0; i < values.Length; i++)
            {
                _pixels[i] = new Pixel[Width];
                for (var j = 0; j < _pixels[i].Length; j++)
                {
                    _pixels[i][j] = new Pixel(values[i][j]);
                }
            }
        }

        public int Width { get; }

        public int Height { get; }

        public Pixel this[int x, int y] => _pixels[y][x];
    }
}