using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Authentication.Commands.Register
{
    public class RegisterCommand : IRequest<bool>
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, bool>
    {
        private readonly IIdentityService _service;
        private readonly IApplicationDbContext _context;

        public RegisterCommandHandler(IIdentityService service, IApplicationDbContext context)
        {
            _service = service;
            _context = context;
        }

        public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.CreateUserAsync(request.UserName, request.Password);

            try
            {
                if (result.Result)
                {
                    await _service.AddUserToRole(result.UserId, request.RoleName);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }

}
