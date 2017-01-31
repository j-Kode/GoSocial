using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GoSocial.Models;

namespace GoSocial.Data.Migrations
{
    [DbContext(typeof(GoSocialContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GoSocial.Models.ApplicationUser", b =>
            {
                b.Property<string>("Id");

                b.Property<int>("AccessFailedCount");

                b.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken();

                b.Property<DateTime>("CreateDate");

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

            modelBuilder.Entity("GoSocial.Models.City", b =>
            {
                b.Property<int>("Id")
                    .HasColumnName("id");

                b.Property<string>("City1")
                    .IsRequired()
                    .HasColumnName("city")
                    .HasColumnType("varchar(300)");

                b.Property<int?>("CountryId")
                    .HasColumnName("countryId");

                b.Property<int?>("StateId")
                    .HasColumnName("stateId");

                b.HasKey("Id");

                b.HasIndex("CountryId");

                b.HasIndex("StateId");

                b.ToTable("City", "dbo");
            });

            modelBuilder.Entity("GoSocial.Models.Country", b =>
            {
                b.Property<int>("Id")
                    .HasColumnName("id");

                b.Property<string>("Country1")
                    .IsRequired()
                    .HasColumnName("country")
                    .HasColumnType("varchar(200)");

                b.Property<string>("CountryCode")
                    .IsRequired()
                    .HasColumnName("countryCode")
                    .HasColumnType("varchar(5)");

                b.HasKey("Id");

                b.ToTable("Country", "dbo");
            });

            modelBuilder.Entity("GoSocial.Models.Industry", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                b.Property<string>("Industry1")
                    .IsRequired()
                    .HasColumnName("Industry")
                    .HasColumnType("varchar(200)");

                b.HasKey("Id");

                b.ToTable("Industry", "dbo");
            });

            modelBuilder.Entity("GoSocial.Models.Message", b =>
            {
                b.Property<int>("MessageId")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                b.Property<DateTime>("CreateDate")
                    .HasColumnName("createDate")
                    .HasColumnType("datetime");

                b.Property<string>("FromUserId")
                    .IsRequired()
                    .HasColumnName("fromUserId")
                    .HasColumnType("varchar(100)");

                b.Property<string>("MessageSubject")
                    .IsRequired()
                    .HasColumnName("messageTitle")
                    .HasColumnType("varchar(100)");

                b.Property<string>("MessageText")
                    .IsRequired()
                    .HasColumnName("message")
                    .HasColumnType("varchar(1500)");

                b.Property<int>("StatusId")
                    .HasColumnName("state");

                b.Property<string>("ToUserId")
                    .IsRequired()
                    .HasColumnName("toUserId")
                    .HasColumnType("varchar(100)");

                b.HasKey("MessageId");

                b.HasIndex("FromUserId");

                b.HasIndex("StatusId");

                b.HasIndex("ToUserId");

                b.ToTable("Message", "dbo");
            });

            modelBuilder.Entity("GoSocial.Models.MessageStatus", b =>
            {
                b.Property<int>("StatusId")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                b.Property<string>("Status")
                    .IsRequired()
                    .HasColumnName("state")
                    .HasColumnType("varchar(50)");

                b.HasKey("StatusId");

                b.ToTable("MessageState", "dbo");
            });

            modelBuilder.Entity("GoSocial.Models.Platform", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                b.Property<string>("Platform1")
                    .IsRequired()
                    .HasColumnName("platform")
                    .HasColumnType("varchar(200)");

                b.HasKey("Id");

                b.ToTable("Platform", "dbo");
            });

            modelBuilder.Entity("GoSocial.Models.Posting", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                b.Property<int>("CityId")
                    .HasColumnName("cityId");

                b.Property<DateTime>("Date")
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                b.Property<string>("Description")
                    .HasColumnName("description")
                    .HasColumnType("varchar(1000)");

                b.Property<long>("FollowersRequired")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("followersRequired")
                    .HasDefaultValueSql("0");

                b.Property<int>("IndustryId")
                    .HasColumnName("industryId");

                b.Property<bool?>("IsDeleted")
                    .HasColumnName("isDeleted");

                b.Property<int>("PlatformId")
                    .HasColumnName("platformId");

                b.Property<decimal>("Price")
                    .HasColumnName("price")
                    .HasColumnType("decimal");

                b.Property<int?>("PromotionType")
                    .HasColumnName("promotionType");

                b.Property<string>("Title")
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(300)");

                b.Property<int?>("Type")
                    .HasColumnName("type");

                b.Property<string>("UserId")
                    .HasColumnName("userId")
                    .HasColumnType("varchar(100)");

                b.HasKey("Id");

                b.HasIndex("CityId");

                b.HasIndex("UserId");

                b.ToTable("Posting", "dbo");
            });

            modelBuilder.Entity("GoSocial.Models.State", b =>
            {
                b.Property<int>("Id")
                    .HasColumnName("id");

                b.Property<int>("CountryId")
                    .HasColumnName("countryId");

                b.Property<string>("State1")
                    .IsRequired()
                    .HasColumnName("state")
                    .HasColumnType("varchar(200)");

                b.Property<string>("StateCode")
                    .HasColumnName("stateCode")
                    .HasColumnType("varchar(5)");

                b.HasKey("Id");

                b.HasIndex("CountryId");

                b.ToTable("State", "dbo");
            });

            modelBuilder.Entity("GoSocial.Models.User", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(300)");

                b.Property<string>("FirstName")
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasColumnType("varchar(200)");

                b.Property<string>("LastName")
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasColumnType("varchar(300)");

                b.Property<string>("UserName")
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasColumnType("varchar(100)");

                b.HasKey("Id");

                b.ToTable("User", "dbo");
            });

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

            modelBuilder.Entity("GoSocial.Models.City", b =>
            {
                b.HasOne("GoSocial.Models.Country", "Country")
                    .WithMany("City")
                    .HasForeignKey("CountryId")
                    .HasConstraintName("FK_City_Country");

                b.HasOne("GoSocial.Models.State", "State")
                    .WithMany("City")
                    .HasForeignKey("StateId")
                    .HasConstraintName("FK_City_State");
            });

            modelBuilder.Entity("GoSocial.Models.Message", b =>
            {
                b.HasOne("GoSocial.Models.ApplicationUser", "FromUser")
                    .WithMany()
                    .HasForeignKey("FromUserId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("GoSocial.Models.MessageStatus", "Status")
                    .WithMany()
                    .HasForeignKey("StatusId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("GoSocial.Models.ApplicationUser", "ToUser")
                    .WithMany()
                    .HasForeignKey("ToUserId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("GoSocial.Models.Posting", b =>
            {
                b.HasOne("GoSocial.Models.City", "City")
                    .WithMany("Posting")
                    .HasForeignKey("CityId")
                    .HasConstraintName("FK_Posting_City");

                b.HasOne("GoSocial.Models.ApplicationUser", "User")
                    .WithMany()
                    .HasForeignKey("UserId");
            });

            modelBuilder.Entity("GoSocial.Models.State", b =>
            {
                b.HasOne("GoSocial.Models.Country", "Country")
                    .WithMany("State")
                    .HasForeignKey("CountryId")
                    .HasConstraintName("FK_State_Country");
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
        }
    }
}
