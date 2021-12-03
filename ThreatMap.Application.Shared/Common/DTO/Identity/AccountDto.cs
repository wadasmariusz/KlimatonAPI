namespace ThreatMap.Application.Shared.Common.DTO.Identity;

public class AccountDto
{
    public long Id { get; set; }
    public string Email { get; set; }
    public ICollection<string> Roles { get; set; } = new List<string>();
    public Dictionary<string, string> Claims { get; set; } = new();
    public DateTimeOffset CreatedAt { get; set; } //Dodać CreatedAt do Usera
}