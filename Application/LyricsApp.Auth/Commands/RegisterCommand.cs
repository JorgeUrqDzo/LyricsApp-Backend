using LyricsApp.Auth.DTOs;
using LyricsApp.Auth.Services;

using MediatR;

namespace LyricsApp.Auth.Commands
{
    public class RegisterCommand: IRequest<AuthResponse>
    {
        public RegisterCommand(string email, string password, string? displayName)
        {
            Email = email;
            Password = password;
            DisplayName = displayName;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string? DisplayName { get; set; }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResponse>
    {
        private readonly IAuthenticationService _authenticationService;

        public RegisterCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public async Task<AuthResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = await _authenticationService.RegisterAsync(request.Email, request.Password, cancellationToken);
            return user;
        }
    }
}