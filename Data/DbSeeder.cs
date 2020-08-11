using FoodTime.Data.Models;
using FoodTime.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Data
{
    public class DbSeeder
    {
        public DbSeeder(FoodTimeContext ctx)
        {
            Ctx = ctx;
        }

        public FoodTimeContext Ctx { get; }

        public void Seed()
        {
            //make sure the database has been created and we have permission to access it
            if(Ctx.Database.CanConnect())
            {
                //check to see if this table has been seeded before
                if (!Ctx.PastryType.Any())
                    CreatePastryTypes();
                //check to see if this table has been seeded before
                if (!Ctx.PastryFilling.Any())
                    CreatePastryFillings();
                //check to see if the pastry table has been seeded with data
                if (!Ctx.Pastry.Any())
                    CreatePastries();
            }
            else
            {
                bool testCreated = Ctx.Database.EnsureCreated();
                bool testConnected = Ctx.Database.CanConnect();
                throw new DbNotCreatedOrAccessibleException();
            }
        }

        //create the pastry fillings that are available
        private void CreatePastryFillings()
        {
            PastryFilling[] pastryFillings =
            {
                new PastryFilling { Id=0, Name = "Apple", Price = 3.00M },
                new PastryFilling { Id=0, Name = "Cherry", Price = 3.00M },
                new PastryFilling { Id=0, Name = "Apricot", Price = 4.00M },
                new PastryFilling { Id=0, Name = "Almond", Price = 5.00M },
                new PastryFilling { Id=0, Name = "Pecan", Price = 5.00M },
                new PastryFilling { Id=0, Name = "Meat", Price = 5.00M },
                new PastryFilling { Id=0, Name = "Chocolate", Price = 2.00M },
                new PastryFilling { Id=0, Name = "Cream Cheese", Price = 3.00M },
                new PastryFilling { Id=0, Name = "Blackberry", Price = 3.00M },
                new PastryFilling { Id=0, Name = "Blueberry", Price = 3.00M },
                new PastryFilling { Id=0, Name = "Pumpkin", Price = 5.00M },
                new PastryFilling { Id=0, Name = "Banana Cream", Price = 3.00M },
                new PastryFilling { Id=0, Name = "Lemon", Price = 3.00M }
            };
            Ctx.PastryFilling.AddRange(pastryFillings);
            Ctx.SaveChanges();
        }

        //Create the 5 types of pastry dough
        private void CreatePastryTypes()
        {
            PastryType[] pastryTypes = { 
                new PastryType { Id=0, Name="Flaky", Price = 10.00M },
                new PastryType { Id=0, Name="Shortcrust", Price = 7.00M },
                new PastryType { Id=0, Name="Puff", Price = 5.00M },
                new PastryType { Id=0, Name="Choux", Price = 6.00M },
                new PastryType { Id=0, Name="Filo", Price = 9.00M },
            };
            Ctx.PastryType.AddRange(pastryTypes);
            Ctx.SaveChanges();
        }

        //randomly generate 200 pastries
        private void CreatePastries()
        {
            Random rnd = new Random();
            List<Pastry> pastries = new List<Pastry>();

            for(int i = 0; i< 200; ++i)
            {
                //get a random filling
                PastryFilling pastryFilling = Ctx.PastryFilling.Skip(rnd.Next(0, Ctx.PastryFilling.Count())).Take(1).First();
                //get a random pastry type
                PastryType pastryType = Ctx.PastryType.Skip(rnd.Next(0, Ctx.PastryType.Count())).Take(1).First();
                pastries.Add
                    (
                        new Pastry
                        {
                            Id=0,
                            Description = $"A decadent pastry created with {pastryType.Name} dough, stuffed with {pastryFilling.Name}, and cooked to perfection!",
                            Name = $"{pastryType.Name} {pastryFilling.Name} Pastry",
                            PastryFilling = pastryFilling,
                            PastryType = pastryType,
                        }
                    );
            }
            Ctx.Pastry.AddRange(pastries);
            Ctx.SaveChanges();
        }
    }
}
