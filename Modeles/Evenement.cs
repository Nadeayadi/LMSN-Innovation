namespace LMSN_Innovation.Modeles
{
    public class Evenement
    {
        public int EvenementID { get; set; } // na-Identifiant unique de l'événement
        public string Titre { get; set; } // na-Titre de l'événement
        public string Description { get; set; } // na-Description de l'événement
        public DateTime DateEvenement { get; set; } // na-Date de l'événement
        public string Lieu { get; set; } // na-Lieu de l'événement
        public string TypeEvenement { get; set; } // na-Type de l'événement
        public int UserID { get; set; } // na-Clé étrangère vers l'utilisateur qui a créé l'événement

        // na-Référence vers l'utilisateur qui a créé l'événement
        public Utilisateur Utilisateur { get; set; } // na-Un événement est créé par un utilisateur
    }
}
