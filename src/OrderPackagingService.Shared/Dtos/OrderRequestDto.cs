using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderPackagingService.Shared.Dtos
{
    public class OrderRequestDto
    {
        public int OrderId { get; set; }
        public List<ProductRequestDto> Products { get; set; } = new List<ProductRequestDto>();
    }
}
