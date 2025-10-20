using Quiz.DAL.Contexts;
using Quiz.DAL.Reposatories.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.DAL.Unit_Of_Work
{
    public class UOW : IUnitOfWork
    {
        private readonly QuizDbContext context;

        public UOW(QuizDbContext context)
        {
            this.context = context;
            //3shan lazem lw geet aklm el uow 3shan st5dm el repo f aklem el context 

            //theres is a better implementation 
            ProductRepo = new ProductRepo(context);
        }

        public IProductRepo ProductRepo { get; set; }
       

        public int Complete()
        {
            return context.SaveChanges();
        }

    }
}
