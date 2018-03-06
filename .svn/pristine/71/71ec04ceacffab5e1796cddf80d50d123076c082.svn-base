using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using Blog.Models;
namespace Blog.Controllers
{
    public class IndexController : BaseController
    {
        // GET: Index
        private DataBaseContext<LearningNote> _learningNote = new DataBaseContext<LearningNote>();
        public ActionResult Index()
        {
            List<LearningNote> list = _learningNote.GetList("select top 3 * from LearningNotes order by CreateDate desc ").ToList();
            ViewBag.Data = list;
            return View();
        }
        public ActionResult Load()
        {

            List<LearningNote> list = _learningNote.GetListAll().OrderByDescending(p => p.CreateDate).ToList();
            return Json(list);
        }
    }
}