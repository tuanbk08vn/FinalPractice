namespace FinalPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFieldAdding : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address1", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address2", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "State", c => c.String());
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
            AddColumn("dbo.AspNetUsers", "Logo", c => c.String());
            AddColumn("dbo.AspNetUsers", "DOB", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DOB");
            DropColumn("dbo.AspNetUsers", "Logo");
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Address2");
            DropColumn("dbo.AspNetUsers", "Address1");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
