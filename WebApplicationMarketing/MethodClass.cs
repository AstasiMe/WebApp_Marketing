using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebApplicationMarketing.Data_;
using WebApplicationMarketing.Models_;
using Newtonsoft.Json;
using Nancy.Json;


namespace WebApplicationMarketing
{
    public class MethodClass
    {
        public static bool GetElement(string? name, int i)
        {
            MyappdbContext db = new MyappdbContext();

            List<SettingTable> tb;
            tb = (from m in db.SettingTables
                  select m).ToList();


            var query = (from t in tb
                         join g in db.AspNetUsers on t.Id equals g.Id
                         where t.IdNavigation.UserName == name
                         select new
                         {
                             t.IncomingTraffics,
                             t.InsideClubs,
                             t.KeysIndicators,
                             t.OnlinePays,
                             t.SocialMediums,
                         }).ToList();

            bool result;

            switch (i)
            {
                case 1:
                    result = Convert.ToBoolean(query[0].IncomingTraffics);
                    break;
                case 2:
                    result = Convert.ToBoolean(query[0].InsideClubs);
                    break;
                case 3:
                    result = Convert.ToBoolean(query[0].KeysIndicators);
                    break;
                case 4:
                    result = Convert.ToBoolean(query[0].OnlinePays);
                    break;
                case 5:
                    result = Convert.ToBoolean(query[0].SocialMediums);
                    break;
                default:
                    result = false;
                    break;
            }

            return result;
        }

        public static int GetId(string? name)
        {
            MyappdbContext db = new MyappdbContext();

            List<SettingTable> tb;
            tb = (from m in db.SettingTables
                  select m).ToList();


            var query = (from t in tb
                         join g in db.AspNetUsers on t.Id equals g.Id
                         where t.IdNavigation.UserName == name
                         select new
                         {
                             t.IdSt
                         }).ToList();


            return query.Count();
        }



    }
}
