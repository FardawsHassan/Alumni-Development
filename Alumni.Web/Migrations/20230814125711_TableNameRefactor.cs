using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alumni.Web.Migrations
{
    public partial class TableNameRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Unemployeed",
                table: "Profiles",
                newName: "isUnemployeed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isUnemployeed",
                table: "Profiles",
                newName: "Unemployeed");
        }
    }
}
