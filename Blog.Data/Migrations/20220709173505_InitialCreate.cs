﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "VARBINARY(500)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViewsCount = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    SeoAuthor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeoDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SeoTags = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2022, 7, 9, 20, 35, 5, 89, DateTimeKind.Local).AddTicks(8142), "C# Programlama dili ile ilgili en güncel bilgiler", true, false, "InitialCreate", new DateTime(2022, 7, 9, 20, 35, 5, 89, DateTimeKind.Local).AddTicks(8155), "C#", "C# Blog Kategorisi" },
                    { 2, "InitialCreate", new DateTime(2022, 7, 9, 20, 35, 5, 89, DateTimeKind.Local).AddTicks(8172), "C++ Programlama dili ile ilgili en güncel bilgiler", true, false, "InitialCreate", new DateTime(2022, 7, 9, 20, 35, 5, 89, DateTimeKind.Local).AddTicks(8173), "C++", "C++ Blog Kategorisi" },
                    { 3, "InitialCreate", new DateTime(2022, 7, 9, 20, 35, 5, 89, DateTimeKind.Local).AddTicks(8186), "JavaScript Programlama dili ile ilgili en güncel bilgiler", true, false, "InitialCreate", new DateTime(2022, 7, 9, 20, 35, 5, 89, DateTimeKind.Local).AddTicks(8187), "JavaScript", "JavaScript Blog Kategorisi" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[] { 1, "InitialCreate", new DateTime(2022, 7, 9, 20, 35, 5, 93, DateTimeKind.Local).AddTicks(5176), "Admin Rolü, Tüm haklara sahiptir", true, false, "InitialCreate", new DateTime(2022, 7, 9, 20, 35, 5, 93, DateTimeKind.Local).AddTicks(5188), "Admin", "Admin Rolüdür." });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "Email", "FirstName", "IsActive", "IsDeleted", "LastName", "ModifiedByName", "ModifiedDate", "Note", "PasswordHash", "Picture", "RoleId", "Username" },
                values: new object[] { 1, "InitialCreate", new DateTime(2022, 7, 9, 20, 35, 5, 114, DateTimeKind.Local).AddTicks(1912), "İlk admin kullanıcısı", "feyyazbalci@gmail.com", "Feyyaz", true, false, "Balcı", "InitialCreate", new DateTime(2022, 7, 9, 20, 35, 5, 114, DateTimeKind.Local).AddTicks(1937), "Admin Kullanıcısı", new byte[] { 48, 49, 57, 50, 48, 50, 51, 97, 55, 98, 98, 100, 55, 51, 50, 53, 48, 53, 49, 54, 102, 48, 54, 57, 100, 102, 49, 56, 98, 53, 48, 48 }, "https://images.unsplash.com/photo-1566228015668-4c45dbc4e2f5?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTd8fGxvZ2lufGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=500&q=60", 1, "feyyazbalci" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[] { 1, 1, 1, "Eski usul ile stream datayı Deserialize edelim. Stream’in deserialize edilmesi için, “IAsyncEnumrable<T>” tipinde geri dönen asenkron çalışan zaten var olan “JsonSerializer.DeserializeAsync()” methodunu kullanalım. Stream’den asenkron çekilen data beklenerek bir result’a atılmakta, daha sonra gelen data da asenkron olarak ekrana basılmaktadır. Buradaki esas trick, streamden çekilen datanın bir akış şeklinde ekrana basılamamasıdır.", "InitialCreate", new DateTime(2022, 7, 9, 20, 35, 5, 86, DateTimeKind.Local).AddTicks(6086), new DateTime(2022, 7, 9, 20, 35, 5, 86, DateTimeKind.Local).AddTicks(4948), true, false, "InitialCreate", new DateTime(2022, 7, 9, 20, 35, 5, 86, DateTimeKind.Local).AddTicks(6666), ".Net 6 Yenilikleri", "Feyyaz Balcı", ".Net 6 Yenilikleri", ".Net 6, .Net Framework", "Default.jpg", ".Net 6 Yenilikleri", 1, 25 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[] { 2, 2, 1, "C++ programlama dili Java gibi programlama dillerine karsın programcıya güvenmektedirler ve güçlerinin büyük bir kısmını buradan alırlar. Bu sayede kullanıcıya daha yüksek performans sunabilmektedirler. Ama sağlamış olduğu bu avantajların yanında kullanıcıdan da daha bilinçli bir şekilde program geliştirmesini beklemektedir.", "InitialCreate", new DateTime(2022, 7, 9, 20, 35, 5, 86, DateTimeKind.Local).AddTicks(8058), new DateTime(2022, 7, 9, 20, 35, 5, 86, DateTimeKind.Local).AddTicks(8055), true, false, "InitialCreate", new DateTime(2022, 7, 9, 20, 35, 5, 86, DateTimeKind.Local).AddTicks(8059), "C++ Avantajları", "Feyyaz Balcı", "C++ Avantajları", "C++ Avantajları, C", "Default.jpg", "C++ Avantajları", 1, 33 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[] { 3, 3, 1, "Javascript ilk zamanlarında sadece browser tarafında çalışıyordu. Yani son kullanıcının gördüğü Front End dediğimiz, tasarımlar ve görüntü katmanında, sayfaları daha dinamik hale getirmek için kullanılırdı. İlk kullanım alanı budur. Mesela kullanıcı butona bastığında arka plan rengini değiştirmek gibi. NodeJS framework'ünün geliştirilmesi ile birlikte artık sunucu tarafında işlemler gerçekleştirmek için de kullanılmaktadır. Örn: oturum işlemleri, veritabanı işlemleri gibi.", "InitialCreate", new DateTime(2022, 7, 9, 20, 35, 5, 86, DateTimeKind.Local).AddTicks(8067), new DateTime(2022, 7, 9, 20, 35, 5, 86, DateTimeKind.Local).AddTicks(8065), true, false, "InitialCreate", new DateTime(2022, 7, 9, 20, 35, 5, 86, DateTimeKind.Local).AddTicks(8068), "Javascript'in Kullanım Alanları", "Feyyaz Balcı", "Javascript'in Kullanım Alanları", "HTML, CSS, Js", "Default.jpg", "Javascript'in Kullanım Alanları", 1, 41 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[] { 1, 1, "InitialCreate", new DateTime(2022, 7, 9, 20, 35, 5, 91, DateTimeKind.Local).AddTicks(8672), true, false, "InitialCreate", new DateTime(2022, 7, 9, 20, 35, 5, 91, DateTimeKind.Local).AddTicks(8684), "C# Makale yorumu", ".Net her yıl gittikçe güçleniyor" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[] { 2, 2, "InitialCreate", new DateTime(2022, 7, 9, 20, 35, 5, 91, DateTimeKind.Local).AddTicks(8700), true, false, "InitialCreate", new DateTime(2022, 7, 9, 20, 35, 5, 91, DateTimeKind.Local).AddTicks(8701), "C++ yorumu", "C++ kullanmak için mantıklı sebepler.." });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[] { 3, 3, "InitialCreate", new DateTime(2022, 7, 9, 20, 35, 5, 91, DateTimeKind.Local).AddTicks(8706), true, false, "InitialCreate", new DateTime(2022, 7, 9, 20, 35, 5, 91, DateTimeKind.Local).AddTicks(8707), "JS adamdır", "Yazılım olduğu sürece JS yaşayacak" });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
