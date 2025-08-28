using System.ComponentModel.DataAnnotations;
namespace MaxSoftWebSite.Models {
	public class PhoneNumberViewModel
    {
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 9)]
        [Required(ErrorMessage = "الرجاء املاء حقل رقم التلفون")]
        [Display(Name = "رقم التلفون")]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
