using eat_easy_user_BE.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace eat_easy_user_BE.Src.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserProfileModel> UserProfiles { get; set; }
        public DbSet<ActivityLogModel> ActivityLogs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurazione per la relazione 1:1 tra User e UserProfile (se non usi Data Annotations)
            modelBuilder.Entity<UserModel>()
                .HasOne(u => u.UserProfile)
                .WithOne(up => up.User)
                .HasForeignKey<UserProfileModel>(up => up.UserId);
        }
    }
}
