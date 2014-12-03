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
    public class PatientsController : ApiController
    {
        private PatientRepository repo = new PatientRepository();

        // GET: api/Patients
        public IEnumerable<PatientDTO> GetPatients()
        {
            return repo.GetAll().AsEnumerable().Select(p => new PatientDTO(p));
        }

        // GET: api/Patients/5
        [ResponseType(typeof(Patient))]
        public IHttpActionResult GetPatient(int id)
        {
            var patient = repo.GetSingleWithStudies(id);

            if (patient == null)
            {
                return NotFound();
            }

            var patientDto = new PatientDetailDTO(patient);

            /* NON-ADMIN
            if (patient.Archived == true)
            {
                return NotFound();
            }
            */

            return Ok(patientDto);
        }

        // PUT: api/Patients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPatient(int id, Patient patient)
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

        // POST: api/Patients
        [ResponseType(typeof(Patient))]
        public IHttpActionResult PostPatient(Patient patient)
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