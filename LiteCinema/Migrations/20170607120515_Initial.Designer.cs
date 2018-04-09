using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LiteCinema.Models;

namespace LiteCinema.Migrations
{
    [DbContext(typeof(CinemaContext))]
    [Migration("20170607120515_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LiteCinema.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("LiteCinema.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Buyer");

                    b.Property<string>("BuyerEmail");

                    b.Property<int>("BuyerPhone");

                    b.Property<int>("FilmId");

                    b.HasKey("TicketId");

                    b.HasIndex("FilmId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("LiteCinema.Models.Ticket", b =>
                {
                    b.HasOne("LiteCinema.Models.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
