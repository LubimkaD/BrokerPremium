using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrokerPremium.Infrastructure.Data.Migrations
{
    public partial class DBTablesCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClaimStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Identificator = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsCompany = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateValidFrom = table.Column<DateTime>(type: "date", nullable: false),
                    DateValidTo = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insurers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfInsurances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfInsurances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsurancePolicies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicyNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TypeOfInsuranceId = table.Column<int>(type: "int", nullable: false),
                    DateValidFrom = table.Column<DateTime>(type: "date", nullable: false),
                    DateValidTo = table.Column<DateTime>(type: "date", nullable: true),
                    InsSuma = table.Column<decimal>(type: "decimal", nullable: false),
                    InsCommission = table.Column<decimal>(type: "decimal", nullable: false),
                    InsurerId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePolicies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsurancePolicies_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsurancePolicies_Insurers_InsurerId",
                        column: x => x.InsurerId,
                        principalTable: "Insurers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsurancePolicies_TypeOfInsurances_TypeOfInsuranceId",
                        column: x => x.TypeOfInsuranceId,
                        principalTable: "TypeOfInsurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PolicyNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateOfAccident = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    ClaimSum = table.Column<decimal>(type: "decimal", nullable: false),
                    ImageOfClaim = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClaimCommission = table.Column<decimal>(type: "decimal", nullable: false),
                    InsurancePolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceClaims_ClaimStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ClaimStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsuranceClaims_InsurancePolicies_InsurancePolicyId",
                        column: x => x.InsurancePolicyId,
                        principalTable: "InsurancePolicies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InsuredObjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeOfObjectId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InsuranceClaimId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InsurancePolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuredObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuredObjects_InsuranceClaims_InsuranceClaimId",
                        column: x => x.InsuranceClaimId,
                        principalTable: "InsuranceClaims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InsuredObjects_InsurancePolicies_InsurancePolicyId",
                        column: x => x.InsurancePolicyId,
                        principalTable: "InsurancePolicies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InsuredObjects_TypeOfObjects_TypeOfObjectId",
                        column: x => x.TypeOfObjectId,
                        principalTable: "TypeOfObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceClaims_InsurancePolicyId",
                table: "InsuranceClaims",
                column: "InsurancePolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceClaims_StatusId",
                table: "InsuranceClaims",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePolicies_CustomerId",
                table: "InsurancePolicies",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePolicies_InsurerId",
                table: "InsurancePolicies",
                column: "InsurerId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePolicies_TypeOfInsuranceId",
                table: "InsurancePolicies",
                column: "TypeOfInsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuredObjects_InsuranceClaimId",
                table: "InsuredObjects",
                column: "InsuranceClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuredObjects_InsurancePolicyId",
                table: "InsuredObjects",
                column: "InsurancePolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuredObjects_TypeOfObjectId",
                table: "InsuredObjects",
                column: "TypeOfObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuredObjects");

            migrationBuilder.DropTable(
                name: "InsuranceClaims");

            migrationBuilder.DropTable(
                name: "TypeOfObjects");

            migrationBuilder.DropTable(
                name: "ClaimStatuses");

            migrationBuilder.DropTable(
                name: "InsurancePolicies");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Insurers");

            migrationBuilder.DropTable(
                name: "TypeOfInsurances");
        }
    }
}
