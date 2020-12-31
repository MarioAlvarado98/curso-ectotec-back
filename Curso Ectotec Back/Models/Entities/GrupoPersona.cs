using System;
using System.Collections.Generic;

#nullable disable

namespace Curso_Ectotec_Back.Models.Entities
{
    public partial class GrupoPersona
    {
        public int GrupoId { get; set; }
        public int PersonaId { get; set; }

        public virtual Grupo Grupo { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
