using System;
using System.Collections.Generic;

#nullable disable

namespace Curso_Ectotec_Back.Models.Entities
{
    public partial class Grupo
    {
        public Grupo()
        {
            GrupoPersonas = new HashSet<GrupoPersona>();
        }

        public int GrupoId { get; set; }
        public int MateriaId { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }

        public virtual Materium Materia { get; set; }
        public virtual ICollection<GrupoPersona> GrupoPersonas { get; set; }
    }
}
