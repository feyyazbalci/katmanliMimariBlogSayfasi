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
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Title).HasMaxLength(100);
            builder.Property(a => a.Title).IsRequired(true);

            builder.Property(a => a.Content).IsRequired(true);
            builder.Property(a => a.Content).HasColumnType("NVARCHAR(MAX)");

            builder.Property(a => a.Date).IsRequired(true);

            builder.Property(a => a.SeoAuthor).IsRequired(true);
            builder.Property(a => a.SeoAuthor).HasMaxLength(50);

            builder.Property(a => a.SeoDescription).IsRequired(true);
            builder.Property(a => a.SeoDescription).HasMaxLength(100);

            builder.Property(a => a.SeoTags).IsRequired(true);
            builder.Property(a => a.SeoTags).HasMaxLength(70);

            builder.Property(a => a.ViewsCount).IsRequired(true);

            builder.Property(a => a.CommentCount).IsRequired(true);

            builder.Property(a => a.Thumbnail).IsRequired(true);
            builder.Property(a => a.Thumbnail).HasMaxLength(250);

            builder.Property(a => a.CreatedByName).IsRequired(true);
            builder.Property(a => a.CreatedByName).HasMaxLength(50);

            builder.Property(a=> a.ModifiedByName).IsRequired(true);
            builder.Property(a=>a.ModifiedByName).HasMaxLength(50);

            builder.Property(a=> a.CreatedDate).IsRequired(true);
            builder.Property(a=>a.ModifiedDate).IsRequired(true);

            builder.Property(a=>a.IsActive).IsRequired(true);
            builder.Property(a=>a.IsDeleted).IsRequired(true);

            builder.Property(a => a.Note).HasMaxLength(500);

            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a => a.CategoryId);

            builder.HasOne<User>(a => a.User).WithMany(u => u.Articles).HasForeignKey(a => a.UserId);

            builder.ToTable("Articles");


            builder.HasData(
                new Article
                {
                    Id = 1,
                    CategoryId = 1,
                    Title = ".Net 6 Yenilikleri",
                    Content = "Eski usul ile stream datayı Deserialize edelim. Stream’in deserialize edilmesi için, “IAsyncEnumrable<T>” tipinde geri dönen asenkron çalışan zaten var olan “JsonSerializer.DeserializeAsync()” methodunu kullanalım. Stream’den asenkron çekilen data beklenerek bir result’a atılmakta, daha sonra gelen data da asenkron olarak ekrana basılmaktadır. Buradaki esas trick, streamden çekilen datanın bir akış şeklinde ekrana basılamamasıdır.",
                    Thumbnail = "Default.jpg",
                    SeoDescription = ".Net 6 Yenilikleri",
                    SeoTags = ".Net 6, .Net Framework",
                    SeoAuthor = "Feyyaz Balcı",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = ".Net 6 Yenilikleri",
                    UserId = 1,
                    ViewsCount= 25,
                    CommentCount = 1
                },
                new Article
                {
                    Id = 2,
                    CategoryId = 2,
                    Title = "C++ Avantajları",
                    Content = "C++ programlama dili Java gibi programlama dillerine karsın programcıya güvenmektedirler ve güçlerinin büyük bir kısmını buradan alırlar. Bu sayede kullanıcıya daha yüksek performans sunabilmektedirler. Ama sağlamış olduğu bu avantajların yanında kullanıcıdan da daha bilinçli bir şekilde program geliştirmesini beklemektedir.",
                    Thumbnail = "Default.jpg",
                    SeoDescription = "C++ Avantajları",
                    SeoTags = "C++ Avantajları, C",
                    SeoAuthor = "Feyyaz Balcı",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "C++ Avantajları",
                    UserId = 1,
                    ViewsCount = 33,
                    CommentCount = 1
                },
                new Article
                {
                    Id = 3,
                    CategoryId = 3,
                    Title = "Javascript'in Kullanım Alanları",
                    Content = "Javascript ilk zamanlarında sadece browser tarafında çalışıyordu. Yani son kullanıcının gördüğü Front End dediğimiz, tasarımlar ve görüntü katmanında, sayfaları daha dinamik hale getirmek için kullanılırdı. İlk kullanım alanı budur. Mesela kullanıcı butona bastığında arka plan rengini değiştirmek gibi. NodeJS framework'ünün geliştirilmesi ile birlikte artık sunucu tarafında işlemler gerçekleştirmek için de kullanılmaktadır. Örn: oturum işlemleri, veritabanı işlemleri gibi.",
                    Thumbnail = "Default.jpg",
                    SeoDescription = "Javascript'in Kullanım Alanları",
                    SeoTags = "HTML, CSS, Js",
                    SeoAuthor = "Feyyaz Balcı",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Javascript'in Kullanım Alanları",
                    UserId = 1,
                    ViewsCount = 41,
                    CommentCount= 1
                }
                );


        }
    }
}
