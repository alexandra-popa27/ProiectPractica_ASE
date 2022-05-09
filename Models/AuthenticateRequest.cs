namespace ProiectPractica_ASE.Models
{
    public class AuthenticateRequest
    {
        public Guid Username { get; set; }//id member va fi username
        public string Password { get; set; }//name din tabela member va fi in locul parolei
    }
}
