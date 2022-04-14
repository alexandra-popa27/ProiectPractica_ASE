using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectPractica_ASE.Models;

namespace ProiectPractica_ASE.App_Data
{
    public class ClubMembershipDbContext:DbContext//Entity Framework e un ORM(object-database mapper)
    {
        public ClubMembershipDbContext(DbContextOptions<ClubMembershipDbContext> options) : base(options) { }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<CodeSnippet>CodeSnippets{get;set;}
        //public DbSet<Member>Members{get;set;}
    }
}
