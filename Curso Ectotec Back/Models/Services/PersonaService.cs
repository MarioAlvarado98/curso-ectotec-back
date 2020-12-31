using Curso_Ectotec_Back.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static Curso_Ectotec_Back.Models.Entities.Respuesta;

namespace Curso_Ectotec_Back.Models.Services
{
    public class PersonaService
    {
        public List<Persona> GetPersonas()
        {
            using (var context = new curso2020Context())
            {
                return context.Personas.ToList();
            }
        }

        public Persona GetPersona(int id)
        {
            using (var context = new curso2020Context())
            {
                return context.Personas.Where(p => p.personaId == id).FirstOrDefault();
            }
        }

        public void PostPersona(Persona persona)
        {
            using(var context = new curso2020Context())
            {
                context.Personas.Add(persona);
                context.SaveChanges();
                return;
            }
        }

        public void PutPersona(Persona persona)
        {
            using (var context = new curso2020Context())
            {
                Persona personaDB = context.Personas.Where(p => p.personaId ==
                    persona.personaId).FirstOrDefault();
                personaDB.nombreCompleto = persona.nombreCompleto;
                personaDB.correo = persona.correo;
                context.SaveChanges();
                return;
            }
        }

        public void DeletePersona(int id)
        {
            using (var context = new curso2020Context())
            {
                Persona personaDB = context.Personas.Where(p => p.personaId ==
                    id).FirstOrDefault();
                context.Personas.Remove(personaDB);
                context.SaveChanges();
                return;
            }
        }
    }
}
