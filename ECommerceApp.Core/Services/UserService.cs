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

    public async Task<AuthenticationResponse?> LoginUser(LoginRequest loginRequest)
    {
        ApplicationUser? user = await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

        if (user == null)
        {
            return null;
        }

        /*return new AuthenticationResponse(
            user.Id, user.Email, user.Username, user.Gender, "Token", Success: true);*/

        return _mapper.Map<AuthenticationResponse>(user) with {
        Success = true,
        Token = "Token"
        };
    }

    public async Task<AuthenticationResponse?> RegisterUser(RegisterRequest registerRequest)
    {
        //Create a dummy user object based on the register request
        ApplicationUser? user = new ApplicationUser()
        {
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            Username = registerRequest.Username,
            Gender = registerRequest.Gender.ToString()
        };

        ApplicationUser? registeredUser = await _usersRepository.AddUser(user);

        if (registeredUser == null)
        {
            return null;
        }

        /*return new AuthenticationResponse( 
            registeredUser.Id, registeredUser.Email, registeredUser.Username,
            registeredUser.Gender, "Token", Success: true);*/

        return _mapper.Map<AuthenticationResponse>(registeredUser) with
        {
            Success = true,
            Token = "Token"
        };
    }
}

