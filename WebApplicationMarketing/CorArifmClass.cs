using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationMarketing
{
    public class CorArifmClass
    {
        public static double CorArifm(double[] x, double[] y)
        {
            double sr_x = 0;
            double sr_y = 0;

            for (int i = 0; i < x.Length; i++) //1 этап: нахождение суммы
            {
                sr_x += x[i];
                sr_y += y[i];
            }

            sr_x = sr_x / x.Length;  //2 этап: нахождение ср знач
            sr_y = sr_y / y.Length;

            double[] otkl_x = new double[x.Length];
            double[] otkl_y = new double[y.Length];
            double sum_otkl_x = 0;
            double sum_otkl_y = 0;

            for (int i = 0; i < x.Length; i++) //3 этап: отклонение в кв
            {
                otkl_x[i] = Math.Pow(sr_x - x[i], 2);
                otkl_y[i] = Math.Pow(sr_y - y[i], 2);
                sum_otkl_x += otkl_x[i];
                sum_otkl_y += otkl_y[i];
            }

            double sum = 0;
            for (int i = 0; i < x.Length; i++) //3 этап: отклонение в кв
            {
                sum += Math.Sqrt(otkl_x[i]) * Math.Sqrt(otkl_y[i]);
            }

            double Pirson = 0;
            Pirson = sum / (Math.Sqrt(sum_otkl_x * sum_otkl_y));

            return Pirson;
        }

        public static string FindResult(double coeff)
        {
            string res_lead = "";
            if (coeff < 0)
            {
                if (Math.Abs(coeff) <= 1 && Math.Abs(coeff) > 0.7)
                {
                    res_lead = "Сильная обратная зависимость: при уменьшении одного показателя будет увеличиваться другой";
                }
                else if (Math.Abs(coeff) <= 0.7 && Math.Abs(coeff) > 0.3)
                {
                    res_lead = "Средняя обратная зависимость: при уменьшении одного показателя незначительно будет увеличиваться другой";
                }
                else if (Math.Abs(coeff) <= 0.3 && Math.Abs(coeff) >= 0)
                {
                    res_lead = "Слабая обратная зависимость: при уменьшении одного показателя практически не будет изменяться другой";
                }
                else res_lead = "Зависмоть данных полностью отсутствует";
            }
            else if (coeff > 0)
            {
                if (coeff <= 1 && coeff > 0.7)
                {
                    res_lead = "Сильная прямая зависимость: при увеличении одного показателя будет увеличиваться другой";
                }
                else if (coeff <= 0.7 && coeff > 0.3)
                {
                    res_lead = "Средняя прямая зависимость: при увеличении одного показателя незначительно будет увеличиваться другой";
                }
                else if (coeff <= 0.3 && coeff >= 0)
                {
                    res_lead = "Слабая прямая зависимость: при увелечении одного показателя практически не будет изменяться другой";
                }
                else res_lead = "Зависмоть данных полностью отсутствует";
            }
            return res_lead;
        }
    }
}
