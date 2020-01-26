

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

        public int sinatencion { get; set; }

        public virtual List<Reporting> GetRPT_Hardware_produccion()
        {
            var ctx = new ProyectoContext();
        //    SqlParameter param1 = new SqlParameter("@idhardware", idhardware);
            return ctx.Database.SqlQuery<Reporting>("RPT_Hardware_produccion").ToList();
        }



        public int hardwareprodempresa { get; set; }
        public int hardwarecloseempresa { get; set; }
        public int hardwarecambioempresa { get; set; }
     
        public int sinatencionempresa { get; set; }


        //VISTA PARA CLIENTES DE PROCESOS Y EQUIPOS ACTIVOS

        public virtual List<Reporting> GetRPT_Hardware_produccion_for_empresa(string empresa)
        {
            var ctx = new ProyectoContext();
            SqlParameter param1 = new SqlParameter("@empresa", empresa);
            return ctx.Database.SqlQuery<Reporting>("RPT_Hardware_produccion_for_empresa @empresa", param1).ToList();
        }




    }
}
