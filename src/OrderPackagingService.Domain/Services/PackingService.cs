using System;
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
            new Box { BoxId = "Caixa 1", Dimensions = new Dimensions { Height = 30, Width = 40, Length = 80 } }, 
            new Box { BoxId = "Caixa 2", Dimensions = new Dimensions { Height = 80, Width = 50, Length = 40 } }, 
            new Box { BoxId = "Caixa 3", Dimensions = new Dimensions { Height = 50, Width = 80, Length = 60 } }  
        };

        public List<OrderResponseDto> PackOrders(List<OrderRequestDto> orders)
        {
            var responses = new List<OrderResponseDto>();
            var largestBoxVolume = _availableBoxes.Max(b => b.Dimensions.Volume); 

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

                var remainingProducts = new List<Product>(products.OrderByDescending(p => p.Dimensions.Volume));
                var boxes = new List<BoxResponseDto>();

                while (remainingProducts.Any())
                {
                    var product = remainingProducts.First();

                    var bestBox = _availableBoxes
                        .Where(b => CanFitInBox(product, b))
                        .OrderBy(b => b.Dimensions.Volume)
                        .FirstOrDefault();

                    if (bestBox == null)
                    {
                        boxes.Add(new BoxResponseDto
                        {
                            BoxId = null,
                            Observation = "Produto não cabe em nenhuma caixa disponível.",
                            Products = new List<string> { product.ProductId }
                        });

                        remainingProducts.Remove(product);

                        continue;
                    }

                    var boxProducts = new List<Product> { product };
                    remainingProducts.Remove(product);
                    var boxVolume = bestBox.Dimensions.Volume;
                    var usedVolume = product.Dimensions.Volume;

                    // Só combina produtos se o primeiro não for grande
                    if (product.Dimensions.Volume <= 0.5 * largestBoxVolume)
                    {
                        for (int i = remainingProducts.Count - 1; i >= 0; i--)
                        {
                            var otherProduct = remainingProducts[i];

                            if (CanFitInBox(otherProduct, bestBox) &&
                                usedVolume + otherProduct.Dimensions.Volume <= boxVolume &&
                                otherProduct.Dimensions.Volume <= 0.5 * largestBoxVolume) // Só combina com pequenos
                            {
                                boxProducts.Add(otherProduct);
                                usedVolume += otherProduct.Dimensions.Volume;
                                remainingProducts.RemoveAt(i);
                            }
                        }
                    }

                    if (boxProducts.Sum(p => p.Dimensions.Volume) > 96000 && bestBox.BoxId == "Caixa 1")
                        bestBox = _availableBoxes.First(b => b.BoxId == "Caixa 2");

                    boxes.Add(new BoxResponseDto
                    {
                        BoxId = bestBox.BoxId,
                        Products = boxProducts.Select(p => p.ProductId).ToList()
                    });
                }

                response.Boxes = boxes;
                responses.Add(response);
            }

            return responses;
        }

        private bool CanFitInBox(Product product, Box box)
        {
            var productDims = new[] 
            { 
                product.Dimensions.Height, 
                product.Dimensions.Width, 
                product.Dimensions.Length 
            }.OrderBy(d => d).ToArray();

            var boxDims = new[] 
            { 
                box.Dimensions.Height, 
                box.Dimensions.Width, 
                box.Dimensions.Length 
            }.OrderBy(d => d).ToArray();

            return productDims[0] <= boxDims[0] && productDims[1] <= boxDims[1] && productDims[2] <= boxDims[2];
        }
    }
}