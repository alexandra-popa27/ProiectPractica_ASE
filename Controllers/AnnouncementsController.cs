using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectPractica_ASE.Models;
using ProiectPractica_ASE.Services;


namespace ProiectPractica_ASE.Controllers
{
    [Route("controller")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementsService _announcementsService;

        public AnnouncementsController(IAnnouncementsService announcementsService)
        {
            _announcementsService = announcementsService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAnnouncements()
        {
            DbSet<Announcement> announcements = await _announcementsService.Get();
            if (announcements != null)
            {
                if (announcements.ToList().Count > 0)
                    return StatusCode(200, announcements);
                else return StatusCode(400, "Nu s-au gasit anunturi in baza de date.");
            }
            return StatusCode(404);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Announcement announcement)
        {
            try
            {
                if(announcement!=null)
                {
                    _announcementsService.Post(announcement);
                    return StatusCode(201, "Anuntul a fost adaugat cu succes!");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
            return StatusCode(500, "Anuntul nu a fost adaugat!");
        }
    }
}
