using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModisAPI.Models;
using ModisAPI.Models.WorkerServices;

namespace ModisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentiController : ControllerBase
    {
        private IWorkerServicesStudenti worker;

        public StudentiController(IWorkerServicesStudenti _worker)
        {
            worker = _worker;
        }
        // GET: api/Studenti
        [HttpGet]
        public IEnumerable<Studente> Get()
        {
            return worker.RestituisciListaStudenti();
        }

        // GET: api/Studenti/5
        [HttpGet("{id}", Name = "Get")]
        public Studente Get(int id)
        {
            return worker.RestituisciStudente(id);
        }

        // POST: api/Studenti
        [HttpPost]
        public int Post([FromBody] Studente stud)
        {
            return worker.Registrazione(stud.Id , stud.Nome, stud.Cognome);
        }

        // PUT: api/Studenti/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
