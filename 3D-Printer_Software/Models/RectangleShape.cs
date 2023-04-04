using System.ComponentModel.DataAnnotations;

namespace _3D_Printer_Software.Models
{
    public class RectangleShape
    {
        
        
            [Required(ErrorMessage = "Please enter the length of the rectangle")]
            public double Length { get; set; }

            [Required(ErrorMessage = "Please enter the width of the rectangle")]
            public double Width { get; set; }

            public double Perimeter { get; set; }
        }

    }

