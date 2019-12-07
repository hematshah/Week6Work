//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace School_Book_Database_App
{
    using System;
    using System.Collections.Generic;
    
    public partial class SBOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SBOrder()
        {
            this.Students = new HashSet<Student>();
        }
    
        public int OrderBooksId { get; set; }
        public Nullable<int> BookInventoryID { get; set; }
        public string Subject { get; set; }
        public string BookName { get; set; }
        public string ExamBoardAndLevel { get; set; }
        public string BookType { get; set; }
        public Nullable<int> QuantityOrdered { get; set; }
        public Nullable<decimal> TotalCostOfBooks { get; set; }
        public Nullable<System.DateTime> DateOrdered { get; set; }
        public Nullable<System.DateTime> DateOrderRecieved { get; set; }
        public string Notes { get; set; }
    
        public virtual SBInventory SBInventory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }
    }
}