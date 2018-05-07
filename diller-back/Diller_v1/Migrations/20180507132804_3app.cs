using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Diller_v1.Migrations
{
    public partial class _3app : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AutoCategory",
                table: "AutoCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AutoBrand",
                table: "AutoBrand");

            migrationBuilder.RenameTable(
                name: "AutoCategory",
                newName: "AutoCategories");

            migrationBuilder.RenameTable(
                name: "AutoBrand",
                newName: "AutoBrands");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Order",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AutoCategories",
                table: "AutoCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AutoBrands",
                table: "AutoBrands",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrandId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    EnVolume = table.Column<string>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    Length = table.Column<string>(nullable: true),
                    MaxSpeed = table.Column<int>(nullable: false),
                    Width = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_AutoBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "AutoBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_AutoCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AutoCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CarId",
                table: "Order",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandId",
                table: "Cars",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Cars_CarId",
                table: "Order",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Cars_CarId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Order_CarId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AutoCategories",
                table: "AutoCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AutoBrands",
                table: "AutoBrands");

            migrationBuilder.RenameTable(
                name: "AutoCategories",
                newName: "AutoCategory");

            migrationBuilder.RenameTable(
                name: "AutoBrands",
                newName: "AutoBrand");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Order",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AutoCategory",
                table: "AutoCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AutoBrand",
                table: "AutoBrand",
                column: "Id");
        }
    }
}
