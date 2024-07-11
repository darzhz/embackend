namespace embackend.Models;
using Microsoft.EntityFrameworkCore;
#pragma warning disable CS8618 

public class EventContext : DbContext{
    public DbSet<Event> eventTable {get;set;}
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=password");
}
   public class Event
{
    public int id {get;set;}
    public string name {get;set;}
    public string desc {get;set;}
    public string timedate{get;set;}
    public float duration{get;set;}
    public string? venue{get;set;}
}