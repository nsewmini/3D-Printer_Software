using System.ComponentModel.DataAnnotations;

namespace _3D_Printer_Software.Models
{
    public class CircleShape
    {

        [Required(ErrorMessage = "Please enter a value for the radius.")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a non-negative value for the radius.")]
        public double? Radius { get; set; }

        [Required(ErrorMessage = "Please enter a value for the X-coordinate of the center.")]
        public double? CenterX { get; set; }

        [Required(ErrorMessage = "Please enter a value for the Y-coordinate of the center.")]
        public double? CenterY { get; set; }

        public double? Perimeter { get; set; }
    }
}
