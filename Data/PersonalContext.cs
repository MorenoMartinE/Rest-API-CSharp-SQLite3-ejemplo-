using Microsoft.EntityFrameworkCore;
using apiRest.Models;

namespace apiRest.Data;


public class PersonalContext : DbContext {
    
    public PersonalContext (DbContextOptions<PersonalContext> options) : base(options){

    }

    public DbSet<Personal> Personals => Set<Personal>();



}