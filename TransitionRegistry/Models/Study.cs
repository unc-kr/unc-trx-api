using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransitionRegistry.Models
{
    public class Study
    {
        public int Id { get; set; }
        [Required]
        public string ShortCode { get; set; }
        [Required]
        public string Name { get; set; }
        [DefaultValue(false)]
        public Boolean Archived { get; set; }
        public String ArchiveDescription { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}