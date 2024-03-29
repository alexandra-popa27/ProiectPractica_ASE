﻿using Microsoft.EntityFrameworkCore;
using ProiectPractica_ASE.Models;

namespace ProiectPractica_ASE.Services
{
    public interface IMembersService
    {
        public Task<DbSet<Member>> Get();
        public Task Post(Member member);
        public Task Delete(Member member);
        public Task Put(Member member);
    }
}
