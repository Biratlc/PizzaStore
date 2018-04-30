using Microsoft.EntityFrameworkCore;

namespace PizzaGuys.Models
{
    public partial class PizzaGuysContext : DbContext
    {
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Amount> Amount { get; set; }
        public virtual DbSet<CardInfo> CardInfo { get; set; }
        public virtual DbSet<CardType> CardType { get; set; }
        public virtual DbSet<Coupon> Coupon { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<DeliveryStatus> DeliveryStatus { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentOption> PaymentOption { get; set; }
        public virtual DbSet<ToppingInfo> ToppingInfo { get; set; }
        public virtual DbSet<Toppings> Toppings { get; set; }
        public virtual DbSet<TotalAmounts> TotalAmounts { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }

        public PizzaGuysContext(DbContextOptions<PizzaGuysContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AddressLine2).HasMaxLength(50);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnType("nchar(15)");
            });

            modelBuilder.Entity<Amount>(entity =>
            {
                entity.Property(e => e.Amount1)
                    .HasColumnName("Amount")
                    .HasColumnType("money");

                entity.Property(e => e.Description).HasMaxLength(15);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Amount)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Amount_Order");
            });

            modelBuilder.Entity<CardInfo>(entity =>
            {
                entity.Property(e => e.Ccv).HasColumnName("ccv");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(50);

                entity.HasOne(d => d.CardType)
                    .WithMany()
                    .HasForeignKey(d => d.CardTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CardInfo_CardType");
            });

            modelBuilder.Entity<CardType>(entity =>
            {
                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.Property(e => e.ValidDate).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Coupon)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Coupon_Customer");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nchar(50)");

                entity.HasOne(d => d.AddressNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.Address)
                    .HasConstraintName("FK_Customer_Address");
            });

            modelBuilder.Entity<DeliveryStatus>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nchar(50)");

                entity.Property(e => e.VehicleId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Vehicle");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Customer");

                entity.HasOne(d => d.DeliveryStatusNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.DeliveryStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_DeliveryStatus");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Employee");

                entity.HasOne(d => d.OrderNavigation)
                    .WithOne(p => p.InverseOrderNavigation)
                    .HasForeignKey<Order>(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Order");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.OrderId });

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Customer");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Order");

                entity.HasOne(d => d.PaymentOptionNavigation)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.PaymentOption)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_PaymentOption");
            });

            modelBuilder.Entity<PaymentOption>(entity =>
            {
                entity.Property(e => e.Options)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CardInfo)
                    .WithMany(p => p.PaymentOption)
                    .HasForeignKey(d => d.CardInfoId)
                    .HasConstraintName("FK_PaymentOption_CardInfo");
            });

            modelBuilder.Entity<ToppingInfo>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nchar(50)");

                entity.Property(e => e.Price).HasColumnType("decimal(3, 2)");
            });

            modelBuilder.Entity<Toppings>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ToppingId });

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Toppings)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Toppings_Order");

                entity.HasOne(d => d.Topping)
                    .WithMany(p => p.Toppings)
                    .HasForeignKey(d => d.ToppingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Toppings_ToppingInfo");
            });

            modelBuilder.Entity<TotalAmounts>(entity =>
            {
                entity.HasKey(e => e.TotalOrdersId);

                entity.Property(e => e.Totalamounts).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TotalAmounts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TotalAmounts_Customer1");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.LicensePlateNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
