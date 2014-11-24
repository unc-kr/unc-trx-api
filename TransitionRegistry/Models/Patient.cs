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

    public enum Diagnosis
    {
        DiagA,
        DiagB,
        DiagC
    }

    public enum Race
    {
        Caucasian,
        AfricanAmerican,
        Asian,
        NativeAmerican,
        PacificIslander
    }


    public class Patient
    {
        public int Id { get; set; }

        [Required, MinLength(2)]
        public string Name { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Birthday { get; set; }

        public Gender Gender { get; set; }

        public Race Race { get; set; }

        [Required, MinLength(6), RegularExpression(@"^\d{6,}$")]
        public string MrnNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public ParticipantType ParticipantType { get; set; }

        public Diagnosis Diagnosis { get; set; }

        [MaxLength(2048)]
        public string Description { get; set; }

        public virtual ICollection<Study> Studies { get; set; }

        [DefaultValue(false)]
        public Boolean Archived { get; set; }

        [DefaultValue(""), MaxLength(2048)]
        public String ArchiveDescription { get; set; }
    }
}