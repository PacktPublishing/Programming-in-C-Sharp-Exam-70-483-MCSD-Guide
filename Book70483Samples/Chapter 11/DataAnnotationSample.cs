using System;
using System.ComponentModel.DataAnnotations;

namespace Chapter11
{
    public class Student
    {
        [Required(ErrorMessage = "Fullname of the student is mandatory")]
        [StringLength(100,MinimumLength =5,ErrorMessage ="Name should have minimum of 5 characters")]
        [DataType(DataType.Text)]
        public string FullName { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Date of Birth")]
        public DateTime DOB { get; set; }
    }
}
