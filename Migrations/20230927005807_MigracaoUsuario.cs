using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "FotoPersonagem",
                table: "TB_PERSONAGENS",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "usuarioId",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TB_USERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Perfil = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Jogador"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USERS", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FotoPersonagem", "usuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FotoPersonagem", "usuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FotoPersonagem", "usuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FotoPersonagem", "usuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FotoPersonagem", "usuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FotoPersonagem", "usuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FotoPersonagem", "usuarioId" },
                values: new object[] { null, null });

            migrationBuilder.InsertData(
                table: "TB_USERS",
                columns: new[] { "Id", "DataAcesso", "Email", "Foto", "Latitude", "Longitude", "PasswordHash", "PasswordSalt", "Perfil", "Username" },
                values: new object[] { 1, null, "seuEmail@gmail.com", null, -23.520024100000001, -46.596497999999997, new byte[] { 205, 214, 43, 139, 103, 147, 94, 18, 248, 172, 80, 147, 217, 11, 246, 194, 131, 185, 116, 240, 50, 40, 198, 71, 238, 3, 109, 83, 142, 102, 103, 82, 174, 155, 9, 174, 170, 244, 244, 217, 157, 92, 186, 220, 239, 124, 235, 149, 36, 170, 195, 132, 195, 210, 101, 41, 119, 207, 138, 155, 177, 154, 142, 1 }, new byte[] { 29, 125, 95, 16, 252, 61, 66, 242, 82, 198, 206, 211, 53, 127, 171, 54, 77, 81, 221, 140, 129, 42, 101, 83, 242, 85, 177, 129, 58, 221, 196, 253, 153, 121, 222, 202, 28, 48, 5, 205, 233, 209, 170, 69, 202, 255, 215, 156, 239, 93, 44, 179, 175, 233, 20, 150, 58, 19, 165, 82, 100, 73, 83, 213, 100, 70, 247, 242, 240, 110, 222, 110, 156, 119, 121, 65, 209, 9, 59, 223, 41, 195, 53, 86, 113, 81, 225, 179, 33, 239, 218, 117, 204, 6, 133, 57, 197, 97, 213, 152, 219, 175, 177, 13, 79, 217, 184, 245, 217, 192, 236, 97, 0, 250, 149, 147, 100, 15, 107, 126, 40, 160, 74, 180, 59, 26, 65, 43 }, "Admin", "UsuarioAdmin" });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_usuarioId",
                table: "TB_PERSONAGENS",
                column: "usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PERSONAGENS_TB_USERS_usuarioId",
                table: "TB_PERSONAGENS",
                column: "usuarioId",
                principalTable: "TB_USERS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PERSONAGENS_TB_USERS_usuarioId",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropTable(
                name: "TB_USERS");

            migrationBuilder.DropIndex(
                name: "IX_TB_PERSONAGENS_usuarioId",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "FotoPersonagem",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "usuarioId",
                table: "TB_PERSONAGENS");
        }
    }
}
