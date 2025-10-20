using Quiz.DAL.Models.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.DAL.Models.Products
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public int Price { get; set; }


        //START of the relation 
        public virtual Category? Category { get; set; }


        //cat id in the entity 
        public int? CategoryId { get; set; }
    }
}
