//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConvenienceStore.Model.Staff
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            this.BillDetails = new HashSet<BillDetail>();
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> BillDate { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<decimal> Price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillDetail> BillDetails { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual User User { get; set; }
    }
}