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
    public class CorrelationClass
    {

        public static string Corr(string name, int j)
        {

            MyappdbContext db = new MyappdbContext();

            List<UnTable> tb;
            tb = (from m in db.UnTables
                  select m).ToList();

            var query = (from t in tb
                         join g in db.AspNetUsers on t.Id equals g.Id
                         where t.IdNavigation.UserName == name
                         select new
                         {
                             t.AdvertisingCosts,
                             t.SiteLeads,
                             t.Sales,
                             t.NewClient
                         }).ToList();

            double[] costs = new double[query.Count];
            double[] leads = new double[query.Count];
            double[] sales = new double[query.Count];
            double[] new_client = new double[query.Count];

            for (int i = 0; i < query.Count(); i++)
            {
                new_client[i] = Convert.ToDouble(query[i].NewClient);
                sales[i] = Convert.ToDouble(query[i].Sales);
                costs[i] = Convert.ToDouble(query[i].AdvertisingCosts);
                leads[i] = Convert.ToDouble(query[i].SiteLeads);
            }

            double pirson_result_leads = CorArifmClass.CorArifm(costs, leads);
            double pirson_result_sales = CorArifmClass.CorArifm(costs, sales);
            double pirson_result_new_client = CorArifmClass.CorArifm(leads, new_client);
            string res_lead = "";
            string res_sales = "";
            string res_new_client = "";

            res_lead = CorArifmClass.FindResult(pirson_result_leads);
            res_sales = CorArifmClass.FindResult(pirson_result_sales);
            res_new_client = CorArifmClass.FindResult(pirson_result_new_client);

            string result = "";
            switch (j)
            {
                case 1:
                    result = res_lead;
                    break;
                case 2:
                    result = res_sales;
                    break;
                case 3:
                    result = res_new_client;
                    break;
                default:
                    result = "error";
                    break;
            }
            return result;
        }
    }
}
