using Microsoft.EntityFrameworkCore;

namespace ContainerTracker.Models;

public class ContainerTrackerContext : DbContext
{
    public ContainerTrackerContext(DbContextOptions<ContainerTrackerContext> options)
        : base(options)
    {
    }
    public DbSet<Container> Containers { get; set; } = null!;
}