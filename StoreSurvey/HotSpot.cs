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
    
    public partial class HotSpot
    {
        // Primitive properties
    
        public int id { get; set; }
        public string head { get; set; }
        public string description { get; set; }
        public Nullable<int> compliance { get; set; }
        public int questionnaireId { get; set; }
        public string formId { get; set; }
    
        // Navigation properties
    
        public virtual Questionnaire Questionnaire { get; set; }
    
    }
}
