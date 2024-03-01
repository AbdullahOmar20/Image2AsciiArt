using System.Drawing;
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
            //Bitmap Result = new Bitmap((int)Asciiwidth,AsciiHeight);
            char[,] result = new char[AsciiHeight, (int)Asciiwidth];
            //int[] scales = {0, 1, 2, 3, 4, 5, 6, 7, 8,9,10,11,12,13,14,15 };
            char[] _AsciiChars = { '#', '#', '@', '%', '=', '+', '*', ':', '-', '.', ' ' };
            for(int i =  0; i < AsciiHeight; i++) 
            {
                for(int j = 0; j<Asciiwidth; j++) 
                {
                    var temp = Image.GetPixel(j, i);
                    int c = (temp.R + temp.B + temp.G) / 3;
                    Color gray = Color.FromArgb(c, c, c);
                    int indx = (gray.R*10) / 255;
                    result[i, j] = _AsciiChars[indx];
                }
            }
            for(int i = 0; i<AsciiHeight; i++)
            {
                for(int j = 0; j<Asciiwidth; j++)
                {
                    Console.Write(result[i,j]);
                }
                Console.WriteLine();
            }
            
        }
    }
}
