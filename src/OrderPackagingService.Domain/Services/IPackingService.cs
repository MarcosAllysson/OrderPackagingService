using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderPackagingService.Shared.Dtos;

namespace OrderPackagingService.Domain.Services
{
    public interface IPackingService
    {
        List<OrderResponseDto> PackOrders(List<OrderRequestDto> orders);
    }
}
