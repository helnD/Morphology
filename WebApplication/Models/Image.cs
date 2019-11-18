using System.Linq;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Models
{
    public class Image
    {
        public Image(IQueryCollection query)
        {
            Model = new int[25][];
            for (int i = 0; i < 25; i++)
            {
                Model[i] = new int[25];
                for (var j = 0; j < Model[i].Length; j++)
                {
                    Model[i][j] = 0;
                }
            }
            
            for (int i = 0; i < (query.Count - 1) / 2; i++)
            {
                var x = int.Parse(query[$"x{i}"]);
                var y = int.Parse(query[$"y{i}"]);

                Model[y][x] = 1;
            }
        }

        public int[][] Model { get; }
        
    }
}