using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace ECommerceApp.Infrastructure.DbContext;

public class DapperDbContext
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _connection;

    public DapperDbContext(IConfiguration configuration)
    {
        //TO DO: Initialize the database connection here, such as using Dapper to connect to a SQL database.
        _configuration = configuration;
        string? connectionString = _configuration.GetConnectionString("PostgresConnection");

        //Create a new NpgsqlConnection using the connection string and open the connection
        _connection = new NpgsqlConnection(connectionString);
    }

    public IDbConnection connection => _connection;
}

