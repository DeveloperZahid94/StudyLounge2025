using Microsoft.EntityFrameworkCore;
using StudyLounge25.DomainModels;
using StudyLounge25.DTO;

namespace StudyLounge25.Data
{
    public class SLdbContext : DbContext
    {
        public SLdbContext(DbContextOptions options) : base(options)
        { }

        public virtual DbSet<StudentModal> Students { get; set; }
        public virtual DbSet<CabinModal> Cabins { get; set; }
        public virtual DbSet<CabinAssignmentModal> CabinAssignments { get; set; }
        public virtual DbSet<FeeModal> Fees { get; set; }
        public virtual DbSet<AdminLogModal> AdminLogs { get; set; }
        public virtual DbSet<CabinSpecificationModal> CabinSpecifications { get; set; }

        public DbSet<FeeSummaryCustom> FeeSummaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and constraints
            modelBuilder.Entity<CabinAssignmentModal>()
                .HasOne(ca => ca.Student)
                .WithMany(s => s.CabinAssignments)
                .HasForeignKey(ca => ca.StudentId);

            modelBuilder.Entity<CabinAssignmentModal>()
                .HasKey(ca => ca.AssignmentId);  // Define primary key

            modelBuilder.Entity<CabinAssignmentModal>()
                .HasOne(ca => ca.Cabin)
                .WithMany(c => c.CabinAssignments)
                .HasForeignKey(ca => ca.CabinId);

            modelBuilder.Entity<FeeModal>()
                .HasOne(f => f.Student)
                .WithMany(s => s.Fees)
                .HasForeignKey(f => f.StudentId);

            modelBuilder.Entity<FeeModal>()
                .HasKey(ca => ca.FeeId);  // Define primary key


            modelBuilder.Entity<CabinSpecificationModal>()
                .HasOne(cs => cs.Cabin)
                .WithMany(c => c.CabinSpecifications)
                .HasForeignKey(cs => cs.CabinId);

            modelBuilder.Entity<CabinSpecificationModal>()
               .HasKey(ca => ca.SpecificationId);

            modelBuilder.Entity<StudentModal>()
               .HasKey(ca => ca.StudentId);

            modelBuilder.Entity<AdminLogModal>()
               .HasKey(ca => ca.LogId);

            modelBuilder.Entity<CabinModal>()
               .HasKey(ca => ca.CabinId);

            modelBuilder.Entity<FeeSummaryCustom>().HasNoKey().ToView(null);

        }
    }
}