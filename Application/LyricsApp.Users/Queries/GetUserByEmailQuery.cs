
using LyricsApp.Users.Repositories;

using MediatR;

namespace LyricsApp.Users.Queries
{
    public class GetUserByEmailQuery : IRequest<Guid?>
    {
        public string Email { get; set; }

        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }

    }


    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, Guid?>
    {
        private readonly IUserRepository _userRepository;


        public GetUserByEmailQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid?> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.FindUserByEmail(request.Email, cancellationToken);

            return existingUser?.Id;
        }

    }
}