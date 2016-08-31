using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Physics;

namespace Physics.Migrations
{
    [DbContext(typeof(PhysicsContext))]
    partial class PhysicsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("Physics.Formul", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("addF");

                    b.Property<string>("description");

                    b.Property<string>("uriImage");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Physics.Ptable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("mcontent");

                    b.Property<string>("type");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Physics.TaskTest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("answer");

                    b.Property<string>("answers");

                    b.Property<string>("content");

                    b.Property<string>("type");

                    b.HasKey("ID");
                });
        }
    }
}
