using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobQuest.Migrations
{
    /// <inheritdoc />
    public partial class last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Freelancers_Clients_ClientID",
                table: "Freelancers");

            migrationBuilder.RenameColumn(
                name: "JObTitle",
                table: "Jobs",
                newName: "JobTitle");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "Freelancers",
                newName: "AssignedClientId");

            migrationBuilder.RenameColumn(
                name: "FreelancerID",
                table: "Freelancers",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Freelancers_ClientID",
                table: "Freelancers",
                newName: "IX_Freelancers_AssignedClientId");

            migrationBuilder.AlterColumn<decimal>(
                name: "JobBudget",
                table: "Jobs",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payments_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    ProposalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProposalText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobID = table.Column<int>(type: "int", nullable: false),
                    FreelancerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.ProposalID);
                    table.ForeignKey(
                        name: "FK_Proposals_Freelancers_FreelancerID",
                        column: x => x.FreelancerID,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proposals_Jobs_JobID",
                        column: x => x.JobID,
                        principalTable: "Jobs",
                        principalColumn: "JobID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    ContractID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScopeOfWork = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    FreelancerID = table.Column<int>(type: "int", nullable: false),
                    JobID = table.Column<int>(type: "int", nullable: false),
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.ContractID);
                    table.ForeignKey(
                        name: "FK_Contracts_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Freelancers_FreelancerID",
                        column: x => x.FreelancerID,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Jobs_JobID",
                        column: x => x.JobID,
                        principalTable: "Jobs",
                        principalColumn: "JobID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Payments_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payments",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ClientID",
                table: "Contracts",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_FreelancerID",
                table: "Contracts",
                column: "FreelancerID");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_JobID",
                table: "Contracts",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_PaymentID",
                table: "Contracts",
                column: "PaymentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ClientID",
                table: "Payments",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_FreelancerID",
                table: "Proposals",
                column: "FreelancerID");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_JobID",
                table: "Proposals",
                column: "JobID");

            migrationBuilder.AddForeignKey(
                name: "FK_Freelancers_Clients_AssignedClientId",
                table: "Freelancers",
                column: "AssignedClientId",
                principalTable: "Clients",
                principalColumn: "ClientID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Freelancers_Clients_AssignedClientId",
                table: "Freelancers");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.RenameColumn(
                name: "JobTitle",
                table: "Jobs",
                newName: "JObTitle");

            migrationBuilder.RenameColumn(
                name: "AssignedClientId",
                table: "Freelancers",
                newName: "ClientID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Freelancers",
                newName: "FreelancerID");

            migrationBuilder.RenameIndex(
                name: "IX_Freelancers_AssignedClientId",
                table: "Freelancers",
                newName: "IX_Freelancers_ClientID");

            migrationBuilder.AlterColumn<string>(
                name: "JobBudget",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_Freelancers_Clients_ClientID",
                table: "Freelancers",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ClientID");
        }
    }
}
