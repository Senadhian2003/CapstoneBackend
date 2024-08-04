using CoffeeStoreManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeStoreManagementApp.Context
{
    public class CoffeeManagementContext : DbContext
    {

        public CoffeeManagementContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<User> Users { get; set; }
        public DbSet<UserCredential> UserCredentials { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeCredential> EmployeeCredentials { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }


        public DbSet<Coffee> Coffees { get; set; }

        public DbSet<Milk> Milks { get; set; }

        public DbSet<Capacity> Capacities { get; set; }

        public DbSet<NonDairyAlternative> NonDairyAlternatives { get; set; }

        public DbSet<Topping> Toppings { get; set; }

        public DbSet<Sauce> Sauces { get; set; }

        public DbSet<CoffeeSauce> CoffeeSauces { get; set; }
        public DbSet<CoffeeMilk> CoffeeMilks { get; set; }

        public DbSet<CoffeeCapacity> CoffeeCapacities { get; set; }
        public DbSet<NonDairyAlternative> CoffeeNonDairyAlternatives { get; set; }

        public DbSet<CoffeeTopping> CoffeeToppings { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<OrderDetailStatus> OrderDetailStatuses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Coffee>()
            .HasKey(c => c.Id);

            modelBuilder.Entity<Sauce>()
            .HasKey(s => s.Id);

            modelBuilder.Entity<CoffeeSauce>()
           .HasKey(cs => new { cs.CoffeeId, cs.SauceId });

            modelBuilder.Entity<CoffeeSauce>()
            .HasOne(cs => cs.Coffee)
            .WithMany(c => c.AllowedSauces)
            .HasForeignKey(cs => cs.CoffeeId);

            modelBuilder.Entity<CoffeeSauce>()
            .HasOne(cs => cs.Sauce)
            .WithMany(s => s.AllowedCoffees)
            .HasForeignKey(cs => cs.SauceId);



            modelBuilder.Entity<CoffeeCapacity>()
           .HasKey(cs => new { cs.CoffeeId, cs.CapacityId });

            modelBuilder.Entity<CoffeeCapacity>()
            .HasOne(cs => cs.Coffee)
            .WithMany(c => c.AllowedCapacities)
            .HasForeignKey(cs => cs.CoffeeId);

            modelBuilder.Entity<CoffeeCapacity>()
            .HasOne(cs => cs.Capacity)
            .WithMany(s => s.AllowedCoffees)
            .HasForeignKey(cs => cs.CapacityId);



            modelBuilder.Entity<CoffeeMilk>()
           .HasKey(cs => new { cs.CoffeeId, cs.MilkId });

            modelBuilder.Entity<CoffeeMilk>()
            .HasOne(cs => cs.Coffee)
            .WithMany(c => c.AllowedMilks)
            .HasForeignKey(cs => cs.CoffeeId);

            modelBuilder.Entity<CoffeeMilk>()
            .HasOne(cs => cs.Milk)
            .WithMany(s => s.AllowedCoffees)
            .HasForeignKey(cs => cs.MilkId);





            modelBuilder.Entity<CoffeeNonDairyAlternative>()
           .HasKey(cs => new { cs.CoffeeId, cs.NonDairyAlternativeId });

            modelBuilder.Entity<CoffeeNonDairyAlternative>()
            .HasOne(cs => cs.Coffee)
            .WithMany(c => c.AllowedCoffeeNonDairyAlternatives)
            .HasForeignKey(cs => cs.CoffeeId);

            modelBuilder.Entity<CoffeeNonDairyAlternative>()
            .HasOne(cs => cs.NonDairyAlternative)
            .WithMany(s => s.AllowedCoffees)
            .HasForeignKey(cs => cs.NonDairyAlternativeId);


            modelBuilder.Entity<CoffeeTopping>()
          .HasKey(cs => new { cs.CoffeeId, cs.ToppingId });

            modelBuilder.Entity<CoffeeTopping>()
            .HasOne(cs => cs.Coffee)
            .WithMany(c => c.AllowedToppings)
            .HasForeignKey(cs => cs.CoffeeId);

            modelBuilder.Entity<CoffeeTopping>()
            .HasOne(cs => cs.Topping)
            .WithMany(s => s.AllowedCoffees)
            .HasForeignKey(cs => cs.ToppingId);







            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithOne(u => u.Cart)
                .HasForeignKey<Cart>(c => c.UserId);


            modelBuilder.Entity<Coffee>().HasData(
    new Coffee { Id = 1, Name = "Espresso", Description = "Strong black coffee", MaxAllowedSauces = 2, MaxAllowedToppings = 1, Price = 2.50, IsAvailable=1 },
    new Coffee { Id = 2, Name = "Cappuccino", Description = "Espresso with steamed milk foam", MaxAllowedSauces = 3, MaxAllowedToppings = 2, Price = 3.50, IsAvailable = 1 },
    new Coffee { Id = 3, Name = "Latte", Description = "Espresso with steamed milk", MaxAllowedSauces = 3, MaxAllowedToppings = 2, Price = 3.75, IsAvailable = 1 },
    new Coffee { Id = 4, Name = "Americano", Description = "Espresso diluted with hot water", MaxAllowedSauces = 2, MaxAllowedToppings = 1, Price = 3.00, IsAvailable = 1 },
    new Coffee { Id = 5, Name = "Mocha", Description = "Espresso with chocolate and steamed milk", MaxAllowedSauces = 2, MaxAllowedToppings = 3, Price = 4.00, IsAvailable = 1 }
);

            modelBuilder.Entity<Capacity>().HasData(
                new Capacity { CapacityId = 1, CapacityName = "Short", Price = 0.00 },
                new Capacity { CapacityId = 2, CapacityName = "Medium", Price = 0.50 },
                new Capacity { CapacityId = 3, CapacityName = "Tall", Price = 1.00 }
            );

            modelBuilder.Entity<NonDairyAlternative>().HasData(
                new NonDairyAlternative { Id = 1, Name = "Soy Milk", Price = 0.75 },
                new NonDairyAlternative { Id = 2, Name = "Almond Milk", Price = 0.75 },
                new NonDairyAlternative { Id = 3, Name = "Oat Milk", Price = 0.75 }
            );

            modelBuilder.Entity<Milk>().HasData(
                new Milk { Id = 1, Name = "Skimmed Milk", Price = 0.00 },
                new Milk { Id = 2, Name = "Whole Milk", Price = 0.00 },
                new Milk { Id = 3, Name = "Semi-Skimmed Milk", Price = 0.00 },
                new Milk { Id = 4, Name = "Lactose-Free Milk", Price = 0.50 }
            );

            modelBuilder.Entity<Sauce>().HasData(
                new Sauce { Id = 1, Name = "Vanilla Syrup", Price = 0.50 },
                new Sauce { Id = 2, Name = "Caramel Syrup", Price = 0.50 },
                new Sauce { Id = 3, Name = "Hazelnut Syrup", Price = 0.50 },
                new Sauce { Id = 4, Name = "Chocolate Sauce", Price = 0.50 },
                new Sauce { Id = 5, Name = "Pumpkin Spice Syrup", Price = 0.75 }
            );

            modelBuilder.Entity<Topping>().HasData(
                new Topping { Id = 1, Name = "Whipped Cream", Price = 0.50 },
                new Topping { Id = 2, Name = "Chocolate Chips", Price = 0.50 },
                new Topping { Id = 3, Name = "Cinnamon Powder", Price = 0.25 },
                new Topping { Id = 4, Name = "Caramel Drizzle", Price = 0.50 },
                new Topping { Id = 5, Name = "Cocoa Powder", Price = 0.25 }
            );

            // Intermediate table data
            modelBuilder.Entity<CoffeeCapacity>().HasData(
                new CoffeeCapacity { CoffeeId = 1, CapacityId = 1 },
                new CoffeeCapacity { CoffeeId = 1, CapacityId = 2 },
                new CoffeeCapacity { CoffeeId = 2, CapacityId = 1 },
                new CoffeeCapacity { CoffeeId = 2, CapacityId = 2 },
                new CoffeeCapacity { CoffeeId = 2, CapacityId = 3 },
                new CoffeeCapacity { CoffeeId = 3, CapacityId = 2 },
                new CoffeeCapacity { CoffeeId = 3, CapacityId = 3 },
                new CoffeeCapacity { CoffeeId = 4, CapacityId = 1 },
                new CoffeeCapacity { CoffeeId = 4, CapacityId = 2 },
                new CoffeeCapacity { CoffeeId = 4, CapacityId = 3 },
                new CoffeeCapacity { CoffeeId = 5, CapacityId = 2 },
                new CoffeeCapacity { CoffeeId = 5, CapacityId = 3 }
            );

            modelBuilder.Entity<CoffeeMilk>().HasData(
                new CoffeeMilk { CoffeeId = 1, MilkId = 1 },
                new CoffeeMilk { CoffeeId = 1, MilkId = 2 },
                new CoffeeMilk { CoffeeId = 2, MilkId = 1 },
                new CoffeeMilk { CoffeeId = 2, MilkId = 2 },
                new CoffeeMilk { CoffeeId = 2, MilkId = 3 },
                new CoffeeMilk { CoffeeId = 3, MilkId = 1 },
                new CoffeeMilk { CoffeeId = 3, MilkId = 2 },
                new CoffeeMilk { CoffeeId = 3, MilkId = 3 },
                new CoffeeMilk { CoffeeId = 3, MilkId = 4 },
                new CoffeeMilk { CoffeeId = 5, MilkId = 1 },
                new CoffeeMilk { CoffeeId = 5, MilkId = 2 }
            );

            modelBuilder.Entity<CoffeeNonDairyAlternative>().HasData(
                new CoffeeNonDairyAlternative { CoffeeId = 1, NonDairyAlternativeId = 1 },
                new CoffeeNonDairyAlternative { CoffeeId = 1, NonDairyAlternativeId = 2 },
                new CoffeeNonDairyAlternative { CoffeeId = 2, NonDairyAlternativeId = 1 },
                new CoffeeNonDairyAlternative { CoffeeId = 2, NonDairyAlternativeId = 2 },
                new CoffeeNonDairyAlternative { CoffeeId = 2, NonDairyAlternativeId = 3 },
                new CoffeeNonDairyAlternative { CoffeeId = 3, NonDairyAlternativeId = 1 },
                new CoffeeNonDairyAlternative { CoffeeId = 3, NonDairyAlternativeId = 2 },
                new CoffeeNonDairyAlternative { CoffeeId = 3, NonDairyAlternativeId = 3 },
                new CoffeeNonDairyAlternative { CoffeeId = 5, NonDairyAlternativeId = 1 },
                new CoffeeNonDairyAlternative { CoffeeId = 5, NonDairyAlternativeId = 2 }
            );

            modelBuilder.Entity<CoffeeSauce>().HasData(
                new CoffeeSauce { CoffeeId = 1, SauceId = 1 },
                new CoffeeSauce { CoffeeId = 1, SauceId = 2 },
                new CoffeeSauce { CoffeeId = 2, SauceId = 1 },
                new CoffeeSauce { CoffeeId = 2, SauceId = 2 },
                new CoffeeSauce { CoffeeId = 2, SauceId = 3 },
                new CoffeeSauce { CoffeeId = 3, SauceId = 1 },
                new CoffeeSauce { CoffeeId = 3, SauceId = 2 },
                new CoffeeSauce { CoffeeId = 3, SauceId = 3 },
                new CoffeeSauce { CoffeeId = 3, SauceId = 4 },
                new CoffeeSauce { CoffeeId = 4, SauceId = 1 },
                new CoffeeSauce { CoffeeId = 4, SauceId = 2 },
                new CoffeeSauce { CoffeeId = 5, SauceId = 1 },
                new CoffeeSauce { CoffeeId = 5, SauceId = 2 },
                new CoffeeSauce { CoffeeId = 5, SauceId = 4 }
            );

            modelBuilder.Entity<CoffeeTopping>().HasData(
                new CoffeeTopping { CoffeeId = 1, ToppingId = 3 },
                new CoffeeTopping { CoffeeId = 2, ToppingId = 1 },
                new CoffeeTopping { CoffeeId = 2, ToppingId = 3 },
                new CoffeeTopping { CoffeeId = 3, ToppingId = 1 },
                new CoffeeTopping { CoffeeId = 3, ToppingId = 3 },
                new CoffeeTopping { CoffeeId = 3, ToppingId = 4 },
                new CoffeeTopping { CoffeeId = 4, ToppingId = 3 },
                new CoffeeTopping { CoffeeId = 5, ToppingId = 1 },
                new CoffeeTopping { CoffeeId = 5, ToppingId = 2 },
                new CoffeeTopping { CoffeeId = 5, ToppingId = 4 },
                new CoffeeTopping { CoffeeId = 5, ToppingId = 5 }
            );





        }



    }
}
