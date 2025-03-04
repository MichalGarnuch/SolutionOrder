using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApiOrders.Models
{
    [Table("Client")]
    public partial class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int IdClient { get; set; }
        public string? Name { get; set; }
        public string? Adress { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; }

        [InverseProperty("IdClientNavigation")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
