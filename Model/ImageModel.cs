using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class ImageModel : IModel
    {

        private List<Pixel> _pixels;

        public ImageModel(List<Pixel> pixels)
        {
            Width = pixels.Max(it => it.X) + 1;
            Height = pixels.Max(it => it.Y) + 1;

            _pixels = new PixelArray(Width, Height, pixels).ArrayValue;
        }

        public int Width { get; }
        public int Height { get; }

        public Pixel this[int x, int y]
        {
            get
            {
                if (y >= Height || x >= Width || y < 0 || x < 0)
                {
                    throw new Exception("index out of model");
                }

                return _pixels.Single(it => it.X == x && it.Y == y);
            }

            set
            {
                _pixels.Remove(this[x, y]);
                _pixels.Add(value);
            }
        }

        public IModel Bypass(Action<IModel, int, int> action)
        {
            var model = new ImageModel(_pixels);

            for (int i = 0; i < model.Height; i++)
            {
                for (int j = 0; j < model.Width; j++)
                {
                    action(model, j, i);
                }
            }

            return model;
        }
    }
}