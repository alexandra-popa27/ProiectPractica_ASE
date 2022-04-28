using Microsoft.EntityFrameworkCore;
using ProiectPractica_ASE.Models;

namespace ProiectPractica_ASE.Services
{
    public interface IMembershipTypesService
    {
        public Task<DbSet<MembershipType>> Get();
        public Task Post(MembershipType membershipType);
        public Task Delete(MembershipType membershipType);
        public Task Put(MembershipType membershipType);
    }
}
