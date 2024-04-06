using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobQuest.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobID",
                table: "Contracts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_JobID",
                table: "Contracts",
                column: "JobID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Jobs_JobID",
                table: "Contracts",
                column: "JobID",
                principalTable: "Jobs",
                principalColumn: "JobID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Jobs_JobID",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_JobID",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "JobID",
                table: "Contracts");
        }
    }
}
