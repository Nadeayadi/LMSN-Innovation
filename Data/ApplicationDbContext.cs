// na-Gestion des entités avec Entity Framework dans ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // na-Définir les tables dans la base de données
    public DbSet<Utilisateur> Utilisateurs { get; set; }  // na-Table des utilisateurs
    public DbSet<Evenement> Evenements { get; set; }      // na-Table des événements
}
 