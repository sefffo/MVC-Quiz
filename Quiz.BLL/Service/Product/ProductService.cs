using Microsoft.EntityFrameworkCore;
using Quiz.DAL.Unit_Of_Work;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.BLL.Service.Product
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public IEnumerable<DAL.Models.Products.Product> GetAllProducts()
        {
            var Products = unitOfWork.ProductRepo.GetAll().ToList();//bmshy haly 
            return Products;
        }

        public DAL.Models.Products.Product GetPRoductById(int id)
        {
            // Make sure it's NOT tracked
            var product = unitOfWork.ProductRepo.GetAll()
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == id);

            return product;
        }


        public int AddProduct(DAL.Models.Products.Product dto)
        {
            unitOfWork.ProductRepo.Add(dto);
            return unitOfWork.Complete();
        }


        public int UpdateProduct(DAL.Models.Products.Product dto)
        {
            var existingProduct = unitOfWork.ProductRepo.GetById(dto.Id);

            if (existingProduct == null)
                return 0;

            unitOfWork.ProductRepo.Detach(existingProduct);

            unitOfWork.ProductRepo.Update(dto);
            return unitOfWork.Complete();
        }

        public int DeleteProduct(int? id)
        {
            var product = unitOfWork.ProductRepo.GetById(id.Value);
            unitOfWork.ProductRepo.Delete(id.Value);
            return unitOfWork.Complete();
        }


    }
}
