using MaxSoftWebSite.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Net;
using System.Web.Mvc;

namespace MaxSoftWebSite.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
           
            return View(db.Categories.ToList());
        }
        public ActionResult Details(int JobId)
        {
            var Job = db.Jobs.Find(JobId);
            if (Job==null)
            {
                return HttpNotFound();
            }
            if (Session["ApplyResult"] != null)
            {
                ViewData["ApplyEnable"] = false;
                ViewBag.Result = (string)Session["ApplyResult"];
                ViewData["status"] = true;
                Session["ApplyResult"] = null;
            }
            else
            {
                ViewData["status"] = false;
                var UserId = User.Identity.GetUserId();
                if (UserId != null)
                {
                    var GetUser = db.Users.Where(a => a.Id == UserId).SingleOrDefault();
                    var ApplyedJobs = db.ApplyForJobs.Where(a => a.JobId == JobId && a.UserId == UserId).ToList();
                    if (ApplyedJobs.Count > 0)
                    {
                        ViewData["ApplyEnable"] = false;
                        ViewBag.Result = "لقد سبق وتقدمت لنفس الوظيفه";
                        
                    }
                    else if(GetUser.UserType=="Admins" || GetUser.UserType == "الناشرون")
                    {
                        ViewData["ApplyEnable"] = false;
                        ViewBag.Result = "لايمكن للمستخدم "+GetUser.UserType+" التقدم لهذه الوظيفة.";

                        // ViewBag.Result = "%" + "تمت الاظافة بنجاح";
                    }
                    else
                    {
                        ViewData["ApplyEnable"] = true;
                    }
                }
                else
                {
                    ViewData["ApplyEnable"] = true;
                    ViewBag.Result = "للتقدم للوظيفة يرجى تسجيل الدخول اوالاشتراك";
                }
            }
           
           
            Session["JobId"] = JobId;
            return View(Job);
        }

        [Authorize]
        public ActionResult Apply()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Apply(ApplyForJob job)
        {
            if (ModelState.IsValid)
            {

                //var check = db.ApplyForJobs.Where(a => a.JobId == JobId && a.UserId == UserId).ToList();
                //if (check.Count<1)
                //{

                var UserId = User.Identity.GetUserId();
                var JobId = (int)Session["JobId"];
                job.UserId = UserId;
                job.JobId = JobId;
                job.ApplyDate = DateTime.Now;
                db.ApplyForJobs.Add(job);
                db.SaveChanges();
                Session["ApplyResult"] = "تمت الاظافة بنجاح";
                //}
                //else
                //{
                //   Session["ApplyResult"] = "لقد سبق وتقدمت لنفس الوظيفه";

                //}
                return RedirectToAction("Details", new { JobId = (int)Session["JobId"] });
            }
            return View(job);
            
        }
        [Authorize(Roles = "الباحثون")]
        public ActionResult GetJobsByUser()
        {
            var UserId = User.Identity.GetUserId();
            var Jobs = db.ApplyForJobs.Where(a => a.UserId == UserId);
            return View(Jobs.ToList());
        }
        [Authorize]
        public ActionResult DetailsOfJob(int id)
        {
            var Job = db.ApplyForJobs.Find(id);
            if (Job == null)
            {
                return HttpNotFound();
            }
            return View(Job);
        }
        [Authorize(Roles = "الناشرون")]
        public ActionResult GetJobsByPublisher()
        {
            var UserID = User.Identity.GetUserId();
            var Jobs = from app in db.ApplyForJobs
                       join job in db.Jobs
                       on app.JobId equals job.Id
                       where job.User.Id == UserID
                       select app;
            var grouped = from j in Jobs
                          group j by j.job.JobTitle
                        into gr
                          select new JobsViewModel
                          {
                              JobTitle = gr.Key,
                              Items=gr
                          };

            return View(grouped.ToList());
        }

        public ActionResult Edit(int id)
        {
            var job = db.ApplyForJobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

      
        [HttpPost]
        public ActionResult Edit(ApplyForJob job)
        {
            if (ModelState.IsValid)
            {
                job.ApplyDate = DateTime.Now;
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetJobsByUser");
            }
            return View(job);
        }

        public ActionResult About()
        {
           
            return View();
        }
        public ActionResult Delete(int id)
        {
            var job = db.ApplyForJobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(ApplyForJob job)
        {
            try
            {
                // TODO: Add delete logic here
                var Myjob = db.ApplyForJobs.Find(job.Id);
                db.ApplyForJobs.Remove(Myjob);
                db.SaveChanges();
                return RedirectToAction("GetJobsByUser");
            }
            catch
            {
                return View(job);
            }
        }
        [HttpGet]
        public ActionResult Contact()
        {
           

            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactModel contact)
        {
            var mail = new MailMessage();
            var loginInfo = new NetworkCredential("maheralyamany4@gmail.com","700429874");
            mail.From = new MailAddress(contact.Email);
            mail.To.Add(new MailAddress("maheralyamany4@gmail.com"));
            mail.Subject = contact.Subject;
            mail.IsBodyHtml = true;
            string body = "اسم المرسل: " + contact.Name + "<br>" +
                        "بريد المرسل: " + contact.Email + "<br>" +
                        "عنوان الرسالة: " + contact.Subject + "<br>" +
                        "نص الرسالة: <b>" + contact.Message+"</b>";
            mail.Body = body;
            mail.Body = contact.Message;
            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(mail);
            return RedirectToAction("Index");
        }
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string searchName)
        {
            var result = db.Jobs.Where(a => a.JobTitle.Contains(searchName) || a.JobContent.Contains(searchName) || a.Category.CategoryName.Contains(searchName) || a.Category.CategoryDescription.Contains(searchName)).ToList();
            return View(result);
        }
    }
}