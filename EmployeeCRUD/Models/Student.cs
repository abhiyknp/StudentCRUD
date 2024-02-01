using System.ComponentModel.DataAnnotations;

namespace StudentCRUD.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Student Name")]
        public string Name { get; set; }
        public string Course { get; set; }
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }        
        public DateTime? DateOfBirth { get; set; }

    }
}
