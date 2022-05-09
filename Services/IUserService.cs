using ProiectPractica_ASE.Models;

namespace ProiectPractica_ASE.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest request);
    }
}
