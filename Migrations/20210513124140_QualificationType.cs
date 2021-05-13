using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleApp.Migrations
{
    public partial class QualificationType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qualification",
                table: "CandidateDetails");

            migrationBuilder.AddColumn<int>(
                name: "QualificationTypeId",
                table: "CandidateDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QualificationType",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qualifications = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualificationType", x => x.TypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateDetails_QualificationTypeId",
                table: "CandidateDetails",
                column: "QualificationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateDetails_QualificationType_QualificationTypeId",
                table: "CandidateDetails",
                column: "QualificationTypeId",
                principalTable: "QualificationType",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateDetails_QualificationType_QualificationTypeId",
                table: "CandidateDetails");

            migrationBuilder.DropTable(
                name: "QualificationType");

            migrationBuilder.DropIndex(
                name: "IX_CandidateDetails_QualificationTypeId",
                table: "CandidateDetails");

            migrationBuilder.DropColumn(
                name: "QualificationTypeId",
                table: "CandidateDetails");

            migrationBuilder.AddColumn<string>(
                name: "Qualification",
                table: "CandidateDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
