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
    public class StudiesController : ApiController
    {
        private TransitionRegistryContext db = new TransitionRegistryContext();

        // GET: api/Studies
        public IQueryable<StudyDTO> GetStudies()
        {
            return from s in db.Studies
                   select new StudyDTO()
                   {
                        Id = s.Id,
                        Name = s.Name
                   };
        }

        // GET: api/Studies/5
        [ResponseType(typeof(StudyDetailDTO))]
        public async Task<IHttpActionResult> GetStudy(int id)
        {
            var study = await db.Studies.Include(s => s.Patients).Select(s =>
                new StudyDetailDTO()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Patients = s.Patients.Select(p => new PatientDTO()
                    {
                        Id = p.Id,
                        Name = p.Name,
                        MrnNumber = p.MrnNumber,
                        Birthday = p.Birthday,
                        Gender = p.Gender,
                        ParticipantType = p.ParticipantType
                    }).ToList()
                }
            ).SingleOrDefaultAsync(s => s.Id == id);
            
            if (study == null)
            {
                return NotFound();
            }

            return Ok(study);
        }

        // PUT: api/Studies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudy(int id, Study study)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != study.Id)
            {
                return BadRequest();
            }

            db.Entry(study).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudyExists(id))
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
        public async Task<IHttpActionResult> PostStudy(Study study)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Studies.Add(study);
            await db.SaveChangesAsync();

            db.Entry(study).Collection(s => s.Patients).Load();

            var dto = new StudyDetailDTO(study);

            return CreatedAtRoute("DefaultApi", new { id = study.Id }, dto);
        }

        // DELETE: api/Studies/5
        [ResponseType(typeof(Study))]
        public IHttpActionResult DeleteStudy(int id)
        {
            Study study = db.Studies.Find(id);
            if (study == null)
            {
                return NotFound();
            }

            db.Studies.Remove(study);
            db.SaveChanges();

            return Ok(study);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudyExists(int id)
        {
            return db.Studies.Count(e => e.Id == id) > 0;
        }
    }
}