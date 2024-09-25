using Microsoft.AspNetCore.Mvc;
using LMSN_Innovation.Data; // na-Namespace pour le contexte de base de données
using LMSN_Innovation.Modeles; // na-Namespace pour les modèles (Utilisateur, Evenement, Role, etc.)
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LMSN_Innovation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration; // na-Injection de la configuration

        public AuthController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration; // na-Stocker la configuration pour accéder à la clé JWT
        }

        // na-Endpoint pour inscrire un nouvel utilisateur
        [HttpPost("register")]
        public IActionResult Register([FromBody] Utilisateur utilisateur)
        {
            if (_context.Utilisateurs.Any(u => u.Email == utilisateur.Email))
            {
                return BadRequest("Un utilisateur avec cet e-mail existe déjà.");
            }

            utilisateur.PasswordHash = HashPassword(utilisateur.PasswordHash); // na-Hasher avec SHA-256 ou BCrypt
            _context.Utilisateurs.Add(utilisateur);
            _context.SaveChanges();
            return Ok("Utilisateur créé avec succès !");
        }

        // na-Fonction pour hasher le mot de passe avec SHA-256
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower(); // na-Convertir en string hexadécimal
            }
        }
    }
}