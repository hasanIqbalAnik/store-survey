//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StoreSurvey
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        // Primitive properties
    
        public int ID { get; set; }
        public int RoleID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Nullable<int> Active { get; set; }
    
        // Navigation properties
    
        public virtual Role Role { get; set; }
    
    }
}
