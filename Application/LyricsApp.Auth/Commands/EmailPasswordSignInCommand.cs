using LyricsApp.Auth.DTOs;
using LyricsApp.Auth.Services;

using MediatR;

namespace LyricsApp.Auth.Commands
{
    public class EmailPasswordSignInCommand : IRequest<AuthResponse>
    {
        public EmailPasswordSignInCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }


        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class EmailPasswordSignInCommandHandler : IRequestHandler<EmailPasswordSignInCommand, AuthResponse>
    {
        private readonly IAuthenticationService _authenticationService;


        public EmailPasswordSignInCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<AuthResponse> Handle(EmailPasswordSignInCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.EmailPasswordSignIn(request.Email, request.Password, cancellationToken);

            return result;
        }
    }
}