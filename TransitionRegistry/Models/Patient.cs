using System;
using System.Collections.Generic;
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
<<<<<<< HEAD
=======
        public string Description { get; set; }
>>>>>>> FETCH_HEAD
        public ParticipantType ParticipantType { get; set; }

        public virtual ICollection<Study> Studies { get; set; }
    }
}