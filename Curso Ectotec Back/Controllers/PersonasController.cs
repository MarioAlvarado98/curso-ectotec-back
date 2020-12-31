using Curso_Ectotec_Back.Models.Entities;
using Curso_Ectotec_Back.Models.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using static Curso_Ectotec_Back.Models.Entities.Respuesta;
using Microsoft.EntityFrameworkCore;

namespace Curso_Ectotec_Back.Controllers
{
    //Línea de código que se debe ejecutar en el gestor de paquetes para tener acceso a la bd
    //Scaffold-DbContext "Data Source=ectotec-cursos.database.windows.net;Initial Catalog=curso-2020;Persist Security Info=True;User ID=ectoadmin;Password=Ectotec.2020;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models/Entities --force
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private PersonaService _personaService { get; set; }
        public PersonasController(PersonaService materiaService)
        {
            _personaService = materiaService;
        }

        [HttpGet]
        public List<Persona> GetPersonas()
        {
            List<Persona> res = _personaService.GetPersonas();
            return res;
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Persona> GetPersona(int id)
        {
            return Ok(_personaService.GetPersona(id));
        }

        [HttpPost]
        public void ActionResult([FromBody]Persona persona)
        {
            _personaService.PostPersona(persona);
        }

        [HttpPut]
        public void PutPersona(Persona persona)
        {
            _personaService.PutPersona(persona);
        }

        [HttpDelete]
        public bool DeletePersona(int id)
        {
            _personaService.DeletePersona(id);
            return true;
        }

        [HttpPatch]
        public IActionResult PatchPersona()
        {
            return Content("");
        }
    }
}
