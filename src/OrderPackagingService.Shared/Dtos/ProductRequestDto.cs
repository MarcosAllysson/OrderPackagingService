using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderPackagingService.Shared.Dtos
{
    public class ProductRequestDto
    {
        public string ProductId { get; set; } = null;
        public DimensionsDto Dimensions { get; set; } = new DimensionsDto();
    }
}
