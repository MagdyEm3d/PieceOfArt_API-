using System.ComponentModel.DataAnnotations;

namespace PiecesOfArt_Application_Assignment.DTOS
{
    public class Categorydto
    {
        [Required(ErrorMessage = "Please Enter Your CategoryName")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Please Enter Your CategoryDescription")]
        public string CategoryDescription { get; set; }
    }
}
