namespace FinalPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201707240704595_UserFieldAdding1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Products", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.AspNetUsers", "DOB", c => c.DateTime(nullable: false));
            DropTable("dbo.Products");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.AspNetUsers", "DOB", c => c.DateTime());
            CreateIndex("dbo.Products", "ApplicationUser_Id");
            AddForeignKey("dbo.Products", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
