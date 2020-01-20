namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;



    [Table("DetalleOrden")]
    public class DetalleOrden
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int iddetalleorden { get; set; }

        public int Orden_Id { get; set; }

        public int Hardware_Id { get; set; }

        [DisplayName("ORDEN DETALLE")]
        public string seriedt { get; set; }




        [DisplayName("USUARIO")]
        public string usuariof { get; set; }


        [DisplayName("TELEFONO")]
        public string telefonof { get; set; }

        [DisplayName("UBICACION")]
        public string ubicacion { get; set; }


        [DisplayName("CABLE DE SEGURIDAD")]
        public string cableseg { get; set; }

        [DisplayName("MOUSE")]
        public string mouse { get; set; }

        [DisplayName("MALETIN")]
        public string maleta { get; set; }


        [DisplayName("OTROS ACC.")]
        public string accesorio { get; set; }



        [DisplayName("VALOR")]
     
        public decimal valor { get; set; }

        [DisplayName("IGV")]

        public decimal IGV { get; set; }


        [DisplayName("TOTAL")]

        public decimal total { get; set; }




        [DisplayName("OBSERVACION")]
        public string obscambio { get; set; }


        [DisplayName("ESTADO")]
        public int estadodetalleorden { get; set; }


        [DisplayName("Fecha Registro")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yy}")]
        public string fregistro { get; set; }

        [DisplayName("GUIA REMISION")]
        public string gremision { get; set; }

        [DisplayName("GUIA RECEPCION")]
        public string grecepcion { get; set; }

        public string codigontb { get; set; }
        public string typedevice { get; set; }
        public string seriehw { get; set; }
        public string nmbrand { get; set; }
        public string nmmodel { get; set; }
        public string partnumberhw { get; set; }
        public string snbatery { get; set; }
        public string sncharger { get; set; }
        public string nmprocessor { get; set; }
        public string ghzprocessor { get; set; }
        public string mcapacity { get; set; }
        public string capacitystorage { get; set; }
        public string lic { get; set; }
        public string nmequipo { get; set; }
        public string obshw { get; set; }




        public virtual Hardware Hardware { get; set; }
        public virtual Orden Orden { get; set; }


        public ResponseModel Guardar()
        {
            var rm = new ResponseModel();
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    ctx.Entry(this).State = EntityState.Added;

                    rm.SetResponse(true);
                    ctx.SaveChanges();
                }
            }
            catch (Exception E)
            {
                throw;
            }
            return rm;
        }

        public List<DetalleOrden> Listar(int orden_id)
        {
            var detalleorden = new List<DetalleOrden>();
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    detalleorden = ctx.DetalleOrden.Include("Hardware")
                                                  .Where(x => x.Orden_Id == orden_id)
                                                  .ToList();
                }
            }
            catch (Exception E)
            {

                throw;
            }

            return detalleorden;
        }



      


    }
}
