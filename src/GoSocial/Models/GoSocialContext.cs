using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GoSocial.Models
{
    public partial class GoSocialContext : IdentityDbContext<ApplicationUser>
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var builder = new ConfigurationBuilder();
        //    var config = builder.Build();
        //    optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        //}
       
        public GoSocialContext(DbContextOptions<GoSocialContext> options)
            : base(options)
        {
        }
        protected GoSocialContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
            {
                b.Property<string>("Id");

                b.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken();

                b.Property<string>("Name")
                    .HasAnnotation("MaxLength", 256);

                b.Property<string>("NormalizedName")
                    .HasAnnotation("MaxLength", 256);

                b.HasKey("Id");

                b.HasIndex("NormalizedName")
                    .HasName("RoleNameIndex");

                b.ToTable("AspNetRoles");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("ClaimType");

                b.Property<string>("ClaimValue");

                b.Property<string>("RoleId")
                    .IsRequired();

                b.HasKey("Id");

                b.HasIndex("RoleId");

                b.ToTable("AspNetRoleClaims");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("ClaimType");

                b.Property<string>("ClaimValue");

                b.Property<string>("UserId")
                    .IsRequired();

                b.HasKey("Id");

                b.HasIndex("UserId");

                b.ToTable("AspNetUserClaims");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
            {
                b.Property<string>("LoginProvider");

                b.Property<string>("ProviderKey");

                b.Property<string>("ProviderDisplayName");

                b.Property<string>("UserId")
                    .IsRequired();

                b.HasKey("LoginProvider", "ProviderKey");

                b.HasIndex("UserId");

                b.ToTable("AspNetUserLogins");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
            {
                b.Property<string>("UserId");

                b.Property<string>("RoleId");

                b.HasKey("UserId", "RoleId");

                b.HasIndex("RoleId");

                b.HasIndex("UserId");

                b.ToTable("AspNetUserRoles");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
            {
                b.Property<string>("UserId");

                b.Property<string>("LoginProvider");

                b.Property<string>("Name");

                b.Property<string>("Value");

                b.HasKey("UserId", "LoginProvider", "Name");

                b.ToTable("AspNetUserTokens");
            });

            modelBuilder.Entity("GoSocial.Models.ApplicationUser", b =>
            {
                b.Property<string>("Id");

                b.Property<int>("AccessFailedCount");

                b.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken();

                b.Property<string>("Email")
                    .HasAnnotation("MaxLength", 256);

                b.Property<bool>("EmailConfirmed");

                b.Property<bool>("LockoutEnabled");

                b.Property<DateTimeOffset?>("LockoutEnd");

                b.Property<string>("NormalizedEmail")
                    .HasAnnotation("MaxLength", 256);

                b.Property<string>("NormalizedUserName")
                    .HasAnnotation("MaxLength", 256);

                b.Property<string>("PasswordHash");

                b.Property<string>("PhoneNumber");

                b.Property<bool>("PhoneNumberConfirmed");

                b.Property<string>("SecurityStamp");

                b.Property<bool>("TwoFactorEnabled");

                b.Property<string>("UserName")
                    .HasAnnotation("MaxLength", 256);

                b.HasKey("Id");

                b.HasIndex("NormalizedEmail")
                    .HasName("EmailIndex");

                b.HasIndex("NormalizedUserName")
                    .IsUnique()
                    .HasName("UserNameIndex");

                b.ToTable("AspNetUsers");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
            {
                b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                    .WithMany("Claims")
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
            {
                b.HasOne("GoSocial.Models.ApplicationUser")
                    .WithMany("Claims")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
            {
                b.HasOne("GoSocial.Models.ApplicationUser")
                    .WithMany("Logins")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
            {
                b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                    .WithMany("Users")
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("GoSocial.Models.ApplicationUser")
                    .WithMany("Roles")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.City1)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.CountryId).HasColumnName("countryId");

                entity.Property(e => e.StateId).HasColumnName("stateId");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_City_Country");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_City_State");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Country1)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasColumnName("countryCode")
                    .HasColumnType("varchar(5)");
            });

            modelBuilder.Entity<Industry>(entity =>
            {
                entity.ToTable("Industry", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Industry1)
                    .IsRequired()
                    .HasColumnName("Industry")
                    .HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<Platform>(entity =>
            {
                entity.ToTable("Platform", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Platform1)
                    .IsRequired()
                    .HasColumnName("platform")
                    .HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<Posting>(entity =>
            {
                entity.ToTable("Posting", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityId).HasColumnName("cityId");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(1000)");

                entity.Property(e => e.FollowersRequired)
                    .HasColumnName("followersRequired")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IndustryId).HasColumnName("industryId");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.PlatformId).HasColumnName("platformId");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal");

                entity.Property(e => e.PromotionType).HasColumnName("promotionType");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Posting)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Posting_City");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("State", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryId).HasColumnName("countryId");

                entity.Property(e => e.State1)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.StateCode)
                    .HasColumnName("stateCode")
                    .HasColumnType("varchar(5)");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_State_Country");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "dbo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasColumnType("varchar(100)");
            });

        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Industry> Industry { get; set; }
        public virtual DbSet<Platform> Platform { get; set; }
        public virtual DbSet<Posting> Posting { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}