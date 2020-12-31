using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Curso_Ectotec_Back.Models.Entities
{
    public class Respuesta
    {
        public class RespuestaModel
        {
            public RespuestaModel()
            {
                this.Informacion = new Informacion();
            }

            public HttpStatusCode Estatus { get; set; }
            public Informacion Informacion { get; set; }
        }

        public class Informacion
        {
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public dynamic Payload { get; set; }

        }
    }
}
