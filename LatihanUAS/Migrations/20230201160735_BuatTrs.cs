using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LatihanUAS.Migrations
{
    /// <inheritdoc />
    public partial class BuatTrs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transaksi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idHp = table.Column<int>(type: "int", nullable: false),
                    idKaryawan = table.Column<int>(type: "int", nullable: false),
                    Jumlah = table.Column<int>(type: "int", nullable: true),
                    TotalHarga = table.Column<int>(type: "int", nullable: true),
                    Tanggal = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaksi", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaksi");
        }
    }
}
