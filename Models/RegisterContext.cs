using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace embackend.Models;
// #pragma warning disable CS8618 

public class RegisterContext : DbContext
{
    public DbSet<User> users {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder options) 
    => options.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=password");
}
public class User
{
    public int userid {get;set;}
    public string? fname {get;set;}
    public string? lname {get;set;}
    public string? email {get;set;}
    public string? branch {get;set;}
    public string? semester {get;set;}
    public string? clg_id {get;set;}
    public string? password {get;set;}

}