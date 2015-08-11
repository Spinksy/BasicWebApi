using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BasicWebAPI.Models;

namespace BasicWebAPI.Controllers
{
    [EnableCors("http://localhost:62939", "*", "*")]
    public class DocumentController : ApiController
    {
        private DocumentRepository _repo;

        public DocumentController()
        {
            _repo = new DocumentRepository();
        }

        // GET: api/Document
        public IEnumerable<Document> Get()
        {
            return _repo.Retrieve();
        }

        // GET: api/Document/5
        public Document Get(int id)
        {
            return _repo.Retrieve(id);
        }

        // POST: api/Document
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/Document/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Document/5
        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        
    }
}
