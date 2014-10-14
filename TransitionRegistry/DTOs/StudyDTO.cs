using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransitionRegistry.Models;

namespace TransitionRegistry.DTOs
{
    public class StudyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public StudyDTO() { }

        public StudyDTO(Study s)
        {
            this.Id = s.Id;
            this.Name = s.Name;
        }

    }
}