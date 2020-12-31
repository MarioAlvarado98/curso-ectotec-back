using System;
using System.Collections.Generic;

#nullable disable

namespace Curso_Ectotec_Back.Models.Entities
{
    public partial class Persona
    {
        public Persona()
        {
            GrupoPersonas = new HashSet<GrupoPersona>();
        }

        public int personaId { get; set; }
        public string nombreCompleto { get; set; }
        public string correo { get; set; }

        public virtual ICollection<GrupoPersona> GrupoPersonas { get; set; }
    }
}
