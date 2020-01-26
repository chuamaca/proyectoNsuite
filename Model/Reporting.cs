

namespace Model
{


    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    public class Reporting
    {



        public int hardwareprod { get; set; }
        public int hardwareclose { get; set; }
        public int hardwarecambio { get; set; }
        public int warehousehw { get; set; }

        public virtual List<Reporting> GetRPT_Hardware_produccion()
        {
            var ctx = new ProyectoContext();
        //    SqlParameter param1 = new SqlParameter("@idhardware", idhardware);
            return ctx.Database.SqlQuery<Reporting>("RPT_Hardware_produccion").ToList();
        }




    }
}
