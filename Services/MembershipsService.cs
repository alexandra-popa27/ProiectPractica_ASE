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
    }
}
