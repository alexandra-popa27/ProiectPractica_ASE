﻿using Microsoft.AspNetCore.Mvc;
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

        [Route("PostMembershipTypes")]
        [HttpPost]
        public async Task<IActionResult> PostMembershipTypes([FromBody] MembershipType membershipType)
        {
            try
            {
                if (membershipType != null)
                {
                    await _membershipTypeService.Post(membershipType);
                    return StatusCode(201, "Tipul de membership a fost adaugat in tabel");
                }
            }
            catch (Exception ex) { return StatusCode(500, ex); }
            return StatusCode(500);
        }

        [Route("DeleteMembershipTypes")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMembershipTypes([FromBody] MembershipType membershipType)
        {
            if (membershipType != null)
            {
                await _membershipTypeService.Delete(membershipType);
                return StatusCode(200, "Tipul de membership a fost sters");
            }
            return StatusCode(500, "A aparut o eroare!Tipul de membership nu a fost sters");
        }

        [Route("PutMembershipTypes")]
        [HttpPut]
        public async Task<IActionResult> PutMembershipTypes([FromBody] MembershipType membershipType)
        {
            if (membershipType != null)
            {
                await _membershipTypeService.Put(membershipType);
                return StatusCode(200, "Tipul de membership a fost modificat!");
            }
            return StatusCode(500, "A aparut o eroare!Tipul de membership nu a fost modificat!");
        }
    }
}
