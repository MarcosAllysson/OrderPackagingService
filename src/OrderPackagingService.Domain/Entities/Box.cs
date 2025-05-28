using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderPackagingService.Domain.Entities
{
    public class Box
    {
        public string BoxId { get; set; }
        public Dimensions Dimensions { get; set; }
    }
}
