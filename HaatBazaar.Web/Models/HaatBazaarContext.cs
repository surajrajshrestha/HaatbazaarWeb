using Microsoft.EntityFrameworkCore;

namespace HaatBazaar.Web.Models;

public partial class HaatBazaarContext : DbContext
{
    public HaatBazaarContext()
    {
    }

    public HaatBazaarContext(DbContextOptions<HaatBazaarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemImage> ItemImages { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserItem> UserItems { get; set; }

    public virtual DbSet<UserOtp> UserOtps { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07B875FD84");

            entity.ToTable("Category");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Image__3214EC07A4F45021");

            entity.ToTable("Image");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Path)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Item__3214EC073B37B0D0");

            entity.ToTable("Item");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Tags).HasMaxLength(100);
            entity.Property(e => e.Unit).HasMaxLength(10);

            entity.HasOne(d => d.Category).WithMany(p => p.Items)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Item_Category");
        });

        modelBuilder.Entity<ItemImage>(entity =>
        {
            entity.HasKey(e => new { e.ItemId, e.ImageId });

            entity.ToTable("ItemImage");

            entity.HasOne(d => d.Image).WithMany(p => p.ItemImages)
                .HasForeignKey(d => d.ImageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Image_ItemImage");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.ToTable("RefreshToken");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.Jwt).HasMaxLength(50);
            entity.Property(e => e.Token).HasMaxLength(512);

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RefreshToken_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC07718FA01D");

            entity.ToTable("User");

            entity.HasIndex(e => e.PhoneNumber, "Unique_PhoneNumber").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Latitude).HasMaxLength(50);
            entity.Property(e => e.Longitude).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.RegisteredDate).HasColumnType("datetime");
            entity.Property(e => e.Verified).HasDefaultValue(false);
        });

        modelBuilder.Entity<UserItem>(entity =>
        {
            entity.ToTable("UserItem");

            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.PriceUnit).HasMaxLength(10);
            entity.Property(e => e.Unit).HasMaxLength(10);

            entity.HasOne(d => d.User).WithMany(p => p.UserItems)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_User_UserItem");
        });

        modelBuilder.Entity<UserOtp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserOTP__1788CC4C8CBECB06");

            entity.ToTable("UserOTP");

            entity.Property(e => e.DateSent).HasColumnType("datetime");
            entity.Property(e => e.Otp)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("OTP");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
