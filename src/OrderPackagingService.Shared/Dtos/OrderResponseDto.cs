using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderPackagingService.Shared.Dtos
{
    public class OrderResponseDto
    {
        public int OrderId { get; set; }
        public List<BoxResponseDto> Boxes { get; set; } = new List<BoxResponseDto>();
    }
}
