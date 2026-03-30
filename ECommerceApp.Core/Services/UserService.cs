using AutoMapper;
using ECommerceApp.Core.DTO;
using ECommerceApp.Core.Entities;
using ECommerceApp.Core.RepositoryContracts;
using ECommerceApp.Core.ServiceContracts;

namespace ECommerceApp.Core.Services;

public class UserService : IUserService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;
    public UserService(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public async Task<UserDTO> GetUserByUserID(Guid userID)
    {
       ApplicationUser? user = await _usersRepository.GetUserByUserID(userID);
       return _mapper.Map<UserDTO>(user);
    }

    public async Task<AuthenticationResponse?> LoginUser(LoginRequest loginRequest)
    {
        ApplicationUser? user = await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

        if (user == null)
        {
            return null;
        }

        return _mapper.Map<AuthenticationResponse>(user) with {
        Success = true,
        Token = "Token"
        };
    }

    public async Task<AuthenticationResponse?> RegisterUser(RegisterRequest registerRequest)
    {
        ApplicationUser user = _mapper.Map<ApplicationUser>(registerRequest);

        ApplicationUser? registeredUser = await _usersRepository.AddUser(user);

        if (registeredUser == null)
        {
            return null;
        }

        return _mapper.Map<AuthenticationResponse>(registeredUser) with
        {
            Success = true,
            Token = "Token"
        };
    }
}

