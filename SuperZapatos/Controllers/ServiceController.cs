using SuperZapatos.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuperZapatos.Controllers
{
    public class ServiceController : ApiController
    {
        private DBContext db;

        public ServiceController()
        {
            db = new DBContext();
        }

        [Route("Services/Stores")]
        [HttpGet]
        public IHttpActionResult GetAllStores()
        {
            var algo = new List<string>();
            return Ok(new { artiles = algo });
        }

        [Route("Services/Articles")]
        [HttpGet]
        public IHttpActionResult GetAllArticles()
        {
            var algo = new List<string>();
            return Ok(new { artiles = algo });
        }

        [Route("Services/Articles/Stores/{id}")]
        [HttpGet]
        public IHttpActionResult GetAllArticlesByStore(int id)
        {
            bool success = false;

            if (!db.Stores.Any(q => q.Id == id))
            {
                var error_code = HttpStatusCode.NotFound;
                var error_msg = "Record not Found";
                return Ok(new { success, error_code, error_msg });
            }

            if (id == 0)
            {
                var error_code = HttpStatusCode.BadRequest;
                var error_msg = "malo";
                return Ok(new { success, error_code, error_msg });
            }

            var allArticles = db.Articles.Where(q => q.StoreId == id);
            var algo = new List<string>() { "1" };
            return Ok(new { success, artiles = algo, also = "" });
        }
    }
}
