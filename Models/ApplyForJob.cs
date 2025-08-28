using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaxSoftWebSite.Models
{
    public class ApplyForJob
    {
        public int Id { get; set; }
        [Required]
        [AllowHtml]
        [Display(Name = "الرسالة")]
        public string Message { get; set; }
        [Display(Name = "تاريخ الإرسال")]
        public DateTime ApplyDate { get; set; }
        [Display(Name = "الوظيفة")]
        public int JobId { get; set; }
        public string  UserId { get; set; }
        [Display(Name = "اسم المستخدم")]
        public virtual Job job { get; set; }
        public virtual ApplicationUser user { get; set; }


    }
}