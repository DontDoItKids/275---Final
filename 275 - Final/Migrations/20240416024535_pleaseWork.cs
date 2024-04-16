using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _275___Final.Migrations
{
    /// <inheritdoc />
    public partial class pleaseWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "GainLoss",
                table: "Transactions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GainLoss",
                table: "Transactions");
        }
    }
}
