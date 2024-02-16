using Microsoft.EntityFrameworkCore.Migrations;

namespace ZefixTest.Migrations
{
    public partial class changeLastmodificationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SogcDate",
                table: "Companies",
                newName: "LastModification");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModification",
                table: "Companies",
                newName: "SogcDate");
        }
    }
}
