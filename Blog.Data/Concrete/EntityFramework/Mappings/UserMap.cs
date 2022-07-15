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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u=>u.Id);
            builder.Property(u=>u.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.Email).IsRequired(true);
            builder.Property(u=>u.Email).HasMaxLength(128);
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u=>u.Username).IsRequired(true);
            builder.Property(u => u.Username).HasMaxLength(20);
            builder.HasIndex(u => u.Username).IsUnique();

            builder.Property(u=>u.PasswordHash).IsRequired(true);
            builder.Property(u => u.PasswordHash).HasColumnType("VARBINARY(500)");

            builder.Property(u => u.Description).HasMaxLength(200);

            builder.Property(u=>u.FirstName).IsRequired(true);
            builder.Property(u=>u.FirstName).HasMaxLength(30);

            builder.Property(u=>u.LastName).IsRequired(true);
            builder.Property(u=>u.LastName).HasMaxLength(20);

            builder.Property(u=>u.Picture).IsRequired(true);
            builder.Property(u => u.Picture).HasMaxLength(250);

            builder.HasOne<Role>(u => u.Role).WithMany(r => r.Users).HasForeignKey(u => u.RoleId);


            builder.Property(u => u.CreatedByName).IsRequired(true);
            builder.Property(u => u.CreatedByName).HasMaxLength(50);
            builder.Property(u => u.ModifiedByName).IsRequired(true);
            builder.Property(u => u.ModifiedByName).HasMaxLength(50);
            builder.Property(u => u.CreatedDate).IsRequired(true);
            builder.Property(u => u.ModifiedDate).IsRequired(true);
            builder.Property(u => u.IsActive).IsRequired(true);
            builder.Property(u => u.IsDeleted).IsRequired(true);
            builder.Property(u => u.Note).HasMaxLength(500);

            builder.ToTable("Users");

            builder.HasData(new User {
              Id = 1,
              RoleId = 1,
              FirstName = "Feyyaz",
              LastName = "Balcı",
              Email = "feyyazbalci@gmail.com",
              Username = "feyyazbalci",
              Picture = "https://images.unsplash.com/photo-1566228015668-4c45dbc4e2f5?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTd8fGxvZ2lufGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=500&q=60",
              IsActive = true,
              IsDeleted = false,
              CreatedByName = "InitialCreate",
              CreatedDate = DateTime.Now,
              ModifiedByName = "InitialCreate",
              ModifiedDate = DateTime.Now,
              Description = "İlk admin kullanıcısı",
              Note = "Admin Kullanıcısı",
              PasswordHash = Encoding.ASCII.GetBytes("0192023a7bbd73250516f069df18b500")
            });

        }
    }
}
