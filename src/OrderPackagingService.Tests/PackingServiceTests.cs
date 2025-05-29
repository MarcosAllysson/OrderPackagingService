using System.Collections.Generic;
using OrderPackagingService.Domain.Entities;
using OrderPackagingService.Domain.Services;
using OrderPackagingService.Shared.Dtos;
using Xunit;

namespace OrderPackagingService.Tests
{
    public class PackingServiceTests
    {
        private readonly PackingService _service = new();

        [Fact]
        public void PackOrders_SingleLargeProduct_PacksAlone()
        {
            var order = new OrderRequestDto
            {
                OrderId = 1,
                Products = new List<ProductRequestDto>
                {
                    new() { ProductId = "Monitor", Dimensions = new DimensionsDto { Height = 40, Width = 60, Length = 80 } }
                }
            };

            var result = _service.PackOrders(new List<OrderRequestDto> { order });

            Assert.Single(result[0].Boxes);
            Assert.Equal("Monitor", result[0].Boxes[0].Products[0]);
        }

        [Fact]
        public void PackOrders_LargeAndSmallProduct_SplitsIntoTwoBoxes()
        {
            var order = new OrderRequestDto
            {
                OrderId = 2,
                Products = new List<ProductRequestDto>
                {
                    new() { ProductId = "Monitor", Dimensions = new DimensionsDto { Height = 40, Width = 60, Length = 80 } },
                    new() { ProductId = "Webcam", Dimensions = new DimensionsDto { Height = 10, Width = 10, Length = 10 } }
                }
            };

            var result = _service.PackOrders(new List<OrderRequestDto> { order });
            Assert.Equal(2, result[0].Boxes.Count);
        }
    }
}