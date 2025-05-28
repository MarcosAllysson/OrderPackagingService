using System.Collections.Generic;
using System.Linq;
using OrderPackagingService.Domain.Entities;
using OrderPackagingService.Shared.Dtos;

namespace OrderPackagingService.Domain.Services
{
    public class PackingService : IPackingService
    {
        private readonly List<Box> _availableBoxes = new()
        {
            new Box { BoxId = "Box1", Dimensions = new Dimensions { Height = 30, Width = 40, Length = 80 } },
            new Box { BoxId = "Box2", Dimensions = new Dimensions { Height = 80, Width = 50, Length = 40 } },
            new Box { BoxId = "Box3", Dimensions = new Dimensions { Height = 50, Width = 80, Length = 60 } }
        };

        public List<OrderResponseDto> PackOrders(List<OrderRequestDto> orders)
        {
            var responses = new List<OrderResponseDto>();

            foreach (var order in orders)
            {
                var response = new OrderResponseDto { OrderId = order.OrderId };

                var products = order.Products.Select(p => new Product
                {
                    ProductId = p.ProductId,
                    Dimensions = new Dimensions
                    {
                        Height = p.Dimensions.Height,
                        Width = p.Dimensions.Width,
                        Length = p.Dimensions.Length
                    }
                }).ToList();

                var remainingProducts = new List<Product>(products);
                var boxes = new List<BoxResponseDto>();

                while (remainingProducts.Any())
                {
                    var bestBox = FindBestBox(remainingProducts);

                    if (bestBox == null)
                    {
                        boxes.Add(new BoxResponseDto
                        {
                            Observation = "No box can accommodate remaining products."
                        });

                        break;
                    }

                    var boxProducts = new List<string>();
                    var boxVolume = bestBox.Dimensions.Volume;
                    var usedVolume = 0;

                    for (int i = remainingProducts.Count - 1; i >= 0; i--)
                    {
                        var product = remainingProducts[i];

                        if (CanFit(product, bestBox, ref usedVolume))
                        {
                            boxProducts.Add(product.ProductId);
                            remainingProducts.RemoveAt(i);
                        }
                    }

                    boxes.Add(new BoxResponseDto
                    {
                        BoxId = bestBox.BoxId,
                        Products = boxProducts
                    });
                }

                response.Boxes = boxes;
                responses.Add(response);
            }

            return responses;
        }

        private Box FindBestBox(List<Product> products)
        {
            foreach (var box in _availableBoxes.OrderBy(b => b.Dimensions.Volume))
            {
                if (products.All(p => CanFitInBox(p, box)))
                    return box;
            }

            return null;
        }

        private bool CanFitInBox(Product product, Box box)
        {
            return product.Dimensions.Height <= box.Dimensions.Height &&
                   product.Dimensions.Width <= box.Dimensions.Width &&
                   product.Dimensions.Length <= box.Dimensions.Length;
        }

        private bool CanFit(Product product, Box box, ref int usedVolume)
        {
            if (CanFitInBox(product, box))
            {
                usedVolume += product.Dimensions.Volume;
                return usedVolume <= box.Dimensions.Volume;
            }

            return false;
        }
    }
}