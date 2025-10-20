using Quiz.DAL.Contexts;
using Quiz.DAL.Models.Products;
using Quiz.DAL.Reposatories.Generic_Reposatory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.DAL.Reposatories.Products
{
    public class ProductRepo : GenericRepo<Product>, IProductRepo 
    {

        private readonly QuizDbContext _context;

        public ProductRepo(QuizDbContext Context) : base(Context)
        //inject the context
        {
            _context = Context;
        }





    }
}
