using System;

namespace Model
{
    public interface IModel
    {
        Pixel this[int x, int y] { get; set; }

        IModel Bypass(Action<IModel, int, int> coordinates);
    }

}