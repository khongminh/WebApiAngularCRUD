using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleDemo.Models
{
    public class Product
    {
		public int Id { get; set; }
		public string ProductName { get; set; }
		public string ProductCode { get; set; }
		public DateTime ReleaseDate { get; set; }
		public decimal Price { get; set; }
		public string Description { get; set; }
		public double StarRating { get; set; }
		public string ImageUrl { get; set; }
	}
}
