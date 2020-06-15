using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeManager.API.Persistence.Migrations
{
    public partial class UserIdUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Recipes",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Recipes",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
