//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeamI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class INSPECTION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INSPECTION()
        {
            this.INSPECTIONDETAILS = new HashSet<INSPECTIONDETAILS>();
        }
    
        public int ID { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<int> labID { get; set; }
        public Nullable<int> userID { get; set; }
        public bool status { get; set; }
        public Nullable<System.DateTime> dueDate { get; set; }
        public Nullable<System.DateTime> scheduledDate { get; set; }
        public Nullable<int> complete { get; set; }
    
        public virtual LAB LAB { get; set; }
        public virtual USER USER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INSPECTIONDETAILS> INSPECTIONDETAILS { get; set; }
    }
}
