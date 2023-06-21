namespace work_02.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StockManagementScript : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ProductCategoryID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                    })
                .PrimaryKey(t => t.ProductCategoryID);
            
            CreateTable(
                "dbo.SavoyIceCreams",
                c => new
                    {
                        SavoyIceCreamId = c.Int(nullable: false, identity: true),
                        ProductCategoryID = c.Int(nullable: false),
                        Eja = c.Int(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NewProduct = c.Int(),
                        Total = c.Int(),
                        SalesQuantity = c.Int(),
                        TotalAmount = c.Decimal(precision: 18, scale: 2),
                        Return = c.Int(),
                        Remaining = c.Int(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.SavoyIceCreamId)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryID, cascadeDelete: true)
                .Index(t => t.ProductCategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SavoyIceCreams", "ProductCategoryID", "dbo.ProductCategories");
            DropIndex("dbo.SavoyIceCreams", new[] { "ProductCategoryID" });
            DropTable("dbo.SavoyIceCreams");
            DropTable("dbo.ProductCategories");
        }
    }
}
