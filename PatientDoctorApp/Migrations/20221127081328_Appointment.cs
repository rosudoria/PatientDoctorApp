using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientDoctorApp.Migrations
{
    public partial class Appointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AppointmentType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");
        }
    }
}
