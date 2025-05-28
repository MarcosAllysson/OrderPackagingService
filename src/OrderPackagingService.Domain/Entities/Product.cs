using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderPackagingService.Domain.Entities
{
    public class Product
    {
        public string ProductId { get; set; }
        public Dimensions Dimensions { get; set; }
    }
}
