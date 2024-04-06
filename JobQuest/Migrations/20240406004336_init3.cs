using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobQuest.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_Contracts_JobID",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "JobID",
                table: "Contracts");

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "Jobs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddColumn<int>(
                name: "JobID",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_JobID",
                table: "Contracts",
                column: "JobID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Jobs_JobID",
                table: "Contracts",
                column: "JobID",
                principalTable: "Jobs",
                principalColumn: "JobID",
                onDelete: ReferentialAction.NoAction);

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
