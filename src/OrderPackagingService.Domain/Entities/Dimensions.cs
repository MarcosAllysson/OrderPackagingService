using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderPackagingService.Domain.Entities
{
    public class Dimensions
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }

        public int Volume => Height * Width * Length;
    }
}
