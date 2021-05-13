using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleApp.Migrations
{
    public partial class addedtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EducationLevel",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLevel", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "CandidateDetails",
                columns: table => new
                {
                    CandidateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Shedule = table.Column<int>(type: "int", nullable: false),
                    Attendance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateDetails", x => x.CandidateID);
                    table.ForeignKey(
                        name: "FK_CandidateDetails_EducationLevel_TypeId",
                        column: x => x.TypeId,
                        principalTable: "EducationLevel",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateDetails_TypeId",
                table: "CandidateDetails",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateDetails");

            migrationBuilder.DropTable(
                name: "EducationLevel");
        }
    }
}
