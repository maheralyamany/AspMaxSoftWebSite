using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaxSoftWebSite.Models
{
    public class ContactModel:PhoneNumberViewModel
    {
        [Required]
        [Display(Name ="اسم المرسل")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "موضوع الرسالة")]
        public string Subject { get; set; }
        [Required]
        [Display(Name = "محتوى الرسالة")]
        public string Message { get; set; }

    }
}