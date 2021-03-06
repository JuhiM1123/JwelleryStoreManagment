// <auto-generated />
using System;
using JwelleryStore.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JwelleryStore.DAL.Migrations
{
    [DbContext(typeof(JwelleryStoreDBContext))]
    partial class JwelleryStoreDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JwelleryStore.DAL.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("DiscountPrice")
                        .HasColumnType("float");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RoleId");

                    b.HasIndex(new[] { "RoleName" }, "IX_RoleName")
                        .IsUnique();

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            RoleName = "Normal"
                        },
                        new
                        {
                            RoleId = 2,
                            DiscountPrice = 2.0,
                            RoleName = "Privileged"
                        });
                });

            modelBuilder.Entity("JwelleryStore.DAL.Entities.UserDetail", b =>
                {
                    b.Property<int>("UserDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("UserDetailId");

                    b.HasIndex("RoleId");

                    b.HasIndex(new[] { "UserName", "Password" }, "IX_UserName_Password")
                        .IsUnique();

                    b.ToTable("UserDetails");

                    b.HasData(
                        new
                        {
                            UserDetailId = 1,
                            FirstName = "Normal",
                            LastName = "User",
                            Password = "nu",
                            RoleId = 1,
                            UserName = "normalUser"
                        },
                        new
                        {
                            UserDetailId = 2,
                            FirstName = "Privileged",
                            LastName = "User",
                            Password = "pu",
                            RoleId = 2,
                            UserName = "privilegedUser"
                        });
                });

            modelBuilder.Entity("JwelleryStore.DAL.Entities.UserDetail", b =>
                {
                    b.HasOne("JwelleryStore.DAL.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
