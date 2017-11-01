using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubsAndSocieties.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubsAndSocieties.Data
{
    public class ClubAndSocContext: DbContext
    {
        public ClubAndSocContext(DbContextOptions<ClubAndSocContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Administrator> Administors { get; set; }
        public DbSet<ClubEvent> ClubEvents { get; set; }
        public DbSet<ClubsAndSociety> ClubsAndSocieties { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>().ToTable("Administrator");
            modelBuilder.Entity<ClubEvent>().ToTable("ClubEvent");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<Notification>().ToTable("Notification");
            modelBuilder.Entity<Post>().ToTable("Post");

        }
    }
    
    
}
