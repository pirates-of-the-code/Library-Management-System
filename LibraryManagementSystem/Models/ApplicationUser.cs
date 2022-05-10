using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            OrderTables = new HashSet<OrderTable>();
        }
        
        //Id 
        //UserName 
        [NotMapped]
        override public string NormalizedUserName { get; set; }
        //Email 
        [NotMapped]
        override public string NormalizedEmail { get; set; }
        [NotMapped]
        override public bool EmailConfirmed { get; set; }
        //PasswordHash
        //[NotMapped]
        //override public string SecurityStamp { get; set; }
        [NotMapped]
        override public string ConcurrencyStamp { get; set; }
        //PhoneNumber 
        [NotMapped]
        override public bool PhoneNumberConfirmed { get; set; }
        [NotMapped]
        override public bool TwoFactorEnabled { get; set; }
        [NotMapped]
        override public DateTimeOffset? LockoutEnd { get; set; }
        [NotMapped]
        override public bool LockoutEnabled { get; set; }
        [NotMapped]
        override public int AccessFailedCount { get; set; }
        public virtual ICollection<OrderTable> OrderTables { get; set; }

    }
}
