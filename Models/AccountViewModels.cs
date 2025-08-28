using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MaxSoftWebSite.Models {
	public class ExternalLoginConfirmationViewModel: PhoneNumberViewModel {
       
    }
    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }
    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
    public class VerifyCodeViewModel
    {
        [Required(ErrorMessage = "الرجاء املاء حقل المزوّد")]
        [Display(Name = "المزوّد")]
        public string Provider { get; set; }
        [Required]
        [Display(Name = "الشفرة")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }
        [Display(Name = "تذكر كلمة المرور هذة!")]
        public bool RememberBrowser { get; set; }
        [Display(Name = "تذكرني")]
        public bool RememberMe { get; set; }
    }
    public class LoginViewModel: PhoneNumberViewModel {
      
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور")]
        public string Password { get; set; }
        [Display(Name = "تذكرني؟")]
        public bool RememberMe { get; set; }
    }
    public class RegisterViewModel: PhoneNumberViewModel {
        [Required]
        [Display(Name = "اسم المستخدم")]
        
        public string UserName { get; set; }
        [Required(ErrorMessage = "الحقل نوع الحساب مطلوب")]
        [Display(Name = "نوع الحساب")]
        public string UserType { get; set; }
       
        [Required]
        [StringLength(100, ErrorMessage = "{0}يجب ان تكون على لاقل {2}", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "تأكيد كلمة المرور")]
        [Compare("Password", ErrorMessage = "كلمات المرور المدخلة غير متطابقة.")]
        public string ConfirmPassword { get; set; }
    }
    public class EditProfileViewModel: PhoneNumberViewModel {
        public int Id { get; set; }
        [Required]
        [Display(Name = "اسم المستخدم")]
        public string UserName { get; set; }
       
        [Required]
        [StringLength(100, ErrorMessage = "{0}يجب ان تكون على لاقل {2}", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور الحالية")]
        public string CurrentPassword { get; set; }
        [StringLength(100, ErrorMessage = "{0}يجب ان تكون على لاقل {2}", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور الجديدة")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "تأكيد كلمة المرور الجديدة")]
        [Compare("NewPassword", ErrorMessage = "كلمات المرور المدخلة غير متطابقة.")]
        public string ConfirmPassword { get; set; }
    }
    public class ResetPasswordViewModel: PhoneNumberViewModel {
        
        [Required]
        [StringLength(100, ErrorMessage = "{0}يجب ان تكون على لاقل {2}", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "تأكيد كلمة المرور")]
        [Compare("Password", ErrorMessage = "كلمات المرور المدخلة غير متطابقة.")]
        public string ConfirmPassword { get; set; }
        public string Code { get; set; }
    }
    public class ForgotPasswordViewModel: PhoneNumberViewModel {
       
    }
}
