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

namespace TransitionRegistry.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PatientsController : ApiController
    {
        private TransitionRegistryContext db = new TransitionRegistryContext();

        // GET: api/Patients
        public IQueryable<PatientDTO> GetPatients()
        {
            return from p in db.Patients
                   select new PatientDTO()
                   {
                        Id = p.Id,
                        Name = p.Name,
                        MrnNumber = p.MrnNumber,
                        Birthday = p.Birthday,
                        Gender = p.Gender,
                        ParticipantType = p.ParticipantType
                   };
        }

        // GET: api/Patients/5
        [ResponseType(typeof(Patient))]
        public async Task<IHttpActionResult> GetPatient(int id)
        {
            var patient = await db.Patients.Include(p => p.Studies).Select(p =>
                new PatientDetailDTO()
                {
                    Id = p.Id,
                    Name = p.Name,
                    MrnNumber = p.MrnNumber,
                    Birthday = p.Birthday,
                    Gender = p.Gender,
                    ParticipantType = p.ParticipantType,
                    Studies = p.Studies.Select(s => new StudyDTO()
                    {
                        Id = s.Id,
                        Name = s.Name,
                    }).ToList()
                }
            ).SingleOrDefaultAsync(s => s.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
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

            db.Entry(patient).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
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
        public async Task<IHttpActionResult> PostPatient(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Patients.Add(patient);
            await db.SaveChangesAsync();

            db.Entry(patient).Collection(p => p.Studies).Load();

            var dto = new PatientDetailDTO(patient);

            return CreatedAtRoute("DefaultApi", new { id = patient.Id }, dto);
        }

        // DELETE: api/Patients/5
        [ResponseType(typeof(Patient))]
        public IHttpActionResult DeletePatient(int id)
        {
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }

            db.Patients.Remove(patient);
            db.SaveChanges();

            return Ok(patient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientExists(int id)
        {
            return db.Patients.Count(e => e.Id == id) > 0;
        }
    }
}