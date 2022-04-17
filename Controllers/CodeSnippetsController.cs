using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public async Task<IActionResult> Get()
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
    }
}
