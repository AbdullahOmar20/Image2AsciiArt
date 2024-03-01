using System.Drawing;
using System.Text;
namespace Image2AsciiArt
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the path of the image you want to convert");
            string ImagePath = Console.ReadLine();
            Bitmap Image = new Bitmap(ImagePath,true);
            int ImageWidth = Image.Width;
            const double Asciiwidth = 680;
            int ScallingFactor = (int)Math.Ceiling(Asciiwidth / ImageWidth);
            int AsciiHeight = Image.Height * ScallingFactor;
            
            char[] _AsciiChars = { '#', '#', '@', '%', '=', '+', '*', ':', '-', '.', ' ' };
            StringBuilder stringBuilder = new StringBuilder();
            for(int i =  0; i < AsciiHeight; i++) 
            {
                for(int j = 0; j<Asciiwidth; j++) 
                {
                    var temp = Image.GetPixel(j, i);
                    int c = (temp.R + temp.B + temp.G) / 3;
                    Color gray = Color.FromArgb(c, c, c);
                    int indx = (gray.R*10) / 255;
                    
                    stringBuilder.Append(_AsciiChars[indx]);
                }
                stringBuilder.Append('\n');
            }
            StreamWriter sw = new StreamWriter(@"D:\sample.txt");
            sw.Write(stringBuilder);
            sw.Flush();
            sw.Close();
            
            Console.WriteLine(stringBuilder);

        }
    }
}
