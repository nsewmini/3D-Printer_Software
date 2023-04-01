using Microsoft.AspNetCore.Mvc.Rendering;

namespace _3D_Printer_Software.Models
{ 
    public class dropdownlist
{

    private SelectList Shapelist { get; set; }
    public SelectList _Shapelist
    {
        get
        {

            if (Shapelist != null)
                return Shapelist;

            //we return shape list that include circle ,rectangle and triangle 

            return new SelectList(GetShapes(), "ID", "shapetype");
        }
        set
        {
            Shapelist = value;
        }

    }
    //add the shapes for the dropdown list
    private List<ShapesVM> GetShapes()
    {

        var shapes = new List<ShapesVM>();
        shapes.Add(new ShapesVM()
        {
            ID = 1,
            shapetype = "circle"
        });
        shapes.Add(new ShapesVM()
        {
            ID = 2,
            shapetype = "rectangle"
        }); shapes.Add(new ShapesVM()
        {
            ID = 3,
            shapetype = "triangle"
        });
        return shapes;
    }
        public string textbox{ get; set; }
    }
}
