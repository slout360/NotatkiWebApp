using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotatkiWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddDataEdycjiToNotatka : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataEdycji",
                table: "Notatkas",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataEdycji",
                table: "Notatkas");
        }
    }
}
