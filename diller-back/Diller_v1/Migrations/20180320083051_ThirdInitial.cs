using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Diller_v1.Migrations
{
    public partial class ThirdInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "Order",
                newName: "managerId");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Order",
                newName: "clientId");

            migrationBuilder.AlterColumn<int>(
                name: "managerId",
                table: "Order",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "clientId",
                table: "Order",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Order_clientId",
                table: "Order",
                column: "clientId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_managerId",
                table: "Order",
                column: "managerId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Client_clientId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Manager_managerId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_clientId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_managerId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "managerId",
                table: "Order",
                newName: "ManagerId");

            migrationBuilder.RenameColumn(
                name: "clientId",
                table: "Order",
                newName: "ClientId");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "Order",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Order",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
