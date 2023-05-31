using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopping.Models
{
	public class CartItem
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? Amount { get; set; }

        [ForeignKey("Customer")]
        public int customerId { get; set; }

        [ForeignKey("ProductList")]
        public int ProductListId { get; set; }

        [ForeignKey("Cart")]
        public int  CartId { get; set; }
    }
}

