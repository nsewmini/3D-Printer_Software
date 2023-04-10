using System.ComponentModel.DataAnnotations;

namespace _3D_Printer_Software.Models
{
    public class RectangleShape
    {
        // put the error message for the lengh
        
        [Required(ErrorMessage = "Please enter a value for the length.")]
        [Range(1, double.MaxValue, ErrorMessage = "Please enter a non-negative value for the length.")]
        public double? Length { get; set; }

        //put the error message for the width
        [Required(ErrorMessage = "Please enter a value for the width.")]
        [Range(1, double.MaxValue, ErrorMessage = "Please enter a non-negative value for the width.")]
       
        public double? Width { get; set; }
        //perimeter data
         public double? Perimeter { get; set; }
        public double? Liqued { get; set; }
    }

    }

