using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicWebAPI.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string DocumentName { get; set; }
        public DateTime DateCreated { get; set; }
        public int CaseId { get; set; }
    }
}