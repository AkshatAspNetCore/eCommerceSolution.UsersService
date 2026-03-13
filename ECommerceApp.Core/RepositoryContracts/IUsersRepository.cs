using ECommerceApp.Core.Entities;

namespace ECommerceApp.Core.RepositoryContracts;
/// <summary>
/// Contract for the Users Repository, which defines the methods for managing user data in the database. This interface includes methods for adding a new user and retrieving a user based on their email and password. The implementation of this interface will handle the actual database operations to perform these actions.
/// </summary>
public interface IUsersRepository
{
    /// <summary>
    /// Method to add a new user to the database. The method takes an ApplicationUser object as a parameter and returns the added user with its generated Id. If the user cannot be added, it returns null.
    /// </summary>
    Task<ApplicationUser?> AddUser(ApplicationUser user);

    /// <summary>
    /// Method to retrieve a user from the database based on their email and password. The method takes an email and a password as parameters and returns the corresponding ApplicationUser object if a match is found. If no match is found, it returns null.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);
}
