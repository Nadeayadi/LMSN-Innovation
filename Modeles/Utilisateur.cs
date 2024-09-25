// na-Modèle pour la table des utilisateurs
using System.Data;

public class Utilisateur
{
    public int UserID { get; set; } // na-ID de l'utilisateur
    public string NomUtilisateur { get; set; } // na-Nom de l'utilisateur
    public string Email { get; set; } // na-Email de l'utilisateur
    public string PasswordHash { get; set; } // na-Hash du mot de passe
    public DateTime DateInscription { get; set; } // na-Date d'inscription
    public int RoleID { get; set; } // na-ID du rôle

    public Role Role { get; set; } // na-Relation avec la table des rôles
}
