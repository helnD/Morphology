using System;

namespace Model
{
    public class Pixel
    {
        public Pixel(Color color, int x, int y)
        {

            if (x < 0 || y < 0)
            {
                throw new Exception("Pixel can't have negative value");
            }
            
            Color = color;
            X = x;
            Y = y;
        }

        public Color Color { get; }
        public int X { get; }
        public int Y { get; }

        public Pixel WithNewCoordinate(int x, int y)
        {
            return new Pixel(this.Color, x, y);
        }
        
    }
}