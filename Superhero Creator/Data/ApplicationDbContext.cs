using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Superhero_Creator.Models;

namespace Superhero_Creator.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // add a property of type DbSet<>
        public DbSet<SuperHero> SuperHeroEntries { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
