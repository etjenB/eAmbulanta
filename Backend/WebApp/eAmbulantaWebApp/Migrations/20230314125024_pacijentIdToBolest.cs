using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eAmbulantaWebApp.Migrations
{
    /// <inheritdoc />
    public partial class pacijentIdToBolest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Specijalizacija_SpecijalizacijaDoktorid",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "SpecijalizacijaDoktorid",
                table: "AspNetUsers",
                newName: "SpecijalizacijaDoktorId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_SpecijalizacijaDoktorid",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_SpecijalizacijaDoktorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Specijalizacija_SpecijalizacijaDoktorId",
                table: "AspNetUsers",
                column: "SpecijalizacijaDoktorId",
                principalTable: "Specijalizacija",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Specijalizacija_SpecijalizacijaDoktorId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "SpecijalizacijaDoktorId",
                table: "AspNetUsers",
                newName: "SpecijalizacijaDoktorid");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_SpecijalizacijaDoktorId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_SpecijalizacijaDoktorid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Specijalizacija_SpecijalizacijaDoktorid",
                table: "AspNetUsers",
                column: "SpecijalizacijaDoktorid",
                principalTable: "Specijalizacija",
                principalColumn: "id");
        }
    }
}
