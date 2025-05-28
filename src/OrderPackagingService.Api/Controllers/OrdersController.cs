using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderPackagingService.Domain.Services;
using OrderPackagingService.Shared.Dtos;

namespace OrderPackagingService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IPackingService _packingService;

        public OrdersController(IPackingService packingService)
        {
            _packingService = packingService;
        }

        [Authorize]
        [HttpPost("pack")]
        public IActionResult PackOrders(List<OrderRequestDto> orders)
        {
            try
            {
                return Ok(_packingService.PackOrders(orders));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
