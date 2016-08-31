using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Physics.Migrations
{
    public partial class DbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Formul",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    addF = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    uriImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formul", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Ptable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    mcontent = table.Column<string>(nullable: true),
                    @type = table.Column<string>(name: "type", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ptable", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "TaskTest",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    answer = table.Column<string>(nullable: true),
                    answers = table.Column<string>(nullable: true),
                    content = table.Column<string>(nullable: true),
                    @type = table.Column<string>(name: "type", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTest", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Formul");
            migrationBuilder.DropTable("Ptable");
            migrationBuilder.DropTable("TaskTest");
        }
    }
}
