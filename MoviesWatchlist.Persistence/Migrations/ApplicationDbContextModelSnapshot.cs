﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesWatchlist.Persistence.Context;

#nullable disable

namespace MoviesWatchlist.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.5.22302.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MoviesWatchlist.Domain.Entities.WatchListItem", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("MovieId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsWatched")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastNotification")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "MovieId");

                    b.ToTable("WatchListItems");
                });
#pragma warning restore 612, 618
        }
    }
}