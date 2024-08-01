using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Data
{
    public class HangHoaContext : DbContext
    {
        public HangHoaContext(DbContextOptions<HangHoaContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<DataHangHoa> HangHoas { get; set; }
        public DbSet<LoaiHH> LoaiHHs { get; set; }
        public DbSet<DonDatHang> donDatHangs { get; set; }
        public DbSet<ChiTietDonHang> chiTietDonHangs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonDatHang>(e => 
            {
                e.ToTable("DonDatHang");
                e.HasKey(dh => dh.MaDH);
                e.Property(dh => dh.Ngaydathang).HasDefaultValueSql("getutcdate()");
                e.Property(dh => dh.Nguoinhanhang).IsRequired().HasMaxLength(255);
            });

            modelBuilder.Entity<ChiTietDonHang>(entity => 
            {
                entity.ToTable("ChiTietDonHang");
                entity.HasKey(e => new { e.MaDH, e.MaHH });

                entity.HasOne(e => e.DonDatHang)
                .WithMany(e => e.ChiTietDonHangs)
                .HasForeignKey(e => e.MaDH)
                .HasConstraintName("FK_CTDH_DonHang");

                entity.HasOne(e => e.DataHangHoa)
                .WithMany(e => e.ChiTietDonHangs)
                .HasForeignKey(e => e.MaHH)
                .HasConstraintName("FK_CTDH_DataHangHoa");
            });
           
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserName).IsUnique();
                entity.Property(e => e.hoTen).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
            });
        }
    }
}
