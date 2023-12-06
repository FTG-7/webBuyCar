namespace PhamMinhNhut_DoAnWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandID = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                        CountryOfOrigin = c.String(),
                    })
                .PrimaryKey(t => t.BrandID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        BodyColor = c.String(),
                        BodyType = c.String(),
                        TransmissionType = c.String(),
                        Consumption = c.String(),
                        Power = c.String(),
                        Price = c.Int(nullable: false),
                        Fuel = c.String(),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductImages", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropIndex("dbo.Carts", new[] { "ProductID" });
            DropIndex("dbo.ProductImages", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropTable("dbo.Carts");
            DropTable("dbo.ProductImages");
            DropTable("dbo.Products");
            DropTable("dbo.Brands");
        }
    }
}
