using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nancy.Json;
using Newtonsoft.Json;
using WebApplicationMarketing.Data_;
using WebApplicationMarketing.Models_;

namespace WebApplicationMarketing
{
    public class ForecastClass
    {

        public static double[] TestSales(string name)
        {
            try
            {
                MyappdbContext db = new MyappdbContext();

                List<UnTable> tb;
                tb = (from m in db.UnTables
                      select m).ToList();

                var query = (from t in tb
                             join g in db.AspNetUsers on t.Id equals g.Id
                             where t.IdNavigation.UserName == name
                             orderby t.DataMonth descending
                             select new
                             {
                                 t.DataMonth,
                                 t.Sales
                             }).ToList();

                double[] sales = new double[15];
                DateTime[] data_ = new DateTime[12];

                for (int i = 0; i < 12; i++)
                {
                    data_[i] = Convert.ToDateTime(query[i].DataMonth);
                    sales[i] = Convert.ToDouble(query[i].Sales);
                }

                double[] arr = Calculat(sales);
                double[] arr2 = Prognoz(sales, arr);
                return arr2;
            }
            catch
            {
                double[] err = new double[3] { 0, 0, 0 };
                return err;
            }
        }

        public static double[] TestCosts(string name)
        {
            try
            {
                MyappdbContext db = new MyappdbContext();

                List<UnTable> tb;
                tb = (from m in db.UnTables
                      select m).ToList();


                var query = (from t in tb
                             join g in db.AspNetUsers on t.Id equals g.Id
                             where t.IdNavigation.UserName == name
                             orderby t.DataMonth descending
                             select new
                             {
                                 t.DataMonth,
                                 t.AdvertisingCosts
                             }).ToList();

                double[] costs = new double[15];
                DateTime[] data_ = new DateTime[12];

                for (int i = 0; i < 12; i++)
                {
                    data_[i] = Convert.ToDateTime(query[i].DataMonth);
                    costs[i] = Convert.ToDouble(query[i].AdvertisingCosts);
                }

                double[] arr = Calculat(costs);
                double[] arr2 = Prognoz(costs, arr);
                return arr2;
            }
            catch
            {
                double[] err = new double[3] { 0, 0, 0 };
                return err;
            }
        }


        public static double[] Calculat(double[] array)
        {
            double[] sr_scolz = new double[array.Length];
            for (int i = 1; i < 12; i++)
            {
                if (i + 1 < array.Length)
                {
                    sr_scolz[i] = (array[i - 1] + array[i] + array[i + 1]) / 3;
                }
            }
            return sr_scolz;
        }

        public static double[] Prognoz(double[] array, double[] arr_sr)
        {
            for (int i = 10; i < 14; i++)
            {
                if (i + 2 < array.Length)
                {
                    array[i + 2] = arr_sr[i] + ((array[i + 1] - array[i]) / 3);
                    arr_sr[i + 1] = (array[i] + array[i + 1] + array[i + 2]) / 3;
                }
            }
            return array;
        }


    }
}

