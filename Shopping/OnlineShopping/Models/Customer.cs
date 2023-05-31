using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopping.Models
{
	public class Customer
	{
        [Key]
        public int Id { get; set; }

		public string userName { get; set; }

		public string email { get; set; }

		public bool? IsMembership { get; set; }
	}
}

