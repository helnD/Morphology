using System.Xml.Linq;

namespace Domain
{
    public interface IGrid
    {
        Pixel this[int x, int y] {get;}
    }
}