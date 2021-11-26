using Microsoft.EntityFrameworkCore.Migrations;

namespace OrientationRetake.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Mountains",
                newName: "MountName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MountName",
                table: "Mountains",
                newName: "Name");
        }
    }
}
