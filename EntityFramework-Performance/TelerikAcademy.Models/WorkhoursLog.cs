//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TelerikAcademy.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkhoursLog
    {
        public int LogID { get; set; }
        public Nullable<int> OldEmployeeID { get; set; }
        public Nullable<System.DateTime> OldDate { get; set; }
        public string OldTask { get; set; }
        public Nullable<int> OldHours { get; set; }
        public string OldComments { get; set; }
        public Nullable<int> NewEmployeeID { get; set; }
        public Nullable<System.DateTime> NewDate { get; set; }
        public string NewTask { get; set; }
        public Nullable<int> NewHours { get; set; }
        public string NewComments { get; set; }
        public string Command { get; set; }
    }
}
