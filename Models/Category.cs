using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaxSoftWebSite.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="نوع الوظيفة")]
        public string CategoryName { get; set; }
        [Required]
        [AllowHtml]
        [Display(Name = "وصف نوع الوظيفة")]
        public string CategoryDescription { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}