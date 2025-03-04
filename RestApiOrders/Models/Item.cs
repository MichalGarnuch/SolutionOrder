using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApiOrders.Models
{
    [Table("Item")]
    public partial class Item
    {
        public Item()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        [Key]
        public int IdItem { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int IdCategory { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Price { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Quantity { get; set; }
        public string? FotoUrl { get; set; }
        public int? IdUnitOfMeasurement { get; set; }
        public string? Code { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("IdCategory")]
        [InverseProperty("Items")]
        public virtual Category IdCategoryNavigation { get; set; } = null!;
        [ForeignKey("IdUnitOfMeasurement")]
        [InverseProperty("Items")]
        public virtual UnitOfMeasurement? IdUnitOfMeasurementNavigation { get; set; }
        [InverseProperty("IdItemNavigation")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
