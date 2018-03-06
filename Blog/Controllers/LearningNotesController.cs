using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Controllers
{
    
    public class LearningNotesController : BaseController
    {
        // GET: LearningNotes
        private DataBaseContext<LearningNote> _learningNote = new DataBaseContext<LearningNote>();
        private DataBaseContext<Comment> _comment = new DataBaseContext<Comment>();
        List<Comment> list = new List<Comment>();
        [UserAuthorize]
        public ActionResult Index()
        {
            int id =Convert.ToInt32(Request.QueryString["id"]);
            if (id != 0)
            {             
                LearningNote learningNote = _learningNote.Get(p => p.NotesID == id);
                learningNote.NotesReadNum++;
                _learningNote.Update(learningNote);
                int count = learningNote.CommentID.Count(p => p == ',');
                if (CacheOperate.GetCache("Comment" + id) == null|| CacheOperate.GetCache("Comment" + id).ToString()== "")
                {
                    foreach (string cid in learningNote.CommentID.Split(','))
                    {
                        if (cid != "")
                        {
                            int d = Convert.ToInt32(cid);
                            Comment comment = _comment.Get(p => p.CommentID == d);
                            list.Add(comment);
                            GetComment(d);
                        }
                    }
                    if (list.Count != 0)
                    {
                        CacheOperate.SetCache("Comment" + id, list, TimeSpan.FromMinutes(5));
                        ViewBag.Comment = list;
                        ViewBag.Count = list.Count;
                    }
                }
                else
                {
                    object obj = CacheOperate.GetCache("Comment" + id);
                    ViewBag.Comment = obj;
                    ViewBag.Count = (obj as List<Comment>).Count;
                }               
                ViewBag.Data =learningNote;
                
            }
            else 
            {
                List<LearningNote> list = _learningNote.GetList("select top 6 * from LearningNotes order by CreateDate desc ");
                ViewBag.Data = list;
            }
            
            return View();
        }
        public ActionResult Load()
        {
            int id = Convert.ToInt32(Request["id"]);
            List<LearningNote> list = _learningNote.GetList("select top 2 * from LearningNotes where NotesID<" + id + " order by CreateDate desc");
            if (list.Count!=0)
            {
                return Json(list);
            }
            else 
            {
                Message m=new Message();
                m.MessageType=1;
                m.MessageContent="学习笔记加载完成";
                return Json(m);
            }            
        }       
        /// <summary>
        /// 获取评论
        /// </summary>
        /// <param name="id">commentID</param>
        public void GetComment(int id)
        {
            List<Comment> data = _comment.GetList(p => p.ParentCommentID == id);
            if (data.Count != 0)
            {
                foreach (var result in data)
                {
                    list.Add(result);
                    GetComment(result.CommentID);
                }
            }
        }

        
    }
}