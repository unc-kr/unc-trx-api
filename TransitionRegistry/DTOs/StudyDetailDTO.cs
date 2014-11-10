using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransitionRegistry.Models;

namespace TransitionRegistry.DTOs
{
    public class StudyDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public ICollection<PatientDTO> Patients { get; set; }
        public Boolean Archived { get; set; }
        public String ArchiveDescription { get; set; }

        public StudyDetailDTO() { }

        public StudyDetailDTO(Study s)
        {
            this.Id = s.Id;
            this.Name = s.Name;
            this.Patients = s.Patients.Select(p => new PatientDTO(p)).ToList();
            this.Archived = s.Archived;
            this.ArchiveDescription = s.ArchiveDescription;
        }
    }
}