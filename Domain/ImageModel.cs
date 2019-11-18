using System;

namespace Domain
{
    public class ImageModel : IGrid
    {
        private Pixel[][] _pixels;

        public ImageModel(int[][] values)
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

        public int Height { get; }
        public int Width { get; }

        public Color[][] ColorMatrix()
        {
            var matrix = new Color[Height][];

            for (int y = 0; y < Height; y++)
            {
                matrix[y] = new Color[Width];
                for (int x = 0; x < Width; x++)
                {
                    matrix[y][x] = this[x, y].Color;
                }
            }

            return matrix;
        }

        public Pixel this[int x, int y] => _pixels[y][x];
    }
}