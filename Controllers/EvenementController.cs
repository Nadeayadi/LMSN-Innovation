// na-Contrôleur pour la gestion des événements
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EvenementController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EvenementController(ApplicationDbContext context)
    {
        _context = context;
    }

    // na-Création d'un nouvel événement
    [HttpPost("create-event")]
    public async Task<IActionResult> CreateEvent([FromBody] Evenement model)
    {
        var newEvent = new Evenement
        {
            Titre = model.Titre,
            Description = model.Description,
            DateEvenement = model.DateEvenement,
            Lieu = model.Lieu,
            TypeEvenement = model.TypeEvenement,
            UserID = model.UserID
        };

        _context.Evenements.Add(newEvent);
        await _context.SaveChangesAsync();

        return Ok("Événement créé avec succès");
    }
}
