using Microsoft.EntityFrameworkCore.Migrations;

namespace PENCOMSERVICE.Migrations
{
    public partial class AddedSubmitCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubmitCode",
                table: "ECRDataModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmitCode",
                table: "ECRDataModel");
        }
    }
}
