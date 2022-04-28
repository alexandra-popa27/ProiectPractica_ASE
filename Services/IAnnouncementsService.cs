using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectPractica_ASE.Models;

namespace ProiectPractica_ASE.Services
{
    public interface IAnnouncementsService
    {
        public Task<DbSet<Announcement>> Get();//citire-read
        public Task Post(Announcement announcement);//creare-insert
        public Task Delete(Announcement announcement);//stergem o inregistrare
        public Task Put(Announcement announcement);//modificam o inregistrare
    }
}
