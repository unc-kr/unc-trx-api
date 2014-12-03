using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransitionRegistry.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? LastAccessDate { get; set; }
    }
}