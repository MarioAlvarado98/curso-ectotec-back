using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_Ectotec_Back.Models.Entities
{
    public class Sesion
    {
        public bool Resultado { get; set; }
        public string Mensaje { get; set; }
        public string Token { get; set; }
    }
}
