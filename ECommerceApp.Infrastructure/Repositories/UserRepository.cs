using Dapper;
using ECommerceApp.Core.Entities;
using ECommerceApp.Core.RepositoryContracts;
using ECommerceApp.Infrastructure.DbContext;

namespace ECommerceApp.Infrastructure.Repositories;

public class UserRepository : IUsersRepository
{
    private readonly DapperDbContext _dbContext;

    public UserRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        //Generate a new Id for the user
        user.UserID = Guid.NewGuid();

        //SQL Query to insert the user into the database 
        string query = "INSERT INTO public. \"Users\"(\"UserID\",\"Email\",\"Username\", " +
            "\"Gender\",\"Password\") VALUES (@Id, @Email, @Username, @Gender, @Password)";

        int rowsAffected = await _dbContext.connection.ExecuteAsync(query, user);

        if (rowsAffected > 0) return user;
        else return null;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        //SQL Query to retrieve the user from the database based on email and password
        string query = "SELECT * FROM public. \"Users\" WHERE " +
            "\"Email\" = @Email AND \"Password\" = @Password";

        var parameters = new { Email = email, Password = password };

        ApplicationUser? user = await _dbContext.connection.QuerySingleOrDefaultAsync<ApplicationUser>(query, parameters);

        return user;
    }

    public async Task<ApplicationUser?> GetUserByUserID(Guid? userID)
    {
        //SQL Query to retrieve the user from the database based on UserID
        string query = "SELECT * FROM public.\"Users\" WHERE " +
            "\"UserID\" = @UserID";

        var parameters = new { UserID = userID.ToString() };

        using var connection = _dbContext.connection; 
        return await connection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);
    }
}

