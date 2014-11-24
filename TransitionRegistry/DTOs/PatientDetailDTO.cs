using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using TransitionRegistry.Models;

namespace TransitionRegistry.DTOs
{
    public class PatientDetailDTO : PatientDTO
    {
        public Race Race { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public ICollection<StudyDTO> Studies { get; set; }
        public String ArchiveDescription { get; set; }

        public PatientDetailDTO(Patient p) : base(p)
        {
            this.Race = p.Race;
            this.Email = p.Email;
            this.PhoneNumber = p.PhoneNumber;
            this.Description = p.Description;
            this.Studies = p.Studies.Select(s => new StudyDTO(s)).ToList();
            this.ArchiveDescription = p.ArchiveDescription;
        }
    }
}