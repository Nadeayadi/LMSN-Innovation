// na-Modèle représentant un rôle pour les utilisateurs
public class Role
{
    // na-Identifiant unique pour chaque rôle
    public int RoleID { get; set; }

    // na-Nom du rôle (Admin, Utilisateur, Modérateur)
    public string NomRole { get; set; }

    // na-Collection d'utilisateurs associés à ce rôle
    // Un rôle peut être attribué à plusieurs utilisateurs
    public ICollection<Utilisateur> Utilisateurs { get; set; }
}
