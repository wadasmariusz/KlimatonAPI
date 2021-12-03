using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace ThreatMap.Domain.Identity.Entities;

public class User : IdentityUser<long>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [JsonIgnore]
    public List<RefreshToken> RefreshTokens { get; set; }

}