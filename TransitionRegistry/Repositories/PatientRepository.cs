using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TransitionRegistry.Models;

namespace TransitionRegistry.Repositories
{
    public class PatientRepository : BaseRepository<TransitionRegistryContext, Patient>
    {
        public Patient GetSingleWithStudies(int id)
        {
            var entity = this.GetAll().Include(p => p.Studies).FirstOrDefault(x => x.Id == id);
            this.UpdateLastAccessed(entity);
            return entity;
        }
    }
}