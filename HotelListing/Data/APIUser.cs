using Microsoft.AspNetCore.Identity;

namespace HotelListing.Data;

public class APIUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;
}
