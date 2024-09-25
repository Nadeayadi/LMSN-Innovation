using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LMSN_Innovation.Data;
using LMSN_Innovation.Modeles;
using LMSN_Innovation.Controllers;



namespace LMSN_Innovation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UtilisateurController(ApplicationDbContext context)
        {
            _context = context;
        }

        // na- Récupérer tous les utilisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetUtilisateurs()
        {
            return await _context.Utilisateurs.ToListAsync(); // na-Renvoyer tous les utilisateurs
        }

        // na- Récupérer un utilisateur par son ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilisateur>> GetUtilisateur(int id)
        {
            var utilisateur = await _context.Utilisateurs.FindAsync(id);

            if (utilisateur == null)
            {
                return NotFound("Utilisateur non trouvé"); // na- Si l'utilisateur n'existe pas
            }

            return utilisateur;
        }

        // na- Mettre à jour un utilisateur par son ID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilisateur(int id, Utilisateur utilisateur)
        {
            if (id != utilisateur.UserID)
            {
                return BadRequest("ID d'utilisateur non valide"); // na- Vérification si l'ID correspond
            }

            _context.Entry(utilisateur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync(); // na-Enregistrer les changements
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilisateurExists(id))
                {
                    return NotFound("Utilisateur non trouvé"); // na- Si l'utilisateur n'existe pas
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // na- Créer un nouvel utilisateur
        [HttpPost]
        public async Task<ActionResult<Utilisateur>> PostUtilisateur(Utilisateur utilisateur)
        {
            _context.Utilisateurs.Add(utilisateur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtilisateur", new { id = utilisateur.UserID }, utilisateur);
        }

        // na- Supprimer un utilisateur
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilisateur(int id)
        {
            var utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (utilisateur == null)
            {
                return NotFound("Utilisateur non trouvé");
            }

            _context.Utilisateurs.Remove(utilisateur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // na- Vérifier si un utilisateur existe
        private bool UtilisateurExists(int id)
        {
            return _context.Utilisateurs.Any(e => e.UserID == id);
        }
    }
}