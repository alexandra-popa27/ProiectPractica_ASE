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

        public async Task Delete(Member member)
        {
            _context.Members.Remove(member);
            _context.SaveChanges();
        }

        public async Task<DbSet<Member>> Get()
        {
            return _context.Members;
        }
        public async Task Post(Member member)
        {
            var member_new = new Member
            {
                IdMember=Guid.NewGuid(),
                Name= member.Name,
                Title= member.Title,
                Position= member.Position,
                Description= member.Description,
                Resume=member.Resume,
            };
            _context.Entry(member_new).State = EntityState.Added;
            _context.SaveChanges();

        }

        public async Task Put(Member member)
        {
            _context.Update(member);
            _context.SaveChanges();
        }
    }
}
