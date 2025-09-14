using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Product
    {

        [DisplayName("ProductId")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is Invalid")]
        [StringLength(20,ErrorMessage ="Name Between 3,20",MinimumLength =3)]
        public string Title { get; set; }



        [Required(ErrorMessage = "Enter Correct Price")]
        [Range(1000, 50000, ErrorMessage = "Price Between 1000, 50000")]
        public int Price { get; set; }


        [Required(ErrorMessage ="Description is Invalid")]
        public string Description { get; set; }



        [Range(0, 50000, ErrorMessage = "Quantity Between 0, 50000")]
        [Required]
        public int Quantity { get; set; }


        [Required]
        public string ImagePath { get; set; } = "~/images/foldername";



        [DisplayName("Category")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


    }
}
