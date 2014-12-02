using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransitionRegistry.Models;

namespace TransitionRegistry.DTOs
{
    public class StudyDetailDTO : StudyDTO
    {
        public ICollection<PatientDTO> Patients { get; set; }
        public String ArchiveDescription { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? LastAccessDate { get; set; }

        public StudyDetailDTO(Study s) : base(s)
        {
            this.Patients = s.Patients.Select(p => new PatientDTO(p)).ToList();
            this.ArchiveDescription = s.ArchiveDescription;

            this.CreatedDate = s.CreatedDate;
            this.LastModifiedDate = s.LastModifiedDate;
            this.LastAccessDate = s.LastAccessDate;
        }
    }
}