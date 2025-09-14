using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class User
    {   
        [DisplayName("User Id")]
        public int Id { get; set; }



        [Required(ErrorMessage = "Enter Your First Name")]
        [DisplayName("First Name")]
        [StringLength(20,ErrorMessage ="Name Brtween 3,20",MinimumLength =3)]
        public string Fname { get; set; }

        [Required(ErrorMessage = "Enter Your Last Name")]
        [StringLength(20, ErrorMessage = "Name Brtween 3,20", MinimumLength = 3)]

        [DisplayName("Last Name")]
        public string Lname { get; set; }


        [EmailAddress]
        [Required(ErrorMessage ="Enter Valid Email")]
        public string Email { get; set; } = "user@gmail.com";


        [DataType(DataType.Password)]
        public string Password { get; set; } = "1234";
        [NotMapped]
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "*")]
        [Compare("Password",ErrorMessage ="password do not match")]

        public string Confirmpassword { get; set; } = "1234";

    }
}
