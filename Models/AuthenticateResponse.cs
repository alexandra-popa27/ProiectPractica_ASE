﻿namespace ProiectPractica_ASE.Models
{
    public class AuthenticateResponse
    {
        public string Token { get; set; }
        public AuthenticateResponse(string token)
        {
            Token = token;
        }
    }
}
