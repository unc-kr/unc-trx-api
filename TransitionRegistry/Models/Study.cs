using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransitionRegistry.Models
{
    public class Study : BaseEntity
    {
        [Required, MaxLength(64)]
        public string ShortCode { get; set; }

        [Required, MaxLength(512)]
        public string Name { get; set; }

        [MaxLength(512)]
        public string Grant { get; set; }

        [MaxLength(2048)]
        public string Description { get; set; }

        [DefaultValue(false)]
        public Boolean Archived { get; set; }

        [DefaultValue(""), MaxLength(2048)]
        public String ArchiveDescription { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}