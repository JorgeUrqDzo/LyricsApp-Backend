using LyricsApp.Core.Entities.Data;
using LyricsApp.Core.Entities.Entities;
using LyricsApp.Users.Repositories;

using MediatR;

namespace LyricsApp.Users.Commands;

public class CreateUserCommand : IRequest<Guid>
{
    public CreateUserCommand(string email, string authId, string? displayName)
    {
        Email = email;
        AuthId = authId;
        DisplayName = displayName ?? string.Empty;
    }

    public string Email { get; set; }
    public string AuthId { get; set; }
    public string DisplayName { get; set; }
}


public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.FindUserByEmail(request.Email, cancellationToken);

        if (existingUser == null)
        {
            var user = new User(Guid.NewGuid(), request.AuthId, request.Email, request.DisplayName);

            await _userRepository.RegisterUserAsync(user, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return user.Id;
        }

        return existingUser.Id;
    }
}