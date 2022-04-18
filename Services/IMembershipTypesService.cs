using Microsoft.EntityFrameworkCore;
using ProiectPractica_ASE.Models;

namespace ProiectPractica_ASE.Services
{
    public interface IMembershipTypesService
    {
        public Task<DbSet<MembershipType>> Get();
    }
}
