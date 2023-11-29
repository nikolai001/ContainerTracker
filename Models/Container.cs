namespace ContainerTracker.Models;
public class Container
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Description {get; set;}
    public string? Location {get; set;}
    public string? Coordinates {get; set;}
    public DateTime? DatePlaced { get; set; }
    public DateTime? DateRemoved {get; set;}
}