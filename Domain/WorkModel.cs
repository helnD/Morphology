namespace Domain
{
    public class WorkModel : IGrid
    {
        private Pixel[][] _pixels;

        public WorkModel(ImageModel model)
        {

            Height = model.Height;
            Width = model.Width;
            
            _pixels = new Pixel[Height][];

            for (var i = 0; i < model.Height; i++)
            {
                _pixels[i] = new Pixel[Width];
                for (var j = 0; j < model.Width; j++)
                {
                    _pixels[i][j] = model[j, i].IsEmpty() ? new Pixel(0) : new Pixel(1);
                }
            }
        }

        public int Height { get; }
        public int Width { get; }
        
        public ImageModel Increasing(StructuralElement element)
        {
            int[][] pixels = new int[Height][];
            
            for (var y = 0; y < _pixels.Length; y++)
            {
                pixels[y] = new int[Width];
                for (int x = 0; x < _pixels[y].Length; x++)
                {
                    if (AnyEquals(x, y, element))
                    {
                        pixels[y][x] = _pixels[y][x].IsEmpty() ? 2 : 1;
                    }
                    else
                    {
                        pixels[y][x] = 0;
                    }
                }
            }
            
            return new ImageModel(pixels);
        }
        
        public ImageModel Erosion(StructuralElement element)
        {
            int[][] pixels = new int[Height][];
            
            for (var y = 0; y < _pixels.Length; y++)
            {
                pixels[y] = new int[Width];
                for (int x = 0; x < _pixels[y].Length; x++)
                {
                    pixels[y][x] = AllEquals(x, y, element) ? 1 : 0;
                }
            }
            
            return new ImageModel(pixels);
        }

        public ImageModel Closing(StructuralElement element)
        {
            return new WorkModel(Increasing(element)).Erosion(element);
        }
        
        public ImageModel Opening(StructuralElement element)
        {
            return new WorkModel(Erosion(element)).Increasing(element);
        }

        private bool AllEquals(int x, int y, StructuralElement element)
        {
            var offsetTop = element.Height / 2;
            var offsetLeft = element.Width / 2;

            for (int yM = y - offsetTop, yE = 0; yE < element.Height; yM++, yE++)
            {
                for (int xM = x - offsetLeft, xE = 0; xE < element.Width; xM++, xE++)
                {
                    if (element[xE, yE] + this[xM, yM]) return false;
                }  
            }

            return true;
        }
        
        private bool AnyEquals(int x, int y, StructuralElement element)
        {
            var offsetTop = element.Height / 2;
            var offsetLeft = element.Width / 2;

            for (int yM = y - offsetTop, yE = 0; yE < element.Height; yM++, yE++)
            {
                for (int xM = x - offsetLeft, xE = 0; xE < element.Height; xM++, xE++)
                {
                    if (!(element[xE, yE] + this[xM, yM])) return true;
                }  
            }

            return false;
        }

        public Pixel this[int x, int y]
        {
            get
            {
                if (x < 0) x = 0;
                if (y < 0) y = 0;
                if (x >= Width) x = Width - 1;
                if (y >= Height) y = Height - 1;

                return _pixels[y][x];
            }
        }

    }
}