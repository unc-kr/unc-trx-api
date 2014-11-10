using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TransitionRegistry.Models
{
    public enum Gender
    {
        Female,
        Male
    }

    public enum ParticipantType
    {
        Pediatric,
        Adult
    }


    public class Patient
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string MrnNumber { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public ParticipantType ParticipantType { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Study> Studies { get; set; }
        [DefaultValue(false)]
        public Boolean Archived { get; set; }
        public String ArchiveDescription { get; set; }
    }
}