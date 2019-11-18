using System;
using System.Runtime.CompilerServices;

namespace Domain
{
    public class Pixel
    {
        private int _value;
        
        public Pixel(int value)
        {
            _value = value;
        }

        public Color Color
        {
            get
            {
                switch (_value)
                {
                    case 0: return new Color(255, 255, 255);
                    case 1: return new Color(15, 14, 14);
                    case 2: return new Color(125, 116, 109);
                    default: throw new Exception("Invalid pixel value for color");
                }
            }
        }

        public bool IsEmpty() => _value == 0;

        public static bool operator +(Pixel pixel1, Pixel pixel2) =>
            pixel1._value != pixel2._value;
    }
}