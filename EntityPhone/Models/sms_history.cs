//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityPhone.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class sms_history
    {
        public int sms_histoty_id { get; set; }
        public int histoty_id { get; set; }
    
        public virtual history history { get; set; }
    }
}
