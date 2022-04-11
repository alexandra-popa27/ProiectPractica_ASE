using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectPractica_ASE.Models;

namespace ProiectPractica_ASE.Models
{
    public interface IAnnouncementsService
    {
        public Task<DbSet<Announcement>> Get();
        public Task Post(Announcement announcement);
    }
}
