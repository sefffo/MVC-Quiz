using Quiz.DAL.Reposatories.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.DAL.Unit_Of_Work
{
    public interface IUnitOfWork
    {
        public IProductRepo ProductRepo { get; set; }
        public int Complete();
    }

}
