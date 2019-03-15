using SuperZapatos.Database;
using SuperZapatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperZapatos.Controllers
{
    public class StoreController : Controller
    {
        private DBContext db;

        public StoreController()
        {
            db = new DBContext();
        }

        // GET: Store
        public ActionResult Index()
        {
            ViewBag.AllStores = db.Stores;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(StoreModel model)
        {
            Store newStore = new Store()
            {
                Name = model.Name,
                Address = model.Address
            };
            db.Stores.Add(newStore);
            db.SaveChanges();
            return Json(newStore, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            Store store = db.Stores.FirstOrDefault(q => q.Id == id);
            StoreModel model = new StoreModel()
            {
                Id = store.Id,
                Name = store.Name,
                Address = store.Address
            };
            return View(model);
        }

        [HttpPost]
        public JsonResult Edit(StoreModel model)
        {
            Store store = db.Stores.FirstOrDefault(q => q.Id == model.Id);
            store.Name = model.Name;
            store.Address = model.Address;
            db.SaveChanges();
            return Json(store, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            List<Article> allArticles = db.Articles.Where(q => q.StoreId == id).ToList();
            allArticles.ForEach(article =>
            {
                db.Articles.Remove(article);
            });
            Store store = db.Stores.FirstOrDefault(q => q.Id == id);
            db.Stores.Remove(store);
            db.SaveChanges();
            return Json(store, JsonRequestBehavior.AllowGet);
        }
    }
}