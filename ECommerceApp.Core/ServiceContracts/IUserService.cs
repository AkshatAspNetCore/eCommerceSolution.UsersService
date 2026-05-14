using ECommerceApp.Core.DTO;

namespace ECommerceApp.Core.ServiceContracts;

public interface IUserService
{
    /// <summary>
    /// Method to handle user login. This method takes an email and a password as parameters and returns an AuthenticationResponse object that contains the user's details. If the login fails, it returns an AuthenticationResponse with Success set to false.
    /// </summary>
    Task<AuthenticationResponse?> LoginUser(LoginRequest loginRequest);

    /// <summary>
    /// Method to handle user registration. This method takes a RegisterRequest object as a parameter and returns an AuthenticationResponse object that contains the user's details. If the registration fails, it returns an AuthenticationResponse with Success set to false.
    /// </summary>
    /// <param name="registerRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> RegisterUser(RegisterRequest registerRequest);

    /// <summary>
    /// // Method to retrieve user details based on the user id.
    /// </summary>
    /// <param name="userID">User id to search.</param>
    /// <returns>UserDTO object based on the matching UserID.</returns>
    Task<UserDTO> GetUserByUserID(Guid userID);
}

