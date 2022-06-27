using StockManagment.Domain.Entities;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Application.Common.Interfaces;
using System;
using System.Linq;

namespace StockManagment.Application.Persons.Commands.CreatePerson
{

    public class CreatePersonCommand : IRequest
    {
        public string Code { get; set; } = string.Empty;
        public string Remark { get; set; } = string.Empty;
        public bool Active { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = string.Empty;
    }

    public class CreatePersonCommanHandler : IRequestHandler<CreatePersonCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreatePersonCommanHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = new Person
            {
                Code = request.Code,
                Active = request.Active,
                Remark = request.Remark,
                Type = request.Type,
                Title = request.Title,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                Nationality = request.Nationality,
                BirthDate = request.BirthDate,
                Gender = request.Gender
            };

            if (_context.Persons.All(x => x.Code != request.Code))
            {
                _context.Persons.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
