using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SM.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase20230221_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TeacherID",
                table: "Teachers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Address_TRN",
                columns: table => new
                {
                    RequestID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Line1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Line2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Barangay = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address_TRN", x => new { x.RequestID, x.Number, x.InternalID });
                });

            migrationBuilder.CreateTable(
                name: "Contact_TRN",
                columns: table => new
                {
                    RequestID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact_TRN", x => new { x.RequestID, x.Number, x.InternalID });
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FunctionID = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestID);
                });

            migrationBuilder.CreateTable(
                name: "Student_TRN",
                columns: table => new
                {
                    RequestID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_TRN", x => new { x.RequestID, x.Number, x.InternalID });
                });

            migrationBuilder.CreateTable(
                name: "Teacher_TRN",
                columns: table => new
                {
                    RequestID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    InternalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeacherID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher_TRN", x => new { x.RequestID, x.Number, x.InternalID });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address_TRN");

            migrationBuilder.DropTable(
                name: "Contact_TRN");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Student_TRN");

            migrationBuilder.DropTable(
                name: "Teacher_TRN");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherID",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);
        }
    }
}
