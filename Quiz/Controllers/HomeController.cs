using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiz.Controllers
{
    public class HomeController : Controller
    {

        QuizAppEntities db = new QuizAppEntities();

        [HttpGet]
        public ActionResult tlogin()
        {
           
            return View();
        } 
        [HttpPost]
        public ActionResult tlogin(tbl_admin ad)
        {
            tbl_admin a = db.tbl_admin.Where(x => x.ad_name == ad.ad_name && x.ad_pass == ad.ad_pass).SingleOrDefault();
            if (a != null)
            {
                Session["ad_id"] = ad.ad_id;
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.msg = "Incalid User Name or Password";
            }
            return View();
        }
        public ActionResult slogin()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add_Category()
        {
            //Session["ad_id"] = 2;
            List<tbl_category> catLi = db.tbl_category.OrderByDescending(x => x.cat_id).ToList();
            ViewData["list"] = catLi;
            return View();
        }


        [HttpPost]
        public ActionResult Add_Category(tbl_category cat)
        {
            Session["ad_id"] = 1;
            int ad_id = Convert.ToInt32(Session["ad_id"].ToString());
            List<tbl_category> catLi = db.tbl_category.Where(x => x.cat_fk_ad_id == ad_id).OrderByDescending(x => x.cat_id).ToList();
            ViewData["list"] = catLi;

            tbl_category c = new tbl_category();
           
            c.cat_name = cat.cat_name;
            c.cat_fk_ad_id = Convert.ToInt32(Session["ad_id"].ToString());

            db.tbl_category.Add(c);
            db.SaveChanges();
            return RedirectToAction("Add_Category");
            return View();
        }

        [HttpGet]
        public ActionResult Add_Questions()
        {
            int sid = Convert.ToInt32(Session["ad_id"]);
            List<tbl_category> li = db.tbl_category.Where(x => x.cat_id == sid).ToList();
            ViewBag.list = new SelectList(li,"cat_id","cat_name");
            return View();
        }
        [HttpPost]
        public ActionResult Add_Questions(tbl_questions q)
        {
            int sid = Convert.ToInt32(Session["ad_id"]);
            List<tbl_category> li = db.tbl_category.Where(x => x.cat_id == sid).ToList();
            ViewBag.list = new SelectList(li,"cat_id","cat_name");

            db.tbl_questions.Add(q);
            db.SaveChanges();
            ViewBag.ms = "Question sucessfully Added";
            
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}