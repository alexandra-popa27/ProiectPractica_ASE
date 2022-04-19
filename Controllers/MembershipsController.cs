using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectPractica_ASE.Models;
using ProiectPractica_ASE.Services;

namespace ProiectPractica_ASE.Controllers
{
    [Route("controller")]
    [ApiController]
    public class MembershipsController : ControllerBase
    {
        private readonly IMembershipsService _membershipsService;
        public MembershipsController(IMembershipsService membershipsService)
        {
            _membershipsService = membershipsService;
        }
        [Route("GetMemberships")]
        [HttpGet]
        public async Task<IActionResult> GetMemberships()
        {
            DbSet<Membership> memberships = await _membershipsService.Get();
            if (memberships != null)
            {
                if (memberships.ToList().Count > 0)
                    return StatusCode(200, memberships);
                else return StatusCode(404, "Nu este niciun membership in tabel.");
            }
            return StatusCode(404);
        }

        [Route("PostMemberships")]
        [HttpPost]
        public async Task<IActionResult> PostMemberships([FromBody] Membership memberships)
        {
            try
            {
                if (memberships != null)
                {
                    await _membershipsService.Post(memberships);
                    return StatusCode(201, "Membership-ul a fost adaugat in tabel");
                }
            }
            catch (Exception ex) { return StatusCode(500, ex); }
            return StatusCode(500);
        }
    }
}
