namespace BakeoffDotnetCore.Models;

public class Artist
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? Name { get; set; }
    public string? Genre { get; set; }
}