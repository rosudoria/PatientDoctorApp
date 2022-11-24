using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientDoctorApp.Migrations
{
    public partial class AddDocumentsTestReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Presciptions",
                table: "Document",
                newName: "Prescriptions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prescriptions",
                table: "Document",
                newName: "Presciptions");
        }
    }
}
