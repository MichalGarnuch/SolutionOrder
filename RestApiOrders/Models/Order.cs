using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApiOrders.Models
{
    [Table("Order")]
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        [Key]
        public int IdOrder { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataOrder { get; set; }
        public int? IdClient { get; set; }
        public int? IdWorker { get; set; }
        public string? Notes { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeliveryDate { get; set; }

        [ForeignKey("IdClient")]
        [InverseProperty("Orders")]
        public virtual Client? IdClientNavigation { get; set; }
        [ForeignKey("IdWorker")]
        [InverseProperty("Orders")]
        public virtual Worker? IdWorkerNavigation { get; set; }
        [InverseProperty("IdOrderNavigation")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
