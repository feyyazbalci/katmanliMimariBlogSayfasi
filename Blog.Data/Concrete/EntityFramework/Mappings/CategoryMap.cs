using Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Name).IsRequired(true);
            builder.Property(c => c.Name).HasMaxLength(50);

            builder.Property(c => c.Description).HasMaxLength(100);

            builder.Property(c => c.CreatedByName).IsRequired(true);
            builder.Property(c => c.CreatedByName).HasMaxLength(50);
                             
            builder.Property(c => c.ModifiedByName).IsRequired(true);
            builder.Property(c => c.ModifiedByName).HasMaxLength(50);
                             
            builder.Property(c => c.CreatedDate).IsRequired(true);
            builder.Property(c => c.ModifiedDate).IsRequired(true);
                             
            builder.Property(c => c.IsActive).IsRequired(true);
            builder.Property(c => c.IsDeleted).IsRequired(true);
                             
            builder.Property(c => c.Note).HasMaxLength(500);

            builder.ToTable("Categories");


            builder.HasData(
               new Category { 
               Id= 1,
               Name="C#",
               Description = "C# Programlama dili ile ilgili en güncel bilgiler",
               IsActive = true,
               IsDeleted = false,
               CreatedByName = "InitialCreate",
               CreatedDate = DateTime.Now,
               ModifiedByName = "InitialCreate",
               ModifiedDate = DateTime.Now,
               Note = "C# Blog Kategorisi"
            },
            new Category
            {
                Id= 2,
                Name = "C++",
                Description = "C++ Programlama dili ile ilgili en güncel bilgiler",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "C++ Blog Kategorisi"
            },
            new Category
            {
                Id = 3,
                Name = "JavaScript",
                Description = "JavaScript Programlama dili ile ilgili en güncel bilgiler",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "JavaScript Blog Kategorisi"
            }
            
            );
        }

    }
}
