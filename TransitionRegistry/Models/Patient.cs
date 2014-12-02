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
        Male,
        Other
    }

    public enum ParticipantType
    {
        Pediatric,
        Adult
    }
    
    public enum Race
    {
        Caucasian,
        AfricanAmerican,
        Asian,
        NativeAmerican,
        PacificIslander,
        Other
    }


    public class Patient
    {
        public int Id { get; set; }

        [Required, MinLength(2)]
        public string Name { get; set; }

        [Required, Column(TypeName = "Date")]
        public DateTime Birthday { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public Race Race { get; set; }

        [Required, MinLength(7), RegularExpression(@"^\d{7,}$")]
        public string MrnNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        public ParticipantType ParticipantType { get; set; }

        [MaxLength(2048)]
        public string Description { get; set; }

        public virtual ICollection<Study> Studies { get; set; }

        [DefaultValue(false)]
        public Boolean Archived { get; set; }

        [DefaultValue(""), MaxLength(2048)]
        public String ArchiveDescription { get; set; }
    }
}