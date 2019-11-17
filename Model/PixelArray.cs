using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class PixelArray
    {
        private int _xSize;
        private int _ySize;
        private List<Pixel> _pixels;

        public PixelArray(int xSize, int ySize, List<Pixel> pixels)
        {
            _xSize = xSize;
            _ySize = ySize;
            _pixels = pixels;
        }


        public List<Pixel> VirtualArrayValue
        {
            get
            {
                List<Pixel> result = new List<Pixel>();
                
                for (int i = 0; i < _ySize; i++)
                {
                    for (int j = 0; j < _xSize; j++)
                    {
                        if (_pixels.Any(it => it.X == j && it.Y == i))
                        {
                            var pixel = _pixels.Find(it => it.X == j && it.Y == i);
                            result.Add(pixel.WithNewCoordinate(pixel.X + 1, pixel.Y + 1));
                        }
                        else
                        {
                            result.Add(new Pixel(new Color(0, 0, 0), j + 1, i + 1));
                        }
                    }
                }

                

                return result;
            }
        }
        
        public List<Pixel> ArrayValue
        {
            get
            {
                List<Pixel> result = new List<Pixel>();
                
                for (int i = 0; i < _ySize; i++)
                {
                    for (int j = 0; j < _xSize; j++)
                    {
                        if (_pixels.Any(it => it.X == j && it.Y == i))
                        {
                            result.Add(_pixels.Find(it => it.X == j && it.Y == i));
                        }
                        else
                        {
                            result.Add(new Pixel(new Color(0, 0, 0), j, i));
                        }
                    }
                }

                return result;
            }
        }
    }
}