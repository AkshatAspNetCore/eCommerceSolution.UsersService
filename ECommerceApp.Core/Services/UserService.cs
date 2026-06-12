using AutoMapper;
using ECommerceApp.Core.DTO;
using ECommerceApp.Core.Entities;
using ECommerceApp.Core.RepositoryContracts;
using ECommerceApp.Core.ServiceContracts;
using Microsoft.Graph;

namespace ECommerceApp.Core.Services;

public class UserService : IUserService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;
    private readonly GraphServiceClient _graphServiceClient;

    public UserService(IUsersRepository usersRepository, IMapper mapper, GraphServiceClient graphServiceClient)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
        _graphServiceClient = graphServiceClient;
    }

    public async Task<UserDTO> GetUserByUserID(Guid userID)
    {
        //ApplicationUser? user = await _usersRepository.GetUserByUserID(userID);
        var existingUser = await _graphServiceClient.Users[Convert.ToString(userID)].GetAsync();
        if (existingUser == null) return null;

        var user = new UserDTO(userID, existingUser.UserPrincipalName, existingUser.GivenName, existingUser.Surname);
       return user;
    }

    /*
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
    */
}

