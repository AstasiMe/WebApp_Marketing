using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebApplicationMarketing.Migrations.Myappdb
{
    public partial class nw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "setting_table",
                columns: table => new
                {
                    id_st = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    incoming_traffics = table.Column<bool>(type: "boolean", nullable: true),
                    inside_clubs = table.Column<bool>(type: "boolean", nullable: true),
                    keys_indicators = table.Column<bool>(type: "boolean", nullable: true),
                    online_pays = table.Column<bool>(type: "boolean", nullable: true),
                    social_mediums = table.Column<bool>(type: "boolean", nullable: true),
                    Id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("setting_table_pkey", x => x.id_st);
                    table.ForeignKey(
                        name: "setting_table_Id_fkey",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_setting_table_Id",
                table: "setting_table",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "setting_table");
        }
    }
}
