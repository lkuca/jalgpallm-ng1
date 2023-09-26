using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpallmäng
{
    public class Stadium
    {
        public Stadium(int width, int height)
        {
            Width = width;
            Height = height;
            
        }
        

        public int Width { get; }

        public int Height { get; }

        public bool IsIn(double x, double y) //True False- pall põllu väljas
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }
    }
}
