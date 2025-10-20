using Quiz.DAL.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.DAL.Models.Categories
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Product> Products { get;set; } = new HashSet<Product>();
    }
}
