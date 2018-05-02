using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Diller_v1.Migrations
{
    public partial class _2app : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Client_clientId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Manager_managerId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.RenameColumn(
                name: "managerId",
                table: "Order",
                newName: "ManagerId");

            migrationBuilder.RenameColumn(
                name: "clientId",
                table: "Order",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_managerId",
                table: "Order",
                newName: "IX_Order_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_clientId",
                table: "Order",
                newName: "IX_Order_ClientId");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdentityId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_AspNetUsers_IdentityId",
                        column: x => x.IdentityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_IdentityId",
                table: "Persons",
                column: "IdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Persons_ClientId",
                table: "Order",
                column: "ClientId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Persons_ManagerId",
                table: "Order",
                column: "ManagerId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Persons_ClientId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Persons_ManagerId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "Order",
                newName: "managerId");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Order",
                newName: "clientId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ManagerId",
                table: "Order",
                newName: "IX_Order_managerId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ClientId",
                table: "Order",
                newName: "IX_Order_clientId");

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Client_clientId",
                table: "Order",
                column: "clientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Manager_managerId",
                table: "Order",
                column: "managerId",
                principalTable: "Manager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
