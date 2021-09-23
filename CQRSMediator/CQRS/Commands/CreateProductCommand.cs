using CQRSMediator.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediator.CQRS.Commands
{
    public class CreateProductCommand :  IRequest<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {
            private readonly ProductContext context;
            public CreateProductCommandHandler(ProductContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var product = new Product
                {
                    Name = command.Name,
                    Price = command.Price
                };

                context.Products.Add(product);
                await context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}
