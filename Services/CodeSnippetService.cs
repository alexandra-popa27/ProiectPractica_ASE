using ProiectPractica_ASE.Models;
using Microsoft.EntityFrameworkCore;
using ProiectPractica_ASE.App_Data;

namespace ProiectPractica_ASE.Services
{
    public class CodeSnippetService : ICodeSnippetService
    {
        private readonly ClubMembershipDbContext _context;

        public CodeSnippetService(ClubMembershipDbContext context)
        {
            _context = context;
        }
        public async Task<DbSet<CodeSnippet>> Get()
        {
            return _context.CodeSnippets;
        }
    }
}
