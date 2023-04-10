using System.ComponentModel.DataAnnotations;

namespace _3D_Printer_Software.Models
{
    public class TriangleShape
    {

        [Required(ErrorMessage = "Please enter a value for side 1.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive integer value for side 1.")]
        public int? Side1 { get; set; }

        [Required(ErrorMessage = "Please enter a value for side 2.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive integer value for side 2.")]
        public int? Side2 { get; set; }

        [Required(ErrorMessage = "Please enter a value for side 3.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive integer value for side 3.")]
        public int? Side3 { get; set; }

        public int? Perimeter { get; set; }
        public double? Liqued { get; set; }
    }
}
