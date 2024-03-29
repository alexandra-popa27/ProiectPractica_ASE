﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectPractica_ASE.Models;
using ProiectPractica_ASE.Services;

namespace ProiectPractica_ASE.Controllers
{
    [Route("controller")]
    [ApiController]
    public class CodeSnippetsController : ControllerBase
    {
        private readonly ICodeSnippetService _codeSnippetService;
        public CodeSnippetsController(ICodeSnippetService codeSnippetService)
        {
            _codeSnippetService = codeSnippetService;
        }

        [Route("GetCodeSnippets")]
        [HttpGet]
        public async Task<IActionResult> GetCodeSnippets()
        {
            DbSet<CodeSnippet> codeSnippets = await _codeSnippetService.Get();
            if (codeSnippets != null)
            {
                if (codeSnippets.ToList().Count > 0)
                    return StatusCode(200, codeSnippets);
                else return StatusCode(404, "Nu este niciun snippet adaugat in tabel.");
            }
            return StatusCode(404);
        }

        [Route("PostCodeSnippets")]
        [HttpPost]
        public async Task<IActionResult> PostCodeSnippets([FromBody]CodeSnippet codeSnippet)
        {
            try
            {
                if(codeSnippet!=null)
                {
                    await _codeSnippetService.Post(codeSnippet);
                    return StatusCode(201, "Code snippet-ul a fost adaugat in tabel");
                }
            }
            catch(Exception ex) { return StatusCode(500, ex); }
            return StatusCode(500);
        }

        [Route("DeleteCodeSnippets")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCodeSnippets([FromBody]CodeSnippet codeSnippet)
        {
            if(codeSnippet!=null)
            {
                await _codeSnippetService.Delete(codeSnippet);
                return StatusCode(200, "Code snippet-ul a fost sters");
            }
            return StatusCode(500, "A aparut o eroare!Code snippet-ul nu a fost sters");
        }

        [Route("PutCodeSnippets")]
        [HttpPut]
        public async Task<IActionResult> PutCodeSnippets([FromBody] CodeSnippet codeSnippet)
        {
            if (codeSnippet != null)
            {
                await _codeSnippetService.Put(codeSnippet);
                return StatusCode(200, "Code snippet-ul a fost modificat!");
            }
            return StatusCode(500, "A aparut o eroare!Code snippet-ul nu a fost modificat!");
        }
    }
}
