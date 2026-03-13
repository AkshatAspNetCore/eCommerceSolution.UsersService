namespace ECommerceApp.Core.Entities;

public class ApplicationUser
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Username { get; set; }
    public string? Gender { get; set; }
}

