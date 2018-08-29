namespace imaginaryPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeInitialMOdel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Photo", c => c.String());
            AddColumn("dbo.Users", "Gender", c => c.String());
            AddColumn("dbo.Users", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "ModifiedBy", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "isActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "isActive");
            DropColumn("dbo.Users", "ModifiedOn");
            DropColumn("dbo.Users", "CreatedOn");
            DropColumn("dbo.Users", "ModifiedBy");
            DropColumn("dbo.Users", "CreatedBy");
            DropColumn("dbo.Users", "Gender");
            DropColumn("dbo.Users", "Photo");
        }
    }
}
