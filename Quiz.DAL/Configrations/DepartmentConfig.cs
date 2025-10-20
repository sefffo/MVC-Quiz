using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.DAL.Models.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.DAL.Configrations
{
    public class DepartmentConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasMany(d => d.Products)
               .WithOne(e => e.Category)
               .HasForeignKey(e => e.CategoryId)
               .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
