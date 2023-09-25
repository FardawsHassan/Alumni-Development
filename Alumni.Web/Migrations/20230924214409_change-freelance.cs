using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alumni.Web.Migrations
{
    public partial class changefreelance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Profiles",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true,
                oldDefaultValue: "Male");

            migrationBuilder.AddColumn<bool>(
                name: "IsFreelancing",
                table: "Freelance",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFreelancing",
                table: "Freelance");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Profiles",
                type: "nvarchar(20)",
                nullable: true,
                defaultValue: "Male",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);
        }
    }
}
