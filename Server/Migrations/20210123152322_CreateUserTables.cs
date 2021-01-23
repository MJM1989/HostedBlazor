using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HostedBlazor.Server.Migrations
{
    public partial class CreateUserTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                "User");

            migrationBuilder.CreateTable(
                "AspNetRoles",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<string>("nvarchar(450)", nullable: false),
                    Name = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AspNetRoles", x => x.Id); });

            migrationBuilder.CreateTable(
                "AspNetUsers",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<string>("nvarchar(450)", nullable: false),
                    UserName = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>("bit", nullable: false),
                    PasswordHash = table.Column<string>("nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>("nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>("nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>("nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>("bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>("bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>("datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>("bit", nullable: false),
                    AccessFailedCount = table.Column<int>("int", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_AspNetUsers", x => x.Id); });

            migrationBuilder.CreateTable(
                "DeviceCodes",
                schema: "User",
                columns: table => new
                {
                    UserCode = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>("nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                    Expiration = table.Column<DateTime>("datetime2", nullable: false),
                    Data = table.Column<string>("nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_DeviceCodes", x => x.UserCode); });

            migrationBuilder.CreateTable(
                "PersistedGrants",
                schema: "User",
                columns: table => new
                {
                    Key = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>("nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                    Expiration = table.Column<DateTime>("datetime2", nullable: true),
                    ConsumedTime = table.Column<DateTime>("datetime2", nullable: true),
                    Data = table.Column<string>("nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_PersistedGrants", x => x.Key); });

            migrationBuilder.CreateTable(
                "AspNetRoleClaims",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>("nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>("nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        x => x.RoleId,
                        principalSchema: "User",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserClaims",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>("nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>("nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetUserClaims_AspNetUsers_UserId",
                        x => x.UserId,
                        principalSchema: "User",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserLogins",
                schema: "User",
                columns: table => new
                {
                    LoginProvider = table.Column<string>("nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>("nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>("nvarchar(max)", nullable: true),
                    UserId = table.Column<string>("nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new {x.LoginProvider, x.ProviderKey});
                    table.ForeignKey(
                        "FK_AspNetUserLogins_AspNetUsers_UserId",
                        x => x.UserId,
                        principalSchema: "User",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserRoles",
                schema: "User",
                columns: table => new
                {
                    UserId = table.Column<string>("nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>("nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new {x.UserId, x.RoleId});
                    table.ForeignKey(
                        "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        x => x.RoleId,
                        principalSchema: "User",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_AspNetUserRoles_AspNetUsers_UserId",
                        x => x.UserId,
                        principalSchema: "User",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserTokens",
                schema: "User",
                columns: table => new
                {
                    UserId = table.Column<string>("nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>("nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>("nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new {x.UserId, x.LoginProvider, x.Name});
                    table.ForeignKey(
                        "FK_AspNetUserTokens_AspNetUsers_UserId",
                        x => x.UserId,
                        principalSchema: "User",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_AspNetRoleClaims_RoleId",
                schema: "User",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                "RoleNameIndex",
                schema: "User",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserClaims_UserId",
                schema: "User",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserLogins_UserId",
                schema: "User",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserRoles_RoleId",
                schema: "User",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                "EmailIndex",
                schema: "User",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                "UserNameIndex",
                schema: "User",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_DeviceCodes_DeviceCode",
                schema: "User",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_DeviceCodes_Expiration",
                schema: "User",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                "IX_PersistedGrants_Expiration",
                schema: "User",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                "IX_PersistedGrants_SubjectId_ClientId_Type",
                schema: "User",
                table: "PersistedGrants",
                columns: new[] {"SubjectId", "ClientId", "Type"});

            migrationBuilder.CreateIndex(
                "IX_PersistedGrants_SubjectId_SessionId_Type",
                schema: "User",
                table: "PersistedGrants",
                columns: new[] {"SubjectId", "SessionId", "Type"});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "AspNetRoleClaims",
                "User");

            migrationBuilder.DropTable(
                "AspNetUserClaims",
                "User");

            migrationBuilder.DropTable(
                "AspNetUserLogins",
                "User");

            migrationBuilder.DropTable(
                "AspNetUserRoles",
                "User");

            migrationBuilder.DropTable(
                "AspNetUserTokens",
                "User");

            migrationBuilder.DropTable(
                "DeviceCodes",
                "User");

            migrationBuilder.DropTable(
                "PersistedGrants",
                "User");

            migrationBuilder.DropTable(
                "AspNetRoles",
                "User");

            migrationBuilder.DropTable(
                "AspNetUsers",
                "User");
        }
    }
}