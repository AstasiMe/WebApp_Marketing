using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebApplicationMarketing.Migrations.Myappdb
{
    public partial class new_init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "universal_table",
                columns: table => new
                {
                    id_ut = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sales = table.Column<double>(type: "double precision", nullable: true),
                    sales_count = table.Column<int>(type: "integer", nullable: true),
                    advertising_costs = table.Column<double>(type: "double precision", nullable: true),
                    new_visitors = table.Column<int>(type: "integer", nullable: true),
                    site_leads = table.Column<int>(type: "integer", nullable: true),
                    new_client = table.Column<int>(type: "integer", nullable: true),
                    applic_phone = table.Column<int>(type: "integer", nullable: true),
                    applic_social = table.Column<int>(type: "integer", nullable: true),
                    Id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("universal_table_pkey", x => x.id_ut);
                    table.ForeignKey(
                        name: "universal_table_Id_fkey",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_universal_table_Id",
                table: "universal_table",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "universal_table");
        }
    }
}
