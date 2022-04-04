using Application.Common.Interfaces;
using StockManagment.Domain.Entities;
using StockManagment.Application.Common.Exceptions;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace StockManagment.Application.Persons.Commands.UpdatePerson
{

    public class UpdatePersonCommand : IRequest
    {
        public string Code { get; set; }
        public string Remark { get; set; }
        public bool Active { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
    }

    public class UpdatePersonCommanHandler : IRequestHandler<UpdatePersonCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePersonCommanHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Persons
                  .FindAsync(new object[] { request.Code }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Person), request.Code);
            }

            entity.Active = request.Active;
            entity.Remark = request.Remark;
            entity.Type = request.Type;
            entity.Title = request.Title;
            entity.FirstName = request.FirstName;
            entity.MiddleName = request.MiddleName;
            entity.LastName = request.LastName;
            entity.Nationality = request.Nationality;
            entity.BirthDate = request.BirthDate;
            entity.Gender = request.Gender;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
