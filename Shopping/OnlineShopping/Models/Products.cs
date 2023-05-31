using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopping.Models
{
	public class Products
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }

		public string? ProductName { get; set; }

        [ForeignKey("ProductType")]
        public int ProductTypeId { get; set; }

        public virtual ProductType? ProductType { get; set; }

        public double? Price { get; set; }

		public string? Description { get; set; }

	}
}

