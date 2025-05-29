using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderPackagingService.Shared.Dtos
{
    public class BoxResponseDto
    {
        public string BoxId { get; set; } = null;
        public string Observation { get; set; } = null;
        public List<string> Products { get; set; } = new List<string>();
    }
}
