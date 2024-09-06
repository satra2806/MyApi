using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace MyApi.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "locationTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FacType = table.Column<string>(type: "longtext", nullable: false),
                    LocID = table.Column<string>(type: "longtext", nullable: false),
                    ServiceArea = table.Column<string>(type: "longtext", nullable: false),
                    Region = table.Column<string>(type: "longtext", nullable: false),
                    City = table.Column<string>(type: "longtext", nullable: false),
                    State = table.Column<string>(type: "longtext", nullable: false),
                    CCC = table.Column<string>(type: "longtext", nullable: false),
                    SSC = table.Column<string>(type: "longtext", nullable: false),
                    SDPFacType = table.Column<string>(type: "longtext", nullable: false),
                    SDPLocID = table.Column<string>(type: "longtext", nullable: false),
                    Airport = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locationTbl", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "locationTbl");
        }
    }
}
