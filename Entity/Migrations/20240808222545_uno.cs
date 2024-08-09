using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class uno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Continents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createat = table.Column<DateTime>(name: "create_at", type: "datetime2", nullable: true),
                    updateat = table.Column<DateTime>(name: "update_at", type: "datetime2", nullable: true),
                    deleteat = table.Column<DateTime>(name: "delete_at", type: "datetime2", nullable: true),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: true),
                    createdby = table.Column<DateTime>(name: "created_by", type: "datetime2", nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true),
                    updatedby = table.Column<DateTime>(name: "updated_by", type: "datetime2", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: true),
                    deletedby = table.Column<DateTime>(name: "deleted_by", type: "datetime2", nullable: true),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: true),
                    createdby = table.Column<DateTime>(name: "created_by", type: "datetime2", nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true),
                    updatedby = table.Column<DateTime>(name: "updated_by", type: "datetime2", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: true),
                    deletedby = table.Column<DateTime>(name: "deleted_by", type: "datetime2", nullable: true),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countrys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    continentId = table.Column<int>(type: "int", nullable: false),
                    createat = table.Column<DateTime>(name: "create_at", type: "datetime2", nullable: true),
                    updateat = table.Column<DateTime>(name: "update_at", type: "datetime2", nullable: true),
                    deleteat = table.Column<DateTime>(name: "delete_at", type: "datetime2", nullable: true),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countrys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countrys_Continents_continentId",
                        column: x => x.continentId,
                        principalTable: "Continents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Views",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    route = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    moduleId = table.Column<int>(type: "int", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false),
                    createdby = table.Column<DateTime>(name: "created_by", type: "datetime2", nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true),
                    updatedby = table.Column<DateTime>(name: "updated_by", type: "datetime2", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: true),
                    deletedby = table.Column<DateTime>(name: "deleted_by", type: "datetime2", nullable: true),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Views", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Views_Modules_moduleId",
                        column: x => x.moduleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Citys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    countryId = table.Column<int>(type: "int", nullable: false),
                    createat = table.Column<DateTime>(name: "create_at", type: "datetime2", nullable: true),
                    updateat = table.Column<DateTime>(name: "update_at", type: "datetime2", nullable: true),
                    deleteat = table.Column<DateTime>(name: "delete_at", type: "datetime2", nullable: true),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citys_Countrys_countryId",
                        column: x => x.countryId,
                        principalTable: "Countrys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleView",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ViewId = table.Column<int>(type: "int", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false),
                    createdby = table.Column<DateTime>(name: "created_by", type: "datetime2", nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true),
                    updatedby = table.Column<DateTime>(name: "updated_by", type: "datetime2", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: true),
                    deletedby = table.Column<DateTime>(name: "deleted_by", type: "datetime2", nullable: true),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleView_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleView_Views_ViewId",
                        column: x => x.ViewId,
                        principalTable: "Views",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(name: "first_name", type: "nvarchar(max)", nullable: true),
                    lastname = table.Column<string>(name: "last_name", type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    document = table.Column<long>(type: "bigint", nullable: true),
                    typedocument = table.Column<string>(name: "type_document", type: "nvarchar(max)", nullable: true),
                    direction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cityId = table.Column<int>(type: "int", nullable: false),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: true),
                    createdby = table.Column<DateTime>(name: "created_by", type: "datetime2", nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true),
                    updatedby = table.Column<DateTime>(name: "updated_by", type: "datetime2", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: true),
                    deletedby = table.Column<DateTime>(name: "deleted_by", type: "datetime2", nullable: true),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Citys_cityId",
                        column: x => x.cityId,
                        principalTable: "Citys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passsword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false),
                    createdby = table.Column<DateTime>(name: "created_by", type: "datetime2", nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true),
                    updatedby = table.Column<DateTime>(name: "updated_by", type: "datetime2", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: true),
                    deletedby = table.Column<DateTime>(name: "deleted_by", type: "datetime2", nullable: true),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Userroles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime2", nullable: false),
                    createdby = table.Column<DateTime>(name: "created_by", type: "datetime2", nullable: true),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime2", nullable: true),
                    updatedby = table.Column<DateTime>(name: "updated_by", type: "datetime2", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "datetime2", nullable: true),
                    deletedby = table.Column<DateTime>(name: "deleted_by", type: "datetime2", nullable: true),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userroles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Userroles_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Userroles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citys_countryId",
                table: "Citys",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX_Countrys_continentId",
                table: "Countrys",
                column: "continentId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_cityId",
                table: "Person",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleView_RoleId",
                table: "RoleView",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleView_ViewId",
                table: "RoleView",
                column: "ViewId");

            migrationBuilder.CreateIndex(
                name: "IX_Userroles_RoleId",
                table: "Userroles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Userroles_UserId",
                table: "Userroles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Views_moduleId",
                table: "Views",
                column: "moduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleView");

            migrationBuilder.DropTable(
                name: "Userroles");

            migrationBuilder.DropTable(
                name: "Views");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Citys");

            migrationBuilder.DropTable(
                name: "Countrys");

            migrationBuilder.DropTable(
                name: "Continents");
        }
    }
}
