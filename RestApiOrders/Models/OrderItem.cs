using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApiOrders.Models
{
    [Table("OrderItem")]
    public partial class OrderItem
    {
        [Key]
        public int IdOrderItem { get; set; }
        public int IdOrder { get; set; }
        public int IdItem { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Quantity { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("IdItem")]
        [InverseProperty("OrderItems")]
        public virtual Item IdItemNavigation { get; set; } = null!;
        [ForeignKey("IdOrder")]
        [InverseProperty("OrderItems")]
        public virtual Order IdOrderNavigation { get; set; } = null!;
    }
}
