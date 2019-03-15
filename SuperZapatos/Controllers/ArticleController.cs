using SuperZapatos.Database;
using SuperZapatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperZapatos.Controllers
{
    public class ArticleController : Controller
    {
        private DBContext db;

        public ArticleController()
        {
            db = new DBContext();
        }

        // GET: Article
        public ActionResult AllArticlesByStore(int id)
        {
            ViewBag.StoreName = db.Stores.FirstOrDefault(q => q.Id == id).Name;
            ViewBag.AllArticles = db.Articles.Where(q => q.StoreId == id);
            return View();
        }

        public ActionResult AddArticle(int id)
        {
            Store store = db.Stores.FirstOrDefault(q => q.Id == id);
            ViewBag.StoreName = store.Name;
            ViewBag.StoreId = store.Id;
            return View();
        }

        [HttpPost]
        public JsonResult AddArticle(ArticleModel model)
        {
            Article newArticle = new Article()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                TotalInShelf = model.TotalInShelf,
                TotalInVault = model.TotalInVault,
                StoreId = model.StoreId
            };
            db.Articles.Add(newArticle);
            db.SaveChanges();
            return Json(newArticle, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            Article article = db.Articles.FirstOrDefault(q => q.Id == id);
            ArticleModel model = new ArticleModel()
            {
                Id = article.Id,
                Name = article.Name,
                Description = article.Description,
                Price = article.Price,
                TotalInShelf = article.TotalInShelf,
                TotalInVault = article.TotalInVault,
                StoreId = article.StoreId
            };
            return View(model);
        }

        [HttpPost]
        public JsonResult Edit(ArticleModel model)
        {
            Article article = db.Articles.FirstOrDefault(q => q.Id == model.Id);
            article.Name = model.Name;
            article.Description = model.Description;
            article.Price = model.Price;
            article.TotalInShelf = model.TotalInShelf;
            article.TotalInVault = model.TotalInVault;
            db.SaveChanges();
            return Json(article, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            Article article = db.Articles.FirstOrDefault(q => q.Id == id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return Json(article, JsonRequestBehavior.AllowGet);
        }
    }
}