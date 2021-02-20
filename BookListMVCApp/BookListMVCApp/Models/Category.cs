﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookListMVCApp.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
	}
}