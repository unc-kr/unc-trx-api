using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TransitionRegistry.DTOs;
using TransitionRegistry.Models;
using TransitionRegistry.Repositories;

namespace TransitionRegistry.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StudiesController : ApiController
    {
        private StudyRepository repo = new StudyRepository();

        // GET: api/Studies
        public IEnumerable<StudyDTO> GetStudies()
        {
            return repo.GetAll().AsEnumerable().Select(s => new StudyDTO(s));
        }

        // GET: api/Studies/5
        [ResponseType(typeof(Study))]
        public IHttpActionResult GetStudy(int id)
        {
            var patient = repo.GetSingleWithPatients(id);

            if (patient == null)
            {
                return NotFound();
            }

            var patientDto = new StudyDetailDTO(patient);

            /* NON-ADMIN
            if (patient.Archived == true)
            {
                return NotFound();
            }
            */

            return Ok(patientDto);
        }

        // PUT: api/Studies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudy(int id, Study patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patient.Id)
            {
                return BadRequest();
            }

            repo.Edit(patient);

            try
            {
                repo.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!repo.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Studies
        [ResponseType(typeof(Study))]
        public IHttpActionResult PostStudy(Study patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.Add(patient);
            repo.Save();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}