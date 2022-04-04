using Application.Common.Interfaces;
using MediatR;
using StockManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockManagment.Application.ObjectTypes.Commands.CreateObjectType
{
    public class CreateObjectTypeCommand : IRequest
    {
         public string Code { get; set; }
         public string Remark { get; set; }
         public string Description { get; set; }
         public bool Active { get; set; }
    }

     public class CreateObjectTypeCommanHandler : IRequestHandler<CreateObjectTypeCommand>
     {
         private readonly IApplicationDbContext _context;

         public CreateObjectTypeCommanHandler(IApplicationDbContext context)
         {
             _context = context;
         }

         public async Task<Unit> Handle(CreateObjectTypeCommand request, CancellationToken cancellationToken)
         {
             var entity = new ObjectType
             {
                 Code = request.Code,
                 Active = request.Active,
                 Remark = request.Remark,
                 Description = request.Description
             };

             _context.ObjectTypes.Add(entity);

             await _context.SaveChangesAsync(cancellationToken);

             return Unit.Value;
         }

     }
}