using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectBL.ViewModels.AccountViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "الاسم مطلوب")]
        [MaxLength(100, ErrorMessage = "الاسم طويل جدًا")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "الإيميل مطلوب")]
        [EmailAddress(ErrorMessage = "الإيميل غير صحيح")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "رقم الموبايل مطلوب")]
        [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "رقم موبايل مصري غير صحيح")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "كلمة المرور مطلوبة")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "تأكيد كلمة المرور مطلوب")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "كلمتين المرور مش متطابقين")]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = "اختار نوع الحساب")]
        public string Role { get; set; } = null!;

        public int? CategoryId { get; set; }

        [Range(0, 20, ErrorMessage = "سنين الخبرة بين 0 و20")]
        public int? YearsOfExperience { get; set; }
    }
}
