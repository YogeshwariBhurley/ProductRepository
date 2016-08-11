namespace ProductDemoApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        PurchaseTransactionSummeries_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PurchaseTransactionSummeries", t => t.PurchaseTransactionSummeries_Id)
                .Index(t => t.PurchaseTransactionSummeries_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Rate = c.Double(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        ProductCategoryId = c.Int(nullable: false),
                        PurchaseTransactionDetails_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PurchaseTransactionDetails", t => t.PurchaseTransactionDetails_Id)
                .Index(t => t.PurchaseTransactionDetails_Id);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        Products_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Products_Id)
                .Index(t => t.Products_Id);
            
            CreateTable(
                "dbo.PurchaseTransactionDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rate = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        PurchaseTransactionSummaryId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchaseTransactionSummeries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        customerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "PurchaseTransactionSummeries_Id", "dbo.PurchaseTransactionSummeries");
            DropForeignKey("dbo.Products", "PurchaseTransactionDetails_Id", "dbo.PurchaseTransactionDetails");
            DropForeignKey("dbo.ProductCategories", "Products_Id", "dbo.Products");
            DropIndex("dbo.ProductCategories", new[] { "Products_Id" });
            DropIndex("dbo.Products", new[] { "PurchaseTransactionDetails_Id" });
            DropIndex("dbo.Customers", new[] { "PurchaseTransactionSummeries_Id" });
            DropTable("dbo.PurchaseTransactionSummeries");
            DropTable("dbo.PurchaseTransactionDetails");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
        }
    }
}
