//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PRTS.App
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserPrivilege
    {
        public long UserPrivilegeId { get; set; }
        public Nullable<long> RoleId { get; set; }
        public Nullable<long> ModuleId { get; set; }
        public Nullable<bool> IsVisible { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}
