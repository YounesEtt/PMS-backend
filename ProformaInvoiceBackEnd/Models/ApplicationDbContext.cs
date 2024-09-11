using Microsoft.EntityFrameworkCore;

namespace ProformaInvoiceBackEnd.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) { }
        public DbSet<User> user { get; set; }
        public DbSet<scenario> scenario { get; set; }
        public DbSet<shippoint> shippoint { get; set; }
        public DbSet<request> request { get; set; }
        public DbSet<Items> Item { get; set; }
        public DbSet<ApproverRequest> ApproverRequest { get; set; }
        public DbSet<request_item> requestsItem { get; set; }
        public DbSet<plant> plant { get; set; }
        public DbSet<Departement> departement { get; set; }
        public DbSet<approverscenario> Approverscenario { get; set; }
        public DbSet<scenario_items_configuration> scenarioItemsConfiguration { get; set; }
        public DbSet<UserPlant> userplant { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //class association
            modelBuilder.Entity<scenario_items_configuration>()
                .HasKey(e => new { e.Id_scenario, e.Id_request_item });

            //scenario_items_configuration with sceanrio
            modelBuilder.Entity<scenario_items_configuration>()
                .HasOne(s => s.Scenario)
                .WithMany(sc => sc.scenarioItemsconfiguration)
                .HasForeignKey(s => s.Id_scenario);

            //scenario_items_configuration with request_item
            modelBuilder.Entity<scenario_items_configuration>()
                .HasOne(s => s.RequestItem)
                .WithMany(sc => sc.scenarioItemsconfiguration)
                .HasForeignKey(s => s.Id_request_item);
            /***************************************************/
            //classe association USERPLANT
            modelBuilder.Entity<UserPlant>()
                .HasKey(e => new { e.Id });

            //scenario_items_configuration with sceanrio
            modelBuilder.Entity<UserPlant>()
                .HasOne(s => s.user)
                .WithMany(sc => sc.UserPlants)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //scenario_items_configuration with request_item
            modelBuilder.Entity<UserPlant>()
                .HasOne(s => s.plant)
                .WithMany(sc => sc.UserPlants)
                .HasForeignKey(s => s.Id_plant)
                .OnDelete(DeleteBehavior.Restrict);

            /***************************************************/
            /***************************************************/
            // Configuration de la relation entre request et shippoint

            modelBuilder.Entity<request>()
                .HasOne(r => r.shippoint)
                .WithMany()
                .HasForeignKey(r => r.shipId);

            /***************************************************/
           /* modelBuilder.Entity<request>()
                .Property(r => r.QUANTITY)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<request>()
                .Property(r => r.UNITVALUEFINANCE)
                .HasColumnType("decimal(18, 2)");
           */
            modelBuilder.Entity<request>()
                .Property(r => r.WEIGHT)
                .HasColumnType("decimal(18, 2)");
            /***************************************************/
            modelBuilder.Entity<request>()
                .HasMany(r => r.ApproverRequest)
                .WithOne(ar => ar.request)
                .HasForeignKey(ar => ar.RequestId)
                .OnDelete(DeleteBehavior.Cascade);
            /***************************************************/
            modelBuilder.Entity<request>()
                .HasMany(r => r.Item)
                .WithOne(ar => ar.request)
                .HasForeignKey(ar => ar.RequestNumber)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
