using LyricsApp.Users.Services;
using MediatR;

namespace LyricsApp.Users.Commands;

public class CreateUserCommand : IRequest<string>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
}


public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
{
    private readonly IAuthenticationService authenticationService;

    public CreateUserCommandHandler(IAuthenticationService authenticationService)
    {
        this.authenticationService = authenticationService;
    }

    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var identityId = await authenticationService.RegisterAsync(request.Email, request.Password, request.Name);

        return identityId;
    }
}