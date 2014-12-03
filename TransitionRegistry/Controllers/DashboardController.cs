using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TransitionRegistry.DTOs;
using TransitionRegistry.Models;
using TransitionRegistry.Repositories;

namespace TransitionRegistry.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DashboardController : ApiController
    {
        private PatientRepository patientsRepo = new PatientRepository();
        private StudyRepository studiesRepo = new StudyRepository();

        // POST: api/Studies/5/Patients/3
        [ResponseType(typeof(void))]
        public IHttpActionResult GetDashboard()
        {
            var patients = patientsRepo.GetRecent(10).AsEnumerable().Select(p => new PatientDTO(p));
            var studies = studiesRepo.GetRecent(10).AsEnumerable().Select(s => new StudyDTO(s));

            var dict = new Dictionary<String, Object>();
            dict.Add("Patients", patients);
            dict.Add("Studies", studies);

            return Ok(dict);
        }
    }
}
