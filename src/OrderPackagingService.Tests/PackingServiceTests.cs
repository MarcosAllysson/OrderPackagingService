using Xunit;
using System.Collections.Generic;
using OrderPackagingService.Domain.Entities;
using OrderPackagingService.Domain.Services;
using OrderPackagingService.Shared.Dtos;

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

        [Fact]
        public void PackOrders_MultipleProducts_SplitIntoBoxes()
        {
            var orders = new List<OrderRequestDto>
            {
                new OrderRequestDto
                {
                    OrderId = 2,
                    Products = new List<ProductRequestDto>
                    {
                        new ProductRequestDto
                        {
                            ProductId = "Monitor",
                            Dimensions = new DimensionsDto { Height = 50, Width = 60, Length = 20 }
                        },
                        new ProductRequestDto
                        {
                            ProductId = "Webcam",
                            Dimensions = new DimensionsDto { Height = 7, Width = 10, Length = 5 }
                        }
                    }
                }
            };

            var result = _service.PackOrders(orders);

            Assert.Single(result);
            Assert.Equal(2, result[0].OrderId);
            Assert.Equal(2, result[0].Boxes.Count);

            Assert.Contains(result[0].Boxes, b => b.BoxId == "Box3" && b.Products.Contains("Monitor"));
            Assert.Contains(result[0].Boxes, b => b.BoxId == "Box1" && b.Products.Contains("Webcam"));
        }

        [Fact]
        public void PackOrders_LargeProduct_NoBoxAvailable()
        {
            var orders = new List<OrderRequestDto>
            {
                new OrderRequestDto
                {
                    OrderId = 3,
                    Products = new List<ProductRequestDto>
                    {
                        new ProductRequestDto
                        {
                            ProductId = "Cadeira Gamer",
                            Dimensions = new DimensionsDto { Height = 120, Width = 60, Length = 70 }
                        }
                    }
                }
            };

            var result = _service.PackOrders(orders);

            Assert.Single(result);
            Assert.Equal(3, result[0].OrderId);

            Assert.Single(result[0].Boxes);
            Assert.Null(result[0].Boxes[0].BoxId);

            Assert.Equal("No box can accommodate remaining products.", result[0].Boxes[0].Observation);
            Assert.Equal("Cadeira Gamer", result[0].Boxes[0].Products[0]);
        }

        [Fact]
        public void PackOrders_EmptyOrder_ReturnsEmptyBoxes()
        {
            var orders = new List<OrderRequestDto>
            {
                new OrderRequestDto
                {
                    OrderId = 4,
                    Products = new List<ProductRequestDto>()
                }
            };

            var result = _service.PackOrders(orders);

            Assert.Single(result);
            Assert.Equal(4, result[0].OrderId);
            Assert.Empty(result[0].Boxes);
        }
    }
}