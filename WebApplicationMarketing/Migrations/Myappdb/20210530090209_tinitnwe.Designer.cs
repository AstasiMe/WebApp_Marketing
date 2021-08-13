﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplicationMarketing.Data_;

namespace WebApplicationMarketing.Migrations.Myappdb
{
    [DbContext(typeof(MyappdbContext))]
    [Migration("20210530090209_tinitnwe")]
    partial class tinitnwe
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Russian_Russia.1251")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("WebApplicationMarketing.Models_.Addlink", b =>
                {
                    b.Property<int>("IdLink")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_link")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("GaLink")
                        .HasColumnType("text")
                        .HasColumnName("ga_link");

                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("YandexLink")
                        .HasColumnType("text")
                        .HasColumnName("yandex_link");

                    b.HasKey("IdLink")
                        .HasName("addlinks_pkey");

                    b.HasIndex("Id");

                    b.ToTable("addlinks");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.AspNetRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedName" }, "RoleNameIndex")
                        .IsUnique();

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.AspNetRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetRoleClaims_RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.AspNetUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedEmail" }, "EmailIndex");

                    b.HasIndex(new[] { "NormalizedUserName" }, "UserNameIndex")
                        .IsUnique();

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.AspNetUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserClaims_UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.AspNetUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserLogins_UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.AspNetUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.AspNetUserToken", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.IncomingTraffic", b =>
                {
                    b.Property<int>("IdIt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_it")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("DataMonth")
                        .HasColumnType("date")
                        .HasColumnName("data_month");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("IncomTrafficGv")
                        .HasColumnType("integer")
                        .HasColumnName("incom_traffic_gv");

                    b.Property<int?>("IncomTrafficMop")
                        .HasColumnType("integer")
                        .HasColumnName("incom_traffic_mop");

                    b.Property<int?>("NewCardsSold")
                        .HasColumnType("integer")
                        .HasColumnName("new_cards_sold");

                    b.Property<decimal?>("OpConversion")
                        .HasColumnType("numeric")
                        .HasColumnName("op_conversion");

                    b.HasKey("IdIt")
                        .HasName("incoming_traffic_pkey");

                    b.HasIndex("Id");

                    b.ToTable("incoming_traffic");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.InsideClub", b =>
                {
                    b.Property<int>("IdIc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_ic")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CallsMopPhone")
                        .HasColumnType("integer")
                        .HasColumnName("calls_mop_phone");

                    b.Property<int?>("CallsReceptPhone")
                        .HasColumnType("integer")
                        .HasColumnName("calls_recept_phone");

                    b.Property<int?>("Calltracking")
                        .HasColumnType("integer")
                        .HasColumnName("calltracking");

                    b.Property<DateTime?>("DataMonth")
                        .HasColumnType("date")
                        .HasColumnName("data_month");

                    b.Property<int?>("GuestVisits")
                        .HasColumnType("integer")
                        .HasColumnName("guest_visits");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("OtherLeads")
                        .HasColumnType("integer")
                        .HasColumnName("other_leads");

                    b.HasKey("IdIc")
                        .HasName("inside_club_pkey");

                    b.HasIndex("Id");

                    b.ToTable("inside_club");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.KeyIndicator", b =>
                {
                    b.Property<int>("IdKi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_ki")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("AllLeadsSites")
                        .HasColumnType("integer")
                        .HasColumnName("all_leads_sites");

                    b.Property<double?>("CostLeadSites")
                        .HasColumnType("double precision")
                        .HasColumnName("cost_lead_sites");

                    b.Property<DateTime?>("DataMonth")
                        .HasColumnType("date")
                        .HasColumnName("data_month");

                    b.Property<int?>("GoalsAdvertising")
                        .HasColumnType("integer")
                        .HasColumnName("goals_advertising");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("LeadsLandingPages")
                        .HasColumnType("integer")
                        .HasColumnName("leads_landing_pages");

                    b.Property<int?>("LeadsSite")
                        .HasColumnType("integer")
                        .HasColumnName("leads_site");

                    b.Property<int?>("MailSubsShares")
                        .HasColumnType("integer")
                        .HasColumnName("mail_subs_shares");

                    b.Property<int?>("NewVisitorsLandingPages")
                        .HasColumnType("integer")
                        .HasColumnName("new_visitors_landing_pages");

                    b.Property<int?>("NewVisitorsSite")
                        .HasColumnType("integer")
                        .HasColumnName("new_visitors_site");

                    b.Property<int?>("NewWebsiteVisitors")
                        .HasColumnType("integer")
                        .HasColumnName("new_website_visitors");

                    b.Property<double?>("SpentWebsitePromotion")
                        .HasColumnType("double precision")
                        .HasColumnName("spent_website_promotion");

                    b.Property<double?>("TargetCost")
                        .HasColumnType("double precision")
                        .HasColumnName("target_cost");

                    b.HasKey("IdKi")
                        .HasName("key_indicators_pkey");

                    b.HasIndex("Id");

                    b.ToTable("key_indicators");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.OnlinePay", b =>
                {
                    b.Property<int>("IdOp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_op")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double?>("AverageCheck")
                        .HasColumnType("double precision")
                        .HasColumnName("average_check");

                    b.Property<DateTime?>("DataMonth")
                        .HasColumnType("date")
                        .HasColumnName("data_month");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("OnlineSales")
                        .HasColumnType("numeric")
                        .HasColumnName("online_sales");

                    b.Property<decimal?>("PayConversion")
                        .HasColumnType("numeric")
                        .HasColumnName("pay_conversion");

                    b.Property<int?>("PaySiteCount")
                        .HasColumnType("integer")
                        .HasColumnName("pay_site_count");

                    b.Property<double?>("PaySiteRub")
                        .HasColumnType("double precision")
                        .HasColumnName("pay_site_rub");

                    b.HasKey("IdOp")
                        .HasName("online_pay_pkey");

                    b.HasIndex("Id");

                    b.ToTable("online_pay");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.SocialMedium", b =>
                {
                    b.Property<int>("IdSm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_sm")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("DataMonth")
                        .HasColumnType("date")
                        .HasColumnName("data_month");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("LeadsVk")
                        .HasColumnType("integer")
                        .HasColumnName("leads_vk");

                    b.Property<int?>("OtherLeads")
                        .HasColumnType("integer")
                        .HasColumnName("other_leads");

                    b.HasKey("IdSm")
                        .HasName("social_media_pkey");

                    b.HasIndex("Id");

                    b.ToTable("social_media");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.UnTable", b =>
                {
                    b.Property<int>("IdUt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_ut")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double?>("AdvertisingCosts")
                        .HasColumnType("double precision")
                        .HasColumnName("advertising_costs");

                    b.Property<int?>("ApplicPhone")
                        .HasColumnType("integer")
                        .HasColumnName("applic_phone");

                    b.Property<int?>("ApplicSocial")
                        .HasColumnType("integer")
                        .HasColumnName("applic_social");

                    b.Property<DateTime?>("DataMonth")
                        .HasColumnType("date")
                        .HasColumnName("data_month");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("NewClient")
                        .HasColumnType("integer")
                        .HasColumnName("new_client");

                    b.Property<int?>("NewVisitors")
                        .HasColumnType("integer")
                        .HasColumnName("new_visitors");

                    b.Property<double?>("Sales")
                        .HasColumnType("double precision")
                        .HasColumnName("sales");

                    b.Property<int?>("SalesCount")
                        .HasColumnType("integer")
                        .HasColumnName("sales_count");

                    b.Property<int?>("SiteLeads")
                        .HasColumnType("integer")
                        .HasColumnName("site_leads");

                    b.HasKey("IdUt")
                        .HasName("un_table_pkey");

                    b.HasIndex("Id");

                    b.ToTable("un_table");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.Addlink", b =>
                {
                    b.HasOne("WebApplicationMarketing.Models_.AspNetUser", "IdNavigation")
                        .WithMany("Addlinks")
                        .HasForeignKey("Id")
                        .HasConstraintName("addlinks_Id_fkey");

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.AspNetRoleClaim", b =>
                {
                    b.HasOne("WebApplicationMarketing.Models_.AspNetRole", "Role")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.AspNetUserClaim", b =>
                {
                    b.HasOne("WebApplicationMarketing.Models_.AspNetUser", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.AspNetUserLogin", b =>
                {
                    b.HasOne("WebApplicationMarketing.Models_.AspNetUser", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.AspNetUserRole", b =>
                {
                    b.HasOne("WebApplicationMarketing.Models_.AspNetRole", "Role")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationMarketing.Models_.AspNetUser", "User")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.AspNetUserToken", b =>
                {
                    b.HasOne("WebApplicationMarketing.Models_.AspNetUser", "User")
                        .WithMany("AspNetUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.IncomingTraffic", b =>
                {
                    b.HasOne("WebApplicationMarketing.Models_.AspNetUser", "IdNavigation")
                        .WithMany("IncomingTraffics")
                        .HasForeignKey("Id")
                        .HasConstraintName("incoming_traffic_Id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.InsideClub", b =>
                {
                    b.HasOne("WebApplicationMarketing.Models_.AspNetUser", "IdNavigation")
                        .WithMany("InsideClubs")
                        .HasForeignKey("Id")
                        .HasConstraintName("inside_club_Id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.KeyIndicator", b =>
                {
                    b.HasOne("WebApplicationMarketing.Models_.AspNetUser", "IdNavigation")
                        .WithMany("KeyIndicators")
                        .HasForeignKey("Id")
                        .HasConstraintName("key_indicators_Id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.OnlinePay", b =>
                {
                    b.HasOne("WebApplicationMarketing.Models_.AspNetUser", "IdNavigation")
                        .WithMany("OnlinePays")
                        .HasForeignKey("Id")
                        .HasConstraintName("online_pay_Id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.SocialMedium", b =>
                {
                    b.HasOne("WebApplicationMarketing.Models_.AspNetUser", "IdNavigation")
                        .WithMany("SocialMedia")
                        .HasForeignKey("Id")
                        .HasConstraintName("social_media_Id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.UnTable", b =>
                {
                    b.HasOne("WebApplicationMarketing.Models_.AspNetUser", "IdNavigation")
                        .WithMany("UnTables")
                        .HasForeignKey("Id")
                        .HasConstraintName("un_table_Id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.AspNetRole", b =>
                {
                    b.Navigation("AspNetRoleClaims");

                    b.Navigation("AspNetUserRoles");
                });

            modelBuilder.Entity("WebApplicationMarketing.Models_.AspNetUser", b =>
                {
                    b.Navigation("Addlinks");

                    b.Navigation("AspNetUserClaims");

                    b.Navigation("AspNetUserLogins");

                    b.Navigation("AspNetUserRoles");

                    b.Navigation("AspNetUserTokens");

                    b.Navigation("IncomingTraffics");

                    b.Navigation("InsideClubs");

                    b.Navigation("KeyIndicators");

                    b.Navigation("OnlinePays");

                    b.Navigation("SocialMedia");

                    b.Navigation("UnTables");
                });
#pragma warning restore 612, 618
        }
    }
}
