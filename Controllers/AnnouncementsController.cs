using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectPractica_ASE.Models;
using ProiectPractica_ASE.Services;


namespace ProiectPractica_ASE.Controllers
{
    [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme)]
    [Route("controller")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementsService _announcementsService;

        public AnnouncementsController(IAnnouncementsService announcementsService)
        {
            _announcementsService = announcementsService;
        }

        [Route("GetAnnouncements")]
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

        [Route("PostAnnouncements")]
        [HttpPost]
        public async Task<IActionResult> PostAnnouncements([FromBody]Announcement announcement)
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

        [Route("DeleteAnnouncements")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAnnouncements([FromBody] Announcement announcement)
        {
            if(announcement!=null)
            {
                await _announcementsService.Delete(announcement);
                return StatusCode(200, "Anuntul a fost sters!");
            }
            return StatusCode(200, "A aparut o eroare!Anuntul nu a fost sters!");
        }

        [Route("PutAnnouncements")]
        [HttpPut]
        public async Task<IActionResult> PutAnnouncements([FromBody] Announcement announcement)
        {
            if(announcement!=null)
            {
                await _announcementsService.Put(announcement);
                return StatusCode(200, "Anuntul a fost modificat!");
            }
            return StatusCode(500, "A aparut o eroare!Anuntul nu a fost modificat!");
        }
    }
}
