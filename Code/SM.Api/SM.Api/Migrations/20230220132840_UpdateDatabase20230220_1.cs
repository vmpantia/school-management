using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SM.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase20230220_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Student_InternalID",
                table: "Contacts",
                newName: "RelationID");

            migrationBuilder.RenameColumn(
                name: "Student_InternalID",
                table: "Addresses",
                newName: "RelationID");

            migrationBuilder.AlterColumn<string>(
                name: "StudentID",
                table: "Students",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RelationID",
                table: "Contacts",
                newName: "Student_InternalID");

            migrationBuilder.RenameColumn(
                name: "RelationID",
                table: "Addresses",
                newName: "Student_InternalID");

            migrationBuilder.AlterColumn<string>(
                name: "StudentID",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);
        }
    }
}
