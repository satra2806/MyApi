using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace MyApi.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectCoordinatorTbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectPlanningTbl",
                table: "ProjectPlanningTbl");

            migrationBuilder.RenameTable(
                name: "ProjectPlanningTbl",
                newName: "projectPlanningtbl");

            migrationBuilder.RenameColumn(
                name: "SDPFacType",
                table: "locationTbl",
                newName: "SdpFacType");

            migrationBuilder.RenameColumn(
                name: "SSC",
                table: "locationTbl",
                newName: "TechOpsDistrictOffice");

            migrationBuilder.RenameColumn(
                name: "SDPLocID",
                table: "locationTbl",
                newName: "SystemSupportCenter");

            migrationBuilder.RenameColumn(
                name: "LocID",
                table: "locationTbl",
                newName: "SdpFacilityLocation");

            migrationBuilder.RenameColumn(
                name: "CCC",
                table: "locationTbl",
                newName: "LookupFacilityLocId");

            migrationBuilder.RenameColumn(
                name: "Airport",
                table: "locationTbl",
                newName: "FacilityLocation");

            migrationBuilder.AddColumn<string>(
                name: "dropDownNumber",
                table: "projectPlanningtbl",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "AirportCode",
                table: "locationTbl",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City1",
                table: "locationTbl",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "CostCenterCode",
                table: "locationTbl",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "DistrictOfficeGroup",
                table: "locationTbl",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Runway",
                table: "locationTbl",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tier",
                table: "locationTbl",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_projectPlanningtbl",
                table: "projectPlanningtbl",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProjectCordinatortbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DropdownValues = table.Column<string>(type: "longtext", nullable: false),
                    DropDownLabel = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCordinatortbl", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectCordinatortbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_projectPlanningtbl",
                table: "projectPlanningtbl");

            migrationBuilder.DropColumn(
                name: "dropDownNumber",
                table: "projectPlanningtbl");

            migrationBuilder.DropColumn(
                name: "AirportCode",
                table: "locationTbl");

            migrationBuilder.DropColumn(
                name: "City1",
                table: "locationTbl");

            migrationBuilder.DropColumn(
                name: "CostCenterCode",
                table: "locationTbl");

            migrationBuilder.DropColumn(
                name: "DistrictOfficeGroup",
                table: "locationTbl");

            migrationBuilder.DropColumn(
                name: "Runway",
                table: "locationTbl");

            migrationBuilder.DropColumn(
                name: "Tier",
                table: "locationTbl");

            migrationBuilder.RenameTable(
                name: "projectPlanningtbl",
                newName: "ProjectPlanningTbl");

            migrationBuilder.RenameColumn(
                name: "SdpFacType",
                table: "locationTbl",
                newName: "SDPFacType");

            migrationBuilder.RenameColumn(
                name: "TechOpsDistrictOffice",
                table: "locationTbl",
                newName: "SSC");

            migrationBuilder.RenameColumn(
                name: "SystemSupportCenter",
                table: "locationTbl",
                newName: "SDPLocID");

            migrationBuilder.RenameColumn(
                name: "SdpFacilityLocation",
                table: "locationTbl",
                newName: "LocID");

            migrationBuilder.RenameColumn(
                name: "LookupFacilityLocId",
                table: "locationTbl",
                newName: "CCC");

            migrationBuilder.RenameColumn(
                name: "FacilityLocation",
                table: "locationTbl",
                newName: "Airport");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectPlanningTbl",
                table: "ProjectPlanningTbl",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProjectCoordinatorTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DropDownLabel = table.Column<string>(type: "longtext", nullable: false),
                    DropdownValues = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCoordinatorTbl", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }
    }
}
