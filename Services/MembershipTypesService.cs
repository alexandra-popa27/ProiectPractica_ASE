using Microsoft.EntityFrameworkCore;
using ProiectPractica_ASE.App_Data;
using ProiectPractica_ASE.Models;

namespace ProiectPractica_ASE.Services
{
    public class MembershipTypesService: IMembershipTypesService
    {
        private readonly ClubMembershipDbContext _context;
        public MembershipTypesService(ClubMembershipDbContext context)
        {
            _context = context;
        }
        public async Task<DbSet<MembershipType>> Get()
        {
            return _context.MembershipTypes;
        }
    }
}
