using System;
using System.Collections.Generic;

#nullable disable

namespace Curso_Ectotec_Back.Models.Entities
{
    public partial class Materium
    {
        public Materium()
        {
            Grupos = new HashSet<Grupo>();
        }

        public int MateriaId { get; set; }
        public string Nombre { get; set; }
        public int? Creditos { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }

        public virtual ICollection<Grupo> Grupos { get; set; }
    }
}
