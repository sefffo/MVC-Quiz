using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.DAL.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.DAL.Configrations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(e => e.Name).HasColumnType("varchar(50)");
          
            builder.Property(e => e.Price).HasColumnType("decimal(10,3)");




        }
    }
}
