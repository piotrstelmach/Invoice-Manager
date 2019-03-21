namespace InvoiceManager.Migrations
{
    using InvoiceManager.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Quick_Invoice.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InvoiceManager.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InvoiceManager.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (!context.Roles.Any(r => r.Name == "Admin") || !context.Roles.Any(r => r.Name == "Employee"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };
                var role1 = new IdentityRole { Name = "Employee" };
                manager.Create(role);
                manager.Create(role1);
            }

            if (!context.Users.Any(u => u.UserName == "AppAdmin") || !context.Users.Any(u => u.UserName == "AppUser"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var adminUser = new ApplicationUser { UserName = "AdminUser" };
                var user = new ApplicationUser { UserName = "EmployeeUser" };

                manager.Create(adminUser, "testpasswd");
                manager.AddToRole(adminUser.Id, "Admin");

                manager.Create(user, "passwdempl");
                manager.AddToRole(user.Id, "Employee");
            }

           /* context.Addresses.AddOrUpdate(
                new Address() { Street = "Wall St.", House_Number = 11, Flat_Number = 5, Zip_code = "90210", Country = "USA" },
                new Address() { Street = "Privet Drive", House_Number = 5, Flat_Number = 18, Zip_code = "80321", Country = "USA" },
                new Address() { Street = "Washington St.", House_Number = 15, Flat_Number = 2, Zip_code = "12345", Country = "USA" }
                ); */

            context.PaymentTypes.AddOrUpdate(
                  new PaymentType() { Payment_Type = "Cash" },
                  new PaymentType() { Payment_Type = "Credit Card" },
                  new PaymentType() { Payment_Type = "Transfer" }
                );

            context.Products.AddOrUpdate(
                new Product() {  Product_name="Windows 10 x64 Home Edition", Price_netto=230.0, Price_brutto=277.7,VAT=19},
                new Product() { Product_name = "Office 2019 x64 Proffesional Plus", Price_netto = 430.0, Price_brutto = 511.7, VAT = 19 },
                new Product() { Product_name = "Windows Server 2012 RC", Price_netto = 500.8, Price_brutto = 615.984, VAT = 23 }
                );

            context.Services.AddOrUpdate(
                 new Service() { Service_name="Configuring Windows 10", Price_netto=100.0, Price_brutto=123.0,VAT=23 },
                 new Service() { Service_name = "Installation Software", Price_netto = 80.5, Price_brutto = 99.0, VAT = 23 },
                 new Service() { Service_name = "Repair software", Price_netto = 120.0, Price_brutto = 147.6, VAT = 23 }
                );

            context.Units.AddOrUpdate(
                  new Unit() { Unit_Name="Item"}
                );

        }
    }
}
