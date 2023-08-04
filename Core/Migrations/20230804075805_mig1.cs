using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAuditor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAuditor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblAuditType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AudTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AudTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAuditType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCPClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPClassCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCPClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCPDeviation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPDevCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPDevName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCPDeviation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblFaultGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFaultGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblPlant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPlant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblShift",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShiftName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblShift", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblZone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZoneName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsStation = table.Column<bool>(type: "bit", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblZone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblEmail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategId = table.Column<int>(type: "int", nullable: true),
                    CategName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantId = table.Column<int>(type: "int", nullable: true),
                    PlantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmail_tblCategory_CategId",
                        column: x => x.CategId,
                        principalTable: "tblCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblEmail_tblPlant_PlantId",
                        column: x => x.PlantId,
                        principalTable: "tblPlant",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantId = table.Column<int>(type: "int", nullable: true),
                    PlantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProduct_tblPlant_PlantId",
                        column: x => x.PlantId,
                        principalTable: "tblPlant",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblVariant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VariantCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VariantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AudTypeId = table.Column<int>(type: "int", nullable: true),
                    AudTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblVariant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblVariant_tblAuditType_AudTypeId",
                        column: x => x.AudTypeId,
                        principalTable: "tblAuditType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblVariant_tblProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "tblProduct",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblCheckpoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPOrderNo = table.Column<int>(type: "int", nullable: false),
                    Standard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AudTypeId = table.Column<int>(type: "int", nullable: true),
                    AudTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VariantId = table.Column<int>(type: "int", nullable: true),
                    VariantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZoneId = table.Column<int>(type: "int", nullable: true),
                    ZoneName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FGroupId = table.Column<int>(type: "int", nullable: true),
                    FGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPClassId = table.Column<int>(type: "int", nullable: true),
                    CPClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DWeightage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCheckpoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblCheckpoints_tblAuditType_AudTypeId",
                        column: x => x.AudTypeId,
                        principalTable: "tblAuditType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblCheckpoints_tblCPClass_CPClassId",
                        column: x => x.CPClassId,
                        principalTable: "tblCPClass",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblCheckpoints_tblFaultGroup_FGroupId",
                        column: x => x.FGroupId,
                        principalTable: "tblFaultGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblCheckpoints_tblVariant_VariantId",
                        column: x => x.VariantId,
                        principalTable: "tblVariant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblCheckpoints_tblZone_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "tblZone",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VariantId = table.Column<int>(type: "int", nullable: true),
                    VariantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblModel_tblVariant_VariantId",
                        column: x => x.VariantId,
                        principalTable: "tblVariant",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCheckpoints_AudTypeId",
                table: "tblCheckpoints",
                column: "AudTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCheckpoints_CPClassId",
                table: "tblCheckpoints",
                column: "CPClassId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCheckpoints_FGroupId",
                table: "tblCheckpoints",
                column: "FGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCheckpoints_VariantId",
                table: "tblCheckpoints",
                column: "VariantId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCheckpoints_ZoneId",
                table: "tblCheckpoints",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmail_CategId",
                table: "tblEmail",
                column: "CategId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmail_PlantId",
                table: "tblEmail",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_tblModel_VariantId",
                table: "tblModel",
                column: "VariantId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_PlantId",
                table: "tblProduct",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_tblVariant_AudTypeId",
                table: "tblVariant",
                column: "AudTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblVariant_ProductId",
                table: "tblVariant",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAuditor");

            migrationBuilder.DropTable(
                name: "tblCheckpoints");

            migrationBuilder.DropTable(
                name: "tblCPDeviation");

            migrationBuilder.DropTable(
                name: "tblEmail");

            migrationBuilder.DropTable(
                name: "tblModel");

            migrationBuilder.DropTable(
                name: "tblShift");

            migrationBuilder.DropTable(
                name: "tblCPClass");

            migrationBuilder.DropTable(
                name: "tblFaultGroup");

            migrationBuilder.DropTable(
                name: "tblZone");

            migrationBuilder.DropTable(
                name: "tblVariant");

            migrationBuilder.DropTable(
                name: "tblAuditType");

            migrationBuilder.DropTable(
                name: "tblProduct");

            migrationBuilder.DropTable(
                name: "tblPlant");
        }
    }
}
