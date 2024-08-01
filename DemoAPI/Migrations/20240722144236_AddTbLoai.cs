using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTbLoai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "GiamGia",
                table: "HangHoa",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "MaLoai",
                table: "HangHoa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LoaiHH",
                columns: table => new
                {
                    MaLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiHH", x => x.MaLoai);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_MaLoai",
                table: "HangHoa",
                column: "MaLoai");

            migrationBuilder.AddForeignKey(
                name: "FK_HangHoa_LoaiHH_MaLoai",
                table: "HangHoa",
                column: "MaLoai",
                principalTable: "LoaiHH",
                principalColumn: "MaLoai");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HangHoa_LoaiHH_MaLoai",
                table: "HangHoa");

            migrationBuilder.DropTable(
                name: "LoaiHH");

            migrationBuilder.DropIndex(
                name: "IX_HangHoa_MaLoai",
                table: "HangHoa");

            migrationBuilder.DropColumn(
                name: "MaLoai",
                table: "HangHoa");

            migrationBuilder.AlterColumn<double>(
                name: "GiamGia",
                table: "HangHoa",
                type: "float",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }
    }
}
