using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ColorPicker
{
    public class ChoosenColors
    {
        private Color color;

       public string colorName { get; set; }
       public string colorHex { get; set; }
       public string colorRGBA { get; set; }
       public string colorHue { get; set; }

        /// <summary>
        /// Setting the color values.
        /// </summary>
        /// <param name="color"></param>
        public ChoosenColors(Color color)
        {
            this.color = color;
            this.colorName = color.Name;
            this.colorHex = color.ToArgb().ToString("X6");
            this.colorRGBA = color.R.ToString() + ",";
            this.colorRGBA += color.G.ToString() + ",";
            this.colorRGBA += color.B.ToString() + ",";
            this.colorRGBA += color.A.ToString();
            this.colorHue = color.GetHue().ToString();

            //Checkng if the the first character of colorName is upper case because if it is not then it is the hex value not the name.
            if (!char.IsUpper(colorName[0]))
            {
                colorName = "Color Name Not Stored In DataBase";
            }
        }
    }
}
