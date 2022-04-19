using ProiectPractica_ASE.Models;
using Microsoft.EntityFrameworkCore;
using ProiectPractica_ASE.App_Data;
namespace ProiectPractica_ASE.Services
{
    public class MembershipsService:IMembershipsService
    {
        private readonly ClubMembershipDbContext _context;
        public MembershipsService(ClubMembershipDbContext context)
        {
            _context = context;
        }
        public async Task<DbSet<Membership>> Get()
        {
            return _context.Memberships;
        }
        public async Task Post(Membership memberships)
        {
            var membership_new = new Membership
            {
                IdMembership=Guid.NewGuid(),
                IdMember=memberships.IdMember,
                IdMembershipType=memberships.IdMembershipType,
                StartDate=DateTime.Now,
                EndDate=memberships.EndDate,
                Level=memberships.Level,
            };
            _context.Entry(membership_new).State = EntityState.Added;
            _context.SaveChanges();
        }
    }
}
