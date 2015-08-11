using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicWebAPI.Models;

namespace BasicWebAPI.Models
{
    public class Case
    {
        public int CaseId { get; set; }
        public List<int> Documents { get; set; }
        public DateTime DateCreated { get; set; }
    }
}