using Microsoft.EntityFrameworkCore;
using ProiectPractica_ASE.App_Data;
using ProiectPractica_ASE.Models;

namespace ProiectPractica_ASE.Services
{
    public class MembersService:IMembersService
    {
        private readonly ClubMembershipDbContext _context;

        public MembersService(ClubMembershipDbContext context)
        {
            _context = context;
        }
        public async Task<DbSet<Member>> Get()
        {
            return _context.Members;
        }
    }
}
