using LyricsApp.Auth.Services;

using MediatR;

namespace LyricsApp.Auth.Commands
{
    public class SignOutCommand: IRequest<Unit>
    {

    }

    public class SignOutCommandHandler : IRequestHandler<SignOutCommand, Unit>
    {
        private readonly IAuthenticationService _authenticationService;


        public SignOutCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;

        }

        public async Task<Unit> Handle(SignOutCommand request, CancellationToken cancellationToken)
        {
            await _authenticationService.SignOut(cancellationToken);

            return Unit.Value;
        }

    }
}