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
    public class CaseController : ApiController
    {
        CaseRepository _repo;

        public CaseController()
        {
            _repo = new CaseRepository();
        }

        // GET: api/Case
        public IEnumerable<Case> Get()
        {
            return _repo.Retrieve();
        }

        // GET: api/Case/5
        public Case Get(int id)
        {
            return _repo.Retrieve(1);
        }

        // POST: api/Case
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Case/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Case/5
        public void Delete(int id)
        {
        }
    }
}
