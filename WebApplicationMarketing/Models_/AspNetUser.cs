﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplicationMarketing.Models_
{
    [Index(nameof(NormalizedEmail), Name = "EmailIndex")]
    [Index(nameof(NormalizedUserName), Name = "UserNameIndex", IsUnique = true)]
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            Addlinks = new HashSet<Addlink>();
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserRoles = new HashSet<AspNetUserRole>();
            AspNetUserTokens = new HashSet<AspNetUserToken>();
            IncomingTraffics = new HashSet<IncomingTraffic>();
            InsideClubs = new HashSet<InsideClub>();
            KeyIndicators = new HashSet<KeyIndicator>();
            OnlinePays = new HashSet<OnlinePay>();
            SettingTables = new HashSet<SettingTable>();
            SocialMedia = new HashSet<SocialMedium>();
            UnTables = new HashSet<UnTable>();
        }

        [Key]
        public string Id { get; set; }
        [StringLength(256)]
        public string UserName { get; set; }
        [StringLength(256)]
        public string NormalizedUserName { get; set; }
        [StringLength(256)]
        public string Email { get; set; }
        [StringLength(256)]
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        [Column(TypeName = "timestamp with time zone")]
        public DateTime? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        [InverseProperty(nameof(Addlink.IdNavigation))]
        public virtual ICollection<Addlink> Addlinks { get; set; }
        [InverseProperty(nameof(AspNetUserClaim.User))]
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        [InverseProperty(nameof(AspNetUserLogin.User))]
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        [InverseProperty(nameof(AspNetUserRole.User))]
        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
        [InverseProperty(nameof(AspNetUserToken.User))]
        public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }
        [InverseProperty(nameof(IncomingTraffic.IdNavigation))]
        public virtual ICollection<IncomingTraffic> IncomingTraffics { get; set; }
        [InverseProperty(nameof(InsideClub.IdNavigation))]
        public virtual ICollection<InsideClub> InsideClubs { get; set; }
        [InverseProperty(nameof(KeyIndicator.IdNavigation))]
        public virtual ICollection<KeyIndicator> KeyIndicators { get; set; }
        [InverseProperty(nameof(OnlinePay.IdNavigation))]
        public virtual ICollection<OnlinePay> OnlinePays { get; set; }
        [InverseProperty(nameof(SettingTable.IdNavigation))]
        public virtual ICollection<SettingTable> SettingTables { get; set; }
        [InverseProperty(nameof(SocialMedium.IdNavigation))]
        public virtual ICollection<SocialMedium> SocialMedia { get; set; }
        [InverseProperty(nameof(UnTable.IdNavigation))]
        public virtual ICollection<UnTable> UnTables { get; set; }
    }
}