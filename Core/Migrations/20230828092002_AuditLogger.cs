using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    public partial class AuditLogger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "ActivityLog",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Module = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        RequestedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ActivityLog", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "AuditLogger",
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
                    table.PrimaryKey("PK_AuditLogger", x => x.Id);
                });
        

        //migrationBuilder.CreateTable(
        //    name: "Auditors",
        //    columns: table => new
        //    {
        //        Id = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        Empno = table.Column<int>(type: "int", nullable: true),
        //        Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        IsActive = table.Column<bool>(type: "bit", nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_Auditors", x => x.Id);
        //    });

        //migrationBuilder.CreateTable(
        //    name: "AuditTypes",
        //    columns: table => new
        //    {
        //        AuditTypeId = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        AuditType = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        AudTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        IsActive = table.Column<bool>(type: "bit", nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_AuditTypes", x => x.AuditTypeId);
        //    });

        //migrationBuilder.CreateTable(
        //    name: "Category",
        //    columns: table => new
        //    {
        //        Id = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        IsActive = table.Column<bool>(type: "bit", nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_Category", x => x.Id);
        //    });

        //migrationBuilder.CreateTable(
        //    name: "CheckpointClasses",
        //    columns: table => new
        //    {
        //        CheckpointClassId = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        CPClassCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        IsActive = table.Column<bool>(type: "bit", nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_CheckpointClasses", x => x.CheckpointClassId);
        //    });

        //migrationBuilder.CreateTable(
        //    name: "CheckpointDeviations",
        //    columns: table => new
        //    {
        //        CheckpointDeviationId = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        Deviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        CPDevCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        IsActive = table.Column<bool>(type: "bit", nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_CheckpointDeviations", x => x.CheckpointDeviationId);
        //    });

        //migrationBuilder.CreateTable(
        //    name: "FaultGroups",
        //    columns: table => new
        //    {
        //        FaultGroupId = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        FaultGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        FGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        IsActive = table.Column<bool>(type: "bit", nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_FaultGroups", x => x.FaultGroupId);
        //    });

        //migrationBuilder.CreateTable(
        //    name: "Menu",
        //    columns: table => new
        //    {
        //        ControlId = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        Pcid = table.Column<int>(type: "int", nullable: true),
        //        ControlName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        ControlType = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        SortOrder = table.Column<int>(type: "int", nullable: true),
        //        IsAp = table.Column<bool>(type: "bit", nullable: true),
        //        IsMenu = table.Column<bool>(type: "bit", nullable: true),
        //        Route = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        Icon = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_Menu", x => x.ControlId);
        //    });

        //migrationBuilder.CreateTable(
        //    name: "Plants",
        //    columns: table => new
        //    {
        //        PlantId = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        Plant = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        IsActive = table.Column<bool>(type: "bit", nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_Plants", x => x.PlantId);
        //    });

        //migrationBuilder.CreateTable(
        //    name: "Role",
        //    columns: table => new
        //    {
        //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //        RoleId = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        IsActive = table.Column<bool>(type: "bit", nullable: false),
        //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
        //        NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
        //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_Role", x => x.Id);
        //    });

        //migrationBuilder.CreateTable(
        //    name: "ScheduleJob",
        //    columns: table => new
        //    {
        //        Id = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        JobType = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        JobName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        CronExpression = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        Enabled = table.Column<bool>(type: "bit", nullable: false),
        //        LastStart = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        LastEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        IsActive = table.Column<bool>(type: "bit", nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_ScheduleJob", x => x.Id);
        //    });

        //migrationBuilder.CreateTable(
        //    name: "Shifts",
        //    columns: table => new
        //    {
        //        ShiftId = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        Shift = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        ShiftCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        IsActive = table.Column<bool>(type: "bit", nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_Shifts", x => x.ShiftId);
        //    });

        //migrationBuilder.CreateTable(
        //    name: "Users",
        //    columns: table => new
        //    {
        //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //        UserId = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        UserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        AuthType = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        profile_pic = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        TokenExpireOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        IsActive = table.Column<bool>(type: "bit", nullable: false),
        //        IsPwdChg = table.Column<bool>(type: "bit", nullable: true),
        //        FcmToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
        //        NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
        //        Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
        //        NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
        //        EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
        //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
        //        TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
        //        LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //        LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
        //        AccessFailedCount = table.Column<int>(type: "int", nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_Users", x => x.Id);
        //    });

        //migrationBuilder.CreateTable(
        //    name: "ZoneOrStations",
        //    columns: table => new
        //    {
        //        ZoneOrStationId = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        ZoneOrStation = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        IsStation = table.Column<bool>(type: "bit", nullable: true),
        //        Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        IsActive = table.Column<bool>(type: "bit", nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_ZoneOrStations", x => x.ZoneOrStationId);
        //    });

        //migrationBuilder.CreateTable(
        //    name: "Email",
        //    columns: table => new
        //    {
        //        EmailId = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        EmailCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        FkPlantId = table.Column<int>(type: "int", nullable: true),
        //        Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        CategoryId = table.Column<int>(type: "int", nullable: true),
        //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        IsActive = table.Column<bool>(type: "bit", nullable: false),
        //        Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_Email", x => x.EmailId);
        //        table.ForeignKey(
        //            name: "FK_Email_Category_CategoryId",
        //            column: x => x.CategoryId,
        //            principalTable: "Category",
        //            principalColumn: "Id");
        //        table.ForeignKey(
        //            name: "FK_Email_Plants_FkPlantId",
        //            column: x => x.FkPlantId,
        //            principalTable: "Plants",
        //            principalColumn: "PlantId");
        //    });

        //migrationBuilder.CreateTable(
        //    name: "Products",
        //    columns: table => new
        //    {
        //        ProductId = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        Product = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        FkPlantId = table.Column<int>(type: "int", nullable: true),
        //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        IsActive = table.Column<bool>(type: "bit", nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_Products", x => x.ProductId);
        //        table.ForeignKey(
        //            name: "FK_Products_Plants_FkPlantId",
        //            column: x => x.FkPlantId,
        //            principalTable: "Plants",
        //            principalColumn: "PlantId");
        //    });

        //migrationBuilder.CreateTable(
        //    name: "AspNetRoleClaims",
        //    columns: table => new
        //    {
        //        Id = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
        //        table.ForeignKey(
        //            name: "FK_AspNetRoleClaims_Role_RoleId",
        //            column: x => x.RoleId,
        //            principalTable: "Role",
        //            principalColumn: "Id",
        //            onDelete: ReferentialAction.Cascade);
        //    });

        //migrationBuilder.CreateTable(
        //    name: "Permission",
        //    columns: table => new
        //    {
        //        Id = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        ControlId = table.Column<int>(type: "int", nullable: true),
        //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
        //        Route = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        IsActive = table.Column<bool>(type: "bit", nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_Permission", x => x.Id);
        //        table.ForeignKey(
        //            name: "FK_Permission_Menu_ControlId",
        //            column: x => x.ControlId,
        //            principalTable: "Menu",
        //            principalColumn: "ControlId");
        //        table.ForeignKey(
        //            name: "FK_Permission_Role_RoleId",
        //            column: x => x.RoleId,
        //            principalTable: "Role",
        //            principalColumn: "Id");
        //    });

        //migrationBuilder.CreateTable(
        //    name: "AspNetUserClaims",
        //    columns: table => new
        //    {
        //        Id = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
        //        table.ForeignKey(
        //            name: "FK_AspNetUserClaims_Users_UserId",
        //            column: x => x.UserId,
        //            principalTable: "Users",
        //            principalColumn: "Id",
        //            onDelete: ReferentialAction.Cascade);
        //    });

        //migrationBuilder.CreateTable(
        //    name: "AspNetUserLogins",
        //    columns: table => new
        //    {
        //        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //        ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //        ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
        //        table.ForeignKey(
        //            name: "FK_AspNetUserLogins_Users_UserId",
        //            column: x => x.UserId,
        //            principalTable: "Users",
        //            principalColumn: "Id",
        //            onDelete: ReferentialAction.Cascade);
        //    });

        //migrationBuilder.CreateTable(
        //    name: "AspNetUserRoles",
        //    columns: table => new
        //    {
        //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
        //        table.ForeignKey(
        //            name: "FK_AspNetUserRoles_Role_RoleId",
        //            column: x => x.RoleId,
        //            principalTable: "Role",
        //            principalColumn: "Id",
        //            onDelete: ReferentialAction.Cascade);
        //        table.ForeignKey(
        //            name: "FK_AspNetUserRoles_Users_UserId",
        //            column: x => x.UserId,
        //            principalTable: "Users",
        //            principalColumn: "Id",
        //            onDelete: ReferentialAction.Cascade);
        //    });

        //migrationBuilder.CreateTable(
        //    name: "AspNetUserTokens",
        //    columns: table => new
        //    {
        //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //        Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //        Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
        //        table.ForeignKey(
        //            name: "FK_AspNetUserTokens_Users_UserId",
        //            column: x => x.UserId,
        //            principalTable: "Users",
        //            principalColumn: "Id",
        //            onDelete: ReferentialAction.Cascade);
        //    });

        //migrationBuilder.CreateTable(
        //    name: "RefreshToken",
        //    columns: table => new
        //    {
        //        Id = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        JwtId = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        IsRevoked = table.Column<bool>(type: "bit", nullable: false),
        //        DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
        //        DateExpire = table.Column<DateTime>(type: "datetime2", nullable: false),
        //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_RefreshToken", x => x.Id);
        //        table.ForeignKey(
        //            name: "FK_RefreshToken_Users_UserId",
        //            column: x => x.UserId,
        //            principalTable: "Users",
        //            principalColumn: "Id");
        //    });

        //migrationBuilder.CreateTable(
        //    name: "Variants",
        //    columns: table => new
        //    {
        //        VariantId = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        Variant = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        FkProductId = table.Column<int>(type: "int", nullable: true),
        //        ProductType = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        auditTypeId = table.Column<int>(type: "int", nullable: true),
        //        VariantCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        IsActive = table.Column<bool>(type: "bit", nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_Variants", x => x.VariantId);
        //        table.ForeignKey(
        //            name: "FK_Variants_AuditTypes_auditTypeId",
        //            column: x => x.auditTypeId,
        //            principalTable: "AuditTypes",
        //            principalColumn: "AuditTypeId");
        //        table.ForeignKey(
        //            name: "FK_Variants_Products_FkProductId",
        //            column: x => x.FkProductId,
        //            principalTable: "Products",
        //            principalColumn: "ProductId");
        //    });

        //migrationBuilder.CreateTable(
        //    name: "Checkpoints",
        //    columns: table => new
        //    {
        //        CheckpointId = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        Standard = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        FkVariantId = table.Column<int>(type: "int", nullable: true),
        //        FkAuditTypeId = table.Column<int>(type: "int", nullable: true),
        //        FkZoneOrStationId = table.Column<int>(type: "int", nullable: true),
        //        FkClassId = table.Column<int>(type: "int", nullable: true),
        //        DefectWeightage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
        //        FkFaultGroupId = table.Column<int>(type: "int", nullable: true),
        //        CPCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        OrderNo = table.Column<int>(type: "int", nullable: false),
        //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        IsActive = table.Column<bool>(type: "bit", nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_Checkpoints", x => x.CheckpointId);
        //        table.ForeignKey(
        //            name: "FK_Checkpoints_AuditTypes_FkAuditTypeId",
        //            column: x => x.FkAuditTypeId,
        //            principalTable: "AuditTypes",
        //            principalColumn: "AuditTypeId");
        //        table.ForeignKey(
        //            name: "FK_Checkpoints_CheckpointClasses_FkClassId",
        //            column: x => x.FkClassId,
        //            principalTable: "CheckpointClasses",
        //            principalColumn: "CheckpointClassId");
        //        table.ForeignKey(
        //            name: "FK_Checkpoints_FaultGroups_FkFaultGroupId",
        //            column: x => x.FkFaultGroupId,
        //            principalTable: "FaultGroups",
        //            principalColumn: "FaultGroupId");
        //        table.ForeignKey(
        //            name: "FK_Checkpoints_Variants_FkVariantId",
        //            column: x => x.FkVariantId,
        //            principalTable: "Variants",
        //            principalColumn: "VariantId");
        //        table.ForeignKey(
        //            name: "FK_Checkpoints_ZoneOrStations_FkZoneOrStationId",
        //            column: x => x.FkZoneOrStationId,
        //            principalTable: "ZoneOrStations",
        //            principalColumn: "ZoneOrStationId");
        //    });

        //migrationBuilder.CreateTable(
        //    name: "Models",
        //    columns: table => new
        //    {
        //        ModelId = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        FkVariantId = table.Column<int>(type: "int", nullable: true),
        //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
        //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //        IsActive = table.Column<bool>(type: "bit", nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_Models", x => x.ModelId);
        //        table.ForeignKey(
        //            name: "FK_Models_Variants_FkVariantId",
        //            column: x => x.FkVariantId,
        //            principalTable: "Variants",
        //            principalColumn: "VariantId");
        //    });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AspNetRoleClaims_RoleId",
        //        table: "AspNetRoleClaims",
        //        column: "RoleId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AspNetUserClaims_UserId",
        //        table: "AspNetUserClaims",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AspNetUserLogins_UserId",
        //        table: "AspNetUserLogins",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AspNetUserRoles_RoleId",
        //        table: "AspNetUserRoles",
        //        column: "RoleId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Checkpoints_FkAuditTypeId",
        //        table: "Checkpoints",
        //        column: "FkAuditTypeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Checkpoints_FkClassId",
        //        table: "Checkpoints",
        //        column: "FkClassId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Checkpoints_FkFaultGroupId",
        //        table: "Checkpoints",
        //        column: "FkFaultGroupId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Checkpoints_FkVariantId",
        //        table: "Checkpoints",
        //        column: "FkVariantId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Checkpoints_FkZoneOrStationId",
        //        table: "Checkpoints",
        //        column: "FkZoneOrStationId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Email_CategoryId",
        //        table: "Email",
        //        column: "CategoryId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Email_FkPlantId",
        //        table: "Email",
        //        column: "FkPlantId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Models_FkVariantId",
        //        table: "Models",
        //        column: "FkVariantId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Permission_ControlId",
        //        table: "Permission",
        //        column: "ControlId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Permission_RoleId",
        //        table: "Permission",
        //        column: "RoleId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Products_FkPlantId",
        //        table: "Products",
        //        column: "FkPlantId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_RefreshToken_UserId",
        //        table: "RefreshToken",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "RoleNameIndex",
        //        table: "Role",
        //        column: "NormalizedName",
        //        unique: true,
        //        filter: "[NormalizedName] IS NOT NULL");

        //    migrationBuilder.CreateIndex(
        //        name: "EmailIndex",
        //        table: "Users",
        //        column: "NormalizedEmail");

        //    migrationBuilder.CreateIndex(
        //        name: "UserNameIndex",
        //        table: "Users",
        //        column: "NormalizedUserName",
        //        unique: true,
        //        filter: "[NormalizedUserName] IS NOT NULL");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Variants_auditTypeId",
        //        table: "Variants",
        //        column: "auditTypeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Variants_FkProductId",
        //        table: "Variants",
        //        column: "FkProductId");
        //}
    }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "ActivityLog");

            //migrationBuilder.DropTable(
            //    name: "AspNetRoleClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserLogins");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserRoles");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AuditLogger");

            //migrationBuilder.DropTable(
            //    name: "Auditors");

            //migrationBuilder.DropTable(
            //    name: "CheckpointDeviations");

            //migrationBuilder.DropTable(
            //    name: "Checkpoints");

            //migrationBuilder.DropTable(
            //    name: "Email");

            //migrationBuilder.DropTable(
            //    name: "Models");

            //migrationBuilder.DropTable(
            //    name: "Permission");

            //migrationBuilder.DropTable(
            //    name: "RefreshToken");

            //migrationBuilder.DropTable(
            //    name: "ScheduleJob");

            //migrationBuilder.DropTable(
            //    name: "Shifts");

            //migrationBuilder.DropTable(
            //    name: "CheckpointClasses");

            //migrationBuilder.DropTable(
            //    name: "FaultGroups");

            //migrationBuilder.DropTable(
            //    name: "ZoneOrStations");

            //migrationBuilder.DropTable(
            //    name: "Category");

            //migrationBuilder.DropTable(
            //    name: "Variants");

            //migrationBuilder.DropTable(
            //    name: "Menu");

            //migrationBuilder.DropTable(
            //    name: "Role");

            //migrationBuilder.DropTable(
            //    name: "Users");

            //migrationBuilder.DropTable(
            //    name: "AuditTypes");

            //migrationBuilder.DropTable(
            //    name: "Products");

            //migrationBuilder.DropTable(
            //    name: "Plants");
        }
    }
}
