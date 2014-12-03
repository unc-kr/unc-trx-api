using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TransitionRegistry.Models;

namespace TransitionRegistry.Repositories
{
    public class StudyRepository : BaseRepository<TransitionRegistryContext, Study>
    {
        public Study GetSingleWithPatients(int id)
        {
            var entity = this.GetAll().Include(s => s.Patients).FirstOrDefault(x => x.Id == id);
            this.UpdateLastAccessed(entity);
            return entity;
        }
    }
}