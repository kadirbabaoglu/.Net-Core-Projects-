using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KursProjesi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OgretmenId",
                table: "KursKayitlari",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_KursKayitlari_OgretmenId",
                table: "KursKayitlari",
                column: "OgretmenId");

            migrationBuilder.AddForeignKey(
                name: "FK_KursKayitlari_Ogretmenler_OgretmenId",
                table: "KursKayitlari",
                column: "OgretmenId",
                principalTable: "Ogretmenler",
                principalColumn: "OgretmenID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KursKayitlari_Ogretmenler_OgretmenId",
                table: "KursKayitlari");

            migrationBuilder.DropIndex(
                name: "IX_KursKayitlari_OgretmenId",
                table: "KursKayitlari");

            migrationBuilder.DropColumn(
                name: "OgretmenId",
                table: "KursKayitlari");
        }
    }
}
