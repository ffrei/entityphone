//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityPhone.DM.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class sub_option
    {
        public int sub_option_id { get; set; }
        public int subscription_id { get; set; }
        public int option_id { get; set; }
        public System.DateTime start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
    
        public virtual option option { get; set; }
        public virtual subscription subscription { get; set; }
    }
}
