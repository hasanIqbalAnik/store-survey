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
    
    public partial class FixedDisplaySku
    {
        // Primitive properties
    
        public int Id { get; set; }
        public Nullable<int> groupId { get; set; }
        public Nullable<int> availability { get; set; }
        public Nullable<int> totalDisplayCount { get; set; }
        public Nullable<int> faceUpCount { get; set; }
        public Nullable<int> sequence { get; set; }
        public Nullable<int> ored { get; set; }
        public int mustHaveSkuId { get; set; }
        public string formId { get; set; }
    
        // Navigation properties
    
        public virtual MustHaveSku MustHaveSku { get; set; }
    
    }
}