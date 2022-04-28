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

        public async Task Delete(MembershipType membershipType)
        {
            _context.MembershipTypes.Remove(membershipType);
            _context.SaveChanges();
        }

        public async Task<DbSet<MembershipType>> Get()
        {
            return _context.MembershipTypes;
        }
        public async Task Post(MembershipType membershipType)
        {
            var membershipType_new = new MembershipType
            {
                IdMembershipType = Guid.NewGuid(),
                Name = membershipType.Name,
                Description = membershipType.Description,
                SubscriptionLenghtMonths = membershipType.SubscriptionLenghtMonths,
            };
            _context.Entry(membershipType_new).State = EntityState.Added;
            _context.SaveChanges();
        }

        public async Task Put(MembershipType membershipType)
        {
            _context.Update(membershipType);
            _context.SaveChanges();
        }
    }
}
