using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing;
using PiecesOfArt_Application_Assignment.Models;
using System.Security.Cryptography;

namespace PiecesOfArt_Application_Assignment.ConnectionDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<PieceOfArt> pieceOfArts { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<LoyaltyCard> loyaltyCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<LoyaltyCard>().HasData
                (
                    new LoyaltyCard { LoyaltyCardId = 1, LoyaltyCardName = "Bronze", LoyaltyCardDescription = "10%" }

                );

            modelBuilder.Entity<User>().HasData
                (
                    new User { UserId=1,UserName="Magdy",UserEmail="Magdy@gmail.com",UserAge=17,LoyaltyCardId=1}


                );

            modelBuilder.Entity<PieceOfArt>().HasData
                (
                    new PieceOfArt { PieceOfArtId=1,Title= "Starry Night",Price=100.00,categoryid=1,userid=1,PublicationDate=DateTime.Now}

                );

            modelBuilder.Entity<Category>().HasData
                (
                    new Category { CategoryId=1,CategoryName= "Impressionism",CategoryDescription= "A 19th-century art movement characterized by small, thin brush strokes and emphasis on light and movement."}


                );


           
            base.OnModelCreating(modelBuilder);
        }
    }
}
