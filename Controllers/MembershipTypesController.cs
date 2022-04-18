using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectPractica_ASE.Models;
using ProiectPractica_ASE.Services;

namespace ProiectPractica_ASE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MembershipTypesController : ControllerBase
    {
        private readonly IMembershipTypesService _membershipTypeService;

        public MembershipTypesController(IMembershipTypesService membershipTypeService)
        {
            _membershipTypeService = membershipTypeService;
        }
        [Route("GetMembershipTypes")]
        [HttpGet]
        public async Task<IActionResult> GetMembershipTypes()
        {
            DbSet<MembershipType> membershipType = await _membershipTypeService.Get();
            if (membershipType != null)
            {
                if (membershipType.ToList().Count > 0)
                    return StatusCode(200, membershipType);
                else return StatusCode(404, "Nu este niciun tip de membership in tabel!");
            }
            return StatusCode(404);
        }
    }
}
