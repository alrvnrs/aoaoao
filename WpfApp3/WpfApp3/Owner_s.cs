//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp3
{
    using System;
    using System.Collections.Generic;
    
    public partial class Owner_s
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Adress { get; set; }
        public string Ownerphone { get; set; }
        public decimal Contribution { get; set; }
        public int Registrationnumber { get; set; }
        public System.DateTime Registrationdate { get; set; }
    
        public virtual Shopinformation Shopinformation { get; set; }

        public static implicit operator string(Owner_s v)
        {
            throw new NotImplementedException();
        }
    }
}