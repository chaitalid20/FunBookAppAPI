using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopping.Models
{
	public class Order
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool? isMember { get; set; }

        public double TotalPrice { get; set; }
        public bool? IsPaymentSuccess { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public List<OrderItems> OrderList { get; set; }
    }
}

