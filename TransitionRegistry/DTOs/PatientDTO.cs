using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using TransitionRegistry.Models;

namespace TransitionRegistry.DTOs
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public string MrnNumber { get; set; }
        public ParticipantType ParticipantType { get; set; }
        public Boolean Archived { get; set; }

        public PatientDTO(Patient p)
        {
            this.Id = p.Id;
            this.Name = p.Name;
            this.Birthday = p.Birthday;
            this.Gender = p.Gender;
            this.MrnNumber = p.MrnNumber;
            this.ParticipantType = p.ParticipantType;
            this.Archived = p.Archived;
        }
    }
}