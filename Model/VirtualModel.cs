using System;

namespace Model
{
    public class VirtualModel : IModel
    {
        
        
        
        public Pixel this[int x, int y]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public IModel Bypass(Action<IModel, int, int> coordinates)
        {
            throw new NotImplementedException();
        }
    }
}