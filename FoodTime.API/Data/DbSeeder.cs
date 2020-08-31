using FoodTime.API.Exceptions;
using FoodTime.Infrastructure;
using FoodTime.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace FoodTime.API.Data
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
                //uncomment this if we want to reseed the db on start up
                //Ctx.Pastry.RemoveRange(Ctx.Set<Pastry>());
                //Ctx.PastryFilling.RemoveRange(Ctx.Set<PastryFilling>());
                //Ctx.PastryDough.RemoveRange(Ctx.Set<PastryDough>());
                //Ctx.SaveChanges();
                //check to see if this table has been seeded before
                if (!Ctx.PastryDough.Any())
                    CreatePastryDoughs();
                //check to see if this table has been seeded before
                if (!Ctx.PastryFilling.Any())
                    CreatePastryFillings();
                //check to see if the pastry table has been seeded with data
                if (!Ctx.Pastry.Any())
                    CreatePastries();
                if (!Ctx.PastryType.Any())
                    CreatePastryStocks();
            }
            else
            {
                bool testCreated = Ctx.Database.EnsureCreated();
                bool testConnected = Ctx.Database.CanConnect();
                throw new DbNotCreatedOrAccessibleException();
            }
        }

        private void CreatePastryStocks()
        {
            IEnumerable<PastryType> pastryTypes = Ctx.Pastry.GroupBy(e => new { e.PastryDoughId, e.PastryFillingId }).Select(e => new PastryType { PastryFillingId = e.Key.PastryFillingId, PastryDoughId = e.Key.PastryDoughId, Stock = e.Count() });
            Ctx.PastryType.AddRange(pastryTypes);
            Ctx.SaveChanges();
            foreach (PastryType pastryType in Ctx.PastryType.ToList())
            {
                var test = GetPastryPicture(pastryType.PastryFillingId, pastryType.PastryDoughId);
                pastryType.Image = GetPastryPicture(pastryType.PastryFillingId, pastryType.PastryDoughId);
                Ctx.SaveChanges();
                Console.WriteLine();

            }
        }

        private byte[] GetPastryPicture(int pastryFillingId, int pastryDoughId)
        {
            string pictureName = (Ctx.PastryDough.Find(pastryDoughId).Name) + Ctx.PastryFilling.Find(pastryFillingId).Name.Replace(" ", "");
            byte[] imageArray = System.IO.File.ReadAllBytes(Directory.GetCurrentDirectory() + $"/Images/{pictureName}.jpg");
            Image fullsizeImage = Image.FromStream(new MemoryStream(imageArray));
            Image thumbnail = fullsizeImage.GetThumbnailImage(250, 250, null, IntPtr.Zero);
            MemoryStream newStream = new MemoryStream();
            thumbnail.Save(newStream, ImageFormat.Jpeg);
            var temp = newStream.ToArray();
            return newStream.ToArray();
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
        private void CreatePastryDoughs()
        {
            PastryDough[] pastryTypes = { 
                new PastryDough { Id=0, Name="Flaky", Price = 10.00M },
                new PastryDough { Id=0, Name="Shortcrust", Price = 7.00M },
                new PastryDough { Id=0, Name="Puff", Price = 5.00M },
                new PastryDough { Id=0, Name="Choux", Price = 6.00M },
                new PastryDough { Id=0, Name="Filo", Price = 9.00M },
            };
            Ctx.PastryDough.AddRange(pastryTypes);
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
                PastryDough pastryType = Ctx.PastryDough.Skip(rnd.Next(0, Ctx.PastryDough.Count())).Take(1).First();
                pastries.Add
                    (
                        new Pastry
                        {
                            Id=0,
                            Description = $"A decadent pastry created with {pastryType.Name} dough, stuffed with {pastryFilling.Name}, and cooked to perfection!",
                            Name = $"{pastryType.Name} {pastryFilling.Name} Pastry",
                            PastryFilling = pastryFilling,
                            PastryDough = pastryType,
                        }
                    );
            }
            Ctx.Pastry.AddRange(pastries);
            Ctx.SaveChanges();
        }
    }
}
