namespace TransitionRegistry.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TransitionRegistry.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TransitionRegistry.Models.TransitionRegistryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TransitionRegistry.Models.TransitionRegistryContext";
        }

        protected override void Seed(TransitionRegistry.Models.TransitionRegistryContext context)
        {
            var p1 = new Patient() { Id = 1, Name = "John Apple", MrnNumber = "123456", Birthday = new DateTime(1990, 10, 05), Gender = Gender.Male, ParticipantType = ParticipantType.Adult };
            var p2 = new Patient() { Id = 2, Name = "Susan Pear", MrnNumber = "654321", Birthday = new DateTime(2000, 02, 18), Gender = Gender.Female, ParticipantType = ParticipantType.Pediatric };
            
            var s1 = new Study() { Id = 1, Name = "Red Study", Patients = new List<Patient>() {p1, p2} };
            var s2 = new Study() { Id = 2, Name = "Green Study", Patients = new List<Patient>() { p1 } };

            context.Patients.AddOrUpdate(x => x.Id,
                p1,
                p2
            );

            context.Studies.AddOrUpdate(x => x.Id, 
                s1,
                s2
            );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
