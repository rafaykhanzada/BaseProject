using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    public partial class AuditLoggerFixedFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "AuditorLoggers",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  LogType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  InFunction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  OnTask = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  ObjectData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                  UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_AuditorLoggers", x => x.Id);
              });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "AuditorLoggers");
        }
    }
}
