using FamilyDinnerRedux.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace FamilyDinnerRedux.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<RecipeModel> Recipes { get; set; }
        public DbSet<RecipeIngredientsModel> RecipeIngredients { get; set; }
        public DbSet<IngredientModel> Ingredients { get; set; }
        public DbSet<ApplicationUser> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RecipeIngredientsModel>()
            .HasKey(o => new { o.RecipeId, o.IngredientID });
        }
    }
}