using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KamasutraAPI.Migrations
{
    public partial class TableNamesCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Position_Action_ActionId",
                table: "Position");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Action",
                table: "Action");

            migrationBuilder.RenameTable(
                name: "Action",
                newName: "KamasutraAction");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KamasutraAction",
                table: "KamasutraAction",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Position_KamasutraAction_ActionId",
                table: "Position",
                column: "ActionId",
                principalTable: "KamasutraAction",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Position_KamasutraAction_ActionId",
                table: "Position");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KamasutraAction",
                table: "KamasutraAction");

            migrationBuilder.RenameTable(
                name: "KamasutraAction",
                newName: "Action");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Action",
                table: "Action",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Position_Action_ActionId",
                table: "Position",
                column: "ActionId",
                principalTable: "Action",
                principalColumn: "Id");
        }
    }
}
