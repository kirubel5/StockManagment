using Application.Common.Interfaces;
using Application.Common.Models.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Authentication.Commands.Login
{
    
    public class LoginCommand : IRequest<AuthenticationResponse>
    {        
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthenticationResponse>
    {
        private readonly IIdentityService _identityService;
       
        public LoginCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }            
                
        public async Task<AuthenticationResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.GetJwtForUserAsync(request.Username, request.Password);

            if (result == null)
            {
                throw new Exception($"Unable to forge a JWT for the user '{ request.Username }'");
            }

            return result;
        }
    }
}
