using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobQuest.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Jobs_JobID",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Clients_ClientID",
                table: "Jobs");

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "Jobs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "JobID",
                table: "Contracts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Jobs_JobID",
                table: "Contracts",
                column: "JobID",
                principalTable: "Jobs",
                principalColumn: "JobID");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Clients_ClientID",
                table: "Jobs",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Jobs_JobID",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Clients_ClientID",
                table: "Jobs");

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobID",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Jobs_JobID",
                table: "Contracts",
                column: "JobID",
                principalTable: "Jobs",
                principalColumn: "JobID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Clients_ClientID",
                table: "Jobs",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
