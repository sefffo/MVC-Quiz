using Quiz.DAL.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;
using Quiz.DAL.Models.Products;

namespace Quiz.BLL.Service.Product
{
    public interface IProductService
    {

        //momken a8ir dto 
        public IEnumerable<Quiz.DAL.Models.Products.Product> GetAllProducts();

        public Quiz.DAL.Models.Products.Product GetPRoductById(int id);
        public int AddProduct(Quiz.DAL.Models.Products.Product dto);
        public int UpdateProduct(Quiz.DAL.Models.Products.Product dto);
        public int DeleteProduct(int? id);
    }
}
