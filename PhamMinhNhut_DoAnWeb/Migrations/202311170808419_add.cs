namespace PhamMinhNhut_DoAnWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "BodyColor", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "BodyType", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "TransmissionType", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Consumption", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Power", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Fuel", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Fuel", c => c.String());
            AlterColumn("dbo.Products", "Power", c => c.String());
            AlterColumn("dbo.Products", "Consumption", c => c.String());
            AlterColumn("dbo.Products", "TransmissionType", c => c.String());
            AlterColumn("dbo.Products", "BodyType", c => c.String());
            AlterColumn("dbo.Products", "BodyColor", c => c.String());
            AlterColumn("dbo.Products", "ProductName", c => c.String());
        }
    }
}
