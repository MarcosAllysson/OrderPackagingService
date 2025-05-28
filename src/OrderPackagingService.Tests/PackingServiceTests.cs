using System.Collections.Generic;
using OrderPackagingService.Domain.Entities;
using OrderPackagingService.Domain.Services;
using OrderPackagingService.Shared.Dtos;
using Xunit;

namespace OrderPackagingService.Tests
{
    public class PackingServiceTests
    {
        private readonly PackingService _service = new PackingService();

        [Fact]
        public void PackOrders_SingleProduct_FitsInBox()
        {
            var orders = new List<OrderRequestDto>
            {
                new OrderRequestDto
                {
                    OrderId = 1,
                    Products = new List<ProductRequestDto>
                    {
                        new ProductRequestDto
                        {
                            ProductId = "TestProduct",
                            Dimensions = new DimensionsDto { Height = 10, Width = 10, Length = 10 }
                        }
                    }
                }
            };

            var result = _service.PackOrders(orders);

            Assert.Single(result);
            Assert.Equal(1, result[0].OrderId);

            Assert.Single(result[0].Boxes);
            Assert.Equal("Box1", result[0].Boxes[0].BoxId);

            Assert.Single(result[0].Boxes[0].Products);
            Assert.Equal("TestProduct", result[0].Boxes[0].Products[0]);
        }
    }
}