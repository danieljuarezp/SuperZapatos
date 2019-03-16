using SuperZapatos.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuperZapatos.Controllers
{
    // [Authorize] sirve para solo servir a usuarios autenticados
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
            bool success = false;
            var stores = db.Stores;
            success = true;
            return Ok(new { success, stores });
        }

        [Route("Services/Articles")]
        [HttpGet]
        public IHttpActionResult GetAllArticles()
        {
            bool success = false;
            var articles = db.Articles;
            success = true;
            return Ok(new { success, articles });
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
            success = true;
            var allArticles = db.Articles.Where(q => q.StoreId == id);
            return Ok(new { success, allArticles });
        }
    }
}
