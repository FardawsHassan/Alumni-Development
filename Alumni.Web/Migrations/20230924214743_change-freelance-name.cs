using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alumni.Web.Migrations
{
    public partial class changefreelancename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsFreelancing",
                table: "Freelance",
                newName: "IsActive");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Freelance",
                newName: "IsFreelancing");
        }
    }
}
