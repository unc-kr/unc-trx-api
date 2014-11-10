using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TransitionRegistry.Models;

namespace TransitionRegistry.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EnrollmentsController : ApiController
    {
        private TransitionRegistryContext db = new TransitionRegistryContext();

        // POST: api/Studies/5/Patients/3
        [ResponseType(typeof(void))]
        public IHttpActionResult Post(int studyId, [FromUri] int patientId)
        {
            var study = db.Studies.Find(studyId);
            var patient = db.Patients.Find(patientId);

            if (study == null || patient == null)
            {
                return NotFound();
            }

            study.Patients.Add(patient);

            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Studies/5/Patients/3
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int studyId, [FromUri] int patientId)
        {
            var study = db.Studies.Find(studyId);
            var patient = db.Patients.Find(patientId);

            if (study == null || patient == null)
            {
                return NotFound();
            }

            study.Patients.Remove(patient);

            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
