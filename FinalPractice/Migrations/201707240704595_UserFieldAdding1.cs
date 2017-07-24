namespace FinalPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFieldAdding1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CodeSKU = c.String(),
                        CategoryId = c.String(),
                        Category = c.String(),
                        SubCategoryId = c.String(),
                        SubCategory = c.String(),
                        Thumbnail = c.String(),
                        MainPhoto = c.String(),
                        Summary = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Featured = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Products", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Products");
        }
    }
}
