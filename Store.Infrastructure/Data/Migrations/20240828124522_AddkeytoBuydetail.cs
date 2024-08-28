using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddkeytoBuydetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder.ActiveProvider == "Microsoft.EntityFrameworkCore.SqlServer")
            {
                // Check if the column exists
                migrationBuilder.DropColumn(
                    name: "Id",
                    table: "BuyDetails");

                // Recreate the Id column with the identity property
                migrationBuilder.AddColumn<int>(
                    name: "Id",
                    table: "BuyDetails",
                    type: "int",
                    nullable: false,
                    defaultValue: 0)
                    .Annotation("SqlServer:Identity", "1, 1");

                // Add the primary key
                migrationBuilder.AddPrimaryKey(
                    name: "PK_BuyDetails",
                    table: "BuyDetails",
                    column: "Id");
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the primary key
            migrationBuilder.DropPrimaryKey(
                name: "PK_BuyDetails",
                table: "BuyDetails");

            // Drop the Id column
            migrationBuilder.DropColumn(
                name: "Id",
                table: "BuyDetails");

            // Recreate the Id column without identity property
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BuyDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // Recreate the primary key if needed
            migrationBuilder.AddPrimaryKey(
                name: "PK_BuyDetails",
                table: "BuyDetails",
                column: "Id");
        }
    }
}
