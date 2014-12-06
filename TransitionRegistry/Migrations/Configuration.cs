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
            var plist = new List<Patient>();
            plist.Add(new Patient() { Name ="John Apple",		MrnNumber="1234567", Birthday = new DateTime(1990, 10, 05), 	Gender = Gender.Male, 	ParticipantType = ParticipantType.Pediatric,	Race = Race.Caucasian });
            plist.Add(new Patient() { Name ="Susan Pear",		MrnNumber="6543219", Birthday = new DateTime(2000, 02, 18), 	Gender = Gender.Female, 	ParticipantType = ParticipantType.Adult,	Race = Race.Caucasian });
            plist.Add(new Patient() { Name ="John Appleseed",		MrnNumber="1292043", Birthday = new DateTime(1993, 10, 12), 	Gender = Gender.Male, 	ParticipantType = ParticipantType.Pediatric,	Race = Race.Caucasian });
            plist.Add(new Patient() { Name ="Annie Hastur",		MrnNumber="9380284", Birthday = new DateTime(2003, 05, 02), 	Gender = Gender.Female, 	ParticipantType = ParticipantType.Adult,	Race = Race.Caucasian });
            plist.Add(new Patient() { Name ="Malcolm Graves",		MrnNumber="9302848", Birthday = new DateTime(1975, 07, 02), 	Gender = Gender.Male, 	ParticipantType = ParticipantType.Pediatric,	Race = Race.Caucasian });
            plist.Add(new Patient() { Name ="Sarah Fortune",		MrnNumber="4376777", Birthday = new DateTime(1980, 06, 12), 	Gender = Gender.Female, 	ParticipantType = ParticipantType.Pediatric,	Race = Race.NativeAmerican });
            plist.Add(new Patient() { Name ="Shauna Vayne",		MrnNumber="2644569", Birthday = new DateTime(1978, 06, 05), 	Gender = Gender.Female, 	ParticipantType = ParticipantType.Pediatric,	Race = Race.AfricanAmerican });
            plist.Add(new Patient() { Name ="Steven Stone",		MrnNumber="2002812", Birthday = new DateTime(1987, 05, 03), 	Gender = Gender.Male, 	ParticipantType = ParticipantType.Pediatric,	Race = Race.Asian });
            
            var slist = new List<Study>();

            slist.Add(new Study() { Name="Red Study", ShortCode="RD", Grant="UNC Kidney Grant", Patients = new List<Patient>(){plist[0], plist[1]}, Archived=true, ArchiveDescription="Finished"	 });
            slist.Add(new Study() { Name = "Green Study", ShortCode = "GR", Grant = "Carolina Grant", Patients = new List<Patient>() { plist[5], plist[7], plist[4], plist[3] }, });
            slist.Add(new Study() { Name = "Purple Study", ShortCode = "PU", Grant = "Kenan Grant", Patients = new List<Patient>() { plist[2], plist[3] }, });
            slist.Add(new Study() { Name = "Black Study", ShortCode = "b", Grant = "UNC Kidney Grant", Patients = new List<Patient>() { plist[6], plist[1] }, });
            slist.Add(new Study() { Name = "Greyjoy Study", ShortCode = "gj", Grant = "Carolina Grant", Patients = new List<Patient>() { plist[0], plist[1], plist[2], plist[4] }, });
                
            foreach(Patient p in plist) {
                context.Patients.AddOrUpdate(x=>x.Name, p);
            }

            foreach(Study s in slist) {
                context.Studies.AddOrUpdate(x=>x.Name, s);
            }
        }
    }
}
