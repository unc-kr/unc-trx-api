using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace TransitionRegistry.Models
{
    public class TransitionRegistryContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TransitionRegistryContext() : base("name=TransitionRegistryContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<TransitionRegistry.Models.Patient> Patients { get; set; }
        public System.Data.Entity.DbSet<TransitionRegistry.Models.Study> Studies { get; set; }

        public override int SaveChanges()
        {
            ObjectContext context = ((IObjectContextAdapter)this).ObjectContext;

            //Find all Entities that are Added/Modified that inherit from my EntityBase
            IEnumerable<ObjectStateEntry> objectStateEntries =
                from e in context.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified)
                where
                    e.IsRelationship == false &&
                    e.Entity != null &&
                    typeof(EntityBase).IsAssignableFrom(e.Entity.GetType())
                select e;

            var currentTime = DateTime.Now;

            foreach (var entry in objectStateEntries)
            {
                var entityBase = entry.Entity as EntityBase;

                if (entry.State == EntityState.Added)
                {
                    entityBase.CreatedDate = currentTime;
                }

                entityBase.LastModifiedDate = currentTime;
            }

            return base.SaveChanges();
        }
    
    }
}
