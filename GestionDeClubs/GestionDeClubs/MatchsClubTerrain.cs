//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionDeClubs
{
    using System;
    using System.Collections.Generic;
    
    public partial class MatchsClubTerrain
    {
        public int id { get; set; }
        public int id_Matchs { get; set; }
        public int id_Terrain { get; set; }
        public int id_Club { get; set; }
    
        public virtual Club Club { get; set; }
        public virtual Matchs Matchs { get; set; }
        public virtual Terrain Terrain { get; set; }
    }
}
