using System.Text.Json.Serialization;

namespace ThreatMap.Application.Shared.Common.DTO.Identity;
public class JsonWebToken
{
    public string AccessToken { get; set; }
    [JsonIgnore]
    public string RefreshToken { get; set; }
    public long Expires { get; set; }
    public long UserId { get; set; }
    public string Email { get; set; }
    public ICollection<string> Roles { get; set; } = new List<string>();
    public IDictionary<string, string> Claims { get; set; } = new Dictionary<string, string>();

}