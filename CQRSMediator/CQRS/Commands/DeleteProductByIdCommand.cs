﻿using CQRSMediator.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediator.CQRS.Commands
{
    public class DeleteProductByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
        {
            private readonly ProductContext context;
            public DeleteProductByIdCommandHandler(ProductContext context)
            {
                this.context = context;
            }

            public async Task<int> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
            {
                var product = await context.Products.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                context.Products.Remove(product);
                await context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}
