using Microsoft.EntityFrameworkCore;
using ProiectPractica_ASE.Models;

namespace ProiectPractica_ASE.Services
{
    public interface IMembershipsService
    {
        public Task<DbSet<Membership>> Get();
        public Task Post(Membership memberships);
    }
}
