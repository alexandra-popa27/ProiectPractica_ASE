﻿using Microsoft.EntityFrameworkCore;
using ProiectPractica_ASE.Models;
namespace ProiectPractica_ASE.Services
{
    public interface ICodeSnippetService
    {
        public Task<DbSet<CodeSnippet>> Get();
        public Task Post(CodeSnippet codeSnippet);
    }
}
