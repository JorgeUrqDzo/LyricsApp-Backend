using System.IdentityModel.Tokens.Jwt;

using LyricsApp.Auth.DTOs;
using LyricsApp.Auth.Services;

using MediatR;

namespace LyricsApp.Auth.Commands
{
    public class JwtTokenGeneratorCommand : IRequest<AuthResponseDto>
    {
        public JwtTokenGeneratorCommand(AuthResponseDto data)
        {
            JwtToken = data.AccessToken;
            UserId = data.UserId;
            RefreshToken = data.RefreshToken;
        }

        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
        public Guid UserId { get; set; }
    }

    public class JwtTokenGeneratorCommandHandler : IRequestHandler<JwtTokenGeneratorCommand, AuthResponseDto>
    {
        private readonly IJwtTokenGeneratorService _jwtTokenGeneratorService;

        public JwtTokenGeneratorCommandHandler(IJwtTokenGeneratorService jwtTokenGeneratorService)
        {
            _jwtTokenGeneratorService = jwtTokenGeneratorService;
        }

        public Task<AuthResponseDto> Handle(JwtTokenGeneratorCommand request, CancellationToken cancellationToken)
        {
            var result = _jwtTokenGeneratorService.CreateSecurityToken(new JwtSecurityToken(request.JwtToken), request.UserId.ToString());

            var jwt = new AuthResponseDto(result, request.RefreshToken, request.UserId);

            return Task.FromResult(jwt);
        }
    }
}