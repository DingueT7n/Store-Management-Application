using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FondCaisseAdding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Caisses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CaisseStatusDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaisseId = table.Column<int>(type: "int", nullable: false),
                    CaisseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClosedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoneyBeforeInCaisse = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MoneyBefore = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MoneyAfterInCaisse = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MoneyAfter = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    OpeningTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosingTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: true),
                    IsBalanced = table.Column<bool>(type: "bit", nullable: false),
                    CaisseId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaisseStatusDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaisseStatusDetails_Caisses_CaisseId",
                        column: x => x.CaisseId,
                        principalTable: "Caisses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaisseStatusDetails_Caisses_CaisseId1",
                        column: x => x.CaisseId1,
                        principalTable: "Caisses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CaisseOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PerformedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaisseStatusDetailId = table.Column<int>(type: "int", nullable: false),
                    CaisseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaisseOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaisseOperations_CaisseStatusDetails_CaisseStatusDetailId",
                        column: x => x.CaisseStatusDetailId,
                        principalTable: "CaisseStatusDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaisseOperations_Caisses_CaisseId",
                        column: x => x.CaisseId,
                        principalTable: "Caisses",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Caisses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Caisses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Caisses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_CaisseOperations_CaisseId",
                table: "CaisseOperations",
                column: "CaisseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaisseOperations_CaisseStatusDetailId",
                table: "CaisseOperations",
                column: "CaisseStatusDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CaisseStatusDetails_CaisseId",
                table: "CaisseStatusDetails",
                column: "CaisseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaisseStatusDetails_CaisseId1",
                table: "CaisseStatusDetails",
                column: "CaisseId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaisseOperations");

            migrationBuilder.DropTable(
                name: "CaisseStatusDetails");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Caisses");
        }
    }
}
