namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEFdataaa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        CompanyName = c.String(),
                        Email = c.String(),
                        age = c.Int(nullable: false),
                        Salary = c.Single(nullable: false),
                        IsDeleted = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderNum = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Orders", new[] { "EmployeeId" });
            DropTable("dbo.Orders");
            DropTable("dbo.Employees");
        }
    }
}
