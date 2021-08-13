﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplicationMarketing.Models_
{
    [Table("un_table")]
    public partial class UnTable
    {
        [Key]
        [Column("id_ut")]
        public int IdUt { get; set; }
        [Column("sales")]
        public double? Sales { get; set; }
        [Column("sales_count")]
        public int? SalesCount { get; set; }
        [Column("advertising_costs")]
        public double? AdvertisingCosts { get; set; }
        [Column("new_visitors")]
        public int? NewVisitors { get; set; }
        [Column("site_leads")]
        public int? SiteLeads { get; set; }
        [Column("new_client")]
        public int? NewClient { get; set; }
        [Column("applic_phone")]
        public int? ApplicPhone { get; set; }
        [Column("applic_social")]
        public int? ApplicSocial { get; set; }
        [Column("data_month", TypeName = "date")]
        public DateTime? DataMonth { get; set; }
        public string Id { get; set; }

        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(AspNetUser.UnTables))]
        public virtual AspNetUser IdNavigation { get; set; }
    }
}