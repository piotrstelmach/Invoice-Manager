namespace InvoiceManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        House_Number = c.Int(nullable: false),
                        Flat_Number = c.Int(nullable: false),
                        Country = c.String(nullable: false),
                        Zip_code = c.String(nullable: false, maxLength: 6),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        id = c.Int(nullable: false),
                        First_name = c.String(nullable: false),
                        Last_name = c.String(nullable: false),
                        Phone_number = c.String(),
                        Email = c.String(),
                        NIP = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Addresses", t => t.id)
                .ForeignKey("dbo.Companies", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Company_Name = c.String(nullable: false),
                        NIP = c.String(nullable: false, maxLength: 10),
                        KRS = c.String(nullable: false, maxLength: 10),
                        Bank_Number = c.String(nullable: false),
                        Bank_swift = c.String(),
                        Address_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Addresses", t => t.Address_id, cascadeDelete: true)
                .Index(t => t.Address_id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        id = c.Int(nullable: false),
                        Invoice_number = c.String(nullable: false),
                        Amount = c.Int(nullable: false),
                        Total_price = c.Double(nullable: false),
                        Create_date = c.DateTime(nullable: false),
                        PaymentDeadline = c.DateTime(nullable: false),
                        LeftToPay = c.Double(nullable: false),
                        Remarks = c.String(),
                        Product_id = c.Int(),
                        Service_id = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Clients", t => t.id)
                .ForeignKey("dbo.PaymentTypes", t => t.id)
                .ForeignKey("dbo.Products", t => t.Product_id)
                .ForeignKey("dbo.Sellers", t => t.id)
                .ForeignKey("dbo.Services", t => t.Service_id, cascadeDelete: true)
                .ForeignKey("dbo.Units", t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.id)
                .Index(t => t.Product_id)
                .Index(t => t.Service_id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Payment_Type = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Product_name = c.String(nullable: false, maxLength: 160),
                        Price_netto = c.Double(nullable: false),
                        Price_brutto = c.Double(nullable: false),
                        VAT = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        id = c.Int(nullable: false),
                        First_name = c.String(nullable: false),
                        Last_name = c.String(nullable: false),
                        Phone_number = c.String(),
                        Email = c.String(),
                        NIP = c.String(nullable: false, maxLength: 10),
                        Company_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Addresses", t => t.id)
                .ForeignKey("dbo.Companies", t => t.Company_id)
                .Index(t => t.id)
                .Index(t => t.Company_id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Service_name = c.String(nullable: false, maxLength: 160),
                        Price_netto = c.Double(nullable: false),
                        Price_brutto = c.Double(nullable: false),
                        VAT = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Unit_Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Invoices", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Invoices", "id", "dbo.Units");
            DropForeignKey("dbo.Invoices", "Service_id", "dbo.Services");
            DropForeignKey("dbo.Invoices", "id", "dbo.Sellers");
            DropForeignKey("dbo.Sellers", "Company_id", "dbo.Companies");
            DropForeignKey("dbo.Sellers", "id", "dbo.Addresses");
            DropForeignKey("dbo.Invoices", "Product_id", "dbo.Products");
            DropForeignKey("dbo.Invoices", "id", "dbo.PaymentTypes");
            DropForeignKey("dbo.Invoices", "id", "dbo.Clients");
            DropForeignKey("dbo.Clients", "id", "dbo.Companies");
            DropForeignKey("dbo.Companies", "Address_id", "dbo.Addresses");
            DropForeignKey("dbo.Clients", "id", "dbo.Addresses");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Sellers", new[] { "Company_id" });
            DropIndex("dbo.Sellers", new[] { "id" });
            DropIndex("dbo.Invoices", new[] { "User_Id" });
            DropIndex("dbo.Invoices", new[] { "Service_id" });
            DropIndex("dbo.Invoices", new[] { "Product_id" });
            DropIndex("dbo.Invoices", new[] { "id" });
            DropIndex("dbo.Companies", new[] { "Address_id" });
            DropIndex("dbo.Clients", new[] { "id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Units");
            DropTable("dbo.Services");
            DropTable("dbo.Sellers");
            DropTable("dbo.Products");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.Invoices");
            DropTable("dbo.Companies");
            DropTable("dbo.Clients");
            DropTable("dbo.Addresses");
        }
    }
}
