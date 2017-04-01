using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeList.Models
{
    public class Code : Entity
    {
        public string Name { get; set;  }
        public string Description { get; set; }
        public string Program { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}