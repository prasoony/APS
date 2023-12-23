﻿// <auto-generated />
using Aps.services.api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aps.services.api.Migrations
{
    [DbContext(typeof(AppDbcontext))]
    partial class AppDbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Aps.services.api.Model.Copoun", b =>
                {
                    b.Property<int>("CopounId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CopounId"));

                    b.Property<string>("CopounCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("DiscountAmount")
                        .HasColumnType("real");

                    b.Property<int>("MinAmount")
                        .HasColumnType("int");

                    b.HasKey("CopounId");

                    b.ToTable("Copouns");

                    b.HasData(
                        new
                        {
                            CopounId = 1,
                            CopounCode = "10OFF",
                            DiscountAmount = 10f,
                            MinAmount = 40
                        },
                        new
                        {
                            CopounId = 2,
                            CopounCode = "20OFF",
                            DiscountAmount = 20f,
                            MinAmount = 40
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
