//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFPerformance.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int userId { get; set; }
        public string username { get; set; }
        public string userpass { get; set; }
        public string fullName { get; set; }
        public Nullable<System.DateTime> lastLogin { get; set; }
        public string GroupId { get; set; }
    
        public virtual Group Group { get; set; }
    }
}
