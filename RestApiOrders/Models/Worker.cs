using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApiOrders.Models
{
    [Table("Worker")]
    public partial class Worker
    {
        public Worker()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int IdWorker { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsActive { get; set; }
        public string Login { get; set; } = null!;
        public string? Password { get; set; }

        [InverseProperty("IdWorkerNavigation")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
