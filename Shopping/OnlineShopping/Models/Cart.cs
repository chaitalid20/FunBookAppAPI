using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopping.Models
{
	public class Cart
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

		public double TotalPrice { get; set; }

		public int ItemCount { get; set; }

		public CartItem CartItem { get; set; }
	}
}

