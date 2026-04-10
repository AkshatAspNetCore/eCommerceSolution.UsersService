namespace ECommerceApp.Core.DTO;

public record AuthenticationResponse(Guid UserID, string? Email,
    string? Username, string? Gender, string? Token, bool Success)
{

    //Parameterless constructor for AutoMapper
    public AuthenticationResponse() : this(default, default, default, default, default, default)
    {
    }
}

