#nullable enable
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ThreatMap.Domain.Identity.Entities;
[Owned] // can only ever appear on navigation properties of other entity types
public class RefreshToken
{
    [Key]
    [JsonIgnore]
    public int Id { get; set; }
    public string? Token { get; set; }
    public DateTimeOffset Expires { get; set; }
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset? Revoked { get; set; }
    public string? ReplacedByToken { get; set; }
    public string? ReasonRevoked { get; set; }
    public bool IsExpired => DateTimeOffset.UtcNow >= Expires;
    public bool IsRevoked => Revoked != null;
    public bool IsActive => !IsRevoked && !IsExpired;
}