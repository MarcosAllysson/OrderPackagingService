using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderPackagingService.Domain.Entities
{
    public class Product
    {
        public required string ProductId { get; set; }
        public required Dimensions Dimensions { get; set; }
    }
}
