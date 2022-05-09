using Microsoft.IdentityModel.Tokens;
using ProiectPractica_ASE.App_Data;
using ProiectPractica_ASE.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ProiectPractica_ASE.Services
{
    public class UserService:IUserService
    {
        private readonly ClubMembershipDbContext _context;
        public UserService(ClubMembershipDbContext context)
        {
            _context = context;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest request)
        {
            var user = _context.Members.SingleOrDefault(x => x.IdMember == request.Username && x.Name == request.Password);
            if (user == null) return null;

            var token = generateJwtToken();
            return new AuthenticateResponse(token);
        }

        private string generateJwtToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AuthSecret_AuthSecret"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken("https://localhost:7249",
              "https://localhost:7249",
              null,
              expires: DateTime.Now.AddDays(3),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
