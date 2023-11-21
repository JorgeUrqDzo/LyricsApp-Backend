using LyricsApp.Auth.DTOs;
using LyricsApp.Auth.Services;

using MediatR;

namespace LyricsApp.Auth.Commands
{
    public class GoogleSignInCommand : IRequest<AuthResponse>
    {
        public GoogleSignInCommand(string email,
                                   string displayName,
                                   string idToken,
                                   string accessToken)
        {
            Email = email;
            DisplayName = displayName;
            IdToken = idToken;
            AccessToken = accessToken;
        }

        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string IdToken { get; set; }
        public string AccessToken { get; set; }
    }

    public class GoogleSignInCommandHandler : IRequestHandler<GoogleSignInCommand, AuthResponse>
    {
        private readonly IAuthenticationService _authenticationService;

        public GoogleSignInCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<AuthResponse> Handle(GoogleSignInCommand request,
                                               CancellationToken cancellationToken)
        {
            try
            {
                return await _authenticationService.GoogleSignInAsync(request.IdToken,
                                                                      request.AccessToken,
                                                                      cancellationToken);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}