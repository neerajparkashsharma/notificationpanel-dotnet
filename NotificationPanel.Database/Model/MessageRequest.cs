//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NotificationPanel.Database.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class MessageRequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MessageRequest()
        {
            this.Notifications = new HashSet<Notification>();
        }
    
        public long Id { get; set; }
        public Nullable<long> UserId { get; set; }
        public Nullable<long> User2Id { get; set; }
        public Nullable<bool> IsAccepted { get; set; }
        public Nullable<bool> IsDiscarded { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
