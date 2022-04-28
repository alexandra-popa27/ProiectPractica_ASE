using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectPractica_ASE.Models;
using ProiectPractica_ASE.App_Data;

namespace ProiectPractica_ASE.Services
{
    public class AnnouncementsService:IAnnouncementsService
    {
        private readonly ClubMembershipDbContext _context;
        public AnnouncementsService(ClubMembershipDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Announcement announcement)
        {
            _context.Remove(announcement);
            _context.SaveChanges();
        }

        public async Task<DbSet<Announcement>>Get()
        {
            return _context.Announcements;
        }
        public async Task Post(Announcement announcement)
        {
            var announcement_new = new Announcement
            {
                IdAnnouncement = Guid.NewGuid(),
                ValidFrom = announcement.ValidFrom,
                ValidTo = announcement.ValidTo,
                Title = announcement.Title,
                Text = announcement.Text,
                Tags = announcement.Tags,
                EventDate = announcement.EventDate
            };
            _context.Entry(announcement_new).State = EntityState.Added;
            _context.SaveChanges();
        }

        public async Task Put(Announcement announcement)
        {
            _context.Update(announcement);
            _context.SaveChanges();
        }
    }
}
