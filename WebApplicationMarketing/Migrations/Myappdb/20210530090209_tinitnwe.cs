using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebApplicationMarketing.Migrations.Myappdb
{
    public partial class tinitnwe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "universal_table");

            migrationBuilder.CreateTable(
                name: "incoming_traffic",
                columns: table => new
                {
                    id_it = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    incom_traffic_gv = table.Column<int>(type: "integer", nullable: true),
                    incom_traffic_mop = table.Column<int>(type: "integer", nullable: true),
                    new_cards_sold = table.Column<int>(type: "integer", nullable: true),
                    op_conversion = table.Column<decimal>(type: "numeric", nullable: true),
                    data_month = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("incoming_traffic_pkey", x => x.id_it);
                    table.ForeignKey(
                        name: "incoming_traffic_Id_fkey",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inside_club",
                columns: table => new
                {
                    id_ic = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    guest_visits = table.Column<int>(type: "integer", nullable: true),
                    calls_mop_phone = table.Column<int>(type: "integer", nullable: true),
                    calls_recept_phone = table.Column<int>(type: "integer", nullable: true),
                    calltracking = table.Column<int>(type: "integer", nullable: true),
                    other_leads = table.Column<int>(type: "integer", nullable: true),
                    data_month = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("inside_club_pkey", x => x.id_ic);
                    table.ForeignKey(
                        name: "inside_club_Id_fkey",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "key_indicators",
                columns: table => new
                {
                    id_ki = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    leads_site = table.Column<int>(type: "integer", nullable: true),
                    new_visitors_site = table.Column<int>(type: "integer", nullable: true),
                    leads_landing_pages = table.Column<int>(type: "integer", nullable: true),
                    new_visitors_landing_pages = table.Column<int>(type: "integer", nullable: true),
                    all_leads_sites = table.Column<int>(type: "integer", nullable: true),
                    goals_advertising = table.Column<int>(type: "integer", nullable: true),
                    spent_website_promotion = table.Column<double>(type: "double precision", nullable: true),
                    cost_lead_sites = table.Column<double>(type: "double precision", nullable: true),
                    target_cost = table.Column<double>(type: "double precision", nullable: true),
                    new_website_visitors = table.Column<int>(type: "integer", nullable: true),
                    mail_subs_shares = table.Column<int>(type: "integer", nullable: true),
                    data_month = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("key_indicators_pkey", x => x.id_ki);
                    table.ForeignKey(
                        name: "key_indicators_Id_fkey",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "online_pay",
                columns: table => new
                {
                    id_op = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pay_site_rub = table.Column<double>(type: "double precision", nullable: true),
                    pay_site_count = table.Column<int>(type: "integer", nullable: true),
                    online_sales = table.Column<decimal>(type: "numeric", nullable: true),
                    average_check = table.Column<double>(type: "double precision", nullable: true),
                    pay_conversion = table.Column<decimal>(type: "numeric", nullable: true),
                    data_month = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("online_pay_pkey", x => x.id_op);
                    table.ForeignKey(
                        name: "online_pay_Id_fkey",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "social_media",
                columns: table => new
                {
                    id_sm = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    leads_vk = table.Column<int>(type: "integer", nullable: true),
                    other_leads = table.Column<int>(type: "integer", nullable: true),
                    data_month = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("social_media_pkey", x => x.id_sm);
                    table.ForeignKey(
                        name: "social_media_Id_fkey",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "un_table",
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
                    data_month = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("un_table_pkey", x => x.id_ut);
                    table.ForeignKey(
                        name: "un_table_Id_fkey",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_incoming_traffic_Id",
                table: "incoming_traffic",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_inside_club_Id",
                table: "inside_club",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_key_indicators_Id",
                table: "key_indicators",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_online_pay_Id",
                table: "online_pay",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_social_media_Id",
                table: "social_media",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_un_table_Id",
                table: "un_table",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "incoming_traffic");

            migrationBuilder.DropTable(
                name: "inside_club");

            migrationBuilder.DropTable(
                name: "key_indicators");

            migrationBuilder.DropTable(
                name: "online_pay");

            migrationBuilder.DropTable(
                name: "social_media");

            migrationBuilder.DropTable(
                name: "un_table");

            migrationBuilder.CreateTable(
                name: "universal_table",
                columns: table => new
                {
                    id_ut = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    advertising_costs = table.Column<double>(type: "double precision", nullable: true),
                    applic_phone = table.Column<int>(type: "integer", nullable: true),
                    applic_social = table.Column<int>(type: "integer", nullable: true),
                    Id = table.Column<string>(type: "text", nullable: false),
                    new_client = table.Column<int>(type: "integer", nullable: true),
                    new_visitors = table.Column<int>(type: "integer", nullable: true),
                    sales = table.Column<double>(type: "double precision", nullable: true),
                    sales_count = table.Column<int>(type: "integer", nullable: true),
                    site_leads = table.Column<int>(type: "integer", nullable: true)
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
    }
}
